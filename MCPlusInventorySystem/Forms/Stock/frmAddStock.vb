Imports Google.Protobuf.WellKnownTypes
Imports MySql.Data.MySqlClient

Public Class frmAddStock
    Dim userLoginComp As String
    Dim compDesc As String

    'LOAD THIS FORM
    Private Sub frmAddStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.centralAuditDB IsNot "" Then
            userLoginComp = get_user_comp(My.Settings.CurrentUserID)
            compDesc = get_company_desc(userLoginComp)

            OrderSlipClass.LoadMPurchaseSupCB()
        End If
    End Sub

    Private Sub btnORShowItems_Click(sender As Object, e As EventArgs) Handles btnORShowItems.Click
        ItemListClass.show_ItemList("MP", False, True)
        frmItemList.ShowDialog()
    End Sub

    Private Sub btnOSSubmit_Click(sender As Object, e As EventArgs) Handles btnOSSubmit.Click
        ' -----------------------------
        ' Validate required header fields
        ' -----------------------------
        If String.IsNullOrWhiteSpace(cbMPSup.Text) OrElse
       String.IsNullOrWhiteSpace(dateMPDRDate.Text) OrElse
       String.IsNullOrWhiteSpace(txtMPRefNo.Text) OrElse
       String.IsNullOrWhiteSpace(dateMPDelivery.Text) OrElse
       String.IsNullOrWhiteSpace(txtMPRemarks.Text) Then

            MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
            Exit Sub
        End If

        ' -----------------------------
        ' Validate item rows
        ' -----------------------------
        If dgOS.Rows.Count = 0 Then
            MsgBox("Please select item(s) to add stock.", MsgBoxStyle.Exclamation, "No Items")
            Exit Sub
        End If

        ' -----------------------------
        ' VALIDATION PHASE - Check all qty and cost values
        ' -----------------------------
        For Each row As DataGridViewRow In dgOS.Rows
            If row.IsNewRow Then Continue For

            Dim qtyVal = row.Cells("stock_qty").Value
            Dim costVal = row.Cells("stock_unitcost").Value

            If qtyVal Is Nothing OrElse costVal Is Nothing OrElse
               String.IsNullOrWhiteSpace(qtyVal.ToString()) OrElse
               String.IsNullOrWhiteSpace(costVal.ToString()) Then

                MessageBox.Show($"Missing quantity or unit cost in row {row.Index + 1}.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim qty As Integer
            Dim cost As Decimal

            If Not Integer.TryParse(qtyVal.ToString(), qty) Then
                MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not Decimal.TryParse(costVal.ToString(), cost) Then
                MessageBox.Show($"Invalid unit cost format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Next

        ' -----------------------------
        ' Confirm submission
        ' -----------------------------
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update the stock balances?",
                                                 "Confirm Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result <> DialogResult.Yes Then
            MessageBox.Show("Operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' -----------------------------
        ' Process item rows
        ' -----------------------------

        Using conn As New MySqlConnection(InvDBConn.ConnectionString)
            conn.Open()
            Dim trans As MySqlTransaction = conn.BeginTransaction()

            Try
                '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                Dim allSuccess As Boolean = True
                Dim rowCount As Integer = 0
                Dim mpID As String = GenerateMPurchaseID(userLoginComp)

                For Each row As DataGridViewRow In dgOS.Rows
                    If row.IsNewRow Then Continue For

                    rowCount += 1

                    ' Extract values
                    Dim skuCode As String = row.Cells("stock_skucode").Value?.ToString().Trim()
                    Dim qtyValue = row.Cells("stock_qty").Value
                    Dim costValue = row.Cells("stock_unitcost").Value

                    ' Validate numeric values
                    Dim addQty As Integer
                    Dim unitCost As Decimal

                    If Not Integer.TryParse(qtyValue.ToString(), addQty) OrElse
                        Not Decimal.TryParse(costValue.ToString(), unitCost) Then
                        MessageBox.Show($"Invalid number format in row {row.Index + 1}.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        allSuccess = False
                        Exit For
                    End If

                    ' Perform database updates
                    Dim balanceUpdated As Boolean = add_itembalance(conn, trans, userLoginComp, My.Settings.Store, "Q001", skuCode, addQty)

                    Dim detailCreated As Boolean = create_mpurchase_l(conn, trans, userLoginComp, mpID, rowCount, lblSupCode.Text, My.Settings.Store,
                                                          skuCode, addQty, unitCost, My.Settings.CurrentUserID)
                    'MsgBox("detailCreated : " + detailCreated.ToString)
                    If Not (balanceUpdated AndAlso detailCreated) Then
                        MessageBox.Show($"Failed to process row {row.Index + 1} for SKU: {skuCode}.", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Throw New Exception($"Failed to process {skuCode}.")
                    End If

                    If Not update_itemprice_when_received(conn, trans, userLoginComp, My.Settings.Store, skuCode, unitCost) Then
                        Throw New Exception($"Failed to update item price {skuCode}.")
                    End If

                    'itemmvt add D00 writes here stock out
                    Dim createdMovement As Boolean = create_movement(conn, trans,
                           userLoginComp,
                           My.Settings.Store,
                           "Q001",
                           skuCode,
                           addQty.ToString,
                           lblSupCode.Text,
                           My.Settings.Store,
                           "----",
                           "Q001",
                           "D00",
                           "MP-" + lblSupCode.Text + mpID,
                          My.Settings.CurrentUserID)
                    If Not (createdMovement) Then
                        Throw New Exception($"Failed to process create_movement.")
                    End If


                Next

                ' -----------------------------
                ' Create Header and Reset Form
                ' -----------------------------

                Dim headerCreated As Boolean = create_mpurchase_h(conn, trans, userLoginComp, mpID, lblSupCode.Text, My.Settings.Store,
                                                          txtMPRefNo.Text, dateMPDRDate.Text, dateMPDelivery.Text,
                                                          3, txtMPRemarks.Text, My.Settings.CurrentUserID)

                If Not (headerCreated) Then
                    Throw New Exception($"Failed to add header.")
                End If

                '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                trans.Commit()

                StockClass.show_ItemBalanceList(True)
                StockClass.show_recent_stockin(True)
                StockClass.cachedStockInLines = Nothing
                ItemPriceClass.cachedItemPrices = Nothing
                MessageBox.Show("Stock balances successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ResetOSForm()

                Me.Close()
            Catch ex As Exception
                ' Rollback on any error
                trans.Rollback()
                MessageBox.Show("Trans failed. All changes have been rolled back." & vbCrLf & ex.Message,
                                "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                conn.Close()
            End Try
        End Using


    End Sub

    Private Sub ResetOSForm()
        cbMPSup.Text = ""
        lblSupCode.Text = ""

        dateMPDRDate.Value = DateTime.Now
        dateMPDRDate.Checked = False
        dateMPDRDate.Format = DateTimePickerFormat.Custom
        dateMPDRDate.CustomFormat = " "

        txtMPRefNo.Text = ""

        dateMPDelivery.Value = DateTime.Now
        dateMPDelivery.Checked = False
        dateMPDelivery.Format = DateTimePickerFormat.Custom
        dateMPDelivery.CustomFormat = " "

        txtMPRemarks.Text = ""
        dgOS.Rows.Clear()
    End Sub


    Private Sub dgOS_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgOS.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgOS.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgOS.Rows(e.RowIndex)
            If columnName = "stock_qty" Then
                dgOS.CurrentCell = dgOS.Rows(e.RowIndex).Cells("stock_qty")
                dgOS.BeginEdit(True)
            ElseIf columnName = "stock_unitcost" Then
                dgOS.CurrentCell = dgOS.Rows(e.RowIndex).Cells("stock_unitcost")
                dgOS.BeginEdit(True)
            ElseIf columnName = "stock_remove" Then
                ' Optional: confirm deletion
                Dim confirmResult = MessageBox.Show("Are you sure you want to remove this Item?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmResult = DialogResult.Yes Then
                    dgOS.Rows.RemoveAt(e.RowIndex)
                End If
            End If
        End If
    End Sub

    'input decimal and integer only for dgOS <---
    Private Sub dgOS_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgOS.EditingControlShowing
        Dim tb As TextBox = TryCast(e.Control, TextBox)

        If tb IsNot Nothing Then
            ' Remove any existing handlers
            RemoveHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
            AddHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
        End If
    End Sub

    Private Sub DataGridViewTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim colName As String = dgOS.CurrentCell.OwningColumn.Name

        If colName = "stock_qty" Then
            ' Allow only digits and control keys (e.g., Backspace)
            If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If

        ElseIf colName = "stock_unitcost" Then
            Dim tb As TextBox = CType(sender, TextBox)

            ' Allow digits, one dot, and control keys
            If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
                e.Handled = True
            End If

            ' Only allow one dot
            If e.KeyChar = "."c AndAlso tb.Text.Contains(".") Then
                e.Handled = True
            End If
        End If
    End Sub
    '--->

    Private Sub dateOSDate_ValueChanged(sender As Object, e As EventArgs) Handles dateMPDRDate.ValueChanged
        If dateMPDRDate.Checked Then
            dateMPDRDate.Format = DateTimePickerFormat.Short
        End If
    End Sub

    Private Sub dateOSDelivery_ValueChanged(sender As Object, e As EventArgs) Handles dateMPDelivery.ValueChanged
        If dateMPDelivery.Checked Then
            dateMPDelivery.Format = DateTimePickerFormat.Short
        End If
    End Sub

    Private Sub tcAddStock_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class
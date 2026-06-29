Imports System.Windows
Imports MySql.Data.MySqlClient
Public Class frmStockOut
    Dim userLoginComp As String
    Dim compDesc As String
    Public Shared isApprovalModule As Boolean
    Private Sub frmStockOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.centralAuditDB IsNot "" Then
            userLoginComp = get_user_comp(My.Settings.CurrentUserID)
            compDesc = get_company_desc(userLoginComp)
            'TransferClass.LoadTTStoreCB()
            If Not isApprovalModule Then
                tcStockOut.TabPages.Add(tabTransferItem)
                tcStockOut.TabPages.Add(tabTransferAll)
                tcStockOut.TabPages.Add(tabTransfer10)
                tcStockOut.TabPages.Add(tabTransfer0)
                tcStockOut.TabPages.Add(tabTransfer1)
                tcStockOut.TabPages.Add(tabTransfer2)
                tcStockOut.TabPages.Add(tabTransfer3)
                tcStockOut.TabPages.Add(tabTransferPartialReceived)
                tcStockOut.TabPages.Add(tabTransfer4)
                tcStockOut.TabPages.Add(tabTransfer9)
                TransferClass.LoadTTStoreCB()
                TransferClass.LoadCBStoreAll()
            ElseIf isApprovalModule Then
                tcStockOut.TabPages.Add(tabTransfer10)
                tcStockOut.TabPages.Add(tabTransferAll)
                tcStockOut.TabPages.Add(tabTransfer0)
                tcStockOut.TabPages.Add(tabTransfer1)
                tcStockOut.TabPages.Add(tabTransfer2)
                tcStockOut.TabPages.Add(tabTransfer3)
                tcStockOut.TabPages.Add(tabTransferPartialReceived)
                tcStockOut.TabPages.Add(tabTransfer4)
                tcStockOut.TabPages.Add(tabTransfer9)
            End If
        End If
    End Sub
    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub btnTTShowItems_Click(sender As Object, e As EventArgs) Handles btnTTShowItems.Click
        ItemListClass.show_ItemList("TT", True, True)
        frmItemList.ShowDialog()
    End Sub

    Private Sub dgTransfer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTransfer.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgTransfer.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgTransfer.Rows(e.RowIndex)
            If columnName = "transfer_qty" Then
                dgTransfer.CurrentCell = dgTransfer.Rows(e.RowIndex).Cells("transfer_qty")
                dgTransfer.BeginEdit(True)
            ElseIf columnName = "transfer_total_amount" Then
                dgTransfer.CurrentCell = dgTransfer.Rows(e.RowIndex).Cells("transfer_total_amount")
                dgTransfer.BeginEdit(True)
            ElseIf columnName = "transfer_remove" Then
                ' Optional: confirm deletion
                Dim confirmResult = MessageBox.Show("Are you sure you want to remove this Item?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmResult = DialogResult.Yes Then
                    dgTransfer.Rows.RemoveAt(e.RowIndex)
                End If
            End If
        End If
    End Sub

    'input decimal and integer only for dgTransfer <---
    Private Sub dgTransfer_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgTransfer.EditingControlShowing
        Dim tb As TextBox = TryCast(e.Control, TextBox)

        If tb IsNot Nothing Then
            ' Remove any existing handlers
            RemoveHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
            AddHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
        End If
    End Sub

    Private Sub DataGridViewTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim colName As String = dgTransfer.CurrentCell.OwningColumn.Name

        If colName = "transfer_qty" Then
            ' Allow only digits and control keys (e.g., Backspace)
            If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If
        ElseIf colName = "transfer_total_amount" Then
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

    '----< BUTTON TRANSFER
    Private Sub btnTTTransfer_Click(sender As Object, e As EventArgs) Handles btnTTTransfer.Click

        ' -----------------------------
        ' Validate required fields
        ' -----------------------------
        If String.IsNullOrWhiteSpace(cbTTStoreDest.Text) OrElse
       String.IsNullOrWhiteSpace(txtTTDR.Text) OrElse
       String.IsNullOrWhiteSpace(txtTTRemarks.Text) Then

            MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
            Exit Sub
        End If

        If dgTransfer.Rows.Count = 0 Then
            MsgBox("No items found in the transfer list.", MsgBoxStyle.Exclamation, "No Items")
            Exit Sub
        End If

        ' -----------------------------
        ' Validate and collect transfer items
        ' -----------------------------
        Dim transferList As New List(Of (itemloc As String, skuCode As String, qty As Integer, total_amount As Decimal))

        For Each row As DataGridViewRow In dgTransfer.Rows
            If row.IsNewRow Then Continue For

            Dim skuCode As String = row.Cells("transfer_skucode").Value?.ToString().Trim()
            Dim qtyVal = row.Cells("transfer_qty").Value
            Dim totalAmountVal = row.Cells("transfer_total_amount").Value
            Dim itemloc As String = row.Cells("transfer_loc_code").Value?.ToString().Trim()

            If String.IsNullOrWhiteSpace(skuCode) OrElse qtyVal Is Nothing OrElse String.IsNullOrWhiteSpace(qtyVal.ToString()) OrElse
               String.IsNullOrWhiteSpace(totalAmountVal.ToString()) Then
                MessageBox.Show($"Please input quantity and total amount {row.Index + 1}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim qty As Integer
            Dim totalAmount As Decimal
            If Not Integer.TryParse(qtyVal.ToString(), qty) Then
                MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If qty <= 0 Then
                MessageBox.Show($"Quantity must greater than 0 in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not Decimal.TryParse(totalAmountVal.ToString(), totalAmount) Then
                MessageBox.Show($"Invalid total amount format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim isValidQty As Boolean = itemBal_picklist_isValidQty(userLoginComp, My.Settings.Store, itemloc, skuCode, qty)
            If Not isValidQty Then
                MessageBox.Show($"Insufficient quantity for Location: {itemloc} SKU: {skuCode}", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            transferList.Add((itemloc, skuCode, qty, totalAmount))
        Next

        ' -----------------------------
        ' Confirm submission
        ' -----------------------------
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to transfer these items to the selected store/branch?",
                                                 "Confirm Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result <> DialogResult.Yes Then
            MessageBox.Show("Operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' -----------------------------
        ' Process within MySQL Transaction
        ' -----------------------------
        Using conn As New MySqlConnection(InvDBConn.ConnectionString)
            conn.Open()
            Dim trans As MySqlTransaction = conn.BeginTransaction()

            Try
                Dim rowCount As Integer = 0
                Dim drNumber As Integer = Convert.ToInt32(txtTTDR.Text)
                Dim orderID As String = If(txtTTOrderID.Text, "").Trim()
                ' Process each item
                For Each item In transferList
                    rowCount += 1

                    'Dim decreaseSuccess As Boolean = decrease_itembalance(conn, trans, userLoginComp, My.Settings.Store, item.skuCode, item.qty)
                    'Dim pickAdded As Boolean = insertto_picklist(conn, trans, userLoginComp, My.Settings.Store, drNumber, item.skuCode, item.qty, My.Settings.CurrentUserID)
                    Dim transferLCreated As Boolean = create_transfer_l(conn, trans, userLoginComp,
                                                                    My.Settings.Store,
                                                                    lblTTStoreCodeDest.Text,
                                                                    drNumber,
                                                                    item.itemloc,
                                                                    "Q001",
                                                                    rowCount,
                                                                    item.skuCode,
                                                                    item.qty,
                                                                    item.total_amount,
                                                                    0,
                                                                    My.Settings.CurrentUserID)

                    If Not (transferLCreated) Then
                        Throw New Exception($"Failed to process item {item.skuCode} at row {rowCount}.")
                    End If
                Next

                ' Create transfer header
                Dim headerSuccess As Boolean = create_transfer_h(conn, trans, userLoginComp,
                                                             My.Settings.Store,
                                                             lblTTStoreCodeDest.Text,
                                                             drNumber,
                                                             "0",
                                                             txtTTRemarks.Text, orderID,
                                                             My.Settings.CurrentUserID)

                If Not headerSuccess Then
                    Throw New Exception("Failed to create transfer header.")
                End If

                ' Commit all changes
                trans.Commit()

                'StockClass.show_ItemBalanceList()
                MessageBox.Show("The items have been successfully transferred.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ResetTransferForm()
                StockClass.show_transfer_h(True)
                StockClass.cachedTransferOutLine = Nothing
            Catch ex As Exception
                ' Rollback on any error
                trans.Rollback()
                MessageBox.Show("Transfer failed. All changes have been rolled back." & vbCrLf & ex.Message,
                            "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End Using

    End Sub

    Private Sub ResetTransferForm()
        cbTTStoreDest.Text = ""
        lblTTStoreCodeDest.Text = ""
        txtTTRemarks.Text = ""
        txtTTDR.Text = GenerateDR(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)
        dgTransfer.Rows.Clear()
    End Sub

    Private Sub dgTransfers_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgTransfer0.CellClick, dgTransfer1.CellClick, dgTransfer2.CellClick, dgTransfer3.CellClick, dgTransfer4.CellClick, dgTransferPartialReceived.CellClick, dgTransfer9.CellClick, dgTransfer10.CellClick, dgTransferAll.CellClick

        If e.RowIndex >= 0 Then
            Dim dgView As DataGridView = CType(sender, DataGridView)
            Dim columnName As String = dgView.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgView.Rows(e.RowIndex)

            Dim inputComp As String = selectedRow.Cells(0).Value.ToString()
            Dim statusCode As String = selectedRow.Cells(1).Value.ToString()
            Dim dr As String = selectedRow.Cells(4).Value.ToString()
            Dim storeCode As String = selectedRow.Cells(2).Value.ToString()
            Dim storeCodeDest As String = selectedRow.Cells(3).Value.ToString()


            ' Loop from 0 to 4 to match column name pattern "th_viewX"
            If columnName = $"th_viewParRec" Then
                frmTransferData.selectedTransferHStatus = statusCode
                StockClass.show_transfer_h()
                StockClass.show_transfer_l(inputComp, dr, storeCode, storeCodeDest, "out")
                frmTransferData.ShowDialog()
            ElseIf columnName = $"th_viewAll" Then
                frmTransferData.selectedTransferHStatus = statusCode
                StockClass.show_transfer_h()
                StockClass.show_transfer_l(inputComp, dr, storeCode, storeCodeDest, "out")
                frmTransferData.ShowDialog()

            Else
                For i As Integer = 0 To 10
                    If columnName = $"th_view{i}" Then
                        frmTransferData.selectedTransferHStatus = i
                        StockClass.show_transfer_h()
                        StockClass.show_transfer_l(inputComp, dr, storeCode, storeCodeDest, "out")
                        frmTransferData.ShowDialog()
                        Exit For
                    End If
                Next
            End If

            'If e.ColumnIndex = 6 Then
            '    StockClass.show_transfer_l(inputComp, dr, storeCode, storeCodeDest)
            '    frmTransferData.ShowDialog()
            'End If
        End If
    End Sub
    Private Sub tcStockOut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcStockOut.SelectedIndexChanged
        StockClass.show_transfer_h()
    End Sub

    Private Sub txtAllStatusFind_TextChanged(sender As Object, e As EventArgs) Handles txtAllStatusFind.TextChanged
        TransferClass.itemListSearch(txtAllStatusFind.Text, lblTTStoreCodeDestAll.Text)
    End Sub
End Class
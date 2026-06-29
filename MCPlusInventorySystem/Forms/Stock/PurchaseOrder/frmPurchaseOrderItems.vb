Imports System.Windows.Input
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Tls.Crypto

Public Class frmPurchaseOrderItems
    Dim userLoginComp As String
    Dim compDesc As String

    Public Shared selectedPOStatus As String ' para malaman kung anong status tab ang seleceted

    Private Sub frmPurchaseOrderItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox("Status : " + selectedPOStatus)
        If My.Settings.centralAuditDB IsNot "" Then
            userLoginComp = get_user_comp(My.Settings.CurrentUserID)
            compDesc = get_company_desc(userLoginComp)
        End If
        With dgPOItemList.ColumnHeadersDefaultCellStyle
            .Font = New System.Drawing.Font("Arial Narrow", 10, FontStyle.Bold)
        End With

        With dgPODRItems.ColumnHeadersDefaultCellStyle
            .Font = New System.Drawing.Font("Arial Narrow", 10, FontStyle.Bold)
        End With

        If selectedPOStatus = "1" Then
            btnReceivedPO.Visible = True
            dgPOItemList.Columns("polist_qtydelivered").Visible = False
        ElseIf selectedPOStatus = "partial" Then
            btnReceivedPO.Visible = True
            'datePODelivery.Enabled = False
            'txtaRemarks.ReadOnly = True
            dgPOItemList.Columns("polist_actualunitcost").ReadOnly = True
            dgPOItemList.Columns("polist_actualreceivedqty").ReadOnly = True
            panelShowHistoryDR.Visible = True

            For Each row As DataGridViewRow In dgPOItemList.Rows
                If row.IsNewRow Then Continue For

                Dim appQtyVal As Integer = Val(row.Cells("polist_qty").Value)
                Dim recQtyVal As Integer = Val(row.Cells("polist_actualreceivedqty").Value)

                ' Default color
                row.DefaultCellStyle.BackColor = Color.White

                If appQtyVal <> recQtyVal Then
                    row.DefaultCellStyle.BackColor = Color.LightSalmon
                    row.Cells("polist_qtydelivered").Style.BackColor = Color.SeaShell
                Else
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                    row.Cells("polist_qtydelivered").Value = "complete"
                    row.Cells("polist_qtydelivered").ReadOnly = True
                End If
            Next

        ElseIf selectedPOStatus = "2" Then
            datePODelivery.Enabled = False
            txtaRemarks.ReadOnly = True
            panelShowHistoryDR.Visible = True
            dgPOItemList.Columns("polist_actualunitcost").ReadOnly = True
            dgPOItemList.Columns("polist_actualreceivedqty").ReadOnly = True
            dgPOItemList.Columns("polist_qtydelivered").Visible = False
            panelReceiving.Visible = False
            For Each row As DataGridViewRow In dgPOItemList.Rows
                If row.IsNewRow Then Continue For

                Dim appQtyVal As Integer = Val(row.Cells("polist_qty").Value)
                Dim recQtyVal As Integer = Val(row.Cells("polist_actualreceivedqty").Value)

                ' Default color
                row.DefaultCellStyle.BackColor = Color.White

                If appQtyVal <> recQtyVal Then
                    row.DefaultCellStyle.BackColor = Color.LightSalmon
                    row.Cells("polist_qtydelivered").Style.BackColor = Color.SeaShell
                Else
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                    row.Cells("polist_qtydelivered").Value = "complete"
                    row.Cells("polist_qtydelivered").ReadOnly = True
                End If
            Next
        End If
    End Sub

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        datePODelivery.Value = DateTime.Now
        datePODelivery.Checked = False
        datePODelivery.Format = DateTimePickerFormat.Custom
        datePODelivery.CustomFormat = " "
        txtaRemarks.Text = ""
        dgPOItemList.Rows.Clear()
        txtRefNo.Text = ""
        datePODelivery.Enabled = True
        txtaRemarks.ReadOnly = False
        btnReceivedPO.Visible = False
        dgPOItemList.Columns("polist_actualunitcost").ReadOnly = False
        dgPOItemList.Columns("polist_actualreceivedqty").ReadOnly = False
        panelShowHistoryDR.Visible = False
        dgPOItemList.Columns("polist_qtydelivered").Visible = True
        panelReceiving.Visible = True
        panelReceiptDR.Visible = False
        panelReceiptDR.SendToBack()
        btnSelectPODR.Text = "- select -"
        dgPODR.Rows.Clear()
        dgPODRItems.Rows.Clear()
    End Sub

    Private Sub datePODelivery_ValueChanged(sender As Object, e As EventArgs) Handles datePODelivery.ValueChanged
        If datePODelivery.Checked Then
            datePODelivery.Format = DateTimePickerFormat.Short
        End If
    End Sub

    Private Sub dgPOItemList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPOItemList.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgPOItemList.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgPOItemList.Rows(e.RowIndex)
            If columnName = "polist_actualreceivedqty" Then
                dgPOItemList.CurrentCell = dgPOItemList.Rows(e.RowIndex).Cells("polist_actualreceivedqty")
                dgPOItemList.BeginEdit(True)
            ElseIf columnName = "polist_actualunitcost" Then
                dgPOItemList.CurrentCell = dgPOItemList.Rows(e.RowIndex).Cells("polist_actualunitcost")
                dgPOItemList.BeginEdit(True)
            ElseIf columnName = "polist_qtydelivered" Then
                dgPOItemList.CurrentCell = dgPOItemList.Rows(e.RowIndex).Cells("polist_qtydelivered")
                dgPOItemList.BeginEdit(True)
            End If
        End If
    End Sub

    'input decimal and integer only for dgOS <---
    Private Sub dgPOItemList_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgPOItemList.EditingControlShowing
        Dim tb As TextBox = TryCast(e.Control, TextBox)

        If tb IsNot Nothing Then
            ' Remove any existing handlers
            RemoveHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
            AddHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
        End If
    End Sub

    Private Sub DataGridViewTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim colName As String = dgPOItemList.CurrentCell.OwningColumn.Name

        If colName = "polist_actualreceivedqty" Then
            ' Allow only digits and control keys (e.g., Backspace)
            If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If

        ElseIf colName = "polist_actualunitcost" Then
            Dim tb As TextBox = CType(sender, TextBox)

            ' Allow digits, one dot, and control keys
            If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
                e.Handled = True
            End If

            ' Only allow one dot
            If e.KeyChar = "."c AndAlso tb.Text.Contains(".") Then
                e.Handled = True
            End If
        ElseIf colName = "polist_qtydelivered" Then
            ' Allow only digits and control keys (e.g., Backspace)
            If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub
    '--->


    Private Sub btnReceivedPO_Click(sender As Object, e As EventArgs) Handles btnReceivedPO.Click
        ' -----------------------------
        ' Validate required fields
        ' -----------------------------
        If String.IsNullOrWhiteSpace(txtaRemarks.Text) OrElse String.IsNullOrWhiteSpace(datePODelivery.Text) Then

            MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
            Exit Sub
        End If

        If dgPOItemList.Rows.Count = 0 Then
            MsgBox("No items found in the Purchase Order list.", MsgBoxStyle.Exclamation, "No Items")
            Exit Sub
        End If
        If selectedPOStatus = "1" OrElse selectedPOStatus = "partial" Then
            If String.IsNullOrWhiteSpace(txtRefNo.Text) Then
                MsgBox("Please fill in the supplier document reference no. fields.", MsgBoxStyle.Exclamation, "Validation Error")
                Exit Sub
            End If
        End If

        Dim isPartialReceived As Boolean
        Dim POList As New List(Of (skuCode As String, toReceivedQtyVal As Integer, qtyReceived As Integer, actualUnitCost As Decimal, qtyDelivered As Integer))

        For Each row As DataGridViewRow In dgPOItemList.Rows
            If row.IsNewRow Then Continue For

            Dim rowCount As String = row.Cells("polist_rowcount").Value?.ToString().Trim()
            Dim skuCodeVal As String = row.Cells("polist_sku").Value?.ToString().Trim()
            Dim toReceivedQtyVal = CInt(row.Cells("polist_qty").Value)
            Dim receivedQtyVal = row.Cells("polist_actualreceivedqty").Value
            Dim actualUnitCostVal = row.Cells("polist_actualunitcost").Value
            Dim qtyDeliveredVal = row.Cells("polist_qtydelivered").Value

            If selectedPOStatus = "1" Then
                If receivedQtyVal Is Nothing OrElse String.IsNullOrWhiteSpace(receivedQtyVal.ToString()) Then
                    MessageBox.Show($"Please input quantity to row {rowCount}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

            Else
                If qtyDeliveredVal Is Nothing OrElse String.IsNullOrWhiteSpace(qtyDeliveredVal.ToString()) Then
                    MessageBox.Show($"Please input quantity and unit cost to row {rowCount}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If

            Dim qtyReceived As Integer
            Dim cost As Decimal
            If Not Integer.TryParse(receivedQtyVal.ToString(), qtyReceived) Then
                MessageBox.Show($"Invalid quantity format in row {rowCount}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim qtyDeliveredStr As String = If(qtyDeliveredVal Is Nothing, "", qtyDeliveredVal.ToString().Trim())
            Dim qtyDelivered As Integer
            If String.IsNullOrEmpty(qtyDeliveredStr) OrElse qtyDeliveredStr = "complete" Then
                qtyDelivered = 0 ' or handle differently
            ElseIf Not Integer.TryParse(qtyDeliveredStr, qtyDelivered) Then
                MessageBox.Show($"Invalid quantity format in row {rowCount}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If qtyReceived < 1 Then
                If actualUnitCostVal Is Nothing OrElse String.IsNullOrWhiteSpace(actualUnitCostVal.ToString()) Then
                    MessageBox.Show($"Please copy the unit cost to the actual unit cost if the actual received quantity is 0 at row {rowCount}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If Not Decimal.TryParse(actualUnitCostVal.ToString(), cost) OrElse cost <= 0 Then
                    MessageBox.Show($"Please copy the unit cost to the actual unit cost if the actual received quantity is 0 at row {rowCount}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                If actualUnitCostVal Is Nothing OrElse String.IsNullOrWhiteSpace(actualUnitCostVal.ToString()) Then
                    MessageBox.Show($"Please input unit cost to row {rowCount}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If Not Decimal.TryParse(actualUnitCostVal.ToString(), cost) Then
                    MessageBox.Show($"Invalid unit cost format in row {rowCount}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If


            If selectedPOStatus = "1" Then
                If toReceivedQtyVal < qtyReceived Then
                    MessageBox.Show($"Oops! You entered a quantity that exceeds the quantity to be received for row {rowCount}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf toReceivedQtyVal > qtyReceived Then
                    isPartialReceived = True
                End If
            Else
                If toReceivedQtyVal < (qtyReceived + qtyDelivered) Then
                    MessageBox.Show($"Oops! You entered a quantity that exceeds the quantity to be received for row {rowCount}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf toReceivedQtyVal > (qtyReceived + qtyDelivered) Then
                    isPartialReceived = True
                End If
            End If

            POList.Add((skuCodeVal, toReceivedQtyVal, qtyReceived, cost, qtyDelivered))
        Next

        ' -----------------------------
        ' Confirm submission
        ' -----------------------------
        Dim headerStatus As Integer = If(isPartialReceived, 1, 2)
        Dim confirmMsg As String = If(isPartialReceived,
                              "Do you confirm that this PO was partially received?",
                              "Do you confirm that this PO was received and is now complete?")

        Dim result As DialogResult = MessageBox.Show(confirmMsg, "Yes, Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result <> DialogResult.Yes Then
            MessageBox.Show("Purchase Order Receiving cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                Dim supplier As String = lblSuppCode.Text
                Dim poNum As Integer = Convert.ToInt32(txtPONum.Text)

                Dim dateNow As Date? = Nothing
                If selectedPOStatus = "1" Then
                    dateNow = datePODelivery.Text
                End If

                ' Create transfer header 
                Dim headerPOSucess As Boolean = Update_PO_Header(conn, trans, userLoginComp, My.Settings.Store, txtPONum.Text, headerStatus, 1, dateNow)
                If Not headerPOSucess Then
                    Throw New Exception("Failed to update Purchase Order Header.")
                End If

                Dim receivingID As Integer = GetNextPOReceivingId(conn, trans)
                'MsgBox(receivingID)

                Dim ReceivingHPOUpdated As Boolean = InsertPOReceivingHeader(conn, trans,
                                      receivingID, userLoginComp, My.Settings.Store, lblSuppCode.Text, txtPONum.Text, txtRefNo.Text,
                                        datePODelivery.Text, txtaRemarks.Text, My.Settings.CurrentUserID)
                If Not (ReceivingHPOUpdated) Then
                    Throw New Exception($"Failed to received header.")
                End If

                ' -----------------------------
                'Process each item
                For Each item In POList
                    rowCount += 1
                    Dim lineStatus As Integer = If(isPartialReceived AndAlso item.toReceivedQtyVal > item.qtyReceived, 1, 2)

                    Dim foundRows() As DataRow = StockClass.dtItemListPO.Select("sku_code = '" & item.skuCode & "'")
                    If foundRows.Length > 0 Then

                        Dim LinePOUpdated As Boolean = Update_PO_Line(conn, trans, userLoginComp, My.Settings.Store, txtPONum.Text, item.skuCode, lineStatus, (item.qtyReceived + item.qtyDelivered), item.actualUnitCost)
                        If Not (LinePOUpdated) Then
                            Throw New Exception($"Failed to process item {item.skuCode} at row {rowCount}.")
                        End If
                        If selectedPOStatus = "1" Then
                            Dim ReceivingLPOUpdated As Boolean = InsertPOReceivingLine(conn, trans, receivingID, userLoginComp, My.Settings.Store, lblSuppCode.Text, txtPONum.Text, txtRefNo.Text, item.skuCode, item.qtyReceived, datePODelivery.Text, My.Settings.CurrentUserID)
                            If Not (ReceivingLPOUpdated) Then
                                Throw New Exception($"Failed to received item {item.skuCode} at row {rowCount}.")
                            End If


                            If Not update_itemprice_when_received(conn, trans, userLoginComp, My.Settings.Store, item.skuCode, item.actualUnitCost) Then
                                Throw New Exception($"Failed to update item price {item.skuCode}.")
                            End If

                            ' Add item balance
                            If Not add_itembalance(conn, trans, userLoginComp, My.Settings.Store, "Q001", item.skuCode, item.qtyReceived) Then
                                Throw New Exception($"Failed to process {item.skuCode}.")
                            End If

                            'itemmvt add D00 writes here stock out
                            If item.qtyReceived > 0 Then
                                Dim createdMovement As Boolean = create_movement(conn, trans,
                                                                                   userLoginComp,
                                                                                   My.Settings.Store,
                                                                                   "Q001",
                                                                                   item.skuCode,
                                                                                   item.qtyReceived.ToString,
                                                                                   lblSuppCode.Text,
                                                                                   My.Settings.Store,
                                                                                   "----",
                                                                                   "Q001", ' can add features to selection of queuing if it has multiple queuing location 
                                                                                   "D00",
                                                                                    "PO-" + lblSuppCode.Text + txtPONum.Text,
                                                                                  My.Settings.CurrentUserID)
                                If Not (createdMovement) Then
                                    Throw New Exception($"Failed to process create_movement.")
                                End If
                            End If

                        Else
                            If item.qtyDelivered > 0 Then
                                Dim ReceivingLPOUpdated As Boolean = InsertPOReceivingLine(conn, trans, receivingID, userLoginComp, My.Settings.Store, lblSuppCode.Text, txtPONum.Text, txtRefNo.Text, item.skuCode, item.qtyDelivered, datePODelivery.Text, My.Settings.CurrentUserID)
                                If Not (ReceivingLPOUpdated) Then
                                    Throw New Exception($"Failed to received item {item.skuCode} at row {rowCount}.")
                                End If

                                If Not update_itemprice_when_received(conn, trans, userLoginComp, My.Settings.Store, item.skuCode, item.actualUnitCost) Then
                                    Throw New Exception($"Failed to update item price {item.skuCode}.")
                                End If

                                ' Add item balance
                                If Not add_itembalance(conn, trans, userLoginComp, My.Settings.Store, "Q001", item.skuCode, item.qtyDelivered) Then
                                    Throw New Exception($"Failed to process {item.skuCode}.")
                                End If

                                'itemmvt add D00 writes here stock out
                                Dim createdMovement As Boolean = create_movement(conn, trans,
                                       userLoginComp,
                                       My.Settings.Store,
                                       "Q001",
                                       item.skuCode,
                                       item.qtyDelivered.ToString,
                                       lblSuppCode.Text,
                                       My.Settings.Store,
                                       "----",
                                       "Q001", ' can add features to selection of queuing if it has multiple queuing location 
                                       "D00",
                                       "PO-" + lblSuppCode.Text + txtPONum.Text,
                                      My.Settings.CurrentUserID)
                                If Not (createdMovement) Then
                                    Throw New Exception($"Failed to process create_movement.")
                                End If
                            End If
                        End If
                    End If
                Next

                ' Commit all changes
                trans.Commit()

                MessageBox.Show("This Purchase Order has been received.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                StockClass.show_po_h(True)
                StockClass.cachedPOLine = Nothing
                StockClass.cachedPOReceivingHeaders = Nothing
                StockClass.cachedPOReceivingLine = Nothing
                ItemPriceClass.cachedItemPrices = Nothing
                StockClass.show_ItemBalanceList(True)
                Me.Close()
            Catch ex As Exception
                ' Rollback on any error
                trans.Rollback()
                MessageBox.Show("Purchase Order modification failed.. All changes have been rolled back." & vbCrLf & ex.Message,
                            "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub btnShowHistoryDR_Click(sender As Object, e As EventArgs) Handles btnShowHistoryDR.Click
        panelReceiptDR.Visible = True
        panelReceiptDR.BringToFront()
    End Sub

    Private Sub bthBackToReceiving_Click(sender As Object, e As EventArgs) Handles bthBackToReceiving.Click
        panelReceiptDR.Visible = False
        panelReceiptDR.SendToBack()
    End Sub

    Private Sub btnSelectPODR_Click(sender As Object, e As EventArgs) Handles btnSelectPODR.Click
        dgPODR.Visible = True
        dgPODR.BringToFront()
        dgPODR.Focus()
    End Sub
    Private Sub dgPODR_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPODR.CellClick
        If e.RowIndex >= 0 Then
            ' Get selected row from current form
            Dim row As DataGridViewRow = dgPODR.Rows(e.RowIndex)
            Dim deliveryDate As String = row.Cells("podr_deliverydate").Value.ToString()
            Dim reference As String = row.Cells("podr_reference").Value.ToString()
            Dim receivingID As String = row.Cells("podr_receivingid").Value.ToString()

            StockClass.show_poreceiving_l(receivingID)
            btnSelectPODR.Text = deliveryDate & " (" & reference & ")"
            dgPODR.Visible = False
            dgPODR.SendToBack()
        End If
    End Sub

    Private Sub dgPODR_LostFocus(sender As Object, e As EventArgs) Handles dgPODR.LostFocus
        dgPODR.Visible = False
        dgPODR.SendToBack()
    End Sub

    Private Sub dgPODR_MouseLeave(sender As Object, e As EventArgs) Handles dgPODR.MouseLeave
        If dgPODR.Visible Then
            dgPODR.Visible = False
            dgPODR.SendToBack()
        End If
    End Sub

    Private Sub btnPORPrint_Click(sender As Object, e As EventArgs) Handles btnPORPrint.Click
        GenerateQRClass.PrintLabels(dgPODRItems, "por")
        StockClass.cachedPOReceivingLine = Nothing
    End Sub

    'test
    Private Sub dgPODRItems_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgPODRItems.CellValueChanged
        btnPORPrint.Enabled = dgPODRItems.Rows.Cast(Of DataGridViewRow)().Any(Function(r) CBool(r.Cells("sku_selectprint").Value))
    End Sub
    Private Sub dgPODRItems_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgPODRItems.CurrentCellDirtyStateChanged
        If dgPODRItems.IsCurrentCellDirty Then dgPODRItems.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgPODRItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPODRItems.CellClick
        ' Ensure the click is not on the header row
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgPODRItems.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgPODRItems.Rows(e.RowIndex)
            ' Get existing values

            If columnName = "no_print" Then
                dgPODRItems.CurrentCell = dgPODRItems.Rows(e.RowIndex).Cells("no_print")
                dgPODRItems.BeginEdit(True)

            ElseIf columnName = "sku_code" Then

                Dim valueToCopy As String = dgPODRItems.Rows(e.RowIndex).Cells("sku_code").Value.ToString()
                Clipboard.SetText(valueToCopy)
                MessageBox.Show("Copied: " & valueToCopy)
            End If
        End If
    End Sub

End Class
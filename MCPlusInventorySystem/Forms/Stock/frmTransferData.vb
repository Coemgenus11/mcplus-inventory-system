Imports System.Drawing.Printing
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1.X509
Imports Org.BouncyCastle.Ocsp
Imports Org.BouncyCastle.X509


Public Class frmTransferData
    Dim userLoginComp As String
    Dim compDesc As String

    Public Shared selectedTransferHStatus As String ' para malaman kung anong status tab ang selected
    Private Sub frmTransferData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.centralAuditDB IsNot "" Then
            userLoginComp = get_user_comp(My.Settings.CurrentUserID)
            compDesc = get_company_desc(userLoginComp)
            'TransferClass.LoadTTStoreCB()
        End If

        If selectedTransferHStatus = "0" Then  'For Approval status
            dgTransferL.Columns("tt_approved_qty").Visible = False
            dgTransferL.Columns("tt_received_qty").Visible = False
            If get_user_auth(My.Settings.CurrentUserID).ToString() = "STK" OrElse get_user_auth(My.Settings.CurrentUserID).ToString() = "ADM" Then
                'dgTransferL.Columns("tt_qty").ReadOnly = True
                btnTransferReroute.Visible = True
            End If
            If get_user_auth(My.Settings.CurrentUserID).ToString() = "RPT" OrElse get_user_auth(My.Settings.CurrentUserID).ToString() = "ADM" Then
                btnTransferApproved.Visible = True
                btnTransferReroute.Visible = True
                btnTransferReject.Visible = True
            End If
        ElseIf selectedTransferHStatus = "1" Then   'APPROVED/TO PICK status
            dgTransferL.Columns("tt_qty").Visible = False
            dgTransferL.Columns("tt_received_qty").Visible = False
            If get_user_auth(My.Settings.CurrentUserID).ToString() = "STK" OrElse get_user_auth(My.Settings.CurrentUserID).ToString() = "ADM" Then
                btnTransferPicked.Visible = True
                btnTransferReroute.Visible = True
            End If

        ElseIf selectedTransferHStatus = "2" Then   'Ready to Ship status
            dgTransferL.Columns("tt_qty").Visible = False
            dgTransferL.Columns("tt_received_qty").Visible = False
            If get_user_auth(My.Settings.CurrentUserID).ToString() = "STK" OrElse get_user_auth(My.Settings.CurrentUserID).ToString() = "ADM" Then
                btnTransferDRPrint.Visible = True
                btnTransferReroute.Visible = True
            End If

        ElseIf selectedTransferHStatus = "3" Then 'In transit status
            dgTransferL.Columns("tt_qty").Visible = False
            dgTransferL.Columns("tt_received_qty").Visible = False
            btnTransferGenDR.Visible = True
        ElseIf selectedTransferHStatus = "partial" Then ' PARTIALLY RECEIVED
            dgTransferL.Columns("tt_qty").Visible = False
            panelReturn.Visible = True
            dgTransferL.Columns("tt_return_qty").Visible = True
            dgTransferL.Columns("tt_total_amount_return").Visible = True

        ElseIf selectedTransferHStatus = "4" Then 'Received status
            dgTransferL.Columns("tt_qty").Visible = False
            panelReturn.Visible = True
            dgTransferL.Columns("tt_return_qty").Visible = True
            dgTransferL.Columns("tt_total_amount_return").Visible = True

        ElseIf selectedTransferHStatus = "5" Then ' Optional

        ElseIf selectedTransferHStatus = "9" Then 'CANCEL
            dgTransferL.Columns("tt_qty").ReadOnly = True

        ElseIf selectedTransferHStatus = "10" Then 'Reroute status
            If get_user_auth(My.Settings.CurrentUserID).ToString() = "STK" OrElse get_user_auth(My.Settings.CurrentUserID).ToString() = "ADM" Then
                dgTransferL.Columns("tt_approved_qty").Visible = False
                dgTransferL.Columns("tt_received_qty").Visible = False
                dgTransferL.Columns("tt_remove").Visible = True
                btnTransferShowItems.Visible = True
                btnTransferSubmitReroute.Visible = True
                dgTransferL.Columns("tt_qty").ReadOnly = False
                dgTransferL.Columns("tt_total_amount").ReadOnly = False
            ElseIf get_user_auth(My.Settings.CurrentUserID).ToString() = "RPT" Then
                dgTransferL.Columns("tt_qty").ReadOnly = True
                dgTransferL.Columns("tt_approved_qty").Visible = False
                dgTransferL.Columns("tt_received_qty").Visible = False
            End If

        End If
        'dgTransferL.Columns("").Visible = False

    End Sub

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        '' Assuming you're accessing the main form directly or via Owner
        'Dim thisForm As frmTransferData = CType(Me.Owner, frmTransferData)

        'dgTransferL.Columns("tt_loc").Visible = True
        dgTransferL.Columns("tt_qty").ReadOnly = True
        dgTransferL.Columns("tt_total_amount").ReadOnly = True
        dgTransferL.Columns("tt_qty").Visible = True
        dgTransferL.Columns("tt_approved_qty").Visible = True
        dgTransferL.Columns("tt_received_qty").Visible = True
        dgTransferL.Columns("tt_remove").Visible = False
        btnTransferDRPrint.Visible = False
        btnTransferApproved.Visible = False
        btnTransferReroute.Visible = False
        btnTransferReject.Visible = False
        btnTransferSubmitReroute.Visible = False
        btnTransferShowItems.Visible = False
        btnTransferPicked.Visible = False
        btnTransferGenDR.Visible = False

        dgTransferL.Columns("tt_return_qty").Visible = False
        dgTransferL.Columns("tt_total_amount_return").Visible = False
        dgTransferL.Columns("tt_return_qty").ReadOnly = True
        dgTransferL.Columns("tt_total_amount_return").ReadOnly = True

        dgTransferL.Columns("tt_return_qty").DefaultCellStyle.BackColor = Color.White
        dgTransferL.Columns("tt_total_amount_return").DefaultCellStyle.BackColor = Color.White
        panelReturn.Visible = False
        cancelReturn.Visible = False
        submitReturn.Visible = False
    End Sub

    Private Sub dgTransferL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTransferL.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgTransferL.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgTransferL.Rows(e.RowIndex)
            ' Get existing values
            Dim comp As String = selectedRow.Cells("tt_companycode").Value.ToString()
            Dim storeCodeOrigin As String = My.Settings.Store.ToString()
            Dim storeCodeDest As String = lblTTStoreCodeDest.Text
            Dim dr As String = selectedRow.Cells("tt_dr").Value.ToString()
            Dim skuCode As String = selectedRow.Cells("tt_sku").Value.ToString()

            If columnName = "tt_qty" Then
                If get_user_auth(My.Settings.CurrentUserID).ToString() = "STK" OrElse get_user_auth(My.Settings.CurrentUserID).ToString() = "ADM" OrElse get_user_auth(My.Settings.CurrentUserID).ToString() = "RPT" Then
                    dgTransferL.CurrentCell = dgTransferL.Rows(e.RowIndex).Cells("tt_qty")
                    dgTransferL.BeginEdit(True)
                End If
            ElseIf columnName = "tt_total_amount" Then
                dgTransferL.CurrentCell = dgTransferL.Rows(e.RowIndex).Cells("tt_total_amount")
                dgTransferL.BeginEdit(True)
            ElseIf columnName = "tt_return_qty" Then
                dgTransferL.CurrentCell = dgTransferL.Rows(e.RowIndex).Cells("tt_return_qty")
                dgTransferL.BeginEdit(True)
            ElseIf columnName = "tt_total_amount_return" Then
                dgTransferL.CurrentCell = dgTransferL.Rows(e.RowIndex).Cells("tt_total_amount_return")
                dgTransferL.BeginEdit(True)
            ElseIf columnName = "tt_remove" Then
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to remove this Item/SKU from the list?", "Confirm Removed", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = DialogResult.Yes Then
                    dgTransferL.Rows.RemoveAt(e.RowIndex)
                    'If delete_transfer_l(comp, storeCodeOrigin, storeCodeDest, dr, skuCode) Then
                    '    dgTransferL.Rows.RemoveAt(e.RowIndex)
                    '    MessageBox.Show("Item remove successfully!", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Else
                    '    MessageBox.Show("Failed to delete item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                End If
            End If
        End If

    End Sub

    ' Allow numeric/decimal input for dgTransferL
    Private Sub dgTransferL_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgTransferL.EditingControlShowing
        Dim tb As System.Windows.Forms.TextBox = TryCast(e.Control, System.Windows.Forms.TextBox)

        If tb IsNot Nothing Then
            RemoveHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
            AddHandler tb.KeyPress, AddressOf DataGridViewTextBox_KeyPress
        End If
    End Sub

    Private Sub DataGridViewTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim colName As String = dgTransferL.CurrentCell.OwningColumn.Name

        If colName = "tt_qty" OrElse colName = "tt_return_qty" Then
            ' Allow only digits and control keys
            If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If
        ElseIf colName = "tt_total_amount" OrElse colName = "tt_total_amount_return" Then
            Dim tb As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)

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


    Private Sub btnTransferShowItems_Click(sender As Object, e As EventArgs) Handles btnTransferShowItems.Click
        ItemListClass.show_ItemList("RT", True, True)
        frmItemList.ShowDialog()
    End Sub

    Private Sub btnTransferSubmitReroute_Click(sender As Object, e As EventArgs) Handles btnTransferSubmitReroute.Click
        ' -----------------------------
        ' Validate required fields
        ' -----------------------------
        If dgTransferL.Rows.Count = 0 Then
            MsgBox("No items found in the transfer list.", MsgBoxStyle.Exclamation, "No Items")
            Exit Sub
        End If

        ' -----------------------------
        ' Validate and collect transfer items
        ' -----------------------------
        Dim transferList As New List(Of (itemLoc As String, skuCode As String, qty As Integer, total_amount As Decimal))

        For Each row As DataGridViewRow In dgTransferL.Rows
            If row.IsNewRow Then Continue For

            Dim skuCode As String = row.Cells("tt_sku").Value?.ToString().Trim()
            Dim qtyVal = row.Cells("tt_qty").Value
            Dim totalAmountVal = row.Cells("tt_total_amount").Value
            Dim itemLoc As String = row.Cells("tt_loc").Value?.ToString().Trim()

            If String.IsNullOrWhiteSpace(skuCode) OrElse qtyVal Is Nothing OrElse String.IsNullOrWhiteSpace(qtyVal.ToString()) OrElse
               String.IsNullOrWhiteSpace(totalAmountVal.ToString()) Then
                MessageBox.Show($"Missing SKU or quantity in row {row.Index + 1}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim qty As Integer
            Dim totalAmount As Decimal
            If Not Integer.TryParse(qtyVal.ToString(), qty) Then
                MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not Decimal.TryParse(totalAmountVal.ToString(), totalAmount) Then
                MessageBox.Show($"Invalid total amount format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim isValidQty As Boolean = itemBal_picklist_isValidQty(userLoginComp, My.Settings.Store, itemLoc, skuCode, qty)
            If Not isValidQty Then
                MessageBox.Show($"Insufficient quantity for Location: {itemLoc} SKU: {skuCode}", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            transferList.Add((itemLoc, skuCode, qty, totalAmount))
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
                Dim drNumber As Integer = Convert.ToInt32(txtTTDRNo.Text)
                'Update Header Status to Approval
                Dim headerUpdated As Boolean = update_transfer_h_status(conn, trans, userLoginComp,
                                      My.Settings.Store, lblTTStoreCodeDest.Text, drNumber, 0)

                If Not headerUpdated Then
                    Throw New Exception("Failed to Update transfer header status.")
                End If

                ' -----------------------------
                ' delete query that sku doesnt exist anymore in the submitted reroute list 
                For Each item As DataRow In StockClass.table_transferLOut.Rows
                    Dim sku As String = item("sku_code").ToString()
                    Dim itemLoc As String = item("itemloc_origin").ToString()


                    Dim exists As Boolean = transferList.Any(Function(transferItem) transferItem.skuCode = sku AndAlso transferItem.itemLoc = itemLoc)
                    If Not exists Then
                        delete_transfer_l(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, itemLoc, drNumber, sku)
                    End If
                Next

                ' Process each item
                For Each item In transferList
                    rowCount += 1

                    'Dim foundRows() As DataRow = StockClass.table_transferLOut.Select("sku_code = '" & item.skuCode & "'") ' ERROR
                    Dim foundRows() As DataRow = StockClass.table_transferLOut.Select(
                                                                                        "sku_code = '" & item.skuCode & "' AND itemloc_origin = '" & item.itemLoc & "'"
                                                                                    )

                    If foundRows.Length > 0 Then
                        Dim transferLUpdated As Boolean = update_transfer_l_row(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, item.itemLoc, drNumber, 0, item.skuCode, Nothing, item.qty, item.total_amount, rowCount)

                        If Not (transferLUpdated) Then
                            Throw New Exception($"Failed to process item {item.skuCode} at row {rowCount}.")
                        End If
                    Else
                        Dim transferLCreated As Boolean = create_transfer_l(conn, trans, userLoginComp,
                                                                    My.Settings.Store,
                                                                    lblTTStoreCodeDest.Text,
                                                                    drNumber,
                                                                    item.itemLoc,
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
                    End If

                Next

                ' Commit all changes
                trans.Commit()

                'StockClass.show_ItemBalanceList()
                MessageBox.Show("The items have been successfully transferred.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                StockClass.show_transfer_h(True)
                StockClass.cachedTransferOutLine = Nothing
                Me.Close()
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

    'MOVE TO APPROVED / TO PICK 
    Private Sub btnTransferApproved_Click(sender As Object, e As EventArgs) Handles btnTransferApproved.Click

        Dim result As DialogResult = MessageBox.Show("Do you confirm approval of this DR?", "Yes, Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Using conn As New MySqlConnection(InvDBConn.ConnectionString)
                conn.Open()
                Dim trans As MySqlTransaction = conn.BeginTransaction()
                Try
                    Dim rowCount As Integer = 0
                    Dim headerUpdated As Boolean = update_transfer_h_status(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, txtTTDRNo.Text, 1, Now, Nothing, My.Settings.CurrentUserID)

                    If Not headerUpdated Then
                        Throw New Exception("Failed to Update transfer header status.")
                    End If

                    For Each row As DataGridViewRow In dgTransferL.Rows
                        rowCount += 1
                        If row.IsNewRow Then Continue For

                        Dim skuCode As String = row.Cells("tt_sku").Value?.ToString().Trim()
                        Dim qtyVal = row.Cells("tt_qty").Value
                        Dim itemLoc As String = row.Cells("tt_loc").Value

                        Dim qty As Integer
                        If Not Integer.TryParse(qtyVal.ToString(), qty) Then
                            MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        'Dim transferLUpdated As Boolean = update_transfer_l_ApprovedQty(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, txtTTDRNo.Text, 1, skuCode, qty)
                        Dim transferLUpdated As Boolean = update_transfer_l_row(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, itemLoc, txtTTDRNo.Text, 1, skuCode, qty)
                        If Not (transferLUpdated) Then
                            Throw New Exception($"Failed to process at row {rowCount}.")
                        End If
                    Next

                    trans.Commit()
                    MessageBox.Show("This DR approved successfully!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    StockClass.show_transfer_h(True)
                    StockClass.cachedTransferOutLine = Nothing
                    Me.Close()
                Catch ex As Exception
                    ' Rollback on any error
                    trans.Rollback()
                    MessageBox.Show("Transfer failed. All changes have been rolled back." & vbCrLf & ex.Message,
                                "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    conn.Close()
                End Try
            End Using
        End If
    End Sub

    'MOVE TO REROUTE 
    Private Sub btnTransferReroute_Click(sender As Object, e As EventArgs) Handles btnTransferReroute.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to reroute this DR?", "Yes, Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Using conn As New MySqlConnection(InvDBConn.ConnectionString)
                conn.Open()
                Dim trans As MySqlTransaction = conn.BeginTransaction()

                Try

                    Dim headerUpdated As Boolean = update_transfer_h_status(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, txtTTDRNo.Text, 10)
                    If Not headerUpdated Then
                        Throw New Exception("Failed to Update transfer header status.")
                    End If

                    Dim rowCount As Integer
                    If selectedTransferHStatus = 0 Then  'Rereoute this For Approval status
                        update_transfer_l_status(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, txtTTDRNo.Text, 10)

                    ElseIf selectedTransferHStatus = 1 OrElse selectedTransferHStatus = 2 Then

                        If selectedTransferHStatus = 2 Then
                            Dim isDeletedPicklist As Boolean = delete_from_picklist(conn, trans, userLoginComp, My.Settings.Store, txtTTDRNo.Text)
                            If Not (isDeletedPicklist) Then
                                Throw New Exception($"Failed to process at row {rowCount}.")
                            End If
                        End If

                        For Each row As DataGridViewRow In dgTransferL.Rows
                            rowCount += 1
                            If row.IsNewRow Then Continue For

                            Dim skuCode As String = row.Cells("tt_sku").Value?.ToString().Trim()
                            Dim itemLoc As String = row.Cells("tt_loc").Value?.ToString().Trim()
                            Dim qtyVal = row.Cells("tt_approved_qty").Value

                            Dim qty As Integer
                            If Not Integer.TryParse(qtyVal.ToString(), qty) Then
                                MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            'Dim transferLUpdated As Boolean = update_transfer_l_qty(conn, trans, userLoginComp,
                            '               My.Settings.Store,
                            '               lblTTStoreCodeDest.Text,
                            '               txtTTDRNo.Text,
                            '               skuCode,
                            '               qty, rowCount, 10, False)
                            Dim transferLUpdated As Boolean = update_transfer_l_row(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, itemLoc, txtTTDRNo.Text, 10, skuCode, Nothing, qty)
                            If Not (transferLUpdated) Then
                                Throw New Exception($"Failed to process at row {rowCount}.")
                            End If
                        Next

                        'ElseIf selectedTransferHStatus = 2 Then

                    End If


                    trans.Commit()
                    MessageBox.Show("This DR moved to reroute successfully!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    StockClass.show_transfer_h(True)
                    StockClass.cachedTransferOutLine = Nothing
                    Me.Close()
                Catch ex As Exception
                    ' Rollback on any error
                    trans.Rollback()
                    MessageBox.Show("Transfer failed. All changes have been rolled back." & vbCrLf & ex.Message,
                                "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    conn.Close()
                End Try
            End Using
        End If
    End Sub

    'MOVE TO CANCELLED
    Private Sub btnTransferReject_Click(sender As Object, e As EventArgs) Handles btnTransferReject.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to reject this DR?", "Yes, Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Using conn As New MySqlConnection(InvDBConn.ConnectionString)
                conn.Open()
                Dim trans As MySqlTransaction = conn.BeginTransaction()

                Try
                    update_transfer_h_status(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, txtTTDRNo.Text, 9)
                    Dim headerUpdated As Boolean = update_transfer_l_status(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, txtTTDRNo.Text, 9)
                    If Not headerUpdated Then
                        Throw New Exception("Failed to Update transfer header status.")
                    End If

                    trans.Commit()
                    MessageBox.Show("This DR moved to cancelled successfully!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    StockClass.show_transfer_h(True)
                    StockClass.cachedTransferOutLine = Nothing
                    Me.Close()
                Catch ex As Exception
                    ' Rollback on any error
                    trans.Rollback()
                    MessageBox.Show("Transfer failed. All changes have been rolled back." & vbCrLf & ex.Message,
                                "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    conn.Close()
                End Try
            End Using
        End If
    End Sub

    'MOVE TO READY TO SHIP
    Private Sub btnTransferPicked_Click(sender As Object, e As EventArgs) Handles btnTransferPicked.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure that you have picked all the items on the list?", "Yes, Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Using conn As New MySqlConnection(InvDBConn.ConnectionString)
                conn.Open()
                Dim trans As MySqlTransaction = conn.BeginTransaction()

                Try

                    Dim headerUpdated As Boolean = update_transfer_h_status(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, txtTTDRNo.Text, 2)
                    If Not headerUpdated Then
                        Throw New Exception("Failed to Update transfer header status.")
                    End If

                    Dim LineUpdated As Boolean = update_transfer_l_status(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, txtTTDRNo.Text, 2)
                    If Not LineUpdated Then
                        Throw New Exception("Failed to Update item transfer status.")
                    End If

                    For Each row As DataGridViewRow In dgTransferL.Rows
                        If row.IsNewRow Then Continue For

                        Dim skuCode As String = row.Cells("tt_sku").Value?.ToString().Trim()
                        Dim qtyVal = row.Cells("tt_approved_qty").Value
                        Dim itemLoc As String = row.Cells("tt_loc").Value?.ToString().Trim()

                        Dim qty As Integer
                        If Not Integer.TryParse(qtyVal.ToString(), qty) Then
                            MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        Dim isValidQty As Boolean = itemBal_picklist_isValidQty(userLoginComp, My.Settings.Store, itemLoc, skuCode, qty)
                        If Not isValidQty Then
                            Throw New Exception($"Insufficient quantity for SKU: {skuCode}")
                        End If

                        Dim isInsertToPickList As Boolean = insertto_picklist(conn, trans,
                                  userLoginComp, My.Settings.Store, itemLoc,
                                  txtTTDRNo.Text, skuCode, qty, My.Settings.CurrentUserID)
                        If Not (isInsertToPickList) Then
                            Throw New Exception($"Failed to process {skuCode}.")
                        End If
                    Next
                    trans.Commit()
                    MessageBox.Show("This DR moved to Ready-to-Ship status successfully!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    StockClass.show_transfer_h(True)
                    StockClass.cachedTransferOutLine = Nothing
                    Me.Close()
                Catch ex As Exception
                    ' Rollback on any error
                    trans.Rollback()
                    MessageBox.Show("Transfer failed. All changes have been rolled back." & vbCrLf & ex.Message,
                                "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Finally
                    conn.Close()
                End Try
            End Using
        End If
    End Sub

    Private Sub btnTransferDRPrint_Click(sender As Object, e As EventArgs) Handles btnTransferDRPrint.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to print this DR?", "Yes, Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Using conn As New MySqlConnection(InvDBConn.ConnectionString)
                conn.Open()
                Dim trans As MySqlTransaction = conn.BeginTransaction()

                Try
                    Dim headerUpdated As Boolean = update_transfer_h_status(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, txtTTDRNo.Text, 3)
                    update_transfer_l_status(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, txtTTDRNo.Text, 3)
                    If Not headerUpdated Then
                        Throw New Exception("Failed to Update transfer header status.")
                    End If

                    update_picklist_stat(conn, trans, userLoginComp, My.Settings.Store, txtTTDRNo.Text, 0)

                    For Each row As DataGridViewRow In dgTransferL.Rows
                        If row.IsNewRow Then Continue For

                        Dim skuCode As String = row.Cells("tt_sku").Value?.ToString().Trim()
                        Dim itemLoc As String = row.Cells("tt_loc").Value?.ToString().Trim()
                        Dim qtyVal = row.Cells("tt_approved_qty").Value

                        Dim qty As Integer
                        If Not Integer.TryParse(qtyVal.ToString(), qty) Then
                            MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        Dim isGreaterOrEqual As Boolean = itembalIsGreaterOrEqual(userLoginComp, My.Settings.Store, itemLoc, skuCode, qty)
                        If Not isGreaterOrEqual Then
                            Throw New Exception($"Insufficient quantity for SKU: {skuCode}")
                        End If

                        Dim decreaseItemBalQty As Boolean = decrease_itembalance(conn, trans, userLoginComp, My.Settings.Store, itemLoc, skuCode, qty)
                        If Not (decreaseItemBalQty) Then
                            Throw New Exception($"Failed to process {skuCode}.")
                        End If

                        'itemmvt add D11 writes here stock out
                        Dim createdMovement As Boolean = create_movement(conn, trans,
                               userLoginComp,
                               My.Settings.Store,
                               itemLoc,
                               skuCode,
                               "-" + qty.ToString,
                               My.Settings.Store,
                               lblTTStoreCodeDest.Text,
                               itemLoc,
                               "Q001",
                               "D11",
                               My.Settings.Store + txtTTDRNo.Text,
                              My.Settings.CurrentUserID)
                        If Not (createdMovement) Then
                            Throw New Exception($"Failed to process create_movement.")
                        End If
                    Next

                    trans.Commit()
                    MessageBox.Show("This DR moved to In-Transit.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MessageBox.Show("Your Delivery Receipt (DR) will be downloaded shortly.", "Generate", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    StockClass.show_transfer_h(True)
                    Using sfd As New SaveFileDialog()
                        sfd.Title = "Save Delivery Receipt PDF"
                        sfd.Filter = "PDF Files (*.pdf)|*.pdf"
                        sfd.FileName = compDesc & "_" & My.Settings.Store & "-" & txtTTDRNo.Text & "_PR_to" & lblTTStoreCodeDest.Text & ".pdf"

                        If sfd.ShowDialog() = DialogResult.OK Then
                            Dim pdfPath As String = sfd.FileName
                            Dim foundRows() As DataRow = StockClass.cachedTransferOutHeader.Select($"dr = '{txtTTDRNo.Text.Replace("'", "''")}'")
                            ExportPOtoPDF(dgTransferL, foundRows(0), pdfPath)

                            Try
                                ' Open PDF in default program/browser
                                Dim psi As New ProcessStartInfo With {
                        .FileName = pdfPath,
                        .UseShellExecute = True
                    }
                                Process.Start(psi)
                            Catch ex As Exception
                                MessageBox.Show("Unable to open PDF automatically: " & ex.Message)
                            End Try
                        End If
                    End Using
                    StockClass.show_ItemBalanceList(True)
                    StockClass.cachedTransferOutLine = Nothing
                    Me.Close()
                Catch ex As Exception
                    ' Rollback on any error
                    trans.Rollback()
                    MessageBox.Show("Transfer failed. All changes have been rolled back." & vbCrLf & ex.Message,
                                "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Finally
                    conn.Close()
                End Try
            End Using
        End If

    End Sub

    Private Sub btnTransferGenDR_Click(sender As Object, e As EventArgs) Handles btnTransferGenDR.Click
        ' Gamit ng SaveFileDialog para makapili ng location at filename

        StockClass.show_transfer_h(True)
        Using sfd As New SaveFileDialog()
            sfd.Title = "Save Delivery Receipt PDF"
            sfd.Filter = "PDF Files (*.pdf)|*.pdf"
            sfd.FileName = compDesc & "_" & My.Settings.Store & "-" & txtTTDRNo.Text & "_PR_to" & lblTTStoreCodeDest.Text & ".pdf"

            If sfd.ShowDialog() = DialogResult.OK Then
                Dim pdfPath As String = sfd.FileName
                Dim foundRows() As DataRow = StockClass.cachedTransferOutHeader.Select($"dr = '{txtTTDRNo.Text.Replace("'", "''")}'")
                ExportPOtoPDF(dgTransferL, foundRows(0), pdfPath)

                Try
                    ' Open PDF in default program/browser
                    Dim psi As New ProcessStartInfo With {
                        .FileName = pdfPath,
                        .UseShellExecute = True
                    }
                    Process.Start(psi)
                Catch ex As Exception
                    MessageBox.Show("Unable to open PDF automatically: " & ex.Message)
                End Try
            End If
        End Using
    End Sub

    Public Sub ExportPOtoPDF(ByVal dgv As DataGridView, ByVal drheaderRow As DataRow, ByVal filePath As String)
        Dim doc As New Document(PageSize.LETTER, 40, 40, 40, 40)

        Try
            Dim writer = PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))
            writer.PageEvent = New PageNumberHelper()
            doc.Open()

            ' === Fonts ===
            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD, New BaseColor(24, 150, 166))
            Dim headerFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD)
            Dim detailsFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL)
            Dim normalFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL)
            Dim skuFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 5, iTextSharp.text.Font.NORMAL)
            Dim nameFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD)


            ' === Company Logo ===
            Dim ms As New MemoryStream()
            My.Resources.mcplus_logo.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(ms.ToArray())
            logo.ScaleToFit(70, 40)
            logo.Alignment = iTextSharp.text.Image.ALIGN_LEFT
            doc.Add(logo)

            ' === Header Section ===
            Dim headerTable As New PdfPTable(2)
            headerTable.WidthPercentage = 100
            headerTable.SetWidths({50, 50})

            ' --- LEFT SIDE (Company + Vendor) ---
            Dim leftCell As New PdfPCell()
            leftCell.Border = Rectangle.NO_BORDER

            ' Company Info
            Dim foundCompanyRows() As DataRow = SettingClass.cachedCompanyList.Select("company_code = '" & userLoginComp & "'")
            Dim companyPara As New iTextSharp.text.Paragraph("Contact : " + foundCompanyRows(0)("contact_num").ToString & vbCrLf &
                                            foundCompanyRows(0)("email_addr").ToString & vbCrLf &
                                            foundCompanyRows(0)("company_url").ToString & vbCrLf, detailsFont)
            leftCell.AddElement(New iTextSharp.text.Paragraph("Medical Coat Plus", headerFont))
            leftCell.AddElement(companyPara)
            leftCell.AddElement(New iTextSharp.text.Paragraph(" "))

            ' Vendor Block

            Dim foundFromRows() As DataRow = SettingClass.cachedStoreList.Select("store_code = '" & My.Settings.Store & "'")
            Dim fromTitle As New PdfPCell(New Phrase("FROM", headerFont)) With {
                .BackgroundColor = New BaseColor(24, 150, 166), ' orange-red highlight
                .Padding = 4,
                .Border = Rectangle.NO_BORDER
            }

            Dim fromTable As New PdfPTable(1)
            fromTable.WidthPercentage = 100
            fromTable.AddCell(fromTitle)
            fromTable.AddCell(New PdfPCell(New Phrase(foundFromRows(0)("store_desc").ToString(), normalFont)) With {.Border = Rectangle.NO_BORDER})
            fromTable.AddCell(New PdfPCell(New Phrase(compDesc, normalFont)) With {.Border = Rectangle.NO_BORDER})
            fromTable.AddCell(New PdfPCell(New Phrase(foundFromRows(0)("store_addr").ToString(), normalFont)) With {.Border = Rectangle.NO_BORDER})
            fromTable.AddCell(New PdfPCell(New Phrase("Contact : " + foundFromRows(0)("store_contact_no").ToString, normalFont)) With {.Border = Rectangle.NO_BORDER})
            'fromTable.AddCell(New PdfPCell(New Phrase(foundFromRows(0)("store_email").ToString, normalFont)) With {.Border = Rectangle.NO_BORDER})

            leftCell.AddElement(fromTable)

            ' --- RIGHT SIDE (Title + Date + PO Number + Ship To) ---
            Dim rightCell As New PdfPCell()
            rightCell.Border = Rectangle.NO_BORDER

            ' Title
            Dim title As New iTextSharp.text.Paragraph("DELIVERY RECEIPT", titleFont)
            title.Alignment = Element.ALIGN_RIGHT
            rightCell.AddElement(title)

            ' Date & PO Number
            Dim datePara As New iTextSharp.text.Paragraph("Date Created: " & CType(drheaderRow("create_date"), DateTime).ToString("MM/dd/yy"), headerFont)
            Dim poNumPara As New iTextSharp.text.Paragraph("DR #: " & drheaderRow("store_code_origin") & "-" & txtTTDRNo.Text, headerFont)
            datePara.Alignment = Element.ALIGN_RIGHT
            poNumPara.Alignment = Element.ALIGN_RIGHT
            rightCell.AddElement(datePara)
            rightCell.AddElement(poNumPara)
            rightCell.AddElement(New iTextSharp.text.Paragraph(" "))

            ' Ship To Block

            Dim foundStoreRows() As DataRow = SettingClass.cachedStoreList.Select("store_code = '" & lblTTStoreCodeDest.Text & "'")
            Dim shipTitle As New PdfPCell(New Phrase("SHIP TO", headerFont)) With {
                .BackgroundColor = New BaseColor(147, 227, 237), ' orange highlight
                .Padding = 4,
                .Border = Rectangle.NO_BORDER
            }

            Dim shipTable As New PdfPTable(1)
            shipTable.WidthPercentage = 100
            shipTable.AddCell(shipTitle)
            shipTable.AddCell(New PdfPCell(New Phrase(foundStoreRows(0)("store_desc").ToString, normalFont)) With {.Border = Rectangle.NO_BORDER})
            shipTable.AddCell(New PdfPCell(New Phrase(compDesc, normalFont)) With {.Border = Rectangle.NO_BORDER})
            shipTable.AddCell(New PdfPCell(New Phrase(foundStoreRows(0)("store_addr").ToString, normalFont)) With {.Border = Rectangle.NO_BORDER})
            shipTable.AddCell(New PdfPCell(New Phrase("Contact : " + foundStoreRows(0)("store_contact_no").ToString, normalFont)) With {.Border = Rectangle.NO_BORDER})
            'shipTable.AddCell(New PdfPCell(New Phrase(foundStoreRows(0)("store_email").ToString, normalFont)) With {.Border = Rectangle.NO_BORDER})

            rightCell.AddElement(shipTable)

            ' Add both cells to main header table
            headerTable.AddCell(leftCell)
            headerTable.AddCell(rightCell)
            doc.Add(headerTable)
            doc.Add(New iTextSharp.text.Paragraph(" "))

            ' === Items Table ===
            Dim pdfTable As New PdfPTable(6)
            pdfTable.WidthPercentage = 100
            pdfTable.SetWidths({5, 10, 30, 22, 13, 8})

            ' Headers
            Dim headers() As String = {"", "SKU", "Item Description", "Color", "Variation", "Qty"}
            For Each h As String In headers
                Dim cell As New PdfPCell(New Phrase(h, headerFont))
                cell.BackgroundColor = BaseColor.LIGHT_GRAY
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                cell.PaddingTop = 5
                cell.PaddingBottom = 5
                pdfTable.AddCell(cell)
            Next

            ' Data Rows
            'Dim grandTotal As Decimal = 0
            For Each row As DataGridViewRow In dgv.Rows
                If Not row.IsNewRow Then
                    Dim rowCount = row.Cells("tt_rowcount").Value.ToString()
                    Dim sku = row.Cells("tt_sku").Value.ToString()
                    Dim desc = row.Cells("tt_item").Value.ToString()
                    Dim color = row.Cells("tt_color").Value.ToString()
                    Dim varApp = row.Cells("tt_variant").Value.ToString()
                    Dim qty As Integer = Convert.ToInt32(row.Cells("tt_approved_qty").Value)

                    pdfTable.AddCell(New PdfPCell(New Phrase(rowCount, normalFont)) With {.HorizontalAlignment = Element.ALIGN_CENTER, .PaddingTop = 3, .PaddingBottom = 3})
                    pdfTable.AddCell(New PdfPCell(New Phrase(sku, skuFont)) With {.PaddingTop = 3, .PaddingBottom = 3})
                    pdfTable.AddCell(New PdfPCell(New Phrase(desc, normalFont)) With {.PaddingTop = 3, .PaddingBottom = 3})
                    pdfTable.AddCell(New PdfPCell(New Phrase(color, normalFont)) With {.PaddingTop = 3, .PaddingBottom = 3})
                    pdfTable.AddCell(New PdfPCell(New Phrase(varApp, normalFont)) With {.PaddingTop = 3, .PaddingBottom = 3})
                    pdfTable.AddCell(New PdfPCell(New Phrase(qty.ToString(), normalFont)) With {.HorizontalAlignment = Element.ALIGN_CENTER, .PaddingTop = 3, .PaddingBottom = 3})

                End If
            Next


            doc.Add(pdfTable)

            ' === Remarks / Terms ===
            'doc.Add(New iTextSharp.text.Paragraph(" "))
            'doc.Add(New iTextSharp.text.Paragraph("Remarks:", headerFont))

            'doc.Add(New iTextSharp.text.Paragraph("Payment Terms: " & vbCrLf &
            '                  "Please ensure quality and timely delivery.", normalFont))

            ' === Signatures ===
            doc.Add(New iTextSharp.text.Paragraph(" "))
            Dim signTable As New PdfPTable(3)
            signTable.WidthPercentage = 100
            signTable.SetWidths({33, 33, 33})

            ' First row (labels)
            signTable.AddCell(New PdfPCell(New Phrase("Prepared by:", normalFont)) With {
                .Border = Rectangle.NO_BORDER,
                .PaddingTop = 20
            })
            signTable.AddCell(New PdfPCell(New Phrase("Approved by:", normalFont)) With {
                .Border = Rectangle.NO_BORDER,
                .PaddingTop = 20
            })
            signTable.AddCell(New PdfPCell(New Phrase("Received by:", normalFont)) With {
                .Border = Rectangle.NO_BORDER,
                .PaddingTop = 20
            })

            ' Second row (names or blank lines for signatures)
            signTable.AddCell(New PdfPCell(New Phrase(get_user_fullname(CInt(drheaderRow("create_by"))), nameFont)) With {
                .PaddingTop = 20,
                .HorizontalAlignment = Element.ALIGN_CENTER
            })
            signTable.AddCell(New PdfPCell(New Phrase(get_user_fullname(CInt(drheaderRow("approved_by"))), nameFont)) With {
                .PaddingTop = 20,
                .HorizontalAlignment = Element.ALIGN_CENTER
            })
            signTable.AddCell(New PdfPCell(New Phrase("____________________", nameFont)) With {
                .PaddingTop = 20,
                .HorizontalAlignment = Element.ALIGN_CENTER
            })

            doc.Add(signTable)


            MessageBox.Show("PR PDF file saved to: " & filePath)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            doc.Close()
        End Try
    End Sub

    Public Class PageNumberHelper
        Inherits PdfPageEventHelper
        Private pageFont As iTextSharp.text.Font =
            New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL)

        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
            Dim cb As PdfContentByte = writer.DirectContent
            Dim footer As New Phrase("Page " & writer.PageNumber, pageFont)
            ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER,
                                       footer,
                                       (document.Right - document.Left) / 2 + document.LeftMargin,
                                       document.Bottom - 10, 0)
        End Sub
    End Class


    Private Sub toggleReturn_Click(sender As Object, e As EventArgs) Handles toggleReturn.Click
        dgTransferL.Columns("tt_return_qty").ReadOnly = False
        dgTransferL.Columns("tt_total_amount_return").ReadOnly = False
        dgTransferL.Columns("tt_return_qty").DefaultCellStyle.BackColor = Color.AntiqueWhite
        dgTransferL.Columns("tt_total_amount_return").DefaultCellStyle.BackColor = Color.AntiqueWhite
        panelReturn.Visible = False
        cancelReturn.Visible = True
        submitReturn.Visible = True
    End Sub

    Private Sub cancelReturn_Click(sender As Object, e As EventArgs) Handles cancelReturn.Click
        dgTransferL.Columns("tt_return_qty").ReadOnly = True
        dgTransferL.Columns("tt_total_amount_return").ReadOnly = True
        dgTransferL.Columns("tt_return_qty").DefaultCellStyle.BackColor = Color.White
        dgTransferL.Columns("tt_total_amount_return").DefaultCellStyle.BackColor = Color.White
        panelReturn.Visible = True
        cancelReturn.Visible = False
        submitReturn.Visible = False

    End Sub

    Private Sub submitReturn_Click(sender As Object, e As EventArgs) Handles submitReturn.Click
        If dgTransferL.Rows.Count = 0 Then
            MsgBox("No items found in the return transfer list.", MsgBoxStyle.Exclamation, "No Items")
            Exit Sub
        End If

        Dim returnTransferList As New List(Of (itemLoc As String, skuCode As String, qty As Integer, returnQty As Integer, total_amount As Decimal))

        For Each row As DataGridViewRow In dgTransferL.Rows
            If row.IsNewRow Then Continue For

            Dim skuCode As String = If(row.Cells("tt_sku").Value?.ToString(), "").Trim()
            Dim qtyVal As String = If(row.Cells("tt_received_qty").Value?.ToString(), "").Trim()
            Dim returnQtyVal As String = If(row.Cells("tt_return_qty").Value?.ToString(), "").Trim()
            Dim returnTotalAmountVal As String = If(row.Cells("tt_total_amount_return").Value?.ToString(), "").Trim()
            Dim itemLoc As String = If(row.Cells("tt_loc").Value?.ToString(), "").Trim()

            If String.IsNullOrWhiteSpace(returnQtyVal) AndAlso String.IsNullOrWhiteSpace(returnTotalAmountVal) Then Continue For

            If String.IsNullOrWhiteSpace(returnQtyVal) OrElse String.IsNullOrWhiteSpace(returnTotalAmountVal) Then
                MessageBox.Show($"Complete return qty and amount at row {row.Index + 1}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim qty, returnQty As Integer
            Dim totalAmount As Decimal
            Integer.TryParse(qtyVal, qty)
            Integer.TryParse(returnQtyVal, returnQty)
            Decimal.TryParse(returnTotalAmountVal, totalAmount)

            returnTransferList.Add((itemLoc, skuCode, qty, returnQty, totalAmount))
        Next

        If MessageBox.Show("Are you sure you want to return item(s)?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Exit Sub

        Using conn As New MySqlConnection(InvDBConn.ConnectionString)
            conn.Open()
            Dim trans As MySqlTransaction = conn.BeginTransaction()
            Try
                Dim drNumber As Integer = Convert.ToInt32(txtTTDRNo.Text)
                Dim rowCount As Integer = 0

                ' --- 1. DELETE: yung tinanggal sa grid, i-reverse ang stock ---
                For Each dbRow As DataRow In StockClass.table_transferLOut.Rows
                    Dim sku As String = dbRow("sku_code").ToString()
                    Dim itemLoc As String = dbRow("itemloc_origin").ToString()
                    Dim oldReturn As Integer = If(IsDBNull(dbRow("return_qty")), 0, Convert.ToInt32(dbRow("return_qty")))

                    If oldReturn > 0 Then
                        Dim exists As Boolean = returnTransferList.Any(Function(x) x.skuCode = sku AndAlso x.itemLoc = itemLoc)
                        If Not exists Then
                            ' ibalik sa destination, bawas sa origin
                            add_itembalance(conn, trans, userLoginComp, lblTTStoreCodeDest.Text, "Q001", sku, oldReturn)
                            decrease_itembalance(conn, trans, userLoginComp, My.Settings.Store, itemLoc, sku, oldReturn)
                            delete_transfer_return(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, itemLoc, drNumber, sku)
                        End If
                    End If
                Next

                ' --- 2. PROCESS: lahat ng nasa grid ---
                For Each item In returnTransferList
                    rowCount += 1

                    Dim found() As DataRow = StockClass.table_transferLOut.Select("sku_code = '" & item.skuCode.Replace("'", "''") & "' AND itemloc_origin = '" & item.itemLoc & "'")
                    Dim oldReturnQty As Integer = 0
                    Dim transferredQty As Integer = item.qty

                    If found.Length > 0 Then
                        If Not IsDBNull(found(0)("return_qty")) Then oldReturnQty = Convert.ToInt32(found(0)("return_qty"))
                        If Not IsDBNull(found(0)("received_qty")) Then transferredQty = Convert.ToInt32(found(0)("received_qty"))
                    End If

                    ' validation: hindi pwede lumampas sa na-transfer
                    If item.returnQty > transferredQty Then
                        Throw New Exception($"Return qty for {item.skuCode} ({item.returnQty}) exceeds transferred qty ({transferredQty}).")
                    End If

                    Dim deltaQty As Integer = item.returnQty - oldReturnQty

                    If deltaQty <> 0 Then
                        If deltaQty > 0 Then
                            ' dagdag return: bawas Dest, dagdag Origin
                            decrease_itembalance(conn, trans, userLoginComp, lblTTStoreCodeDest.Text, "Q001", item.skuCode, deltaQty)
                            add_itembalance(conn, trans, userLoginComp, My.Settings.Store, item.itemLoc, item.skuCode, deltaQty)
                        Else
                            ' binawasan ang return: balik sa Dest, bawas sa Origin
                            Dim absDelta As Integer = Math.Abs(deltaQty)
                            add_itembalance(conn, trans, userLoginComp, lblTTStoreCodeDest.Text, "Q001", item.skuCode, absDelta)
                            decrease_itembalance(conn, trans, userLoginComp, My.Settings.Store, item.itemLoc, item.skuCode, absDelta)
                        End If
                    End If

                    ' update or create record
                    If oldReturnQty > 0 Then
                        update_transfer_return_row(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, item.itemLoc, drNumber, item.skuCode, item.returnQty, item.total_amount, rowCount)
                    Else
                        create_transfer_return(conn, trans, userLoginComp, My.Settings.Store, lblTTStoreCodeDest.Text, drNumber, item.itemLoc, "Q001", rowCount, item.skuCode, item.returnQty, item.total_amount, My.Settings.CurrentUserID)
                    End If
                Next

                trans.Commit()
                MessageBox.Show("The item(s) have been successfully returned.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                StockClass.show_transfer_h(True)
                StockClass.cachedTransferOutLine = Nothing
                'Me.Close()
                StockClass.show_transfer_l(userLoginComp, drNumber, My.Settings.Store, lblTTStoreCodeDest.Text, "out")
                dgTransferL.Columns("tt_return_qty").ReadOnly = True
                dgTransferL.Columns("tt_total_amount_return").ReadOnly = True
                dgTransferL.Columns("tt_return_qty").DefaultCellStyle.BackColor = Color.White
                dgTransferL.Columns("tt_total_amount_return").DefaultCellStyle.BackColor = Color.White
                panelReturn.Visible = True
                cancelReturn.Visible = False
                submitReturn.Visible = False

            Catch ex As Exception
                trans.Rollback()
                MessageBox.Show("Return failed. All changes rolled back." & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
End Class
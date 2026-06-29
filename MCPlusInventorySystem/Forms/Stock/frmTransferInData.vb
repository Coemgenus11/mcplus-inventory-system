Imports MySql.Data.MySqlClient

Public Class frmTransferInData

    Dim userLoginComp As String
    Dim compDesc As String

    Public Shared selectedTransferHStatus As String
    Private Sub frmTransferInData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.centralAuditDB IsNot "" Then
            userLoginComp = get_user_comp(My.Settings.CurrentUserID)
            compDesc = get_company_desc(userLoginComp)
        End If

        If selectedTransferHStatus = "1" Then   'APPROVED/TO PICK status

        ElseIf selectedTransferHStatus = "2" Then   'Ready to Ship status

        ElseIf selectedTransferHStatus = "3" Then 'In transit status Or Partial Received
            btnTransferReceived.Visible = True
            dgTransferL.Columns("ti_received_qty").Visible = True

        ElseIf selectedTransferHStatus = "partial" Then 'Partially Received
            btnTransferReceived.Visible = True
            'btnPartialSubmit.Visible = True
            dgTransferL.Columns("ti_received_qty").Visible = True
            dgTransferL.Columns("ti_received_qty").ReadOnly = True
            dgTransferL.Columns("ti_receive_now").Visible = True

            For Each row As DataGridViewRow In dgTransferL.Rows
                If row.IsNewRow Then Continue For

                Dim appQtyVal As Integer = Val(row.Cells("ti_approved_qty").Value)
                Dim recQtyVal As Integer = Val(row.Cells("ti_received_qty").Value)

                ' Default color
                row.DefaultCellStyle.BackColor = Color.White

                If appQtyVal <> recQtyVal Then
                    row.DefaultCellStyle.BackColor = Color.LightSalmon
                    row.Cells("ti_receive_now").Style.BackColor = Color.SeaShell
                Else
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                    row.Cells("ti_receive_now").Value = "complete"
                End If
            Next

        ElseIf selectedTransferHStatus = "4" Then 'Received status
            dgTransferL.Columns("ti_received_qty").Visible = True
            dgTransferL.Columns("ti_received_qty").ReadOnly = True

        ElseIf selectedTransferHStatus = "9" Then 'CANCEL

        ElseIf selectedTransferHStatus = "10" Then 'Reroute status
        End If
    End Sub

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnTransferReceived.Visible = False
        dgTransferL.Columns("ti_received_qty").Visible = False
        dgTransferL.Columns("ti_received_qty").ReadOnly = False
        dgTransferL.Columns("ti_receive_now").Visible = False
    End Sub


    Private Sub dgTransferL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTransferL.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgTransferL.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgTransferL.Rows(e.RowIndex)

            Dim appQty As String = selectedRow.Cells("ti_approved_qty").Value?.ToString()
            Dim recQty As String = selectedRow.Cells("ti_received_qty").Value?.ToString()

            If columnName = "ti_received_qty" Then
                Dim auth = get_user_auth(My.Settings.CurrentUserID).ToString()
                If auth = "STK" OrElse auth = "ADM" Then

                    dgTransferL.CurrentCell = dgTransferL.Rows(e.RowIndex).Cells("ti_received_qty")
                    dgTransferL.BeginEdit(True)
                End If
            ElseIf columnName = "ti_receive_now" Then
                Dim auth = get_user_auth(My.Settings.CurrentUserID).ToString()
                If auth = "STK" OrElse auth = "ADM" Then
                    If appQty = recQty Then
                        ' Equal → gawin read-only
                        selectedRow.Cells("ti_receive_now").ReadOnly = True
                    Else
                        ' Not equal → editable
                        selectedRow.Cells("ti_receive_now").ReadOnly = False
                        dgTransferL.CurrentCell = selectedRow.Cells("ti_receive_now")
                        dgTransferL.BeginEdit(True)
                    End If
                End If
            End If
        End If
    End Sub

    ' Allow numeric/decimal input for dgTransferL
    Private Sub dgTransferL_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgTransferL.EditingControlShowing
        Dim tb As System.Windows.Forms.TextBox = TryCast(e.Control, System.Windows.Forms.TextBox)

        If tb IsNot Nothing Then
            RemoveHandler tb.KeyPress, AddressOf dgTransferL_TextBox_KeyPress
            AddHandler tb.KeyPress, AddressOf dgTransferL_TextBox_KeyPress
        End If
    End Sub

    Private Sub dgTransferL_TextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim colName As String = dgTransferL.CurrentCell.OwningColumn.Name

        If colName = "ti_approved_qty" OrElse colName = "ti_received_qty" OrElse colName = "ti_receive_now" Then
            ' Allow only digits and control keys
            If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub btnTransferReceived_Click(sender As Object, e As EventArgs) Handles btnTransferReceived.Click
        Dim isPartialReceived As Boolean
        Dim transferInList As New List(Of (itemLocOrigin As String, skuCode As String, qtyToReceivedVal As Integer, qty As Integer, qtyNow As Integer))

        ' === VALIDATION LOOP ===
        For Each row As DataGridViewRow In dgTransferL.Rows
            If row.IsNewRow Then Continue For

            Dim skuCode As String = row.Cells("ti_sku").Value?.ToString().Trim()
            Dim qtyToReceivedVal = Convert.ToDecimal(row.Cells("ti_approved_qty").Value)
            Dim qtyReceivedVal = row.Cells("ti_received_qty").Value
            Dim qtyReceiveNowValObj = row.Cells("ti_receive_now").Value
            Dim itemLocOrigin As String = row.Cells("ti_loc").Value?.ToString().Trim()

            If selectedTransferHStatus = "3" Then
                If String.IsNullOrWhiteSpace(skuCode) OrElse qtyReceivedVal Is Nothing OrElse String.IsNullOrWhiteSpace(qtyReceivedVal.ToString()) Then
                    MessageBox.Show($"Missing SKU or received quantity in row {row.Index + 1}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                If String.IsNullOrWhiteSpace(skuCode) OrElse qtyReceiveNowValObj Is Nothing OrElse String.IsNullOrWhiteSpace(qtyReceiveNowValObj.ToString()) Then
                    MessageBox.Show($"Missing SKU or receive now quantity in row {row.Index + 1}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If


            Dim qtyReceived As Integer
            If Not Integer.TryParse(qtyReceivedVal.ToString(), qtyReceived) Then
                MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim qtyReceiveNowStr As String = If(qtyReceiveNowValObj Is Nothing, "", qtyReceiveNowValObj.ToString().Trim())
            Dim qtyReceiveNow As Integer
            If String.IsNullOrEmpty(qtyReceiveNowStr) OrElse qtyReceiveNowStr = "complete" Then
                qtyReceiveNow = 0 ' or handle differently
            ElseIf Not Integer.TryParse(qtyReceiveNowStr, qtyReceiveNow) Then
                MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Dim qtyReceiveNow As Integer
            'If Not Integer.TryParse(qtyReceiveNowVal.ToString(), qtyReceiveNow) Then
            '    MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If

            If selectedTransferHStatus = "3" Then
                If qtyToReceivedVal < qtyReceived Then
                    MessageBox.Show($"Oops! You entered a quantity that exceeds the quantity to be received for {skuCode}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf qtyToReceivedVal > qtyReceived Then
                    isPartialReceived = True
                End If
            Else
                If qtyToReceivedVal < (qtyReceived + qtyReceiveNow) Then
                    MessageBox.Show($"Oops! You entered a quantity that exceeds the quantity to be received for {skuCode}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf qtyToReceivedVal > (qtyReceived + qtyReceiveNow) Then
                    isPartialReceived = True
                End If
            End If


            transferInList.Add((itemLocOrigin, skuCode, qtyToReceivedVal, qtyReceived, qtyReceiveNow))
        Next

        ' === CONFIRMATION MESSAGE ===
        Dim headerStatus As Integer = If(isPartialReceived, 3, 4)
        Dim confirmMsg As String = If(isPartialReceived, "Do you confirm that this DR was partially received?", "Do you confirm that this DR was received and is now complete?")
        If MessageBox.Show(confirmMsg, "Yes, Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Exit Sub

        ' === DB TRANSACTION ===
        Using conn As New MySqlConnection(InvDBConn.ConnectionString)
            conn.Open()
            Dim trans As MySqlTransaction = conn.BeginTransaction()
            Try
                ' Header update
                If Not update_transfer_h_status(conn, trans, userLoginComp, lblTTStoreCodeOrig.Text, My.Settings.Store, txtTTDRNo.Text, headerStatus, Nothing, Now) Then
                    Throw New Exception("Failed to Update transfer header status.")
                End If

                For Each item In transferInList

                    If selectedTransferHStatus = "3" Then
                        ' Line update (Partial lines can be Complete if qty matches)
                        Dim lineStatus As Integer = If(isPartialReceived AndAlso item.qtyToReceivedVal > item.qty, 3, 4)
                        If Not update_transfer_l_row(conn, trans, userLoginComp, lblTTStoreCodeOrig.Text, My.Settings.Store, item.itemLocOrigin, txtTTDRNo.Text, lineStatus, item.skuCode, Nothing, Nothing, Nothing, Nothing, item.qty, Now) Then
                            Throw New Exception("Failed to Update item transfer status.")
                        End If

                        ' Add item balance
                        If Not add_itembalance(conn, trans, userLoginComp, My.Settings.Store, "Q001", item.skuCode, item.qty) Then
                            Throw New Exception($"Failed to process {item.skuCode}.")
                        End If

                        'itemmvt add D11 writes here stock out
                        If item.qty > 0 Then
                            Dim createdMovement As Boolean = create_movement(conn, trans,
                                                                               userLoginComp,
                                                                               My.Settings.Store,
                                                                               "Q001",
                                                                               item.skuCode,
                                                                               item.qty.ToString,
                                                                               lblTTStoreCodeOrig.Text,
                                                                               My.Settings.Store,
                                                                               item.itemLocOrigin,
                                                                               "Q001",
                                                                               "D11",
                                                                              lblTTStoreCodeOrig.Text + txtTTDRNo.Text,
                                                                              My.Settings.CurrentUserID)
                            If Not (createdMovement) Then
                                Throw New Exception($"Failed to process create_movement.")
                            End If
                        End If

                    Else
                        ' Line update (Partial lines can be Complete if qty matches)
                        Dim lineStatus As Integer = If(isPartialReceived AndAlso item.qtyToReceivedVal > (item.qty + item.qtyNow), 3, 4)
                        If Not update_transfer_l_row(conn, trans, userLoginComp, lblTTStoreCodeOrig.Text, My.Settings.Store, item.itemLocOrigin, txtTTDRNo.Text, lineStatus, item.skuCode, Nothing, Nothing, Nothing, Nothing, (item.qty + item.qtyNow), Now) Then
                            Throw New Exception("Failed to Update item transfer status.")
                        End If

                        ' Add item balance
                        If Not add_itembalance(conn, trans, userLoginComp, My.Settings.Store, "Q001", item.skuCode, item.qtyNow) Then
                            Throw New Exception($"Failed to process {item.skuCode}.")
                        End If

                        'itemmvt add D11 writes here stock out
                        If item.qtyNow > 0 Then
                            Dim createdMovement As Boolean = create_movement(conn, trans,
                                                                               userLoginComp,
                                                                               My.Settings.Store,
                                                                               "Q001",
                                                                               item.skuCode,
                                                                               item.qtyNow.ToString,
                                                                               lblTTStoreCodeOrig.Text,
                                                                               My.Settings.Store,
                                                                               item.itemLocOrigin,
                                                                               "Q001",
                                                                               "D11",
                                                                              lblTTStoreCodeOrig.Text + txtTTDRNo.Text,
                                                                              My.Settings.CurrentUserID)
                            If Not (createdMovement) Then
                                Throw New Exception($"Failed to process create_movement.")
                            End If
                        End If


                    End If

                Next

                trans.Commit()
                MessageBox.Show(If(isPartialReceived, "Partially Received!", "Complete!"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                StockClass.show_transfer_h_dest(True)
                StockClass.show_ItemBalanceList(True)
                StockClass.cachedTransferInLine = Nothing
                Me.Close()
            Catch ex As Exception
                trans.Rollback()
                MessageBox.Show("Failed. All changes have been rolled back." & vbCrLf & ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Using
    End Sub
    'OKKKKKKKKKKKKKKKKKKKKKKK

    'Private Sub btnTransferReceived_Click(sender As Object, e As EventArgs) Handles btnTransferReceived.Click
    '    Dim isPartialReceived As Boolean = False
    '    Dim transferInList As New List(Of (skuCode As String, qtyToReceive As Integer, alreadyReceived As Integer, qtyNow As Integer, newLineStatus As Integer))

    '    ' === VALIDATION LOOP ===
    '    For Each row As DataGridViewRow In dgTransferL.Rows
    '        If row.IsNewRow Then Continue For

    '        Dim skuCode As String = row.Cells("ti_sku").Value?.ToString().Trim()
    '        Dim qtyToReceive As Integer = Convert.ToInt32(row.Cells("ti_approved_qty").Value)
    '        Dim alreadyReceived As Integer = Convert.ToInt32(row.Cells("ti_received_qty").Value)
    '        Dim qtyNowObj = row.Cells("ti_receive_now").Value

    '        If String.IsNullOrWhiteSpace(skuCode) OrElse qtyNowObj Is Nothing OrElse String.IsNullOrWhiteSpace(qtyNowObj.ToString()) Then
    '            MessageBox.Show($"Missing SKU or quantity in row {row.Index + 1}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If

    '        Dim qtyNow As Integer
    '        If Not Integer.TryParse(qtyNowObj.ToString(), qtyNow) Then
    '            MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If

    '        Dim remainingQty = qtyToReceive - alreadyReceived
    '        If qtyNow < 0 OrElse qtyNow > remainingQty Then
    '            MessageBox.Show($"Invalid quantity for {skuCode}. Max you can receive: {remainingQty}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If

    '        ' Determine new line status
    '        Dim newLineStatus As Integer
    '        If (alreadyReceived + qtyNow) = qtyToReceive Then
    '            newLineStatus = 4 ' Complete
    '        Else
    '            newLineStatus = 3 ' Partial
    '            isPartialReceived = True
    '        End If

    '        transferInList.Add((skuCode, qtyToReceive, alreadyReceived, qtyNow, newLineStatus))
    '    Next

    '    ' === DETERMINE NEW HEADER STATUS ===
    '    Dim headerStatus As Integer = If(isPartialReceived, 3, 4)

    '    ' === CONFIRMATION MESSAGE ===
    '    Dim confirmMsg As String
    '    Select Case selectedTransferHStatus
    '        Case "3" ' In-Transit
    '            confirmMsg = If(isPartialReceived, "Do you confirm that this DR was partially received?", "Do you confirm that this DR was received and is now complete?")
    '        Case "partial" ' Partial Received
    '            confirmMsg = If(isPartialReceived, "Do you confirm that this DR will remain partially received?", "Do you confirm that this DR is now fully received?")
    '        Case Else
    '            MessageBox.Show("Invalid current status for receiving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '    End Select

    '    If MessageBox.Show(confirmMsg, "Yes, Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Exit Sub

    '    ' === DB TRANSACTION ===
    '    Using conn As New MySqlConnection(InvDBConn.ConnectionString)
    '        conn.Open()
    '        Dim trans As MySqlTransaction = conn.BeginTransaction()
    '        Try
    '            ' === UPDATE HEADER ===
    '            Dim updateTimestamp As DateTime? = Nothing
    '            If selectedTransferHStatus = "3" Then
    '                updateTimestamp = Now ' First time receiving
    '            End If

    '            If Not update_transfer_h_status(conn, trans, userLoginComp, lblTTStoreCodeOrig.Text, My.Settings.Store, txtTTDRNo.Text, headerStatus, Nothing, updateTimestamp) Then
    '                Throw New Exception("Failed to Update transfer header status.")
    '            End If

    '            ' === UPDATE LINES & ADD STOCK ===
    '            For Each item In transferInList
    '                If Not update_transfer_l_row(conn, trans, userLoginComp, lblTTStoreCodeOrig.Text, My.Settings.Store, txtTTDRNo.Text, item.newLineStatus, item.skuCode, Nothing, Nothing, Nothing, item.qtyNow, Now) Then
    '                    Throw New Exception($"Failed to Update item {item.skuCode}.")
    '                End If

    '                If item.qtyNow > 0 Then
    '                    If Not add_itembalance(conn, trans, userLoginComp, My.Settings.Store, item.skuCode, item.qtyNow) Then
    '                        Throw New Exception($"Failed to add stock for {item.skuCode}.")
    '                    End If
    '                End If
    '            Next

    '            trans.Commit()
    '            MessageBox.Show(If(headerStatus = 3, "Partially Received!", "Complete!"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            StockClass.show_transfer_h_dest()
    '            StockClass.show_ItemBalanceList()
    '            Me.Close()
    '        Catch ex As Exception
    '            trans.Rollback()
    '            MessageBox.Show("Failed. All changes have been rolled back." & vbCrLf & ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End Try
    '    End Using
    'End Sub


    'Private Sub btnTransferReceived_Click(sender As Object, e As EventArgs) Handles btnTransferReceived.Click
    '    Dim isPartialReceived As Boolean
    '    Dim transferInList As New List(Of (skuCode As String, qtyToReceivedVal As Integer, qty As Integer))
    '    For Each row As DataGridViewRow In dgTransferL.Rows
    '        If row.IsNewRow Then Continue For

    '        Dim skuCode As String = row.Cells("ti_sku").Value?.ToString().Trim()
    '        Dim qtyToReceivedVal = Convert.ToDecimal(row.Cells("ti_approved_qty").Value)
    '        Dim qtyReceivedVal = row.Cells("ti_received_qty").Value

    '        If String.IsNullOrWhiteSpace(skuCode) OrElse qtyReceivedVal Is Nothing OrElse String.IsNullOrWhiteSpace(qtyReceivedVal.ToString()) Then
    '            MessageBox.Show($"Missing SKU or received quantity in row {row.Index + 1}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If

    '        Dim qty As Integer
    '        If Not Integer.TryParse(qtyReceivedVal.ToString(), qty) Then
    '            MessageBox.Show($"Invalid quantity format in row {row.Index + 1}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If

    '        'Dim isValidQty As Boolean = itemBal_picklist_isValidQty(userLoginComp, My.Settings.Store, skuCode, qty)
    '        'If Not isValidQty Then
    '        '    MessageBox.Show($"Insufficient quantity for SKU: {skuCode}", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        '    Exit Sub
    '        'End If

    '        If qtyToReceivedVal <> qty Then
    '            If qtyToReceivedVal < qty Then
    '                MessageBox.Show($"Oops! You entered a quantity that exceeds the quantity to be received for {skuCode}.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Exit Sub
    '            Else
    '                isPartialReceived = True
    '            End If
    '        End If

    '        transferInList.Add((skuCode, qtyToReceivedVal, qty))
    '    Next

    '    If isPartialReceived Then ' PARTIALLY RECEIVED
    '        Dim result As DialogResult = MessageBox.Show("Do you confirm that this DR was partially received?", "Yes, Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '        If result = DialogResult.Yes Then
    '            Using conn As New MySqlConnection(InvDBConn.ConnectionString)
    '                conn.Open()
    '                Dim trans As MySqlTransaction = conn.BeginTransaction()

    '                Try
    '                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                    For Each item In transferInList

    '                        Dim headerUpdated As Boolean = update_transfer_h_status(conn, trans, userLoginComp, lblTTStoreCodeOrig.Text, My.Settings.Store, txtTTDRNo.Text, 3, Nothing, Now)
    '                        If Not headerUpdated Then
    '                            Throw New Exception("Failed to Update transfer header status.")
    '                        End If

    '                        If item.qtyToReceivedVal > item.qty Then
    '                            Dim LineUpdated As Boolean = update_transfer_l_row(conn, trans, userLoginComp, lblTTStoreCodeOrig.Text, My.Settings.Store, txtTTDRNo.Text, 3, item.skuCode, Nothing, Nothing, Nothing, item.qty, Now)
    '                            If Not LineUpdated Then
    '                                Throw New Exception("Failed to Update item transfer status.")
    '                            End If
    '                        ElseIf item.qtyToReceivedVal = item.qty Then
    '                            Dim LineUpdated As Boolean = update_transfer_l_row(conn, trans, userLoginComp, lblTTStoreCodeOrig.Text, My.Settings.Store, txtTTDRNo.Text, 4, item.skuCode, Nothing, Nothing, Nothing, item.qty, Now)
    '                            If Not LineUpdated Then
    '                                Throw New Exception("Failed to Update item transfer status.")
    '                            End If
    '                        End If

    '                        Dim balanceUpdated As Boolean = add_itembalance(conn, trans, userLoginComp, My.Settings.Store, item.skuCode, item.qty)
    '                        If Not balanceUpdated Then
    '                            Throw New Exception($"Failed to process {item.skuCode}.")
    '                        End If
    '                    Next
    '                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    '                    MessageBox.Show("Partially Received!.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    StockClass.show_transfer_h_dest()
    '                    StockClass.show_ItemBalanceList()
    '                    trans.Commit()
    '                    Me.Close()
    '                Catch ex As Exception
    '                    ' Rollback on any error
    '                    trans.Rollback()
    '                    MessageBox.Show("Failed. All changes have been rolled back." & vbCrLf & ex.Message,
    '                                    "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Finally
    '                    conn.Close()
    '                End Try
    '            End Using
    '        End If
    '    Else ' COMPLETE
    '        Dim result As DialogResult = MessageBox.Show("Do you confirm that this DR was received and is now complete?", "Yes, Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '        If result = DialogResult.Yes Then
    '            Using conn As New MySqlConnection(InvDBConn.ConnectionString)
    '                conn.Open()
    '                Dim trans As MySqlTransaction = conn.BeginTransaction()

    '                Try
    '                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                    For Each item In transferInList

    '                        Dim headerUpdated As Boolean = update_transfer_h_status(conn, trans, userLoginComp, lblTTStoreCodeOrig.Text, My.Settings.Store, txtTTDRNo.Text, 4, Nothing, Now)
    '                        If Not headerUpdated Then
    '                            Throw New Exception("Failed to Update transfer header status.")
    '                        End If

    '                        Dim LineUpdated As Boolean = update_transfer_l_row(conn, trans, userLoginComp, lblTTStoreCodeOrig.Text, My.Settings.Store, txtTTDRNo.Text, 4, item.skuCode, Nothing, Nothing, Nothing, item.qty, Now)
    '                        If Not LineUpdated Then
    '                            Throw New Exception("Failed to Update item transfer status.")
    '                        End If

    '                        Dim balanceUpdated As Boolean = add_itembalance(conn, trans, userLoginComp, My.Settings.Store, item.skuCode, item.qty)
    '                        If Not balanceUpdated Then
    '                            Throw New Exception($"Failed to process {item.skuCode}.")
    '                        End If
    '                    Next
    '                    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '                    trans.Commit()

    '                    MessageBox.Show("Complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    StockClass.show_transfer_h_dest()
    '                    StockClass.show_ItemBalanceList()
    '                    Me.Close()
    '                Catch ex As Exception
    '                    ' Rollback on any error
    '                    trans.Rollback()
    '                    MessageBox.Show("Failed. All changes have been rolled back." & vbCrLf & ex.Message,
    '                                    "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Finally
    '                    conn.Close()
    '                End Try
    '            End Using
    '        End If
    '    End If
    'End Sub


End Class
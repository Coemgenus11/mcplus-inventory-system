Public Class frmItemLoc


    Private Sub dgItemLoc_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgItemLoc.CellDoubleClick
        If e.RowIndex >= 0 Then
            If frmItemList.frmCurrent = "TT" Then ' MANUAL PURCHASE
                Dim row As DataGridViewRow = dgItemLoc.Rows(e.RowIndex)
                Dim selectedLoc As String = row.Cells("loc_code").Value.ToString()
                Dim selectedSKU As String = lblLocSKU.Text
                Dim selectedItem As String = lblLocProdDesc.Text
                Dim selectedVar As String = lblLocVar.Text
                Dim selectedColor As String = lblLocColor.Text
                Dim currentStock As String = row.Cells("loc_qty_current").Value.ToString()

                If currentStock < 1 Then
                    MessageBox.Show("Oops! Insufficient quantity for this item location.", "Out of stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                For Each existingRow As DataGridViewRow In frmStockOut.dgTransfer.Rows
                    If Not existingRow.IsNewRow Then ' Avoid the new blank row
                        If existingRow.Cells("transfer_skucode").Value IsNot Nothing AndAlso existingRow.Cells("transfer_skucode").Value.ToString() = selectedSKU AndAlso existingRow.Cells("transfer_loc_code").Value.ToString() = selectedLoc Then
                            MessageBox.Show("This SKU in location " + selectedLoc + " already exists in the list.", "Duplicate SKU", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    End If
                Next
                frmStockOut.dgTransfer.Rows.Add(
                    selectedSKU,
                    selectedItem,
                    selectedColor,
                    selectedVar,
                    selectedLoc,
                    currentStock
                )
            ElseIf frmItemList.frmCurrent = "RT" Then

                Dim row As DataGridViewRow = dgItemLoc.Rows(e.RowIndex)
                Dim selectedLoc As String = row.Cells("loc_code").Value.ToString()
                Dim selectedSKU As String = lblLocSKU.Text
                Dim selectedItem As String = lblLocProdDesc.Text
                Dim selectedVar As String = lblLocVar.Text
                Dim selectedColor As String = lblLocColor.Text
                Dim currentStock As String = row.Cells("loc_qty_current").Value.ToString()

                If currentStock < 1 Then
                    MessageBox.Show("Oops! Insufficient quantity for this item location.", "Out of stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                For Each existingRow As DataGridViewRow In frmTransferData.dgTransferL.Rows
                    If Not existingRow.IsNewRow Then ' Avoid the new blank row
                        If existingRow.Cells("tt_sku").Value IsNot Nothing AndAlso existingRow.Cells("tt_sku").Value.ToString() = selectedSKU AndAlso existingRow.Cells("tt_loc").Value.ToString() = selectedLoc Then
                            MessageBox.Show("This SKU in location " + selectedLoc + " already exists in the list.", "Duplicate SKU", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    End If
                Next
                frmTransferData.dgTransferL.Rows.Add(
                    get_user_comp(My.Settings.CurrentUserID),
                    frmTransferData.txtTTDRNo.Text,
                    selectedSKU,
                    selectedItem,
                    selectedColor,
                    selectedVar,
                    selectedLoc
                )
            End If

        End If

    End Sub

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        lblForTransferOut.Visible = False
    End Sub

    Private Sub frmItemLoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
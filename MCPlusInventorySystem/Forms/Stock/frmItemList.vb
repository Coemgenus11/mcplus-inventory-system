Public Class frmItemList

    Public Shared frmCurrent As String

    Private Sub txtItemListSearch_TextChanged(sender As Object, e As EventArgs) Handles txtItemListSearch.TextChanged
        ItemListClass.itemListSearch(txtItemListSearch.Text)
    End Sub

    Private Sub dgItemList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgItemList.CellDoubleClick
        If e.RowIndex >= 0 Then
            ' Get selected row from current form
            Dim row As DataGridViewRow = dgItemList.Rows(e.RowIndex)
            Dim selectedSKU As String = row.Cells("stock_skucode").Value.ToString()
            Dim currentStock As String = row.Cells("stock_current").Value.ToString()


            ' Add row values if not duplicate
            If frmCurrent = "MP" Then ' MANUAL PURCHASE
                ' Check if SKU already exists in FormB's DataGridView
                For Each existingRow As DataGridViewRow In frmAddStock.dgOS.Rows
                    If Not existingRow.IsNewRow Then ' Avoid the new blank row
                        If existingRow.Cells(0).Value IsNot Nothing AndAlso existingRow.Cells(0).Value.ToString() = selectedSKU Then
                            MessageBox.Show("This SKU already exists in the list.", "Duplicate SKU", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    End If
                Next
                frmAddStock.dgOS.Rows.Add(
                    row.Cells("stock_skucode").Value,
                    row.Cells("stock_desc").Value,
                    row.Cells("stock_color").Value,
                    row.Cells("stock_variant").Value
                )

            ElseIf frmCurrent = "TT" OrElse frmCurrent = "RT" Then ' TRANSFER TO and REROUTE
                If currentStock < 1 Then
                    MessageBox.Show("Oops! Insufficient quantity for this item.", "Out of stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                frmItemLoc.lblLocSKU.Text = row.Cells("stock_skucode").Value
                frmItemLoc.lblLocProdDesc.Text = row.Cells("stock_desc").Value
                frmItemLoc.lblLocVar.Text = row.Cells("stock_variant").Value
                frmItemLoc.lblLocColor.Text = row.Cells("stock_color").Value
                frmItemLoc.lblLocTotalQty.Text = row.Cells("stock_current").Value
                Dim sku As String = row.Cells("stock_skucode").Value.ToString()
                ItemListClass.show_ItemList(frmCurrent, True)
                If ItemListClass.cachedItemList IsNot Nothing Then
                    Dim filteredRows() As DataRow = ItemListClass.cachedItemList.Select("sku_code = '" & sku.Replace("'", "''") & "'")
                    frmItemLoc.dgItemLoc.Rows.Clear()
                    For Each dr As DataRow In filteredRows
                        frmItemLoc.dgItemLoc.Rows.Add(
                                                        dr("item_loc").ToString(),
                                                        dr("item_qty")
                                                    )
                    Next
                End If
                frmItemLoc.lblForTransferOut.Visible = True
                frmItemLoc.ShowDialog()
            End If

        End If
    End Sub

    Private Sub frmItemList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(frmCurrent)
        If frmCurrent Is "TT" Then
            lblForTransferOut.Visible = True
        End If
    End Sub

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        lblForTransferOut.Visible = False
        frmCurrent = ""
    End Sub


End Class
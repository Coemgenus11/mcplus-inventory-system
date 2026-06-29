Public Class frmPurchaseOrder


    Private Sub dgPO1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPO1.CellClick, dgPOPartial.CellClick, dgPO2.CellClick
        If e.RowIndex >= 0 Then
            Dim dgView As DataGridView = CType(sender, DataGridView)
            Dim columnName As String = dgView.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgView.Rows(e.RowIndex)

            Dim inputComp As String = selectedRow.Cells(0).Value.ToString()
            Dim storeCode As String = selectedRow.Cells(1).Value.ToString()
            Dim poNum As String = selectedRow.Cells(4).Value.ToString()

            If columnName = $"po_view1" Then
                StockClass.show_po_h()
                StockClass.show_po_l(poNum)
                frmPurchaseOrderItems.ShowDialog()

            ElseIf columnName = $"po_viewpartial" Then
                StockClass.show_po_h()
                StockClass.show_po_l(poNum)
                StockClass.show_poreceiving_h(poNum)
                frmPurchaseOrderItems.ShowDialog()

            ElseIf columnName = $"po_view2" Then
                StockClass.show_po_h()
                StockClass.show_po_l(poNum)
                StockClass.show_poreceiving_h(poNum)
                frmPurchaseOrderItems.ShowDialog()
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        StockClass.show_po_h()
    End Sub
End Class
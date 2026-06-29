Public Class frmTransferIn
    Private Sub dgTransfer9_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTransfer1.CellClick,
        dgTransfer2.CellClick, dgTransfer3.CellClick, dgTransfer4.CellClick, dgTransferPartialReceived.CellClick, dgTransfer9.CellClick

        If e.RowIndex >= 0 Then
            Dim dgView As DataGridView = CType(sender, DataGridView)
            Dim columnName As String = dgView.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgView.Rows(e.RowIndex)

            Dim inputComp As String = selectedRow.Cells(0).Value.ToString()
            Dim dr As String = selectedRow.Cells(3).Value.ToString()
            Dim storeCodeDestination As String = selectedRow.Cells(1).Value.ToString()
            Dim storeCodeOrigin As String = selectedRow.Cells(2).Value.ToString()


            ' Loop from 0 to 4 to match column name pattern "th_viewX"
            If columnName = $"ti_viewParRec" Then
                frmTransferInData.selectedTransferHStatus = "partial"
                StockClass.show_transfer_h_dest()
                StockClass.show_transfer_l(inputComp, dr, storeCodeOrigin, storeCodeDestination, "in")
                frmTransferInData.ShowDialog()
            Else
                For i As Integer = 0 To 9
                    If columnName = $"ti_view{i}" Then
                        frmTransferInData.selectedTransferHStatus = i
                        StockClass.show_transfer_h_dest()
                        StockClass.show_transfer_l(inputComp, dr, storeCodeOrigin, storeCodeDestination, "in")
                        frmTransferInData.ShowDialog()
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
    Private Sub tcStockTransferIn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcStockTransferIn.SelectedIndexChanged
        StockClass.show_transfer_h_dest()
    End Sub

End Class
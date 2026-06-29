Public Class frmStockInData
    Private Sub btnStockINPrint_Click(sender As Object, e As EventArgs) Handles btnStockINPrint.Click
        GenerateQRClass.PrintLabels(dgMPL, "mpl")
        StockClass.cachedStockInLines = Nothing
    End Sub

    Private Sub dgMPL_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgMPL.CellValueChanged
        btnStockINPrint.Enabled = dgMPL.Rows.Cast(Of DataGridViewRow)().Any(Function(r) CBool(r.Cells("sku_selectprint").Value))
    End Sub
    Private Sub ddgMPL_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgMPL.CurrentCellDirtyStateChanged
        If dgMPL.IsCurrentCellDirty Then dgMPL.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgMPL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMPL.CellClick
        ' Ensure the click is not on the header row
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgMPL.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgMPL.Rows(e.RowIndex)
            ' Get existing values

            If columnName = "no_print" Then
                dgMPL.CurrentCell = dgMPL.Rows(e.RowIndex).Cells("no_print")
                dgMPL.BeginEdit(True)

            ElseIf columnName = "sku_code" Then

                Dim valueToCopy As String = dgMPL.Rows(e.RowIndex).Cells("sku_code").Value.ToString()
                Clipboard.SetText(valueToCopy)
                MessageBox.Show("Copied: " & valueToCopy)
            End If
        End If
    End Sub

End Class
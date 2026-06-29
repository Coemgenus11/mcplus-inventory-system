Public Class frmPriceUpdate

    Private Sub btnPriceUpdateSave_Click(sender As Object, e As EventArgs) Handles btnPriceUpdateSave.Click
        If MessageBox.Show("Are you sure you want to update Price/s?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Dim success As Boolean = update_itemprice(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store, lblPriceSku.Text, txtPriceUnit.Text, txtPriceRetail.Text)
            If success Then
                MsgBox("Variation successfully added.", MsgBoxStyle.Information, "Success")
                'ItemPriceClass.show_ItemPrice()
                For Each row As DataGridViewRow In frmMain.dgPrice.Rows
                    If row.Cells("price_skucode").Value.ToString() = lblPriceSku.Text Then
                        row.Cells("price_unit").Value = txtPriceUnit.Text
                        row.Cells("price_retail").Value = txtPriceRetail.Text
                        Exit For
                    End If
                Next
                Me.Close()
            Else
                MsgBox("Failed to add variation.", MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub txtPriceUnit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPriceUnit.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Only allow one decimal point
        If e.KeyChar = "."c AndAlso txtPriceUnit.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPriceRetail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPriceRetail.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Only allow one decimal point
        If e.KeyChar = "."c AndAlso txtPriceRetail.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
Public Class ItemPriceClass
    Public Shared cachedItemPrices As DataTable = Nothing

    Public Shared Sub show_ItemPrice(Optional forceRefresh As Boolean = False)


        ' Kung walang cache pa or pinilit mag-refresh, query ulit
        If cachedItemPrices Is Nothing OrElse forceRefresh Then
            cachedItemPrices = get_itemPrice(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)
            frmMain.dgPrice.Refresh()
            frmMain.dgPrice.Rows.Clear()
            If cachedItemPrices.Rows.Count > 0 Then
                For Each Row As DataRow In cachedItemPrices.Rows
                    frmMain.dgPrice.Rows.Add(
                        Row("sku_code"),
                        Row("gen_desc") + " " + Row("col_desc") + " " + Row("type_desc") + " " + Row("stylecat_desc") + " " + Row("stylevar_desc"),
                        Row("color_desc"),
                        Row("variant"),
                        Row("unit_price"),
                        Row("retail_price")
                    )
                Next
            End If
        End If
    End Sub

    Public Shared Sub itemPriceSearch(searchText As String)
        If frmMain.dgPrice.Rows.Count > 0 Then
            For Each row As DataGridViewRow In frmMain.dgPrice.Rows
                If row.Cells("price_skucode").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("price_desc").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("price_variant").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("price_color").Value.ToString().ToLower().Contains(searchText.ToLower()) Then
                    row.Visible = True
                Else
                    row.Visible = False
                End If
            Next
        End If
    End Sub
End Class

Public Class ItemListClass
    Public Shared pickListSelected As Boolean
    Public Shared cachedItemList As DataTable = Nothing

    Public Shared Sub show_ItemList(ByVal frm As String, ByVal isFrmPick As Boolean, Optional forceRefresh As Boolean = False)
        pickListSelected = isFrmPick
        frmItemList.frmCurrent = frm

        If cachedItemList Is Nothing OrElse forceRefresh Then
            cachedItemList = get_itembalance(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store, isFrmPick)
        End If

        If cachedItemList Is Nothing Then Exit Sub

        ' Dictionary to store summed qty per SKU
        Dim skuDict As New Dictionary(Of String, Double)

        ' Optional: store other details (desc, brand, etc.)
        Dim skuDetails As New Dictionary(Of String, DataRow)

        ' Step 1: Group and Sum
        For Each row As DataRow In cachedItemList.Rows
            Dim sku As String = row("sku_code").ToString()
            Dim qty As Double = Convert.ToDouble(row("item_qty"))

            If skuDict.ContainsKey(sku) Then
                skuDict(sku) += qty
            Else
                skuDict.Add(sku, qty)
                skuDetails.Add(sku, row) ' store first occurrence for other fields
            End If
        Next

        ' Step 2: Display / Update Grid
        For Each kvp In skuDict
            Dim sku As String = kvp.Key
            Dim totalQty As Double = kvp.Value
            Dim row As DataRow = skuDetails(sku)

            Dim found As Boolean = False

            For Each dgRow As DataGridViewRow In frmItemList.dgItemList.Rows
                If dgRow.Cells(0).Value.ToString() = sku Then
                    dgRow.Cells(4).Value = totalQty
                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                frmItemList.dgItemList.Rows.Add(
                sku,
                row("gen_desc") + " " + row("col_desc") + " " + row("type_desc") + " " + row("stylecat_desc") + " " + row("stylevar_desc"),
                row("color_desc"),
                row("variant"),
                totalQty
            )
            End If
        Next

        'frmItemList.ShowDialog()

    End Sub

    Public Shared Sub itemListSearch(searchText As String)
        If frmItemList.dgItemList.Rows.Count > 0 Then
            For Each row As DataGridViewRow In frmItemList.dgItemList.Rows
                If row.Cells("stock_skucode").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("stock_desc").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("stock_variant").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("stock_color").Value.ToString().ToLower().Contains(searchText.ToLower()) Then
                    row.Visible = True
                Else
                    row.Visible = False
                End If
            Next
        End If
    End Sub
End Class

Public Class SKUClass
    Public Shared cachedItems As DataTable = Nothing

    Public Shared Sub show_ItemSKU(Optional forceRefresh As Boolean = False)
        'LOAD ALL LISTS PARENT SKU
        If cachedItems Is Nothing OrElse forceRefresh Then
            cachedItems = get_items(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)

            frmItem.dgSKU.Refresh()
            frmItem.dgSKU.Rows.Clear()

            frmMain.dgSKU.Refresh()
            frmMain.dgSKU.Rows.Clear()

            If cachedItems.Rows.Count > 0 Then
                For Each Row As DataRow In cachedItems.Rows
                    Dim nmi As String = If(Row("merchandise") < 1, "No", "Yes")
                    Dim status As String = If(Row("status") < 1, "inactive", "active")

                    frmItem.dgSKU.Rows.Add(
                        Row("company_code"),
                        Row("sku_link"),
                        Row("sku_code"),
                        Row("gen_desc"),
                        Row("col_desc"),
                        Row("type_desc"),
                        Row("stylecat_desc") + " " + Row("stylevar_desc"),
                        Row("color_desc"),
                        Row("variant"),
                        Row("item_qty"),
                        Row("unit_price"),
                        Row("retail_price"),
                        nmi,
                        status,
                        1,
                        Row("printed")
                    )
                    frmMain.dgSKU.Rows.Add(
                        Row("sku_code"),
                        Row("gen_desc") + " " + Row("col_desc") + " " + Row("type_desc") + " " + Row("stylecat_desc") + " " + Row("stylevar_desc") + " - " + Row("color_desc"),
                        Row("variant")
                    )
                Next
            End If
        End If

        initialSkuLoad()
    End Sub

    Public Shared Sub initialSkuLoad()
        If frmItem.dgSKU.Rows.Count > 0 Then
            LoadSkuFromRow(frmItem.dgSKU.Rows(0))
            frmItem.dgSKU.ClearSelection()
            frmItem.dgSKU.Rows(0).Selected = True
        End If
    End Sub

    Public Shared Sub LoadSkuFromRow(row As DataGridViewRow)
        Dim skuCode As String = row.Cells("sku_code").Value.ToString()
        Dim skuDesc As String = row.Cells("sku_gender").Value.ToString() + " " + row.Cells("sku_col").Value.ToString() + " " + row.Cells("sku_type").Value.ToString() + " " + row.Cells("sku_cat").Value.ToString() + " " + row.Cells("sku_color").Value.ToString() + " - " + row.Cells("sku_variant").Value.ToString()
        Dim skuNMI As String = row.Cells("sku_nmicode").Value.ToString()
        Dim skuStatus As String = row.Cells("sku_status").Value.ToString()

        frmItem.txtSkuCode.Text = skuCode
        frmItem.txtSkuDesc.Text = skuDesc
        frmItem.btnSkuNmi.Text = skuNMI
        frmItem.btnSkuStatus.Text = skuStatus

    End Sub

    Public Shared Sub skuFilterData(searchText As String)
        If frmItem.dgSKU.Rows.Count > 0 Then
            For Each row As DataGridViewRow In frmItem.dgSKU.Rows
                If row.Cells("sku_code").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("sku_gender").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("sku_col").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("sku_type").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("sku_cat").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("sku_color").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("sku_variant").Value.ToString().ToLower().Contains(searchText.ToLower()) Then
                    row.Visible = True
                Else
                    row.Visible = False
                End If
            Next
        End If
    End Sub
End Class

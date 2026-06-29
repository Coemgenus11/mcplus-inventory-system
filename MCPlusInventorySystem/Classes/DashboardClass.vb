Public Class DashboardClass


    Public Shared cachedFastMoving As DataTable = Nothing
    Public Shared Sub show_fast_moving(Optional forceRefresh As Boolean = False)
        Dim userLoginComp As String
        userLoginComp = get_user_comp(My.Settings.CurrentUserID)
        ' If walang laman ang cache OR gusto ng user mag-refresh
        If cachedFastMoving Is Nothing OrElse forceRefresh Then
            cachedFastMoving = get_fastmoving(userLoginComp, My.Settings.Store)

            If cachedFastMoving.Rows.Count > 0 Then
                'frmMain.dgBrand.Rows.Clear()
                'frmItem.dgBrand.Rows.Clear()

                For Each Row As DataRow In cachedFastMoving.Rows
                    frmMain.dgDashFastMoving.Rows.Add(Row("sku_code"), Row("item_desc"), Row("variation"), Row("brand_desc"), Row("total_qty_sold"))
                Next
            End If
        End If
    End Sub
End Class

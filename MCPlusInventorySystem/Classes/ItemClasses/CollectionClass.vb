Public Class CollectionClass
    Public Shared cachedCollections As DataTable = Nothing

    Public Shared Sub show_collection(Optional forceRefresh As Boolean = False)

        ' Load from DB if cache is empty or refresh is requested
        If cachedCollections Is Nothing OrElse forceRefresh Then
            cachedCollections = get_itemcol(get_user_comp(My.Settings.CurrentUserID))
            frmItem.dgCol.Refresh()
            frmItem.dgCol.Rows.Clear()
            frmMain.dgCol.Rows.Clear()

            If cachedCollections.Rows.Count > 0 Then
                For Each Row As DataRow In cachedCollections.Rows
                    Dim status As String = If(Convert.ToInt32(Row("status")) = 1, "active", "inactive")
                    frmItem.dgCol.Rows.Add(Row("company_code"), Row("col_code"), Row("col_desc"), status)
                    frmMain.dgCol.Rows.Add(Row("col_code"), Row("col_desc"), status)
                Next
            End If
        End If
    End Sub
End Class

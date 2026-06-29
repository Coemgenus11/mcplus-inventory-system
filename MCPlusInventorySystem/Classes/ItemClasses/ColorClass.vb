Public Class ColorClass
    Public Shared cachedColors As DataTable = Nothing
    Public Shared Sub show_colors(Optional forceRefresh As Boolean = False)

        ' Load from DB if cache is empty or refresh is requested
        If cachedColors Is Nothing OrElse forceRefresh Then
            cachedColors = get_itemcolor(get_user_comp(My.Settings.CurrentUserID))
            frmItem.dgColor.Refresh()
            frmItem.dgColor.Rows.Clear()

            frmMain.dgColor.Refresh()
            frmMain.dgColor.Rows.Clear()

            If cachedColors.Rows.Count > 0 Then
                For Each Row As DataRow In cachedColors.Rows
                    Dim status As String = If(Convert.ToInt32(Row("status")) = 1, "active", "inactive")
                    frmItem.dgColor.Rows.Add(Row("company_code"), Row("color_code"), Row("color_desc"), status)
                    frmMain.dgColor.Rows.Add(Row("color_code"), Row("color_desc"), status)
                Next
            End If
        End If
    End Sub
End Class

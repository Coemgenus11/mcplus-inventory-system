Public Class GenderClass
    Public Shared cachedGenders As DataTable = Nothing
    Public Shared Sub show_genders(Optional forceRefresh As Boolean = False)

        ' Load from DB if cache is empty or refresh is requested
        If cachedGenders Is Nothing OrElse forceRefresh Then
            cachedGenders = get_itemgender(get_user_comp(My.Settings.CurrentUserID))
            frmItem.dgGender.Refresh()
            frmItem.dgGender.Rows.Clear()
            frmMain.dgGender.Refresh()
            frmMain.dgGender.Rows.Clear()

            If cachedGenders.Rows.Count > 0 Then
                For Each Row As DataRow In cachedGenders.Rows
                    Dim status As String = If(Convert.ToInt32(Row("status")) = 1, "active", "inactive")
                    frmItem.dgGender.Rows.Add(Row("company_code"), Row("gen_code"), Row("gen_desc"), status)
                    frmMain.dgGender.Rows.Add(Row("gen_code"), Row("gen_desc"), status)
                Next
            End If
        End If
    End Sub
End Class

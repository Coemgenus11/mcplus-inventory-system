Imports Microsoft.VisualBasic.ApplicationServices

Public Class AccountClass
    'Public Shared userLoginComp As String
    'Public Shared compDesc As String
    Public Shared cachedUsers As DataTable = Nothing
    Public Shared cachedAuth As DataTable = Nothing
    Public Shared Sub show_accounts(Optional forceRefresh As Boolean = False)

        If cachedUsers Is Nothing OrElse forceRefresh Then
            cachedUsers = get_users(get_user_comp(My.Settings.CurrentUserID))


            frmMain.dgAccountsUsers.Rows.Clear()
            frmAudit.dgAccountsUsers.Rows.Clear()
            If cachedUsers.Rows.Count > 0 Then

                For Each Row As DataRow In cachedUsers.Rows
                    Dim status As String = If(Row("user_stat") < 1, "inactive", "active")
                    frmAudit.dgAccountsUsers.Rows.Add(Row("iduser"), Row("user_pass"), Row("company_code"), Row("full_name"), Row("user_name"), Row("authority_code"), Row("user_desc"), status)
                    frmMain.dgAccountsUsers.Rows.Add(Row("iduser"), Row("user_name"), Row("user_desc"), Row("authority_code"))

                Next
            End If

        End If
    End Sub
    Public Shared Function GetSelectedUserDataRow(userID As Integer) As DataRow
        If cachedUsers Is Nothing OrElse cachedUsers.Rows.Count = 0 Then
            Return Nothing
        End If
        Dim filter As String = String.Format("idUser = {0}", userID)
        Dim foundRows() As DataRow = cachedUsers.Select(filter)
        If foundRows.Length > 0 Then
            Return foundRows(0) ' laging isa lang ang expectation
        Else
            Return Nothing
        End If
    End Function

    Public Shared Sub LoadCBAuth()
        Try
            Dim table_auth = cachedAuth
            frmUserInfo.cbUserAuth.Items.Clear()
            frmUserInfo.cbUserAuth.Items.Add("- Select -")
            Dim authDict As New Dictionary(Of String, String)

            For Each row As DataRow In table_auth.Rows
                Dim authDesc As String = row("authority_desc").ToString()
                Dim authCode As String = row("authority_code").ToString()

                frmUserInfo.cbUserAuth.Items.Add(authDesc)
                authDict(authDesc) = authCode
            Next

            If frmUserInfo.cbUserAuth.Items.Count > 0 Then
                frmUserInfo.cbUserAuth.SelectedIndex = 0
            End If
            AddHandler frmUserInfo.cbUserAuth.SelectedIndexChanged, Sub(sender As Object, e As EventArgs)
                                                                        Dim selectedName As String = frmUserInfo.cbUserAuth.Text
                                                                        If authDict.ContainsKey(selectedName) Then
                                                                            frmUserInfo.lblAuthCode.Text = authDict(selectedName)
                                                                        Else
                                                                            frmUserInfo.lblAuthCode.Text = "-"
                                                                        End If

                                                                    End Sub
        Catch ex As Exception
            MsgBox("Error loading Company Checkbox: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub show_auth(Optional forceRefresh As Boolean = False)

        If cachedAuth Is Nothing OrElse forceRefresh Then
            cachedAuth = get_auth(get_user_comp(My.Settings.CurrentUserID))
            If cachedAuth.Rows.Count > 0 Then
                frmMain.dgAuth.Rows.Clear()
                frmAudit.dgAuth.Rows.Clear()
                For Each Row As DataRow In cachedAuth.Rows
                    frmMain.dgAuth.Rows.Add(Row("company_code"), Row("authority_code"), Row("authority_desc"))
                    frmAudit.dgAuth.Rows.Add(Row("company_code"), Row("authority_code"), Row("authority_desc"))
                Next
            End If

        End If

    End Sub
    'Public Shared Sub show_tranauth()

    '    Dim table_user_auth = get_user_tranauth("%")
    '    If table_user_auth.Rows.Count > 0 Then
    '        frmMain.dgUserTrans.Rows.Clear()
    '        For Each Row As DataRow In table_user_auth.Rows
    '            frmMain.dgUserTrans.Rows.Add(Row(1), Row(2), Row(3), Row(4), CDate(Row(5)).ToString("yyyy-MM-dd"), Row(6), Row(7))
    '        Next
    '    End If
    'End Sub
End Class

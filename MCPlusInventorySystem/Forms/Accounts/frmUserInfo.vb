Imports Org.BouncyCastle.Asn1.Cmp

Public Class frmUserInfo

    Dim userLoginComp As String
    Dim compDesc As String
    Public Shared isCreate As Boolean
    Private Sub frmUserInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.centralAuditDB IsNot "" Then
            userLoginComp = get_user_comp(My.Settings.CurrentUserID)
            compDesc = get_company_desc(userLoginComp)
        End If
        If isCreate Then
            Label7.Visible = False
            lblUserID.Visible = False
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim authority_code As String = lblAuthCode.Text.Trim()
        Dim user_desc As String = txtDesc.Text.Trim()
        Dim user_fullname As String = txtFullname.Text.Trim()
        Dim user_name As String = txtUsername.Text.Trim()
        Dim user_pass As String = txtPass.Text.Trim()
        Dim user_stat As String = btnStatus.Text.Trim()
        Dim user_id As String = lblUserID.Text.Trim()

        Dim status As String = If(user_stat = "active", 1, 0)

        ' === ONE VALIDATION BLOCK ===
        Dim errorMsg As String = ""

        If authority_code = "-" Then
            errorMsg = "Please select authority."
        ElseIf String.IsNullOrWhiteSpace(user_desc) Then
            errorMsg = "Description is required."
        ElseIf String.IsNullOrWhiteSpace(user_fullname) Then
            errorMsg = "Full name is required."
        ElseIf String.IsNullOrWhiteSpace(user_name) Then
            errorMsg = "Username is required."
        ElseIf user_name.Contains(" ") Then
            errorMsg = "Username cannot contain spaces."
        ElseIf String.IsNullOrWhiteSpace(user_pass) Then
            errorMsg = "Password is required."
        ElseIf user_pass.Length < 6 Then
            errorMsg = "Password must be at least 6 characters long."
        End If

        If errorMsg <> "" Then
            MsgBox(errorMsg, MsgBoxStyle.Exclamation, "Validation Error")
            Exit Sub
        End If
        If isCreate Then
            If MessageBox.Show("Are you sure you want to create this user account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Dim success As Boolean = write_users(company_code, user_fullname, user_name, EncryptString(user_pass), user_desc, authority_code, status, My.Settings.CurrentUserID)

                If success Then
                    AccountClass.show_accounts(True)
                    MsgBox("Account successfully created.", MsgBoxStyle.Information, "Success")
                    Me.Close()
                Else
                    MsgBox("Failed to create account.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Else
            If MessageBox.Show("Are you sure you want to update this user account information?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Dim success As Boolean = update_user(user_id, company_code, user_fullname, user_name,
                                                        EncryptString(user_pass), user_desc, authority_code, status)
                If success Then
                    AccountClass.show_accounts(True)
                    MsgBox("Account Information successfully updated.", MsgBoxStyle.Information, "Success")
                    Me.Close()
                Else
                    MsgBox("Failed to update account information.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        End If


    End Sub

    Private Sub btnStatus_Click(sender As Object, e As EventArgs) Handles btnStatus.Click
        If btnStatus.Text = "active" Then
            btnStatus.Text = "inactive"
            btnStatus.BackColor = Color.LightCoral   ' example red shade kapag inactive
        Else
            btnStatus.Text = "active"
            btnStatus.BackColor = Color.FromArgb(192, 255, 192)  ' light green kapag active
        End If
    End Sub

    Private Sub frmUserInfo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        txtFullname.Text = ""
        txtUsername.Text = ""
        txtPass.Text = ""
        txtDesc.Text = ""
        lblAuthCode.Text = "-"
        lblCompanyCode.Text = "-"
        txtCompDesc.Text = ""
        cbUserAuth.Text = "- Select -"
        isCreate = False
        Label7.Visible = True
        lblUserID.Visible = True
    End Sub

    Private Sub txtPass_TextChanged(sender As Object, e As EventArgs) Handles txtPass.TextChanged
        txtPass.UseSystemPasswordChar = True
    End Sub
End Class
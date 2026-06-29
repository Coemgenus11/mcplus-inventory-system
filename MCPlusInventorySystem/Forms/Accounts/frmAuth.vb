Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmAuth
    Public Shared isCreate As Boolean
    Private Sub frmAuth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If isCreate Then
            lblAuth.Text = "ADD AUTHORITY"
        Else
            lblAuth.Text = "UPDATE AUTHORITY"
            txtAuthCode.Enabled = False
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim authority_code As String = txtAuthCode.Text.Trim()
        Dim authority_desc As String = txtAuthDesc.Text.Trim()

        Dim errorMsg As String = ""

        If String.IsNullOrWhiteSpace(authority_code) Then
            errorMsg = "Authority code is required."
        ElseIf authority_code.Length <> 3 Then
            errorMsg = "Authority code must be exactly 3 characters long."
        ElseIf String.IsNullOrWhiteSpace(authority_desc) Then
            errorMsg = "Authority description is required."
        End If

        If errorMsg <> "" Then
            MsgBox(errorMsg, MsgBoxStyle.Exclamation, "Validation Error")
            Exit Sub
        End If

        If isCreate Then 'if Add new Authority
            If check_authcode_exists(get_user_comp(My.Settings.CurrentUserID), authority_code) Then
                MsgBox("The Authority Code is already exist. Please input other code", MsgBoxStyle.Exclamation, "Validation Error")
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to add this authority?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Dim success As Boolean = write_authority(company_code, authority_code, authority_desc, My.Settings.CurrentUserID)

                If success Then
                    MsgBox("Authority successfully created.", MsgBoxStyle.Information, "Success")
                    AccountClass.show_auth(True)
                    Me.Close()
                Else
                    MsgBox("Failed to create authority.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Else
            If MessageBox.Show("Are you sure you want to update this authority?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Dim success As Boolean = update_authority_desc(company_code, authority_code, authority_desc)

                If success Then
                    MsgBox("Authority successfully updated.", MsgBoxStyle.Information, "Success")
                    AccountClass.show_auth(True)
                    Me.Close()
                Else
                    MsgBox("Failed to update authority.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        End If

    End Sub


    Private Sub frmAuth_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        txtAuthCode.Text = ""
        txtAuthDesc.Text = ""
        txtAuthCode.Enabled = True
        isCreate = False
    End Sub


End Class
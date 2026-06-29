Imports System.Xml.Schema

Public Class frmStyleVariant
    Private Sub btnSVarCancel_Click(sender As Object, e As EventArgs) Handles btnSVarCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSVarAdd_Click(sender As Object, e As EventArgs) Handles btnSVarAdd.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim svar_code As String = txtSVarCode.Text.Trim()
        Dim svar_desc As String = txtSVarDesc.Text.Trim()
        Dim svar_scat_code As String = lblSVarSCCode.Text.Trim()

        If IsInvalid(svar_scat_code) OrElse IsInvalid(svar_scat_code) Then
            MsgBox("Please check the style variant.", MsgBoxStyle.Exclamation, "Validation Error")
            Exit Sub
        End If
        If btnSVarAdd.Text = "Add" Then

            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(svar_code) OrElse
                    String.IsNullOrWhiteSpace(svar_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtSVarCode.Text.Length <> 1 Then
                    MessageBox.Show("Style Variant Code Input must be exactly 1 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtSVarCode.Focus()
                    Exit Sub
                End If
                If check_stylevar_code_exists(get_user_comp(My.Settings.CurrentUserID), svar_scat_code, svar_code) Then
                    MsgBox("The Style Variant Code is already exist in this style category " + lblSVarSCDesc.Text + ".", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to add this style variant?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = create_stylevar(company_code, svar_code, svar_desc, svar_scat_code, My.Settings.CurrentUserID)

                    If success Then
                        StyleCategoryClass.show_stylevar(True)
                        StyleCategoryClass.ShowStyleVarByStyleCat(svar_scat_code)
                        MsgBox("Style Variant successfully added.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to add style variant.", MsgBoxStyle.Critical, "Error")
                    End If
                End If
            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try


        ElseIf btnSVarAdd.Text = "Update" Then
            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(svar_code) OrElse
                    String.IsNullOrWhiteSpace(svar_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtSVarCode.Text.Length <> 1 Then
                    MessageBox.Show("Item Style Variant Code Input must be exactly 1 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtSVarCode.Focus()
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to update information of this style variant?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = update_itemstylevar(company_code, svar_code, svar_desc, svar_scat_code)
                    If success Then
                        StyleCategoryClass.show_stylevar(True)
                        StyleCategoryClass.ShowStyleVarByStyleCat(svar_scat_code)
                        MsgBox("style variant successfully updated.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to update style variant.", MsgBoxStyle.Critical, "Error")
                    End If
                End If

            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Private Function IsInvalid(value As String) As Boolean
        Return String.IsNullOrWhiteSpace(value) OrElse value = "-"
    End Function

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnSVarAdd.Text = "Add"
        txtSVarCode.Text = ""
        txtSVarCode.Enabled = True
        txtSVarDesc.Text = ""
    End Sub

    Private Sub frmStyleVariant_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
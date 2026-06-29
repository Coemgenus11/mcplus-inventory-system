Public Class frmGender
    Private Sub btnGenderCancel_Click(sender As Object, e As EventArgs) Handles btnGenderCancel.Click
        Me.Close()
    End Sub

    Private Sub btnGenderAdd_Click(sender As Object, e As EventArgs) Handles btnGenderAdd.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim gender_code As String = txtGenderCode.Text.Trim()
        Dim gender_desc As String = txtGenderDesc.Text.Trim()
        Dim status As String = btnGenderStatus.Text

        If btnGenderAdd.Text = "Add" Then

            Me.Cursor = Cursors.WaitCursor
            Try


                If String.IsNullOrWhiteSpace(gender_code) OrElse
                        String.IsNullOrWhiteSpace(gender_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtGenderCode.Text.Length <> 1 Then
                    MessageBox.Show("Gender Code Input must be exactly 1 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtGenderCode.Focus()
                    Exit Sub
                End If
                If check_gender_code_exists(get_user_comp(My.Settings.CurrentUserID), gender_code) Then
                    MsgBox("The Gender Code is already exist.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to add this gender?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = create_itemgender(company_code, gender_code, gender_desc, status, My.Settings.CurrentUserID)

                    If success Then
                        GenderClass.show_genders(True)
                        MsgBox("Gender successfully added.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to add gender.", MsgBoxStyle.Critical, "Error")
                    End If
                End If


            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try


        ElseIf btnGenderAdd.Text = "Update" Then
            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(gender_code) OrElse
                        String.IsNullOrWhiteSpace(gender_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtGenderCode.Text.Length <> 1 Then
                    MessageBox.Show("Gender Code Input must be exactly 1 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtGenderCode.Focus()
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to update information of this gender?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = update_itemgender(company_code, gender_code, gender_desc, status)
                    If success Then
                        GenderClass.show_genders(True)
                        MsgBox("gender successfully updated.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to update gender.", MsgBoxStyle.Critical, "Error")
                    End If
                End If

            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnGenderAdd.Text = "Add"
        txtGenderCode.Text = ""
        txtGenderCode.Enabled = True
        txtGenderDesc.Text = ""
    End Sub

    Private Sub btnGenderStatus_Click(sender As Object, e As EventArgs) Handles btnGenderStatus.Click
        Dim isActive As Boolean = (btnGenderStatus.Text = "active")
        btnGenderStatus.Text = If(isActive, "inactive", "active")
    End Sub

End Class
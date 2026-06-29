Public Class frmColor
    Private Sub btnColorCancel_Click(sender As Object, e As EventArgs) Handles btnColorCancel.Click
        Me.Close()
    End Sub

    Private Sub btnColorAdd_Click(sender As Object, e As EventArgs) Handles btnColorAdd.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim color_code As String = txtColorCode.Text.Trim()
        Dim color_desc As String = txtColorDesc.Text.Trim()
        Dim status As String = btnColorStatus.Text

        If btnColorAdd.Text = "Add" Then

            Me.Cursor = Cursors.WaitCursor
            Try


                If String.IsNullOrWhiteSpace(color_code) OrElse
                        String.IsNullOrWhiteSpace(color_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtColorCode.Text.Length <> 3 Then
                    MessageBox.Show("Color Code Input must be exactly 3 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtColorCode.Focus()
                    Exit Sub
                End If
                If check_color_code_exists(get_user_comp(My.Settings.CurrentUserID), color_code) Then
                    MsgBox("The Color Code is already exist.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to add this color?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = create_itemcolor(company_code, color_code, color_desc, status, My.Settings.CurrentUserID)

                    If success Then
                        ColorClass.show_colors(True)
                        MsgBox("Color successfully added.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to add color.", MsgBoxStyle.Critical, "Error")
                    End If
                End If


            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try


        ElseIf btnColorAdd.Text = "Update" Then
            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(color_code) OrElse
                        String.IsNullOrWhiteSpace(color_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtColorCode.Text.Length <> 3 Then
                    MessageBox.Show("Color Code Input must be exactly 3 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtColorCode.Focus()
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to update information of this color?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = update_itemcolor(company_code, color_code, color_desc, status)
                    If success Then
                        ColorClass.show_colors(True)
                        MsgBox("color successfully updated.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to update color.", MsgBoxStyle.Critical, "Error")
                    End If
                End If

            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnColorAdd.Text = "Add"
        txtColorCode.Text = ""
        txtColorCode.Enabled = True
        txtColorDesc.Text = ""
    End Sub

    Private Sub btnColorStatus_Click(sender As Object, e As EventArgs) Handles btnColorStatus.Click
        Dim isActive As Boolean = (btnColorStatus.Text = "active")
        btnColorStatus.Text = If(isActive, "inactive", "active")
    End Sub

    Private Sub frmColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
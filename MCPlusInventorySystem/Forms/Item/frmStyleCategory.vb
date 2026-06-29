Public Class frmStyleCategory
    Private Sub btnSCatCancel_Click(sender As Object, e As EventArgs) Handles btnSCatCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSCatAdd_Click(sender As Object, e As EventArgs) Handles btnSCatAdd.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim scat_code As String = txtSCatCode.Text.Trim()
        Dim scat_desc As String = txtSCatDesc.Text.Trim()
        Dim scat_wear_code As String = lblWearCode.Text.Trim()
        Dim scat_type_code As String = lblTypeCode.Text.Trim()

        If IsInvalid(scat_wear_code) OrElse IsInvalid(scat_type_code) Then
            MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
            Exit Sub
        End If
        If btnSCatAdd.Text = "Add" Then

            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(scat_code) OrElse
                        String.IsNullOrWhiteSpace(scat_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtSCatCode.Text.Length <> 2 Then
                    MessageBox.Show("Style Category Code Input must be exactly 2 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtSCatCode.Focus()
                    Exit Sub
                End If
                If check_stylecat_code_exists(get_user_comp(My.Settings.CurrentUserID), scat_code) Then
                    MsgBox("The Style Category Code is already exist.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to add this style category?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = create_stylecat(company_code, scat_code, scat_desc, lblWearCode.Text, lblTypeCode.Text, My.Settings.CurrentUserID)

                    If success Then
                        StyleCategoryClass.show_stylecat(True)
                        MsgBox("Style Category successfully added.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to add style category.", MsgBoxStyle.Critical, "Error")
                    End If
                End If
            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try


        ElseIf btnSCatAdd.Text = "Update" Then
            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(scat_code) OrElse
                        String.IsNullOrWhiteSpace(scat_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtSCatCode.Text.Length <> 2 Then
                    MessageBox.Show("Item Style Category Code Input must be exactly 2 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtSCatCode.Focus()
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to update information of this style category?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = update_itemstylecat(company_code, scat_code, scat_desc, lblWearCode.Text, lblTypeCode.Text)
                    If success Then
                        StyleCategoryClass.show_stylecat(True)
                        MsgBox("style category successfully updated.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to update style category.", MsgBoxStyle.Critical, "Error")
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
        btnSCatAdd.Text = "Add"
        txtSCatCode.Text = ""
        txtSCatCode.Enabled = True
        txtSCatDesc.Text = ""
    End Sub

    Private Sub frmStyleCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
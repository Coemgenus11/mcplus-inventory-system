Public Class frmProductVariant
    Private Sub btnSVarCancel_Click(sender As Object, e As EventArgs) Handles btnParVarCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSVarAdd_Click(sender As Object, e As EventArgs) Handles btnParVarAdd.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim var_code As String = txtParVarCode.Text.Trim()
        Dim var_desc As String = txtParVarDesc.Text.Trim()
        Dim par_code As String = txtParCode.Text.Trim()

        If IsInvalid(par_code) OrElse IsInvalid(par_code) Then
            MsgBox("Please check the variant.", MsgBoxStyle.Exclamation, "Validation Error")
            Exit Sub
        End If
        If btnParVarAdd.Text = "Add" Then

            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(var_code) OrElse
                    String.IsNullOrWhiteSpace(var_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtParVarCode.Text.Length <> 3 Then
                    MessageBox.Show("Variant Code Input must be exactly 3 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtParVarCode.Focus()
                    Exit Sub
                End If
                If check_var_code_exists(get_user_comp(My.Settings.CurrentUserID), par_code, var_code) Then
                    MsgBox("The Variant Code is already exist in this Parent Product '" + txtParDesc.Text + "'.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to add this variant?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = create_variation(company_code, var_code, var_desc, par_code, My.Settings.CurrentUserID)

                    If success Then
                        SKUCreationClass.get_variations(True)
                        SKUCreationClass.show_itemvariant(par_code)
                        MsgBox("Style Variant successfully added.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to add variant.", MsgBoxStyle.Critical, "Error")
                    End If
                End If
            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try


        ElseIf btnParVarAdd.Text = "Update" Then
            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(var_code) OrElse
                    String.IsNullOrWhiteSpace(var_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure you want to update information of this variant?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = update_variantdesc(company_code, var_code, var_desc, par_code)
                    If success Then
                        SKUCreationClass.get_variations(True)
                        SKUCreationClass.show_itemvariant(par_code)
                        MsgBox("variant successfully updated.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to update variant.", MsgBoxStyle.Critical, "Error")
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
        btnParVarAdd.Text = "Add"
        txtParVarCode.Text = ""
        txtParVarCode.Enabled = True
        txtParVarDesc.Text = ""
    End Sub
End Class
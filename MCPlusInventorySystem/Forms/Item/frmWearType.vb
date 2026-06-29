Public Class frmWearType

    Private Sub btnWTCancel_Click(sender As Object, e As EventArgs) Handles btnWTCancel.Click
        Me.Close()
    End Sub

    Private Sub btnWTAdd_Click(sender As Object, e As EventArgs) Handles btnWTAdd.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim wear_code As String = txtWTCode.Text.Trim()
        Dim wear_desc As String = txtWTDesc.Text.Trim()

        If btnWTAdd.Text = "Add" Then

            Me.Cursor = Cursors.WaitCursor
            Try


                If String.IsNullOrWhiteSpace(wear_code) OrElse
                        String.IsNullOrWhiteSpace(wear_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtWTCode.Text.Length <> 2 Then
                    MessageBox.Show("Wear Type Code Input must be exactly 2 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtWTCode.Focus()
                    Exit Sub
                End If
                If check_itemwear_code_exists(get_user_comp(My.Settings.CurrentUserID), wear_code) Then
                    MsgBox("The Wear Type Code is already exist.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to add this wear type?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = create_itemwear(company_code, wear_code, wear_desc, My.Settings.CurrentUserID)

                    If success Then
                        StyleCategoryClass.show_weartype(True)
                        MsgBox("wear successfully added.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to add wear type.", MsgBoxStyle.Critical, "Error")
                    End If
                End If


            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try


        ElseIf btnWTAdd.Text = "Update" Then
            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(wear_code) OrElse
                        String.IsNullOrWhiteSpace(wear_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtWTCode.Text.Length <> 2 Then
                    MessageBox.Show("Wear Type Code Input must be exactly 2 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtWTCode.Focus()
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to update information of this wear type?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = update_itemwear(company_code, wear_code, wear_desc)
                    If success Then
                        StyleCategoryClass.show_weartype(True)
                        MsgBox("wear type successfully updated.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to update itemwear.", MsgBoxStyle.Critical, "Error")
                    End If
                End If

            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnWTAdd.Text = "Add"
        txtWTCode.Text = ""
        txtWTCode.Enabled = True
        txtWTDesc.Text = ""
    End Sub
    Private Sub frmWearType_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
Public Class frmItemType

    Private Sub btnTypeCancel_Click(sender As Object, e As EventArgs) Handles btnTypeCancel.Click
        Me.Close()
    End Sub

    Private Sub btnTypeAdd_Click(sender As Object, e As EventArgs) Handles btnTypeAdd.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim type_code As String = txtTypeCode.Text.Trim()
        Dim type_desc As String = txtTypeDesc.Text.Trim()

        If btnTypeAdd.Text = "Add" Then

            Me.Cursor = Cursors.WaitCursor
            Try


                If String.IsNullOrWhiteSpace(type_code) OrElse
                        String.IsNullOrWhiteSpace(type_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtTypeCode.Text.Length <> 1 Then
                    MessageBox.Show("Item Type Code Input must be exactly 1 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtTypeCode.Focus()
                    Exit Sub
                End If
                If check_itemtype_code_exists(get_user_comp(My.Settings.CurrentUserID), type_code) Then
                    MsgBox("The Item Type Code is already exist.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to add this item type?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = create_itemtype(company_code, type_code, type_desc, My.Settings.CurrentUserID)

                    If success Then
                        StyleCategoryClass.show_types(True)
                        MsgBox("Item type successfully added.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to add item type.", MsgBoxStyle.Critical, "Error")
                    End If
                End If


            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try


        ElseIf btnTypeAdd.Text = "Update" Then
            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(type_code) OrElse
                        String.IsNullOrWhiteSpace(type_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtTypeCode.Text.Length <> 1 Then
                    MessageBox.Show("Item Type Code Input must be exactly 1 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtTypeCode.Focus()
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to update information of this item type?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = update_itemtype(company_code, type_code, type_desc)
                    If success Then
                        StyleCategoryClass.show_types(True)
                        MsgBox("item type successfully updated.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to update itemtype.", MsgBoxStyle.Critical, "Error")
                    End If
                End If

            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnTypeAdd.Text = "Add"
        txtTypeCode.Text = ""
        txtTypeCode.Enabled = True
        txtTypeDesc.Text = ""
    End Sub

    Private Sub frmItemType_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
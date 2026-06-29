Public Class frmCollection
    Private Sub btnColCancel_Click(sender As Object, e As EventArgs) Handles btnColCancel.Click
        Me.Close()
    End Sub

    Private Sub btnColAdd_Click(sender As Object, e As EventArgs) Handles btnColAdd.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim col_code As String = txtColCode.Text.Trim()
        Dim col_desc As String = txtColDesc.Text.Trim()
        Dim status As String = btnColStatus.Text

        If btnColAdd.Text = "Add" Then

            Me.Cursor = Cursors.WaitCursor
            Try


                If String.IsNullOrWhiteSpace(col_code) OrElse
                        String.IsNullOrWhiteSpace(col_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtColCode.Text.Length <> 1 Then
                    MessageBox.Show("Collection Code Input must be exactly  character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtColCode.Focus()
                    Exit Sub
                End If
                If check_col_code_exists(get_user_comp(My.Settings.CurrentUserID), col_code) Then
                    MsgBox("The Collection Code is already exist.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to add this collection?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = create_itemcol(company_code, col_code, col_desc, status, My.Settings.CurrentUserID)

                    If success Then
                        CollectionClass.show_collection(True)
                        MsgBox("Collection successfully added.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to add col.", MsgBoxStyle.Critical, "Error")
                    End If
                End If


            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try


        ElseIf btnColAdd.Text = "Update" Then
            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(col_code) OrElse
                        String.IsNullOrWhiteSpace(col_desc) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtColCode.Text.Length <> 1 Then
                    MessageBox.Show("Collection Code Input must be exactly  character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtColCode.Focus()
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to update information of this col?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = update_itemcol(company_code, col_code, col_desc, status)
                    If success Then
                        CollectionClass.show_collection(True)
                        MsgBox("Collection successfully updated.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to update collection.", MsgBoxStyle.Critical, "Error")
                    End If
                End If

            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnColAdd.Text = "Add"
        txtColCode.Text = ""
        txtColCode.Enabled = True
        txtColDesc.Text = ""
    End Sub

    Private Sub btnColStatus_Click(sender As Object, e As EventArgs) Handles btnColStatus.Click
        Dim isActive As Boolean = (btnColStatus.Text = "active")
        btnColStatus.Text = If(isActive, "inactive", "active")
    End Sub

    Private Sub frmCollection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
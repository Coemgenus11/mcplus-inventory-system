Public Class frmParentSKU
    Private Sub btnParCancel_Click(sender As Object, e As EventArgs) Handles btnParCancel.Click
        Me.Close()
    End Sub

    Private Sub btnParAdd_Click(sender As Object, e As EventArgs) Handles btnParAdd.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim gen_code As String = lblParGender.Text.Trim()
        Dim col_code As String = lblParCol.Text.Trim()
        Dim color_code As String = lblParColor.Text.Trim()
        Dim type_code As String = lblParType.Text.Trim()
        Dim stylecat_code As String = lblParSCat.Text.Trim()
        Dim stylevar_code As String = lblParSVar.Text.Trim()
        Dim parent_sku_code As String = txtParCode.Text.Trim()
        Dim status As String = btnParStatus.Text

        If IsInvalid(gen_code) OrElse IsInvalid(col_code) OrElse IsInvalid(color_code) OrElse IsInvalid(type_code) OrElse IsInvalid(stylecat_code) OrElse IsInvalid(stylevar_code) OrElse IsInvalid(parent_sku_code) Then
            MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
            Exit Sub
        End If
        If btnParAdd.Text = "Add" Then

            Me.Cursor = Cursors.WaitCursor
            Try

                If check_parentsku_exists(get_user_comp(My.Settings.CurrentUserID), parent_sku_code) Then
                    MsgBox("The Parent SKU Code is already exist.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to add this Parent SKU?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = create_parent_sku(company_code, parent_sku_code, gen_code, col_code, type_code, stylecat_code, stylevar_code, color_code, status, My.Settings.CurrentUserID)

                    If success Then
                        SKUCreationClass.show_parentSKU(True)
                        MsgBox("Parent SKU Code successfully Created.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to add parent sku product.", MsgBoxStyle.Critical, "Error")
                    End If
                End If

            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try


        ElseIf btnParAdd.Text = "Update" Then
            Me.Cursor = Cursors.WaitCursor
            Try

                If MessageBox.Show("Are you sure you want to update parent sku status?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = update_parent_sku(company_code, parent_sku_code, status)
                    If success Then
                        SKUCreationClass.show_parentSKU(True)
                        MsgBox("status successfully updated.", MsgBoxStyle.Information, "Success")
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
    Private Function IsInvalid(value As String) As Boolean
        Return String.IsNullOrWhiteSpace(value) OrElse value = "-"
    End Function
    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed


        btnParAdd.Text = "Add"
        btnParStatus.Text = "active"
        panelPar.Enabled = True
    End Sub

    Private Sub btnParStatus_Click(sender As Object, e As EventArgs) Handles btnParStatus.Click
        Dim isActive As Boolean = (btnParStatus.Text = "active")
        btnParStatus.Text = If(isActive, "inactive", "active")
    End Sub

    Private Sub frmParentSKU_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
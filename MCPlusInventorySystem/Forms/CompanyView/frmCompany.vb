Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmCompany

    Private Sub btnComAdd_Click(sender As Object, e As EventArgs) Handles btnComAdd.Click

        If btnComAdd.Text = "ADD" Then

            btnComStatus.Text = "active"
            btnComCancel.Enabled = True
            btnComAdd.Text = "SAVE"
            panelCom.Enabled = True
            lblComBtn.Text = "ADD COMPANY"

        Else
            Me.Cursor = Cursors.WaitCursor
            Try
                ' Validate required fields
                If txtComCode.Text = "" Or
                   txtComNo.Text = "" Or
                   btnComStatus.Text = "" Or
                   txtComDesc.Text = "" Or
                   txtComURL.Text = "" Or
                   txtComAddr.Text = "" Or
                   txtComTIN.Text = "" Or
                   txtComEmail.Text = "" Then

                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtComCode.Text.Length <> 2 Then
                    MessageBox.Show("Family Code Input must be exactly 2 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtComCode.Focus()
                    Exit Sub
                End If

                If check_comp_code_exists(txtComCode.Text) Then
                    MsgBox("The Company code is already exist.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If
                Dim comStatus As String = If(btnComStatus.Text = "active", 1, 0)

                Dim success As Boolean = create_company(txtComCode.Text, txtComDesc.Text, txtComAddr.Text, txtComTIN.Text, txtComNo.Text, txtComAddr.Text, txtComURL.Text, comStatus)

                If success Then
                    MsgBox("Company record successfully added.", MsgBoxStyle.Information, "Success")

                Else
                    MsgBox("Failed to add Company record.", MsgBoxStyle.Critical, "Error")
                End If
                CompanyClass.show_company()
                CompanyClass.ComCancelOrSave()
            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub dgCompList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCompList.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgCompList.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgCompList.Rows(e.RowIndex)

            ' Get existing values
            Dim companyCode As String = selectedRow.Cells("comp_code").Value.ToString()
            Dim companyDesc As String = selectedRow.Cells("comp_desc").Value.ToString()
            Dim companyAddress As String = selectedRow.Cells("comp_addr").Value.ToString()
            Dim companyTIN As String = selectedRow.Cells("comp_tin").Value.ToString()
            Dim companyURL As String = selectedRow.Cells("company_url").Value.ToString()
            Dim companyContact As String = selectedRow.Cells("comp_contact").Value.ToString()
            Dim companyEmail As String = selectedRow.Cells("comp_email").Value.ToString()
            Dim companyStatus As String = selectedRow.Cells("comp_status").Value.ToString()

            If columnName = "com_edit" Then
                CompanyClass.ComEditOrAdd()
                ' Assign values to textboxes instead of using InputBox
                txtComCode.Text = companyCode
                txtComNo.Text = companyContact
                btnComStatus.Text = companyStatus
                txtComDesc.Text = companyDesc
                txtComURL.Text = companyURL
                txtComAddr.Text = companyAddress
                txtComTIN.Text = companyTIN
                txtComEmail.Text = companyEmail

            End If
        End If
    End Sub

    Private Sub btnComSave_Click(sender As Object, e As EventArgs) Handles btnComSave.Click

        Dim comCode As String = txtComCode.Text.Trim()
        Dim newComNo As String = txtComNo.Text.Trim()
        Dim newComStatus As String = btnComStatus.Text.Trim()
        Dim newComDesc As String = txtComDesc.Text.Trim()
        Dim newComURL As String = txtComURL.Text.Trim()
        Dim newComAddr As String = txtComAddr.Text.Trim()
        Dim newComTIN As String = txtComTIN.Text.Trim()
        Dim newComEmail As String = txtComEmail.Text.Trim()

        ' Validate required fields
        If txtComCode.Text = "" Or
           txtComNo.Text = "" Or
           btnComStatus.Text = "" Or
           txtComDesc.Text = "" Or
           txtComURL.Text = "" Or
           txtComAddr.Text = "" Or
           txtComTIN.Text = "" Or
           txtComEmail.Text = "" Then

            MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
            Exit Sub
        End If

        ' Update the record
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update Company data?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        Dim comStatus As String = If(newComStatus = "active", 1, 0)

        If result = DialogResult.Yes Then
            If update_company(comCode, newComDesc, newComAddr, newComTIN, newComNo, newComEmail, newComURL, comStatus) Then
                MessageBox.Show("Company data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CompanyClass.show_company()
                CompanyClass.ComCancelOrSave()
            Else
                MessageBox.Show("Failed to update record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        'FamilyClass.show_family()

    End Sub

    Private Sub btnComCancel_Click(sender As Object, e As EventArgs) Handles btnComCancel.Click
        CompanyClass.ComCancelOrSave()
    End Sub

    Private Sub txtComCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComCode.KeyPress
        If Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnComStatus_Click(sender As Object, e As EventArgs) Handles btnComStatus.Click
        Dim isActive As Boolean = (btnComStatus.Text = "active")
        btnComStatus.Text = If(isActive, "inactive", "active")
    End Sub
End Class
Public Class frmSupplier
    Private Sub btnSupCancel_Click(sender As Object, e As EventArgs) Handles btnSupCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSupAdd_Click(sender As Object, e As EventArgs) Handles btnSupAdd.Click

        Dim company_code As String = get_user_comp(My.Settings.CurrentUserID)
        Dim supplier_code As String = txtSupCode.Text.Trim()
        Dim supplier_desc As String = txtSupDesc.Text.Trim()
        Dim supplier_tin As String = txtSupTIN.Text.Trim()
        Dim supplier_addr As String = txtSupAddr.Text.Trim()
        Dim supplier_contact As String = txtSupContact.Text.Trim()
        Dim supplier_email As String = txtSupEmail.Text.Trim()
        Dim payment_terms As String = txtPaymentTerms.Text.Trim()

        If btnSupAdd.Text = "Add" Then



            Me.Cursor = Cursors.WaitCursor
            Try


                If String.IsNullOrWhiteSpace(supplier_code) OrElse
                        String.IsNullOrWhiteSpace(supplier_desc) OrElse
                        String.IsNullOrWhiteSpace(supplier_tin) OrElse
                        String.IsNullOrWhiteSpace(supplier_addr) OrElse
                        String.IsNullOrWhiteSpace(supplier_contact) OrElse
                        String.IsNullOrWhiteSpace(supplier_email) OrElse
                        String.IsNullOrWhiteSpace(payment_terms) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtSupCode.Text.Length <> 2 Then
                    MessageBox.Show("Item Code Input must be exactly 2 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtSupCode.Focus()
                    Exit Sub
                End If
                If check_supplier_code_exists(get_user_comp(My.Settings.CurrentUserID), supplier_code) Then
                    MsgBox("The Supplier Code is already exist.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to add this supplier?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = create_supplier(company_code, supplier_code, supplier_desc,
                                    supplier_tin, supplier_addr, supplier_contact,
                                    supplier_email, payment_terms, My.Settings.CurrentUserID)

                    If success Then
                        StockClass.show_Suppliers(True)
                        MsgBox("Supplier successfully added.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to add supplier.", MsgBoxStyle.Critical, "Error")
                    End If
                End If


            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try


        ElseIf btnSupAdd.Text = "Update" Then
            Me.Cursor = Cursors.WaitCursor
            Try
                If String.IsNullOrWhiteSpace(supplier_code) OrElse
                        String.IsNullOrWhiteSpace(supplier_desc) OrElse
                        String.IsNullOrWhiteSpace(supplier_tin) OrElse
                        String.IsNullOrWhiteSpace(supplier_addr) OrElse
                        String.IsNullOrWhiteSpace(supplier_contact) OrElse
                        String.IsNullOrWhiteSpace(supplier_email) OrElse
                        String.IsNullOrWhiteSpace(payment_terms) Then
                    MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Validation Error")
                    Exit Sub
                End If

                If txtSupCode.Text.Length <> 2 Then
                    MessageBox.Show("Item Code Input must be exactly 2 character.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtSupCode.Focus()
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to update information of this supplier?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Dim success As Boolean = update_supplier(company_code, supplier_code, supplier_desc,
                                    supplier_tin, supplier_addr, supplier_contact,
                                    supplier_email, payment_terms)
                    If success Then
                        StockClass.show_Suppliers(True)
                        MsgBox("Supplier successfully updated.", MsgBoxStyle.Information, "Success")
                        Me.Close()
                    Else
                        MsgBox("Failed to update supplier.", MsgBoxStyle.Critical, "Error")
                    End If
                End If

            Finally
                ' Change the cursor back to the default cursor when finished
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub PopupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        btnSupAdd.Text = "Add"
        txtSupCode.Text = ""
        txtSupCode.Enabled = True
        txtSupDesc.Text = ""
        txtSupTIN.Text = ""
        txtSupAddr.Text = ""
        txtSupContact.Text = ""
        txtSupEmail.Text = ""
        txtPaymentTerms.Text = ""
    End Sub
    Private Sub frmSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
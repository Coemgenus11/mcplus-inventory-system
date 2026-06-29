Public Class OrderSlipClass

    Public Shared Sub LoadMPurchaseSupCB()
        Try
            Dim table As DataTable = get_suppliers(get_user_comp(My.Settings.CurrentUserID))
            If table.Rows.Count = 0 Then Exit Sub

            Dim newRow As DataRow = table.NewRow()
            newRow("supplier_code") = ""
            newRow("supplier_desc") = ""
            table.Rows.InsertAt(newRow, 0)

            ' Bind to ComboBox
            With frmAddStock.cbMPSup
                .DataSource = table
                .DisplayMember = "supplier_desc" ' What user sees
                .ValueMember = "supplier_code"   ' What is used internally
                .SelectedIndex = 0 ' 
            End With

            AddHandler frmAddStock.cbMPSup.SelectedIndexChanged, Sub()
                                                                     Dim cb = frmAddStock.cbMPSup
                                                                     If cb.SelectedIndex >= 0 Then
                                                                         frmAddStock.lblSupCode.Text = cb.SelectedValue.ToString()
                                                                     Else
                                                                         frmAddStock.lblSupCode.Text = "Supplier Code"
                                                                     End If
                                                                 End Sub

        Catch ex As Exception
            MsgBox("Error loading suppliers: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub




End Class

Public Class CompanyClass

    Public Shared Sub show_company()
        Dim table_comp = get_company("%")
        If table_comp.Rows.Count > 0 Then
            frmMain.dgSettingsComp.Rows.Clear()
            frmCompany.dgCompList.Rows.Clear()

            For Each Row As DataRow In table_comp.Rows
                Dim status As String = If(Row("status") < 1, "inactive", "active")
                frmMain.dgSettingsComp.Rows.Add(Row("idcompany"), Row("company_code"), Row("company_desc"), Row("company_addr"), Row("tin_num"), Row("company_url"), Row("contact_num"), Row("email_addr"), status, CDate(Row("create_date")).ToString("yyyy-MM-dd"), Row("create_time"), Row("create_by"))
                frmCompany.dgCompList.Rows.Add(Row("idcompany"), Row("company_code"), Row("company_desc"), Row("company_addr"), Row("tin_num"), Row("company_url"), Row("contact_num"), Row("email_addr"), status, CDate(Row("create_date")).ToString("yyyy-MM-dd"), Row("create_time"), Row("create_by"))
                'frmAccounts.cbCompany.Items.Add(Row(1))
            Next
        End If
    End Sub


    Public Shared Sub ComEditOrAdd()
        frmCompany.btnComAdd.Visible = False
        frmCompany.panelCom.Enabled = True
        frmCompany.txtComCode.Enabled = False
        frmCompany.btnComCancel.Enabled = True
        frmCompany.btnComSave.Enabled = True
        frmCompany.btnComSave.Visible = True
    End Sub

    Public Shared Sub ComCancelOrSave()

        frmCompany.txtComCode.Text = ""
        frmCompany.txtComNo.Text = ""
        frmCompany.btnComStatus.Text = ""
        frmCompany.txtComDesc.Text = ""
        frmCompany.txtComURL.Text = ""
        frmCompany.txtComAddr.Text = ""
        frmCompany.txtComTIN.Text = ""
        frmCompany.txtComEmail.Text = ""
        frmCompany.lblComBtn.Text = "---"
        frmCompany.btnComAdd.Text = "ADD"

        frmCompany.btnComCancel.Enabled = False
        frmCompany.btnComAdd.Enabled = True
        frmCompany.btnComAdd.Visible = True
        frmCompany.btnComSave.Enabled = False
        frmCompany.btnComSave.Visible = False
        frmCompany.panelCom.Enabled = False

    End Sub
End Class

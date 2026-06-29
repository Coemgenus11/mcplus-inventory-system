Public Class frmInit

    Private Sub cmdTestLServer_Click(sender As Object, e As EventArgs) Handles cmdTestLServer.Click
        check_db(txtLServerIP.Text.ToString, txtLAuditDB.Text.ToString, txtLInventoryDB.Text.ToString, txtLSalesDB.Text.ToString, txtLServerUname.Text.ToString, txtLServerPass.Text.ToString)
    End Sub
    Private Sub cmdTestCServer_Click(sender As Object, e As EventArgs) Handles cmdTestCServer.Click
        check_db(txtServerIP.Text.ToString, txtCAuditDB.Text.ToString, txtCInventoryDB.Text.ToString, txtCSalesDB.Text.ToString, txtServerUname.Text.ToString, txtServerPass.Text.ToString)
    End Sub

    Private Sub cmdApplyLServer_Click(sender As Object, e As EventArgs) Handles cmdApplyLServer.Click

        If check_db(txtLServerIP.Text.ToString, txtLAuditDB.Text.ToString, txtLInventoryDB.Text.ToString, txtLSalesDB.Text.ToString, txtLServerUname.Text.ToString, txtLServerPass.Text.ToString) Then

            My.Settings.LocalserverIP = txtLServerIP.Text
            My.Settings.LocalUserName = txtLServerUname.Text
            My.Settings.LocalPassword = EncryptString(txtLServerPass.Text)
            My.Settings.LocalAuditDB = txtLAuditDB.Text
            My.Settings.LocalInventoryDB = txtLInventoryDB.Text
            My.Settings.LocalSalesDB = txtLSalesDB.Text
            My.Settings.Save()

            'SettingClass.show_settings()
            'CompanyClass.show_company()
            ''ItemClass.show_items()

            txtLServerIP.BackColor = Color.White
            txtLServerUname.BackColor = Color.White
            txtLServerPass.BackColor = Color.White
            txtLAuditDB.BackColor = Color.White
            txtLInventoryDB.BackColor = Color.White
            txtLSalesDB.BackColor = Color.White

        Else
            txtLServerIP.BackColor = Color.LightCoral
            txtLServerUname.BackColor = Color.LightCoral
            txtLServerPass.BackColor = Color.LightCoral
            txtLAuditDB.BackColor = Color.LightCoral
            txtLInventoryDB.BackColor = Color.LightCoral
            txtLSalesDB.BackColor = Color.LightCoral

        End If

    End Sub

    Private Sub cmdApplyCServer_Click(sender As Object, e As EventArgs) Handles cmdApplyCServer.Click

        If check_db(txtServerIP.Text.ToString, txtCAuditDB.Text.ToString, txtCInventoryDB.Text.ToString, txtCSalesDB.Text.ToString, txtServerUname.Text.ToString, txtServerPass.Text.ToString) Then

            My.Settings.centralserverIP = txtServerIP.Text
            My.Settings.centralUserName = txtServerUname.Text
            My.Settings.centralPassword = EncryptString(txtServerPass.Text)
            My.Settings.centralAuditDB = txtCAuditDB.Text
            My.Settings.CentralInventoryDB = txtCInventoryDB.Text
            My.Settings.centralSalesDB = txtCSalesDB.Text
            My.Settings.Save()

            'SettingClass.show_settings()
            'CompanyClass.show_company()
            ''ItemClass.show_items()

            txtServerIP.BackColor = Color.White
            txtServerUname.BackColor = Color.White
            txtServerPass.BackColor = Color.White
            txtCAuditDB.BackColor = Color.White
            txtCInventoryDB.BackColor = Color.White
            txtCSalesDB.BackColor = Color.White

            btnGotoLogin.Enabled = True

        Else
            txtServerIP.BackColor = Color.LightCoral
            txtServerUname.BackColor = Color.LightCoral
            txtServerPass.BackColor = Color.LightCoral
            txtCAuditDB.BackColor = Color.LightCoral
            txtCInventoryDB.BackColor = Color.LightCoral
            txtCSalesDB.BackColor = Color.LightCoral

        End If
    End Sub

    Private Sub btnGotoLogin_Click(sender As Object, e As EventArgs) Handles btnGotoLogin.Click
        Dim loginForm As New frmLogin()
        loginForm.Show()
        Me.Close()
    End Sub


End Class
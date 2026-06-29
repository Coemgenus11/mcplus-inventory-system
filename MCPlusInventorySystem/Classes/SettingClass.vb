Public Class SettingClass

    Private Shared fActive As String = "view"
    Public Shared Sub show_settings()
        frmMain.txtLServerIP.Text = My.Settings.LocalserverIP
        frmMain.txtLServerUname.Text = My.Settings.LocalUserName
        frmMain.txtLServerPass.Text = DecryptString(My.Settings.LocalPassword)
        frmMain.txtLServerDB.Text = My.Settings.LocalDatabase

        frmMain.txtServerIP.Text = My.Settings.centralserverIP
        frmMain.txtServerUname.Text = My.Settings.centralUserName
        frmMain.txtServerPass.Text = DecryptString(My.Settings.centralPassword)
        frmMain.txtServerDB.Text = My.Settings.centralDatabase
    End Sub

    Public Shared Sub enable_obj()
        frmMain.pbComBanner.Enabled = True
        frmMain.cbComStatus.Enabled = True
        frmMain.txtComCode.Enabled = True
        frmMain.txtComDesc.Enabled = True
        frmMain.txtComAddr.Enabled = True
        frmMain.txtComTIN.Enabled = True
        frmMain.txtComEmail.Enabled = True
        frmMain.txtComNo.Enabled = True
        frmMain.txtComNo.Enabled = True
        frmMain.cmdSave.Enabled = True
    End Sub

    Public Shared Sub disable_obj()
        frmMain.pbComBanner.Enabled = False
        frmMain.cbComStatus.Enabled = False
        frmMain.txtComCode.Enabled = False
        frmMain.txtComDesc.Enabled = False
        frmMain.txtComAddr.Enabled = False
        frmMain.txtComTIN.Enabled = False
        frmMain.txtComEmail.Enabled = False
        frmMain.txtComNo.Enabled = False
        frmMain.txtComNo.Enabled = False
        frmMain.cmdSave.Enabled = False
    End Sub

    Public Shared Sub add_com_on()
        frmMain.cmdComAdd.Text = "Cancel"
        enable_obj()
        frmMain.cbComStatus.Checked = True
        frmMain.lblOption.Text = "Add Company"
        frmMain.cmdComEdit.Text = "Edit"
        frmMain.txtComCode.Text = ""
        frmMain.txtComDesc.Text = ""
        frmMain.txtComAddr.Text = ""
        frmMain.txtComTIN.Text = ""
        frmMain.txtComNo.Text = ""
        frmMain.pbComBanner.Image = Nothing
    End Sub
    Public Shared Sub add_com_off()
        frmMain.cmdComAdd.Text = "Add"
        disable_obj()
        frmMain.lblOption.Text = "View Only"
    End Sub

    Public Shared Sub edit_user_on()
        frmMain.cmdComEdit.Text = "Cancel"
        frmMain.cmdComAdd.Text = "Add"
        enable_obj()
        frmMain.lblOption.Text = "Edit Company"
        fActive = "edit"
    End Sub
    Public Shared Sub edit_user_off()
        frmMain.cmdComEdit.Text = "Edit"
        disable_obj()
        frmMain.lblOption.Text = "View Only"
        fActive = "view"
    End Sub
End Class

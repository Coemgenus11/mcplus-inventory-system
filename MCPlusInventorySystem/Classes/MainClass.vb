Imports System.Net.NetworkInformation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives

Public Class MainClass

    'CONNECTION STATUS
    Public Shared isNotConnected As Boolean = False

    Public Shared Sub RefreshUserTab()
        Dim userLoginComp As String
        userLoginComp = get_user_comp(My.Settings.CurrentUserID)

        frmMain.cmdDashboard.Visible = False
        frmMain.cmdStocks.Visible = False
        frmMain.cmdItems.Visible = False
        frmMain.cmdAccounts.Visible = False
        frmMain.cmdLogout.Visible = False
        frmMain.cmdSettings.Visible = False

        frmMain.tcMain.TabPages.Remove(frmMain.tabDashboard)
        frmMain.tcMain.TabPages.Remove(frmMain.tabStocks)
        frmMain.tcMain.TabPages.Remove(frmMain.tabItems)
        frmMain.tcMain.TabPages.Remove(frmMain.tabApproval)
        frmMain.tcMain.TabPages.Remove(frmMain.tabAccounts)
        frmMain.tcMain.TabPages.Remove(frmMain.tabItemPrice)
        frmMain.tcMain.TabPages.Remove(frmMain.tabSettings)

        frmMain.lblStore.Text = "STORE : " + My.Settings.Store
        frmMain.lblUser.Text = "User : " + get_user_fullname(My.Settings.CurrentUserID) & " 👤"
        frmMain.lblDashWelcome.Text = "WELCOME, " + get_user_fullname(My.Settings.CurrentUserID) + "!"
        frmMain.lblDashTotalItemStock.Text = getItemTotalStocks(userLoginComp, My.Settings.Store)
        frmMain.lblDashTotalItem.Text = getTotalItems(userLoginComp)
        frmMain.lblDashToReceivePO.Text = getToReceivedPOCount(userLoginComp, My.Settings.Store)
        frmMain.lblDashForTransferIN.Text = getToReceivedTransfer(userLoginComp, My.Settings.Store)
        frmMain.lblDashForTransferOutApproval.Text = getForApprovalTransferToOtherStore(userLoginComp, My.Settings.Store)
        DashboardClass.show_fast_moving()

    End Sub

    Public Shared Sub UserADM()
        'Module for Admin
        frmMain.cmdDashboard.Visible = True
        frmMain.cmdStocks.Visible = True
        frmMain.cmdItems.Visible = True
        frmMain.cmdAccounts.Visible = True
        frmMain.cmdLogout.Visible = True
        frmMain.cmdSettings.Visible = True

        frmMain.tcMain.TabPages.Add(frmMain.tabDashboard)
        frmMain.tcMain.TabPages.Add(frmMain.tabItems)
        frmMain.tcMain.TabPages.Add(frmMain.tabStocks)
        frmMain.tcMain.TabPages.Add(frmMain.tabItemPrice)
        frmMain.tcMain.TabPages.Add(frmMain.tabApproval)
        frmMain.tcMain.TabPages.Add(frmMain.tabAccounts)
        frmMain.tcMain.TabPages.Add(frmMain.tabSettings)
    End Sub

    Public Shared Sub UserSTK()
        'Only Modules for Stock Clerk
        frmMain.cmdDashboard.Visible = True
        frmMain.cmdStocks.Visible = True
        frmMain.cmdItems.Visible = True
        'frmMain.cmdReports.Visible = True
        'frmMain.cmdAccounts.Visible = True
        frmMain.cmdLogout.Visible = True
        'frmMain.cmdSettings.Visible = True

        frmMain.tcMain.TabPages.Add(frmMain.tabDashboard)
        frmMain.tcMain.TabPages.Add(frmMain.tabItems)
        frmMain.tcMain.TabPages.Add(frmMain.tabStocks)
        'frmMain.tcMain.TabPages.Add(frmMain.tabReports)
        'frmMain.tcMain.TabPages.Add(frmMain.tabAccounts)
        frmMain.tcMain.TabPages.Add(frmMain.tabItemPrice)
        'frmMain.tcMain.TabPages.Add(frmMain.tabSettings)
    End Sub

    Public Shared Sub UserRPT()
        'Module for Admin
        frmMain.cmdDashboard.Visible = True
        'frmMain.cmdStocks.Visible = True
        'frmMain.cmdItems.Visible = True
        'frmMain.cmdAccounts.Visible = True
        frmMain.cmdLogout.Visible = True
        'frmMain.cmdSettings.Visible = True

        frmMain.tcMain.TabPages.Add(frmMain.tabDashboard)
        'frmMain.tcMain.TabPages.Add(frmMain.tabItems)
        'frmMain.tcMain.TabPages.Add(frmMain.tabStocks)
        'frmMain.tcMain.TabPages.Add(frmMain.tabItemPrice)
        frmMain.tcMain.TabPages.Add(frmMain.tabApproval)
        'frmMain.tcMain.TabPages.Add(frmMain.tabAccounts)
        'frmMain.tcMain.TabPages.Add(frmMain.tabSettings)
    End Sub
    Public Shared Sub UserOPE()
        frmMain.cmdDashboard.Visible = False
        frmMain.cmdStocks.Visible = False
        frmMain.cmdItems.Visible = False
        frmMain.cmdAccounts.Visible = False
        'frmMain.cmdSettings.Visible = False

        frmMain.tcMain.TabPages.Remove(frmMain.tabDashboard)
        frmMain.tcMain.TabPages.Remove(frmMain.tabStocks)
        frmMain.tcMain.TabPages.Remove(frmMain.tabItems)
        frmMain.tcMain.TabPages.Remove(frmMain.tabAccounts)
        'frmMain.tcMain.TabPages.Remove(frmMain.tabSettings)
    End Sub

    'Public Shared Sub UserCAS()
    '    frmMain.cmdDashboard.Visible = False
    '    frmMain.cmdStocks.Visible = False
    '    frmMain.cmdItems.Visible = False
    '    frmMain.cmdReports.Visible = False
    '    frmMain.cmdAccounts.Visible = False
    '    frmMain.cmdSettings.Visible = False

    '    frmMain.tcMain.TabPages.Remove(frmMain.tabDashboard)
    '    frmMain.tcMain.TabPages.Remove(frmMain.tabStocks)
    '    frmMain.tcMain.TabPages.Remove(frmMain.tabItems)
    '    frmMain.tcMain.TabPages.Remove(frmMain.tabReports)
    '    frmMain.tcMain.TabPages.Remove(frmMain.tabAccounts)
    '    frmMain.tcMain.TabPages.Remove(frmMain.tabSettings)
    'End Sub
End Class


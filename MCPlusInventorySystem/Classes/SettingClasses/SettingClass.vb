Public Class SettingClass
    Public Shared cachedCompanyList As DataTable = Nothing
    Public Shared cachedStoreList As DataTable = Nothing
    Public Shared Sub show_settings()
        frmMain.txtLServerIP.Text = My.Settings.LocalserverIP
        frmMain.txtLServerUname.Text = My.Settings.LocalUserName
        frmMain.txtLServerPass.Text = DecryptString(My.Settings.LocalPassword)
        frmMain.txtLAuditDB.Text = My.Settings.LocalAuditDB
        frmMain.txtLInventoryDB.Text = My.Settings.LocalInventoryDB
        frmMain.txtLSalesDB.Text = My.Settings.LocalSalesDB

        frmMain.txtServerIP.Text = My.Settings.centralserverIP
        frmMain.txtServerUname.Text = My.Settings.centralUserName
        frmMain.txtServerPass.Text = DecryptString(My.Settings.centralPassword)
        frmMain.txtCAuditDB.Text = My.Settings.centralAuditDB
        frmMain.txtCInventoryDB.Text = My.Settings.CentralInventoryDB
        frmMain.txtCSalesDB.Text = My.Settings.centralSalesDB

        LoadCBStore()
    End Sub

    Public Shared Sub load_CompanyList(Optional forceRefresh As Boolean = False)
        ' Kung walang cache or pinilit mag-refresh → query ulit
        If cachedCompanyList Is Nothing OrElse forceRefresh Then
            cachedCompanyList = get_company(get_user_comp(My.Settings.CurrentUserID))
        End If
    End Sub
    Public Shared Sub load_StoreList(Optional forceRefresh As Boolean = False)
        ' Kung walang cache or pinilit mag-refresh → query ulit
        If cachedStoreList Is Nothing OrElse forceRefresh Then
            cachedStoreList = get_store(get_user_comp(My.Settings.CurrentUserID))
        End If
    End Sub


    Public Shared Sub LoadCBStore()
        Try
            Dim table As DataTable = get_store(get_user_comp(My.Settings.CurrentUserID))
            frmMain.cbStore.Items.Clear()
            frmMain.cbStore.Items.Add("")

            For Each row As DataRow In table.Rows
                Dim storeCode As String = row("store_code").ToString()
                frmMain.cbStore.Items.Add(storeCode)
            Next

            If frmMain.cbStore.Items.Contains(My.Settings.Store) Then
                frmMain.cbStore.Text = My.Settings.Store
                frmMain.btnApplyStore.Enabled = False
            ElseIf frmMain.cbStore.Items.Count > 0 Then
                frmMain.cbStore.SelectedIndex = 0
            End If

        Catch ex As Exception
            MsgBox("Error loading Store: " & ex.Message)
        End Try
    End Sub

End Class

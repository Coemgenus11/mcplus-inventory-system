Public Class RefreshClass

    Public Shared Sub RefreshAll()
        SKUClass.cachedItems = Nothing
        ItemPriceClass.cachedItemPrices = Nothing
        ItemListClass.cachedItemList = Nothing
        CollectionClass.cachedCollections = Nothing
        ColorClass.cachedColors = Nothing
        GenderClass.cachedGenders = Nothing
        StyleCategoryClass.cachedWearType = Nothing
        StyleCategoryClass.cachedTypes = Nothing
        StyleCategoryClass.cachedStyleCat = Nothing
        StyleCategoryClass.cachedStyleVar = Nothing
        SKUCreationClass.cachedParentSKU = Nothing
        SKUCreationClass.cachedVariant = Nothing

        StockClass.cachedItemBalance = Nothing
        frmMain.dgStockItemBal.Rows.Clear()

        StockClass.cachedSuppliers = Nothing
        StockClass.cachedStockInHeader = Nothing
        StockClass.cachedStockInLines = Nothing
        StockClass.cachedTransferOutHeader = Nothing
        StockClass.cachedTransferOutLine = Nothing
        StockClass.cachedTransferInHeader = Nothing
        StockClass.cachedTransferInLine = Nothing
        StockClass.cachedPOHeader = Nothing
        StockClass.cachedPOLine = Nothing
        StockClass.cachedPOReceivingHeaders = Nothing
        StockClass.cachedPOReceivingLine = Nothing
        TransactionClass.cachedItemTransactions = Nothing
        AccountClass.cachedUsers = Nothing

        Dim userLoginComp As String
        userLoginComp = get_user_comp(My.Settings.CurrentUserID)

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

    Public Shared Sub RefreshTimer()
        'Products Tab ------------------------
        CollectionClass.cachedCollections = Nothing
        ColorClass.cachedColors = Nothing
        GenderClass.cachedGenders = Nothing

        StyleCategoryClass.cachedWearType = Nothing
        StyleCategoryClass.cachedTypes = Nothing
        StyleCategoryClass.cachedStyleCat = Nothing
        StyleCategoryClass.cachedStyleVar = Nothing

        SKUCreationClass.cachedParentSKU = Nothing
        SKUCreationClass.cachedVariant = Nothing

        SKUClass.cachedItems = Nothing

        TransactionClass.cachedItemTransactions = Nothing


        'Stock Tab ----------------

        StockClass.show_ItemBalanceList(True)
        StockClass.cachedSuppliers = Nothing
        StockClass.cachedStockInHeader = Nothing
        StockClass.cachedStockInLines = Nothing
        StockClass.cachedTransferOutHeader = Nothing
        StockClass.cachedTransferOutLine = Nothing
        StockClass.cachedTransferInHeader = Nothing
        StockClass.cachedTransferInLine = Nothing
        StockClass.cachedPOHeader = Nothing
        StockClass.cachedPOLine = Nothing
        StockClass.cachedPOReceivingHeaders = Nothing
        StockClass.cachedPOReceivingLine = Nothing

        'Price Tab -----------
        ItemPriceClass.cachedItemPrices = Nothing
        SettingClass.load_CompanyList(True)
        SettingClass.load_StoreList(True)


        Dim userLoginComp As String
        userLoginComp = get_user_comp(My.Settings.CurrentUserID)

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
End Class

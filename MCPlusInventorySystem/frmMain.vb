Imports System.Globalization
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls.Primitives
Imports MCPlusInventorySystem.My
Imports Mysqlx.XDevAPI.Relational
Imports Org.BouncyCastle.Asn1.Cmp
Imports Org.BouncyCastle.Asn1.Pkcs

Public Class frmMain
    'Settings Module
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.centralAuditDB IsNot "" Then
            SettingClass.show_settings()
            CompanyClass.show_company()

            SettingClass.load_CompanyList()
            SettingClass.load_StoreList()

        End If
    End Sub

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

            txtLServerIP.BackColor = Color.White
            txtLServerUname.BackColor = Color.White
            txtLServerPass.BackColor = Color.White
            txtLAuditDB.BackColor = Color.White
            txtLInventoryDB.BackColor = Color.White
            txtLSalesDB.BackColor = Color.White

            CompanyClass.show_company()
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

            txtServerIP.BackColor = Color.White
            txtServerUname.BackColor = Color.White
            txtServerPass.BackColor = Color.White
            txtCAuditDB.BackColor = Color.White
            txtCInventoryDB.BackColor = Color.White
            txtCSalesDB.BackColor = Color.White

            CompanyClass.show_company()

            'refresh all cached
            RefreshClass.RefreshAll()
        Else
            txtServerIP.BackColor = Color.LightCoral
            txtServerUname.BackColor = Color.LightCoral
            txtServerPass.BackColor = Color.LightCoral
            txtCAuditDB.BackColor = Color.LightCoral
            txtCInventoryDB.BackColor = Color.LightCoral
            txtCSalesDB.BackColor = Color.LightCoral

        End If
    End Sub

    'Company
    Private Sub btnViewCompFrm_Click(sender As Object, e As EventArgs) Handles btnViewCompFrm.Click
        CompanyClass.show_company()
        frmCompany.Show()
    End Sub

    Private Sub btnUsersview_Click(sender As Object, e As EventArgs) Handles btnUsersview.Click
        Dim userLoginComp = get_user_comp(My.Settings.CurrentUserID)
        Dim compDesc = get_company_desc(userLoginComp)

        Me.Cursor = Cursors.WaitCursor
        Try
            AccountClass.LoadCBAuth()
            frmUserInfo.txtCompDesc.Text = compDesc
            frmUserInfo.lblCompanyCode.Text = userLoginComp
            frmAudit.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub btnAuthView_Click(sender As Object, e As EventArgs) Handles btnAuthView.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            frmAudit.tcAudit.SelectedTab = frmAudit.tabAuth
            frmAudit.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdDashboard_Click(sender As Object, e As EventArgs) Handles cmdDashboard.Click
        tcMain.SelectedTab = tabDashboard
    End Sub
    Private Sub cmdStocks_Click(sender As Object, e As EventArgs) Handles cmdStocks.Click
        tcMain.SelectedTab = tabStocks
    End Sub
    Private Sub cmdItems_Click(sender As Object, e As EventArgs) Handles cmdItems.Click
        tcMain.SelectedTab = tabItems
    End Sub
    Private Sub cmdAccounts_Click(sender As Object, e As EventArgs) Handles cmdAccounts.Click
        tcMain.SelectedTab = tabAccounts
    End Sub

    Private Sub cmdSettings_Click(sender As Object, e As EventArgs) Handles cmdSettings.Click
        tcMain.SelectedTab = tabSettings
    End Sub

    Private Sub btnSKUView_Click(sender As Object, e As EventArgs) Handles btnSKUView.Click

        Me.Cursor = Cursors.WaitCursor
        Try
            SKUClass.show_ItemSKU()
            frmItem.tcItemModule.SelectedTab = frmItem.tpSKU
            frmItem.ShowDialog()

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdLogout_Click(sender As Object, e As EventArgs) Handles cmdLogout.Click
        If MsgBox("Are you sure you want to logout?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm Logout") = MsgBoxResult.Yes Then

            'My.Settings.LocalserverIP = ""
            'My.Settings.LocalAuditDB = ""
            'My.Settings.LocalInventoryDB = ""
            'My.Settings.LocalPassword = ""
            'My.Settings.LocalUserName = ""

            'My.Settings.centralserverIP = ""
            'My.Settings.centralAuditDB = ""
            'My.Settings.CentralInventoryDB = ""
            'My.Settings.centralPassword = ""
            'My.Settings.centralUserName = ""

            My.Settings.CurrentUserID = ""
            My.Settings.LoggedIn = False
            My.Settings.Save()
            frmLogin.chkRememberMe.Checked = False
            ' Show frmLogin again
            Dim loginForm As New frmLogin()
            loginForm.Show()
            Me.Close()
        End If
    End Sub

    'STOCK MODULE 
    Private Sub dgRecentStockIN_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgRecentStockIN.CellMouseMove
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim columnName As String = dgRecentStockIN.Columns(e.ColumnIndex).Name

            If columnName = "recent_view" Then
                Me.Cursor = Cursors.Hand
            Else
                Me.Cursor = Cursors.Default
            End If
        Else
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub dgRecentStockIN_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgRecentStockIN.CellMouseLeave
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgRecentStockIN.Columns(e.ColumnIndex).Name
            If columnName = "recent_view" Then
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmAddStock.ShowDialog()
    End Sub

    Private Sub txtStockSearch_TextChanged(sender As Object, e As EventArgs) Handles txtStockSearch.TextChanged
        StockClass.itemBalanceSearch(txtStockSearch.Text)
    End Sub
    Private Sub dgRecentStockIN_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgRecentStockIN.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgRecentStockIN.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgRecentStockIN.Rows(e.RowIndex)

            ' Get existing values
            Dim inputComp As String = selectedRow.Cells("mph_companycode").Value.ToString()
            Dim mpurchaseID As String = selectedRow.Cells("mph_id").Value.ToString()
            Dim storeCode As String = selectedRow.Cells("mph_store_code").Value.ToString()

            If columnName = "mph_view" Then
                StockClass.show_mpl_stockin(inputComp, mpurchaseID, storeCode)
                frmStockInData.ShowDialog()
            End If
        End If
    End Sub

    Private Sub dgRecentTransfer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgRecentTransfer.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgRecentTransfer.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgRecentTransfer.Rows(e.RowIndex)
            Dim inputComp As String = selectedRow.Cells("th_companycode").Value.ToString()
            Dim dr As String = selectedRow.Cells("th_dr").Value.ToString()
            Dim storeCode As String = selectedRow.Cells("th_storecode_orig").Value.ToString()
            Dim storeCodeDest As String = selectedRow.Cells("th_storecode_dest").Value.ToString()
            Dim statusCode As String = selectedRow.Cells("th_statuscode").Value.ToString()

            If columnName = "th_view" Then

                StockClass.show_transfer_h()
                StockClass.show_transfer_l(inputComp, dr, storeCode, storeCodeDest, "out")
                frmTransferData.selectedTransferHStatus = statusCode
                frmTransferData.ShowDialog()
            End If
        End If
    End Sub

    Private Sub dateStockFrom_ValueChanged(sender As Object, e As EventArgs) Handles dateStockFrom.ValueChanged
        StockClass.FilterDataGridViewByDate(Me.dgRecentStockIN, Me.dateStockFrom.Value.Date, Me.dateStockTo.Value.Date)
    End Sub

    Private Sub dateStockTo_ValueChanged(sender As Object, e As EventArgs) Handles dateStockTo.ValueChanged
        StockClass.FilterDataGridViewByDate(Me.dgRecentStockIN, Me.dateStockFrom.Value.Date, Me.dateStockTo.Value.Date)
    End Sub

    'MAIN TAB CONTROL
    Private Sub tcMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcMain.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor

        Try
            If MainClass.isNotConnected Then
                MsgBox("Please check your connection first.", MsgBoxStyle.Critical)
                Exit Sub
            Else
                If tcMain.SelectedTab.Name = "tabStocks" Then
                    StockClass.show_ItemBalanceList()
                    StockClass.show_Suppliers()
                    StockClass.show_recent_stockin()
                    StockClass.show_transfer_h()
                    StockClass.show_transfer_h_dest()
                    StockClass.show_po_h()
                End If
                If tcMain.SelectedTab.Name = "tabItems" Then

                    SKUClass.show_ItemSKU()
                    CollectionClass.show_collection()
                    ColorClass.show_colors()
                    GenderClass.show_genders()
                    TransactionClass.show_ItemTransactions()
                    TransactionClass.load_ItemTransactions_To_frmItem()
                    StyleCategoryClass.show_types()
                    StyleCategoryClass.show_weartype()
                    StyleCategoryClass.show_stylecat()
                    SKUCreationClass.show_parentSKU()
                    SKUCreationClass.LoadCBGender()
                    SKUCreationClass.LoadCBColor()
                    SKUCreationClass.LoadCBCollection()
                    SKUCreationClass.LoadCBTypes()
                End If
                If tcMain.SelectedTab.Name = "tabItemPrice" Then
                    ItemPriceClass.show_ItemPrice()
                End If
                If tcMain.SelectedTab.Name = "tabApproval" Then
                    StockClass.show_transfer_h()
                End If
                If tcMain.SelectedTab.Name = "tabAccounts" Then
                    AccountClass.show_accounts()
                    AccountClass.show_auth()
                End If
                If tcMain.SelectedTab.Name = "tabSettings" Then
                    SettingClass.show_settings()
                End If
            End If

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Try
            If TabControl1.SelectedTab.Name = "tabMP" Then
                StockClass.show_recent_stockin()
            End If
            If TabControl1.SelectedTab.Name = "tabPO" Then
                StockClass.show_po_h()
            End If
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    'EXECUTE EVENT 
    Private Sub btnItemEvent_Click(sender As Object, e As EventArgs) Handles btnItemEvent.Click
        ' Ask for confirmation before proceeding
        Dim result As DialogResult = MessageBox.Show("Do you want to generate and insert items that do not yet exist in the item table now?", "Confirm Insert", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            If InsertNotExistingItems() Then
                RefreshClass.RefreshAll()
                MsgBox("Items successfully inserted.", MsgBoxStyle.Information, "Success")
            Else
                MsgBox("No items were inserted or operation was cancelled.", MsgBoxStyle.Exclamation, "Notice")
            End If

        End If
    End Sub

    Private Sub btnItemBalEvent_Click(sender As Object, e As EventArgs) Handles btnItemBalEvent.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to generate and insert items that do not yet exist in the item balance table now?", "Confirm Insert", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            If InsertNotExistingItemBal() Then
                RefreshClass.RefreshAll()
                MsgBox("Items successfully inserted.", MsgBoxStyle.Information, "Success")
            Else
                MsgBox("No items were inserted or operation was cancelled.", MsgBoxStyle.Exclamation, "Notice")
            End If

        End If
    End Sub

    Private Sub btnItemPriceEvent_Click(sender As Object, e As EventArgs) Handles btnItemPriceEvent.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to generate and insert items that do not yet exist in the item price table now?", "Confirm Insert", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If InsertNotExistingItemPrice() Then
                RefreshClass.RefreshAll()
                MsgBox("Items successfully inserted.", MsgBoxStyle.Information, "Success")
            Else
                MsgBox("No items were inserted or operation was cancelled.", MsgBoxStyle.Exclamation, "Notice")
            End If
        End If
    End Sub

    'PRICE MODULE
    Private Sub dgPrice_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPrice.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgPrice.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgPrice.Rows(e.RowIndex)

            Dim skuCode As String = selectedRow.Cells("price_skucode").Value.ToString()
            Dim item As String = selectedRow.Cells("price_desc").Value.ToString()
            Dim color As String = selectedRow.Cells("price_color").Value.ToString()
            Dim var As String = selectedRow.Cells("price_variant").Value.ToString()
            Dim unitPrice As String = selectedRow.Cells("price_unit").Value.ToString()
            Dim retailPrice As String = selectedRow.Cells("price_retail").Value.ToString()

            If columnName = "price_edit" Then
                frmPriceUpdate.lblPriceSku.Text = skuCode
                frmPriceUpdate.txtProductDesc.Text = item
                frmPriceUpdate.lblLocColor.Text = color
                frmPriceUpdate.lblLocVar.Text = var
                frmPriceUpdate.txtPriceUnit.Text = unitPrice
                frmPriceUpdate.txtPriceRetail.Text = retailPrice

                frmPriceUpdate.ShowDialog()

            End If
        End If
    End Sub

    Private Sub txtPriceSearch_TextChanged(sender As Object, e As EventArgs) Handles txtPriceSearch.TextChanged
        ItemPriceClass.itemPriceSearch(txtPriceSearch.Text)
    End Sub

    Private Sub cbStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbStore.SelectedIndexChanged
        btnApplyStore.Enabled = True
    End Sub

    Private Sub btnApplyStore_Click(sender As Object, e As EventArgs) Handles btnApplyStore.Click
        If MsgBox("Are you sure you want to apply changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Apply Store") = MsgBoxResult.Yes Then
            My.Settings.Store = cbStore.Text
            btnApplyStore.Enabled = False
            RefreshClass.RefreshAll()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        frmSupplier.ShowDialog()
    End Sub

    'CONNECTION STATUS
    Private Sub timeMain_Tick(sender As Object, e As EventArgs) Handles timeMain.Tick
        Dim isNowConnected As Boolean = isConnectedToServer(My.Settings.centralserverIP)

        If isNowConnected Then
            MainClass.isNotConnected = False
            lblConnectionStatus.Text = "Connected"
            lblConnectionStatus.ForeColor = Color.Green
            picConnTrue.Visible = True
            picConnFalse.Visible = False
            tcMain.Enabled = True
        Else
            If Not MainClass.isNotConnected Then
                MainClass.isNotConnected = True
                lblConnectionStatus.Text = "Disconnected"
                lblConnectionStatus.ForeColor = Color.DarkGray
                tcMain.Enabled = False
                picConnTrue.Visible = False
                picConnFalse.Visible = True
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frmStockOut.isApprovalModule = False
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransferItem)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransferAll)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer10)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer0)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer1)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer2)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer3)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransferPartialReceived)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer4)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer9)
        frmStockOut.ShowDialog()
    End Sub




    'Approval Tab ============================================
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmStockOut.isApprovalModule = True
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransferItem)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransferAll)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer10)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer0)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer1)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer2)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer3)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransferPartialReceived)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer4)
        frmStockOut.tcStockOut.TabPages.Remove(frmStockOut.tabTransfer9)
        frmStockOut.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmTransferIn.ShowDialog()
    End Sub

    Private Sub dgTransferIn_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTransferIn.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgTransferIn.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgTransferIn.Rows(e.RowIndex)
            Dim inputComp As String = selectedRow.Cells("ti_companycode").Value.ToString()
            Dim dr As String = selectedRow.Cells("ti_dr").Value.ToString()
            Dim storeCode As String = selectedRow.Cells("ti_storecode_orig").Value.ToString()
            Dim storeCodeDest As String = selectedRow.Cells("ti_storecode_dest").Value.ToString()
            Dim statusCode As String = selectedRow.Cells("ti_statuscode").Value.ToString()

            If columnName = "ti_view" Then
                StockClass.show_transfer_h_dest()
                StockClass.show_transfer_l(inputComp, dr, storeCode, storeCodeDest, "in")
                frmTransferInData.selectedTransferHStatus = statusCode
                frmTransferInData.ShowDialog()
            End If
        End If
    End Sub

    Private Sub dgTransferApprTab_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTransferApprTab.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgTransferApprTab.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgTransferApprTab.Rows(e.RowIndex)
            Dim inputComp As String = selectedRow.Cells("th_appr_companycode").Value.ToString()
            Dim dr As String = selectedRow.Cells("th_appr_dr").Value.ToString()
            Dim storeCode As String = selectedRow.Cells("th_appr_storecode_orig").Value.ToString()
            Dim storeCodeDest As String = selectedRow.Cells("th_appr_storecode_dest").Value.ToString()
            Dim statusCode As String = selectedRow.Cells("th_appr_statuscode").Value.ToString()

            If columnName = "th_appr_view" Then
                StockClass.show_transfer_l(inputComp, dr, storeCode, storeCodeDest, "out")
                frmTransferData.selectedTransferHStatus = statusCode
                frmTransferData.ShowDialog()
            End If
        End If
    End Sub


    Private Sub dgSupplier_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSupplier.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgSupplier.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgSupplier.Rows(e.RowIndex)
            Dim compCode As String = selectedRow.Cells("sup_comp_code").Value.ToString()
            Dim supCode As String = selectedRow.Cells("sup_code").Value.ToString()
            Dim supDesc As String = selectedRow.Cells("sup_supplier_desc").Value.ToString()
            Dim supTIN As String = selectedRow.Cells("sup_tin").Value.ToString()
            Dim supAddr As String = selectedRow.Cells("sup_addr").Value.ToString()
            Dim supContact As String = selectedRow.Cells("sup_contact").Value.ToString()
            Dim supEmail As String = selectedRow.Cells("sup_email").Value.ToString()
            Dim supPTerms As String = selectedRow.Cells("sup_pterms").Value.ToString()

            If columnName = "sup_view" Then

                frmSupplier.txtSupDesc.Text = supDesc
                frmSupplier.txtSupCode.Text = supCode
                frmSupplier.txtSupCode.Enabled = False
                frmSupplier.txtSupTIN.Text = supTIN
                frmSupplier.txtSupAddr.Text = supAddr
                frmSupplier.txtSupContact.Text = supContact
                frmSupplier.txtSupEmail.Text = supEmail
                frmSupplier.txtPaymentTerms.Text = supPTerms
                frmSupplier.btnSupAdd.Text = "Update"
                frmSupplier.ShowDialog()
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        StockClass.show_po_h()
        frmPurchaseOrder.ShowDialog()
    End Sub

    Private Sub dgPO_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPO.CellClick
        If e.RowIndex >= 0 Then
            Dim dgView As DataGridView = CType(sender, DataGridView)
            Dim columnName As String = dgView.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgView.Rows(e.RowIndex)

            Dim inputComp As String = selectedRow.Cells(0).Value.ToString()
            Dim storeCode As String = selectedRow.Cells(1).Value.ToString()
            Dim poNum As String = selectedRow.Cells(4).Value.ToString()

            If columnName = $"po_view" Then
                StockClass.show_po_h()
                StockClass.show_po_l(poNum)
                frmPurchaseOrderItems.ShowDialog()
            End If
        End If
    End Sub

    Private Sub GroupBox7_Enter(sender As Object, e As EventArgs) Handles GroupBox7.Enter

    End Sub

    Private Sub txtLServerPass_TextChanged(sender As Object, e As EventArgs) Handles txtLServerPass.TextChanged
        txtLServerPass.UseSystemPasswordChar = True
    End Sub

    Private Sub txtServerPass_TextChanged(sender As Object, e As EventArgs) Handles txtServerPass.TextChanged
        txtServerPass.UseSystemPasswordChar = True
    End Sub

    Private Sub refreshData_Tick(sender As Object, e As EventArgs) Handles refreshData.Tick
        Dim isNowConnected As Boolean = isConnectedToServer(My.Settings.centralserverIP)

        If isNowConnected Then
            RefreshClass.RefreshTimer()
            'Else
            '    If Not MainClass.isNotConnected Then
            '        MainClass.isNotConnected = True
            '        lblConnectionStatus.Text = "Disconnected"
            '        lblConnectionStatus.ForeColor = Color.DarkGray
            '        tcMain.Enabled = False
            '        picConnTrue.Visible = False
            '        picConnFalse.Visible = True
            '    End If
        End If
    End Sub

    Private Sub dgStockItemBal_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStockItemBal.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgStockItemBal.Rows(e.RowIndex)
            Dim selectedSKU As String = row.Cells("stock_skucode").Value.ToString()
            Dim currentStock As String = row.Cells("stock_qty").Value.ToString()

            If currentStock < 1 Then
                MessageBox.Show("Oops! Insufficient quantity for this item.", "Out of stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            frmItemLoc.lblLocSKU.Text = row.Cells("stock_skucode").Value
            frmItemLoc.lblLocProdDesc.Text = row.Cells("stock_desc").Value
            frmItemLoc.lblLocVar.Text = row.Cells("stock_variant").Value
            frmItemLoc.lblLocColor.Text = row.Cells("stock_color").Value
            frmItemLoc.lblLocTotalQty.Text = row.Cells("stock_qty").Value
            Dim sku As String = row.Cells("stock_skucode").Value.ToString()
            If StockClass.cachedItemBalance IsNot Nothing Then
                Dim filteredRows() As DataRow = StockClass.cachedItemBalance.Select("sku_code = '" & sku.Replace("'", "''") & "'")
                frmItemLoc.dgItemLoc.Rows.Clear()
                For Each dr As DataRow In filteredRows
                    frmItemLoc.dgItemLoc.Rows.Add(
                                                    dr("item_loc").ToString(),
                                                    dr("item_qty")
                                                )
                Next
            End If
            frmItemLoc.ShowDialog()
        End If
    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            TransactionClass.show_ItemTransactions()
            TransactionClass.load_ItemTransactions_To_frmItem()
            frmItem.tcItemModule.SelectedTab = frmItem.tpTransaction
            frmItem.ShowDialog()

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            StyleCategoryClass.show_stylecat()
            StyleCategoryClass.show_types()
            StyleCategoryClass.show_weartype()
            frmItem.tcItemModule.SelectedTab = frmItem.tpCategory
            frmItem.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            ColorClass.show_colors()
            CollectionClass.show_collection()
            GenderClass.show_genders()
            frmItem.tcItemModule.SelectedTab = frmItem.tpModules
            frmItem.ShowDialog()
        Finally
            ' Change the cursor back to the default cursor when finished
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            SKUCreationClass.show_parentSKU()
            frmItem.tcItemModule.SelectedTab = frmItem.tpParentSKU
            frmItem.ShowDialog()
        Finally
            ' Change the cursor back to the default cursor when finished
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class

'Public Class temp
'    Public Class StockClass

'        Public Shared table_transferL As DataTable 'TO MAKE IT PUBLIC TO USE ITS DATA

'        Public Shared cachedItemBalance As DataTable = Nothing
'        Public Shared cachedSuppliers As DataTable = Nothing
'        'Private Shared cachedRecentStockIn As DataTable = Nothing
'        Public Shared cachedStockInHeader As DataTable = Nothing
'        Public Shared cachedStockInLines As DataTable = Nothing
'        Public Shared cachedTransferH As DataTable = Nothing

'        Public Shared Sub show_ItemBalanceList(Optional forceRefresh As Boolean = False)

'            ' Kung walang cache or pinilit i-refresh → query DB ulit
'            If cachedItemBalance Is Nothing OrElse forceRefresh Then
'                cachedItemBalance = get_itembalance(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store, False)

'                frmMain.dgStockItemBal.Refresh()
'                frmMain.dgStockItemBal.Rows.Clear()

'                If cachedItemBalance.Rows.Count > 0 Then
'                    For Each Row As DataRow In cachedItemBalance.Rows
'                        frmMain.dgStockItemBal.Rows.Add(
'                        Row("sku_code"),
'                        Row("item_desc"),
'                        Row("var_app"),
'                        Row("brand_desc"),
'                        Row("item_qty")
'                    )
'                    Next
'                End If
'            End If
'        End Sub

'        Public Shared Sub show_Suppliers(Optional forceRefresh As Boolean = False)

'            ' Load from DB if cache is empty or refresh is requested
'            If cachedSuppliers Is Nothing OrElse forceRefresh Then
'                cachedSuppliers = get_suppliers(get_user_comp(My.Settings.CurrentUserID))
'                frmMain.dgSupplier.Refresh()
'                frmMain.dgSupplier.Rows.Clear()

'                If cachedSuppliers.Rows.Count > 0 Then
'                    For Each Row As DataRow In cachedSuppliers.Rows
'                        Dim supplier As String = Row("supplier_desc") & " (" & Row("supplier_code") & ")"
'                        frmMain.dgSupplier.Rows.Add(Row("company_code"), Row("supplier_code"), supplier)
'                    Next
'                End If
'            End If
'        End Sub


'        'STOCK IN HISTORY <=====================================================================================
'        Public Shared Sub show_recent_stockin(Optional forceRefresh As Boolean = False)

'            ' Load from DB if cache is empty or refresh requested
'            If cachedStockInHeader Is Nothing OrElse forceRefresh Then
'                cachedStockInHeader = get_mpurchase_h(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)

'                frmMain.dgRecentStockIN.Refresh()

'                ' Default date range (last 1 month)
'                frmMain.dateStockTo.Value = DateTime.Now.Date
'                frmMain.dateStockFrom.Value = frmMain.dateStockTo.Value.AddMonths(-1)
'                frmMain.dgRecentStockIN.Rows.Clear()

'                If cachedStockInHeader.Rows.Count > 0 Then
'                    For Each Row As DataRow In cachedStockInHeader.Rows
'                        frmMain.dgRecentStockIN.Rows.Add(
'                        Row("company_code"),
'                        Row("mpurchase_id"),
'                        Row("supplier_code"),
'                        Row("store_code"),
'                        Row("supplier_desc"),
'                        Row("reference_no"),
'                        CDate(Row("delivery_date")).ToString("MMMM dd, yyyy")
'                    )
'                    Next
'                End If
'            End If
'        End Sub
'        Private Shared Function GetStockInHeaderRow(mpurchaseID As String) As DataRow
'            If cachedStockInHeader Is Nothing OrElse cachedStockInHeader.Rows.Count = 0 Then
'                Return Nothing
'            End If

'            Dim filter As String = String.Format(" mpurchase_id = '{0}'",
'                                         mpurchaseID.Replace("'", "''"))

'            Dim foundRows() As DataRow = cachedStockInHeader.Select(filter)

'            If foundRows.Length > 0 Then
'                Return foundRows(0) ' laging 1 lang ang expectation
'            Else
'                Return Nothing
'            End If
'        End Function
'        Private Shared Function GetStockInLine(mpurchaseID As String) As DataTable
'            If cachedStockInLines Is Nothing OrElse cachedStockInLines.Rows.Count = 0 Then
'                Return New DataTable() ' walang laman
'            End If

'            Dim filter As String = $"mpurchase_id = '{mpurchaseID.Replace("'", "''")}'"
'            Dim foundRows() As DataRow = cachedStockInLines.Select(filter)

'            Return If(foundRows.Length > 0, foundRows.CopyToDataTable(), cachedStockInLines.Clone())
'        End Function

'        Public Shared Sub show_mpl_stockin(ByVal inputComp As String, ByVal mpurchaseID As String, ByVal storeCode As String, Optional forceRefresh As Boolean = False)
'            '--- Get header data
'            If cachedStockInHeader Is Nothing OrElse forceRefresh Then
'                cachedStockInHeader = get_mpurchase_h(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)
'            End If

'            Dim row As DataRow = GetStockInHeaderRow(mpurchaseID)
'            If row IsNot Nothing Then
'                frmStockInData.lblMPID.Text = row("mpurchase_id").ToString()
'                frmStockInData.lblMPSupplier.Text = row("supplier_desc").ToString()
'                frmStockInData.txtMPRefNo.Text = row("reference_no").ToString()
'                frmStockInData.txtMPReceiptDate.Text = CDate(row("dr_date")).ToString("MMMM dd, yyyy")
'                frmStockInData.txttMPDeliveryDate.Text = CDate(row("delivery_date")).ToString("MMMM dd, yyyy")
'                frmStockInData.txtMPRemarks.Text = row("remarks").ToString()
'                frmStockInData.lblMPStatus.Text = row("status").ToString()

'                ' --- Get line details (specific sa mpurchaseID)
'                If cachedStockInLines Is Nothing OrElse forceRefresh Then
'                    cachedStockInLines = get_mpurchase_l(inputComp, storeCode)
'                End If

'                Dim lineTable As DataTable = GetStockInLine(mpurchaseID)

'                frmStockInData.dgMPL.Rows.Clear()
'                frmStockInData.dgMPL.Refresh()
'                frmStockInData.btnStockINPrint.Enabled = False

'                For Each line As DataRow In lineTable.Rows
'                    frmStockInData.dgMPL.Rows.Add(
'                line("company_code"),
'                line("sku_link"),
'                line("mpurchase_id"),
'                line("sku_code"),
'                line("item_desc"),
'                line("var_app"),
'                line("brand_desc"),
'                line("qty"),
'                line("unit_cost"),
'                1,
'                line("printed"),
'                line("skuprinted")
'            )
'                Next
'            Else
'                MsgBox("No data found.")
'            End If
'        End Sub
'        '=====================================================================================> STOCK IN HISTORY 

'        'Outgoing Transfer HISTORY <=====================================================================================
'        Public Shared Sub show_transfer_h(Optional forceRefresh As Boolean = False)

'            If cachedTransferH Is Nothing OrElse forceRefresh Then
'                cachedTransferH = get_transfer_h(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)

'                '=== Clear all grids ===
'                ClearAllTransferGrids()
'                If cachedTransferH.Rows.Count = 0 Then Exit Sub

'                For Each Row As DataRow In cachedTransferH.Rows
'                    Dim statusCode As String = Row("status").ToString()
'                    Dim createDate As String = CDate(Row("create_date")).ToString("MMMM dd, yyyy")

'                    ' Special handling for partial received
'                    Dim inTransitLabel As String = "In Transit"
'                    If statusCode = "3" AndAlso Not String.IsNullOrEmpty(Row("received_timestamp").ToString()) Then
'                        statusCode = "partial"
'                        inTransitLabel = "Partial Received"
'                    End If

'                    ' Status list
'                    Dim statuses() As String = {
'                    "For Approval", "To Pick", "Ready to ship",
'                    inTransitLabel, "Received", "", "", "", "",
'                    "Cancelled", "Reroute"
'                }
'                    Dim statusDesc As String = If(IsNumeric(statusCode) AndAlso CInt(statusCode) >= 0 AndAlso CInt(statusCode) <= 10,
'                                              statuses(CInt(statusCode)),
'                                              If(statusCode = "partial", "Partial Received", "Unknown"))

'                    '=== Add to Main Grids ===
'                    frmMain.dgRecentTransfer.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                    frmMain.dgTransferApprTab.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)

'                    '=== Add to StockOut Grids based on Status ===
'                    AddToStockOutGrid(statusCode, Row, statusDesc, createDate)
'                Next
'            End If

'        End Sub
'        Private Shared Sub ClearAllTransferGrids()
'            frmMain.dgRecentTransfer.Rows.Clear()
'            frmMain.dgTransferApprTab.Rows.Clear()

'            frmStockOut.dgTransfer0.Rows.Clear()
'            frmStockOut.dgTransfer1.Rows.Clear()
'            frmStockOut.dgTransfer2.Rows.Clear()
'            frmStockOut.dgTransfer3.Rows.Clear()
'            frmStockOut.dgTransfer4.Rows.Clear()
'            frmStockOut.dgTransferPartialReceived.Rows.Clear()
'            frmStockOut.dgTransfer9.Rows.Clear()
'            frmStockOut.dgTransfer10.Rows.Clear()
'        End Sub
'        Private Shared Sub AddToStockOutGrid(statusCode As String, Row As DataRow, statusDesc As String, createDate As String)
'            Select Case statusCode
'                Case "0"
'                    frmStockOut.dgTransfer0.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                Case "1"
'                    frmStockOut.dgTransfer1.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                Case "2"
'                    frmStockOut.dgTransfer2.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                Case "3"
'                    If String.IsNullOrEmpty(Row("received_timestamp").ToString()) Then
'                        frmStockOut.dgTransfer3.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                    Else
'                        frmStockOut.dgTransferPartialReceived.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                    End If
'                Case "4"
'                    frmStockOut.dgTransfer4.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                Case "9"
'                    frmStockOut.dgTransfer9.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                Case "10"
'                    frmStockOut.dgTransfer10.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                Case "partial"
'                    frmStockOut.dgTransferPartialReceived.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'            End Select
'        End Sub
'        '=====================================================================================> Outgoing Transfer HISTORY


'        ''----------------------------------------------------------
'        '' Optional: clear cache if needed
'        ''----------------------------------------------------------
'        'Public Shared Sub ClearCache()
'        '    cachedTransferH = Nothing
'        'End Sub

'        'Public Shared Sub show_transfer_h()
'        '    'LOAD ALL LISTS PARENT SKU
'        '    Dim table_transferh As DataTable
'        '    frmMain.dgRecentTransfer.Refresh()
'        '    frmMain.dgRecentTransfer.Rows.Clear()

'        '    frmMain.dgTransferApprTab.Refresh()
'        '    frmMain.dgTransferApprTab.Rows.Clear()

'        '    frmStockOut.dgTransfer0.Refresh()
'        '    frmStockOut.dgTransfer1.Refresh()
'        '    frmStockOut.dgTransfer2.Refresh()
'        '    frmStockOut.dgTransfer3.Refresh()
'        '    frmStockOut.dgTransfer4.Refresh()
'        '    frmStockOut.dgTransferPartialReceived.Refresh()
'        '    frmStockOut.dgTransfer9.Refresh()
'        '    frmStockOut.dgTransfer10.Refresh()

'        '    frmStockOut.dgTransfer0.Rows.Clear()
'        '    frmStockOut.dgTransfer1.Rows.Clear()
'        '    frmStockOut.dgTransfer2.Rows.Clear()
'        '    frmStockOut.dgTransfer3.Rows.Clear()
'        '    frmStockOut.dgTransfer4.Rows.Clear()
'        '    frmStockOut.dgTransferPartialReceived.Rows.Clear()
'        '    frmStockOut.dgTransfer9.Rows.Clear()
'        '    frmStockOut.dgTransfer10.Rows.Clear()

'        '    'frmMain.dateStockTo.Value = DateTime.Now.Date
'        '    'frmMain.dateStockFrom.Value = frmMain.dateStockTo.Value.AddMonths(-1)

'        '    table_transferh = get_transfer_h(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)

'        '    If table_transferh.Rows.Count > 0 Then
'        '        For Each Row As DataRow In table_transferh.Rows
'        '            'OUT
'        '            Dim inTransitLabel As String = "In Transit"
'        '            Dim statusCode As String = Row("status").ToString
'        '            If statusCode = "3" AndAlso Not String.IsNullOrEmpty(Row("received_timestamp").ToString) Then
'        '                statusCode = "partial"
'        '                inTransitLabel = "Partial Received"
'        '            End If

'        '            Dim statuses() As String = {"For Approval", "To Pick", "Ready to ship", inTransitLabel, "Received", "", "", "", "", "Cancelled", "Reroute"}
'        '            Dim statusDesc As String = If(Row("status") >= 0 AndAlso Row("status") <= 10, statuses(Row("status")), "Unknown")
'        '            frmMain.dgRecentTransfer.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            frmMain.dgTransferApprTab.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            If Row("status") = 0 Then
'        '                frmStockOut.dgTransfer0.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            ElseIf Row("status") = 1 Then
'        '                frmStockOut.dgTransfer1.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            ElseIf Row("status") = 2 Then
'        '                frmStockOut.dgTransfer2.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            ElseIf Row("status") = 3 Then
'        '                If Row("received_timestamp").ToString IsNot "" Then
'        '                    frmStockOut.dgTransferPartialReceived.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '                Else
'        '                    frmStockOut.dgTransfer3.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '                End If
'        '            ElseIf Row("status") = 4 Then
'        '                frmStockOut.dgTransfer4.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            ElseIf Row("status") = 5 Then 'OPTIONAL
'        '                'frmStockOut.dgTransfer5.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            ElseIf Row("status") = 9 Then
'        '                frmStockOut.dgTransferPartialReceived.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            ElseIf Row("status") = 10 Then
'        '                frmStockOut.dgTransfer10.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            End If

'        '        Next
'        '    End If
'        'End Sub

'        'Incoming transfer_h < ========================================================================================================
'        '=== Cache DataTable ===
'        Public Shared cachedTransferHDest As DataTable = Nothing

'        '----------------------------------------------------------
'        ' Show Transfer Dest
'        '----------------------------------------------------------
'        Public Shared Sub show_transfer_h_dest(Optional forceRefresh As Boolean = False)
'            '=== Clear all grids ===
'            ClearAllTransferInGrids()

'            '=== Use cache or reload ===
'            If cachedTransferHDest Is Nothing OrElse forceRefresh Then
'                cachedTransferHDest = get_transfer_h_dest(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)
'            End If

'            If cachedTransferHDest.Rows.Count = 0 Then Exit Sub

'            For Each Row As DataRow In cachedTransferHDest.Rows
'                Dim statusCode As String = Row("status").ToString()
'                Dim inTransitLabel As String = "In Transit"

'                ' Partial received handling
'                If statusCode = "3" AndAlso Not String.IsNullOrEmpty(Row("received_timestamp").ToString()) Then
'                    statusCode = "partial"
'                    inTransitLabel = "Partial Received"
'                End If

'                ' Status array
'                Dim statusesIN() As String = {
'                "For Approval", "Preparing", "Ready to ship",
'                inTransitLabel, "Received", "", "", "", "",
'                "Cancelled", "Reroute"
'            }

'                Dim statusDescIN As String =
'                If(IsNumeric(Row("status")) AndAlso CInt(Row("status")) >= 0 AndAlso CInt(Row("status")) <= 10,
'                   statusesIN(CInt(Row("status"))),
'                   If(statusCode = "partial", "Partial Received", "Unknown"))

'                Dim createDate As String = CDate(Row("create_date")).ToString("MMMM dd, yyyy")

'                '=== Add to Main Grid ===
'                frmMain.dgTransferIn.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDescIN, createDate)

'                '=== Add to TransferIn Grids based on Status ===
'                AddToTransferInGrid(statusCode, Row, statusDescIN, createDate)
'            Next
'        End Sub
'        Private Shared Sub ClearAllTransferInGrids()
'            frmMain.dgTransferIn.Rows.Clear()

'            frmTransferIn.dgTransfer1.Rows.Clear()
'            frmTransferIn.dgTransfer2.Rows.Clear()
'            frmTransferIn.dgTransfer3.Rows.Clear()
'            frmTransferIn.dgTransfer4.Rows.Clear()
'            frmTransferIn.dgTransferPartialReceived.Rows.Clear()
'            frmTransferIn.dgTransfer9.Rows.Clear()
'        End Sub
'        Private Shared Sub AddToTransferInGrid(statusCode As String, Row As DataRow, statusDesc As String, createDate As String)
'            Select Case statusCode
'                Case "1"
'                    frmTransferIn.dgTransfer1.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                Case "2"
'                    frmTransferIn.dgTransfer2.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                Case "3"
'                    If String.IsNullOrEmpty(Row("received_timestamp").ToString()) Then
'                        frmTransferIn.dgTransfer3.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                    Else
'                        frmTransferIn.dgTransferPartialReceived.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                    End If
'                Case "4"
'                    frmTransferIn.dgTransfer4.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                Case "9"
'                    frmTransferIn.dgTransfer9.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'                Case "partial"
'                    frmTransferIn.dgTransferPartialReceived.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
'            End Select
'        End Sub
'        '========================================================================================================> Incoming transfer_h

'        'Public Shared Sub show_transfer_h_dest()
'        '    'LOAD ALL LISTS PARENT SKU
'        '    Dim table_transferh_dest As DataTable
'        '    frmMain.dgTransferIn.Refresh()
'        '    frmMain.dgTransferIn.Rows.Clear()

'        '    frmTransferIn.dgTransfer1.Refresh()
'        '    frmTransferIn.dgTransfer2.Refresh()
'        '    frmTransferIn.dgTransfer3.Refresh()
'        '    frmTransferIn.dgTransfer4.Refresh()
'        '    frmTransferIn.dgTransferPartialReceived.Refresh()
'        '    frmTransferIn.dgTransfer9.Refresh()

'        '    frmTransferIn.dgTransfer1.Rows.Clear()
'        '    frmTransferIn.dgTransfer2.Rows.Clear()
'        '    frmTransferIn.dgTransfer3.Rows.Clear()
'        '    frmTransferIn.dgTransfer4.Rows.Clear()
'        '    frmTransferIn.dgTransferPartialReceived.Rows.Clear()
'        '    frmTransferIn.dgTransfer9.Rows.Clear()

'        '    table_transferh_dest = get_transfer_h_dest(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)

'        '    If table_transferh_dest.Rows.Count > 0 Then
'        '        For Each Row As DataRow In table_transferh_dest.Rows

'        '            'IN
'        '            Dim inTransitLabel As String = "In Transit"
'        '            Dim statusCode As String = Row("status").ToString
'        '            If statusCode = "3" AndAlso Not String.IsNullOrEmpty(Row("received_timestamp").ToString) Then
'        '                statusCode = "partial"
'        '                inTransitLabel = "Partial Received"
'        '            End If

'        '            Dim statusesIN() As String = {"For Approval", "Preparing", "Ready to ship", inTransitLabel, "Received", "", "", "", "", "Cancelled", "Reroute"}
'        '            Dim statusDescIN As String = If(Row("status") >= 0 AndAlso Row("status") <= 10, statusesIN(Row("status")), "Unknown")
'        '            frmMain.dgTransferIn.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDescIN, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))

'        '            If Row("status") = 1 Then
'        '                frmTransferIn.dgTransfer1.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDescIN, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            ElseIf Row("status") = 2 Then
'        '                frmTransferIn.dgTransfer2.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDescIN, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            ElseIf Row("status") = 3 Then
'        '                If Row("received_timestamp").ToString IsNot "" Then
'        '                    frmTransferIn.dgTransferPartialReceived.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDescIN, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '                Else
'        '                    frmTransferIn.dgTransfer3.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDescIN, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '                End If
'        '            ElseIf Row("status") = 4 Then
'        '                frmTransferIn.dgTransfer4.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDescIN, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            ElseIf Row("status") = 5 Then ' Optional

'        '            ElseIf Row("status") = 9 Then
'        '                frmTransferIn.dgTransfer9.Rows.Add(Row("company_code"), Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDescIN, CDate(Row("create_date")).ToString("MMMM dd, yyyy"))
'        '            End If
'        '        Next
'        '    End If
'        'End Sub


'        Public Shared Sub show_transfer_l(ByVal inputComp As String, ByVal dr As String, ByVal storeCodeOrigin As String, ByVal storeCodeDest As String, ByVal inOrOut As String)
'            'LOAD ALL LISTS PARENT SKU
'            Dim resultTable As DataTable = get_transfer_h_data(inputComp, dr, storeCodeOrigin, storeCodeDest)

'            If resultTable.Rows.Count > 0 Then

'                Dim drID As String = resultTable.Rows(0)("dr").ToString()
'                Dim storeOriginDesc As String = resultTable.Rows(0)("store_origin_desc").ToString()
'                Dim storeDestDesc As String = resultTable.Rows(0)("store_dest_desc").ToString()
'                Dim dateCreated As String = CDate(resultTable.Rows(0)("create_date")).ToString("MMMM dd, yyyy")
'                Dim status As String = resultTable.Rows(0)("status").ToString()
'                Dim remarks As String = resultTable.Rows(0)("remarks").ToString()
'                Dim receivedTimestamp As String = resultTable.Rows(0)("received_timestamp").ToString()
'                Dim inTransitLabel As String

'                If inOrOut = "out" Then

'                    If String.IsNullOrEmpty(receivedTimestamp) Then
'                        inTransitLabel = "In Transit"
'                    Else
'                        inTransitLabel = "Partial Received"
'                    End If
'                    Dim statuses() As String = {
'                                            "Created, Waiting for Approval",  ' 0
'                                            "Approved/To pick",               ' 1
'                                            "Ready to Ship",                  ' 2
'                                            inTransitLabel,                     ' 3
'                                            "Received",                       ' 4
'                                            "", "", "", "",                   ' 5–8 (optional)
'                                            "Cancelled",                      ' 9
'                                            "Reroute"                         ' 10
'                                        }

'                    Dim statusDesc As String = If(status >= 0 AndAlso status <= 10, statuses(status), "Unknown")
'                    frmTransferData.lblTTStatus.Text = statusDesc

'                    ' Set color per status
'                    Select Case status
'                        Case 0 ' Created / For Approval
'                            frmTransferData.lblTTStatus.ForeColor = Color.DimGray ' Neutral / pending
'                        Case 1 ' Approved / To Pick
'                            frmTransferData.lblTTStatus.ForeColor = Color.Orange ' Warning / action required
'                        Case 2 ' Ready to Ship
'                            frmTransferData.lblTTStatus.ForeColor = Color.DodgerBlue ' Ready state
'                        Case 3 ' In Transit
'                            frmTransferData.lblTTStatus.ForeColor = Color.MediumSlateBlue ' Moving state
'                        Case 4 ' Received
'                            frmTransferData.lblTTStatus.ForeColor = Color.ForestGreen ' Successfully received
'                        Case 5 ' Complete
'                            frmTransferData.lblTTStatus.ForeColor = Color.DarkCyan ' Final stage
'                        Case 9 ' Cancelled
'                            frmTransferData.lblTTStatus.ForeColor = Color.Crimson ' Strong red for cancelled
'                        Case 10 ' Reroute
'                            frmTransferData.lblTTStatus.ForeColor = Color.DarkOrange ' Alert but different from “To Pick”
'                        Case Else
'                            frmTransferData.lblTTStatus.ForeColor = Color.Black ' Fallback/default
'                    End Select
'                    frmTransferData.txtTTDRNo.Text = drID
'                    frmTransferData.lblTTStoreDest.Text = storeDestDesc
'                    frmTransferData.txtTTRemarks.Text = remarks
'                    frmTransferData.txtTTCreateDate.Text = dateCreated
'                    frmTransferData.lblTTStoreCodeDest.Text = storeCodeDest

'                    'Dim table_transferL As DataTable
'                    table_transferL = get_transfer_l(inputComp, dr, storeCodeOrigin, storeCodeDest)

'                    frmTransferData.dgTransferL.Refresh()
'                    frmTransferData.dgTransferL.Rows.Clear()

'                    If table_transferL.Rows.Count > 0 Then
'                        For Each Row As DataRow In table_transferL.Rows
'                            frmTransferData.dgTransferL.Rows.Add(Row("company_code"), Row("dr"), Row("sku_code"), Row("item_desc"), Row("var_app"), Row("brand_desc"), Row("qty"), Row("approved_qty"), Row("received_qty"))
'                        Next
'                    End If

'                ElseIf inOrOut = "in" Then
'                    If String.IsNullOrEmpty(receivedTimestamp) Then
'                        inTransitLabel = "In Transit"
'                    Else
'                        inTransitLabel = "Partial Received"
'                    End If
'                    Dim statuses() As String = {"Preparing",
'                                            "Preparing",                      ' 1
'                                            "Ready to Ship",                  ' 2
'                                            inTransitLabel,                     ' 3
'                                            "Received",                       ' 4
'                                            "Complete",                       ' 5
'                                             "", "", "",                      ' 6–8 (optional)
'                                            "Cancelled"                      ' 9
'                                        }

'                    Dim statusDesc As String = If(status >= 0 AndAlso status <= 9, statuses(status), "Unknown")
'                    frmTransferInData.lblTTStatus.Text = statusDesc

'                    ' Set color per status
'                    Select Case status
'                        Case 1 ' Approved / To Pick
'                            frmTransferInData.lblTTStatus.ForeColor = Color.Orange ' Warning / action required
'                        Case 2 ' Ready to Ship
'                            frmTransferInData.lblTTStatus.ForeColor = Color.DodgerBlue ' Ready state
'                        Case 3 ' In Transit
'                            frmTransferInData.lblTTStatus.ForeColor = Color.MediumSlateBlue ' Moving state
'                        Case 4 ' Received
'                            frmTransferInData.lblTTStatus.ForeColor = Color.ForestGreen ' Successfully received
'                        Case 5 ' Complete
'                            frmTransferInData.lblTTStatus.ForeColor = Color.DarkCyan ' Final stage
'                        Case 9 ' Cancelled
'                            frmTransferInData.lblTTStatus.ForeColor = Color.Crimson ' Strong red for cancelled
'                        Case Else
'                            frmTransferInData.lblTTStatus.ForeColor = Color.Black ' Fallback/default
'                    End Select
'                    frmTransferInData.txtTTDRNo.Text = drID
'                    frmTransferInData.lblTTStoreOrigin.Text = storeOriginDesc
'                    frmTransferInData.txtTTRemarks.Text = remarks
'                    frmTransferInData.txtTTCreateDate.Text = dateCreated
'                    frmTransferInData.lblTTStoreCodeOrig.Text = storeCodeOrigin

'                    'Dim table_transferL As DataTable
'                    table_transferL = get_transfer_l(inputComp, dr, storeCodeOrigin, storeCodeDest)

'                    frmTransferInData.dgTransferL.Refresh()
'                    frmTransferInData.dgTransferL.Rows.Clear()

'                    If table_transferL.Rows.Count > 0 Then
'                        For Each Row As DataRow In table_transferL.Rows
'                            frmTransferInData.dgTransferL.Rows.Add(Row("company_code"), Row("dr"), Row("sku_code"), Row("item_desc"), Row("var_app"), Row("brand_desc"), Row("approved_qty"), Row("received_qty"))
'                        Next
'                    End If
'                End If


'            Else
'                MsgBox("No data found.")
'            End If

'        End Sub

'        Public Shared Sub FilterDataGridViewByDate(dataGrid As DataGridView, fromDate As Date, toDate As Date)
'            toDate = toDate.AddDays(1).AddSeconds(-1) ' include entire "to" date

'            For Each row As DataGridViewRow In dataGrid.Rows
'                If row.IsNewRow Then Continue For

'                Dim rowDate As Date
'                If Date.TryParse(row.Cells("mph_deliverydate").Value.ToString(), rowDate) Then
'                    row.Visible = (rowDate >= fromDate.ToString() AndAlso rowDate <= toDate.ToString())
'                Else
'                    row.Visible = False
'                End If
'            Next
'        End Sub

'        Public Shared Sub itemBalanceSearch(searchText As String)
'            If frmMain.dgStockItemBal.Rows.Count > 0 Then
'                For Each row As DataGridViewRow In frmMain.dgStockItemBal.Rows
'                    If row.Cells("stock_skucode").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
'                    row.Cells("stock_item").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
'                    row.Cells("stock_variation").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
'                    row.Cells("stock_brand").Value.ToString().ToLower().Contains(searchText.ToLower()) Then
'                        row.Visible = True
'                    Else
'                        row.Visible = False
'                    End If
'                Next
'            End If
'        End Sub
'    End Class

'End Class

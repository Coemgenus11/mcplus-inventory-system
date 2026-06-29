Public Class StockClass

    Public Shared table_transferLOut As DataTable

    Public Shared cachedItemBalance As DataTable = Nothing
    Public Shared cachedSuppliers As DataTable = Nothing
    'Private Shared cachedRecentStockIn As DataTable = Nothing
    Public Shared cachedStockInHeader As DataTable = Nothing
    Public Shared cachedStockInLines As DataTable = Nothing
    Public Shared cachedTransferOutHeader As DataTable = Nothing
    Public Shared cachedTransferOutLine As DataTable = Nothing
    Public Shared cachedTransferInHeader As DataTable = Nothing
    Public Shared cachedTransferInLine As DataTable = Nothing


    Public Shared Sub show_ItemBalanceList(Optional forceRefresh As Boolean = False)

        If cachedItemBalance Is Nothing OrElse forceRefresh Then
            cachedItemBalance = get_itembalance(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store, False)
        End If

        If cachedItemBalance Is Nothing Then Exit Sub

        ' Dictionary to store summed qty per SKU
        Dim skuDict As New Dictionary(Of String, Double)

        ' Optional: store other details (desc, brand, etc.)
        Dim skuDetails As New Dictionary(Of String, DataRow)

        ' Step 1: Group and Sum
        For Each row As DataRow In cachedItemBalance.Rows
            Dim sku As String = row("sku_code").ToString()
            Dim qty As Double = Convert.ToDouble(row("item_qty"))

            If skuDict.ContainsKey(sku) Then
                skuDict(sku) += qty
            Else
                skuDict.Add(sku, qty)
                skuDetails.Add(sku, row) ' store first occurrence for other fields
            End If
        Next

        ' Step 2: Display / Update Grid
        For Each kvp In skuDict
            Dim sku As String = kvp.Key
            Dim totalQty As Double = kvp.Value
            Dim row As DataRow = skuDetails(sku)

            Dim found As Boolean = False

            For Each dgRow As DataGridViewRow In frmMain.dgStockItemBal.Rows
                If dgRow.Cells(0).Value.ToString() = sku Then
                    dgRow.Cells(4).Value = totalQty
                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                frmMain.dgStockItemBal.Rows.Add(
                sku,
                row("gen_desc") + " " + row("col_desc") + " " + row("type_desc") + " " + row("stylecat_desc") + " " + row("stylevar_desc"),
                row("color_desc"),
                row("variant"),
                totalQty
            )
            End If
        Next

    End Sub

    Public Shared Sub show_Suppliers(Optional forceRefresh As Boolean = False)

        ' Load from DB if cache is empty or refresh is requested
        If cachedSuppliers Is Nothing OrElse forceRefresh Then
            cachedSuppliers = get_suppliers(get_user_comp(My.Settings.CurrentUserID))
            frmMain.dgSupplier.Refresh()
            frmMain.dgSupplier.Rows.Clear()

            If cachedSuppliers.Rows.Count > 0 Then
                For Each Row As DataRow In cachedSuppliers.Rows
                    Dim supplier As String = Row("supplier_desc") & " (" & Row("supplier_code") & ")"
                    frmMain.dgSupplier.Rows.Add(Row("company_code"), Row("supplier_code"), supplier, Row("supplier_desc"), Row("supplier_tin"), Row("supplier_addr"), Row("supplier_contact"), Row("supplier_email"), Row("payment_terms"))
                Next
            End If
        End If
    End Sub


    'STOCK IN MPH HISTORY <=====================================================================================
    Public Shared Sub show_recent_stockin(Optional forceRefresh As Boolean = False)

        ' Load from DB if cache is empty or refresh requested
        If cachedStockInHeader Is Nothing OrElse forceRefresh Then
            cachedStockInHeader = get_mpurchase_h(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)

            frmMain.dgRecentStockIN.Refresh()

            ' Default date range (last 1 month)
            frmMain.dateStockTo.Value = DateTime.Now.Date
            frmMain.dateStockFrom.Value = frmMain.dateStockTo.Value.AddMonths(-1)
            frmMain.dgRecentStockIN.Rows.Clear()

            If cachedStockInHeader.Rows.Count > 0 Then
                For Each Row As DataRow In cachedStockInHeader.Rows
                    frmMain.dgRecentStockIN.Rows.Add(
                        Row("company_code"),
                        Row("mpurchase_id"),
                        Row("supplier_code"),
                        Row("store_code"),
                        Row("supplier_desc"),
                        Row("reference_no"),
                        CDate(Row("delivery_date")).ToString("MMMM dd, yyyy")
                    )
                Next
            End If
        End If
    End Sub
    Private Shared Function GetStockInHeaderRow(mpurchaseID As String) As DataRow
        If cachedStockInHeader Is Nothing OrElse cachedStockInHeader.Rows.Count = 0 Then
            Return Nothing
        End If

        Dim filter As String = String.Format(" mpurchase_id = '{0}'",
                                         mpurchaseID.Replace("'", "''"))

        Dim foundRows() As DataRow = cachedStockInHeader.Select(filter)

        If foundRows.Length > 0 Then
            Return foundRows(0) ' laging 1 lang ang expectation
        Else
            Return Nothing
        End If
    End Function

    Private Shared Function GetStockInLine(mpurchaseID As String) As DataTable
        If cachedStockInLines Is Nothing OrElse cachedStockInLines.Rows.Count = 0 Then
            Return New DataTable() ' walang laman
        End If

        Dim filter As String = $"mpurchase_id = '{mpurchaseID.Replace("'", "''")}'"
        Dim foundRows() As DataRow = cachedStockInLines.Select(filter)

        Return If(foundRows.Length > 0, foundRows.CopyToDataTable(), cachedStockInLines.Clone())
    End Function

    Public Shared Sub show_mpl_stockin(ByVal inputComp As String, ByVal mpurchaseID As String, ByVal storeCode As String, Optional forceRefresh As Boolean = False)
        '--- Get header data
        If cachedStockInHeader Is Nothing OrElse forceRefresh Then
            cachedStockInHeader = get_mpurchase_h(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)
        End If

        Dim row As DataRow = GetStockInHeaderRow(mpurchaseID)
        If row IsNot Nothing Then
            frmStockInData.lblMPID.Text = row("mpurchase_id").ToString()
            frmStockInData.lblMPSupplier.Text = row("supplier_desc").ToString()
            frmStockInData.txtMPRefNo.Text = row("reference_no").ToString()
            frmStockInData.txtMPReceiptDate.Text = CDate(row("dr_date")).ToString("MMMM dd, yyyy")
            frmStockInData.txttMPDeliveryDate.Text = CDate(row("delivery_date")).ToString("MMMM dd, yyyy")
            frmStockInData.txtMPRemarks.Text = row("remarks").ToString()
            frmStockInData.lblMPStatus.Text = row("status").ToString()

            ' --- Get line details (specific sa mpurchaseID)
            If cachedStockInLines Is Nothing OrElse forceRefresh Then
                cachedStockInLines = get_mpurchase_l(inputComp, storeCode)
            End If

            Dim lineTable As DataTable = GetStockInLine(mpurchaseID)

            frmStockInData.dgMPL.Rows.Clear()
            frmStockInData.dgMPL.Refresh()
            frmStockInData.btnStockINPrint.Enabled = False

            For Each line As DataRow In lineTable.Rows
                frmStockInData.dgMPL.Rows.Add(
                line("company_code"),
                line("sku_link"),
                line("mpurchase_id"),
                line("sku_code"),
                line("gen_desc"),
                line("col_desc"),
                line("type_desc"),
                line("stylecat_desc") + " " + line("stylevar_desc"),
                line("color_desc"),
                line("variant"),
                line("qty"),
                line("unit_cost"),
                1,
                line("printed"),
                line("skuprinted")
            )
            Next
        Else
            MsgBox("No data found.")
        End If
    End Sub
    '=====================================================================================> STOCK IN HISTORY 

    'Outgoing Transfer HISTORY <=====================================================================================
    Public Shared Sub show_transfer_h(Optional forceRefresh As Boolean = False)

        If cachedTransferOutHeader Is Nothing OrElse forceRefresh Then
            cachedTransferOutHeader = get_transfer_h(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)

            '=== Clear all grids ===
            ClearAllTransferGrids()
            If cachedTransferOutHeader.Rows.Count = 0 Then Exit Sub

            For Each Row As DataRow In cachedTransferOutHeader.Rows
                Dim statusCode As String = Row("status").ToString()
                Dim createDate As String = CDate(Row("create_date")).ToString("MMMM dd, yyyy")

                ' Special handling for partial received
                Dim inTransitLabel As String = "In Transit"
                If statusCode = "3" AndAlso Not String.IsNullOrEmpty(Row("received_timestamp").ToString()) Then
                    statusCode = "partial"
                    inTransitLabel = "Partial Received"
                End If

                ' Status list
                Dim statuses() As String = {
                    "For Approval", "To Pick", "Ready to ship",
                    inTransitLabel, "Received", "", "", "", "",
                    "Cancelled", "Reroute"
                }
                Dim statusDesc As String = If(IsNumeric(statusCode) AndAlso CInt(statusCode) >= 0 AndAlso CInt(statusCode) <= 10,
                                              statuses(CInt(statusCode)),
                                              If(statusCode = "partial", "Partial Received", "Unknown"))

                '=== Add to Main Grids ===
                frmMain.dgRecentTransfer.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
                frmMain.dgTransferApprTab.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)

                '=== Add to StockOut Grids based on Status ===
                AddToStockOutGrid(statusCode, Row, statusDesc, createDate)
            Next
        End If

    End Sub
    Private Shared Sub ClearAllTransferGrids()
        frmMain.dgRecentTransfer.Rows.Clear()
        frmMain.dgTransferApprTab.Rows.Clear()

        frmStockOut.dgTransferAll.Rows.Clear()

        frmStockOut.dgTransfer0.Rows.Clear()
        frmStockOut.dgTransfer1.Rows.Clear()
        frmStockOut.dgTransfer2.Rows.Clear()
        frmStockOut.dgTransfer3.Rows.Clear()
        frmStockOut.dgTransfer4.Rows.Clear()
        frmStockOut.dgTransferPartialReceived.Rows.Clear()
        frmStockOut.dgTransfer9.Rows.Clear()
        frmStockOut.dgTransfer10.Rows.Clear()
    End Sub
    Private Shared Sub AddToStockOutGrid(statusCode As String, Row As DataRow, statusDesc As String, createDate As String)
        frmStockOut.dgTransferAll.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), Row("order_id"), statusDesc, createDate)
        Select Case statusCode
            Case "0"
                frmStockOut.dgTransfer0.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
            Case "1"
                frmStockOut.dgTransfer1.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
            Case "2"
                frmStockOut.dgTransfer2.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
            Case "3"
                If String.IsNullOrEmpty(Row("received_timestamp").ToString()) Then
                    frmStockOut.dgTransfer3.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
                Else
                    frmStockOut.dgTransferPartialReceived.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
                End If
            Case "4"
                frmStockOut.dgTransfer4.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
            Case "9"
                frmStockOut.dgTransfer9.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
            Case "10"
                frmStockOut.dgTransfer10.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
            Case "partial"
                frmStockOut.dgTransferPartialReceived.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDesc, createDate)
        End Select
    End Sub
    '=====================================================================================> Outgoing Transfer HISTORY


    ''----------------------------------------------------------
    '' Optional: clear cache if needed
    ''----------------------------------------------------------
    'Public Shared Sub ClearCache()
    '    cachedTransferH = Nothing
    'End Sub

    'Incoming transfer_h < ========================================================================================================
    '=== Cache DataTable ===


    '----------------------------------------------------------
    ' Show Transfer Dest
    '----------------------------------------------------------
    Public Shared Sub show_transfer_h_dest(Optional forceRefresh As Boolean = False)
        '=== Clear all grids ===
        ClearAllTransferInGrids()

        '=== Use cache or reload ===
        If cachedTransferInHeader Is Nothing OrElse forceRefresh Then
            cachedTransferInHeader = get_transfer_h_dest(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)
        End If

        If cachedTransferInHeader.Rows.Count = 0 Then Exit Sub

        For Each Row As DataRow In cachedTransferInHeader.Rows
            Dim statusCode As String = Row("status").ToString()
            Dim inTransitLabel As String = "In Transit"

            ' Partial received handling
            If statusCode = "3" AndAlso Not String.IsNullOrEmpty(Row("received_timestamp").ToString()) Then
                statusCode = "partial"
                inTransitLabel = "Partial Received"
            End If

            ' Status array
            Dim statusesIN() As String = {
                "For Approval", "Preparing", "Ready to ship",
                inTransitLabel, "Received", "", "", "", "",
                "Cancelled", "Reroute"
            }

            Dim statusDescIN As String =
                If(IsNumeric(Row("status")) AndAlso CInt(Row("status")) >= 0 AndAlso CInt(Row("status")) <= 10,
                   statusesIN(CInt(Row("status"))),
                   If(statusCode = "partial", "Partial Received", "Unknown"))

            Dim createDate As String = CDate(Row("create_date")).ToString("MMMM dd, yyyy")

            '=== Add to Main Grid ===
            frmMain.dgTransferIn.Rows.Add(Row("company_code"), statusCode, Row("store_code_origin"), Row("store_code_dest"), Row("dr"), statusDescIN, createDate)

            '=== Add to TransferIn Grids based on Status ===
            AddToTransferInGrid(statusCode, Row, statusDescIN, createDate)
        Next
    End Sub
    Private Shared Sub ClearAllTransferInGrids()
        frmMain.dgTransferIn.Rows.Clear()

        frmTransferIn.dgTransfer1.Rows.Clear()
        frmTransferIn.dgTransfer2.Rows.Clear()
        frmTransferIn.dgTransfer3.Rows.Clear()
        frmTransferIn.dgTransfer4.Rows.Clear()
        frmTransferIn.dgTransferPartialReceived.Rows.Clear()
        frmTransferIn.dgTransfer9.Rows.Clear()
    End Sub
    Private Shared Sub AddToTransferInGrid(statusCode As String, Row As DataRow, statusDesc As String, createDate As String)
        Select Case statusCode
            Case "1"
                frmTransferIn.dgTransfer1.Rows.Add(Row("company_code"), Row("store_code_dest"), Row("store_code_origin"), Row("dr"), statusDesc, createDate)
            Case "2"
                frmTransferIn.dgTransfer2.Rows.Add(Row("company_code"), Row("store_code_dest"), Row("store_code_origin"), Row("dr"), statusDesc, createDate)
            Case "3"
                If String.IsNullOrEmpty(Row("received_timestamp").ToString()) Then
                    frmTransferIn.dgTransfer3.Rows.Add(Row("company_code"), Row("store_code_dest"), Row("store_code_origin"), Row("dr"), statusDesc, createDate)
                Else
                    frmTransferIn.dgTransferPartialReceived.Rows.Add(Row("company_code"), Row("store_code_dest"), Row("store_code_origin"), Row("dr"), statusDesc, createDate)
                End If
            Case "4"
                frmTransferIn.dgTransfer4.Rows.Add(Row("company_code"), Row("store_code_dest"), Row("store_code_origin"), Row("dr"), statusDesc, createDate)
            Case "9"
                frmTransferIn.dgTransfer9.Rows.Add(Row("company_code"), Row("store_code_dest"), Row("store_code_origin"), Row("dr"), statusDesc, createDate)
            Case "partial"
                frmTransferIn.dgTransferPartialReceived.Rows.Add(Row("company_code"), Row("store_code_dest"), Row("store_code_origin"), Row("dr"), statusDesc, createDate)
        End Select
    End Sub
    '========================================================================================================> Incoming transfer_h


    Private Shared Function GetTransferOutHeaderRow(dr As String) As DataRow
        If cachedTransferOutHeader Is Nothing OrElse cachedTransferOutHeader.Rows.Count = 0 Then Return Nothing
        Dim filter As String = $"dr = '{dr.Replace("'", "''")}'"
        Dim foundRows() As DataRow = cachedTransferOutHeader.Select(filter)
        Return If(foundRows.Length > 0, foundRows(0), Nothing)
    End Function
    Private Shared Function GetTransferOutLine(dr As String) As DataTable
        If cachedTransferOutLine Is Nothing OrElse cachedTransferOutLine.Rows.Count = 0 Then
            Return New DataTable()
        End If

        Dim filter As String = $"dr = '{dr.Replace("'", "''")}'"
        Dim foundRows() As DataRow = cachedTransferOutLine.Select(filter)
        Return If(foundRows.Length > 0, foundRows.CopyToDataTable(), cachedTransferOutLine.Clone())
    End Function

    Private Shared Function GetTransferInHeaderRow(dr As String) As DataRow
        If cachedTransferInHeader Is Nothing OrElse cachedTransferInHeader.Rows.Count = 0 Then Return Nothing
        Dim filter As String = $"dr = '{dr.Replace("'", "''")}'"
        Dim foundRows() As DataRow = cachedTransferInHeader.Select(filter)
        Return If(foundRows.Length > 0, foundRows(0), Nothing)
    End Function
    Private Shared Function GetTransferInLine(dr As String) As DataTable
        If cachedTransferInLine Is Nothing OrElse cachedTransferInLine.Rows.Count = 0 Then
            Return New DataTable()
        End If

        Dim filter As String = $"dr = '{dr.Replace("'", "''")}'"
        Dim foundRows() As DataRow = cachedTransferInLine.Select(filter)
        Return If(foundRows.Length > 0, foundRows.CopyToDataTable(), cachedTransferInLine.Clone())
    End Function


    '---------------------------------------------
    '   SHOW TRANSFER HEADER + LINE
    '---------------------------------------------
    Public Shared Sub show_transfer_l(ByVal inputComp As String,
                                  ByVal dr As String,
                                  ByVal storeCodeOrigin As String,
                                  ByVal storeCodeDest As String,
                                  ByVal inOrOut As String,
                                  Optional forceRefresh As Boolean = False)

        Dim row As DataRow = Nothing
        If inOrOut = "out" Then
            row = GetTransferOutHeaderRow(dr)
        ElseIf inOrOut = "in" Then
            row = GetTransferInHeaderRow(dr)
        End If

        If row Is Nothing Then
            MsgBox("No data found.")
            Exit Sub
        End If

        '--- Common fields
        Dim drID As String = row("dr").ToString()
        Dim storeOriginDesc As String = row("store_origin_desc").ToString()
        Dim storeDestDesc As String = row("store_dest_desc").ToString()
        Dim dateCreated As String = CDate(row("create_date")).ToString("MMMM dd, yyyy")
        Dim status As Integer = CInt(row("status"))
        Dim remarks As String = row("remarks").ToString()
        Dim order_id As String = row("order_id").ToString()
        Dim grand_total As Decimal = CDec(row("grand_total_amount"))
        Dim receivedTimestamp As String = row("received_timestamp").ToString()
        Dim inTransitLabel As String = If(String.IsNullOrEmpty(receivedTimestamp), "In Transit", "Partial Received")

        '--- Transfer Lines

        'Dim table_transferL As DataTable = get_transfer_l(inputComp, dr, storeCodeOrigin, storeCodeDest)


        If inOrOut = "out" Then
            '==== OUT UI ====
            If cachedTransferOutLine Is Nothing OrElse forceRefresh Then
                cachedTransferOutLine = get_transfer_l(inputComp, storeCodeOrigin, inOrOut)
            End If
            table_transferLOut = GetTransferOutLine(dr)
            Dim statuses() As String = {
                                            "Created, Waiting for Approval",  ' 0
                                            "Approved/To pick",               ' 1
                                            "Ready to Ship",                  ' 2
                                            inTransitLabel,                   ' 3
                                            "Received",                       ' 4
                                            "", "", "", "",                   ' 5–8 optional
                                            "Cancelled",                      ' 9
                                            "Reroute"                         ' 10
                                        }
            Dim statusDesc As String = If(status >= 0 AndAlso status <= 10, statuses(status), "Unknown")

            With frmTransferData
                .lblTTStatus.Text = statusDesc
                .lblTTStatus.ForeColor = GetStatusColor(status, inOrOut)
                .txtTTDRNo.Text = drID
                .lblTTStoreDest.Text = storeDestDesc
                .txtTTRemarks.Text = remarks
                .txtTTOrderID.Text = order_id
                .txtTTGrandTotal.Text = grand_total
                .txtTTCreateDate.Text = dateCreated
                .lblTTStoreCodeDest.Text = storeCodeDest

                .dgTransferL.Rows.Clear()
                If table_transferLOut.Rows.Count > 0 Then
                    For Each r As DataRow In table_transferLOut.Rows
                        .dgTransferL.Rows.Add(r("company_code"), r("dr"), r("row_count"), r("sku_code"),
                                          r("gen_desc") + " " + r("col_desc") + " " + r("type_desc") + " " + r("stylecat_desc") + " " + r("stylevar_desc"),
                                          r("color_desc"),
                                          r("variant"),
                                          r("itemloc_origin"),
                                          r("qty"), r("approved_qty"), r("received_qty"), r("total_amount"), r("return_qty"), r("return_total_amount"))
                    Next
                End If
            End With

        ElseIf inOrOut = "in" Then
            '==== IN UI ====
            If cachedTransferInLine Is Nothing OrElse forceRefresh Then
                cachedTransferInLine = get_transfer_l(inputComp, storeCodeDest, inOrOut)
            End If
            Dim table_transferLIn As DataTable = GetTransferInLine(dr)
            Dim statuses() As String = {
                                            "Preparing", "Preparing",         ' 0–1
                                            "Ready to Ship",                  ' 2
                                            inTransitLabel,                   ' 3
                                            "Received",                       ' 4
                                            "Complete",                       ' 5
                                            "", "", "",                       ' 6–8
                                            "Cancelled"                       ' 9
                                        }
            Dim statusDesc As String = If(status >= 0 AndAlso status <= 9, statuses(status), "Unknown")

            With frmTransferInData
                .lblTTStatus.Text = statusDesc
                .lblTTStatus.ForeColor = GetStatusColor(status, inOrOut)
                .txtTTDRNo.Text = drID
                .lblTTStoreOrigin.Text = storeOriginDesc
                .txtTTRemarks.Text = remarks
                .txtTTCreateDate.Text = dateCreated
                .lblTTStoreCodeOrig.Text = storeCodeOrigin

                .dgTransferL.Rows.Clear()
                If table_transferLIn.Rows.Count > 0 Then

                    For Each r As DataRow In table_transferLIn.Rows
                        Dim qty = r("approved_qty")
                        If status = 9 Then
                            qty = r("qty")
                        End If
                        If storeCodeOrigin Like r("store_code_origin") Then
                            .dgTransferL.Rows.Add(r("company_code"), r("itemloc_origin"), r("dr"), r("row_count"), r("sku_code"),
                                                  r("gen_desc") + " " + r("col_desc") + " " + r("type_desc") + " " + r("stylecat_desc") + " " + r("stylevar_desc"),
                                                  r("color_desc"),
                                                  r("variant"),
                                                  qty, r("received_qty"))
                        End If
                    Next
                End If
            End With
        End If
    End Sub

    '---------------------------------------------
    '   HELPER: STATUS COLOR
    '---------------------------------------------
    Private Shared Function GetStatusColor(status As Integer, inOrOut As String) As Color
        Select Case status
            Case 0 : Return If(inOrOut = "out", Color.DimGray, Color.Black)
            Case 1 : Return Color.Orange
            Case 2 : Return Color.DodgerBlue
            Case 3 : Return Color.MediumSlateBlue
            Case 4 : Return Color.ForestGreen
            Case 5 : Return Color.DarkCyan
            Case 9 : Return Color.Crimson
            Case 10 : Return Color.DarkOrange
            Case Else : Return Color.Black
        End Select
    End Function


    Public Shared cachedPOHeader As DataTable = Nothing
    Public Shared cachedPOLine As DataTable = Nothing
    Public Shared dtItemListPO As DataTable 'TO MAKE IT PUBLIC TO USE ITS DATA

    Private Shared Function GetPOHeaderRow(po_num As String) As DataRow
        If cachedPOHeader Is Nothing OrElse cachedPOHeader.Rows.Count = 0 Then Return Nothing
        Dim filter As String = $"po_num = '{po_num.Replace("'", "''")}'"
        Dim foundRows() As DataRow = cachedPOHeader.Select(filter)
        Return If(foundRows.Length > 0, foundRows(0), Nothing)
    End Function
    Private Shared Function GetPOLineDataTable(po_num As String) As DataTable
        If cachedPOLine Is Nothing OrElse cachedPOLine.Rows.Count = 0 Then
            Return New DataTable()
        End If
        Dim filter As String = $"po_num = '{po_num.Replace("'", "''")}'"
        Dim foundRows() As DataRow = cachedPOLine.Select(filter)
        Return If(foundRows.Length > 0, foundRows.CopyToDataTable(), cachedPOLine.Clone())
    End Function

    Public Shared Sub show_po_h(Optional forceRefresh As Boolean = False)

        If cachedPOHeader Is Nothing OrElse forceRefresh Then
            cachedPOHeader = get_PO_Header(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)

            '=== Clear all grids ===
            ClearAllPOGrids()
            If cachedPOHeader.Rows.Count = 0 Then Exit Sub

            For Each Row As DataRow In cachedPOHeader.Rows
                Dim statusCode As String = Row("status").ToString()
                Dim createDate As String = CDate(Row("create_date")).ToString("MMMM dd, yyyy")
                Dim isReceived As Boolean = Row("is_received").ToString()

                ' Special handling for partial received
                Dim status1Label As String = "To Received"
                If statusCode = "1" AndAlso isReceived Then
                    statusCode = "partial"
                    status1Label = "Partial Received"
                End If

                ' Status list
                Dim statuses() As String = {
                    "For Approval", status1Label, "Received", "", "", "", "", "", "",
                    "Cancelled", "Reroute"
                }
                Dim statusDesc As String = If(IsNumeric(statusCode) AndAlso CInt(statusCode) >= 0 AndAlso CInt(statusCode) <= 10,
                                              statuses(CInt(statusCode)),
                                              If(statusCode = "partial", "Partial Received", "Unknown"))
                '=== Add to Main Grids ===
                'frmMain.dgPO.Rows.Add(Row("supplier_code"), Row("supplier_desc"), Row("po_num"), deliveryDate, statusDesc)

                ' === Add to StockOut Grids based on Status ===
                AddToPOGrid(statusCode, Row, statusDesc, createDate)
            Next
        End If
    End Sub

    Private Shared Sub ClearAllPOGrids()
        frmMain.dgPO.Rows.Clear()
        frmPurchaseOrder.dgPO1.Rows.Clear()
        frmPurchaseOrder.dgPO2.Rows.Clear()
        frmPurchaseOrder.dgPOPartial.Rows.Clear()
    End Sub
    Private Shared Sub AddToPOGrid(statusCode As String, Row As DataRow, statusDesc As String, createDate As String)
        Select Case statusCode
            Case "1"
                frmMain.dgPO.Rows.Add(Row("company_code"), statusCode, Row("store_code"), Row("supplier_desc"), Row("po_num"), createDate, statusDesc)
                frmPurchaseOrder.dgPO1.Rows.Add(Row("company_code"), statusCode, Row("store_code"), Row("supplier_desc"), Row("po_num"), createDate, statusDesc)
            Case "2"
                frmPurchaseOrder.dgPO2.Rows.Add(Row("company_code"), statusCode, Row("store_code"), Row("supplier_desc"), Row("po_num"), createDate, statusDesc)
            Case "partial"
                frmPurchaseOrder.dgPOPartial.Rows.Add(Row("company_code"), statusCode, Row("store_code"), Row("supplier_desc"), Row("po_num"), createDate, statusDesc)

        End Select
    End Sub


    Public Shared Sub show_po_l(ByVal po_num As String, Optional forceRefresh As Boolean = False)

        Dim po_HeaderRow As DataRow = GetPOHeaderRow(po_num)

        If po_HeaderRow Is Nothing Then
            MsgBox("No data found.")
            Exit Sub
        End If

        '--- Common fields
        Dim poNum As String = po_HeaderRow("po_num").ToString()
        Dim supplierDesc As String = po_HeaderRow("supplier_desc").ToString()
        Dim supplierCode As String = po_HeaderRow("supplier_code").ToString()
        Dim createdAt As String = CDate(po_HeaderRow("create_date")).ToString("MMMM dd, yyyy") + " " + po_HeaderRow("create_time").ToString()
        Dim isReceived As Boolean = po_HeaderRow("is_received").ToString()


        Dim statusCode As String = po_HeaderRow("status").ToString()
        Dim compCode As String = po_HeaderRow("company_code").ToString()
        Dim storeCode As String = po_HeaderRow("store_code").ToString()


        frmPurchaseOrderItems.txtPONum.Text = poNum
        frmPurchaseOrderItems.txtSupp.Text = supplierDesc
        frmPurchaseOrderItems.lblSuppCode.Text = supplierCode
        frmPurchaseOrderItems.lblCreatedAt.Text = createdAt

        'Special handling for partial received
        Dim status1Label As String = "To Received"
        If statusCode = "1" AndAlso isReceived Then
            statusCode = "partial"
            status1Label = "Partial Received"
        End If

        ' Status list
        Dim statuses() As String = {
            "For Approval", status1Label, "Received", "", "", "", "", "", "",
            "Cancelled", "Reroute"
        }

        Dim statusDesc As String = If(IsNumeric(statusCode) AndAlso CInt(statusCode) >= 0 AndAlso CInt(statusCode) <= 10,
                                              statuses(CInt(statusCode)),
                                              If(statusCode = "partial", "Partial Received", "Unknown"))
        frmPurchaseOrderItems.lblStatusDesc.Text = statusDesc
        frmPurchaseOrderItems.lblStatusDesc.ForeColor = GetStatusColor(statusCode)
        frmPurchaseOrderItems.selectedPOStatus = statusCode

        '--- Transfer Lines
        If cachedPOLine Is Nothing OrElse forceRefresh Then
            cachedPOLine = Get_PO_Line(compCode, storeCode)
        End If

        Dim po_LineTable As DataTable = GetPOLineDataTable(po_num)
        dtItemListPO = po_LineTable

        With frmPurchaseOrderItems
            .dgPOItemList.Rows.Clear()
            If po_LineTable.Rows.Count > 0 Then
                For Each itemRow As DataRow In po_LineTable.Rows
                    .dgPOItemList.Rows.Add(itemRow("row_count"), itemRow("sku_code"),
                                           itemRow("gen_desc") + " " + itemRow("col_desc") + " " + itemRow("type_desc") + " " + itemRow("stylecat_desc") + " " + itemRow("stylevar_desc"),
                                           itemRow("color_desc"),
                                           itemRow("variant"),
                                           itemRow("qty"), itemRow("po_unit_cost"), itemRow("received_qty"), itemRow("unit_cost"))
                Next
            End If
        End With


    End Sub

    '---------------------------------------------
    '   HELPER: STATUS COLOR
    '---------------------------------------------
    Private Shared Function GetStatusColor(status As String) As Color
        Select Case status
            Case 1 : Return Color.Orange
            Case "partial" : Return Color.DodgerBlue
            Case 2 : Return Color.ForestGreen
            Case Else : Return Color.Black
        End Select
    End Function


    Public Shared cachedPOReceivingHeaders As DataTable = Nothing
    Public Shared cachedPOReceivingLine As DataTable = Nothing

    Private Shared Function GetPOReceivingHeaderDataTable(po_num As String) As DataTable
        If cachedPOReceivingHeaders Is Nothing OrElse cachedPOReceivingHeaders.Rows.Count = 0 Then
            Return New DataTable()
        End If
        Dim filter As String = $"po_num = '{po_num.Replace("'", "''")}'"
        Dim foundRows() As DataRow = cachedPOReceivingHeaders.Select(filter)
        Return If(foundRows.Length > 0, foundRows.CopyToDataTable(), cachedPOReceivingHeaders.Clone())
    End Function

    Private Shared Function GetPOReceivingLineDataTable(id As String) As DataTable
        If cachedPOReceivingLine Is Nothing OrElse cachedPOReceivingLine.Rows.Count = 0 Then
            Return New DataTable()
        End If
        Dim filter As String = $"receiving_id = '{id.Replace("'", "''")}'"
        Dim foundRows() As DataRow = cachedPOReceivingLine.Select(filter)
        Return If(foundRows.Length > 0, foundRows.CopyToDataTable(), cachedPOReceivingLine.Clone())
    End Function

    Public Shared Sub show_poreceiving_h(ByVal po_num As String, Optional forceRefresh As Boolean = False)
        If cachedPOReceivingHeaders Is Nothing OrElse forceRefresh Then
            cachedPOReceivingHeaders = get_PO_ReceivingH(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)
        End If

        Dim receivingHeadersDT As DataTable = GetPOReceivingHeaderDataTable(po_num)
        '=== Clear all grids ===
        frmPurchaseOrderItems.dgPODR.Rows.Clear()
        If receivingHeadersDT.Rows.Count = 0 Then Exit Sub

        For Each Row As DataRow In receivingHeadersDT.Rows
            frmPurchaseOrderItems.dgPODR.Rows.Add(Row("id"), CDate(Row("delivery_date")).ToString("MMMM dd, yyyy"), Row("dr_reference_no"))
        Next
    End Sub

    Public Shared Sub show_poreceiving_l(ByVal receivingID As String, Optional forceRefresh As Boolean = False)
        If cachedPOReceivingLine Is Nothing OrElse forceRefresh Then
            cachedPOReceivingLine = get_PO_ReceivingL(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)
        End If

        Dim receivingLinesDT As DataTable = GetPOReceivingLineDataTable(receivingID)
        '=== Clear all grids ===
        frmPurchaseOrderItems.dgPODRItems.Rows.Clear()
        If receivingLinesDT.Rows.Count = 0 Then Exit Sub

        For Each Row As DataRow In receivingLinesDT.Rows
            frmPurchaseOrderItems.dgPODRItems.Rows.Add(Row("company_code"), Row("receiving_id"), Row("sku_link"), Row("po_num"), Row("sku_code"),
                                                        Row("gen_desc"),
                                                        Row("col_desc"),
                                                        Row("type_desc"),
                                                        Row("stylecat_desc") + " " + Row("stylevar_desc"),
                                                        Row("color_desc"),
                                                        Row("variant"),
                                                        Row("received_qty"), 1, Row("printed"), Row("skuprinted"))
        Next
    End Sub

    Public Shared Sub FilterDataGridViewByDate(dataGrid As DataGridView, fromDate As Date, toDate As Date)
        toDate = toDate.AddDays(1).AddSeconds(-1) ' include entire "to" date

        For Each row As DataGridViewRow In dataGrid.Rows
            If row.IsNewRow Then Continue For

            Dim rowDate As Date
            If Date.TryParse(row.Cells("mph_deliverydate").Value.ToString(), rowDate) Then
                row.Visible = (rowDate >= fromDate.ToString() AndAlso rowDate <= toDate.ToString())
            Else
                row.Visible = False
            End If
        Next
    End Sub

    Public Shared Sub itemBalanceSearch(searchText As String)
        If frmMain.dgStockItemBal.Rows.Count > 0 Then
            For Each row As DataGridViewRow In frmMain.dgStockItemBal.Rows
                If row.Cells("stock_skucode").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("stock_desc").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("stock_variant").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("stock_color").Value.ToString().ToLower().Contains(searchText.ToLower()) Then
                    row.Visible = True
                Else
                    row.Visible = False
                End If
            Next
        End If
    End Sub
End Class

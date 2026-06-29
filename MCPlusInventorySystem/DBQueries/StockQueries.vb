Imports MySql.Data.MySqlClient
Module StockQueries

    Public Function get_itembalance(ByVal inputComp As String, ByVal inputStore As String, ByVal isFrmPick As Boolean)
        Dim table As New DataTable()
        Try
            Dim sqlQuery As String = " SELECT 
                                            item.*,
                                            itemgen.gen_desc,
                                            itemcol.col_desc,
                                            itemtype.type_desc,
                                            itemstylecat.stylecat_desc,
                                            itemstylevar.stylevar_desc,
                                            itemcolor.color_desc,
                                            variation.variant,
                                            itembal.item_loc,
                                            CASE 
										        WHEN @isFrmPick THEN itembal.item_qty - IFNULL(picklist_summary.total_picked, 0)
										        ELSE itembal.item_qty 
										    END AS item_qty
                                        FROM item
                                        LEFT JOIN itemgen 
                                            ON itemgen.company_code = item.company_code
                                            AND itemgen.gen_code = item.gen_code
                                        LEFT JOIN itemcol
                                            ON itemcol.company_code = item.company_code
                                            AND itemcol.col_code = item.col_code
                                        LEFT JOIN itemtype
                                            ON itemtype.company_code = item.company_code
                                            AND itemtype.type_code = item.type_code
                                        LEFT JOIN itemstylecat
                                            ON itemstylecat.company_code = item.company_code
                                            AND itemstylecat.stylecat_code = item.stylecat_code
                                        LEFT JOIN itemstylevar
                                            ON itemstylevar.company_code = item.company_code
                                            AND itemstylevar.stylecat_code = item.stylecat_code
                                            AND itemstylevar.stylevar_code = item.stylevar_code
                                        LEFT JOIN itemcolor
                                            ON itemcolor.company_code = item.company_code
                                            AND itemcolor.color_code = item.color_code
                                        LEFT JOIN variation 
                                            ON item.parent_sku_code = variation.parent_sku_code 
                                            AND item.var_code = variation.var_code
                                            AND variation.company_code = item.company_code
                                        LEFT JOIN itembal
                                            ON item.sku_code  = itembal.sku_code      
                                            AND itembal.company_code = item.company_code  
                                        -- LEFT JOIN with subquery to get total qty_picked
                                        LEFT JOIN (
                                            SELECT 
                                                sku_code,
                                                company_code,
                                                store_code,
                                                item_loc,
                                                status,
                                                SUM(qty_picked) AS total_picked
                                            FROM picklist
                                            GROUP BY company_code, store_code, item_loc, sku_code, status
                                        ) AS picklist_summary
                                            ON itembal.sku_code = picklist_summary.sku_code
                                            AND itembal.company_code = picklist_summary.company_code
                                            AND itembal.store_code = picklist_summary.store_code
                                            AND itembal.item_loc = picklist_summary.item_loc
                                            AND picklist_summary.status = 1
                                        WHERE itembal.company_code = @comp 
                                          AND itembal.store_code = @store;"


            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@store", inputStore)
                        .Parameters.AddWithValue("@isFrmPick", isFrmPick)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter
                        adapter.SelectCommand = sqlComm
                        adapter.Fill(table)
                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        InvDBConn.Close()
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function

    'ADD ITEM BALANCE ???? ALWAYS adding stock to Queuing code Q001
    Public Function add_itembalance(conn As MySqlConnection, trans As MySqlTransaction,
                                comp As String, store As String, item_loc As String, skuCode As String, addQty As Integer) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE itembal 
                                  SET item_qty = (item_qty + @addQty), replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND store_code = @store  
                                    AND item_loc = @item_loc  
                                    AND sku_code = @skuCode"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", comp)
                sqlComm.Parameters.AddWithValue("@store", store)
                sqlComm.Parameters.AddWithValue("@item_loc", item_loc)
                sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                sqlComm.Parameters.AddWithValue("@addQty", addQty)

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function


    ' decrease_itembalance
    Public Function decrease_itembalance(conn As MySqlConnection, trans As MySqlTransaction,
                                     comp As String, store As String, itemLoc As String, skuCode As String, decreaseQty As Integer) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE itembal 
                                  SET item_qty = item_qty - @decreaseQty, replication_stat = 1
                                  WHERE company_code = @comp AND store_code = @store AND item_loc = @itemLoc AND sku_code = @skuCode"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", comp)
                sqlComm.Parameters.AddWithValue("@store", store)
                sqlComm.Parameters.AddWithValue("@itemLoc", itemLoc)
                sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                sqlComm.Parameters.AddWithValue("@decreaseQty", decreaseQty)

                Return sqlComm.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            MsgBox("Error in decrease_itembalance: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    ' Check if itembalance and Picklist Qty is Valid
    Public Function itemBal_picklist_isValidQty(comp As String, store As String, itemLoc As String, skuCode As String, decreaseQty As Integer) As Boolean
        Try
            Dim sqlQuery As String =
            "SELECT 
                (itembal.item_qty - IFNULL(picklist_summary.total_picked, 0)) - @decreaseQty AS computed_qty
             FROM itembal
             LEFT JOIN (
                 SELECT 
                     sku_code,
                     company_code,
                     store_code,
                     item_loc,
                     status,
                     SUM(qty_picked) AS total_picked
                 FROM picklist
                 WHERE status = 1
                 GROUP BY company_code, store_code, item_loc, sku_code
             ) AS picklist_summary
                 ON itembal.sku_code = picklist_summary.sku_code
                 AND itembal.company_code = picklist_summary.company_code
                 AND itembal.store_code = picklist_summary.store_code
                 AND itembal.item_loc = picklist_summary.item_loc
             WHERE itembal.company_code = @comp 
               AND itembal.store_code = @store
               AND itembal.item_loc = @itemLoc
               AND itembal.sku_code = @skuCode
             LIMIT 1;"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                sqlConn.Open() ' ✅ IMPORTANT: Open connection

                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@store", store)
                    sqlComm.Parameters.AddWithValue("@itemLoc", itemLoc)
                    sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                    sqlComm.Parameters.AddWithValue("@decreaseQty", decreaseQty)

                    Dim result = sqlComm.ExecuteScalar()

                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        Dim computedQty As Integer = Convert.ToInt32(result)
                        Return computedQty >= 0
                    Else
                        ' SKU not found or no stock data
                        Return False
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error in itemBal_picklist_isValidQty: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function itembalIsGreaterOrEqual(comp As String, store As String, itemLoc As String, skuCode As String, qtyToShip As Integer) As Boolean
        Try
            Dim sqlQuery As String =
                                    "SELECT 
                                        CASE WHEN itembal.item_qty >= @qtyToShip THEN 1 ELSE 0 END AS is_greater_or_equal
                                     FROM itembal
                                     WHERE itembal.company_code = @comp 
                                       AND itembal.store_code = @store
                                       AND itembal.item_loc = @itemLoc
                                       AND itembal.sku_code = @skuCode
                                     LIMIT 1;"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                sqlConn.Open()

                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@store", store)
                    sqlComm.Parameters.AddWithValue("@itemLoc", itemLoc)
                    sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                    sqlComm.Parameters.AddWithValue("@qtyToShip", qtyToShip)

                    Dim result = sqlComm.ExecuteScalar()

                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        Return Convert.ToInt32(result) = 1
                    Else
                        ' SKU not found
                        Return False
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error in itembalIsGreaterOrEqual: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function


    Public Function InsertNotExistingItemBal() As Boolean
        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand("sp_insert_itembal_all_stores", sqlConn)

                    sqlComm.CommandType = CommandType.StoredProcedure
                    sqlConn.Open()
                    sqlComm.ExecuteNonQuery()

                    Return True
                End Using
            End Using

        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function



    'Supplier Feature

    Public Function get_suppliers(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM supplier WHERE company_code like @comp ORDER BY supplier.supplier_desc ASC"
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter
                        adapter.SelectCommand = sqlComm
                        adapter.Fill(table)

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        InvDBConn.Close()
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function

    Public Function create_supplier(company_code As String, supplier_code As String, supplier_desc As String,
                                    supplier_tin As String, supplier_addr As String, supplier_contact As String,
                                    supplier_email As String, payment_terms As String, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO supplier (company_code, supplier_code, supplier_desc, supplier_tin, supplier_addr, supplier_contact, supplier_email, payment_terms, create_date, create_time, create_by, replication_stat) 
                                  VALUES (@comp, @scode, @sdesc, @stin, @saddr, @scontact, @semail, @spterms, @createDate, @createTime, @createBy, 1)"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@scode", supplier_code)
                    sqlComm.Parameters.AddWithValue("@sdesc", supplier_desc)
                    sqlComm.Parameters.AddWithValue("@stin", supplier_tin)
                    sqlComm.Parameters.AddWithValue("@saddr", supplier_addr)
                    sqlComm.Parameters.AddWithValue("@scontact", supplier_contact)
                    sqlComm.Parameters.AddWithValue("@semail", supplier_email)
                    sqlComm.Parameters.AddWithValue("@spterms", payment_terms)
                    sqlComm.Parameters.AddWithValue("@createDate", DateTime.Now.ToString("yyyy-MM-dd"))
                    sqlComm.Parameters.AddWithValue("@createTime", DateTime.Now.ToString("HH:mm:ss"))
                    sqlComm.Parameters.AddWithValue("@createBy", create_by)

                    ' Execute insert
                    sqlConn.Open()
                    Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        Return True ' Successfully inserted
                    Else
                        Return False ' No rows inserted
                    End If
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function update_supplier(company_code As String, supplier_code As String, supplier_desc As String,
                                supplier_tin As String, supplier_addr As String, supplier_contact As String,
                                supplier_email As String, payment_terms As String) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE supplier 
                                  SET supplier_desc = @sdesc, 
                                      supplier_tin = @stin, 
                                      supplier_addr = @saddr, 
                                      supplier_contact = @scontact, 
                                      supplier_email = @semail, 
                                      payment_terms = @spterms,
                                      replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND supplier_code = @scode"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@sdesc", supplier_desc)
                    sqlComm.Parameters.AddWithValue("@stin", supplier_tin)
                    sqlComm.Parameters.AddWithValue("@saddr", supplier_addr)
                    sqlComm.Parameters.AddWithValue("@scontact", supplier_contact)
                    sqlComm.Parameters.AddWithValue("@semail", supplier_email)
                    sqlComm.Parameters.AddWithValue("@spterms", payment_terms)

                    ' WHERE parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@scode", supplier_code)

                    ' Execute update
                    sqlConn.Open()
                    Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        Return True ' Successfully updated
                    Else
                        Return False ' No rows updated
                    End If
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function


    Public Function check_supplier_code_exists(ByVal comp As String, ByVal supplier_code As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM supplier WHERE company_code = @comp AND supplier_code = @supplier_code"

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@supplier_code", supplier_code)

                    sqlConn.Open()
                    Dim count As Integer = Convert.ToInt32(sqlComm.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error checking brand_code: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function



    'MANUAL PURCHASE

    Public Function GenerateMPurchaseID(ByVal compCode As String) As Integer


        Dim sqlQuery As String = "  SELECT MAX(mpurchase_id) 
                                    FROM mpurchase_h 
                                    WHERE company_code = @comp 
                                      AND LEFT(mpurchase_id, 4) = @year"

        Dim currentYear As String = Date.Now.ToString("yyyy")
        Dim newID As Integer = 0

        Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
            Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                sqlComm.Parameters.AddWithValue("@comp", compCode)
                sqlComm.Parameters.AddWithValue("@year", currentYear)

                sqlConn.Open()
                Dim result = sqlComm.ExecuteScalar()
                If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                    newID = Convert.ToInt32(result) + 1
                Else
                    newID = CInt(currentYear & "0001")
                End If
            End Using
        End Using

        Return newID
    End Function

    Public Function create_mpurchase_h(conn As MySqlConnection, trans As MySqlTransaction,
                                   ByVal inputCom As String,
                                   ByVal mpurchaseID As String,
                                   ByVal supplier_code As String,
                                   ByVal store_code As String,
                                   ByVal reference_no As String,
                                   ByVal dr_date As Date,
                                   ByVal delivery_date As Date,
                                   ByVal status As String,
                                   ByVal remarks As String,
                                   ByVal create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO mpurchase_h 
                (company_code, mpurchase_id, supplier_code, store_code, reference_no, dr_date, delivery_date, status, remarks, create_date, create_time, create_by, replication_stat) 
                VALUES (@comp, @mpid, @sup, @store, @ref, @drdate, @deldate, @stat, @rem, @cdate, @ctime, @cby, @rep)"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", inputCom)
                sqlComm.Parameters.AddWithValue("@mpid", mpurchaseID)
                sqlComm.Parameters.AddWithValue("@sup", supplier_code)
                sqlComm.Parameters.AddWithValue("@store", store_code)
                sqlComm.Parameters.AddWithValue("@ref", reference_no)
                sqlComm.Parameters.AddWithValue("@drdate", dr_date.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@deldate", delivery_date.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@stat", status)
                sqlComm.Parameters.AddWithValue("@rem", remarks)
                sqlComm.Parameters.AddWithValue("@cdate", Date.Now.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@ctime", Date.Now.ToString("HH:mm:ss"))
                sqlComm.Parameters.AddWithValue("@cby", create_by)
                sqlComm.Parameters.AddWithValue("@rep", 1)

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function



    Public Function create_mpurchase_l(conn As MySqlConnection, trans As MySqlTransaction,
                                   ByVal inputCom As String,
                                   ByVal mpurchaseID As Integer,
                                   ByVal rowCount As Integer,
                                   ByVal supplier_code As String,
                                   ByVal store_code As String,
                                   ByVal sku_code As String,
                                   ByVal qty As Integer,
                                   ByVal unit_cost As Decimal,
                                   ByVal create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO mpurchase_l 
                (company_code, mpurchase_id, row_count, supplier_code, store_code, sku_code, qty, unit_cost, printed, create_date, create_time, create_by, replication_stat)
                VALUES (@comp, @mpid, @row, @sup, @store, @sku, @qty, @cost, 0, @cdate, @ctime, @cby, @rep)"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", inputCom)
                sqlComm.Parameters.AddWithValue("@mpid", mpurchaseID)
                sqlComm.Parameters.AddWithValue("@row", rowCount)
                sqlComm.Parameters.AddWithValue("@sup", supplier_code)
                sqlComm.Parameters.AddWithValue("@store", store_code)
                sqlComm.Parameters.AddWithValue("@sku", sku_code)
                sqlComm.Parameters.AddWithValue("@qty", qty)
                sqlComm.Parameters.AddWithValue("@cost", unit_cost)
                sqlComm.Parameters.AddWithValue("@cdate", Date.Now.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@ctime", Date.Now.ToString("HH:mm:ss"))
                sqlComm.Parameters.AddWithValue("@cby", create_by)
                sqlComm.Parameters.AddWithValue("@rep", 1)

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function



    'RECENT STOCK IN
    Public Function get_mpurchase_h(ByVal inputComp As String, ByVal storeCode As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT 
                                            mpurchase_h.*, 
                                            supplier.supplier_desc
                                        FROM 
                                            mpurchase_h
                                        LEFT JOIN 
                                            supplier ON supplier.supplier_code = mpurchase_h.supplier_code
                                                   AND supplier.company_code = mpurchase_h.company_code
                                        WHERE 
                                            mpurchase_h.company_code LIKE @comp 
                                                   AND mpurchase_h.store_code LIKE @storeCode 
                                        ORDER BY mpurchase_h.delivery_date  DESC"
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@storeCode", storeCode)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter
                        adapter.SelectCommand = sqlComm
                        adapter.Fill(table)

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        InvDBConn.Close()
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function

    Public Function get_mpurchase_h_data(ByVal inputComp As String, ByVal storeCode As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT 
                                            mpurchase_h.*, 
                                            supplier.supplier_desc
                                        FROM 
                                            mpurchase_h
                                        LEFT JOIN 
                                            supplier ON supplier.supplier_code = mpurchase_h.supplier_code
                                                   AND supplier.company_code = mpurchase_h.company_code
                                        WHERE 
                                            mpurchase_h.company_code LIKE @comp 
                                        AND mpurchase_h.store_code LIKE @storeCode "
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        '.Parameters.AddWithValue("@mpID", mpID)
                        .Parameters.AddWithValue("@storeCode", storeCode)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter
                        adapter.SelectCommand = sqlComm
                        adapter.Fill(table)

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        InvDBConn.Close()
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function

    Public Function get_mpurchase_l(ByVal inputComp As String, ByVal storeCode As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT 
                                        mpurchase_h.supplier_code ,
                                        mpurchase_h.reference_no ,
                                        mpurchase_h.dr_date,
                                        mpurchase_h.delivery_date,
                                        mpurchase_h.status,
                                        mpurchase_h.remarks,
                                        supplier.supplier_desc,
                                        mpurchase_l.mpurchase_id ,
                                        mpurchase_l.company_code,
                                        mpurchase_l.sku_code,
                                        mpurchase_l.row_count ,
                                        mpurchase_l.qty,
                                        mpurchase_l.unit_cost,
                                        mpurchase_l.printed,
                                        item.sku_link, 
                                        item.printed AS skuprinted,
                                        itemgen.gen_desc,
                                        itemcol.col_desc,
                                        itemtype.type_desc,
                                        itemstylecat.stylecat_desc,
                                        itemstylevar.stylevar_desc,
                                        itemcolor.color_desc,
                                        variation.variant
                                    FROM 
                                        mpurchase_l
                                    LEFT JOIN 
                                        mpurchase_h 
                                        ON mpurchase_h.mpurchase_id = mpurchase_l.mpurchase_id
                                        AND mpurchase_h.company_code = mpurchase_l.company_code
                                    LEFT JOIN 
                                        supplier 
                                        ON supplier.supplier_code = mpurchase_l.supplier_code
                                        AND supplier.company_code = mpurchase_l.company_code
                                    LEFT JOIN item
                                        ON mpurchase_l.sku_code = item.sku_code 
                                        AND mpurchase_l.company_code = item.company_code

                                        LEFT JOIN itemgen 
                                            ON itemgen.company_code = item.company_code
                                            AND itemgen.gen_code = item.gen_code
                                        LEFT JOIN itemcol
                                            ON itemcol.company_code = item.company_code
                                            AND itemcol.col_code = item.col_code
                                        LEFT JOIN itemtype
                                            ON itemtype.company_code = item.company_code
                                            AND itemtype.type_code = item.type_code
                                        LEFT JOIN itemstylecat
                                            ON itemstylecat.company_code = item.company_code
                                            AND itemstylecat.stylecat_code = item.stylecat_code
                                        LEFT JOIN itemstylevar
                                            ON itemstylevar.company_code = item.company_code
                                            AND itemstylevar.stylecat_code = item.stylecat_code
                                            AND itemstylevar.stylevar_code = item.stylevar_code
                                        LEFT JOIN itemcolor
                                            ON itemcolor.company_code = item.company_code
                                            AND itemcolor.color_code = item.color_code
                                        LEFT JOIN variation 
                                            ON item.parent_sku_code = variation.parent_sku_code 
                                            AND item.var_code = variation.var_code
                                            AND variation.company_code = item.company_code
                                    WHERE 
                                        mpurchase_l.company_code = @comp 
                                        AND mpurchase_l.store_code = @storeCode 
                                    ORDER BY 
	                                    mpurchase_l.row_count ASC;"
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@storeCode", storeCode)
                        '.Parameters.AddWithValue("@mpurchaseID", mpurchaseID)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter
                        adapter.SelectCommand = sqlComm
                        adapter.Fill(table)

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        InvDBConn.Close()
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function


    'TRANSFER 
    Public Function GenerateDR(ByVal compCode As String, ByVal storeCode As String) As Integer


        Dim sqlQuery As String = "  SELECT MAX(dr) 
                                    FROM transfer_h 
                                    WHERE company_code = @comp AND store_code_origin = @storeCode
                                      AND LEFT(dr, 4) = @year"

        Dim currentYear As String = Date.Now.ToString("yyyy")
        Dim newID As Integer = 0

        Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
            Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                sqlComm.Parameters.AddWithValue("@comp", compCode)
                sqlComm.Parameters.AddWithValue("@storeCode", storeCode)
                sqlComm.Parameters.AddWithValue("@year", currentYear)

                sqlConn.Open()
                Dim result = sqlComm.ExecuteScalar()
                If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                    newID = Convert.ToInt32(result) + 1
                Else
                    newID = CInt(currentYear & "0001")
                End If
            End Using
        End Using

        Return newID
    End Function


    Public Function create_transfer_h(conn As MySqlConnection, trans As MySqlTransaction,
                                  inputCom As String, storeOrig As String, storeDest As String,
                                  dr As Integer, status As String, remarks As String, order_id As String, grand_total_amount As String,
                                  create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO transfer_h (company_code, store_code_origin, store_code_dest, dr, status, remarks, order_id, grand_total_amount, create_date, create_time, create_by, replication_stat) 
                                  VALUES (@comp, @storeOrig, @storeDest, @dr, @status, @remarks, @order_id, @grand_total_amount, @cdate, @ctime, @cby, @rep)"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", inputCom)
                sqlComm.Parameters.AddWithValue("@storeOrig", storeOrig)
                sqlComm.Parameters.AddWithValue("@storeDest", storeDest)
                sqlComm.Parameters.AddWithValue("@dr", dr)
                sqlComm.Parameters.AddWithValue("@status", status)
                sqlComm.Parameters.AddWithValue("@remarks", remarks)
                sqlComm.Parameters.AddWithValue("@order_id", order_id)
                sqlComm.Parameters.AddWithValue("@grand_total_amount", grand_total_amount)
                sqlComm.Parameters.AddWithValue("@cdate", Date.Now.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@ctime", Date.Now.ToString("HH:mm:ss"))
                sqlComm.Parameters.AddWithValue("@cby", create_by)
                sqlComm.Parameters.AddWithValue("@rep", 1)

                Return sqlComm.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            MsgBox("Error in create_transfer_h: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function


    Public Function create_transfer_l(conn As MySqlConnection, trans As MySqlTransaction,
                                  inputCom As String, storeOrig As String, storeDest As String,
                                  dr As Integer, locOrig As String, locDest As String,
                                  rowCount As Integer, skuCode As String, qty As Integer, total_amount As Integer, status As Integer, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO transfer_l (company_code, store_code_origin, store_code_dest, dr, itemloc_origin, itemloc_dest, row_count, sku_code, qty, total_amount, approved_qty, status, create_date, create_time, create_by, replication_stat)
                                  VALUES (@comp, @storeOrig, @storeDest, @dr, @locOrig, @locDest, @rowCount, @skuCode, @qty, @total_amount, 0, @status, @cdate, @ctime, @cby, @rep)"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", inputCom)
                sqlComm.Parameters.AddWithValue("@storeOrig", storeOrig)
                sqlComm.Parameters.AddWithValue("@storeDest", storeDest)
                sqlComm.Parameters.AddWithValue("@dr", dr)
                sqlComm.Parameters.AddWithValue("@locOrig", locOrig)
                sqlComm.Parameters.AddWithValue("@locDest", locDest)
                sqlComm.Parameters.AddWithValue("@rowCount", rowCount)
                sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                sqlComm.Parameters.AddWithValue("@qty", qty)
                sqlComm.Parameters.AddWithValue("@total_amount", total_amount)
                'sqlComm.Parameters.AddWithValue("@receivedQty", receivedQty)
                sqlComm.Parameters.AddWithValue("@status", status)
                sqlComm.Parameters.AddWithValue("@cdate", Date.Now.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@ctime", Date.Now.ToString("HH:mm:ss"))
                sqlComm.Parameters.AddWithValue("@cby", create_by)
                sqlComm.Parameters.AddWithValue("@rep", 1)

                Return sqlComm.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            MsgBox("Error in create_transfer_l: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    'WHEN SUBMIT REROUTE
    Public Function update_transfer_l_status(conn As MySqlConnection, trans As MySqlTransaction,
                                         ByVal comp As String,
                                         ByVal storeCodeOrigin As String,
                                         ByVal storeCodeDest As String,
                                         ByVal dr As String,
                                         ByVal status As Integer,
                                         Optional ByVal received_timestamp As Object = Nothing) As Boolean
        Try
            Dim setClauses As New List(Of String)
            setClauses.Add("status = @status")

            If received_timestamp IsNot Nothing Then
                setClauses.Add("received_timestamp = @received_timestamp")
            End If

            Dim sqlQuery As String = $"
                                            UPDATE transfer_l 
                                            SET {String.Join(", ", setClauses)} , replication_stat = 1
                                            WHERE company_code = @comp 
                                              AND store_code_origin = @storeCodeOrigin 
                                              AND store_code_dest = @storeCodeDest 
                                              AND dr = @dr
                                        "

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                With sqlComm
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@status", status)

                    If received_timestamp IsNot Nothing Then
                        .Parameters.AddWithValue("@received_timestamp", received_timestamp)
                    End If

                    .Parameters.AddWithValue("@comp", comp)
                    .Parameters.AddWithValue("@storeCodeOrigin", storeCodeOrigin)
                    .Parameters.AddWithValue("@storeCodeDest", storeCodeDest)
                    .Parameters.AddWithValue("@dr", dr)
                End With

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As Exception
            MsgBox("Error updating transfer_l: " & ex.Message)
            Return False
        End Try
    End Function

    'UPDATE PER ROW (Reroute and Qty Approval)
    Public Function update_transfer_l_row(conn As MySqlConnection, trans As MySqlTransaction,
                                      ByVal comp As String,
                                      ByVal storeCodeOrigin As String,
                                      ByVal storeCodeDest As String,
                                      ByVal itemLoc As String,
                                      ByVal dr As String,
                                      ByVal status As Integer,
                                      ByVal skuCode As String,
                                      Optional ByVal approvedQty As Object = Nothing,
                                      Optional ByVal newQty As Object = Nothing,
                                      Optional ByVal newTotalAmount As Object = Nothing,
                                      Optional ByVal rowcount As Object = Nothing,
                                      Optional ByVal receivedQty As Object = Nothing,
                                      Optional ByVal received_timestamp As Object = Nothing) As Boolean
        Try
            ' Base SET clause (status is always required)
            Dim setClauses As New List(Of String)
            setClauses.Add("status = @status")

            If approvedQty IsNot Nothing Then
                setClauses.Add("approved_qty = @approvedQty")
            End If
            If newQty IsNot Nothing Then
                setClauses.Add("qty = @newQty")
            End If
            If newTotalAmount IsNot Nothing Then
                setClauses.Add("total_amount = @newTotalAmount")
            End If
            If rowcount IsNot Nothing Then
                setClauses.Add("row_count = @rowcount")
            End If
            If receivedQty IsNot Nothing Then
                setClauses.Add("received_qty = @receivedQty")
            End If
            If received_timestamp IsNot Nothing Then
                setClauses.Add("received_timestamp = @received_timestamp")
            End If


            ' Build final SQL dynamically
            Dim sqlQuery As String = "
                                        UPDATE transfer_l 
                                        SET " & String.Join(", ", setClauses) & " , replication_stat = 1
                                        WHERE company_code = @comp
                                          AND store_code_origin = @storeCodeOrigin
                                          AND store_code_dest = @storeCodeDest
                                          AND itemloc_origin = @itemLoc
                                          AND dr = @dr
                                          AND sku_code = @skuCode"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                With sqlComm
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@status", status)

                    If approvedQty IsNot Nothing Then
                        .Parameters.AddWithValue("@approvedQty", approvedQty)
                    End If
                    If newQty IsNot Nothing Then
                        .Parameters.AddWithValue("@newQty", newQty)
                    End If
                    If newTotalAmount IsNot Nothing Then
                        .Parameters.AddWithValue("@newTotalAmount", newTotalAmount)
                    End If
                    If rowcount IsNot Nothing Then
                        .Parameters.AddWithValue("@rowcount", rowcount)
                    End If
                    If receivedQty IsNot Nothing Then
                        .Parameters.AddWithValue("@receivedQty", receivedQty)
                    End If
                    If received_timestamp IsNot Nothing Then
                        .Parameters.AddWithValue("@received_timestamp", received_timestamp)
                    End If

                    .Parameters.AddWithValue("@comp", comp)
                    .Parameters.AddWithValue("@storeCodeOrigin", storeCodeOrigin)
                    .Parameters.AddWithValue("@storeCodeDest", storeCodeDest)
                    .Parameters.AddWithValue("@itemLoc", itemLoc)
                    .Parameters.AddWithValue("@dr", dr)
                    .Parameters.AddWithValue("@skuCode", skuCode)
                End With

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As Exception
            MsgBox("Error updating transfer_l row: " & ex.Message)
            Return False
        End Try
    End Function


    Public Function delete_transfer_l(conn As MySqlConnection,
                                  trans As MySqlTransaction,
                                  comp As String,
                                  storeCodeOrigin As String,
                                  storeCodeDest As String,
                                  itemLocOrigin As String,
                                  dr As String,
                                  skuCode As String) As Boolean
        Dim sqlQuery As String =
        "DELETE FROM transfer_l " & vbCrLf &
        "WHERE company_code = @comp " & vbCrLf &
        "  AND store_code_origin = @storeCodeOrigin " & vbCrLf &
        "  AND store_code_dest = @storeCodeDest " & vbCrLf &
        "  AND itemloc_origin = @itemLocOrigin " & vbCrLf &
        "  AND dr = @dr " & vbCrLf &
        "  AND sku_code = @skuCode"

        Try
            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", comp)
                sqlComm.Parameters.AddWithValue("@storeCodeOrigin", storeCodeOrigin)
                sqlComm.Parameters.AddWithValue("@storeCodeDest", storeCodeDest)
                sqlComm.Parameters.AddWithValue("@itemLocOrigin", itemLocOrigin)
                sqlComm.Parameters.AddWithValue("@dr", dr)
                sqlComm.Parameters.AddWithValue("@skuCode", skuCode)

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()

                ' Optional: i-check kung may row na natanggal
                Return rowsAffected > 0
            End Using

        Catch ex As MySqlException
            MsgBox("MySQL Error: " & ex.Message)
            Return False
        Catch ex As Exception
            MsgBox("General Error: " & ex.Message)
            Return False
        End Try
    End Function


    Public Function insertto_picklist(conn As MySqlConnection, trans As MySqlTransaction,
                                  inputCom As String, storeCode As String, itemLoc As String,
                                  refID As Integer, skuCode As String, qtyPicked As Integer, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO picklist (company_code, store_code, item_loc, reference_id, sku_code, qty_picked, status, create_date, create_time, create_by, replication_stat)
                                  VALUES (@comp, @storeCode, @itemLoc, @refID, @skuCode, @qtyPicked, @status, @cdate, @ctime, @cby, @rep)"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", inputCom)
                sqlComm.Parameters.AddWithValue("@storeCode", storeCode)
                sqlComm.Parameters.AddWithValue("@itemLoc", itemLoc)
                sqlComm.Parameters.AddWithValue("@refID", refID)
                sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                sqlComm.Parameters.AddWithValue("@qtyPicked", qtyPicked)
                sqlComm.Parameters.AddWithValue("@status", 1)
                sqlComm.Parameters.AddWithValue("@cdate", Date.Now.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@ctime", Date.Now.ToString("HH:mm:ss"))
                sqlComm.Parameters.AddWithValue("@cby", create_by)
                sqlComm.Parameters.AddWithValue("@rep", 1)

                Return sqlComm.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            MsgBox("Error in insertto_picklist: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function delete_from_picklist(conn As MySqlConnection, trans As MySqlTransaction,
                                     inputCom As String, storeCode As String, refID As Integer) As Boolean
        Try
            Dim sqlQuery As String = "DELETE FROM picklist WHERE company_code = @comp AND store_code = @storeCode AND reference_id = @refID"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", inputCom)
                sqlComm.Parameters.AddWithValue("@storeCode", storeCode)
                sqlComm.Parameters.AddWithValue("@refID", refID)

                Return sqlComm.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            MsgBox("Error in delete_from_picklist: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function update_picklist_stat(conn As MySqlConnection, trans As MySqlTransaction,
                                     inputCom As String, storeCode As String, refID As Integer, status As Integer) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE picklist SET status = @status, replication_stat = 1 WHERE company_code = @comp AND store_code = @storeCode AND reference_id = @refID"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", inputCom)
                sqlComm.Parameters.AddWithValue("@storeCode", storeCode)
                sqlComm.Parameters.AddWithValue("@refID", refID)
                sqlComm.Parameters.AddWithValue("@status", status)

                Return sqlComm.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            MsgBox("Error in delete_from_picklist: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    'ORIGIN LIST (STOCK OUT TRANSFER LIST)
    Public Function get_transfer_h(ByVal inputComp As String, ByVal storeCode As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT 
                                            transfer_h.company_code,
                                            transfer_h.status,
                                            transfer_h.store_code_origin,
                                            transfer_h.store_code_dest,
                                            transfer_h.dr, 
                                            transfer_h.remarks,
                                            transfer_h.order_id,
                                            transfer_h.grand_total_amount,
                                            transfer_h.create_by,
                                            transfer_h.create_date,
                                            transfer_h.approved_by,
                                            transfer_h.approved_timestamp,
                                            transfer_h.received_timestamp,
                                            s_origin.store_desc AS store_origin_desc,
                                            s_dest.store_desc AS store_dest_desc
                                        FROM 
                                            transfer_h
                                        LEFT JOIN store AS s_origin 
                                            ON s_origin.store_code = transfer_h.store_code_origin
                                            AND s_origin.company_code = transfer_h.company_code
                                        LEFT JOIN store AS s_dest 
                                            ON s_dest.store_code = transfer_h.store_code_dest
                                            AND s_dest.company_code = transfer_h.company_code
                                        WHERE 
                                           transfer_h.company_code = @comp 
                                                   AND transfer_h.store_code_origin LIKE @storeCode 
                                        ORDER BY create_date  DESC"
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@storeCode", storeCode)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter
                        adapter.SelectCommand = sqlComm
                        adapter.Fill(table)

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        InvDBConn.Close()
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function


    'DESTINATION LIST (STOCK IN TRANSFER LIST)
    Public Function get_transfer_h_dest(ByVal inputComp As String, ByVal storeCode As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT 
                                            transfer_h.company_code,
                                            transfer_h.status,
                                            transfer_h.store_code_origin,
                                            transfer_h.store_code_dest,
                                            transfer_h.dr,
                                            transfer_h.remarks,
                                            transfer_h.order_id,
                                            transfer_h.grand_total_amount,
                                            transfer_h.create_date,
                                            transfer_h.approved_timestamp,
                                            transfer_h.received_timestamp,
                                            s_origin.store_desc AS store_origin_desc,
                                            s_dest.store_desc AS store_dest_desc
                                        FROM 
                                            transfer_h
                                        LEFT JOIN store AS s_origin 
                                            ON s_origin.store_code = transfer_h.store_code_origin
                                            AND s_origin.company_code = transfer_h.company_code
                                        LEFT JOIN store AS s_dest 
                                            ON s_dest.store_code = transfer_h.store_code_dest
                                            AND s_dest.company_code = transfer_h.company_code
                                        WHERE 
                                           transfer_h.company_code = @comp 
                                                   AND transfer_h.store_code_dest LIKE @storeCode AND (transfer_h.status BETWEEN 1 AND 5 OR status = 9)
                                        ORDER BY create_date  DESC"
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@storeCode", storeCode)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter
                        adapter.SelectCommand = sqlComm
                        adapter.Fill(table)

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        InvDBConn.Close()
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function

    'Public Function update_transfer_h_status(conn As MySqlConnection, trans As MySqlTransaction, ByVal comp As String,
    '                                  ByVal storeCodeOrigin As String,
    '                                  ByVal storeCodeDest As String,
    '                                  ByVal dr As String,
    '                                  ByVal newStatus As Integer) As Boolean
    '    Try
    '        Dim sqlQuery As String = "UPDATE transfer_h SET status = @newStatus  
    '                              WHERE company_code LIKE @comp AND store_code_origin = @storeCodeOrigin 
    '                              AND store_code_dest = @storeCodeDest AND dr = @dr"

    '        Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
    '            With sqlComm
    '                .CommandType = CommandType.Text
    '                .Parameters.AddWithValue("@newStatus", newStatus)
    '                .Parameters.AddWithValue("@comp", comp)
    '                .Parameters.AddWithValue("@storeCodeOrigin", storeCodeOrigin)
    '                .Parameters.AddWithValue("@storeCodeDest", storeCodeDest)
    '                .Parameters.AddWithValue("@dr", dr)
    '            End With

    '            Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
    '            Return rowsAffected > 0
    '        End Using

    '    Catch ex As Exception
    '        MsgBox("Error updating transfer_h: " & ex.Message)
    '        Return False
    '    End Try
    'End Function

    Public Function update_transfer_h_status(conn As MySqlConnection, trans As MySqlTransaction,
                                         ByVal comp As String,
                                         ByVal storeCodeOrigin As String,
                                         ByVal storeCodeDest As String,
                                         ByVal dr As String,
                                         ByVal newStatus As Integer,
                                         Optional ByVal approved_timestamp As Object = Nothing,
                                         Optional ByVal received_timestamp As Object = Nothing,
                                         Optional ByVal approved_by As Object = Nothing) As Boolean
        Try
            Dim setClauses As New List(Of String)
            setClauses.Add("status = @newStatus")

            ' Conditional fields
            If approved_timestamp IsNot Nothing Then
                setClauses.Add("approved_timestamp = @approved_timestamp")
            End If
            If received_timestamp IsNot Nothing Then
                setClauses.Add("received_timestamp = @received_timestamp")
            End If
            If approved_by IsNot Nothing Then
                setClauses.Add("approved_by = @approved_by")
            End If

            Dim sqlQuery As String = $"
                                        UPDATE transfer_h 
                                        SET {String.Join(", ", setClauses)}, replication_stat = 1
                                        WHERE company_code = @comp 
                                          AND store_code_origin = @storeCodeOrigin 
                                          AND store_code_dest = @storeCodeDest 
                                          AND dr = @dr
                                    "

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                With sqlComm
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@newStatus", newStatus)

                    If approved_timestamp IsNot Nothing Then
                        .Parameters.AddWithValue("@approved_timestamp", approved_timestamp)
                    End If

                    If received_timestamp IsNot Nothing Then
                        .Parameters.AddWithValue("@received_timestamp", received_timestamp)
                    End If

                    If approved_by IsNot Nothing Then
                        .Parameters.AddWithValue("@approved_by", approved_by)
                    End If

                    .Parameters.AddWithValue("@comp", comp)
                    .Parameters.AddWithValue("@storeCodeOrigin", storeCodeOrigin)
                    .Parameters.AddWithValue("@storeCodeDest", storeCodeDest)
                    .Parameters.AddWithValue("@dr", dr)
                End With

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As Exception
            MsgBox("Error updating transfer_h: " & ex.Message)
            Return False
        End Try
    End Function


    Public Function get_transfer_h_data(ByVal inputComp As String, ByVal dr As String, ByVal storeCodeOrig As String, ByVal storeCodeDest As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT 
                                            transfer_h.company_code,
                                            transfer_h.status,
                                            transfer_h.store_code_origin,
                                            transfer_h.store_code_dest,
                                            transfer_h.dr,
                                            transfer_h.remarks,
                                            transfer_h.create_date,
                                            transfer_h.approved_timestamp,
                                            transfer_h.received_timestamp,
                                            s_origin.store_desc AS store_origin_desc,
                                            s_dest.store_desc AS store_dest_desc
                                        FROM 
                                            transfer_h
                                        LEFT JOIN store AS s_origin 
                                            ON s_origin.store_code = transfer_h.store_code_origin
                                            AND s_origin.company_code = transfer_h.company_code
                                        LEFT JOIN store AS s_dest 
                                            ON s_dest.store_code = transfer_h.store_code_dest
                                            AND s_dest.company_code = transfer_h.company_code
                                        WHERE 
                                            transfer_h.company_code LIKE @comp 
                                            AND transfer_h.dr LIKE @dr
                                            AND transfer_h.store_code_origin LIKE @storeCodeOrig
                                            AND transfer_h.store_code_dest LIKE @storeCodeDest "
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@dr", dr)
                        .Parameters.AddWithValue("@storeCodeOrig", storeCodeOrig)
                        .Parameters.AddWithValue("@storeCodeDest", storeCodeDest)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter
                        adapter.SelectCommand = sqlComm
                        adapter.Fill(table)

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        InvDBConn.Close()
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function

    Public Function get_transfer_l(ByVal inputComp As String,
                                   ByVal storeCode As String,
                                   ByVal inOrOut As String) As DataTable
        Dim table As New DataTable()

        Try
            ' piliin kung alin ang gagamitin sa WHERE
            Dim storeFilter As String
            If inOrOut.ToLower() = "out" Then
                storeFilter = "transfer_l.store_code_origin = @storeCode"
            ElseIf inOrOut.ToLower() = "in" Then
                storeFilter = "transfer_l.store_code_dest = @storeCode"
            Else
                Throw New ArgumentException("Invalid inOrOut parameter. Use 'in' or 'out'.")
            End If

            Dim sqlQuery As String = $"
                                        SELECT 
                                            transfer_l.company_code,
                                            transfer_l.store_code_origin,
                                            transfer_l.store_code_dest,
                                            transfer_l.itemloc_origin,
                                            transfer_l.itemloc_dest,
                                            transfer_l.dr,
                                            transfer_l.sku_code,
                                            transfer_l.row_count,
                                            transfer_l.qty, 
                                            transfer_l.approved_qty, 
                                            transfer_l.received_qty, 
                                            transfer_l.total_amount, 
                                            itemgen.gen_desc,
                                            itemcol.col_desc,
                                            itemtype.type_desc,
                                            itemstylecat.stylecat_desc,
                                            itemstylevar.stylevar_desc,
                                            itemcolor.color_desc,
                                            variation.variant,
                                            transfer_return.return_qty,
                                            transfer_return.return_total_amount
                                        FROM transfer_l
                                        LEFT JOIN transfer_h 
                                            ON transfer_h.dr = transfer_l.dr
                                            AND transfer_h.company_code = transfer_l.company_code
                                            AND transfer_h.store_code_origin = transfer_l.store_code_origin
                                            AND transfer_h.store_code_dest = transfer_l.store_code_dest
                                        LEFT JOIN transfer_return
                                            ON transfer_return.dr = transfer_l.dr
                                            AND transfer_return.company_code = transfer_l.company_code
                                            AND transfer_return.store_code_origin = transfer_l.store_code_origin
                                            AND transfer_return.store_code_dest = transfer_l.store_code_dest
                                            AND transfer_return.sku_code = transfer_l.sku_code
                                        LEFT JOIN item
                                            ON transfer_l.sku_code = item.sku_code 
                                            AND transfer_l.company_code = item.company_code
                                        LEFT JOIN itemgen 
                                            ON itemgen.company_code = item.company_code
                                            AND itemgen.gen_code = item.gen_code
                                        LEFT JOIN itemcol
                                            ON itemcol.company_code = item.company_code
                                            AND itemcol.col_code = item.col_code
                                        LEFT JOIN itemtype
                                            ON itemtype.company_code = item.company_code
                                            AND itemtype.type_code = item.type_code
                                        LEFT JOIN itemstylecat
                                            ON itemstylecat.company_code = item.company_code
                                            AND itemstylecat.stylecat_code = item.stylecat_code
                                        LEFT JOIN itemstylevar
                                            ON itemstylevar.company_code = item.company_code
                                            AND itemstylevar.stylecat_code = item.stylecat_code
                                            AND itemstylevar.stylevar_code = item.stylevar_code
                                        LEFT JOIN itemcolor
                                            ON itemcolor.company_code = item.company_code
                                            AND itemcolor.color_code = item.color_code
                                        LEFT JOIN variation 
                                            ON item.parent_sku_code = variation.parent_sku_code 
                                            AND item.var_code = variation.var_code
                                            AND variation.company_code = item.company_code
                                        WHERE 
                                            transfer_l.company_code = @comp 
                                            AND {storeFilter}
                                        ORDER BY transfer_l.row_count ASC;"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@storeCode", storeCode)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter(sqlComm)
                        adapter.Fill(table)
                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        InvDBConn.Close()
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function


    'PURCHASE ORDER
    Public Function get_PO_Header(ByVal inputComp As String, ByVal storeCode As String) As DataTable
        Dim table As New DataTable()
        Try
            ' Base query
            Dim sqlQuery As String = "
                                        SELECT 
                                            purchase_order_h.*, 
                                            supplier.supplier_desc
                                        FROM 
                                            purchase_order_h
                                        LEFT JOIN 
                                            supplier ON supplier.supplier_code = purchase_order_h.supplier_code
                                                      AND supplier.company_code = purchase_order_h.company_code
                                        WHERE 
                                            purchase_order_h.company_code LIKE @comp 
                                            AND purchase_order_h.store_code LIKE @storeCode
                                            AND purchase_order_h.status IN (1, 2)
                                    "



            ' Order
            'sqlQuery &= " ORDER BY purchase_order_h.delivery_timestamp DESC, purchase_order_h.po_num DESC"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@storeCode", storeCode)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter(sqlComm)
                        adapter.Fill(table)
                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function

    Public Function Get_PO_Line(ByVal inputComp As String, ByVal storeCode As String) As DataTable
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = $"
                                        SELECT 
                                            purchase_order_l.*,
                                            itemgen.gen_desc,
                                            itemcol.col_desc,
                                            itemtype.type_desc,
                                            itemstylecat.stylecat_desc,
                                            itemstylevar.stylevar_desc,
                                            itemcolor.color_desc,
                                            variation.variant
                                        FROM purchase_order_l
                                        LEFT JOIN purchase_order_h 
                                            ON purchase_order_h.po_num = purchase_order_l.po_num
                                            AND purchase_order_h.company_code = purchase_order_l.company_code
                                            AND purchase_order_h.store_code = purchase_order_l.store_code
                                        LEFT JOIN item
                                            ON purchase_order_l.sku_code = item.sku_code 
                                            AND purchase_order_l.company_code = item.company_code
                                        LEFT JOIN itemgen 
                                            ON itemgen.company_code = item.company_code
                                            AND itemgen.gen_code = item.gen_code
                                        LEFT JOIN itemcol
                                            ON itemcol.company_code = item.company_code
                                            AND itemcol.col_code = item.col_code
                                        LEFT JOIN itemtype
                                            ON itemtype.company_code = item.company_code
                                            AND itemtype.type_code = item.type_code
                                        LEFT JOIN itemstylecat
                                            ON itemstylecat.company_code = item.company_code
                                            AND itemstylecat.stylecat_code = item.stylecat_code
                                        LEFT JOIN itemstylevar
                                            ON itemstylevar.company_code = item.company_code
                                            AND itemstylevar.stylecat_code = item.stylecat_code
                                            AND itemstylevar.stylevar_code = item.stylevar_code
                                        LEFT JOIN itemcolor
                                            ON itemcolor.company_code = item.company_code
                                            AND itemcolor.color_code = item.color_code
                                        LEFT JOIN variation 
                                            ON item.parent_sku_code = variation.parent_sku_code 
                                            AND item.var_code = variation.var_code
                                            AND variation.company_code = item.company_code 
                                        WHERE 
                                            purchase_order_l.company_code = @comp 
                                            AND purchase_order_l.store_code = @storeCode
                                            AND purchase_order_l.status IN (1, 2)
                                        ORDER BY purchase_order_l.row_count ASC;"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@storeCode", storeCode)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter(sqlComm)
                        adapter.Fill(table)
                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        InvDBConn.Close()
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function

    Public Function Update_PO_Header(conn As MySqlConnection, trans As MySqlTransaction,
                                 ByVal comp As String,
                                 ByVal storeCode As String,
                                 ByVal poNum As String,
                                 ByVal newStatus As Integer,
                                 Optional ByVal isReceived As Object = Nothing, Optional ByVal fdateReceived As Date? = Nothing) As Boolean
        Try
            Dim setClauses As New List(Of String)
            setClauses.Add("status = @newStatus")

            ' Conditional fields
            If isReceived IsNot Nothing Then
                setClauses.Add("is_received = @is_received")
            End If
            If fdateReceived.HasValue Then
                setClauses.Add("first_date_delivered = @fdateReceived")
            End If
            Dim sqlQuery As String = $"UPDATE purchase_order_h 
                                        SET {String.Join(", ", setClauses)}, replication_stat = 1
                                        WHERE company_code = @comp 
                                          AND store_code = @storeCode 
                                          AND po_num = @poNum"
            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                With sqlComm
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@newStatus", newStatus)
                    If isReceived IsNot Nothing Then
                        .Parameters.AddWithValue("@is_received", isReceived)
                    End If
                    If fdateReceived.HasValue Then
                        .Parameters.AddWithValue("@fdateReceived", fdateReceived.Value)
                    End If

                    .Parameters.AddWithValue("@comp", comp)
                    .Parameters.AddWithValue("@storeCode", storeCode)
                    .Parameters.AddWithValue("@poNum", poNum)
                End With

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As Exception
            MsgBox("Error updating purchase_order_h: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function Update_PO_Line(conn As MySqlConnection, trans As MySqlTransaction,
                                      ByVal comp As String,
                                      ByVal storeCode As String,
                                      ByVal poNum As String,
                                      ByVal skuCode As String,
                                      Optional ByVal newStatus As Object = Nothing,
                                      Optional ByVal receivedQty As Object = Nothing,
                                      Optional ByVal unitCost As Object = Nothing) As Boolean
        Try
            ' Build dynamic SET clauses based on passed parameters
            Dim setClauses As New List(Of String)

            If newStatus IsNot Nothing Then
                setClauses.Add("status = @status")
            End If
            If receivedQty IsNot Nothing Then
                setClauses.Add("received_qty = @receivedQty")
            End If
            If unitCost IsNot Nothing Then
                setClauses.Add("unit_cost = @unitCost")
            End If

            ' If no columns to update, exit
            If setClauses.Count = 0 Then
                Return False
            End If

            ' Build final SQL query
            Dim sqlQuery As String =
                "UPDATE purchase_order_l " & vbCrLf &
                "   SET " & String.Join(", ", setClauses) & vbCrLf &
                ", replication_stat = 1 WHERE company_code = @comp" & vbCrLf &
                "   AND store_code = @storeCode" & vbCrLf &
                "   AND po_num = @poNum" & vbCrLf &
                "   AND sku_code = @skuCode"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                With sqlComm
                    .CommandType = CommandType.Text

                    If newStatus IsNot Nothing Then
                        .Parameters.AddWithValue("@status", newStatus)
                    End If
                    If receivedQty IsNot Nothing Then
                        .Parameters.AddWithValue("@receivedQty", receivedQty)
                    End If
                    If unitCost IsNot Nothing Then
                        .Parameters.AddWithValue("@unitCost", unitCost)
                    End If

                    ' WHERE clause parameters
                    .Parameters.AddWithValue("@comp", comp)
                    .Parameters.AddWithValue("@storeCode", storeCode)
                    .Parameters.AddWithValue("@poNum", poNum)
                    .Parameters.AddWithValue("@skuCode", skuCode)
                End With

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As Exception
            MsgBox("Error updating purchase_order_l row: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function GetNextPOReceivingId(conn As MySqlConnection, trans As MySqlTransaction) As Integer
        Dim sql As String = "SELECT IFNULL(MAX(id),0) + 1 FROM po_receiving_h"
        Using cmd As New MySqlCommand(sql, conn, trans)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Public Function InsertPOReceivingHeader(conn As MySqlConnection, trans As MySqlTransaction,
                                        ByVal id As Integer,
                                        ByVal company_code As String,
                                        ByVal store_code As String,
                                        ByVal supplier_code As String,
                                        ByVal po_num As Integer,
                                        ByVal dr_ref_num As String,
                                        ByVal deliveryDate As Date,
                                        ByVal remarks As String,
                                        ByVal create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO po_receiving_h 
                                    (id, company_code, store_code, supplier_code, po_num, dr_reference_no, delivery_date, remarks, create_date, create_time, create_by, replication_stat) 
                                  VALUES 
                                    (@id, @company_code, @store_code, @supplier_code, @po_num, @dr_ref_num, @deliveryDate, @remarks, @cdate, @ctime, @create_by, 1)"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@id", id)
                sqlComm.Parameters.AddWithValue("@company_code", company_code)
                sqlComm.Parameters.AddWithValue("@store_code", store_code)
                sqlComm.Parameters.AddWithValue("@supplier_code", supplier_code)
                sqlComm.Parameters.AddWithValue("@po_num", po_num)
                sqlComm.Parameters.AddWithValue("@dr_ref_num", dr_ref_num)
                sqlComm.Parameters.AddWithValue("@deliveryDate", deliveryDate.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@remarks", remarks)
                sqlComm.Parameters.AddWithValue("@cdate", Date.Now.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@ctime", Date.Now.ToString("HH:mm:ss"))
                sqlComm.Parameters.AddWithValue("@create_by", create_by)

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using
        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function


    Public Function InsertPOReceivingLine(conn As MySqlConnection, trans As MySqlTransaction,
                               ByVal receivingId As Integer,
                               ByVal inputCom As String,
                               ByVal store_code As String,
                               ByVal supplier_code As String,
                               ByVal po_num As String, ByVal dr_ref_num As String,
                               ByVal sku_code As String,
                               ByVal qty As Integer, ByVal deliveryDate As Date,
                               ByVal create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO po_receiving_l
              (receiving_id,company_code, store_code, supplier_code, po_num, dr_reference_no, sku_code, received_qty, printed, delivery_date, create_date, create_time, create_by, replication_stat)
                VALUES (@receivingId, @inputCom, @store_code, @supplier_code, @po_num, @dr_ref_num, @sku_code, @qty, 0, @deliveryDate, @cdate, @ctime, @create_by, 1)"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@receivingId", receivingId)
                sqlComm.Parameters.AddWithValue("@inputCom", inputCom)
                sqlComm.Parameters.AddWithValue("@store_code", store_code)
                sqlComm.Parameters.AddWithValue("@po_num", po_num)
                sqlComm.Parameters.AddWithValue("@dr_ref_num", dr_ref_num)
                sqlComm.Parameters.AddWithValue("@sku_code", sku_code)
                sqlComm.Parameters.AddWithValue("@supplier_code", supplier_code)
                sqlComm.Parameters.AddWithValue("@qty", qty)
                sqlComm.Parameters.AddWithValue("@deliveryDate", deliveryDate.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@cdate", Date.Now.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@ctime", Date.Now.ToString("HH:mm:ss"))
                sqlComm.Parameters.AddWithValue("@create_by", create_by)

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function get_PO_ReceivingH(ByVal inputComp As String, ByVal storeCode As String) As DataTable
        Dim table As New DataTable()
        Try
            ' Base query
            Dim sqlQuery As String = "
                                        SELECT 
                                            po_receiving_h.*
                                        FROM 
                                            po_receiving_h
                                        WHERE 
                                            po_receiving_h.company_code LIKE @comp 
                                            AND po_receiving_h.store_code LIKE @storeCode
                                    "

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@storeCode", storeCode)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter(sqlComm)
                        adapter.Fill(table)
                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function

    Public Function get_PO_ReceivingL(ByVal inputComp As String, ByVal storeCode As String) As DataTable
        Dim table As New DataTable()
        Try
            ' Base query
            Dim sqlQuery As String = "
                                        SELECT 
                                            po_receiving_l.*,
                                            item.sku_link,
                                            item.printed AS skuprinted,
                                            itemgen.gen_desc,
                                            itemcol.col_desc,
                                            itemtype.type_desc,
                                            itemstylecat.stylecat_desc,
                                            itemstylevar.stylevar_desc,
                                            itemcolor.color_desc,
                                            variation.variant
                                        FROM po_receiving_l
                                        LEFT JOIN purchase_order_h 
                                            ON purchase_order_h.po_num = po_receiving_l.po_num
                                            AND purchase_order_h.company_code = po_receiving_l.company_code
                                            AND purchase_order_h.store_code = po_receiving_l.store_code
                                        LEFT JOIN item
                                            ON po_receiving_l.sku_code = item.sku_code 
                                            AND po_receiving_l.company_code = item.company_code
                                        LEFT JOIN itemgen 
                                            ON itemgen.company_code = po_receiving_l.company_code
                                            AND itemgen.gen_code = item.gen_code
                                        LEFT JOIN itemcol
                                            ON itemcol.company_code = po_receiving_l.company_code
                                            AND itemcol.col_code = item.col_code
                                        LEFT JOIN itemtype
                                            ON itemtype.company_code = po_receiving_l.company_code
                                            AND itemtype.type_code = item.type_code
                                        LEFT JOIN itemstylecat
                                            ON itemstylecat.company_code = po_receiving_l.company_code
                                            AND itemstylecat.stylecat_code = item.stylecat_code
                                        LEFT JOIN itemstylevar
                                            ON itemstylevar.company_code = po_receiving_l.company_code
                                            AND itemstylevar.stylecat_code = item.stylecat_code
                                            AND itemstylevar.stylevar_code = item.stylevar_code
                                        LEFT JOIN itemcolor
                                            ON itemcolor.company_code = po_receiving_l.company_code
                                            AND itemcolor.color_code = item.color_code
                                        LEFT JOIN variation 
                                            ON item.parent_sku_code = variation.parent_sku_code 
                                            AND item.var_code = variation.var_code
                                            AND variation.company_code = po_receiving_l.company_code 
                                        WHERE 
                                            po_receiving_l.company_code LIKE @comp 
                                            AND po_receiving_l.store_code LIKE @storeCode
                                        ORDER BY po_receiving_l.id ASC;
                                    "

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@storeCode", storeCode)
                    End With
                    Try
                        Dim adapter As New MySqlDataAdapter(sqlComm)
                        adapter.Fill(table)
                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                    End Try
                End Using
            End Using
            InvDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            InvDBConn.Close()
        End Try

        Return table
    End Function


    Public Function getItemTotalStocks(ByVal inputComp As String, ByVal storeCode As String) As String
        Dim totalQty As Integer = 0
        Dim sqlQuery As String = "
                                    SELECT SUM(item_qty) AS total_stock_qty
                                    FROM itembal
                                    WHERE company_code LIKE @comp
                                      AND store_code LIKE @storeCode
                                "

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                sqlConn.Open()
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    ' Add wildcards if you really mean LIKE
                    sqlComm.Parameters.AddWithValue("@comp", inputComp)
                    sqlComm.Parameters.AddWithValue("@storeCode", storeCode)

                    Dim result = sqlComm.ExecuteScalar()
                    If result IsNot DBNull.Value Then
                        totalQty = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return totalQty.ToString()
    End Function

    Public Function get_fastmoving(ByVal inputComp As String, ByVal storeCode As String) As DataTable
        Dim table As New DataTable()

        Dim sqlQuery As String = "
                                    SELECT
                                        sh.store AS store_code,
                                        sl.sku_code,
                                        par.item_desc,
                                        bra.brand_desc,
                                        IF(var.variant IS NULL OR var.variant = '', var.application, CONCAT(var.variant, ' - ', var.application)) AS variation,
                                        SUM(sl.qty) AS total_qty_sold
                                    FROM salesl sl
                                    LEFT JOIN salesh sh
                                        ON sh.transaction_id = sl.transaction_id
                                        AND sh.company_code = sl.company_code
                                    LEFT JOIN inventory_db.item itm
                                        ON itm.sku_code = sl.sku_code
                                        AND itm.company_code = sl.company_code
                                    LEFT JOIN inventory_db.parent_sku par
                                        ON par.parent_sku_code = LEFT(itm.sku_code,9)
                                        AND par.company_code = itm.company_code
                                    LEFT JOIN inventory_db.variation var
                                        ON CONCAT(var.parent_sku_code, var.var_code) = itm.sku_code
                                    LEFT JOIN inventory_db.brand bra
                                        ON bra.company_code = itm.company_code
                                        AND bra.brand_code = itm.brand_code
                                    WHERE sh.company_code = @comp
                                        AND sh.store = @storeCode
                                    GROUP BY
                                        sh.store,
                                        sl.sku_code,
                                        par.item_desc,
                                        bra.brand_desc,
                                        var.variant,
                                        var.application
                                    ORDER BY total_qty_sold DESC
                                    LIMIT 20;
                                "

        Try
            Using sqlConn As MySqlConnection = SalesDBConn()
                sqlConn.Open()
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", inputComp)
                    sqlComm.Parameters.AddWithValue("@storeCode", storeCode)

                    Using adapter As New MySqlDataAdapter(sqlComm)
                        adapter.Fill(table)
                    End Using
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox("Database error: " & ex.Message)
        Catch ex As Exception
            MsgBox("General error: " & ex.Message)
        End Try

        Return table
    End Function

    Public Function getToReceivedPOCount(ByVal inputComp As String, ByVal storeCode As String) As String
        Dim totalQty As Integer = 0
        Dim sqlQuery As String = "
                                    SELECT COUNT(*) AS total_open_po
                                    FROM purchase_order_h 
                                    WHERE company_code LIKE @comp
                                        AND store_code LIKE @storeCode 
                                        AND is_received = 0 AND status = 1;
                                "

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                sqlConn.Open()
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    ' Add wildcards if you really mean LIKE
                    sqlComm.Parameters.AddWithValue("@comp", inputComp)
                    sqlComm.Parameters.AddWithValue("@storeCode", storeCode)

                    Dim result = sqlComm.ExecuteScalar()
                    If result IsNot DBNull.Value Then
                        totalQty = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return totalQty.ToString()
    End Function

    Public Function getToReceivedTransfer(ByVal inputComp As String, ByVal storeCode As String) As String
        Dim totalQty As Integer = 0
        Dim sqlQuery As String = "
                                    SELECT COUNT(*) AS total_to_receive_transfer
                                    FROM transfer_h 
                                    WHERE company_code LIKE @comp
                                        AND store_code_dest LIKE @storeCode   AND status = 3 AND received_timestamp IS null;                 
                                "

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                sqlConn.Open()
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    ' Add wildcards if you really mean LIKE
                    sqlComm.Parameters.AddWithValue("@comp", inputComp)
                    sqlComm.Parameters.AddWithValue("@storeCode", storeCode)

                    Dim result = sqlComm.ExecuteScalar()
                    If result IsNot DBNull.Value Then
                        totalQty = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return totalQty.ToString()
    End Function

    Public Function getForApprovalTransferToOtherStore(ByVal inputComp As String, ByVal storeCode As String) As String
        Dim totalQty As Integer = 0
        Dim sqlQuery As String = "
                                    SELECT COUNT(*) AS total_to_receive_transfer
                                    FROM transfer_h 
                                    WHERE company_code LIKE @comp
                                        AND store_code_origin LIKE @storeCode   AND status = 0 AND received_timestamp IS null;                 
                                "

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                sqlConn.Open()
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    ' Add wildcards if you really mean LIKE
                    sqlComm.Parameters.AddWithValue("@comp", inputComp)
                    sqlComm.Parameters.AddWithValue("@storeCode", storeCode)

                    Dim result = sqlComm.ExecuteScalar()
                    If result IsNot DBNull.Value Then
                        totalQty = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return totalQty.ToString()
    End Function



    'STOCK MOVEMENT
    Public Function create_movement(conn As MySqlConnection, trans As MySqlTransaction,
                               ByVal inputCom As String, ByVal storeCode As String, ByVal location As String,
                               ByVal sku_code As String,
                               ByVal qty As String,
                               ByVal origin As String,
                               ByVal destination As String,
                               ByVal itemloc_origin As String,
                               ByVal itemloc_dest As String,
                               ByVal mvt_code As String,
                               ByVal doc_no As String,
                               ByVal create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO itemmvt (company, store_code, location, sku_code, item_qty, origin, destination, itemloc_origin, itemloc_dest, mvt_code, doc_no, create_date, create_time, create_by, replication_stat) 
                                                    VALUES (@comp, @store, @location, @sku, @qty, @origin, @destination, @itemloc_origin, @itemloc_dest, @mvt_code, @doc_no, @cdate, @ctime, @cby, @rep);"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", inputCom)
                sqlComm.Parameters.AddWithValue("@store", storeCode)
                sqlComm.Parameters.AddWithValue("@location", location)
                sqlComm.Parameters.AddWithValue("@sku", sku_code)
                sqlComm.Parameters.AddWithValue("@qty", qty)
                sqlComm.Parameters.AddWithValue("@origin", origin)
                sqlComm.Parameters.AddWithValue("@destination", destination)
                sqlComm.Parameters.AddWithValue("@itemloc_origin", itemloc_origin)
                sqlComm.Parameters.AddWithValue("@itemloc_dest", itemloc_dest)
                sqlComm.Parameters.AddWithValue("@mvt_code", mvt_code)
                sqlComm.Parameters.AddWithValue("@doc_no", doc_no)

                sqlComm.Parameters.AddWithValue("@cdate", Date.Now.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@ctime", Date.Now.ToString("HH:mm:ss"))
                sqlComm.Parameters.AddWithValue("@cby", create_by)
                sqlComm.Parameters.AddWithValue("@rep", 1)

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function create_transfer_return(conn As MySqlConnection, trans As MySqlTransaction,
                              inputCom As String, storeOrig As String, storeDest As String,
                              dr As Integer, locOrig As String, locDest As String,
                              rowCount As Integer, skuCode As String, return_qty As Integer, return_total_amount As Decimal, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO transfer_return (company_code, store_code_origin, store_code_dest, dr, itemloc_origin, itemloc_dest, row_count, sku_code, return_qty, return_total_amount, create_date, create_time, create_by, replication_stat)
                                  VALUES (@comp, @storeOrig, @storeDest, @dr, @locOrig, @locDest, @rowCount, @skuCode, @return_qty, @return_total_amount, @cdate, @ctime, @cby, @rep)"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", inputCom)
                sqlComm.Parameters.AddWithValue("@storeOrig", storeOrig)
                sqlComm.Parameters.AddWithValue("@storeDest", storeDest)
                sqlComm.Parameters.AddWithValue("@dr", dr)
                sqlComm.Parameters.AddWithValue("@locOrig", locOrig)
                sqlComm.Parameters.AddWithValue("@locDest", locDest)
                sqlComm.Parameters.AddWithValue("@rowCount", rowCount)
                sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                sqlComm.Parameters.AddWithValue("@return_qty", return_qty)
                sqlComm.Parameters.AddWithValue("@return_total_amount", return_total_amount)
                'sqlComm.Parameters.AddWithValue("@receivedQty", receivedQty)
                sqlComm.Parameters.AddWithValue("@cdate", Date.Now.ToString("yyyy-MM-dd"))
                sqlComm.Parameters.AddWithValue("@ctime", Date.Now.ToString("HH:mm:ss"))
                sqlComm.Parameters.AddWithValue("@cby", create_by)
                sqlComm.Parameters.AddWithValue("@rep", 1)

                Return sqlComm.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            MsgBox("Error in create_transfer_l: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function delete_transfer_return(conn As MySqlConnection,
                              trans As MySqlTransaction,
                              comp As String,
                              storeCodeOrigin As String,
                              storeCodeDest As String,
                              itemLocOrigin As String,
                              dr As String,
                              skuCode As String) As Boolean
        Dim sqlQuery As String =
        "DELETE FROM transfer_return " & vbCrLf &
        "WHERE company_code = @comp " & vbCrLf &
        "  AND store_code_origin = @storeCodeOrigin " & vbCrLf &
        "  AND store_code_dest = @storeCodeDest " & vbCrLf &
        "  AND itemloc_origin = @itemLocOrigin " & vbCrLf &
        "  AND dr = @dr " & vbCrLf &
        "  AND sku_code = @skuCode"

        Try
            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                sqlComm.Parameters.AddWithValue("@comp", comp)
                sqlComm.Parameters.AddWithValue("@storeCodeOrigin", storeCodeOrigin)
                sqlComm.Parameters.AddWithValue("@storeCodeDest", storeCodeDest)
                sqlComm.Parameters.AddWithValue("@itemLocOrigin", itemLocOrigin)
                sqlComm.Parameters.AddWithValue("@dr", dr)
                sqlComm.Parameters.AddWithValue("@skuCode", skuCode)

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()

                ' Optional: i-check kung may row na natanggal
                Return rowsAffected > 0
            End Using

        Catch ex As MySqlException
            MsgBox("MySQL Error: " & ex.Message)
            Return False
        Catch ex As Exception
            MsgBox("General Error: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function update_transfer_return_row(conn As MySqlConnection, trans As MySqlTransaction,
                                  ByVal comp As String,
                                  ByVal storeCodeOrigin As String,
                                  ByVal storeCodeDest As String,
                                  ByVal itemLoc As String,
                                  ByVal dr As String,
                                  ByVal skuCode As String,
                                  Optional ByVal newReturnQty As Object = Nothing,
                                  Optional ByVal newReturnTotalAmount As Object = Nothing,
                                  Optional ByVal rowcount As Object = Nothing) As Boolean
        Try
            ' Base SET clause (status is always required)
            Dim setClauses As New List(Of String)

            If newReturnQty IsNot Nothing Then
                setClauses.Add("return_qty = @newReturnQty")
            End If
            If newReturnTotalAmount IsNot Nothing Then
                setClauses.Add("return_total_amount = @newReturnTotalAmount")
            End If
            If rowcount IsNot Nothing Then
                setClauses.Add("row_count = @rowcount")
            End If


            ' Build final SQL dynamically
            Dim sqlQuery As String = "
                                        UPDATE transfer_return 
                                        SET " & String.Join(", ", setClauses) & " , replication_stat = 1
                                        WHERE company_code = @comp
                                          AND store_code_origin = @storeCodeOrigin
                                          AND store_code_dest = @storeCodeDest
                                          AND itemloc_origin = @itemLoc
                                          AND dr = @dr
                                          AND sku_code = @skuCode"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)
                With sqlComm
                    .CommandType = CommandType.Text

                    If newReturnQty IsNot Nothing Then
                        .Parameters.AddWithValue("@newReturnQty", newReturnQty)
                    End If
                    If newReturnTotalAmount IsNot Nothing Then
                        .Parameters.AddWithValue("@newReturnTotalAmount", newReturnTotalAmount)
                    End If
                    If rowcount IsNot Nothing Then
                        .Parameters.AddWithValue("@rowcount", rowcount)
                    End If

                    .Parameters.AddWithValue("@comp", comp)
                    .Parameters.AddWithValue("@storeCodeOrigin", storeCodeOrigin)
                    .Parameters.AddWithValue("@storeCodeDest", storeCodeDest)
                    .Parameters.AddWithValue("@itemLoc", itemLoc)
                    .Parameters.AddWithValue("@dr", dr)
                    .Parameters.AddWithValue("@skuCode", skuCode)
                End With

                Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As Exception
            MsgBox("Error updating transfer_l row: " & ex.Message)
            Return False
        End Try
    End Function

End Module

Imports MySql.Data.MySqlClient

Module ItemPriceQueries

    'DATABASE CONNECTION

    'EXECUTE EVENT
    Public Function InsertNotExistingItemPrice() As Boolean
        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand("sp_insert_itemprice_all_stores", sqlConn)

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

    'GET ITEM PRICE
    Public Function get_itemPrice(ByVal inputComp As String, ByVal inputStore As String)
        Dim table As New DataTable()
        Try
            Dim sqlQuery As String = "SELECT 
                                        item.*,
                                        itemgen.gen_desc,
                                        itemcol.col_desc,
                                        itemtype.type_desc,
                                        itemstylecat.stylecat_desc,
                                        itemstylevar.stylevar_desc,
                                        itemcolor.color_desc,
                                        variation.variant,
                                        itemprice.unit_price,
                                        itemprice.retail_price
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
                                    LEFT JOIN itemprice
                                        ON item.sku_code  = itemprice.sku_code      
                                        AND itemprice.company_code = item.company_code
                                        AND itemprice.store_code = @store
                                    WHERE item.company_code = @comp
                                    -- ✅ IMPORTANT
                                    GROUP BY item.sku_code;"
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@store", inputStore)
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

    Public Function update_itemprice(comp, inputStore, skuCode, unitPrice, retailPrice) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE itemprice 
                                  SET unit_price = @unitPrice, retail_price = @retailPrice, replication_stat = 1
                                  WHERE company_code = @comp AND store_code = @inputStore AND sku_code = @skuCode"
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@inputStore", inputStore)
                    sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                    sqlComm.Parameters.AddWithValue("@unitPrice", unitPrice)
                    sqlComm.Parameters.AddWithValue("@retailPrice", retailPrice)

                    sqlConn.Open()
                    Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        Return True ' Successfully updated
                    Else
                        Return False ' No matching record found
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

    Public Function update_itemprice_when_received(conn As MySqlConnection,
                                 trans As MySqlTransaction,
                                 comp As String,
                                 inputStore As String,
                                 skuCode As String,
                                 unitPrice As Decimal) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE itemprice 
                                  SET unit_price = GREATEST(unit_price, @unitPrice), replication_stat = 1
                                  WHERE company_code = @comp 
                                  AND store_code = @inputStore 
                                  AND sku_code = @skuCode"

            Using sqlComm As New MySqlCommand(sqlQuery, conn, trans)

                sqlComm.Parameters.AddWithValue("@comp", comp)
                sqlComm.Parameters.AddWithValue("@inputStore", inputStore)
                sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                sqlComm.Parameters.AddWithValue("@unitPrice", unitPrice)

                Return sqlComm.ExecuteNonQuery() > 0

            End Using

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

End Module

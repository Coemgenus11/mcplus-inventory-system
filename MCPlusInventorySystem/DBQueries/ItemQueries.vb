Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational
Imports QRCoder

Module ItemQueries

    'TABLE item =========================================================
    Public Function get_items(ByVal inputComp As String, ByVal inputStore As String)
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
                                        SUM(itembal.item_qty) AS item_qty,
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
                                    LEFT JOIN itembal
                                        ON item.sku_code  = itembal.sku_code      
                                        AND itembal.company_code = item.company_code  
                                        AND itembal.store_code = @store
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

    Public Function update_printed(compCode, skuCode, printInfo) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE item 
                                  SET printed = @printInfo, replication_stat = 1
                                  WHERE company_code = @comp AND sku_code = @skuCode"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", compCode)
                    sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                    sqlComm.Parameters.AddWithValue("@printInfo", printInfo)

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

    Public Function update_printed_mpl(compCode, mpl_id, skuCode, printInfo) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE mpurchase_l 
                                  SET printed = @printInfo, replication_stat = 1
                                  WHERE company_code = @comp AND mpurchase_id = @mpl_id  AND sku_code = @skuCode"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", compCode)
                    sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                    sqlComm.Parameters.AddWithValue("@mpl_id", mpl_id)
                    sqlComm.Parameters.AddWithValue("@printInfo", printInfo)

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

    Public Function update_printed_por(compCode, receiving_id, po_num, skuCode, printInfo) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE po_receiving_l 
                                  SET printed = @printInfo, replication_stat = 1
                                  WHERE company_code = @comp AND receiving_id = @receiving_id AND po_num = @po_num  AND sku_code = @skuCode"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", compCode)
                    sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                    sqlComm.Parameters.AddWithValue("@po_num", po_num)
                    sqlComm.Parameters.AddWithValue("@printInfo", printInfo)
                    sqlComm.Parameters.AddWithValue("@receiving_id", receiving_id)

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

    Public Function update_NMI(comp, skuCode, newMerchandise) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE item 
                                  SET merchandise = @newMerchandise, replication_stat = 1
                                  WHERE company_code = @comp AND sku_code = @skuCode"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                    sqlComm.Parameters.AddWithValue("@newMerchandise", newMerchandise)

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

    Public Function update_SkuStatus(comp, skuCode, newStatus) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE item 
                                  SET status = @newStatus, replication_stat = 1
                                  WHERE company_code = @comp AND sku_code = @skuCode"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@skuCode", skuCode)
                    sqlComm.Parameters.AddWithValue("@newStatus", newStatus)

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



    'GENDER QUERIES
    Public Function get_itemgender(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM itemgen WHERE company_code like @comp ORDER BY itemgen.gen_desc ASC"
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

    Public Function check_gender_code_exists(ByVal comp As String, ByVal gen_code As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM itemgen WHERE company_code = @comp AND gen_code = @gen_code"

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@gen_code", gen_code)

                    sqlConn.Open()
                    Dim count As Integer = Convert.ToInt32(sqlComm.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error checking gen_code: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function create_itemgender(company_code As String, gen_code As String, gen_desc As String, status As String, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO itemgen (company_code, gen_code, gen_desc, status, create_date, create_time, create_by, replication_stat) 
                                  VALUES (@comp, @gen_code, @gen_desc, @status, @createDate, @createTime, @createBy, 1)"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@gen_code", gen_code)
                    sqlComm.Parameters.AddWithValue("@gen_desc", gen_desc)
                    Dim isActive As Boolean = (status = "active")
                    sqlComm.Parameters.AddWithValue("@status", isActive)
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

    Public Function update_itemgender(company_code As String, gen_code As String, gen_desc As String, status As String) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE itemgen 
                                  SET gen_desc = @gen_desc, status = @status, replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND gen_code = @gen_code"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@gen_desc", gen_desc)
                    Dim isActive As Boolean = (status = "active")
                    sqlComm.Parameters.AddWithValue("@status", isActive)

                    ' WHERE parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@gen_code", gen_code)

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


    'COLLECTION QUERIES

    Public Function get_itemcol(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM itemcol WHERE company_code like @comp ORDER BY itemcol.col_desc ASC"
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
    Public Function check_col_code_exists(ByVal comp As String, ByVal col_code As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM itemcol WHERE company_code = @comp AND col_code = @col_code"

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@col_code", col_code)

                    sqlConn.Open()
                    Dim count As Integer = Convert.ToInt32(sqlComm.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error checking col_code: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function create_itemcol(company_code As String, col_code As String, col_desc As String, status As String, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO itemcol (company_code, col_code, col_desc, status, create_date, create_time, create_by, replication_stat) 
                                  VALUES (@comp, @col_code, @col_desc, @status, @createDate, @createTime, @createBy, 1)"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@col_code", col_code)
                    sqlComm.Parameters.AddWithValue("@col_desc", col_desc)
                    Dim isActive As Boolean = (status = "active")
                    sqlComm.Parameters.AddWithValue("@status", isActive)
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

    Public Function update_itemcol(company_code As String, col_code As String, col_desc As String, status As String) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE itemcol
                                  SET col_desc = @col_desc, status = @status, replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND col_code = @col_code"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@col_desc", col_desc)
                    Dim isActive As Boolean = (status = "active")
                    sqlComm.Parameters.AddWithValue("@status", isActive)

                    ' WHERE parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@col_code", col_code)

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

    'COLOR QUERIES
    Public Function get_itemcolor(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM itemcolor WHERE company_code like @comp ORDER BY itemcolor.color_desc ASC"
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

    Public Function check_color_code_exists(ByVal comp As String, ByVal color_code As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM itemcolor WHERE company_code = @comp AND color_code = @color_code"

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@color_code", color_code)

                    sqlConn.Open()
                    Dim count As Integer = Convert.ToInt32(sqlComm.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error checking color_code: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function create_itemcolor(company_code As String, color_code As String, color_desc As String, status As String, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO itemcolor (company_code, color_code, color_desc, status, create_date, create_time, create_by, replication_stat) 
                                  VALUES (@comp, @color_code, @color_desc, @status, @createDate, @createTime, @createBy, 1)"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@color_code", color_code)
                    sqlComm.Parameters.AddWithValue("@color_desc", color_desc)
                    Dim isActive As Boolean = (status = "active")
                    sqlComm.Parameters.AddWithValue("@status", isActive)
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

    Public Function update_itemcolor(company_code As String, color_code As String, color_desc As String, status As String) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE itemcolor 
                                  SET color_desc = @color_desc, status = @status, replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND color_code = @color_code"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@color_desc", color_desc)
                    Dim isActive As Boolean = (status = "active")
                    sqlComm.Parameters.AddWithValue("@status", isActive)

                    ' WHERE parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@color_code", color_code)

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

    '====================================================================================================================================================
    'SKU CREATION QUERIES================================================================================================================================
    '====================================================================================================================================================

    'Parent SKU Queries


    Public Function get_parent_sku(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT 
                                        ps.*,
                                        itemgen.gen_desc,
                                        itemcol.col_desc,
                                        itemtype.type_desc,
                                        itemstylecat.stylecat_desc,
                                        itemstylevar.stylevar_desc,
                                        itemcolor.color_desc 
                                    FROM parent_sku ps
                                    LEFT JOIN itemgen 
                                        ON itemgen.company_code = ps.company_code
                                        AND itemgen.gen_code = ps.gen_code
                                    LEFT JOIN itemcol
                                        ON itemcol.company_code = ps.company_code
                                        AND itemcol.col_code = ps.col_code
                                    LEFT JOIN itemtype
                                        ON itemtype.company_code = ps.company_code
                                        AND itemtype.type_code = ps.type_code
                                    LEFT JOIN itemstylecat
                                        ON itemstylecat.company_code = ps.company_code
                                        AND itemstylecat.stylecat_code = ps.stylecat_code
                                    LEFT JOIN itemstylevar
                                        ON itemstylevar.company_code = ps.company_code
                                        AND itemstylevar.stylecat_code = ps.stylecat_code
                                        AND itemstylevar.stylevar_code = ps.stylevar_code
                                    LEFT JOIN itemcolor
                                        ON itemcolor.company_code = ps.company_code
                                        AND itemcolor.color_code = ps.color_code
                                    WHERE 
	                                    ps.company_code like @comp"
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

    Public Function check_parentsku_exists(ByVal comp As String, ByVal parent_sku_code As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM parent_sku WHERE company_code = @comp AND parent_sku_code = @parent_sku_code"

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@parent_sku_code", parent_sku_code)

                    sqlConn.Open()
                    Dim count As Integer = Convert.ToInt32(sqlComm.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error checking color_code: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function create_parent_sku(company_code As String, parent_sku_code As String, gen_code As String, col_code As String, type_code As String, stylecat_code As String, stylevar_code As String, color_code As String, status As String, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO parent_sku (company_code, parent_sku_code, gen_code, col_code, type_code, stylecat_code, stylevar_code, color_code, status, create_date, create_time, create_by, replication_stat) 
                                  VALUES (@comp, @parent_sku_code, @gen_code, @col_code, @type_code, @stylecat_code, @stylevar_code, @color_code, @status, @createDate, @createTime, @createBy, 1)"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@parent_sku_code", parent_sku_code)
                    sqlComm.Parameters.AddWithValue("@gen_code", gen_code)
                    sqlComm.Parameters.AddWithValue("@col_code", col_code)
                    sqlComm.Parameters.AddWithValue("@type_code", type_code)
                    sqlComm.Parameters.AddWithValue("@stylecat_code", stylecat_code)
                    sqlComm.Parameters.AddWithValue("@stylevar_code", stylevar_code)
                    sqlComm.Parameters.AddWithValue("@color_code", color_code)

                    Dim isActive As Boolean = (status = "active")
                    sqlComm.Parameters.AddWithValue("@status", isActive)
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

    Public Function update_parent_sku(company_code As String, parent_sku_code As String, status As String) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE parent_sku 
                                  SET  status = @status, replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND parent_sku_code = @parent_sku_code"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    Dim isActive As Boolean = (status = "active")
                    sqlComm.Parameters.AddWithValue("@status", isActive)

                    ' WHERE parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@parent_sku_code", parent_sku_code)

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


    'Variation Queries

    Public Function get_parentsku_variations(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM variation WHERE company_code like @comp"
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


    Public Function check_var_code_exists(ByVal comp As String, ByVal par_code As String, ByVal var_code As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM variation WHERE company_code = @comp AND parent_sku_code = @par_code AND var_code = @var_code"

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@par_code", par_code)
                    sqlComm.Parameters.AddWithValue("@var_code", var_code)

                    sqlConn.Open()
                    Dim count As Integer = Convert.ToInt32(sqlComm.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error checking var_code: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function create_variation(company_code As String, var_code As String, var_desc As String, parent_sku_code As String, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO variation (company_code, var_code, variant, parent_sku_code, create_date, create_time, create_by, replication_stat) 
                                  VALUES (@comp, @var_code, @variant, @parent_sku_code, @createDate, @createTime, @createBy, 1)"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@var_code", var_code)
                    sqlComm.Parameters.AddWithValue("@variant", var_desc)
                    sqlComm.Parameters.AddWithValue("@parent_sku_code", parent_sku_code)
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

    Public Function update_variantdesc(company_code As String, var_code As String, var_desc As String, parent_sku_code As String) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE variation
                                  SET variant = @var_desc, replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND var_code = @var_code
                                    AND parent_sku_code = @parent_sku_code"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@var_desc", var_desc)

                    ' WHERE parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@var_code", var_code)
                    sqlComm.Parameters.AddWithValue("@parent_sku_code", parent_sku_code)

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







    'VARIATION MANUAL TRIGGER INSERT 
    Public Function InsertNotExistingItems() As Boolean
        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand("sp_insert_items_from_variation", sqlConn)

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


    'TOTAL ITEMS
    Public Function getTotalItems(ByVal inputComp As String) As Integer
        Dim total As Integer = 0

        Dim sqlQuery As String = "
                                    SELECT COUNT(*) 
                                    FROM item
                                    WHERE company_code = @comp
                                "

        Try
            Using conn As MySqlConnection = InvDBConn()
                conn.Open()

                Using cmd As New MySqlCommand(sqlQuery, conn)
                    cmd.Parameters.AddWithValue("@comp", inputComp)

                    Dim result = cmd.ExecuteScalar()

                    If result IsNot DBNull.Value Then
                        total = Convert.ToInt32(result)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return total
    End Function



    'TRANSACTIONS Query
    Public Function get_item_transactions(ByVal inputComp As String, ByVal inputStore As String)
        Dim table As New DataTable()
        Try
            Dim sqlQuery As String = "SELECT 
                                        itemmvt.iditemmvt,
                                        itemmvt.sku_code,
                                        itemgen.gen_desc,
                                        itemcol.col_desc,
                                        itemtype.type_desc,
                                        itemstylecat.stylecat_desc,
                                        itemstylevar.stylevar_desc,
                                        itemcolor.color_desc,
                                        variation.variant,
                                        itemmvt.origin,
                                        itemmvt.destination,
                                        itemmvt.location,
                                        itemmvt.itemloc_origin,
                                        itemmvt.itemloc_dest,
                                        itemmvt.doc_no,
                                        itemmvt.mvt_code,
                                        itemmvt.item_qty,
                                        itemmvt.create_date,
                                        itemmvt.create_time,
                                        itemmvt.create_by
                                    FROM itemmvt
                                    LEFT JOIN item 
                                        ON itemmvt.sku_code = item.sku_code
                                        AND item.company_code = itemmvt.company
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
                                    WHERE itemmvt.company = @comp
                                      AND itemmvt.store_code = @store
                                    ORDER BY itemmvt.create_date DESC, itemmvt.create_time DESC;"
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


    'STYLE CATEGORY MODULE ==========================================================================
    'WEAR TYPE 

    Public Function get_itemwear(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM itemwear WHERE company_code like @comp ORDER BY itemwear.wear_desc ASC"
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

    Public Function create_itemwear(company_code As String, wear_code As String, wear_desc As String, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO itemwear (company_code, wear_code, wear_desc, create_date, create_time, create_by, replication_stat) 
                                  VALUES (@comp, @wear_code, @wear_desc, @createDate, @createTime, @createBy, 1)"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@wear_code", wear_code)
                    sqlComm.Parameters.AddWithValue("@wear_desc", wear_desc)
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

    Public Function update_itemwear(company_code As String, wear_code As String, wear_desc As String) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE itemwear 
                                  SET wear_desc = @wear_desc, replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND wear_code = @wear_code"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@wear_desc", wear_desc)

                    ' WHERE parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@wear_code", wear_code)

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


    Public Function check_itemwear_code_exists(ByVal comp As String, ByVal wear_code As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM itemwear WHERE company_code = @comp AND wear_code = @wear_code"

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@wear_code", wear_code)

                    sqlConn.Open()
                    Dim count As Integer = Convert.ToInt32(sqlComm.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error checking wear_code: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function


    'itemtype QUERIES

    Public Function get_itemtype(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM itemtype WHERE company_code like @comp ORDER BY itemtype.type_desc ASC"
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

    Public Function check_itemtype_code_exists(ByVal comp As String, ByVal type_code As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM itemtype WHERE company_code = @comp AND type_code = @type_code"

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@type_code", type_code)

                    sqlConn.Open()
                    Dim count As Integer = Convert.ToInt32(sqlComm.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error checking type_code: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function create_itemtype(company_code As String, type_code As String, type_desc As String, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO itemtype (company_code, type_code, type_desc, create_date, create_time, create_by, replication_stat) 
                                  VALUES (@comp, @type_code, @type_desc, @createDate, @createTime, @createBy, 1)"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@type_code", type_code)
                    sqlComm.Parameters.AddWithValue("@type_desc", type_desc)
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
    Public Function update_itemtype(company_code As String, type_code As String, type_desc As String) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE itemtype 
                                  SET type_desc = @type_desc, replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND type_code = @type_code"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@type_desc", type_desc)

                    ' WHERE parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@type_code", type_code)

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

    'itemstylecat QUERIES

    Public Function get_stylecat(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "
                                    SELECT 
                                        sc.idstylecat,
                                        sc.company_code,
                                        sc.stylecat_code,
                                        sc.stylecat_desc,

                                        -- Type
                                        sc.type_code,
                                        t.type_desc,

                                        -- Wear
                                        sc.wear_code,
                                        w.wear_desc

                                    FROM itemstylecat sc

                                    LEFT JOIN itemtype t 
                                        ON sc.type_code = t.type_code
                                        AND sc.company_code = t.company_code

                                    LEFT JOIN itemwear w 
                                        ON sc.wear_code = w.wear_code
                                        AND sc.company_code = w.company_code 
                                    WHERE sc.company_code = @comp
                                    ORDER BY sc.stylecat_desc ASC"
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

    Public Function check_stylecat_code_exists(ByVal comp As String, ByVal stylecat_code As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM itemstylecat WHERE company_code = @comp AND stylecat_code = @stylecat_code"

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@stylecat_code", stylecat_code)

                    sqlConn.Open()
                    Dim count As Integer = Convert.ToInt32(sqlComm.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error checking type_code: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function create_stylecat(company_code As String, stylecat_code As String, stylecat_desc As String, wear_code As String, type_code As String, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO itemstylecat (company_code, stylecat_code, stylecat_desc, wear_code, type_code, create_date, create_time, create_by, replication_stat) 
                                  VALUES (@comp, @stylecat_code, @stylecat_desc, @wear_code, @type_code, @createDate, @createTime, @createBy, 1)"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@stylecat_code", stylecat_code)
                    sqlComm.Parameters.AddWithValue("@stylecat_desc", stylecat_desc)
                    sqlComm.Parameters.AddWithValue("@wear_code", wear_code)
                    sqlComm.Parameters.AddWithValue("@type_code", type_code)
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

    Public Function update_itemstylecat(company_code As String, stylecat_code As String, stylecat_desc As String, wear_code As String, type_code As String) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE itemstylecat 
                                  SET stylecat_desc = @stylecat_desc, wear_code = @wear_code,  type_code = @type_code, replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND stylecat_code = @stylecat_code"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@stylecat_desc", stylecat_desc)
                    sqlComm.Parameters.AddWithValue("@wear_code", wear_code)
                    sqlComm.Parameters.AddWithValue("@type_code", type_code)

                    ' WHERE parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@stylecat_code", stylecat_code)

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

    'itemstylevar QUERIES
    Public Function get_itemstylevar(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM itemstylevar WHERE company_code like @comp ORDER BY itemstylevar.stylevar_desc ASC"
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

    Public Function create_stylevar(company_code As String, stylevar_code As String, stylevar_desc As String, stylecat_code As String, create_by As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO itemstylevar (company_code, stylevar_code, stylevar_desc, stylecat_code, create_date, create_time, create_by, replication_stat) 
                                  VALUES (@comp, @stylevar_code, @stylevar_desc, @stylecat_code, @createDate, @createTime, @createBy, 1)"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@stylevar_code", stylevar_code)
                    sqlComm.Parameters.AddWithValue("@stylevar_desc", stylevar_desc)
                    sqlComm.Parameters.AddWithValue("@stylecat_code", stylecat_code)
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

    Public Function check_stylevar_code_exists(ByVal comp As String, ByVal stylecat_code As String, ByVal stylevar_code As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM itemstylevar WHERE company_code = @comp AND stylecat_code = @stylecat_code AND stylevar_code = @stylevar_code"

        Try
            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@stylecat_code", stylecat_code)
                    sqlComm.Parameters.AddWithValue("@stylevar_code", stylevar_code)

                    sqlConn.Open()
                    Dim count As Integer = Convert.ToInt32(sqlComm.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error checking type_code: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function
    Public Function update_itemstylevar(company_code As String, stylevar_code As String, stylevar_desc As String, stylecat_code As String) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE itemstylevar
                                  SET stylevar_desc = @stylevar_desc, replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND stylevar_code = @stylevar_code
                                    AND stylecat_code = @stylecat_code"

            Using sqlConn As New MySqlConnection(InvDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    ' Add parameters
                    sqlComm.Parameters.AddWithValue("@stylevar_desc", stylevar_desc)

                    ' WHERE parameters
                    sqlComm.Parameters.AddWithValue("@comp", company_code)
                    sqlComm.Parameters.AddWithValue("@stylevar_code", stylevar_code)
                    sqlComm.Parameters.AddWithValue("@stylecat_code", stylecat_code)

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
End Module

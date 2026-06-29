Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Module AuditQueries


    Public Function get_user_auth(userID As String) As Object ' You can also use As String if you expect only a string result

        Try
            Dim sqlQuery As String = "SELECT authority_code FROM user WHERE iduser = @userID"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@userID", userID)

                    sqlConn.Open()
                    Using reader As MySqlDataReader = sqlComm.ExecuteReader()
                        If reader.Read() Then
                            ' Read the authority_code value safely
                            Return reader("authority_code").ToString()
                        Else
                            Return Nothing ' User not found
                        End If
                    End Using
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function

    Public Function get_user_comp(userID As String) As Object ' You can also use As String if you expect only a string result

        Try
            Dim sqlQuery As String = "SELECT company_code FROM user WHERE iduser = @userID"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@userID", userID)

                    sqlConn.Open()
                    Using reader As MySqlDataReader = sqlComm.ExecuteReader()
                        If reader.Read() Then
                            ' Read the authority_code value safely
                            Return reader("company_code").ToString()
                        Else
                            Return Nothing ' User not found
                        End If
                    End Using
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function

    Public Function get_users(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * , company.company_desc, authority.authority_desc
                                        FROM user 
                                        LEFT JOIN 
                                            authority 
                                                    ON authority.company_code = user.company_code
                                                  AND authority.authority_code  = user.authority_code
                                        LEFT JOIN 
                                            company ON company.company_code = user.company_code 
                                        WHERE user.company_code like @comp"
            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
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
                        AuditDBConn.Close()
                    End Try
                End Using
            End Using
            AuditDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return table
    End Function

    Public Function write_authority(inputComp, inputAuthCode, inputAuthDesc, inputCrtby)
        Dim ind_write As Boolean

        Try
            Dim sqlQuery As String = "INSERT INTO authority
                                      (company_code, authority_code, authority_desc, create_date, create_time, create_by, replication_stat)
                                      VALUES (@comp, @authority_code, @authority_desc, @date, @time, @crtby, 1)"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@authority_code", inputAuthCode)
                        .Parameters.AddWithValue("@authority_desc", inputAuthDesc)
                        .Parameters.AddWithValue("@crtby", inputCrtby)
                        .Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"))
                        .Parameters.AddWithValue("@time", DateTime.Now.ToString("HH:mm:ss"))

                    End With
                    Try
                        sqlConn.Open()
                        sqlComm.ExecuteNonQuery()
                        ind_write = True
                    Catch ex As MySqlException
                        ind_write = False
                        MsgBox(ex.Message)
                        AuditDBConn.Close()
                    End Try

                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            ind_write = False
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return ind_write
    End Function

    Public Function update_authority_desc(inputComp As String, inputAuthCode As String, inputAuthDesc As String) As Boolean
        Dim ind_update As Boolean = False

        Try
            Dim sqlQuery As String = "UPDATE authority 
                                  SET authority_desc = @authority_desc, replication_stat = 1
                                  WHERE company_code = @comp 
                                    AND authority_code = @authority_code"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.CommandType = CommandType.Text
                    sqlComm.Parameters.AddWithValue("@comp", inputComp)
                    sqlComm.Parameters.AddWithValue("@authority_code", inputAuthCode)
                    sqlComm.Parameters.AddWithValue("@authority_desc", inputAuthDesc)

                    sqlConn.Open()
                    Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                    ind_update = (rowsAffected > 0)
                End Using
            End Using

        Catch ex As MySqlException
            MsgBox("MySQL Error: " & ex.Message)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try

        Return ind_update
    End Function


    Public Function get_auth(ByVal inputComp As String)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM authority WHERE company_code like @comp"
            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
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
                        AuditDBConn.Close()
                    End Try
                End Using
            End Using
            AuditDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return table
    End Function
    Public Function check_authcode_exists(ByVal comp As String, ByVal auth_code As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM authority WHERE company_code = @comp AND authority_code = @authority_code"

        Try
            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)
                    sqlComm.Parameters.AddWithValue("@authority_code", auth_code)

                    sqlConn.Open()
                    Dim count As Integer = Convert.ToInt32(sqlComm.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error checking authority_code: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function get_company(ByVal inputComp)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM company WHERE company_code Like @comp"
            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
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
                        AuditDBConn.Close()
                    End Try

                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return table
    End Function

    Public Function get_company_desc(Comp)
        Dim desc = Nothing

        Try
            Dim sqlQuery As String = "SELECT company_desc FROM company WHERE company_code = @comp"
            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", Comp)
                    End With
                    Try
                        sqlConn.Open()
                        desc = sqlComm.ExecuteScalar()

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        AuditDBConn.Close()
                    End Try
                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return desc
    End Function


    Public Function write_users(inputComp, inputfullname, inputUser, inputPass, inputDesc, inputAuth, inputStat, inputCrtby)
        Dim ind_write As Boolean

        Try
            Dim sqlQuery As String = "INSERT INTO user
                                      (company_code, full_name, user_name, user_pass, user_desc, authority_code, user_stat, user_img, create_date, create_time, create_by, replication_stat)
                                      VALUES (@comp, @fullname, @uname, @pass, @desc, @auth, @stat, 'test', @date, @time, @crtby, 1)"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@fullname", inputfullname)
                        .Parameters.AddWithValue("@uname", inputUser)
                        .Parameters.AddWithValue("@pass", inputPass)
                        .Parameters.AddWithValue("@desc", inputDesc)
                        .Parameters.AddWithValue("@auth", inputAuth)
                        .Parameters.AddWithValue("@stat", inputStat)
                        .Parameters.AddWithValue("@crtby", inputCrtby)
                        .Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"))
                        .Parameters.AddWithValue("@time", DateTime.Now.ToString("HH:mm:ss"))

                    End With
                    Try
                        sqlConn.Open()
                        sqlComm.ExecuteNonQuery()
                        ind_write = True
                    Catch ex As MySqlException
                        ind_write = False
                        MsgBox(ex.Message)
                        AuditDBConn.Close()
                    End Try

                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            ind_write = False
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return ind_write
    End Function

    Public Function check_uname(inputCom, inputUname)
        Dim ind_exist As Boolean

        Try
            Dim sqlQuery As String = "SELECT * FROM user WHERE company_code = @comp and user_name = @uname"
            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputCom)
                        .Parameters.AddWithValue("@uname", inputUname)
                    End With
                    Try
                        sqlConn.Open()
                        Dim rec As Integer = CInt(sqlComm.ExecuteScalar)

                        If rec > 0 Then
                            ind_exist = True
                        Else
                            ind_exist = False
                        End If

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        AuditDBConn.Close()
                    End Try
                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return ind_exist
    End Function

    Public Function update_user(inputUserID As String, inputComp As String, inputfullname As String, inputUser As String,
                                 inputPass As String, inputDesc As String,
                                 inputAuth As String, inputStat As String) As Boolean
        Dim ind_update As Boolean
        Try
            Dim sqlQuery As String = "UPDATE user SET 
                                      full_name = @fullname,
                                      user_name = @uname,
                                      user_pass = @pass,
                                      user_desc = @desc,
                                      authority_code = @auth,
                                      user_stat = @stat,
                                      user_img = 'test',
                                      replication_stat = 1
                                  WHERE iduser = @inputUserID"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@fullname", inputfullname)
                        .Parameters.AddWithValue("@uname", inputUser)
                        .Parameters.AddWithValue("@pass", inputPass)
                        .Parameters.AddWithValue("@desc", inputDesc)
                        .Parameters.AddWithValue("@auth", inputAuth)
                        .Parameters.AddWithValue("@stat", inputStat)
                        .Parameters.AddWithValue("@inputUserID", inputUserID)
                    End With
                    Try
                        sqlConn.Open()
                        Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()
                        ind_update = (rowsAffected > 0)
                    Catch ex As MySqlException
                        ind_update = False
                        MsgBox(ex.Message)
                        AuditDBConn.Close()
                    End Try

                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            ind_update = False
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return ind_update
    End Function

    Public Function delete_user(inputCom, inputUname)
        Dim ind_del As Boolean

        Try
            Dim sqlQuery As String = "DELETE from user 
                                      WHERE company_code = @comp and user_name = @uname"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputCom)
                        .Parameters.AddWithValue("@uname", inputUname)
                    End With
                    Try
                        sqlConn.Open()
                        sqlComm.ExecuteNonQuery()
                        ind_del = True
                    Catch ex As MySqlException
                        ind_del = False
                        MsgBox(ex.Message)
                        AuditDBConn.Close()
                    End Try

                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            ind_del = False
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return ind_del
    End Function


    Public Sub edit_image(inputCom, inputUname, inputPath)

        Try
            Dim sqlQuery As String = "UPDATE user
                                      SET user_img = @imgpath, replication_stat = 1
                                      WHERE company_code = @comp and user_name = @uname"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputCom)
                        .Parameters.AddWithValue("@uname", inputUname)
                        .Parameters.AddWithValue("@imgpath", inputPath)

                    End With
                    Try
                        sqlConn.Open()
                        sqlComm.ExecuteNonQuery()
                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        AuditDBConn.Close()
                    End Try

                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try


    End Sub

    Public Function get_user_image(inputComp, inputUname)
        Dim img = Nothing

        Try
            Dim sqlQuery As String = "SELECT user_img FROM user WHERE company_code = @comp and user_name = @uname"
            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                        .Parameters.AddWithValue("@uname", inputUname)
                    End With
                    Try
                        sqlConn.Open()
                        img = sqlComm.ExecuteScalar()

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        AuditDBConn.Close()
                    End Try
                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return img
    End Function

    Public Function get_com_image(inputComp)
        Dim img = Nothing

        Try
            Dim sqlQuery As String = "SELECT com_banner FROM company WHERE company_code = @comp"
            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputComp)
                    End With
                    Try
                        sqlConn.Open()
                        img = sqlComm.ExecuteScalar()

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        AuditDBConn.Close()
                    End Try
                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return img
    End Function

    Public Function check_com(inputCom)
        Dim ind_exist As Boolean

        Try
            Dim sqlQuery As String = "SELECT * FROM company WHERE company_code = @comp"
            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputCom)
                    End With
                    Try
                        sqlConn.Open()
                        Dim rec As Integer = CInt(sqlComm.ExecuteScalar)

                        If rec > 0 Then
                            ind_exist = True
                        Else
                            ind_exist = False
                        End If

                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        AuditDBConn.Close()
                    End Try
                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try

        Return ind_exist
    End Function

    Public Function create_company(company_code As String, company_desc As String, company_addr As String, tin_num As String, contact_num As String, email_addr As String, company_url As String, status As String) As Boolean
        Try
            Dim sqlQuery As String = "INSERT INTO company
                                  (company_code, company_desc, company_addr, tin_num, contact_num, email_addr, company_url, status, create_date, create_time, create_by, replication_stat)
                                  VALUES
                                  (@company_code, @company_desc, @company_addr, @tin_num, @contact_num, @email_addr, @company_url, @status, @create_date, @create_time, @create_by, 1)"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    sqlComm.Parameters.AddWithValue("@company_code", company_code)
                    sqlComm.Parameters.AddWithValue("@company_desc", company_desc)
                    sqlComm.Parameters.AddWithValue("@company_addr", company_addr)
                    sqlComm.Parameters.AddWithValue("@tin_num", tin_num)
                    sqlComm.Parameters.AddWithValue("@contact_num", contact_num)
                    sqlComm.Parameters.AddWithValue("@email_addr", email_addr)
                    sqlComm.Parameters.AddWithValue("@company_url", company_url)
                    sqlComm.Parameters.AddWithValue("@status", status)

                    ' Auto values
                    sqlComm.Parameters.AddWithValue("@create_date", Date.Now.ToString("yyyy-MM-dd"))
                    sqlComm.Parameters.AddWithValue("@create_time", Date.Now.ToString("HH:mm:ss"))
                    sqlComm.Parameters.AddWithValue("@create_by", My.Settings.CurrentUserID)

                    sqlConn.Open()
                    Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()

                    Return rowsAffected > 0
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

    Public Function update_company(company_code As String, company_desc As String, company_addr As String, tin_num As String, contact_num As String, email_addr As String, company_url As String, status As String) As Boolean
        Try
            Dim sqlQuery As String = "UPDATE company SET
                                  company_desc = @company_desc,
                                  company_addr = @company_addr,
                                  tin_num = @tin_num,
                                  contact_num = @contact_num,
                                  email_addr = @email_addr,
                                  company_url = @company_url,
                                  status = @status,
                                  replication_stat = 1
                                  WHERE company_code = @company_code"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)

                    sqlComm.Parameters.AddWithValue("@company_desc", company_desc)
                    sqlComm.Parameters.AddWithValue("@company_addr", company_addr)
                    sqlComm.Parameters.AddWithValue("@tin_num", tin_num)
                    sqlComm.Parameters.AddWithValue("@contact_num", contact_num)
                    sqlComm.Parameters.AddWithValue("@email_addr", email_addr)
                    sqlComm.Parameters.AddWithValue("@company_url", company_url)
                    sqlComm.Parameters.AddWithValue("@status", status)


                    ' WHERE condition
                    sqlComm.Parameters.AddWithValue("@company_code", company_code)

                    sqlConn.Open()
                    Dim rowsAffected As Integer = sqlComm.ExecuteNonQuery()

                    Return rowsAffected > 0
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

    'Public Function create_company(inputCom, inputDesc, inputAddr, inputTIN, inputEmail, inputNum, inputStat, inputDat, inputTim, inputCrtby)
    '    Dim ind_com_write As Boolean

    '    Try
    '        Dim sqlQuery As String = "INSERT INTO company
    '                                  (company_code, company_desc, company_addr, tin_num, contact_num, email_addr, status, create_date, create_time, create_by)
    '                                  VALUES (@comp, @desc, @addr, @tin, @email, @num, CASE WHEN @stat THEN '1' ELSE '0' END,
    '                                  @date, @time, @crtby)"

    '        Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
    '            Using sqlComm As New MySqlCommand()
    '                With sqlComm
    '                    .Connection = sqlConn
    '                    .CommandText = sqlQuery
    '                    .CommandType = CommandType.Text
    '                    .Parameters.AddWithValue("@comp", inputCom)
    '                    .Parameters.AddWithValue("@desc", inputDesc)
    '                    .Parameters.AddWithValue("@addr", inputAddr)
    '                    .Parameters.AddWithValue("@tin", inputTIN)
    '                    .Parameters.AddWithValue("@email", inputEmail)
    '                    .Parameters.AddWithValue("@num", inputNum)
    '                    .Parameters.AddWithValue("@stat", inputStat)
    '                    .Parameters.AddWithValue("@date", inputDat)
    '                    .Parameters.AddWithValue("@time", inputTim)
    '                    .Parameters.AddWithValue("@crtby", inputCrtby)
    '                End With
    '                Try
    '                    sqlConn.Open()
    '                    sqlComm.ExecuteNonQuery()
    '                    ind_com_write = True
    '                Catch ex As MySqlException
    '                    ind_com_write = False
    '                    MsgBox(ex.Message)
    '                    AuditDBConn.Close()
    '                End Try

    '            End Using
    '        End Using

    '        AuditDBConn.Close()
    '    Catch ex As Exception
    '        ind_com_write = False
    '        MsgBox(ex.Message)
    '        AuditDBConn.Close()
    '    End Try

    '    Return ind_com_write
    'End Function

    Public Sub edit_com_image(inputCom, inputPath)

        Try
            Dim sqlQuery As String = "UPDATE company
                                      SET com_banner = @imgpath, replication_stat = 1
                                      WHERE company_code = @comp"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand()
                    With sqlComm
                        .Connection = sqlConn
                        .CommandText = sqlQuery
                        .CommandType = CommandType.Text
                        .Parameters.AddWithValue("@comp", inputCom)
                        .Parameters.AddWithValue("@imgpath", inputPath)

                    End With
                    Try
                        sqlConn.Open()
                        sqlComm.ExecuteNonQuery()
                    Catch ex As MySqlException
                        MsgBox(ex.Message)
                        AuditDBConn.Close()
                    End Try

                End Using
            End Using

            AuditDBConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            AuditDBConn.Close()
        End Try
    End Sub


    Public Function get_user_tranauth(inputComp)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM tranauth WHERE company_code like @comp"
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

    Public Function get_trans(inputComp)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM tranmvts WHERE company_code like @comp"
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

    Public Function get_store(inputComp)
        Dim table As New DataTable()

        Try
            Dim sqlQuery As String = "SELECT * FROM store WHERE company_code like @comp"
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

    Public Function check_comp_code_exists(ByVal comp As String) As Boolean
        Dim sqlQuery As String = "SELECT COUNT(*) FROM company WHERE company_code = @comp"

        Try
            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@comp", comp)

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

    Public Function get_user_fullname(userID As String) As Object ' You can also use As String if you expect only a string result

        Try
            Dim sqlQuery As String = "SELECT full_name FROM user WHERE iduser = @userID"

            Using sqlConn As New MySqlConnection(AuditDBConn.ConnectionString)
                Using sqlComm As New MySqlCommand(sqlQuery, sqlConn)
                    sqlComm.Parameters.AddWithValue("@userID", userID)

                    sqlConn.Open()
                    Using reader As MySqlDataReader = sqlComm.ExecuteReader()
                        If reader.Read() Then
                            ' Read the authority_code value safely
                            Return reader("full_name").ToString()
                        Else
                            Return Nothing ' User not found
                        End If
                    End Using
                End Using
            End Using
        Catch ex As MySqlException
            MsgBox("Database Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function
End Module

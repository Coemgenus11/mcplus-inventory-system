Imports MySql.Data.MySqlClient

Module db_conn

    Public Function AuditDBConn() As MySqlConnection
        Dim connStr As String = $"Server={My.Settings.centralserverIP};Database={My.Settings.centralAuditDB};Uid={My.Settings.centralUserName};Pwd={DecryptString(My.Settings.centralPassword)}"
        Return New MySqlConnection(connStr)
    End Function


    Public Function InvDBConn() As MySqlConnection
        Dim connStr As String = $"Server={My.Settings.centralserverIP};Database={My.Settings.CentralInventoryDB};Uid={My.Settings.centralUserName};Pwd={DecryptString(My.Settings.centralPassword)}"
        Return New MySqlConnection(connStr)
    End Function

    Public Function SalesDBConn() As MySqlConnection
        Dim connStr As String = $"Server={My.Settings.centralserverIP};Database={My.Settings.centralSalesDB};Uid={My.Settings.centralUserName};Pwd={DecryptString(My.Settings.centralPassword)}"
        Return New MySqlConnection(connStr)
    End Function


End Module

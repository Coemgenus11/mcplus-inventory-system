Imports System.Net.NetworkInformation
Imports System.Xml
Imports MySql.Data.MySqlClient

Module Conn
    'Public Function check_db(ServerIP As String, AuditDB As String, InventoryDB As String, Uname As String, Pass As String) As Boolean
    '    Dim connString As String = $"Server={ServerIP};Database={AuditDB};Uid={Uname};Pwd={Pass};"
    '    Try
    '        Using conn As New MySqlConnection(connString)
    '            conn.Open()
    '            MessageBox.Show("Connection to " & ServerIP & " database was successful!", "Database Connection")
    '            Return True
    '        End Using
    '    Catch ex As Exception
    '        'MsgBox("Database connection failed: " & ex.Message)
    '        MsgBox("Please check your database connection and credentials.")
    '        Return False
    '    End Try
    'End Function

    Public Function check_db(ServerIP As String, AuditDB As String, InventoryDB As String, SalesDB As String, Uname As String, Pass As String) As Boolean
        Dim auditConnString As String = $"Server={ServerIP};Database={AuditDB};Uid={Uname};Pwd={Pass};"
        Dim inventoryConnString As String = $"Server={ServerIP};Database={InventoryDB};Uid={Uname};Pwd={Pass};"
        Dim salesConnString As String = $"Server={ServerIP};Database={SalesDB};Uid={Uname};Pwd={Pass};"

        ' Check AuditDB connection
        Try
            Using auditConn As New MySqlConnection(auditConnString)
                auditConn.Open()
            End Using
        Catch ex As Exception
            MsgBox($"Failed to connect to AuditDB '{AuditDB}': {ex.Message}", MsgBoxStyle.Critical, "AuditDB Connection Error")
            Return False
        End Try

        ' Check InventoryDB connection
        Try
            Using inventoryConn As New MySqlConnection(inventoryConnString)
                inventoryConn.Open()
            End Using
        Catch ex As Exception
            MsgBox($"Failed to connect to InventoryDB '{InventoryDB}': {ex.Message}", MsgBoxStyle.Critical, "InventoryDB Connection Error")
            Return False
        End Try

        ' Check SalesDB connection
        Try
            Using salesConn As New MySqlConnection(salesConnString)
                salesConn.Open()
            End Using
        Catch ex As Exception
            MsgBox($"Failed to connect to SalesDB '{SalesDB}': {ex.Message}", MsgBoxStyle.Critical, "SalesDB Connection Error")
            Return False
        End Try

        ' If both connections succeeded
        MessageBox.Show($"Successfully connected to both '{AuditDB}' and '{InventoryDB}' and '{SalesDB}' on server '{ServerIP}'.", "Connection Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
    End Function

    Public Function isConnectedToServer(ipAddress As String) As Boolean
        Try
            Dim pingSender As New Ping()
            Dim reply As PingReply = pingSender.Send(ipAddress, 1000) ' Timeout in ms

            If reply.Status = IPStatus.Success Then
                Return True ' IP is up
            Else
                Return False ' IP is down or unreachable
            End If
        Catch ex As Exception
            ' If an exception occurs, assume IP is down
            Return False
        End Try
    End Function


End Module

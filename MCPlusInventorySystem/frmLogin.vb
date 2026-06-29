Imports System.Data.Common
Imports System.Text
Imports System.Windows.Controls.Primitives
Imports CrystalDecisions.[Shared].Json
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'My.Settings.centralserverIP = ""
        'My.Settings.centralAuditDB = ""
        'My.Settings.CentralInventoryDB = ""
        'My.Settings.centralPassword = ""
        'My.Settings.centralUserName = ""
        Init_Fields()
        isSettingsDBConnected(Me)
    End Sub

    Public Sub Init_Fields()
        txtId.Text = ""
        txtPass.Text = ""
        lblMsg.Text = ""
        lblMsg.ForeColor = Color.Red
    End Sub

    Public Sub UserAuth(auth_code)
        MainClass.RefreshUserTab()
        RefreshClass.RefreshAll()
        If auth_code = "STK" Then
            MainClass.UserSTK()
        ElseIf auth_code = "RPT" Then
            MainClass.UserRPT()
        ElseIf auth_code = "ADM" Then
            MainClass.UserADM()
        ElseIf auth_code = "OPE" Then
            MainClass.UserOPE()
        End If
    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click

        Dim dt As DataTable = get_users("%")
        Dim userFound As Boolean = False

        For Each row As DataRow In dt.Rows
            Dim pass = DecryptString(row("user_pass").ToString()) 'ERROR IN HEREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
            If txtId.Text.Trim = row("user_name").ToString().Trim AndAlso
               txtPass.Text = pass Then

                userFound = True
                If chkRememberMe.Checked Then
                    My.Settings.LoggedIn = True
                End If
                My.Settings.CurrentUserID = row("iduser").ToString()
                My.Settings.Save()

                UserAuth(row("authority_code").ToString())
                Exit For
            End If
        Next
        If Not userFound Then
            lblMsg.Text = "Invalid credentials!"
            lblMsg.ForeColor = Color.Red
        ElseIf userFound Then

            'MsgBox(My.Settings.Store)
            frmMain.Show()
            Me.Close()
        End If
    End Sub

    Private Sub txtPass_TextChanged(sender As Object, e As EventArgs) Handles txtPass.TextChanged
        txtPass.UseSystemPasswordChar = True
    End Sub
    Public Sub isSettingsDBConnected(currentForm As Form)
        Dim isConnected As Boolean = CheckDatabaseConnection()
        If Not isConnected Then
            Dim result As DialogResult = MessageBox.Show("This action will set up the initial database connection for the application on this device.",
                                             "Inventory System - Initial Setup",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                frmInit.ShowDialog()
                currentForm.Close()
            End If
        ElseIf isConnected Then

            If Not isConnectedToServer(My.Settings.centralserverIP) Then
                MsgBox("Cannot continue. Please check your connection.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If My.Settings.LoggedIn Then
                If get_user_auth(My.Settings.CurrentUserID) IsNot Nothing Then
                    UserAuth(get_user_auth(My.Settings.CurrentUserID).ToString())
                    frmMain.ShowDialog()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Function CheckDatabaseConnection() As Boolean
        If My.Settings.centralAuditDB IsNot "" And My.Settings.centralPassword IsNot "" Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
Imports System.IO
Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmAudit
    Private Sub frmAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCreateUserAcc_Click(sender As Object, e As EventArgs) Handles btnCreateUserAcc.Click
        frmUserInfo.isCreate = True
        frmUserInfo.ShowDialog()

    End Sub

    Private Sub dgAccountsUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAccountsUsers.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgAccountsUsers.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgAccountsUsers.Rows(e.RowIndex)

            ' Get existing values
            Dim userID As Integer = Convert.ToInt32(selectedRow.Cells("user_id").Value)
            Dim row As DataRow = AccountClass.GetSelectedUserDataRow(userID)

            If row IsNot Nothing Then
                If columnName = "user_view" Then
                    Dim user_stat As String = row("user_stat").ToString()
                    Dim status As String = If(user_stat < 1, "inactive", "active")

                    If status = "inactive" Then
                        frmUserInfo.btnStatus.Text = "inactive"
                        frmUserInfo.btnStatus.BackColor = Color.LightCoral   ' example red shade kapag inactive
                    Else
                        frmUserInfo.btnStatus.Text = "active"
                        frmUserInfo.btnStatus.BackColor = Color.FromArgb(192, 255, 192)  ' light green kapag active
                    End If
                    frmUserInfo.lblUserID.Text = row("iduser").ToString()
                    frmUserInfo.txtFullname.Text = row("full_name").ToString()
                    frmUserInfo.txtUsername.Text = row("user_name").ToString()
                    frmUserInfo.txtPass.Text = DecryptString(row("user_pass").ToString())
                    frmUserInfo.txtDesc.Text = row("user_desc").ToString()
                    frmUserInfo.btnStatus.Text = status
                    frmUserInfo.txtCompDesc.Text = row("company_desc").ToString()
                    frmUserInfo.lblCompanyCode.Text = row("company_code").ToString()
                    frmUserInfo.cbUserAuth.Text = row("authority_desc").ToString()
                    frmUserInfo.lblAuthCode.Text = row("authority_code").ToString()
                    frmUserInfo.ShowDialog()
                End If
            End If

        End If
    End Sub

    Private Sub btnAddAuth_Click(sender As Object, e As EventArgs) Handles btnAddAuth.Click
        frmAuth.isCreate = True
        frmAuth.ShowDialog()
    End Sub

    'Private Sub dgAuth_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuth.CellContentClick
    'End Sub

    Private Sub dgAuth_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuth.CellClick
        If e.RowIndex >= 0 Then

            Dim columnName As String = dgAuth.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgAuth.Rows(e.RowIndex)
            ' Get existing values
            Dim authCode As String = selectedRow.Cells("auth_code").Value
            Dim authDesc As String = selectedRow.Cells("auth_desc").Value

            If columnName = "auth_view" Then
                frmAuth.txtAuthDesc.Text = authDesc
                frmAuth.txtAuthCode.Text = authCode
                frmAuth.ShowDialog()
            End If

        End If
    End Sub
End Class
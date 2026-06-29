<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtLAuditDB = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtLInventoryDB = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmdTestLServer = New System.Windows.Forms.Button()
        Me.cmdApplyLServer = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtLServerPass = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtLServerUname = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtLServerIP = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtCInventoryDB = New System.Windows.Forms.TextBox()
        Me.txtCAuditDB = New System.Windows.Forms.TextBox()
        Me.cmdTestCServer = New System.Windows.Forms.Button()
        Me.cmdApplyCServer = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtServerPass = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtServerUname = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtServerIP = New System.Windows.Forms.TextBox()
        Me.btnGotoLogin = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtLSalesDB = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtCSalesDB = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox11)
        Me.GroupBox2.Controls.Add(Me.cmdTestLServer)
        Me.GroupBox2.Controls.Add(Me.cmdApplyLServer)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtLServerPass)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtLServerUname)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtLServerIP)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 35)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(380, 305)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Local Server"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label29)
        Me.GroupBox11.Controls.Add(Me.txtLAuditDB)
        Me.GroupBox11.Controls.Add(Me.txtLSalesDB)
        Me.GroupBox11.Controls.Add(Me.Label22)
        Me.GroupBox11.Controls.Add(Me.txtLInventoryDB)
        Me.GroupBox11.Controls.Add(Me.Label20)
        Me.GroupBox11.Location = New System.Drawing.Point(5, 150)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(289, 134)
        Me.GroupBox11.TabIndex = 20
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Database :"
        '
        'txtLAuditDB
        '
        Me.txtLAuditDB.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLAuditDB.Location = New System.Drawing.Point(115, 26)
        Me.txtLAuditDB.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLAuditDB.Name = "txtLAuditDB"
        Me.txtLAuditDB.Size = New System.Drawing.Size(124, 26)
        Me.txtLAuditDB.TabIndex = 15
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(48, 68)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(57, 13)
        Me.Label22.TabIndex = 18
        Me.Label22.Text = "Inventory :"
        '
        'txtLInventoryDB
        '
        Me.txtLInventoryDB.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLInventoryDB.Location = New System.Drawing.Point(115, 64)
        Me.txtLInventoryDB.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLInventoryDB.Name = "txtLInventoryDB"
        Me.txtLInventoryDB.Size = New System.Drawing.Size(124, 26)
        Me.txtLInventoryDB.TabIndex = 17
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(48, 30)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 13)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "Audit :"
        '
        'cmdTestLServer
        '
        Me.cmdTestLServer.Location = New System.Drawing.Point(303, 156)
        Me.cmdTestLServer.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdTestLServer.Name = "cmdTestLServer"
        Me.cmdTestLServer.Size = New System.Drawing.Size(64, 61)
        Me.cmdTestLServer.TabIndex = 14
        Me.cmdTestLServer.Text = "Test"
        Me.cmdTestLServer.UseVisualStyleBackColor = True
        '
        'cmdApplyLServer
        '
        Me.cmdApplyLServer.Location = New System.Drawing.Point(303, 230)
        Me.cmdApplyLServer.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdApplyLServer.Name = "cmdApplyLServer"
        Me.cmdApplyLServer.Size = New System.Drawing.Size(64, 62)
        Me.cmdApplyLServer.TabIndex = 13
        Me.cmdApplyLServer.Text = "Apply"
        Me.cmdApplyLServer.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 115)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Password:"
        '
        'txtLServerPass
        '
        Me.txtLServerPass.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLServerPass.Location = New System.Drawing.Point(79, 112)
        Me.txtLServerPass.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLServerPass.Name = "txtLServerPass"
        Me.txtLServerPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtLServerPass.Size = New System.Drawing.Size(124, 26)
        Me.txtLServerPass.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 76)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 13)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Username:"
        '
        'txtLServerUname
        '
        Me.txtLServerUname.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLServerUname.Location = New System.Drawing.Point(79, 73)
        Me.txtLServerUname.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLServerUname.Name = "txtLServerUname"
        Me.txtLServerUname.Size = New System.Drawing.Size(124, 26)
        Me.txtLServerUname.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 38)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 13)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Server IP:"
        '
        'txtLServerIP
        '
        Me.txtLServerIP.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLServerIP.Location = New System.Drawing.Point(79, 35)
        Me.txtLServerIP.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLServerIP.Name = "txtLServerIP"
        Me.txtLServerIP.Size = New System.Drawing.Size(124, 26)
        Me.txtLServerIP.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox14)
        Me.GroupBox1.Controls.Add(Me.cmdTestCServer)
        Me.GroupBox1.Controls.Add(Me.cmdApplyCServer)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtServerPass)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtServerUname)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtServerIP)
        Me.GroupBox1.Location = New System.Drawing.Point(404, 35)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(381, 305)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Central Server"
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.Label34)
        Me.GroupBox14.Controls.Add(Me.Label24)
        Me.GroupBox14.Controls.Add(Me.txtCSalesDB)
        Me.GroupBox14.Controls.Add(Me.Label25)
        Me.GroupBox14.Controls.Add(Me.txtCInventoryDB)
        Me.GroupBox14.Controls.Add(Me.txtCAuditDB)
        Me.GroupBox14.Location = New System.Drawing.Point(5, 150)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(289, 134)
        Me.GroupBox14.TabIndex = 21
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Database :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(48, 68)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(57, 13)
        Me.Label24.TabIndex = 18
        Me.Label24.Text = "Inventory :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(48, 30)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(37, 13)
        Me.Label25.TabIndex = 16
        Me.Label25.Text = "Audit :"
        '
        'txtCInventoryDB
        '
        Me.txtCInventoryDB.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCInventoryDB.Location = New System.Drawing.Point(111, 66)
        Me.txtCInventoryDB.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCInventoryDB.Name = "txtCInventoryDB"
        Me.txtCInventoryDB.Size = New System.Drawing.Size(128, 26)
        Me.txtCInventoryDB.TabIndex = 17
        '
        'txtCAuditDB
        '
        Me.txtCAuditDB.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCAuditDB.Location = New System.Drawing.Point(111, 29)
        Me.txtCAuditDB.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCAuditDB.Name = "txtCAuditDB"
        Me.txtCAuditDB.Size = New System.Drawing.Size(128, 26)
        Me.txtCAuditDB.TabIndex = 15
        '
        'cmdTestCServer
        '
        Me.cmdTestCServer.Location = New System.Drawing.Point(305, 157)
        Me.cmdTestCServer.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdTestCServer.Name = "cmdTestCServer"
        Me.cmdTestCServer.Size = New System.Drawing.Size(64, 61)
        Me.cmdTestCServer.TabIndex = 14
        Me.cmdTestCServer.Text = "Test"
        Me.cmdTestCServer.UseVisualStyleBackColor = True
        '
        'cmdApplyCServer
        '
        Me.cmdApplyCServer.Location = New System.Drawing.Point(305, 231)
        Me.cmdApplyCServer.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdApplyCServer.Name = "cmdApplyCServer"
        Me.cmdApplyCServer.Size = New System.Drawing.Size(64, 62)
        Me.cmdApplyCServer.TabIndex = 13
        Me.cmdApplyCServer.Text = "Apply"
        Me.cmdApplyCServer.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 115)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Password:"
        '
        'txtServerPass
        '
        Me.txtServerPass.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServerPass.Location = New System.Drawing.Point(78, 112)
        Me.txtServerPass.Margin = New System.Windows.Forms.Padding(2)
        Me.txtServerPass.Name = "txtServerPass"
        Me.txtServerPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtServerPass.Size = New System.Drawing.Size(128, 26)
        Me.txtServerPass.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 76)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Username:"
        '
        'txtServerUname
        '
        Me.txtServerUname.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServerUname.Location = New System.Drawing.Point(78, 73)
        Me.txtServerUname.Margin = New System.Windows.Forms.Padding(2)
        Me.txtServerUname.Name = "txtServerUname"
        Me.txtServerUname.Size = New System.Drawing.Size(128, 26)
        Me.txtServerUname.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 38)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Server IP:"
        '
        'txtServerIP
        '
        Me.txtServerIP.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServerIP.Location = New System.Drawing.Point(78, 35)
        Me.txtServerIP.Margin = New System.Windows.Forms.Padding(2)
        Me.txtServerIP.Name = "txtServerIP"
        Me.txtServerIP.Size = New System.Drawing.Size(128, 26)
        Me.txtServerIP.TabIndex = 7
        '
        'btnGotoLogin
        '
        Me.btnGotoLogin.Enabled = False
        Me.btnGotoLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGotoLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGotoLogin.ForeColor = System.Drawing.Color.Green
        Me.btnGotoLogin.Location = New System.Drawing.Point(688, 370)
        Me.btnGotoLogin.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGotoLogin.Name = "btnGotoLogin"
        Me.btnGotoLogin.Size = New System.Drawing.Size(97, 25)
        Me.btnGotoLogin.TabIndex = 22
        Me.btnGotoLogin.Text = "Go to Login"
        Me.btnGotoLogin.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(49, 103)
        Me.Label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(39, 13)
        Me.Label29.TabIndex = 24
        Me.Label29.Text = "Sales :"
        '
        'txtLSalesDB
        '
        Me.txtLSalesDB.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLSalesDB.Location = New System.Drawing.Point(115, 99)
        Me.txtLSalesDB.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLSalesDB.Name = "txtLSalesDB"
        Me.txtLSalesDB.Size = New System.Drawing.Size(124, 26)
        Me.txtLSalesDB.TabIndex = 23
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(49, 107)
        Me.Label34.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(39, 13)
        Me.Label34.TabIndex = 26
        Me.Label34.Text = "Sales :"
        '
        'txtCSalesDB
        '
        Me.txtCSalesDB.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCSalesDB.Location = New System.Drawing.Point(110, 103)
        Me.txtCSalesDB.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCSalesDB.Name = "txtCSalesDB"
        Me.txtCSalesDB.Size = New System.Drawing.Size(129, 26)
        Me.txtCSalesDB.TabIndex = 25
        '
        'frmInit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 410)
        Me.Controls.Add(Me.btnGotoLogin)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmInit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Server Settings"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents txtLAuditDB As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtLInventoryDB As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cmdTestLServer As Button
    Friend WithEvents cmdApplyLServer As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents txtLServerPass As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtLServerUname As TextBox
    Friend WithEvents Label19 As Label
    Public WithEvents txtLServerIP As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtCInventoryDB As TextBox
    Friend WithEvents txtCAuditDB As TextBox
    Friend WithEvents cmdTestCServer As Button
    Friend WithEvents cmdApplyCServer As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents txtServerPass As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtServerUname As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtServerIP As TextBox
    Friend WithEvents btnGotoLogin As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents txtLSalesDB As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents txtCSalesDB As TextBox
End Class

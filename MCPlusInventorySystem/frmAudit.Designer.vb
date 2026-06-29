<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAudit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tabAuth = New System.Windows.Forms.TabPage()
        Me.btnAddAuth = New System.Windows.Forms.Button()
        Me.dgAuth = New System.Windows.Forms.DataGridView()
        Me.tabTransact = New System.Windows.Forms.TabPage()
        Me.tabUsers = New System.Windows.Forms.TabPage()
        Me.btnCreateUserAcc = New System.Windows.Forms.Button()
        Me.dgAccountsUsers = New System.Windows.Forms.DataGridView()
        Me.user_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user_pass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user_comp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user_fullname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user_auth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user_desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user_stat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user_view = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.pbItem = New System.Windows.Forms.PictureBox()
        Me.tcAudit = New System.Windows.Forms.TabControl()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.comp_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.auth_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.auth_desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.auth_view = New System.Windows.Forms.DataGridViewImageColumn()
        Me.tabAuth.SuspendLayout()
        CType(Me.dgAuth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabUsers.SuspendLayout()
        CType(Me.dgAccountsUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcAudit.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabAuth
        '
        Me.tabAuth.Controls.Add(Me.btnAddAuth)
        Me.tabAuth.Controls.Add(Me.dgAuth)
        Me.tabAuth.Location = New System.Drawing.Point(4, 22)
        Me.tabAuth.Margin = New System.Windows.Forms.Padding(2)
        Me.tabAuth.Name = "tabAuth"
        Me.tabAuth.Padding = New System.Windows.Forms.Padding(2)
        Me.tabAuth.Size = New System.Drawing.Size(1093, 563)
        Me.tabAuth.TabIndex = 1
        Me.tabAuth.Text = "Authority"
        Me.tabAuth.UseVisualStyleBackColor = True
        '
        'btnAddAuth
        '
        Me.btnAddAuth.Location = New System.Drawing.Point(985, 36)
        Me.btnAddAuth.Name = "btnAddAuth"
        Me.btnAddAuth.Size = New System.Drawing.Size(103, 32)
        Me.btnAddAuth.TabIndex = 67
        Me.btnAddAuth.Text = "Add Authority"
        Me.btnAddAuth.UseVisualStyleBackColor = True
        '
        'dgAuth
        '
        Me.dgAuth.AllowUserToAddRows = False
        Me.dgAuth.AllowUserToDeleteRows = False
        Me.dgAuth.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAuth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgAuth.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgAuth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgAuth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAuth.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.comp_code, Me.auth_code, Me.auth_desc, Me.auth_view})
        Me.dgAuth.Location = New System.Drawing.Point(3, 73)
        Me.dgAuth.Margin = New System.Windows.Forms.Padding(2)
        Me.dgAuth.Name = "dgAuth"
        Me.dgAuth.RowHeadersVisible = False
        Me.dgAuth.RowHeadersWidth = 51
        Me.dgAuth.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAuth.Size = New System.Drawing.Size(1085, 489)
        Me.dgAuth.TabIndex = 21
        '
        'tabTransact
        '
        Me.tabTransact.Location = New System.Drawing.Point(4, 22)
        Me.tabTransact.Margin = New System.Windows.Forms.Padding(2)
        Me.tabTransact.Name = "tabTransact"
        Me.tabTransact.Size = New System.Drawing.Size(1093, 563)
        Me.tabTransact.TabIndex = 2
        Me.tabTransact.Text = "Transaction"
        Me.tabTransact.UseVisualStyleBackColor = True
        '
        'tabUsers
        '
        Me.tabUsers.Controls.Add(Me.btnCreateUserAcc)
        Me.tabUsers.Controls.Add(Me.dgAccountsUsers)
        Me.tabUsers.Controls.Add(Me.Button6)
        Me.tabUsers.Controls.Add(Me.Button4)
        Me.tabUsers.Controls.Add(Me.pbItem)
        Me.tabUsers.Location = New System.Drawing.Point(4, 22)
        Me.tabUsers.Margin = New System.Windows.Forms.Padding(2)
        Me.tabUsers.Name = "tabUsers"
        Me.tabUsers.Padding = New System.Windows.Forms.Padding(2)
        Me.tabUsers.Size = New System.Drawing.Size(1093, 563)
        Me.tabUsers.TabIndex = 0
        Me.tabUsers.Text = "Users"
        Me.tabUsers.UseVisualStyleBackColor = True
        '
        'btnCreateUserAcc
        '
        Me.btnCreateUserAcc.Location = New System.Drawing.Point(997, 37)
        Me.btnCreateUserAcc.Name = "btnCreateUserAcc"
        Me.btnCreateUserAcc.Size = New System.Drawing.Size(75, 32)
        Me.btnCreateUserAcc.TabIndex = 66
        Me.btnCreateUserAcc.Text = "Create new"
        Me.btnCreateUserAcc.UseVisualStyleBackColor = True
        '
        'dgAccountsUsers
        '
        Me.dgAccountsUsers.AllowUserToAddRows = False
        Me.dgAccountsUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAccountsUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgAccountsUsers.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgAccountsUsers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgAccountsUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAccountsUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.user_id, Me.user_pass, Me.user_comp, Me.user_fullname, Me.user_name, Me.user_auth, Me.user_desc, Me.user_stat, Me.user_view})
        Me.dgAccountsUsers.Location = New System.Drawing.Point(3, 74)
        Me.dgAccountsUsers.Margin = New System.Windows.Forms.Padding(2)
        Me.dgAccountsUsers.Name = "dgAccountsUsers"
        Me.dgAccountsUsers.RowHeadersVisible = False
        Me.dgAccountsUsers.RowHeadersWidth = 51
        Me.dgAccountsUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAccountsUsers.Size = New System.Drawing.Size(1086, 485)
        Me.dgAccountsUsers.TabIndex = 65
        '
        'user_id
        '
        Me.user_id.FillWeight = 50.0!
        Me.user_id.HeaderText = "ID"
        Me.user_id.MinimumWidth = 6
        Me.user_id.Name = "user_id"
        Me.user_id.ReadOnly = True
        '
        'user_pass
        '
        Me.user_pass.HeaderText = "Password"
        Me.user_pass.MinimumWidth = 6
        Me.user_pass.Name = "user_pass"
        Me.user_pass.ReadOnly = True
        Me.user_pass.Visible = False
        '
        'user_comp
        '
        Me.user_comp.HeaderText = "Company Code"
        Me.user_comp.MinimumWidth = 6
        Me.user_comp.Name = "user_comp"
        Me.user_comp.ReadOnly = True
        '
        'user_fullname
        '
        Me.user_fullname.HeaderText = "Full Name"
        Me.user_fullname.Name = "user_fullname"
        Me.user_fullname.ReadOnly = True
        '
        'user_name
        '
        Me.user_name.HeaderText = "Username"
        Me.user_name.MinimumWidth = 6
        Me.user_name.Name = "user_name"
        Me.user_name.ReadOnly = True
        '
        'user_auth
        '
        Me.user_auth.HeaderText = "Authority Code"
        Me.user_auth.MinimumWidth = 6
        Me.user_auth.Name = "user_auth"
        Me.user_auth.ReadOnly = True
        '
        'user_desc
        '
        Me.user_desc.HeaderText = "Description"
        Me.user_desc.MinimumWidth = 6
        Me.user_desc.Name = "user_desc"
        Me.user_desc.ReadOnly = True
        '
        'user_stat
        '
        Me.user_stat.HeaderText = "Status"
        Me.user_stat.MinimumWidth = 6
        Me.user_stat.Name = "user_stat"
        Me.user_stat.ReadOnly = True
        '
        'user_view
        '
        Me.user_view.FillWeight = 30.0!
        Me.user_view.HeaderText = ""
        Me.user_view.Image = Global.MCPlusInventorySystem.My.Resources.Resources.update
        Me.user_view.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.user_view.Name = "user_view"
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button6.Location = New System.Drawing.Point(1792, 47)
        Me.Button6.Margin = New System.Windows.Forms.Padding(2)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(44, 38)
        Me.Button6.TabIndex = 55
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.Location = New System.Drawing.Point(1592, 47)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(44, 38)
        Me.Button4.TabIndex = 54
        Me.Button4.UseVisualStyleBackColor = True
        '
        'pbItem
        '
        Me.pbItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbItem.Image = Global.MCPlusInventorySystem.My.Resources.Resources.default_item
        Me.pbItem.Location = New System.Drawing.Point(1640, 18)
        Me.pbItem.Margin = New System.Windows.Forms.Padding(2)
        Me.pbItem.Name = "pbItem"
        Me.pbItem.Size = New System.Drawing.Size(148, 98)
        Me.pbItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbItem.TabIndex = 52
        Me.pbItem.TabStop = False
        '
        'tcAudit
        '
        Me.tcAudit.Controls.Add(Me.tabUsers)
        Me.tcAudit.Controls.Add(Me.tabAuth)
        Me.tcAudit.Controls.Add(Me.tabTransact)
        Me.tcAudit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcAudit.Location = New System.Drawing.Point(0, 0)
        Me.tcAudit.Margin = New System.Windows.Forms.Padding(2)
        Me.tcAudit.Name = "tcAudit"
        Me.tcAudit.SelectedIndex = 0
        Me.tcAudit.Size = New System.Drawing.Size(1101, 589)
        Me.tcAudit.TabIndex = 34
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.FillWeight = 30.0!
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.MCPlusInventorySystem.My.Resources.Resources.update
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Width = 48
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.FillWeight = 20.0!
        Me.DataGridViewImageColumn2.HeaderText = ""
        Me.DataGridViewImageColumn2.Image = Global.MCPlusInventorySystem.My.Resources.Resources.update
        Me.DataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn2.Width = 99
        '
        'comp_code
        '
        Me.comp_code.HeaderText = "Company Code"
        Me.comp_code.MinimumWidth = 6
        Me.comp_code.Name = "comp_code"
        Me.comp_code.Visible = False
        '
        'auth_code
        '
        Me.auth_code.HeaderText = "Authority Code"
        Me.auth_code.MinimumWidth = 6
        Me.auth_code.Name = "auth_code"
        '
        'auth_desc
        '
        Me.auth_desc.HeaderText = "Description"
        Me.auth_desc.MinimumWidth = 6
        Me.auth_desc.Name = "auth_desc"
        '
        'auth_view
        '
        Me.auth_view.FillWeight = 20.0!
        Me.auth_view.HeaderText = ""
        Me.auth_view.Image = Global.MCPlusInventorySystem.My.Resources.Resources.update
        Me.auth_view.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.auth_view.Name = "auth_view"
        Me.auth_view.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.auth_view.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'frmAudit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 589)
        Me.Controls.Add(Me.tcAudit)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmAudit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Accounts Module"
        Me.tabAuth.ResumeLayout(False)
        CType(Me.dgAuth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabUsers.ResumeLayout(False)
        CType(Me.dgAccountsUsers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcAudit.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabAuth As TabPage
    Friend WithEvents tabTransact As TabPage
    Friend WithEvents tabUsers As TabPage
    Friend WithEvents Button6 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents pbItem As PictureBox
    Friend WithEvents tcAudit As TabControl
    Friend WithEvents dgAccountsUsers As DataGridView
    Friend WithEvents user_id As DataGridViewTextBoxColumn
    Friend WithEvents user_pass As DataGridViewTextBoxColumn
    Friend WithEvents user_comp As DataGridViewTextBoxColumn
    Friend WithEvents user_fullname As DataGridViewTextBoxColumn
    Friend WithEvents user_name As DataGridViewTextBoxColumn
    Friend WithEvents user_auth As DataGridViewTextBoxColumn
    Friend WithEvents user_desc As DataGridViewTextBoxColumn
    Friend WithEvents user_stat As DataGridViewTextBoxColumn
    Friend WithEvents user_view As DataGridViewImageColumn
    Friend WithEvents btnCreateUserAcc As Button
    Friend WithEvents dgAuth As DataGridView
    Friend WithEvents btnAddAuth As Button
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents comp_code As DataGridViewTextBoxColumn
    Friend WithEvents auth_code As DataGridViewTextBoxColumn
    Friend WithEvents auth_desc As DataGridViewTextBoxColumn
    Friend WithEvents auth_view As DataGridViewImageColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompany
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompany))
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.dgCompList = New System.Windows.Forms.DataGridView()
        Me.comp_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_addr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_tin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.company_url = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_contact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_create_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_create_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_created_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.com_edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.panelCom = New System.Windows.Forms.Panel()
        Me.lblComBtn = New System.Windows.Forms.Label()
        Me.txtComURL = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComCode = New System.Windows.Forms.TextBox()
        Me.btnComStatus = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtComDesc = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.pbComBanner = New System.Windows.Forms.PictureBox()
        Me.txtComAddr = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtComEmail = New System.Windows.Forms.TextBox()
        Me.txtComTIN = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtComNo = New System.Windows.Forms.TextBox()
        Me.btnComAdd = New System.Windows.Forms.Button()
        Me.btnComCancel = New System.Windows.Forms.Button()
        Me.btnComSave = New System.Windows.Forms.Button()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox11.SuspendLayout()
        CType(Me.dgCompList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.panelCom.SuspendLayout()
        CType(Me.pbComBanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox11
        '
        resources.ApplyResources(Me.GroupBox11, "GroupBox11")
        Me.GroupBox11.Controls.Add(Me.dgCompList)
        Me.GroupBox11.Controls.Add(Me.Panel2)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.TabStop = False
        '
        'dgCompList
        '
        Me.dgCompList.AllowUserToAddRows = False
        resources.ApplyResources(Me.dgCompList, "dgCompList")
        Me.dgCompList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgCompList.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgCompList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgCompList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCompList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.comp_id, Me.comp_code, Me.comp_desc, Me.comp_addr, Me.comp_tin, Me.company_url, Me.comp_contact, Me.comp_email, Me.comp_status, Me.comp_create_date, Me.comp_create_time, Me.comp_created_by, Me.com_edit})
        Me.dgCompList.Name = "dgCompList"
        Me.dgCompList.RowHeadersVisible = False
        Me.dgCompList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'comp_id
        '
        resources.ApplyResources(Me.comp_id, "comp_id")
        Me.comp_id.Name = "comp_id"
        Me.comp_id.ReadOnly = True
        '
        'comp_code
        '
        resources.ApplyResources(Me.comp_code, "comp_code")
        Me.comp_code.Name = "comp_code"
        Me.comp_code.ReadOnly = True
        '
        'comp_desc
        '
        resources.ApplyResources(Me.comp_desc, "comp_desc")
        Me.comp_desc.Name = "comp_desc"
        Me.comp_desc.ReadOnly = True
        '
        'comp_addr
        '
        resources.ApplyResources(Me.comp_addr, "comp_addr")
        Me.comp_addr.Name = "comp_addr"
        Me.comp_addr.ReadOnly = True
        '
        'comp_tin
        '
        resources.ApplyResources(Me.comp_tin, "comp_tin")
        Me.comp_tin.Name = "comp_tin"
        Me.comp_tin.ReadOnly = True
        '
        'company_url
        '
        resources.ApplyResources(Me.company_url, "company_url")
        Me.company_url.Name = "company_url"
        Me.company_url.ReadOnly = True
        '
        'comp_contact
        '
        resources.ApplyResources(Me.comp_contact, "comp_contact")
        Me.comp_contact.Name = "comp_contact"
        Me.comp_contact.ReadOnly = True
        '
        'comp_email
        '
        resources.ApplyResources(Me.comp_email, "comp_email")
        Me.comp_email.Name = "comp_email"
        Me.comp_email.ReadOnly = True
        '
        'comp_status
        '
        resources.ApplyResources(Me.comp_status, "comp_status")
        Me.comp_status.Name = "comp_status"
        Me.comp_status.ReadOnly = True
        '
        'comp_create_date
        '
        resources.ApplyResources(Me.comp_create_date, "comp_create_date")
        Me.comp_create_date.Name = "comp_create_date"
        Me.comp_create_date.ReadOnly = True
        '
        'comp_create_time
        '
        resources.ApplyResources(Me.comp_create_time, "comp_create_time")
        Me.comp_create_time.Name = "comp_create_time"
        Me.comp_create_time.ReadOnly = True
        '
        'comp_created_by
        '
        resources.ApplyResources(Me.comp_created_by, "comp_created_by")
        Me.comp_created_by.Name = "comp_created_by"
        Me.comp_created_by.ReadOnly = True
        '
        'com_edit
        '
        resources.ApplyResources(Me.com_edit, "com_edit")
        Me.com_edit.Image = Global.MCPlusInventorySystem.My.Resources.Resources.update
        Me.com_edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.com_edit.Name = "com_edit"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.panelCom)
        Me.Panel2.Controls.Add(Me.btnComAdd)
        Me.Panel2.Controls.Add(Me.btnComCancel)
        Me.Panel2.Controls.Add(Me.btnComSave)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'panelCom
        '
        Me.panelCom.Controls.Add(Me.lblComBtn)
        Me.panelCom.Controls.Add(Me.txtComURL)
        Me.panelCom.Controls.Add(Me.Label2)
        Me.panelCom.Controls.Add(Me.txtComCode)
        Me.panelCom.Controls.Add(Me.btnComStatus)
        Me.panelCom.Controls.Add(Me.Label22)
        Me.panelCom.Controls.Add(Me.Label1)
        Me.panelCom.Controls.Add(Me.txtComDesc)
        Me.panelCom.Controls.Add(Me.Label23)
        Me.panelCom.Controls.Add(Me.pbComBanner)
        Me.panelCom.Controls.Add(Me.txtComAddr)
        Me.panelCom.Controls.Add(Me.Label27)
        Me.panelCom.Controls.Add(Me.Label24)
        Me.panelCom.Controls.Add(Me.txtComEmail)
        Me.panelCom.Controls.Add(Me.txtComTIN)
        Me.panelCom.Controls.Add(Me.Label26)
        Me.panelCom.Controls.Add(Me.Label25)
        Me.panelCom.Controls.Add(Me.txtComNo)
        resources.ApplyResources(Me.panelCom, "panelCom")
        Me.panelCom.Name = "panelCom"
        '
        'lblComBtn
        '
        resources.ApplyResources(Me.lblComBtn, "lblComBtn")
        Me.lblComBtn.BackColor = System.Drawing.Color.Transparent
        Me.lblComBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblComBtn.Name = "lblComBtn"
        '
        'txtComURL
        '
        resources.ApplyResources(Me.txtComURL, "txtComURL")
        Me.txtComURL.Name = "txtComURL"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtComCode
        '
        resources.ApplyResources(Me.txtComCode, "txtComCode")
        Me.txtComCode.Name = "txtComCode"
        '
        'btnComStatus
        '
        resources.ApplyResources(Me.btnComStatus, "btnComStatus")
        Me.btnComStatus.Name = "btnComStatus"
        Me.btnComStatus.UseVisualStyleBackColor = True
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.Name = "Label22"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtComDesc
        '
        resources.ApplyResources(Me.txtComDesc, "txtComDesc")
        Me.txtComDesc.Name = "txtComDesc"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.Name = "Label23"
        '
        'pbComBanner
        '
        Me.pbComBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbComBanner.Image = Global.MCPlusInventorySystem.My.Resources.Resources.default_company
        resources.ApplyResources(Me.pbComBanner, "pbComBanner")
        Me.pbComBanner.Name = "pbComBanner"
        Me.pbComBanner.TabStop = False
        '
        'txtComAddr
        '
        resources.ApplyResources(Me.txtComAddr, "txtComAddr")
        Me.txtComAddr.Name = "txtComAddr"
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.Name = "Label27"
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.Name = "Label24"
        '
        'txtComEmail
        '
        resources.ApplyResources(Me.txtComEmail, "txtComEmail")
        Me.txtComEmail.Name = "txtComEmail"
        '
        'txtComTIN
        '
        resources.ApplyResources(Me.txtComTIN, "txtComTIN")
        Me.txtComTIN.Name = "txtComTIN"
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.Name = "Label26"
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.Name = "Label25"
        '
        'txtComNo
        '
        resources.ApplyResources(Me.txtComNo, "txtComNo")
        Me.txtComNo.Name = "txtComNo"
        '
        'btnComAdd
        '
        resources.ApplyResources(Me.btnComAdd, "btnComAdd")
        Me.btnComAdd.BackColor = System.Drawing.Color.Navy
        Me.btnComAdd.ForeColor = System.Drawing.SystemColors.Control
        Me.btnComAdd.Name = "btnComAdd"
        Me.btnComAdd.UseVisualStyleBackColor = False
        '
        'btnComCancel
        '
        resources.ApplyResources(Me.btnComCancel, "btnComCancel")
        Me.btnComCancel.BackColor = System.Drawing.Color.Red
        Me.btnComCancel.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnComCancel.Name = "btnComCancel"
        Me.btnComCancel.UseVisualStyleBackColor = False
        '
        'btnComSave
        '
        resources.ApplyResources(Me.btnComSave, "btnComSave")
        Me.btnComSave.BackColor = System.Drawing.Color.Green
        Me.btnComSave.ForeColor = System.Drawing.SystemColors.Control
        Me.btnComSave.Name = "btnComSave"
        Me.btnComSave.UseVisualStyleBackColor = False
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.FillWeight = 25.0!
        resources.ApplyResources(Me.DataGridViewImageColumn1, "DataGridViewImageColumn1")
        Me.DataGridViewImageColumn1.Image = Global.MCPlusInventorySystem.My.Resources.Resources.update
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.FillWeight = 25.0!
        resources.ApplyResources(Me.DataGridViewImageColumn2, "DataGridViewImageColumn2")
        Me.DataGridViewImageColumn2.Image = Global.MCPlusInventorySystem.My.Resources.Resources.remove
        Me.DataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        '
        'frmCompany
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox11)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmCompany"
        Me.GroupBox11.ResumeLayout(False)
        CType(Me.dgCompList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.panelCom.ResumeLayout(False)
        Me.panelCom.PerformLayout()
        CType(Me.pbComBanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnComAdd As Button
    Friend WithEvents btnComCancel As Button
    Friend WithEvents btnComSave As Button
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents dgCompList As DataGridView
    Friend WithEvents pbComBanner As PictureBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txtComEmail As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtComNo As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtComTIN As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtComAddr As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtComDesc As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtComCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtComURL As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnComStatus As Button
    Friend WithEvents comp_id As DataGridViewTextBoxColumn
    Friend WithEvents comp_code As DataGridViewTextBoxColumn
    Friend WithEvents comp_desc As DataGridViewTextBoxColumn
    Friend WithEvents comp_addr As DataGridViewTextBoxColumn
    Friend WithEvents comp_tin As DataGridViewTextBoxColumn
    Friend WithEvents company_url As DataGridViewTextBoxColumn
    Friend WithEvents comp_contact As DataGridViewTextBoxColumn
    Friend WithEvents comp_email As DataGridViewTextBoxColumn
    Friend WithEvents comp_status As DataGridViewTextBoxColumn
    Friend WithEvents comp_create_date As DataGridViewTextBoxColumn
    Friend WithEvents comp_create_time As DataGridViewTextBoxColumn
    Friend WithEvents comp_created_by As DataGridViewTextBoxColumn
    Friend WithEvents com_edit As DataGridViewImageColumn
    Friend WithEvents lblComBtn As Label
    Friend WithEvents panelCom As Panel
End Class

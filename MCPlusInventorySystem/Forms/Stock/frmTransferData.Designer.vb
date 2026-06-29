<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferData
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTTOrderID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.submitReturn = New System.Windows.Forms.Button()
        Me.cancelReturn = New System.Windows.Forms.Button()
        Me.panelReturn = New System.Windows.Forms.Panel()
        Me.toggleReturn = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnTransferGenDR = New System.Windows.Forms.Button()
        Me.btnTransferPicked = New System.Windows.Forms.Button()
        Me.lblTTStoreCodeDest = New System.Windows.Forms.Label()
        Me.btnTransferShowItems = New System.Windows.Forms.PictureBox()
        Me.btnTransferSubmitReroute = New System.Windows.Forms.Button()
        Me.btnTransferReject = New System.Windows.Forms.Button()
        Me.btnTransferReroute = New System.Windows.Forms.Button()
        Me.btnTransferApproved = New System.Windows.Forms.Button()
        Me.lblTTStatus = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTTStoreDest = New System.Windows.Forms.Label()
        Me.txtTTDRNo = New System.Windows.Forms.TextBox()
        Me.txtTTCreateDate = New System.Windows.Forms.TextBox()
        Me.txtTTRemarks = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTransferDRPrint = New System.Windows.Forms.Button()
        Me.dgTransferL = New System.Windows.Forms.DataGridView()
        Me.tt_companycode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_dr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_rowcount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_variant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_loc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_approved_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_received_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_total_amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_return_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_total_amount_return = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tt_remove = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtTTGrandTotal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.panelReturn.SuspendLayout()
        CType(Me.btnTransferShowItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTransferL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtTTGrandTotal)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTTOrderID)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.submitReturn)
        Me.GroupBox1.Controls.Add(Me.cancelReturn)
        Me.GroupBox1.Controls.Add(Me.panelReturn)
        Me.GroupBox1.Controls.Add(Me.btnTransferGenDR)
        Me.GroupBox1.Controls.Add(Me.btnTransferPicked)
        Me.GroupBox1.Controls.Add(Me.lblTTStoreCodeDest)
        Me.GroupBox1.Controls.Add(Me.btnTransferShowItems)
        Me.GroupBox1.Controls.Add(Me.btnTransferSubmitReroute)
        Me.GroupBox1.Controls.Add(Me.btnTransferReject)
        Me.GroupBox1.Controls.Add(Me.btnTransferReroute)
        Me.GroupBox1.Controls.Add(Me.btnTransferApproved)
        Me.GroupBox1.Controls.Add(Me.lblTTStatus)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblTTStoreDest)
        Me.GroupBox1.Controls.Add(Me.txtTTDRNo)
        Me.GroupBox1.Controls.Add(Me.txtTTCreateDate)
        Me.GroupBox1.Controls.Add(Me.txtTTRemarks)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnTransferDRPrint)
        Me.GroupBox1.Controls.Add(Me.dgTransferL)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1182, 559)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'txtTTOrderID
        '
        Me.txtTTOrderID.Location = New System.Drawing.Point(623, 71)
        Me.txtTTOrderID.Name = "txtTTOrderID"
        Me.txtTTOrderID.ReadOnly = True
        Me.txtTTOrderID.Size = New System.Drawing.Size(255, 20)
        Me.txtTTOrderID.TabIndex = 101
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(548, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "ORDER ID :"
        '
        'submitReturn
        '
        Me.submitReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.submitReturn.BackColor = System.Drawing.Color.ForestGreen
        Me.submitReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.submitReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.submitReturn.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.submitReturn.Location = New System.Drawing.Point(1070, 138)
        Me.submitReturn.Margin = New System.Windows.Forms.Padding(2)
        Me.submitReturn.Name = "submitReturn"
        Me.submitReturn.Size = New System.Drawing.Size(104, 24)
        Me.submitReturn.TabIndex = 99
        Me.submitReturn.Text = "Submit Return"
        Me.submitReturn.UseVisualStyleBackColor = False
        Me.submitReturn.Visible = False
        '
        'cancelReturn
        '
        Me.cancelReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelReturn.BackColor = System.Drawing.Color.IndianRed
        Me.cancelReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cancelReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelReturn.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.cancelReturn.Location = New System.Drawing.Point(950, 138)
        Me.cancelReturn.Margin = New System.Windows.Forms.Padding(2)
        Me.cancelReturn.Name = "cancelReturn"
        Me.cancelReturn.Size = New System.Drawing.Size(116, 24)
        Me.cancelReturn.TabIndex = 98
        Me.cancelReturn.Text = "Cancel"
        Me.cancelReturn.UseVisualStyleBackColor = False
        Me.cancelReturn.Visible = False
        '
        'panelReturn
        '
        Me.panelReturn.Controls.Add(Me.toggleReturn)
        Me.panelReturn.Controls.Add(Me.Label4)
        Me.panelReturn.Location = New System.Drawing.Point(0, 139)
        Me.panelReturn.Name = "panelReturn"
        Me.panelReturn.Size = New System.Drawing.Size(180, 23)
        Me.panelReturn.TabIndex = 97
        Me.panelReturn.Visible = False
        '
        'toggleReturn
        '
        Me.toggleReturn.AutoSize = True
        Me.toggleReturn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.toggleReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toggleReturn.ForeColor = System.Drawing.Color.Green
        Me.toggleReturn.Location = New System.Drawing.Point(109, 5)
        Me.toggleReturn.Name = "toggleReturn"
        Me.toggleReturn.Size = New System.Drawing.Size(36, 13)
        Me.toggleReturn.TabIndex = 96
        Me.toggleReturn.Text = "here."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(1, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 13)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "To return item(s), click "
        '
        'btnTransferGenDR
        '
        Me.btnTransferGenDR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransferGenDR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTransferGenDR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransferGenDR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransferGenDR.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnTransferGenDR.Location = New System.Drawing.Point(1041, 10)
        Me.btnTransferGenDR.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTransferGenDR.Name = "btnTransferGenDR"
        Me.btnTransferGenDR.Size = New System.Drawing.Size(135, 32)
        Me.btnTransferGenDR.TabIndex = 94
        Me.btnTransferGenDR.Text = "Download DR"
        Me.btnTransferGenDR.UseVisualStyleBackColor = True
        Me.btnTransferGenDR.Visible = False
        '
        'btnTransferPicked
        '
        Me.btnTransferPicked.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransferPicked.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTransferPicked.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTransferPicked.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransferPicked.Location = New System.Drawing.Point(992, 87)
        Me.btnTransferPicked.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTransferPicked.Name = "btnTransferPicked"
        Me.btnTransferPicked.Size = New System.Drawing.Size(82, 42)
        Me.btnTransferPicked.TabIndex = 92
        Me.btnTransferPicked.Text = "Pick Complete"
        Me.btnTransferPicked.UseVisualStyleBackColor = True
        Me.btnTransferPicked.Visible = False
        '
        'lblTTStoreCodeDest
        '
        Me.lblTTStoreCodeDest.AutoSize = True
        Me.lblTTStoreCodeDest.Location = New System.Drawing.Point(95, 49)
        Me.lblTTStoreCodeDest.Name = "lblTTStoreCodeDest"
        Me.lblTTStoreCodeDest.Size = New System.Drawing.Size(85, 13)
        Me.lblTTStoreCodeDest.TabIndex = 91
        Me.lblTTStoreCodeDest.Text = "Store Code Dest"
        '
        'btnTransferShowItems
        '
        Me.btnTransferShowItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransferShowItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTransferShowItems.Image = Global.MCPlusInventorySystem.My.Resources.Resources.searchlist_icon
        Me.btnTransferShowItems.Location = New System.Drawing.Point(1132, 119)
        Me.btnTransferShowItems.Name = "btnTransferShowItems"
        Me.btnTransferShowItems.Size = New System.Drawing.Size(44, 34)
        Me.btnTransferShowItems.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnTransferShowItems.TabIndex = 90
        Me.btnTransferShowItems.TabStop = False
        Me.btnTransferShowItems.Visible = False
        '
        'btnTransferSubmitReroute
        '
        Me.btnTransferSubmitReroute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransferSubmitReroute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTransferSubmitReroute.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTransferSubmitReroute.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransferSubmitReroute.Location = New System.Drawing.Point(1022, 67)
        Me.btnTransferSubmitReroute.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTransferSubmitReroute.Name = "btnTransferSubmitReroute"
        Me.btnTransferSubmitReroute.Size = New System.Drawing.Size(82, 35)
        Me.btnTransferSubmitReroute.TabIndex = 89
        Me.btnTransferSubmitReroute.Text = "Submit"
        Me.btnTransferSubmitReroute.UseVisualStyleBackColor = True
        Me.btnTransferSubmitReroute.Visible = False
        '
        'btnTransferReject
        '
        Me.btnTransferReject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransferReject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTransferReject.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTransferReject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransferReject.Location = New System.Drawing.Point(1078, 86)
        Me.btnTransferReject.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTransferReject.Name = "btnTransferReject"
        Me.btnTransferReject.Size = New System.Drawing.Size(82, 42)
        Me.btnTransferReject.TabIndex = 88
        Me.btnTransferReject.Text = "Reject"
        Me.btnTransferReject.UseVisualStyleBackColor = True
        Me.btnTransferReject.Visible = False
        '
        'btnTransferReroute
        '
        Me.btnTransferReroute.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransferReroute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTransferReroute.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTransferReroute.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransferReroute.Location = New System.Drawing.Point(906, 87)
        Me.btnTransferReroute.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTransferReroute.Name = "btnTransferReroute"
        Me.btnTransferReroute.Size = New System.Drawing.Size(82, 42)
        Me.btnTransferReroute.TabIndex = 87
        Me.btnTransferReroute.Text = "Reroute"
        Me.btnTransferReroute.UseVisualStyleBackColor = True
        Me.btnTransferReroute.Visible = False
        '
        'btnTransferApproved
        '
        Me.btnTransferApproved.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransferApproved.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTransferApproved.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTransferApproved.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransferApproved.Location = New System.Drawing.Point(993, 86)
        Me.btnTransferApproved.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTransferApproved.Name = "btnTransferApproved"
        Me.btnTransferApproved.Size = New System.Drawing.Size(82, 42)
        Me.btnTransferApproved.TabIndex = 86
        Me.btnTransferApproved.Text = "Approve"
        Me.btnTransferApproved.UseVisualStyleBackColor = True
        Me.btnTransferApproved.Visible = False
        '
        'lblTTStatus
        '
        Me.lblTTStatus.AutoSize = True
        Me.lblTTStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTTStatus.ForeColor = System.Drawing.Color.Black
        Me.lblTTStatus.Location = New System.Drawing.Point(551, 29)
        Me.lblTTStatus.Name = "lblTTStatus"
        Me.lblTTStatus.Size = New System.Drawing.Size(39, 13)
        Me.lblTTStatus.TabIndex = 85
        Me.lblTTStatus.Text = "STAT"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(504, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Status :"
        '
        'lblTTStoreDest
        '
        Me.lblTTStoreDest.AutoSize = True
        Me.lblTTStoreDest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTTStoreDest.ForeColor = System.Drawing.Color.Black
        Me.lblTTStoreDest.Location = New System.Drawing.Point(93, 27)
        Me.lblTTStoreDest.Name = "lblTTStoreDest"
        Me.lblTTStoreDest.Size = New System.Drawing.Size(43, 15)
        Me.lblTTStoreDest.TabIndex = 83
        Me.lblTTStoreDest.Text = "DEST"
        '
        'txtTTDRNo
        '
        Me.txtTTDRNo.Location = New System.Drawing.Point(67, 71)
        Me.txtTTDRNo.Name = "txtTTDRNo"
        Me.txtTTDRNo.ReadOnly = True
        Me.txtTTDRNo.Size = New System.Drawing.Size(156, 20)
        Me.txtTTDRNo.TabIndex = 80
        '
        'txtTTCreateDate
        '
        Me.txtTTCreateDate.Location = New System.Drawing.Point(327, 71)
        Me.txtTTCreateDate.Name = "txtTTCreateDate"
        Me.txtTTCreateDate.ReadOnly = True
        Me.txtTTCreateDate.Size = New System.Drawing.Size(167, 20)
        Me.txtTTCreateDate.TabIndex = 79
        '
        'txtTTRemarks
        '
        Me.txtTTRemarks.Location = New System.Drawing.Point(101, 109)
        Me.txtTTRemarks.Name = "txtTTRemarks"
        Me.txtTTRemarks.ReadOnly = True
        Me.txtTTRemarks.Size = New System.Drawing.Size(362, 20)
        Me.txtTTRemarks.TabIndex = 78
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "REMARKS :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(245, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Date Created :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Destination :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "DR :"
        '
        'btnTransferDRPrint
        '
        Me.btnTransferDRPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransferDRPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTransferDRPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTransferDRPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransferDRPrint.Location = New System.Drawing.Point(1041, 87)
        Me.btnTransferDRPrint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTransferDRPrint.Name = "btnTransferDRPrint"
        Me.btnTransferDRPrint.Size = New System.Drawing.Size(82, 42)
        Me.btnTransferDRPrint.TabIndex = 68
        Me.btnTransferDRPrint.Text = "Deliver Now"
        Me.btnTransferDRPrint.UseVisualStyleBackColor = True
        Me.btnTransferDRPrint.Visible = False
        '
        'dgTransferL
        '
        Me.dgTransferL.AllowUserToAddRows = False
        Me.dgTransferL.AllowUserToDeleteRows = False
        Me.dgTransferL.AllowUserToResizeRows = False
        Me.dgTransferL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTransferL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransferL.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgTransferL.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransferL.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTransferL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgTransferL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTransferL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tt_companycode, Me.tt_dr, Me.tt_rowcount, Me.tt_sku, Me.tt_item, Me.tt_color, Me.tt_variant, Me.tt_loc, Me.tt_qty, Me.tt_approved_qty, Me.tt_received_qty, Me.tt_total_amount, Me.tt_return_qty, Me.tt_total_amount_return, Me.tt_remove})
        Me.dgTransferL.Location = New System.Drawing.Point(0, 163)
        Me.dgTransferL.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransferL.Name = "dgTransferL"
        Me.dgTransferL.RowHeadersVisible = False
        Me.dgTransferL.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTransferL.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgTransferL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransferL.Size = New System.Drawing.Size(1182, 396)
        Me.dgTransferL.TabIndex = 41
        '
        'tt_companycode
        '
        Me.tt_companycode.HeaderText = "Company Code"
        Me.tt_companycode.Name = "tt_companycode"
        Me.tt_companycode.ReadOnly = True
        Me.tt_companycode.Visible = False
        '
        'tt_dr
        '
        Me.tt_dr.HeaderText = "DR"
        Me.tt_dr.Name = "tt_dr"
        Me.tt_dr.ReadOnly = True
        Me.tt_dr.Visible = False
        '
        'tt_rowcount
        '
        Me.tt_rowcount.FillWeight = 20.0!
        Me.tt_rowcount.HeaderText = ""
        Me.tt_rowcount.Name = "tt_rowcount"
        Me.tt_rowcount.ReadOnly = True
        '
        'tt_sku
        '
        Me.tt_sku.FillWeight = 70.0!
        Me.tt_sku.HeaderText = "SKU"
        Me.tt_sku.Name = "tt_sku"
        Me.tt_sku.ReadOnly = True
        '
        'tt_item
        '
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tt_item.DefaultCellStyle = DataGridViewCellStyle6
        Me.tt_item.HeaderText = "Item"
        Me.tt_item.Name = "tt_item"
        Me.tt_item.ReadOnly = True
        '
        'tt_color
        '
        Me.tt_color.FillWeight = 70.0!
        Me.tt_color.HeaderText = "Color"
        Me.tt_color.Name = "tt_color"
        Me.tt_color.ReadOnly = True
        '
        'tt_variant
        '
        Me.tt_variant.HeaderText = "Variation"
        Me.tt_variant.Name = "tt_variant"
        Me.tt_variant.ReadOnly = True
        '
        'tt_loc
        '
        Me.tt_loc.FillWeight = 52.0!
        Me.tt_loc.HeaderText = "Location"
        Me.tt_loc.Name = "tt_loc"
        Me.tt_loc.ReadOnly = True
        '
        'tt_qty
        '
        Me.tt_qty.FillWeight = 40.0!
        Me.tt_qty.HeaderText = "Qty"
        Me.tt_qty.Name = "tt_qty"
        '
        'tt_approved_qty
        '
        Me.tt_approved_qty.FillWeight = 50.0!
        Me.tt_approved_qty.HeaderText = "Qty Approved"
        Me.tt_approved_qty.Name = "tt_approved_qty"
        Me.tt_approved_qty.ReadOnly = True
        '
        'tt_received_qty
        '
        Me.tt_received_qty.FillWeight = 50.0!
        Me.tt_received_qty.HeaderText = "Qty Received"
        Me.tt_received_qty.Name = "tt_received_qty"
        Me.tt_received_qty.ReadOnly = True
        '
        'tt_total_amount
        '
        Me.tt_total_amount.FillWeight = 70.0!
        Me.tt_total_amount.HeaderText = "Total Amount"
        Me.tt_total_amount.Name = "tt_total_amount"
        Me.tt_total_amount.ReadOnly = True
        '
        'tt_return_qty
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.tt_return_qty.DefaultCellStyle = DataGridViewCellStyle7
        Me.tt_return_qty.FillWeight = 50.0!
        Me.tt_return_qty.HeaderText = "Return Qty"
        Me.tt_return_qty.Name = "tt_return_qty"
        Me.tt_return_qty.ReadOnly = True
        Me.tt_return_qty.Visible = False
        '
        'tt_total_amount_return
        '
        Me.tt_total_amount_return.FillWeight = 70.0!
        Me.tt_total_amount_return.HeaderText = "Total Amount Return"
        Me.tt_total_amount_return.Name = "tt_total_amount_return"
        Me.tt_total_amount_return.ReadOnly = True
        Me.tt_total_amount_return.Visible = False
        '
        'tt_remove
        '
        Me.tt_remove.FillWeight = 20.0!
        Me.tt_remove.HeaderText = ""
        Me.tt_remove.Image = Global.MCPlusInventorySystem.My.Resources.Resources.remove
        Me.tt_remove.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.tt_remove.Name = "tt_remove"
        Me.tt_remove.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tt_remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.tt_remove.Visible = False
        '
        'txtTTGrandTotal
        '
        Me.txtTTGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTTGrandTotal.Location = New System.Drawing.Point(694, 97)
        Me.txtTTGrandTotal.Name = "txtTTGrandTotal"
        Me.txtTTGrandTotal.ReadOnly = True
        Me.txtTTGrandTotal.Size = New System.Drawing.Size(184, 21)
        Me.txtTTGrandTotal.TabIndex = 103
        Me.txtTTGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(548, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 13)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "GRAND TOTAL AMOUNT :"
        '
        'frmTransferData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 561)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1200, 600)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1119, 600)
        Me.Name = "frmTransferData"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transfer To"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.panelReturn.ResumeLayout(False)
        Me.panelReturn.PerformLayout()
        CType(Me.btnTransferShowItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTransferL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTTStatus As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTTStoreDest As Label
    Friend WithEvents txtTTDRNo As TextBox
    Friend WithEvents txtTTCreateDate As TextBox
    Friend WithEvents txtTTRemarks As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnTransferDRPrint As Button
    Friend WithEvents dgTransferL As DataGridView
    Friend WithEvents btnTransferApproved As Button
    Friend WithEvents btnTransferReroute As Button
    Friend WithEvents btnTransferReject As Button
    Friend WithEvents btnTransferSubmitReroute As Button
    Friend WithEvents btnTransferShowItems As PictureBox
    Friend WithEvents lblTTStoreCodeDest As Label
    Friend WithEvents btnTransferPicked As Button
    Friend WithEvents btnTransferGenDR As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents toggleReturn As Label
    Friend WithEvents panelReturn As Panel
    Friend WithEvents cancelReturn As Button
    Friend WithEvents submitReturn As Button
    Friend WithEvents tt_companycode As DataGridViewTextBoxColumn
    Friend WithEvents tt_dr As DataGridViewTextBoxColumn
    Friend WithEvents tt_rowcount As DataGridViewTextBoxColumn
    Friend WithEvents tt_sku As DataGridViewTextBoxColumn
    Friend WithEvents tt_item As DataGridViewTextBoxColumn
    Friend WithEvents tt_color As DataGridViewTextBoxColumn
    Friend WithEvents tt_variant As DataGridViewTextBoxColumn
    Friend WithEvents tt_loc As DataGridViewTextBoxColumn
    Friend WithEvents tt_qty As DataGridViewTextBoxColumn
    Friend WithEvents tt_approved_qty As DataGridViewTextBoxColumn
    Friend WithEvents tt_received_qty As DataGridViewTextBoxColumn
    Friend WithEvents tt_total_amount As DataGridViewTextBoxColumn
    Friend WithEvents tt_return_qty As DataGridViewTextBoxColumn
    Friend WithEvents tt_total_amount_return As DataGridViewTextBoxColumn
    Friend WithEvents tt_remove As DataGridViewImageColumn
    Friend WithEvents txtTTOrderID As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTTGrandTotal As TextBox
    Friend WithEvents Label7 As Label
End Class

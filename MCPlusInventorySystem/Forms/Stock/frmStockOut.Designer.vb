<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStockOut
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tcStockOut = New System.Windows.Forms.TabControl()
        Me.tabTransferItem = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTTOrderID = New System.Windows.Forms.TextBox()
        Me.btnTTTransfer = New System.Windows.Forms.Button()
        Me.lblTTStoreCodeDest = New System.Windows.Forms.Label()
        Me.cbTTStoreDest = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTTRemarks = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTTDR = New System.Windows.Forms.TextBox()
        Me.btnTTShowItems = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgTransfer = New System.Windows.Forms.DataGridView()
        Me.transfer_skucode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transfer_desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transfer_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transfer_variant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transfer_loc_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transfer_stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transfer_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transfer_total_amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transfer_remove = New System.Windows.Forms.DataGridViewImageColumn()
        Me.tabTransferAll = New System.Windows.Forms.TabPage()
        Me.dgTransferAll = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tabTransfer10 = New System.Windows.Forms.TabPage()
        Me.dgTransfer10 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_view10 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabTransfer0 = New System.Windows.Forms.TabPage()
        Me.dgTransfer0 = New System.Windows.Forms.DataGridView()
        Me.th_companycode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_storecode_orig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_storecode_dest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_dr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_datecreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_view0 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabTransfer1 = New System.Windows.Forms.TabPage()
        Me.dgTransfer1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_view1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tabTransfer2 = New System.Windows.Forms.TabPage()
        Me.dgTransfer2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_view2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabTransfer3 = New System.Windows.Forms.TabPage()
        Me.dgTransfer3 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_view3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabTransferPartialReceived = New System.Windows.Forms.TabPage()
        Me.dgTransferPartialReceived = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_viewParRec = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tabTransfer4 = New System.Windows.Forms.TabPage()
        Me.dgTransfer4 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_view4 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tabTransfer9 = New System.Windows.Forms.TabPage()
        Me.dgTransfer9 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn41 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn42 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_view9 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.cbAllStatusStore = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAllStatusFind = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn43 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn44 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_storedestAll = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_drAll = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_orderIDAll = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn47 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn48 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.th_viewAll = New System.Windows.Forms.DataGridViewImageColumn()
        Me.lblTTStoreCodeDestAll = New System.Windows.Forms.Label()
        Me.tcStockOut.SuspendLayout()
        Me.tabTransferItem.SuspendLayout()
        CType(Me.btnTTShowItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTransferAll.SuspendLayout()
        CType(Me.dgTransferAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.tabTransfer10.SuspendLayout()
        CType(Me.dgTransfer10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTransfer0.SuspendLayout()
        CType(Me.dgTransfer0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTransfer1.SuspendLayout()
        CType(Me.dgTransfer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTransfer2.SuspendLayout()
        CType(Me.dgTransfer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTransfer3.SuspendLayout()
        CType(Me.dgTransfer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTransferPartialReceived.SuspendLayout()
        CType(Me.dgTransferPartialReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTransfer4.SuspendLayout()
        CType(Me.dgTransfer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTransfer9.SuspendLayout()
        CType(Me.dgTransfer9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcStockOut
        '
        Me.tcStockOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcStockOut.Controls.Add(Me.tabTransferItem)
        Me.tcStockOut.Controls.Add(Me.tabTransferAll)
        Me.tcStockOut.Controls.Add(Me.tabTransfer10)
        Me.tcStockOut.Controls.Add(Me.tabTransfer0)
        Me.tcStockOut.Controls.Add(Me.tabTransfer1)
        Me.tcStockOut.Controls.Add(Me.tabTransfer2)
        Me.tcStockOut.Controls.Add(Me.tabTransfer3)
        Me.tcStockOut.Controls.Add(Me.tabTransferPartialReceived)
        Me.tcStockOut.Controls.Add(Me.tabTransfer4)
        Me.tcStockOut.Controls.Add(Me.tabTransfer9)
        Me.tcStockOut.Location = New System.Drawing.Point(-2, 10)
        Me.tcStockOut.Name = "tcStockOut"
        Me.tcStockOut.SelectedIndex = 0
        Me.tcStockOut.Size = New System.Drawing.Size(1094, 648)
        Me.tcStockOut.TabIndex = 1
        '
        'tabTransferItem
        '
        Me.tabTransferItem.Controls.Add(Me.Label14)
        Me.tabTransferItem.Controls.Add(Me.txtTTOrderID)
        Me.tabTransferItem.Controls.Add(Me.btnTTTransfer)
        Me.tabTransferItem.Controls.Add(Me.lblTTStoreCodeDest)
        Me.tabTransferItem.Controls.Add(Me.cbTTStoreDest)
        Me.tabTransferItem.Controls.Add(Me.Label10)
        Me.tabTransferItem.Controls.Add(Me.txtTTRemarks)
        Me.tabTransferItem.Controls.Add(Me.Label12)
        Me.tabTransferItem.Controls.Add(Me.Label13)
        Me.tabTransferItem.Controls.Add(Me.txtTTDR)
        Me.tabTransferItem.Controls.Add(Me.btnTTShowItems)
        Me.tabTransferItem.Controls.Add(Me.Label8)
        Me.tabTransferItem.Controls.Add(Me.dgTransfer)
        Me.tabTransferItem.Location = New System.Drawing.Point(4, 22)
        Me.tabTransferItem.Name = "tabTransferItem"
        Me.tabTransferItem.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTransferItem.Size = New System.Drawing.Size(1086, 622)
        Me.tabTransferItem.TabIndex = 0
        Me.tabTransferItem.Text = "Transfer Creation"
        Me.tabTransferItem.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(49, 138)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 13)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "Order ID :"
        '
        'txtTTOrderID
        '
        Me.txtTTOrderID.Location = New System.Drawing.Point(123, 131)
        Me.txtTTOrderID.Name = "txtTTOrderID"
        Me.txtTTOrderID.Size = New System.Drawing.Size(471, 20)
        Me.txtTTOrderID.TabIndex = 45
        '
        'btnTTTransfer
        '
        Me.btnTTTransfer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTTTransfer.BackColor = System.Drawing.Color.Teal
        Me.btnTTTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTTTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTTTransfer.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnTTTransfer.Location = New System.Drawing.Point(973, 588)
        Me.btnTTTransfer.Name = "btnTTTransfer"
        Me.btnTTTransfer.Size = New System.Drawing.Size(104, 31)
        Me.btnTTTransfer.TabIndex = 44
        Me.btnTTTransfer.Text = "Create Transfer"
        Me.btnTTTransfer.UseVisualStyleBackColor = False
        '
        'lblTTStoreCodeDest
        '
        Me.lblTTStoreCodeDest.AutoSize = True
        Me.lblTTStoreCodeDest.Location = New System.Drawing.Point(398, 46)
        Me.lblTTStoreCodeDest.Name = "lblTTStoreCodeDest"
        Me.lblTTStoreCodeDest.Size = New System.Drawing.Size(16, 13)
        Me.lblTTStoreCodeDest.TabIndex = 43
        Me.lblTTStoreCodeDest.Text = "---"
        '
        'cbTTStoreDest
        '
        Me.cbTTStoreDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTTStoreDest.FormattingEnabled = True
        Me.cbTTStoreDest.Location = New System.Drawing.Point(123, 40)
        Me.cbTTStoreDest.Name = "cbTTStoreDest"
        Me.cbTTStoreDest.Size = New System.Drawing.Size(219, 21)
        Me.cbTTStoreDest.TabIndex = 42
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(479, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "REMARKS :"
        '
        'txtTTRemarks
        '
        Me.txtTTRemarks.Location = New System.Drawing.Point(561, 89)
        Me.txtTTRemarks.Name = "txtTTRemarks"
        Me.txtTTRemarks.Size = New System.Drawing.Size(383, 20)
        Me.txtTTRemarks.TabIndex = 37
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(31, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Select Store :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(73, 96)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 13)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "DR :"
        '
        'txtTTDR
        '
        Me.txtTTDR.Location = New System.Drawing.Point(123, 89)
        Me.txtTTDR.Name = "txtTTDR"
        Me.txtTTDR.ReadOnly = True
        Me.txtTTDR.Size = New System.Drawing.Size(219, 20)
        Me.txtTTDR.TabIndex = 33
        '
        'btnTTShowItems
        '
        Me.btnTTShowItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTTShowItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTTShowItems.Image = Global.MCPlusInventorySystem.My.Resources.Resources.searchlist_icon
        Me.btnTTShowItems.Location = New System.Drawing.Point(1025, 157)
        Me.btnTTShowItems.Name = "btnTTShowItems"
        Me.btnTTShowItems.Size = New System.Drawing.Size(44, 34)
        Me.btnTTShowItems.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnTTShowItems.TabIndex = 32
        Me.btnTTShowItems.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("News706 BT", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 174)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 18)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Transfer item/s"
        '
        'dgTransfer
        '
        Me.dgTransfer.AllowUserToAddRows = False
        Me.dgTransfer.AllowUserToDeleteRows = False
        Me.dgTransfer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTransfer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransfer.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransfer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgTransfer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.transfer_skucode, Me.transfer_desc, Me.transfer_color, Me.transfer_variant, Me.transfer_loc_code, Me.transfer_stock, Me.transfer_qty, Me.transfer_total_amount, Me.transfer_remove})
        Me.dgTransfer.Location = New System.Drawing.Point(5, 196)
        Me.dgTransfer.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransfer.Name = "dgTransfer"
        Me.dgTransfer.RowHeadersVisible = False
        Me.dgTransfer.RowHeadersWidth = 51
        Me.dgTransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransfer.Size = New System.Drawing.Size(1075, 387)
        Me.dgTransfer.TabIndex = 18
        '
        'transfer_skucode
        '
        Me.transfer_skucode.HeaderText = "SKU"
        Me.transfer_skucode.Name = "transfer_skucode"
        Me.transfer_skucode.ReadOnly = True
        '
        'transfer_desc
        '
        Me.transfer_desc.HeaderText = "Product Desc."
        Me.transfer_desc.Name = "transfer_desc"
        Me.transfer_desc.ReadOnly = True
        '
        'transfer_color
        '
        Me.transfer_color.HeaderText = "Color"
        Me.transfer_color.Name = "transfer_color"
        Me.transfer_color.ReadOnly = True
        '
        'transfer_variant
        '
        Me.transfer_variant.HeaderText = "Variation"
        Me.transfer_variant.Name = "transfer_variant"
        Me.transfer_variant.ReadOnly = True
        '
        'transfer_loc_code
        '
        Me.transfer_loc_code.HeaderText = "Location"
        Me.transfer_loc_code.Name = "transfer_loc_code"
        Me.transfer_loc_code.ReadOnly = True
        '
        'transfer_stock
        '
        Me.transfer_stock.HeaderText = "Stock"
        Me.transfer_stock.Name = "transfer_stock"
        Me.transfer_stock.ReadOnly = True
        '
        'transfer_qty
        '
        Me.transfer_qty.FillWeight = 50.0!
        Me.transfer_qty.HeaderText = "Qty"
        Me.transfer_qty.Name = "transfer_qty"
        '
        'transfer_total_amount
        '
        Me.transfer_total_amount.FillWeight = 80.0!
        Me.transfer_total_amount.HeaderText = "Total Amount"
        Me.transfer_total_amount.Name = "transfer_total_amount"
        '
        'transfer_remove
        '
        Me.transfer_remove.FillWeight = 30.0!
        Me.transfer_remove.HeaderText = ""
        Me.transfer_remove.Image = Global.MCPlusInventorySystem.My.Resources.Resources.remove
        Me.transfer_remove.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.transfer_remove.Name = "transfer_remove"
        '
        'tabTransferAll
        '
        Me.tabTransferAll.Controls.Add(Me.dgTransferAll)
        Me.tabTransferAll.Controls.Add(Me.Panel1)
        Me.tabTransferAll.Location = New System.Drawing.Point(4, 22)
        Me.tabTransferAll.Name = "tabTransferAll"
        Me.tabTransferAll.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTransferAll.Size = New System.Drawing.Size(1086, 622)
        Me.tabTransferAll.TabIndex = 10
        Me.tabTransferAll.Text = "All Status"
        Me.tabTransferAll.UseVisualStyleBackColor = True
        '
        'dgTransferAll
        '
        Me.dgTransferAll.AllowUserToAddRows = False
        Me.dgTransferAll.AllowUserToDeleteRows = False
        Me.dgTransferAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransferAll.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransferAll.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgTransferAll.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn43, Me.Column1, Me.DataGridViewTextBoxColumn44, Me.th_storedestAll, Me.th_drAll, Me.th_orderIDAll, Me.DataGridViewTextBoxColumn47, Me.DataGridViewTextBoxColumn48, Me.th_viewAll})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTransferAll.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgTransferAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTransferAll.Location = New System.Drawing.Point(3, 103)
        Me.dgTransferAll.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransferAll.Name = "dgTransferAll"
        Me.dgTransferAll.ReadOnly = True
        Me.dgTransferAll.RowHeadersVisible = False
        Me.dgTransferAll.RowHeadersWidth = 51
        Me.dgTransferAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransferAll.Size = New System.Drawing.Size(1080, 516)
        Me.dgTransferAll.TabIndex = 26
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Honeydew
        Me.Panel1.Controls.Add(Me.lblTTStoreCodeDestAll)
        Me.Panel1.Controls.Add(Me.cbAllStatusStore)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtAllStatusFind)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1080, 100)
        Me.Panel1.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Honeydew
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label11.Size = New System.Drawing.Size(1080, 37)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "ALL STATUS"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabTransfer10
        '
        Me.tabTransfer10.Controls.Add(Me.dgTransfer10)
        Me.tabTransfer10.Controls.Add(Me.Label1)
        Me.tabTransfer10.Location = New System.Drawing.Point(4, 22)
        Me.tabTransfer10.Name = "tabTransfer10"
        Me.tabTransfer10.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTransfer10.Size = New System.Drawing.Size(1086, 622)
        Me.tabTransfer10.TabIndex = 7
        Me.tabTransfer10.Text = "Reroute"
        Me.tabTransfer10.UseVisualStyleBackColor = True
        '
        'dgTransfer10
        '
        Me.dgTransfer10.AllowUserToAddRows = False
        Me.dgTransfer10.AllowUserToDeleteRows = False
        Me.dgTransfer10.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransfer10.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransfer10.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgTransfer10.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Column2, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.th_view10})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTransfer10.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgTransfer10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTransfer10.Location = New System.Drawing.Point(3, 39)
        Me.dgTransfer10.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransfer10.Name = "dgTransfer10"
        Me.dgTransfer10.ReadOnly = True
        Me.dgTransfer10.RowHeadersVisible = False
        Me.dgTransfer10.RowHeadersWidth = 51
        Me.dgTransfer10.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransfer10.Size = New System.Drawing.Size(1080, 580)
        Me.dgTransfer10.TabIndex = 8
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Company Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Status Code"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Store Code"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Store Destination"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn4.HeaderText = "DR"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Date Created"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'th_view10
        '
        Me.th_view10.FillWeight = 30.0!
        Me.th_view10.HeaderText = ""
        Me.th_view10.Image = Global.MCPlusInventorySystem.My.Resources.Resources.listview
        Me.th_view10.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.th_view10.Name = "th_view10"
        Me.th_view10.ReadOnly = True
        Me.th_view10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.th_view10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOrange
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(1080, 36)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Reroute"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabTransfer0
        '
        Me.tabTransfer0.Controls.Add(Me.dgTransfer0)
        Me.tabTransfer0.Controls.Add(Me.Label2)
        Me.tabTransfer0.Location = New System.Drawing.Point(4, 22)
        Me.tabTransfer0.Name = "tabTransfer0"
        Me.tabTransfer0.Size = New System.Drawing.Size(1086, 622)
        Me.tabTransfer0.TabIndex = 1
        Me.tabTransfer0.Text = "For Approval"
        Me.tabTransfer0.UseVisualStyleBackColor = True
        '
        'dgTransfer0
        '
        Me.dgTransfer0.AllowUserToAddRows = False
        Me.dgTransfer0.AllowUserToDeleteRows = False
        Me.dgTransfer0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransfer0.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransfer0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgTransfer0.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.th_companycode, Me.Column3, Me.th_storecode_orig, Me.th_storecode_dest, Me.th_dr, Me.th_status, Me.th_datecreated, Me.th_view0})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTransfer0.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgTransfer0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTransfer0.Location = New System.Drawing.Point(0, 36)
        Me.dgTransfer0.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransfer0.Name = "dgTransfer0"
        Me.dgTransfer0.ReadOnly = True
        Me.dgTransfer0.RowHeadersVisible = False
        Me.dgTransfer0.RowHeadersWidth = 51
        Me.dgTransfer0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransfer0.Size = New System.Drawing.Size(1086, 586)
        Me.dgTransfer0.TabIndex = 5
        '
        'th_companycode
        '
        Me.th_companycode.HeaderText = "Company Code"
        Me.th_companycode.Name = "th_companycode"
        Me.th_companycode.ReadOnly = True
        Me.th_companycode.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "Status Code"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'th_storecode_orig
        '
        Me.th_storecode_orig.HeaderText = "Store Code"
        Me.th_storecode_orig.Name = "th_storecode_orig"
        Me.th_storecode_orig.ReadOnly = True
        Me.th_storecode_orig.Visible = False
        '
        'th_storecode_dest
        '
        Me.th_storecode_dest.HeaderText = "Store Destination"
        Me.th_storecode_dest.Name = "th_storecode_dest"
        Me.th_storecode_dest.ReadOnly = True
        '
        'th_dr
        '
        Me.th_dr.FillWeight = 80.0!
        Me.th_dr.HeaderText = "DR"
        Me.th_dr.Name = "th_dr"
        Me.th_dr.ReadOnly = True
        '
        'th_status
        '
        Me.th_status.FillWeight = 80.0!
        Me.th_status.HeaderText = "Status"
        Me.th_status.Name = "th_status"
        Me.th_status.ReadOnly = True
        '
        'th_datecreated
        '
        Me.th_datecreated.FillWeight = 70.0!
        Me.th_datecreated.HeaderText = "Date Created"
        Me.th_datecreated.Name = "th_datecreated"
        Me.th_datecreated.ReadOnly = True
        '
        'th_view0
        '
        Me.th_view0.FillWeight = 30.0!
        Me.th_view0.HeaderText = ""
        Me.th_view0.Image = Global.MCPlusInventorySystem.My.Resources.Resources.listview
        Me.th_view0.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.th_view0.Name = "th_view0"
        Me.th_view0.ReadOnly = True
        Me.th_view0.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.th_view0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(1086, 36)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "For Approval"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabTransfer1
        '
        Me.tabTransfer1.Controls.Add(Me.dgTransfer1)
        Me.tabTransfer1.Controls.Add(Me.Label3)
        Me.tabTransfer1.Location = New System.Drawing.Point(4, 22)
        Me.tabTransfer1.Name = "tabTransfer1"
        Me.tabTransfer1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTransfer1.Size = New System.Drawing.Size(1086, 622)
        Me.tabTransfer1.TabIndex = 8
        Me.tabTransfer1.Text = "To Pick"
        Me.tabTransfer1.UseVisualStyleBackColor = True
        '
        'dgTransfer1
        '
        Me.dgTransfer1.AllowUserToAddRows = False
        Me.dgTransfer1.AllowUserToDeleteRows = False
        Me.dgTransfer1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransfer1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransfer1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgTransfer1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn31, Me.Column4, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.th_view1})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTransfer1.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgTransfer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTransfer1.Location = New System.Drawing.Point(3, 39)
        Me.dgTransfer1.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransfer1.Name = "dgTransfer1"
        Me.dgTransfer1.ReadOnly = True
        Me.dgTransfer1.RowHeadersVisible = False
        Me.dgTransfer1.RowHeadersWidth = 51
        Me.dgTransfer1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransfer1.Size = New System.Drawing.Size(1080, 580)
        Me.dgTransfer1.TabIndex = 8
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.HeaderText = "Company Code"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        Me.DataGridViewTextBoxColumn31.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "Status Code"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.HeaderText = "Store Code"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        Me.DataGridViewTextBoxColumn32.Visible = False
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.HeaderText = "Store Destination"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn34.HeaderText = "DR"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn35.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.ReadOnly = True
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn36.HeaderText = "Date Created"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.ReadOnly = True
        '
        'th_view1
        '
        Me.th_view1.FillWeight = 30.0!
        Me.th_view1.HeaderText = ""
        Me.th_view1.Image = Global.MCPlusInventorySystem.My.Resources.Resources.listview
        Me.th_view1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.th_view1.Name = "th_view1"
        Me.th_view1.ReadOnly = True
        Me.th_view1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.th_view1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Orange
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(1080, 36)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "To Pick"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabTransfer2
        '
        Me.tabTransfer2.Controls.Add(Me.dgTransfer2)
        Me.tabTransfer2.Controls.Add(Me.Label4)
        Me.tabTransfer2.Location = New System.Drawing.Point(4, 22)
        Me.tabTransfer2.Name = "tabTransfer2"
        Me.tabTransfer2.Size = New System.Drawing.Size(1086, 622)
        Me.tabTransfer2.TabIndex = 3
        Me.tabTransfer2.Text = "Ready To Ship"
        Me.tabTransfer2.UseVisualStyleBackColor = True
        '
        'dgTransfer2
        '
        Me.dgTransfer2.AllowUserToAddRows = False
        Me.dgTransfer2.AllowUserToDeleteRows = False
        Me.dgTransfer2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransfer2.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransfer2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgTransfer2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.Column5, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.th_view2})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTransfer2.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgTransfer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTransfer2.Location = New System.Drawing.Point(0, 36)
        Me.dgTransfer2.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransfer2.Name = "dgTransfer2"
        Me.dgTransfer2.ReadOnly = True
        Me.dgTransfer2.RowHeadersVisible = False
        Me.dgTransfer2.RowHeadersWidth = 51
        Me.dgTransfer2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransfer2.Size = New System.Drawing.Size(1086, 586)
        Me.dgTransfer2.TabIndex = 7
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Company Code"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "Status Code"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Store Code"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Store Destination"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn10.HeaderText = "DR"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn11.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn12.HeaderText = "Date Created"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'th_view2
        '
        Me.th_view2.FillWeight = 30.0!
        Me.th_view2.HeaderText = ""
        Me.th_view2.Image = Global.MCPlusInventorySystem.My.Resources.Resources.listview
        Me.th_view2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.th_view2.Name = "th_view2"
        Me.th_view2.ReadOnly = True
        Me.th_view2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.th_view2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(1086, 36)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Ready To Ship"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabTransfer3
        '
        Me.tabTransfer3.Controls.Add(Me.dgTransfer3)
        Me.tabTransfer3.Controls.Add(Me.Label5)
        Me.tabTransfer3.Location = New System.Drawing.Point(4, 22)
        Me.tabTransfer3.Name = "tabTransfer3"
        Me.tabTransfer3.Size = New System.Drawing.Size(1086, 622)
        Me.tabTransfer3.TabIndex = 4
        Me.tabTransfer3.Text = "In Transit"
        Me.tabTransfer3.UseVisualStyleBackColor = True
        '
        'dgTransfer3
        '
        Me.dgTransfer3.AllowUserToAddRows = False
        Me.dgTransfer3.AllowUserToDeleteRows = False
        Me.dgTransfer3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransfer3.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransfer3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgTransfer3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13, Me.Column6, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.th_view3})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTransfer3.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgTransfer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTransfer3.Location = New System.Drawing.Point(0, 36)
        Me.dgTransfer3.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransfer3.Name = "dgTransfer3"
        Me.dgTransfer3.ReadOnly = True
        Me.dgTransfer3.RowHeadersVisible = False
        Me.dgTransfer3.RowHeadersWidth = 51
        Me.dgTransfer3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransfer3.Size = New System.Drawing.Size(1086, 586)
        Me.dgTransfer3.TabIndex = 7
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Company Code"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "Status Code"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Store Code"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Store Destination"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn16.HeaderText = "DR"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn17.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn18.HeaderText = "Date Created"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'th_view3
        '
        Me.th_view3.FillWeight = 30.0!
        Me.th_view3.HeaderText = ""
        Me.th_view3.Image = Global.MCPlusInventorySystem.My.Resources.Resources.listview
        Me.th_view3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.th_view3.Name = "th_view3"
        Me.th_view3.ReadOnly = True
        Me.th_view3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.th_view3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(1086, 36)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "In Transit"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabTransferPartialReceived
        '
        Me.tabTransferPartialReceived.Controls.Add(Me.dgTransferPartialReceived)
        Me.tabTransferPartialReceived.Controls.Add(Me.Label6)
        Me.tabTransferPartialReceived.Location = New System.Drawing.Point(4, 22)
        Me.tabTransferPartialReceived.Name = "tabTransferPartialReceived"
        Me.tabTransferPartialReceived.Size = New System.Drawing.Size(1086, 622)
        Me.tabTransferPartialReceived.TabIndex = 6
        Me.tabTransferPartialReceived.Text = "Partially Received"
        Me.tabTransferPartialReceived.UseVisualStyleBackColor = True
        '
        'dgTransferPartialReceived
        '
        Me.dgTransferPartialReceived.AllowUserToAddRows = False
        Me.dgTransferPartialReceived.AllowUserToDeleteRows = False
        Me.dgTransferPartialReceived.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransferPartialReceived.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransferPartialReceived.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgTransferPartialReceived.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn25, Me.Column7, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.th_viewParRec})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTransferPartialReceived.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgTransferPartialReceived.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTransferPartialReceived.Location = New System.Drawing.Point(0, 36)
        Me.dgTransferPartialReceived.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransferPartialReceived.Name = "dgTransferPartialReceived"
        Me.dgTransferPartialReceived.ReadOnly = True
        Me.dgTransferPartialReceived.RowHeadersVisible = False
        Me.dgTransferPartialReceived.RowHeadersWidth = 51
        Me.dgTransferPartialReceived.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransferPartialReceived.Size = New System.Drawing.Size(1086, 586)
        Me.dgTransferPartialReceived.TabIndex = 8
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.HeaderText = "Company Code"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "Status Code"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.HeaderText = "Store Code"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Visible = False
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.HeaderText = "Store Destination"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn28.HeaderText = "DR"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn29.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn30.HeaderText = "Date Created"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        '
        'th_viewParRec
        '
        Me.th_viewParRec.FillWeight = 30.0!
        Me.th_viewParRec.HeaderText = ""
        Me.th_viewParRec.Image = Global.MCPlusInventorySystem.My.Resources.Resources.listview
        Me.th_viewParRec.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.th_viewParRec.Name = "th_viewParRec"
        Me.th_viewParRec.ReadOnly = True
        Me.th_viewParRec.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.th_viewParRec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(1086, 36)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Partially Received"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabTransfer4
        '
        Me.tabTransfer4.Controls.Add(Me.dgTransfer4)
        Me.tabTransfer4.Controls.Add(Me.Label7)
        Me.tabTransfer4.Location = New System.Drawing.Point(4, 22)
        Me.tabTransfer4.Name = "tabTransfer4"
        Me.tabTransfer4.Size = New System.Drawing.Size(1086, 622)
        Me.tabTransfer4.TabIndex = 5
        Me.tabTransfer4.Text = "Received"
        Me.tabTransfer4.UseVisualStyleBackColor = True
        '
        'dgTransfer4
        '
        Me.dgTransfer4.AllowUserToAddRows = False
        Me.dgTransfer4.AllowUserToDeleteRows = False
        Me.dgTransfer4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransfer4.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransfer4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgTransfer4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn19, Me.Column8, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.th_view4})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTransfer4.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgTransfer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTransfer4.Location = New System.Drawing.Point(0, 36)
        Me.dgTransfer4.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransfer4.Name = "dgTransfer4"
        Me.dgTransfer4.ReadOnly = True
        Me.dgTransfer4.RowHeadersVisible = False
        Me.dgTransfer4.RowHeadersWidth = 51
        Me.dgTransfer4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransfer4.Size = New System.Drawing.Size(1086, 586)
        Me.dgTransfer4.TabIndex = 7
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "Company Code"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "Status Code"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "Store Code"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "Store Destination"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn22.HeaderText = "DR"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn23.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn24.HeaderText = "Date Created"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        '
        'th_view4
        '
        Me.th_view4.FillWeight = 30.0!
        Me.th_view4.HeaderText = ""
        Me.th_view4.Image = Global.MCPlusInventorySystem.My.Resources.Resources.listview
        Me.th_view4.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.th_view4.Name = "th_view4"
        Me.th_view4.ReadOnly = True
        Me.th_view4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.th_view4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.ForestGreen
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.Size = New System.Drawing.Size(1086, 36)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Received (Complete)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabTransfer9
        '
        Me.tabTransfer9.Controls.Add(Me.dgTransfer9)
        Me.tabTransfer9.Controls.Add(Me.Label9)
        Me.tabTransfer9.Location = New System.Drawing.Point(4, 22)
        Me.tabTransfer9.Name = "tabTransfer9"
        Me.tabTransfer9.Size = New System.Drawing.Size(1086, 622)
        Me.tabTransfer9.TabIndex = 9
        Me.tabTransfer9.Text = "Cancelled"
        Me.tabTransfer9.UseVisualStyleBackColor = True
        '
        'dgTransfer9
        '
        Me.dgTransfer9.AllowUserToAddRows = False
        Me.dgTransfer9.AllowUserToDeleteRows = False
        Me.dgTransfer9.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransfer9.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransfer9.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgTransfer9.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn37, Me.Column9, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39, Me.DataGridViewTextBoxColumn40, Me.DataGridViewTextBoxColumn41, Me.DataGridViewTextBoxColumn42, Me.th_view9})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTransfer9.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgTransfer9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTransfer9.Location = New System.Drawing.Point(0, 36)
        Me.dgTransfer9.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransfer9.Name = "dgTransfer9"
        Me.dgTransfer9.ReadOnly = True
        Me.dgTransfer9.RowHeadersVisible = False
        Me.dgTransfer9.RowHeadersWidth = 51
        Me.dgTransfer9.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransfer9.Size = New System.Drawing.Size(1086, 586)
        Me.dgTransfer9.TabIndex = 9
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.HeaderText = "Company Code"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.ReadOnly = True
        Me.DataGridViewTextBoxColumn37.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "Status Code"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.HeaderText = "Store Code"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.ReadOnly = True
        Me.DataGridViewTextBoxColumn38.Visible = False
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.HeaderText = "Store Destination"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.ReadOnly = True
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn40.HeaderText = "DR"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        Me.DataGridViewTextBoxColumn40.ReadOnly = True
        '
        'DataGridViewTextBoxColumn41
        '
        Me.DataGridViewTextBoxColumn41.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn41.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
        Me.DataGridViewTextBoxColumn41.ReadOnly = True
        '
        'DataGridViewTextBoxColumn42
        '
        Me.DataGridViewTextBoxColumn42.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn42.HeaderText = "Date Created"
        Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
        Me.DataGridViewTextBoxColumn42.ReadOnly = True
        '
        'th_view9
        '
        Me.th_view9.FillWeight = 30.0!
        Me.th_view9.HeaderText = ""
        Me.th_view9.Image = Global.MCPlusInventorySystem.My.Resources.Resources.listview
        Me.th_view9.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.th_view9.Name = "th_view9"
        Me.th_view9.ReadOnly = True
        Me.th_view9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.th_view9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Crimson
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label9.Size = New System.Drawing.Size(1086, 36)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Cancelled"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.FillWeight = 20.0!
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.MCPlusInventorySystem.My.Resources.Resources.remove
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 35
        '
        'cbAllStatusStore
        '
        Me.cbAllStatusStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAllStatusStore.FormattingEnabled = True
        Me.cbAllStatusStore.Location = New System.Drawing.Point(113, 47)
        Me.cbAllStatusStore.Name = "cbAllStatusStore"
        Me.cbAllStatusStore.Size = New System.Drawing.Size(219, 21)
        Me.cbAllStatusStore.TabIndex = 46
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 82)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Find DR / Order ID:"
        '
        'txtAllStatusFind
        '
        Me.txtAllStatusFind.Location = New System.Drawing.Point(113, 75)
        Me.txtAllStatusFind.Name = "txtAllStatusFind"
        Me.txtAllStatusFind.Size = New System.Drawing.Size(278, 20)
        Me.txtAllStatusFind.TabIndex = 44
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 13)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Select Store :"
        '
        'DataGridViewTextBoxColumn43
        '
        Me.DataGridViewTextBoxColumn43.HeaderText = "Company Code"
        Me.DataGridViewTextBoxColumn43.Name = "DataGridViewTextBoxColumn43"
        Me.DataGridViewTextBoxColumn43.ReadOnly = True
        Me.DataGridViewTextBoxColumn43.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Status Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'DataGridViewTextBoxColumn44
        '
        Me.DataGridViewTextBoxColumn44.HeaderText = "Store Code"
        Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
        Me.DataGridViewTextBoxColumn44.ReadOnly = True
        Me.DataGridViewTextBoxColumn44.Visible = False
        '
        'th_storedestAll
        '
        Me.th_storedestAll.HeaderText = "Store Destination"
        Me.th_storedestAll.Name = "th_storedestAll"
        Me.th_storedestAll.ReadOnly = True
        '
        'th_drAll
        '
        Me.th_drAll.FillWeight = 80.0!
        Me.th_drAll.HeaderText = "DR"
        Me.th_drAll.Name = "th_drAll"
        Me.th_drAll.ReadOnly = True
        '
        'th_orderIDAll
        '
        Me.th_orderIDAll.HeaderText = "Order ID"
        Me.th_orderIDAll.Name = "th_orderIDAll"
        Me.th_orderIDAll.ReadOnly = True
        '
        'DataGridViewTextBoxColumn47
        '
        Me.DataGridViewTextBoxColumn47.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn47.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn47.Name = "DataGridViewTextBoxColumn47"
        Me.DataGridViewTextBoxColumn47.ReadOnly = True
        '
        'DataGridViewTextBoxColumn48
        '
        Me.DataGridViewTextBoxColumn48.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn48.HeaderText = "Date Created"
        Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
        Me.DataGridViewTextBoxColumn48.ReadOnly = True
        '
        'th_viewAll
        '
        Me.th_viewAll.FillWeight = 30.0!
        Me.th_viewAll.HeaderText = ""
        Me.th_viewAll.Image = Global.MCPlusInventorySystem.My.Resources.Resources.listview
        Me.th_viewAll.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.th_viewAll.Name = "th_viewAll"
        Me.th_viewAll.ReadOnly = True
        Me.th_viewAll.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.th_viewAll.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'lblTTStoreCodeDestAll
        '
        Me.lblTTStoreCodeDestAll.AutoSize = True
        Me.lblTTStoreCodeDestAll.Location = New System.Drawing.Point(338, 52)
        Me.lblTTStoreCodeDestAll.Name = "lblTTStoreCodeDestAll"
        Me.lblTTStoreCodeDestAll.Size = New System.Drawing.Size(16, 13)
        Me.lblTTStoreCodeDestAll.TabIndex = 47
        Me.lblTTStoreCodeDestAll.Text = "---"
        '
        'frmStockOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 656)
        Me.Controls.Add(Me.tcStockOut)
        Me.MinimizeBox = False
        Me.Name = "frmStockOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock-OUT Movement"
        Me.tcStockOut.ResumeLayout(False)
        Me.tabTransferItem.ResumeLayout(False)
        Me.tabTransferItem.PerformLayout()
        CType(Me.btnTTShowItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTransferAll.ResumeLayout(False)
        CType(Me.dgTransferAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabTransfer10.ResumeLayout(False)
        CType(Me.dgTransfer10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTransfer0.ResumeLayout(False)
        CType(Me.dgTransfer0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTransfer1.ResumeLayout(False)
        CType(Me.dgTransfer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTransfer2.ResumeLayout(False)
        CType(Me.dgTransfer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTransfer3.ResumeLayout(False)
        CType(Me.dgTransfer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTransferPartialReceived.ResumeLayout(False)
        CType(Me.dgTransferPartialReceived, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTransfer4.ResumeLayout(False)
        CType(Me.dgTransfer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTransfer9.ResumeLayout(False)
        CType(Me.dgTransfer9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tcStockOut As TabControl
    Friend WithEvents tabTransferItem As TabPage
    Friend WithEvents btnTTShowItems As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dgTransfer As DataGridView
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents lblTTStoreCodeDest As Label
    Friend WithEvents cbTTStoreDest As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTTRemarks As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtTTDR As TextBox
    Friend WithEvents btnTTTransfer As Button
    Friend WithEvents tabTransfer0 As TabPage
    Friend WithEvents tabTransfer2 As TabPage
    Friend WithEvents tabTransfer3 As TabPage
    Friend WithEvents tabTransfer4 As TabPage
    Friend WithEvents dgTransfer0 As DataGridView
    Friend WithEvents dgTransfer2 As DataGridView
    Friend WithEvents dgTransfer3 As DataGridView
    Friend WithEvents dgTransfer4 As DataGridView
    Friend WithEvents tabTransferPartialReceived As TabPage
    Friend WithEvents dgTransferPartialReceived As DataGridView
    Friend WithEvents tabTransfer10 As TabPage
    Friend WithEvents dgTransfer10 As DataGridView
    Friend WithEvents tabTransfer1 As TabPage
    Friend WithEvents dgTransfer1 As DataGridView
    Friend WithEvents tabTransfer9 As TabPage
    Friend WithEvents dgTransfer9 As DataGridView
    Friend WithEvents transfer_skucode As DataGridViewTextBoxColumn
    Friend WithEvents transfer_desc As DataGridViewTextBoxColumn
    Friend WithEvents transfer_color As DataGridViewTextBoxColumn
    Friend WithEvents transfer_variant As DataGridViewTextBoxColumn
    Friend WithEvents transfer_loc_code As DataGridViewTextBoxColumn
    Friend WithEvents transfer_stock As DataGridViewTextBoxColumn
    Friend WithEvents transfer_qty As DataGridViewTextBoxColumn
    Friend WithEvents transfer_total_amount As DataGridViewTextBoxColumn
    Friend WithEvents transfer_remove As DataGridViewImageColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents tabTransferAll As TabPage
    Friend WithEvents dgTransferAll As DataGridView
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents txtTTOrderID As TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents th_view10 As DataGridViewImageColumn
    Friend WithEvents th_companycode As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents th_storecode_orig As DataGridViewTextBoxColumn
    Friend WithEvents th_storecode_dest As DataGridViewTextBoxColumn
    Friend WithEvents th_dr As DataGridViewTextBoxColumn
    Friend WithEvents th_status As DataGridViewTextBoxColumn
    Friend WithEvents th_datecreated As DataGridViewTextBoxColumn
    Friend WithEvents th_view0 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn
    Friend WithEvents th_view1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents th_view2 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents th_view3 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn
    Friend WithEvents th_viewParRec As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
    Friend WithEvents th_view4 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn41 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn42 As DataGridViewTextBoxColumn
    Friend WithEvents th_view9 As DataGridViewImageColumn
    Friend WithEvents cbAllStatusStore As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtAllStatusFind As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents DataGridViewTextBoxColumn43 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn44 As DataGridViewTextBoxColumn
    Friend WithEvents th_storedestAll As DataGridViewTextBoxColumn
    Friend WithEvents th_drAll As DataGridViewTextBoxColumn
    Friend WithEvents th_orderIDAll As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn47 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn
    Friend WithEvents th_viewAll As DataGridViewImageColumn
    Friend WithEvents lblTTStoreCodeDestAll As Label
End Class

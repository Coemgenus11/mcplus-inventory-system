<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPurchaseOrderItems
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnReceivedPO = New System.Windows.Forms.Button()
        Me.lblStatusDesc = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCreatedAt = New System.Windows.Forms.Label()
        Me.txtSupp = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblSuppCode = New System.Windows.Forms.Label()
        Me.txtPONum = New System.Windows.Forms.TextBox()
        Me.dgPOItemList = New System.Windows.Forms.DataGridView()
        Me.polist_rowcount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polist_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polist_itemdesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polist_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polist_var = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polist_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polist_unitcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polist_actualreceivedqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polist_actualunitcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polist_qtydelivered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.polist_remove = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtaRemarks = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.datePODelivery = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnShowHistoryDR = New System.Windows.Forms.Label()
        Me.panelReceiptDR = New System.Windows.Forms.Panel()
        Me.btnPORPrint = New System.Windows.Forms.Button()
        Me.dgPODRItems = New System.Windows.Forms.DataGridView()
        Me.comp_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.receiving_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_link = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.po_num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_cat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_variant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.podri_qtydelivered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.no_print = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.printed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.skuprinted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_selectprint = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnSelectPODR = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.bthBackToReceiving = New System.Windows.Forms.Button()
        Me.dgPODR = New System.Windows.Forms.DataGridView()
        Me.podr_receivingid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.podr_deliverydate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.podr_reference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelShowHistoryDR = New System.Windows.Forms.Panel()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.panelReceiving = New System.Windows.Forms.Panel()
        CType(Me.dgPOItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelReceiptDR.SuspendLayout()
        CType(Me.dgPODRItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPODR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelShowHistoryDR.SuspendLayout()
        Me.panelReceiving.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnReceivedPO
        '
        Me.btnReceivedPO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReceivedPO.BackColor = System.Drawing.Color.ForestGreen
        Me.btnReceivedPO.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen
        Me.btnReceivedPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReceivedPO.Font = New System.Drawing.Font("Arial Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceivedPO.ForeColor = System.Drawing.Color.Snow
        Me.btnReceivedPO.Location = New System.Drawing.Point(1363, 707)
        Me.btnReceivedPO.Name = "btnReceivedPO"
        Me.btnReceivedPO.Size = New System.Drawing.Size(117, 35)
        Me.btnReceivedPO.TabIndex = 52
        Me.btnReceivedPO.Text = "RECEIVED PO"
        Me.btnReceivedPO.UseVisualStyleBackColor = False
        Me.btnReceivedPO.Visible = False
        '
        'lblStatusDesc
        '
        Me.lblStatusDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatusDesc.AutoSize = True
        Me.lblStatusDesc.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusDesc.ForeColor = System.Drawing.Color.DimGray
        Me.lblStatusDesc.Location = New System.Drawing.Point(65, 177)
        Me.lblStatusDesc.Name = "lblStatusDesc"
        Me.lblStatusDesc.Size = New System.Drawing.Size(49, 15)
        Me.lblStatusDesc.TabIndex = 49
        Me.lblStatusDesc.Text = "Status"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label2.Location = New System.Drawing.Point(21, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Status :"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(1183, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "PO Created At:"
        '
        'lblCreatedAt
        '
        Me.lblCreatedAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCreatedAt.AutoSize = True
        Me.lblCreatedAt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedAt.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblCreatedAt.Location = New System.Drawing.Point(1267, 4)
        Me.lblCreatedAt.Name = "lblCreatedAt"
        Me.lblCreatedAt.Size = New System.Drawing.Size(70, 13)
        Me.lblCreatedAt.TabIndex = 46
        Me.lblCreatedAt.Text = "Created Date"
        '
        'txtSupp
        '
        Me.txtSupp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupp.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupp.Location = New System.Drawing.Point(144, 58)
        Me.txtSupp.Name = "txtSupp"
        Me.txtSupp.ReadOnly = True
        Me.txtSupp.Size = New System.Drawing.Size(221, 26)
        Me.txtSupp.TabIndex = 45
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(617, 62)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(59, 17)
        Me.Label23.TabIndex = 44
        Me.Label23.Text = "PO No."
        '
        'lblSuppCode
        '
        Me.lblSuppCode.AutoSize = True
        Me.lblSuppCode.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblSuppCode.Location = New System.Drawing.Point(371, 63)
        Me.lblSuppCode.Name = "lblSuppCode"
        Me.lblSuppCode.Size = New System.Drawing.Size(70, 13)
        Me.lblSuppCode.TabIndex = 43
        Me.lblSuppCode.Text = "supplier code"
        '
        'txtPONum
        '
        Me.txtPONum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPONum.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPONum.Location = New System.Drawing.Point(682, 58)
        Me.txtPONum.Name = "txtPONum"
        Me.txtPONum.ReadOnly = True
        Me.txtPONum.Size = New System.Drawing.Size(171, 26)
        Me.txtPONum.TabIndex = 42
        '
        'dgPOItemList
        '
        Me.dgPOItemList.AllowUserToAddRows = False
        Me.dgPOItemList.AllowUserToDeleteRows = False
        Me.dgPOItemList.AllowUserToResizeColumns = False
        Me.dgPOItemList.AllowUserToResizeRows = False
        Me.dgPOItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPOItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgPOItemList.BackgroundColor = System.Drawing.Color.Linen
        Me.dgPOItemList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgPOItemList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgPOItemList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.ButtonShadow
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPOItemList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgPOItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPOItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.polist_rowcount, Me.polist_sku, Me.polist_itemdesc, Me.polist_color, Me.polist_var, Me.polist_qty, Me.polist_unitcost, Me.polist_actualreceivedqty, Me.polist_actualunitcost, Me.polist_qtydelivered, Me.polist_remove})
        Me.dgPOItemList.Location = New System.Drawing.Point(9, 195)
        Me.dgPOItemList.Name = "dgPOItemList"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPOItemList.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgPOItemList.RowHeadersVisible = False
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.Padding = New System.Windows.Forms.Padding(3)
        Me.dgPOItemList.RowsDefaultCellStyle = DataGridViewCellStyle22
        Me.dgPOItemList.RowTemplate.Height = 40
        Me.dgPOItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPOItemList.Size = New System.Drawing.Size(1472, 502)
        Me.dgPOItemList.TabIndex = 39
        '
        'polist_rowcount
        '
        Me.polist_rowcount.FillWeight = 15.0!
        Me.polist_rowcount.HeaderText = ""
        Me.polist_rowcount.Name = "polist_rowcount"
        Me.polist_rowcount.ReadOnly = True
        '
        'polist_sku
        '
        Me.polist_sku.FillWeight = 60.0!
        Me.polist_sku.HeaderText = "SKU"
        Me.polist_sku.Name = "polist_sku"
        Me.polist_sku.ReadOnly = True
        '
        'polist_itemdesc
        '
        Me.polist_itemdesc.HeaderText = "ITEM DESCRIPTION"
        Me.polist_itemdesc.Name = "polist_itemdesc"
        Me.polist_itemdesc.ReadOnly = True
        '
        'polist_color
        '
        Me.polist_color.FillWeight = 60.0!
        Me.polist_color.HeaderText = "COLOR"
        Me.polist_color.Name = "polist_color"
        Me.polist_color.ReadOnly = True
        '
        'polist_var
        '
        Me.polist_var.HeaderText = "VARIATION"
        Me.polist_var.Name = "polist_var"
        Me.polist_var.ReadOnly = True
        '
        'polist_qty
        '
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        Me.polist_qty.DefaultCellStyle = DataGridViewCellStyle16
        Me.polist_qty.FillWeight = 40.0!
        Me.polist_qty.HeaderText = "QTY"
        Me.polist_qty.Name = "polist_qty"
        Me.polist_qty.ReadOnly = True
        '
        'polist_unitcost
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        Me.polist_unitcost.DefaultCellStyle = DataGridViewCellStyle17
        Me.polist_unitcost.FillWeight = 50.0!
        Me.polist_unitcost.HeaderText = "UNIT COST"
        Me.polist_unitcost.Name = "polist_unitcost"
        Me.polist_unitcost.ReadOnly = True
        '
        'polist_actualreceivedqty
        '
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.polist_actualreceivedqty.DefaultCellStyle = DataGridViewCellStyle18
        Me.polist_actualreceivedqty.FillWeight = 40.0!
        Me.polist_actualreceivedqty.HeaderText = "QTY RECEIVED"
        Me.polist_actualreceivedqty.Name = "polist_actualreceivedqty"
        '
        'polist_actualunitcost
        '
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.polist_actualunitcost.DefaultCellStyle = DataGridViewCellStyle19
        Me.polist_actualunitcost.FillWeight = 50.0!
        Me.polist_actualunitcost.HeaderText = "ACTUAL UNIT COST"
        Me.polist_actualunitcost.Name = "polist_actualunitcost"
        '
        'polist_qtydelivered
        '
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.polist_qtydelivered.DefaultCellStyle = DataGridViewCellStyle20
        Me.polist_qtydelivered.FillWeight = 50.0!
        Me.polist_qtydelivered.HeaderText = "QTY DELIVERED NOW"
        Me.polist_qtydelivered.Name = "polist_qtydelivered"
        '
        'polist_remove
        '
        Me.polist_remove.FillWeight = 30.0!
        Me.polist_remove.HeaderText = ""
        Me.polist_remove.Name = "polist_remove"
        Me.polist_remove.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.polist_remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.polist_remove.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label3.Location = New System.Drawing.Point(13, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 24)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Purchase Order"
        '
        'txtaRemarks
        '
        Me.txtaRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtaRemarks.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaRemarks.Location = New System.Drawing.Point(127, 46)
        Me.txtaRemarks.Multiline = True
        Me.txtaRemarks.Name = "txtaRemarks"
        Me.txtaRemarks.Size = New System.Drawing.Size(671, 36)
        Me.txtaRemarks.TabIndex = 53
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(60, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Supplier :"
        '
        'datePODelivery
        '
        Me.datePODelivery.Checked = False
        Me.datePODelivery.CustomFormat = " "
        Me.datePODelivery.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.datePODelivery.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datePODelivery.Location = New System.Drawing.Point(127, 4)
        Me.datePODelivery.Name = "datePODelivery"
        Me.datePODelivery.Size = New System.Drawing.Size(221, 26)
        Me.datePODelivery.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 15)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Delivery Date :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(38, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Remarks :"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(7, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(223, 15)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "To view receiving history of this PO, click"
        '
        'btnShowHistoryDR
        '
        Me.btnShowHistoryDR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowHistoryDR.AutoSize = True
        Me.btnShowHistoryDR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowHistoryDR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowHistoryDR.ForeColor = System.Drawing.Color.Green
        Me.btnShowHistoryDR.Location = New System.Drawing.Point(226, 4)
        Me.btnShowHistoryDR.Name = "btnShowHistoryDR"
        Me.btnShowHistoryDR.Size = New System.Drawing.Size(35, 15)
        Me.btnShowHistoryDR.TabIndex = 63
        Me.btnShowHistoryDR.Text = "here."
        '
        'panelReceiptDR
        '
        Me.panelReceiptDR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelReceiptDR.Controls.Add(Me.btnPORPrint)
        Me.panelReceiptDR.Controls.Add(Me.dgPODRItems)
        Me.panelReceiptDR.Controls.Add(Me.btnSelectPODR)
        Me.panelReceiptDR.Controls.Add(Me.Label9)
        Me.panelReceiptDR.Controls.Add(Me.bthBackToReceiving)
        Me.panelReceiptDR.Controls.Add(Me.dgPODR)
        Me.panelReceiptDR.Location = New System.Drawing.Point(5, 90)
        Me.panelReceiptDR.Name = "panelReceiptDR"
        Me.panelReceiptDR.Size = New System.Drawing.Size(1482, 656)
        Me.panelReceiptDR.TabIndex = 64
        Me.panelReceiptDR.Visible = False
        '
        'btnPORPrint
        '
        Me.btnPORPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPORPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPORPrint.Enabled = False
        Me.btnPORPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPORPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPORPrint.Location = New System.Drawing.Point(1384, 18)
        Me.btnPORPrint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPORPrint.Name = "btnPORPrint"
        Me.btnPORPrint.Size = New System.Drawing.Size(82, 42)
        Me.btnPORPrint.TabIndex = 74
        Me.btnPORPrint.Text = "PRINT QR"
        Me.btnPORPrint.UseVisualStyleBackColor = True
        '
        'dgPODRItems
        '
        Me.dgPODRItems.AllowUserToAddRows = False
        Me.dgPODRItems.AllowUserToDeleteRows = False
        Me.dgPODRItems.AllowUserToResizeColumns = False
        Me.dgPODRItems.AllowUserToResizeRows = False
        Me.dgPODRItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPODRItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgPODRItems.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgPODRItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgPODRItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgPODRItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.ButtonShadow
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPODRItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgPODRItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPODRItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.comp_code, Me.receiving_id, Me.sku_link, Me.po_num, Me.sku_code, Me.sku_gender, Me.sku_col, Me.sku_type, Me.sku_cat, Me.sku_color, Me.sku_variant, Me.podri_qtydelivered, Me.no_print, Me.printed, Me.skuprinted, Me.sku_selectprint})
        Me.dgPODRItems.Location = New System.Drawing.Point(12, 69)
        Me.dgPODRItems.Name = "dgPODRItems"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPODRItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgPODRItems.RowHeadersVisible = False
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.Padding = New System.Windows.Forms.Padding(3)
        Me.dgPODRItems.RowsDefaultCellStyle = DataGridViewCellStyle26
        Me.dgPODRItems.RowTemplate.Height = 40
        Me.dgPODRItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPODRItems.Size = New System.Drawing.Size(1454, 538)
        Me.dgPODRItems.TabIndex = 73
        '
        'comp_code
        '
        Me.comp_code.HeaderText = "Company Code"
        Me.comp_code.Name = "comp_code"
        Me.comp_code.ReadOnly = True
        Me.comp_code.Visible = False
        '
        'receiving_id
        '
        Me.receiving_id.HeaderText = "Receiving ID"
        Me.receiving_id.Name = "receiving_id"
        Me.receiving_id.ReadOnly = True
        Me.receiving_id.Visible = False
        '
        'sku_link
        '
        Me.sku_link.HeaderText = "SKU Link"
        Me.sku_link.Name = "sku_link"
        Me.sku_link.ReadOnly = True
        Me.sku_link.Visible = False
        '
        'po_num
        '
        Me.po_num.HeaderText = "PO No."
        Me.po_num.Name = "po_num"
        Me.po_num.ReadOnly = True
        Me.po_num.Visible = False
        '
        'sku_code
        '
        Me.sku_code.FillWeight = 50.0!
        Me.sku_code.HeaderText = "SKU"
        Me.sku_code.Name = "sku_code"
        Me.sku_code.ReadOnly = True
        '
        'sku_gender
        '
        Me.sku_gender.FillWeight = 50.0!
        Me.sku_gender.HeaderText = "GENDER"
        Me.sku_gender.Name = "sku_gender"
        Me.sku_gender.ReadOnly = True
        '
        'sku_col
        '
        Me.sku_col.FillWeight = 80.0!
        Me.sku_col.HeaderText = "COLLECTION"
        Me.sku_col.Name = "sku_col"
        Me.sku_col.ReadOnly = True
        '
        'sku_type
        '
        Me.sku_type.HeaderText = "TYPE"
        Me.sku_type.Name = "sku_type"
        Me.sku_type.ReadOnly = True
        '
        'sku_cat
        '
        Me.sku_cat.HeaderText = "CATEGORY"
        Me.sku_cat.Name = "sku_cat"
        Me.sku_cat.ReadOnly = True
        '
        'sku_color
        '
        Me.sku_color.HeaderText = "COLOR"
        Me.sku_color.Name = "sku_color"
        Me.sku_color.ReadOnly = True
        '
        'sku_variant
        '
        Me.sku_variant.FillWeight = 50.0!
        Me.sku_variant.HeaderText = "VARIATION"
        Me.sku_variant.Name = "sku_variant"
        Me.sku_variant.ReadOnly = True
        '
        'podri_qtydelivered
        '
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.podri_qtydelivered.DefaultCellStyle = DataGridViewCellStyle24
        Me.podri_qtydelivered.FillWeight = 40.0!
        Me.podri_qtydelivered.HeaderText = "QTY DELIVERED"
        Me.podri_qtydelivered.Name = "podri_qtydelivered"
        Me.podri_qtydelivered.ReadOnly = True
        '
        'no_print
        '
        Me.no_print.FillWeight = 20.0!
        Me.no_print.HeaderText = "No. of print"
        Me.no_print.Name = "no_print"
        '
        'printed
        '
        Me.printed.FillWeight = 20.0!
        Me.printed.HeaderText = "Printed"
        Me.printed.Name = "printed"
        Me.printed.ReadOnly = True
        '
        'skuprinted
        '
        Me.skuprinted.FillWeight = 20.0!
        Me.skuprinted.HeaderText = "SKU Printed"
        Me.skuprinted.Name = "skuprinted"
        Me.skuprinted.ReadOnly = True
        Me.skuprinted.Visible = False
        '
        'sku_selectprint
        '
        Me.sku_selectprint.FillWeight = 20.0!
        Me.sku_selectprint.HeaderText = "Select print"
        Me.sku_selectprint.Name = "sku_selectprint"
        '
        'btnSelectPODR
        '
        Me.btnSelectPODR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectPODR.Location = New System.Drawing.Point(190, 23)
        Me.btnSelectPODR.Name = "btnSelectPODR"
        Me.btnSelectPODR.Size = New System.Drawing.Size(246, 29)
        Me.btnSelectPODR.TabIndex = 60
        Me.btnSelectPODR.Text = "- select -"
        Me.btnSelectPODR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSelectPODR.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(18, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(166, 15)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Select Delivery Receipt :"
        '
        'bthBackToReceiving
        '
        Me.bthBackToReceiving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bthBackToReceiving.Location = New System.Drawing.Point(3, 618)
        Me.bthBackToReceiving.Name = "bthBackToReceiving"
        Me.bthBackToReceiving.Size = New System.Drawing.Size(130, 33)
        Me.bthBackToReceiving.TabIndex = 0
        Me.bthBackToReceiving.Text = "<< Back to Receiving"
        Me.bthBackToReceiving.UseVisualStyleBackColor = True
        '
        'dgPODR
        '
        Me.dgPODR.AllowUserToAddRows = False
        Me.dgPODR.AllowUserToDeleteRows = False
        Me.dgPODR.AllowUserToResizeColumns = False
        Me.dgPODR.AllowUserToResizeRows = False
        Me.dgPODR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgPODR.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgPODR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPODR.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgPODR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPODR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.podr_receivingid, Me.podr_deliverydate, Me.podr_reference})
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPODR.DefaultCellStyle = DataGridViewCellStyle28
        Me.dgPODR.GridColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgPODR.Location = New System.Drawing.Point(190, 51)
        Me.dgPODR.Margin = New System.Windows.Forms.Padding(2)
        Me.dgPODR.Name = "dgPODR"
        Me.dgPODR.ReadOnly = True
        Me.dgPODR.RowHeadersVisible = False
        Me.dgPODR.RowHeadersWidth = 51
        Me.dgPODR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPODR.Size = New System.Drawing.Size(287, 144)
        Me.dgPODR.TabIndex = 72
        Me.dgPODR.Visible = False
        '
        'podr_receivingid
        '
        Me.podr_receivingid.FillWeight = 57.44501!
        Me.podr_receivingid.HeaderText = "Receiving ID"
        Me.podr_receivingid.Name = "podr_receivingid"
        Me.podr_receivingid.ReadOnly = True
        Me.podr_receivingid.Visible = False
        '
        'podr_deliverydate
        '
        Me.podr_deliverydate.HeaderText = "Delivery Date"
        Me.podr_deliverydate.Name = "podr_deliverydate"
        Me.podr_deliverydate.ReadOnly = True
        '
        'podr_reference
        '
        Me.podr_reference.HeaderText = "Reference"
        Me.podr_reference.Name = "podr_reference"
        Me.podr_reference.ReadOnly = True
        '
        'panelShowHistoryDR
        '
        Me.panelShowHistoryDR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.panelShowHistoryDR.Controls.Add(Me.Label7)
        Me.panelShowHistoryDR.Controls.Add(Me.btnShowHistoryDR)
        Me.panelShowHistoryDR.Location = New System.Drawing.Point(3, 718)
        Me.panelShowHistoryDR.Name = "panelShowHistoryDR"
        Me.panelShowHistoryDR.Size = New System.Drawing.Size(266, 24)
        Me.panelShowHistoryDR.TabIndex = 65
        Me.panelShowHistoryDR.Visible = False
        '
        'txtRefNo
        '
        Me.txtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRefNo.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNo.Location = New System.Drawing.Point(624, 4)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(174, 26)
        Me.txtRefNo.TabIndex = 60
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(367, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(253, 16)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "Supplier Doc. Reference No. (e.g. DR, Order Slip) :"
        '
        'panelReceiving
        '
        Me.panelReceiving.Controls.Add(Me.txtaRemarks)
        Me.panelReceiving.Controls.Add(Me.datePODelivery)
        Me.panelReceiving.Controls.Add(Me.Label8)
        Me.panelReceiving.Controls.Add(Me.Label6)
        Me.panelReceiving.Controls.Add(Me.txtRefNo)
        Me.panelReceiving.Controls.Add(Me.Label5)
        Me.panelReceiving.Location = New System.Drawing.Point(134, 104)
        Me.panelReceiving.Name = "panelReceiving"
        Me.panelReceiving.Size = New System.Drawing.Size(804, 85)
        Me.panelReceiving.TabIndex = 66
        '
        'frmPurchaseOrderItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1491, 746)
        Me.Controls.Add(Me.panelShowHistoryDR)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnReceivedPO)
        Me.Controls.Add(Me.lblStatusDesc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCreatedAt)
        Me.Controls.Add(Me.txtSupp)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lblSuppCode)
        Me.Controls.Add(Me.txtPONum)
        Me.Controls.Add(Me.dgPOItemList)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.panelReceiving)
        Me.Controls.Add(Me.panelReceiptDR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPurchaseOrderItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Order"
        CType(Me.dgPOItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelReceiptDR.ResumeLayout(False)
        Me.panelReceiptDR.PerformLayout()
        CType(Me.dgPODRItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPODR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelShowHistoryDR.ResumeLayout(False)
        Me.panelShowHistoryDR.PerformLayout()
        Me.panelReceiving.ResumeLayout(False)
        Me.panelReceiving.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnReceivedPO As Button
    Friend WithEvents lblStatusDesc As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCreatedAt As Label
    Friend WithEvents txtSupp As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents lblSuppCode As Label
    Friend WithEvents txtPONum As TextBox
    Friend WithEvents dgPOItemList As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents txtaRemarks As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents datePODelivery As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnShowHistoryDR As Label
    Friend WithEvents panelReceiptDR As Panel
    Friend WithEvents panelShowHistoryDR As Panel
    Friend WithEvents bthBackToReceiving As Button
    Friend WithEvents txtRefNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents panelReceiving As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents btnSelectPODR As Button
    Friend WithEvents dgPODR As DataGridView
    Friend WithEvents podr_receivingid As DataGridViewTextBoxColumn
    Friend WithEvents podr_deliverydate As DataGridViewTextBoxColumn
    Friend WithEvents podr_reference As DataGridViewTextBoxColumn
    Friend WithEvents dgPODRItems As DataGridView
    Friend WithEvents btnPORPrint As Button
    Friend WithEvents polist_rowcount As DataGridViewTextBoxColumn
    Friend WithEvents polist_sku As DataGridViewTextBoxColumn
    Friend WithEvents polist_itemdesc As DataGridViewTextBoxColumn
    Friend WithEvents polist_color As DataGridViewTextBoxColumn
    Friend WithEvents polist_var As DataGridViewTextBoxColumn
    Friend WithEvents polist_qty As DataGridViewTextBoxColumn
    Friend WithEvents polist_unitcost As DataGridViewTextBoxColumn
    Friend WithEvents polist_actualreceivedqty As DataGridViewTextBoxColumn
    Friend WithEvents polist_actualunitcost As DataGridViewTextBoxColumn
    Friend WithEvents polist_qtydelivered As DataGridViewTextBoxColumn
    Friend WithEvents polist_remove As DataGridViewImageColumn
    Friend WithEvents comp_code As DataGridViewTextBoxColumn
    Friend WithEvents receiving_id As DataGridViewTextBoxColumn
    Friend WithEvents sku_link As DataGridViewTextBoxColumn
    Friend WithEvents po_num As DataGridViewTextBoxColumn
    Friend WithEvents sku_code As DataGridViewTextBoxColumn
    Friend WithEvents sku_gender As DataGridViewTextBoxColumn
    Friend WithEvents sku_col As DataGridViewTextBoxColumn
    Friend WithEvents sku_type As DataGridViewTextBoxColumn
    Friend WithEvents sku_cat As DataGridViewTextBoxColumn
    Friend WithEvents sku_color As DataGridViewTextBoxColumn
    Friend WithEvents sku_variant As DataGridViewTextBoxColumn
    Friend WithEvents podri_qtydelivered As DataGridViewTextBoxColumn
    Friend WithEvents no_print As DataGridViewTextBoxColumn
    Friend WithEvents printed As DataGridViewTextBoxColumn
    Friend WithEvents skuprinted As DataGridViewTextBoxColumn
    Friend WithEvents sku_selectprint As DataGridViewCheckBoxColumn
End Class

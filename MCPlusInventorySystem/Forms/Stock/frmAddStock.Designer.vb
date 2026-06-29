<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddStock
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
        Me.lblSupCode = New System.Windows.Forms.Label()
        Me.cbMPSup = New System.Windows.Forms.ComboBox()
        Me.btnOSSubmit = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dateMPDRDate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dateMPDelivery = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMPRemarks = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMPRefNo = New System.Windows.Forms.TextBox()
        Me.dgOS = New System.Windows.Forms.DataGridView()
        Me.btnORShowItems = New System.Windows.Forms.PictureBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.stock_skucode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock_variant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock_unitcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock_remove = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.dgOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnORShowItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSupCode
        '
        Me.lblSupCode.AutoSize = True
        Me.lblSupCode.Location = New System.Drawing.Point(431, 35)
        Me.lblSupCode.Name = "lblSupCode"
        Me.lblSupCode.Size = New System.Drawing.Size(16, 13)
        Me.lblSupCode.TabIndex = 20
        Me.lblSupCode.Text = "---"
        '
        'cbMPSup
        '
        Me.cbMPSup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMPSup.FormattingEnabled = True
        Me.cbMPSup.Location = New System.Drawing.Point(156, 29)
        Me.cbMPSup.Name = "cbMPSup"
        Me.cbMPSup.Size = New System.Drawing.Size(219, 21)
        Me.cbMPSup.TabIndex = 19
        '
        'btnOSSubmit
        '
        Me.btnOSSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOSSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnOSSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOSSubmit.Location = New System.Drawing.Point(992, 537)
        Me.btnOSSubmit.Name = "btnOSSubmit"
        Me.btnOSSubmit.Size = New System.Drawing.Size(104, 39)
        Me.btnOSSubmit.TabIndex = 18
        Me.btnOSSubmit.Text = "SUBMIT"
        Me.btnOSSubmit.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("News706 BT", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 18)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Item Received :"
        '
        'dateMPDRDate
        '
        Me.dateMPDRDate.Checked = False
        Me.dateMPDRDate.CustomFormat = " "
        Me.dateMPDRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateMPDRDate.Location = New System.Drawing.Point(531, 75)
        Me.dateMPDRDate.Name = "dateMPDRDate"
        Me.dateMPDRDate.Size = New System.Drawing.Size(196, 20)
        Me.dateMPDRDate.TabIndex = 15
        Me.dateMPDRDate.Value = New Date(2025, 6, 19, 14, 41, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(61, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Delivery Date :"
        '
        'dateMPDelivery
        '
        Me.dateMPDelivery.Checked = False
        Me.dateMPDelivery.CustomFormat = " "
        Me.dateMPDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateMPDelivery.Location = New System.Drawing.Point(156, 120)
        Me.dateMPDelivery.Name = "dateMPDelivery"
        Me.dateMPDelivery.Size = New System.Drawing.Size(219, 20)
        Me.dateMPDelivery.TabIndex = 13
        Me.dateMPDelivery.Value = New Date(2025, 6, 19, 14, 41, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(450, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "REMARKS :"
        '
        'txtMPRemarks
        '
        Me.txtMPRemarks.Location = New System.Drawing.Point(531, 119)
        Me.txtMPRemarks.Name = "txtMPRemarks"
        Me.txtMPRemarks.Size = New System.Drawing.Size(383, 20)
        Me.txtMPRemarks.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(440, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Receipt Date :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(99, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Supplier :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Refence No. :"
        '
        'txtMPRefNo
        '
        Me.txtMPRefNo.Location = New System.Drawing.Point(156, 78)
        Me.txtMPRefNo.Name = "txtMPRefNo"
        Me.txtMPRefNo.Size = New System.Drawing.Size(219, 20)
        Me.txtMPRefNo.TabIndex = 2
        '
        'dgOS
        '
        Me.dgOS.AllowUserToAddRows = False
        Me.dgOS.AllowUserToDeleteRows = False
        Me.dgOS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgOS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgOS.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgOS.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgOS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.stock_skucode, Me.stock_item, Me.stock_color, Me.stock_variant, Me.stock_qty, Me.stock_unitcost, Me.stock_remove})
        Me.dgOS.Location = New System.Drawing.Point(10, 190)
        Me.dgOS.Margin = New System.Windows.Forms.Padding(2)
        Me.dgOS.Name = "dgOS"
        Me.dgOS.RowHeadersVisible = False
        Me.dgOS.RowHeadersWidth = 51
        Me.dgOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOS.Size = New System.Drawing.Size(1086, 342)
        Me.dgOS.TabIndex = 1
        '
        'btnORShowItems
        '
        Me.btnORShowItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnORShowItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnORShowItems.Image = Global.MCPlusInventorySystem.My.Resources.Resources.searchlist_icon
        Me.btnORShowItems.Location = New System.Drawing.Point(1042, 153)
        Me.btnORShowItems.Name = "btnORShowItems"
        Me.btnORShowItems.Size = New System.Drawing.Size(44, 34)
        Me.btnORShowItems.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnORShowItems.TabIndex = 17
        Me.btnORShowItems.TabStop = False
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
        'stock_skucode
        '
        Me.stock_skucode.HeaderText = "SKU"
        Me.stock_skucode.Name = "stock_skucode"
        '
        'stock_item
        '
        Me.stock_item.HeaderText = "Product Desc."
        Me.stock_item.Name = "stock_item"
        Me.stock_item.ReadOnly = True
        '
        'stock_color
        '
        Me.stock_color.HeaderText = "Color"
        Me.stock_color.Name = "stock_color"
        Me.stock_color.ReadOnly = True
        '
        'stock_variant
        '
        Me.stock_variant.HeaderText = "Variation"
        Me.stock_variant.Name = "stock_variant"
        Me.stock_variant.ReadOnly = True
        '
        'stock_qty
        '
        Me.stock_qty.HeaderText = "Add Stock / Qty"
        Me.stock_qty.Name = "stock_qty"
        '
        'stock_unitcost
        '
        Me.stock_unitcost.HeaderText = "Unit Cost"
        Me.stock_unitcost.Name = "stock_unitcost"
        '
        'stock_remove
        '
        Me.stock_remove.FillWeight = 20.0!
        Me.stock_remove.HeaderText = ""
        Me.stock_remove.Image = Global.MCPlusInventorySystem.My.Resources.Resources.remove
        Me.stock_remove.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.stock_remove.Name = "stock_remove"
        Me.stock_remove.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.stock_remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'frmAddStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1107, 588)
        Me.Controls.Add(Me.lblSupCode)
        Me.Controls.Add(Me.cbMPSup)
        Me.Controls.Add(Me.btnOSSubmit)
        Me.Controls.Add(Me.btnORShowItems)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgOS)
        Me.Controls.Add(Me.dateMPDRDate)
        Me.Controls.Add(Me.txtMPRefNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dateMPDelivery)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMPRemarks)
        Me.MinimizeBox = False
        Me.Name = "frmAddStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Incoming Stocks"
        CType(Me.dgOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnORShowItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgOS As DataGridView
    Friend WithEvents txtMPRefNo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dateMPDelivery As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMPRemarks As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dateMPDRDate As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents btnORShowItems As PictureBox
    Friend WithEvents btnOSSubmit As Button
    Friend WithEvents cbMPSup As ComboBox
    Friend WithEvents lblSupCode As Label
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents stock_skucode As DataGridViewTextBoxColumn
    Friend WithEvents stock_item As DataGridViewTextBoxColumn
    Friend WithEvents stock_color As DataGridViewTextBoxColumn
    Friend WithEvents stock_variant As DataGridViewTextBoxColumn
    Friend WithEvents stock_qty As DataGridViewTextBoxColumn
    Friend WithEvents stock_unitcost As DataGridViewTextBoxColumn
    Friend WithEvents stock_remove As DataGridViewImageColumn
End Class

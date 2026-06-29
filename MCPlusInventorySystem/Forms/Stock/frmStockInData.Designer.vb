<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockInData
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblMPStatus = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMPSupplier = New System.Windows.Forms.Label()
        Me.lblMPID = New System.Windows.Forms.Label()
        Me.txttMPDeliveryDate = New System.Windows.Forms.TextBox()
        Me.txtMPRefNo = New System.Windows.Forms.TextBox()
        Me.txtMPReceiptDate = New System.Windows.Forms.TextBox()
        Me.txtMPRemarks = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnStockINPrint = New System.Windows.Forms.Button()
        Me.dgMPL = New System.Windows.Forms.DataGridView()
        Me.comp_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_link = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mpl_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_gender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_col = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_cat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_variant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mpl_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mpl_unitcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.no_print = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.printed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.skuprinted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sku_selectprint = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgMPL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblMPStatus)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblMPSupplier)
        Me.GroupBox1.Controls.Add(Me.lblMPID)
        Me.GroupBox1.Controls.Add(Me.txttMPDeliveryDate)
        Me.GroupBox1.Controls.Add(Me.txtMPRefNo)
        Me.GroupBox1.Controls.Add(Me.txtMPReceiptDate)
        Me.GroupBox1.Controls.Add(Me.txtMPRemarks)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnStockINPrint)
        Me.GroupBox1.Controls.Add(Me.dgMPL)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1494, 676)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'lblMPStatus
        '
        Me.lblMPStatus.AutoSize = True
        Me.lblMPStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMPStatus.ForeColor = System.Drawing.Color.Black
        Me.lblMPStatus.Location = New System.Drawing.Point(579, 28)
        Me.lblMPStatus.Name = "lblMPStatus"
        Me.lblMPStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblMPStatus.TabIndex = 85
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(532, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Status :"
        '
        'lblMPSupplier
        '
        Me.lblMPSupplier.AutoSize = True
        Me.lblMPSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMPSupplier.ForeColor = System.Drawing.Color.Black
        Me.lblMPSupplier.Location = New System.Drawing.Point(83, 27)
        Me.lblMPSupplier.Name = "lblMPSupplier"
        Me.lblMPSupplier.Size = New System.Drawing.Size(0, 15)
        Me.lblMPSupplier.TabIndex = 83
        '
        'lblMPID
        '
        Me.lblMPID.AutoSize = True
        Me.lblMPID.ForeColor = System.Drawing.Color.Blue
        Me.lblMPID.Location = New System.Drawing.Point(370, 27)
        Me.lblMPID.Name = "lblMPID"
        Me.lblMPID.Size = New System.Drawing.Size(0, 13)
        Me.lblMPID.TabIndex = 82
        '
        'txttMPDeliveryDate
        '
        Me.txttMPDeliveryDate.Location = New System.Drawing.Point(101, 105)
        Me.txttMPDeliveryDate.Name = "txttMPDeliveryDate"
        Me.txttMPDeliveryDate.ReadOnly = True
        Me.txttMPDeliveryDate.Size = New System.Drawing.Size(156, 20)
        Me.txttMPDeliveryDate.TabIndex = 81
        '
        'txtMPRefNo
        '
        Me.txtMPRefNo.Location = New System.Drawing.Point(101, 75)
        Me.txtMPRefNo.Name = "txtMPRefNo"
        Me.txtMPRefNo.ReadOnly = True
        Me.txtMPRefNo.Size = New System.Drawing.Size(156, 20)
        Me.txtMPRefNo.TabIndex = 80
        '
        'txtMPReceiptDate
        '
        Me.txtMPReceiptDate.Location = New System.Drawing.Point(370, 71)
        Me.txtMPReceiptDate.Name = "txtMPReceiptDate"
        Me.txtMPReceiptDate.ReadOnly = True
        Me.txtMPReceiptDate.Size = New System.Drawing.Size(167, 20)
        Me.txtMPReceiptDate.TabIndex = 79
        '
        'txtMPRemarks
        '
        Me.txtMPRemarks.Location = New System.Drawing.Point(370, 101)
        Me.txtMPRemarks.Name = "txtMPRemarks"
        Me.txtMPRemarks.ReadOnly = True
        Me.txtMPRemarks.Size = New System.Drawing.Size(383, 20)
        Me.txtMPRemarks.TabIndex = 78
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(281, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Transaction ID :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Delivery Date :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(298, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "REMARKS :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(288, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Receipt Date :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Supplier :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Refence No. :"
        '
        'btnStockINPrint
        '
        Me.btnStockINPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStockINPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnStockINPrint.Enabled = False
        Me.btnStockINPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnStockINPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockINPrint.Location = New System.Drawing.Point(1404, 87)
        Me.btnStockINPrint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnStockINPrint.Name = "btnStockINPrint"
        Me.btnStockINPrint.Size = New System.Drawing.Size(82, 42)
        Me.btnStockINPrint.TabIndex = 68
        Me.btnStockINPrint.Text = "PRINT QR"
        Me.btnStockINPrint.UseVisualStyleBackColor = True
        '
        'dgMPL
        '
        Me.dgMPL.AllowUserToAddRows = False
        Me.dgMPL.AllowUserToDeleteRows = False
        Me.dgMPL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgMPL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgMPL.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgMPL.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgMPL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.comp_code, Me.sku_link, Me.mpl_id, Me.sku_code, Me.sku_gender, Me.sku_col, Me.sku_type, Me.sku_cat, Me.sku_color, Me.sku_variant, Me.mpl_qty, Me.mpl_unitcost, Me.no_print, Me.printed, Me.skuprinted, Me.sku_selectprint})
        Me.dgMPL.Location = New System.Drawing.Point(0, 158)
        Me.dgMPL.Margin = New System.Windows.Forms.Padding(2)
        Me.dgMPL.Name = "dgMPL"
        Me.dgMPL.RowHeadersVisible = False
        Me.dgMPL.RowHeadersWidth = 51
        Me.dgMPL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMPL.Size = New System.Drawing.Size(1494, 513)
        Me.dgMPL.TabIndex = 41
        '
        'comp_code
        '
        Me.comp_code.HeaderText = "Company Code"
        Me.comp_code.Name = "comp_code"
        Me.comp_code.ReadOnly = True
        Me.comp_code.Visible = False
        '
        'sku_link
        '
        Me.sku_link.HeaderText = "SKU link"
        Me.sku_link.Name = "sku_link"
        Me.sku_link.ReadOnly = True
        Me.sku_link.Visible = False
        '
        'mpl_id
        '
        Me.mpl_id.HeaderText = "Transaction ID"
        Me.mpl_id.Name = "mpl_id"
        Me.mpl_id.ReadOnly = True
        Me.mpl_id.Visible = False
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
        Me.sku_gender.FillWeight = 70.0!
        Me.sku_gender.HeaderText = "Gender"
        Me.sku_gender.Name = "sku_gender"
        Me.sku_gender.ReadOnly = True
        '
        'sku_col
        '
        Me.sku_col.HeaderText = "Collection"
        Me.sku_col.Name = "sku_col"
        Me.sku_col.ReadOnly = True
        '
        'sku_type
        '
        Me.sku_type.HeaderText = "Type"
        Me.sku_type.Name = "sku_type"
        Me.sku_type.ReadOnly = True
        '
        'sku_cat
        '
        Me.sku_cat.HeaderText = "Category"
        Me.sku_cat.Name = "sku_cat"
        Me.sku_cat.ReadOnly = True
        '
        'sku_color
        '
        Me.sku_color.HeaderText = "Color"
        Me.sku_color.Name = "sku_color"
        Me.sku_color.ReadOnly = True
        '
        'sku_variant
        '
        Me.sku_variant.HeaderText = "Variant/Size"
        Me.sku_variant.Name = "sku_variant"
        Me.sku_variant.ReadOnly = True
        '
        'mpl_qty
        '
        Me.mpl_qty.FillWeight = 50.0!
        Me.mpl_qty.HeaderText = "Qty"
        Me.mpl_qty.Name = "mpl_qty"
        Me.mpl_qty.ReadOnly = True
        '
        'mpl_unitcost
        '
        Me.mpl_unitcost.FillWeight = 50.0!
        Me.mpl_unitcost.HeaderText = "Unit Cost"
        Me.mpl_unitcost.Name = "mpl_unitcost"
        Me.mpl_unitcost.ReadOnly = True
        '
        'no_print
        '
        Me.no_print.FillWeight = 50.0!
        Me.no_print.HeaderText = "No. of print"
        Me.no_print.Name = "no_print"
        '
        'printed
        '
        Me.printed.FillWeight = 50.0!
        Me.printed.HeaderText = "Printed"
        Me.printed.Name = "printed"
        Me.printed.ReadOnly = True
        '
        'skuprinted
        '
        Me.skuprinted.HeaderText = "SKU Printed"
        Me.skuprinted.Name = "skuprinted"
        Me.skuprinted.ReadOnly = True
        Me.skuprinted.Visible = False
        '
        'sku_selectprint
        '
        Me.sku_selectprint.FillWeight = 50.0!
        Me.sku_selectprint.HeaderText = "Select print"
        Me.sku_selectprint.Name = "sku_selectprint"
        Me.sku_selectprint.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sku_selectprint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'frmStockInData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1494, 676)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1078, 582)
        Me.Name = "frmStockInData"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock In Data"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgMPL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgMPL As DataGridView
    Friend WithEvents btnStockINPrint As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txttMPDeliveryDate As TextBox
    Friend WithEvents txtMPRefNo As TextBox
    Friend WithEvents txtMPReceiptDate As TextBox
    Friend WithEvents txtMPRemarks As TextBox
    Friend WithEvents lblMPSupplier As Label
    Friend WithEvents lblMPID As Label
    Friend WithEvents lblMPStatus As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents comp_code As DataGridViewTextBoxColumn
    Friend WithEvents sku_link As DataGridViewTextBoxColumn
    Friend WithEvents mpl_id As DataGridViewTextBoxColumn
    Friend WithEvents sku_code As DataGridViewTextBoxColumn
    Friend WithEvents sku_gender As DataGridViewTextBoxColumn
    Friend WithEvents sku_col As DataGridViewTextBoxColumn
    Friend WithEvents sku_type As DataGridViewTextBoxColumn
    Friend WithEvents sku_cat As DataGridViewTextBoxColumn
    Friend WithEvents sku_color As DataGridViewTextBoxColumn
    Friend WithEvents sku_variant As DataGridViewTextBoxColumn
    Friend WithEvents mpl_qty As DataGridViewTextBoxColumn
    Friend WithEvents mpl_unitcost As DataGridViewTextBoxColumn
    Friend WithEvents no_print As DataGridViewTextBoxColumn
    Friend WithEvents printed As DataGridViewTextBoxColumn
    Friend WithEvents skuprinted As DataGridViewTextBoxColumn
    Friend WithEvents sku_selectprint As DataGridViewCheckBoxColumn
End Class

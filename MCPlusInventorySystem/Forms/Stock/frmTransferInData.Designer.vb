<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTransferInData
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTTStoreCodeOrig = New System.Windows.Forms.Label()
        Me.btnTransferReceived = New System.Windows.Forms.Button()
        Me.lblTTStatus = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTTStoreOrigin = New System.Windows.Forms.Label()
        Me.txtTTDRNo = New System.Windows.Forms.TextBox()
        Me.txtTTCreateDate = New System.Windows.Forms.TextBox()
        Me.txtTTRemarks = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgTransferL = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ti_companycode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ti_loc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ti_dr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ti_rowcount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ti_sku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ti_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ti_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ti_variant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ti_approved_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ti_received_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ti_receive_now = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgTransferL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblTTStoreCodeOrig)
        Me.GroupBox1.Controls.Add(Me.btnTransferReceived)
        Me.GroupBox1.Controls.Add(Me.lblTTStatus)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblTTStoreOrigin)
        Me.GroupBox1.Controls.Add(Me.txtTTDRNo)
        Me.GroupBox1.Controls.Add(Me.txtTTCreateDate)
        Me.GroupBox1.Controls.Add(Me.txtTTRemarks)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dgTransferL)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1101, 559)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'lblTTStoreCodeOrig
        '
        Me.lblTTStoreCodeOrig.AutoSize = True
        Me.lblTTStoreCodeOrig.Location = New System.Drawing.Point(95, 49)
        Me.lblTTStoreCodeOrig.Name = "lblTTStoreCodeOrig"
        Me.lblTTStoreCodeOrig.Size = New System.Drawing.Size(86, 13)
        Me.lblTTStoreCodeOrig.TabIndex = 91
        Me.lblTTStoreCodeOrig.Text = "Store Code From"
        '
        'btnTransferReceived
        '
        Me.btnTransferReceived.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransferReceived.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTransferReceived.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnTransferReceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransferReceived.Location = New System.Drawing.Point(917, 78)
        Me.btnTransferReceived.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTransferReceived.Name = "btnTransferReceived"
        Me.btnTransferReceived.Size = New System.Drawing.Size(82, 42)
        Me.btnTransferReceived.TabIndex = 87
        Me.btnTransferReceived.Text = "Received"
        Me.btnTransferReceived.UseVisualStyleBackColor = True
        Me.btnTransferReceived.Visible = False
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
        'lblTTStoreOrigin
        '
        Me.lblTTStoreOrigin.AutoSize = True
        Me.lblTTStoreOrigin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTTStoreOrigin.ForeColor = System.Drawing.Color.Black
        Me.lblTTStoreOrigin.Location = New System.Drawing.Point(93, 27)
        Me.lblTTStoreOrigin.Name = "lblTTStoreOrigin"
        Me.lblTTStoreOrigin.Size = New System.Drawing.Size(55, 15)
        Me.lblTTStoreOrigin.TabIndex = 83
        Me.lblTTStoreOrigin.Text = "ORIGIN"
        '
        'txtTTDRNo
        '
        Me.txtTTDRNo.Location = New System.Drawing.Point(144, 81)
        Me.txtTTDRNo.Name = "txtTTDRNo"
        Me.txtTTDRNo.ReadOnly = True
        Me.txtTTDRNo.Size = New System.Drawing.Size(156, 20)
        Me.txtTTDRNo.TabIndex = 80
        '
        'txtTTCreateDate
        '
        Me.txtTTCreateDate.Location = New System.Drawing.Point(423, 77)
        Me.txtTTCreateDate.Name = "txtTTCreateDate"
        Me.txtTTCreateDate.ReadOnly = True
        Me.txtTTCreateDate.Size = New System.Drawing.Size(167, 20)
        Me.txtTTCreateDate.TabIndex = 79
        '
        'txtTTRemarks
        '
        Me.txtTTRemarks.Location = New System.Drawing.Point(144, 115)
        Me.txtTTRemarks.Name = "txtTTRemarks"
        Me.txtTTRemarks.ReadOnly = True
        Me.txtTTRemarks.Size = New System.Drawing.Size(446, 20)
        Me.txtTTRemarks.TabIndex = 78
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(69, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "REMARKS :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(341, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Date Created :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "From :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(106, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "DR :"
        '
        'dgTransferL
        '
        Me.dgTransferL.AllowUserToAddRows = False
        Me.dgTransferL.AllowUserToDeleteRows = False
        Me.dgTransferL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTransferL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgTransferL.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgTransferL.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgTransferL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ti_companycode, Me.ti_loc, Me.ti_dr, Me.ti_rowcount, Me.ti_sku, Me.ti_item, Me.ti_color, Me.ti_variant, Me.ti_approved_qty, Me.ti_received_qty, Me.ti_receive_now})
        Me.dgTransferL.Location = New System.Drawing.Point(5, 158)
        Me.dgTransferL.Margin = New System.Windows.Forms.Padding(2)
        Me.dgTransferL.Name = "dgTransferL"
        Me.dgTransferL.RowHeadersVisible = False
        Me.dgTransferL.RowHeadersWidth = 51
        Me.dgTransferL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTransferL.Size = New System.Drawing.Size(1101, 396)
        Me.dgTransferL.TabIndex = 41
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
        Me.DataGridViewImageColumn1.Visible = False
        '
        'ti_companycode
        '
        Me.ti_companycode.HeaderText = "Company Code"
        Me.ti_companycode.Name = "ti_companycode"
        Me.ti_companycode.ReadOnly = True
        Me.ti_companycode.Visible = False
        '
        'ti_loc
        '
        Me.ti_loc.HeaderText = "Location"
        Me.ti_loc.Name = "ti_loc"
        Me.ti_loc.ReadOnly = True
        Me.ti_loc.Visible = False
        '
        'ti_dr
        '
        Me.ti_dr.HeaderText = "DR"
        Me.ti_dr.Name = "ti_dr"
        Me.ti_dr.ReadOnly = True
        Me.ti_dr.Visible = False
        '
        'ti_rowcount
        '
        Me.ti_rowcount.FillWeight = 20.0!
        Me.ti_rowcount.HeaderText = ""
        Me.ti_rowcount.Name = "ti_rowcount"
        Me.ti_rowcount.ReadOnly = True
        '
        'ti_sku
        '
        Me.ti_sku.HeaderText = "SKU"
        Me.ti_sku.Name = "ti_sku"
        Me.ti_sku.ReadOnly = True
        '
        'ti_item
        '
        Me.ti_item.HeaderText = "Product Desc."
        Me.ti_item.Name = "ti_item"
        Me.ti_item.ReadOnly = True
        '
        'ti_color
        '
        Me.ti_color.HeaderText = "Color"
        Me.ti_color.Name = "ti_color"
        Me.ti_color.ReadOnly = True
        '
        'ti_variant
        '
        Me.ti_variant.HeaderText = "Variation"
        Me.ti_variant.Name = "ti_variant"
        Me.ti_variant.ReadOnly = True
        '
        'ti_approved_qty
        '
        Me.ti_approved_qty.FillWeight = 40.0!
        Me.ti_approved_qty.HeaderText = "Delivery Qty"
        Me.ti_approved_qty.Name = "ti_approved_qty"
        Me.ti_approved_qty.ReadOnly = True
        '
        'ti_received_qty
        '
        Me.ti_received_qty.FillWeight = 40.0!
        Me.ti_received_qty.HeaderText = "Qty Received"
        Me.ti_received_qty.Name = "ti_received_qty"
        Me.ti_received_qty.Visible = False
        '
        'ti_receive_now
        '
        Me.ti_receive_now.FillWeight = 40.0!
        Me.ti_receive_now.HeaderText = "Receive Now"
        Me.ti_receive_now.Name = "ti_receive_now"
        Me.ti_receive_now.Visible = False
        '
        'frmTransferInData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1103, 561)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1119, 600)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1119, 600)
        Me.Name = "frmTransferInData"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transfer Receiving"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgTransferL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTTStoreCodeOrig As Label
    Friend WithEvents btnTransferReceived As Button
    Friend WithEvents lblTTStatus As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTTStoreOrigin As Label
    Friend WithEvents txtTTDRNo As TextBox
    Friend WithEvents txtTTCreateDate As TextBox
    Friend WithEvents txtTTRemarks As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgTransferL As DataGridView
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents ti_companycode As DataGridViewTextBoxColumn
    Friend WithEvents ti_loc As DataGridViewTextBoxColumn
    Friend WithEvents ti_dr As DataGridViewTextBoxColumn
    Friend WithEvents ti_rowcount As DataGridViewTextBoxColumn
    Friend WithEvents ti_sku As DataGridViewTextBoxColumn
    Friend WithEvents ti_item As DataGridViewTextBoxColumn
    Friend WithEvents ti_color As DataGridViewTextBoxColumn
    Friend WithEvents ti_variant As DataGridViewTextBoxColumn
    Friend WithEvents ti_approved_qty As DataGridViewTextBoxColumn
    Friend WithEvents ti_received_qty As DataGridViewTextBoxColumn
    Friend WithEvents ti_receive_now As DataGridViewTextBoxColumn
End Class

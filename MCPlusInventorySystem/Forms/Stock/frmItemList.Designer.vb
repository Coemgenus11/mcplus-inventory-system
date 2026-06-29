<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmItemList
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
        Me.dgItemList = New System.Windows.Forms.DataGridView()
        Me.stock_skucode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock_desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock_variant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock_current = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtItemListSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblForTransferOut = New System.Windows.Forms.Label()
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgItemList
        '
        Me.dgItemList.AllowUserToAddRows = False
        Me.dgItemList.AllowUserToDeleteRows = False
        Me.dgItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgItemList.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgItemList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.stock_skucode, Me.stock_desc, Me.stock_color, Me.stock_variant, Me.stock_current})
        Me.dgItemList.Location = New System.Drawing.Point(0, 53)
        Me.dgItemList.Margin = New System.Windows.Forms.Padding(2)
        Me.dgItemList.Name = "dgItemList"
        Me.dgItemList.ReadOnly = True
        Me.dgItemList.RowHeadersVisible = False
        Me.dgItemList.RowHeadersWidth = 51
        Me.dgItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItemList.Size = New System.Drawing.Size(903, 409)
        Me.dgItemList.TabIndex = 2
        '
        'stock_skucode
        '
        Me.stock_skucode.FillWeight = 40.0!
        Me.stock_skucode.HeaderText = "SKU"
        Me.stock_skucode.Name = "stock_skucode"
        Me.stock_skucode.ReadOnly = True
        '
        'stock_desc
        '
        Me.stock_desc.HeaderText = "Product Desc"
        Me.stock_desc.Name = "stock_desc"
        Me.stock_desc.ReadOnly = True
        '
        'stock_color
        '
        Me.stock_color.FillWeight = 60.0!
        Me.stock_color.HeaderText = "Color"
        Me.stock_color.Name = "stock_color"
        Me.stock_color.ReadOnly = True
        '
        'stock_variant
        '
        Me.stock_variant.FillWeight = 50.0!
        Me.stock_variant.HeaderText = "Variation"
        Me.stock_variant.Name = "stock_variant"
        Me.stock_variant.ReadOnly = True
        '
        'stock_current
        '
        Me.stock_current.FillWeight = 30.0!
        Me.stock_current.HeaderText = "Stock / Qty"
        Me.stock_current.Name = "stock_current"
        Me.stock_current.ReadOnly = True
        '
        'txtItemListSearch
        '
        Me.txtItemListSearch.Location = New System.Drawing.Point(56, 29)
        Me.txtItemListSearch.Name = "txtItemListSearch"
        Me.txtItemListSearch.Size = New System.Drawing.Size(175, 20)
        Me.txtItemListSearch.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search :"
        '
        'lblForTransferOut
        '
        Me.lblForTransferOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblForTransferOut.AutoSize = True
        Me.lblForTransferOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForTransferOut.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblForTransferOut.Location = New System.Drawing.Point(638, 38)
        Me.lblForTransferOut.Name = "lblForTransferOut"
        Me.lblForTransferOut.Size = New System.Drawing.Size(265, 13)
        Me.lblForTransferOut.TabIndex = 5
        Me.lblForTransferOut.Text = "Double-click the list to view stock locations for picking."
        '
        'frmItemList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 462)
        Me.Controls.Add(Me.lblForTransferOut)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtItemListSearch)
        Me.Controls.Add(Me.dgItemList)
        Me.Name = "frmItemList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item List"
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgItemList As DataGridView
    Friend WithEvents txtItemListSearch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblForTransferOut As Label
    Friend WithEvents stock_skucode As DataGridViewTextBoxColumn
    Friend WithEvents stock_desc As DataGridViewTextBoxColumn
    Friend WithEvents stock_color As DataGridViewTextBoxColumn
    Friend WithEvents stock_variant As DataGridViewTextBoxColumn
    Friend WithEvents stock_current As DataGridViewTextBoxColumn
End Class

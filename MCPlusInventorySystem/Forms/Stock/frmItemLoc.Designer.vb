<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemLoc
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
        Me.dgItemLoc = New System.Windows.Forms.DataGridView()
        Me.loc_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loc_qty_current = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblLocSKU = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLocProdDesc = New System.Windows.Forms.Label()
        Me.lblLocVar = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLocColor = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblLocTotalQty = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblForTransferOut = New System.Windows.Forms.Label()
        CType(Me.dgItemLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgItemLoc
        '
        Me.dgItemLoc.AllowUserToAddRows = False
        Me.dgItemLoc.AllowUserToDeleteRows = False
        Me.dgItemLoc.AllowUserToResizeColumns = False
        Me.dgItemLoc.AllowUserToResizeRows = False
        Me.dgItemLoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgItemLoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgItemLoc.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgItemLoc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgItemLoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgItemLoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.loc_code, Me.loc_qty_current})
        Me.dgItemLoc.Location = New System.Drawing.Point(1, 101)
        Me.dgItemLoc.Margin = New System.Windows.Forms.Padding(2)
        Me.dgItemLoc.Name = "dgItemLoc"
        Me.dgItemLoc.ReadOnly = True
        Me.dgItemLoc.RowHeadersVisible = False
        Me.dgItemLoc.RowHeadersWidth = 51
        Me.dgItemLoc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgItemLoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItemLoc.Size = New System.Drawing.Size(498, 177)
        Me.dgItemLoc.TabIndex = 3
        '
        'loc_code
        '
        Me.loc_code.HeaderText = "Location"
        Me.loc_code.Name = "loc_code"
        Me.loc_code.ReadOnly = True
        '
        'loc_qty_current
        '
        Me.loc_qty_current.FillWeight = 60.0!
        Me.loc_qty_current.HeaderText = "Stock / Qty"
        Me.loc_qty_current.Name = "loc_qty_current"
        Me.loc_qty_current.ReadOnly = True
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(330, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "SKU : "
        '
        'lblLocSKU
        '
        Me.lblLocSKU.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLocSKU.AutoSize = True
        Me.lblLocSKU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocSKU.Location = New System.Drawing.Point(383, 86)
        Me.lblLocSKU.Name = "lblLocSKU"
        Me.lblLocSKU.Size = New System.Drawing.Size(15, 13)
        Me.lblLocSKU.TabIndex = 40
        Me.lblLocSKU.Text = "--"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Item :"
        '
        'lblLocProdDesc
        '
        Me.lblLocProdDesc.AutoSize = True
        Me.lblLocProdDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocProdDesc.Location = New System.Drawing.Point(74, 9)
        Me.lblLocProdDesc.Name = "lblLocProdDesc"
        Me.lblLocProdDesc.Size = New System.Drawing.Size(15, 13)
        Me.lblLocProdDesc.TabIndex = 42
        Me.lblLocProdDesc.Text = "--"
        '
        'lblLocVar
        '
        Me.lblLocVar.AutoSize = True
        Me.lblLocVar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocVar.Location = New System.Drawing.Point(75, 63)
        Me.lblLocVar.Name = "lblLocVar"
        Me.lblLocVar.Size = New System.Drawing.Size(15, 13)
        Me.lblLocVar.TabIndex = 44
        Me.lblLocVar.Text = "--"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Variation :"
        '
        'lblLocColor
        '
        Me.lblLocColor.AutoSize = True
        Me.lblLocColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocColor.Location = New System.Drawing.Point(75, 34)
        Me.lblLocColor.Name = "lblLocColor"
        Me.lblLocColor.Size = New System.Drawing.Size(15, 13)
        Me.lblLocColor.TabIndex = 46
        Me.lblLocColor.Text = "--"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Color :"
        '
        'lblLocTotalQty
        '
        Me.lblLocTotalQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLocTotalQty.AutoSize = True
        Me.lblLocTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocTotalQty.Location = New System.Drawing.Point(443, 286)
        Me.lblLocTotalQty.Name = "lblLocTotalQty"
        Me.lblLocTotalQty.Size = New System.Drawing.Size(15, 13)
        Me.lblLocTotalQty.TabIndex = 48
        Me.lblLocTotalQty.Text = "--"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(364, 286)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "TOTAL QTY :"
        '
        'lblForTransferOut
        '
        Me.lblForTransferOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblForTransferOut.AutoSize = True
        Me.lblForTransferOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForTransferOut.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblForTransferOut.Location = New System.Drawing.Point(-2, 280)
        Me.lblForTransferOut.Name = "lblForTransferOut"
        Me.lblForTransferOut.Size = New System.Drawing.Size(331, 13)
        Me.lblForTransferOut.TabIndex = 49
        Me.lblForTransferOut.Text = "Double-click the list to select an item and save it to the transfer table."
        Me.lblForTransferOut.Visible = False
        '
        'frmItemLoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 306)
        Me.Controls.Add(Me.lblForTransferOut)
        Me.Controls.Add(Me.lblLocTotalQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblLocColor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblLocVar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblLocProdDesc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblLocSKU)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dgItemLoc)
        Me.Name = "frmItemLoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Location/s"
        CType(Me.dgItemLoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgItemLoc As DataGridView
    Friend WithEvents Label10 As Label
    Friend WithEvents lblLocSKU As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblLocVar As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblLocColor As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblLocProdDesc As Label
    Friend WithEvents loc_code As DataGridViewTextBoxColumn
    Friend WithEvents loc_qty_current As DataGridViewTextBoxColumn
    Friend WithEvents lblLocTotalQty As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblForTransferOut As Label
End Class

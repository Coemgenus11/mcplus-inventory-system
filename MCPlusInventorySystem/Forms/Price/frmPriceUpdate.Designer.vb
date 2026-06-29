<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPriceUpdate
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
        Me.lblPriceSku = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPriceUpdateSave = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPriceUnit = New System.Windows.Forms.TextBox()
        Me.txtPriceRetail = New System.Windows.Forms.TextBox()
        Me.lblLocColor = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblLocVar = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtProductDesc = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPriceSku
        '
        Me.lblPriceSku.AutoSize = True
        Me.lblPriceSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPriceSku.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblPriceSku.Location = New System.Drawing.Point(225, 117)
        Me.lblPriceSku.Name = "lblPriceSku"
        Me.lblPriceSku.Size = New System.Drawing.Size(0, 13)
        Me.lblPriceSku.TabIndex = 89
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(184, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "SKU :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 16)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "UNIT PRICE :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(53, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 16)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "SELLING PRICE :"
        '
        'btnPriceUpdateSave
        '
        Me.btnPriceUpdateSave.Location = New System.Drawing.Point(213, 260)
        Me.btnPriceUpdateSave.Name = "btnPriceUpdateSave"
        Me.btnPriceUpdateSave.Size = New System.Drawing.Size(75, 23)
        Me.btnPriceUpdateSave.TabIndex = 96
        Me.btnPriceUpdateSave.Text = "SAVE"
        Me.btnPriceUpdateSave.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(294, 260)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 97
        Me.Button4.Text = "CANCEL"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtProductDesc)
        Me.Panel1.Controls.Add(Me.lblLocColor)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lblLocVar)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.lblPriceSku)
        Me.Panel1.Location = New System.Drawing.Point(5, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(370, 138)
        Me.Panel1.TabIndex = 100
        '
        'txtPriceUnit
        '
        Me.txtPriceUnit.Font = New System.Drawing.Font("MS Reference Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPriceUnit.Location = New System.Drawing.Point(193, 170)
        Me.txtPriceUnit.Name = "txtPriceUnit"
        Me.txtPriceUnit.Size = New System.Drawing.Size(176, 26)
        Me.txtPriceUnit.TabIndex = 101
        Me.txtPriceUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPriceRetail
        '
        Me.txtPriceRetail.Font = New System.Drawing.Font("MS Reference Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPriceRetail.Location = New System.Drawing.Point(193, 202)
        Me.txtPriceRetail.Name = "txtPriceRetail"
        Me.txtPriceRetail.Size = New System.Drawing.Size(176, 26)
        Me.txtPriceRetail.TabIndex = 102
        Me.txtPriceRetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLocColor
        '
        Me.lblLocColor.AutoSize = True
        Me.lblLocColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocColor.Location = New System.Drawing.Point(97, 60)
        Me.lblLocColor.Name = "lblLocColor"
        Me.lblLocColor.Size = New System.Drawing.Size(15, 13)
        Me.lblLocColor.TabIndex = 105
        Me.lblLocColor.Text = "--"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(54, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "Color :"
        '
        'lblLocVar
        '
        Me.lblLocVar.AutoSize = True
        Me.lblLocVar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocVar.Location = New System.Drawing.Point(97, 89)
        Me.lblLocVar.Name = "lblLocVar"
        Me.lblLocVar.Size = New System.Drawing.Size(15, 13)
        Me.lblLocVar.TabIndex = 103
        Me.lblLocVar.Text = "--"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 102
        Me.Label9.Text = "Variation :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "Product Desc. :"
        '
        'txtProductDesc
        '
        Me.txtProductDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductDesc.Location = New System.Drawing.Point(100, 3)
        Me.txtProductDesc.Multiline = True
        Me.txtProductDesc.Name = "txtProductDesc"
        Me.txtProductDesc.ReadOnly = True
        Me.txtProductDesc.Size = New System.Drawing.Size(263, 50)
        Me.txtProductDesc.TabIndex = 106
        '
        'frmPriceUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 291)
        Me.Controls.Add(Me.txtPriceRetail)
        Me.Controls.Add(Me.txtPriceUnit)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.btnPriceUpdateSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPriceUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Price Update"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPriceSku As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnPriceUpdateSave As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtPriceUnit As TextBox
    Friend WithEvents txtPriceRetail As TextBox
    Friend WithEvents lblLocColor As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblLocVar As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtProductDesc As TextBox
End Class

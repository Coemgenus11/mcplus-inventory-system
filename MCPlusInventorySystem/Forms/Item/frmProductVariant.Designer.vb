<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductVariant
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
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnParVarCancel = New System.Windows.Forms.Button()
        Me.btnParVarAdd = New System.Windows.Forms.Button()
        Me.txtParVarCode = New System.Windows.Forms.TextBox()
        Me.lblewan = New System.Windows.Forms.Label()
        Me.txtParVarDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtParDesc = New System.Windows.Forms.TextBox()
        Me.txtParCode = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(9, 39)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(130, 16)
        Me.Label23.TabIndex = 64
        Me.Label23.Text = "Product Description :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 16)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Parent SKU Code :"
        '
        'btnParVarCancel
        '
        Me.btnParVarCancel.Location = New System.Drawing.Point(394, 245)
        Me.btnParVarCancel.Name = "btnParVarCancel"
        Me.btnParVarCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnParVarCancel.TabIndex = 62
        Me.btnParVarCancel.Text = "Cancel"
        Me.btnParVarCancel.UseVisualStyleBackColor = True
        '
        'btnParVarAdd
        '
        Me.btnParVarAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnParVarAdd.Location = New System.Drawing.Point(313, 245)
        Me.btnParVarAdd.Name = "btnParVarAdd"
        Me.btnParVarAdd.Size = New System.Drawing.Size(75, 32)
        Me.btnParVarAdd.TabIndex = 61
        Me.btnParVarAdd.Text = "Add"
        Me.btnParVarAdd.UseVisualStyleBackColor = True
        '
        'txtParVarCode
        '
        Me.txtParVarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtParVarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParVarCode.Location = New System.Drawing.Point(145, 194)
        Me.txtParVarCode.MaxLength = 3
        Me.txtParVarCode.Name = "txtParVarCode"
        Me.txtParVarCode.Size = New System.Drawing.Size(147, 22)
        Me.txtParVarCode.TabIndex = 60
        '
        'lblewan
        '
        Me.lblewan.AutoSize = True
        Me.lblewan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblewan.Location = New System.Drawing.Point(48, 197)
        Me.lblewan.Name = "lblewan"
        Me.lblewan.Size = New System.Drawing.Size(91, 16)
        Me.lblewan.TabIndex = 59
        Me.lblewan.Text = "Variant Code :"
        '
        'txtParVarDesc
        '
        Me.txtParVarDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParVarDesc.Location = New System.Drawing.Point(145, 154)
        Me.txtParVarDesc.Name = "txtParVarDesc"
        Me.txtParVarDesc.Size = New System.Drawing.Size(324, 22)
        Me.txtParVarDesc.TabIndex = 58
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(84, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Variant :"
        '
        'txtParDesc
        '
        Me.txtParDesc.Enabled = False
        Me.txtParDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParDesc.Location = New System.Drawing.Point(145, 19)
        Me.txtParDesc.Multiline = True
        Me.txtParDesc.Name = "txtParDesc"
        Me.txtParDesc.Size = New System.Drawing.Size(324, 60)
        Me.txtParDesc.TabIndex = 67
        '
        'txtParCode
        '
        Me.txtParCode.Enabled = False
        Me.txtParCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParCode.Location = New System.Drawing.Point(145, 94)
        Me.txtParCode.Name = "txtParCode"
        Me.txtParCode.Size = New System.Drawing.Size(158, 22)
        Me.txtParCode.TabIndex = 68
        '
        'frmProductVariant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 297)
        Me.Controls.Add(Me.txtParCode)
        Me.Controls.Add(Me.txtParDesc)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnParVarCancel)
        Me.Controls.Add(Me.btnParVarAdd)
        Me.Controls.Add(Me.txtParVarCode)
        Me.Controls.Add(Me.lblewan)
        Me.Controls.Add(Me.txtParVarDesc)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmProductVariant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmProductVariant"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label23 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnParVarCancel As Button
    Friend WithEvents btnParVarAdd As Button
    Friend WithEvents txtParVarCode As TextBox
    Friend WithEvents lblewan As Label
    Friend WithEvents txtParVarDesc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtParDesc As TextBox
    Friend WithEvents txtParCode As TextBox
End Class

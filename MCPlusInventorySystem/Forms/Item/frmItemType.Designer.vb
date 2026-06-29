<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemType
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
        Me.btnTypeCancel = New System.Windows.Forms.Button()
        Me.btnTypeAdd = New System.Windows.Forms.Button()
        Me.txtTypeCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTypeDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnTypeCancel
        '
        Me.btnTypeCancel.Location = New System.Drawing.Point(271, 128)
        Me.btnTypeCancel.Name = "btnTypeCancel"
        Me.btnTypeCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnTypeCancel.TabIndex = 35
        Me.btnTypeCancel.Text = "Cancel"
        Me.btnTypeCancel.UseVisualStyleBackColor = True
        '
        'btnTypeAdd
        '
        Me.btnTypeAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTypeAdd.Location = New System.Drawing.Point(190, 128)
        Me.btnTypeAdd.Name = "btnTypeAdd"
        Me.btnTypeAdd.Size = New System.Drawing.Size(75, 32)
        Me.btnTypeAdd.TabIndex = 34
        Me.btnTypeAdd.Text = "Add"
        Me.btnTypeAdd.UseVisualStyleBackColor = True
        '
        'txtTypeCode
        '
        Me.txtTypeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTypeCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTypeCode.Location = New System.Drawing.Point(190, 66)
        Me.txtTypeCode.MaxLength = 1
        Me.txtTypeCode.Name = "txtTypeCode"
        Me.txtTypeCode.Size = New System.Drawing.Size(147, 22)
        Me.txtTypeCode.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(67, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Item Type Code :"
        '
        'txtTypeDesc
        '
        Me.txtTypeDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTypeDesc.Location = New System.Drawing.Point(88, 31)
        Me.txtTypeDesc.Name = "txtTypeDesc"
        Me.txtTypeDesc.Size = New System.Drawing.Size(249, 22)
        Me.txtTypeDesc.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Item Type :"
        '
        'frmItemType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 179)
        Me.Controls.Add(Me.btnTypeCancel)
        Me.Controls.Add(Me.btnTypeAdd)
        Me.Controls.Add(Me.txtTypeCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTypeDesc)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmItemType"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnTypeCancel As Button
    Friend WithEvents btnTypeAdd As Button
    Friend WithEvents txtTypeCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTypeDesc As TextBox
    Friend WithEvents Label1 As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWearType
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
        Me.btnWTCancel = New System.Windows.Forms.Button()
        Me.btnWTAdd = New System.Windows.Forms.Button()
        Me.txtWTCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtWTDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnWTCancel
        '
        Me.btnWTCancel.Location = New System.Drawing.Point(271, 133)
        Me.btnWTCancel.Name = "btnWTCancel"
        Me.btnWTCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnWTCancel.TabIndex = 29
        Me.btnWTCancel.Text = "Cancel"
        Me.btnWTCancel.UseVisualStyleBackColor = True
        '
        'btnWTAdd
        '
        Me.btnWTAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWTAdd.Location = New System.Drawing.Point(190, 133)
        Me.btnWTAdd.Name = "btnWTAdd"
        Me.btnWTAdd.Size = New System.Drawing.Size(75, 32)
        Me.btnWTAdd.TabIndex = 28
        Me.btnWTAdd.Text = "Add"
        Me.btnWTAdd.UseVisualStyleBackColor = True
        '
        'txtWTCode
        '
        Me.txtWTCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWTCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWTCode.Location = New System.Drawing.Point(190, 71)
        Me.txtWTCode.MaxLength = 2
        Me.txtWTCode.Name = "txtWTCode"
        Me.txtWTCode.Size = New System.Drawing.Size(147, 22)
        Me.txtWTCode.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(67, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Wear Type Code :"
        '
        'txtWTDesc
        '
        Me.txtWTDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWTDesc.Location = New System.Drawing.Point(88, 36)
        Me.txtWTDesc.Name = "txtWTDesc"
        Me.txtWTDesc.Size = New System.Drawing.Size(249, 22)
        Me.txtWTDesc.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Wear Type :"
        '
        'frmWearType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 179)
        Me.Controls.Add(Me.btnWTCancel)
        Me.Controls.Add(Me.btnWTAdd)
        Me.Controls.Add(Me.txtWTCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtWTDesc)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmWearType"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wear Type"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnWTCancel As Button
    Friend WithEvents btnWTAdd As Button
    Friend WithEvents txtWTCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtWTDesc As TextBox
    Friend WithEvents Label1 As Label
End Class

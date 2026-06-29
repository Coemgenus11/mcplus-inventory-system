<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColor
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
        Me.btnColorCancel = New System.Windows.Forms.Button()
        Me.btnColorAdd = New System.Windows.Forms.Button()
        Me.txtColorCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtColorDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnColorStatus = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnColorCancel
        '
        Me.btnColorCancel.Location = New System.Drawing.Point(282, 148)
        Me.btnColorCancel.Name = "btnColorCancel"
        Me.btnColorCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnColorCancel.TabIndex = 41
        Me.btnColorCancel.Text = "Cancel"
        Me.btnColorCancel.UseVisualStyleBackColor = True
        '
        'btnColorAdd
        '
        Me.btnColorAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnColorAdd.Location = New System.Drawing.Point(201, 148)
        Me.btnColorAdd.Name = "btnColorAdd"
        Me.btnColorAdd.Size = New System.Drawing.Size(75, 32)
        Me.btnColorAdd.TabIndex = 40
        Me.btnColorAdd.Text = "Add"
        Me.btnColorAdd.UseVisualStyleBackColor = True
        '
        'txtColorCode
        '
        Me.txtColorCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColorCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColorCode.Location = New System.Drawing.Point(201, 70)
        Me.txtColorCode.MaxLength = 3
        Me.txtColorCode.Name = "txtColorCode"
        Me.txtColorCode.Size = New System.Drawing.Size(156, 22)
        Me.txtColorCode.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(79, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 16)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Color Code :"
        '
        'txtColorDesc
        '
        Me.txtColorDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColorDesc.Location = New System.Drawing.Point(82, 32)
        Me.txtColorDesc.Name = "txtColorDesc"
        Me.txtColorDesc.Size = New System.Drawing.Size(275, 22)
        Me.txtColorDesc.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Color :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(110, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Status :"
        '
        'btnColorStatus
        '
        Me.btnColorStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnColorStatus.Location = New System.Drawing.Point(201, 107)
        Me.btnColorStatus.Name = "btnColorStatus"
        Me.btnColorStatus.Size = New System.Drawing.Size(103, 23)
        Me.btnColorStatus.TabIndex = 43
        Me.btnColorStatus.Text = "active"
        Me.btnColorStatus.UseVisualStyleBackColor = True
        '
        'frmColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 206)
        Me.Controls.Add(Me.btnColorStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnColorCancel)
        Me.Controls.Add(Me.btnColorAdd)
        Me.Controls.Add(Me.txtColorCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtColorDesc)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmColor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Color"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnColorCancel As Button
    Friend WithEvents btnColorAdd As Button
    Friend WithEvents txtColorCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtColorDesc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnColorStatus As Button
End Class

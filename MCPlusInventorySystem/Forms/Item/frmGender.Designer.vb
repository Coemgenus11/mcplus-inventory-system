<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGender
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
        Me.btnGenderStatus = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGenderCancel = New System.Windows.Forms.Button()
        Me.btnGenderAdd = New System.Windows.Forms.Button()
        Me.txtGenderCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGenderDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnGenderStatus
        '
        Me.btnGenderStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenderStatus.Location = New System.Drawing.Point(202, 110)
        Me.btnGenderStatus.Name = "btnGenderStatus"
        Me.btnGenderStatus.Size = New System.Drawing.Size(103, 23)
        Me.btnGenderStatus.TabIndex = 51
        Me.btnGenderStatus.Text = "active"
        Me.btnGenderStatus.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(111, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Status :"
        '
        'btnGenderCancel
        '
        Me.btnGenderCancel.Location = New System.Drawing.Point(283, 151)
        Me.btnGenderCancel.Name = "btnGenderCancel"
        Me.btnGenderCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnGenderCancel.TabIndex = 49
        Me.btnGenderCancel.Text = "Cancel"
        Me.btnGenderCancel.UseVisualStyleBackColor = True
        '
        'btnGenderAdd
        '
        Me.btnGenderAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenderAdd.Location = New System.Drawing.Point(202, 151)
        Me.btnGenderAdd.Name = "btnGenderAdd"
        Me.btnGenderAdd.Size = New System.Drawing.Size(75, 32)
        Me.btnGenderAdd.TabIndex = 48
        Me.btnGenderAdd.Text = "Add"
        Me.btnGenderAdd.UseVisualStyleBackColor = True
        '
        'txtGenderCode
        '
        Me.txtGenderCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGenderCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGenderCode.Location = New System.Drawing.Point(165, 73)
        Me.txtGenderCode.MaxLength = 1
        Me.txtGenderCode.Name = "txtGenderCode"
        Me.txtGenderCode.Size = New System.Drawing.Size(193, 22)
        Me.txtGenderCode.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(80, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Code :"
        '
        'txtGenderDesc
        '
        Me.txtGenderDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGenderDesc.Location = New System.Drawing.Point(83, 35)
        Me.txtGenderDesc.Name = "txtGenderDesc"
        Me.txtGenderDesc.Size = New System.Drawing.Size(275, 22)
        Me.txtGenderDesc.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Gender :"
        '
        'frmGender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 207)
        Me.Controls.Add(Me.btnGenderStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnGenderCancel)
        Me.Controls.Add(Me.btnGenderAdd)
        Me.Controls.Add(Me.txtGenderCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGenderDesc)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmGender"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmGender"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGenderStatus As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGenderCancel As Button
    Friend WithEvents btnGenderAdd As Button
    Friend WithEvents txtGenderCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtGenderDesc As TextBox
    Friend WithEvents Label1 As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStyleVariant
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
        Me.btnSVarCancel = New System.Windows.Forms.Button()
        Me.btnSVarAdd = New System.Windows.Forms.Button()
        Me.txtSVarCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSVarDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSVarSCDesc = New System.Windows.Forms.Label()
        Me.lblSVarSCCode = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSVarCancel
        '
        Me.btnSVarCancel.Location = New System.Drawing.Point(279, 194)
        Me.btnSVarCancel.Name = "btnSVarCancel"
        Me.btnSVarCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnSVarCancel.TabIndex = 35
        Me.btnSVarCancel.Text = "Cancel"
        Me.btnSVarCancel.UseVisualStyleBackColor = True
        '
        'btnSVarAdd
        '
        Me.btnSVarAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSVarAdd.Location = New System.Drawing.Point(198, 194)
        Me.btnSVarAdd.Name = "btnSVarAdd"
        Me.btnSVarAdd.Size = New System.Drawing.Size(75, 32)
        Me.btnSVarAdd.TabIndex = 34
        Me.btnSVarAdd.Text = "Add"
        Me.btnSVarAdd.UseVisualStyleBackColor = True
        '
        'txtSVarCode
        '
        Me.txtSVarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSVarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSVarCode.Location = New System.Drawing.Point(207, 130)
        Me.txtSVarCode.MaxLength = 1
        Me.txtSVarCode.Name = "txtSVarCode"
        Me.txtSVarCode.Size = New System.Drawing.Size(147, 22)
        Me.txtSVarCode.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(77, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Style Variant Code :"
        '
        'txtSVarDesc
        '
        Me.txtSVarDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSVarDesc.Location = New System.Drawing.Point(105, 95)
        Me.txtSVarDesc.Name = "txtSVarDesc"
        Me.txtSVarDesc.Size = New System.Drawing.Size(249, 22)
        Me.txtSVarDesc.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Style Variant :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(1, 28)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(101, 16)
        Me.Label23.TabIndex = 54
        Me.Label23.Text = "Style Category :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(56, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 16)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Code :"
        '
        'lblSVarSCDesc
        '
        Me.lblSVarSCDesc.AutoSize = True
        Me.lblSVarSCDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSVarSCDesc.Location = New System.Drawing.Point(108, 28)
        Me.lblSVarSCDesc.Name = "lblSVarSCDesc"
        Me.lblSVarSCDesc.Size = New System.Drawing.Size(12, 16)
        Me.lblSVarSCDesc.TabIndex = 55
        Me.lblSVarSCDesc.Text = "-"
        '
        'lblSVarSCCode
        '
        Me.lblSVarSCCode.AutoSize = True
        Me.lblSVarSCCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSVarSCCode.Location = New System.Drawing.Point(108, 58)
        Me.lblSVarSCCode.Name = "lblSVarSCCode"
        Me.lblSVarSCCode.Size = New System.Drawing.Size(12, 16)
        Me.lblSVarSCCode.TabIndex = 56
        Me.lblSVarSCCode.Text = "-"
        '
        'frmStyleVariant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 238)
        Me.Controls.Add(Me.lblSVarSCCode)
        Me.Controls.Add(Me.lblSVarSCDesc)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnSVarCancel)
        Me.Controls.Add(Me.btnSVarAdd)
        Me.Controls.Add(Me.txtSVarCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSVarDesc)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStyleVariant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStyleVariant"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSVarCancel As Button
    Friend WithEvents btnSVarAdd As Button
    Friend WithEvents txtSVarCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSVarDesc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblSVarSCDesc As Label
    Friend WithEvents lblSVarSCCode As Label
End Class

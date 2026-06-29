<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAuth
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
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtAuthDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAuthCode = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.lblAuth = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label23.Location = New System.Drawing.Point(33, 63)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(142, 17)
        Me.Label23.TabIndex = 64
        Me.Label23.Text = "Authority Description"
        '
        'txtAuthDesc
        '
        Me.txtAuthDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAuthDesc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuthDesc.Location = New System.Drawing.Point(34, 83)
        Me.txtAuthDesc.Name = "txtAuthDesc"
        Me.txtAuthDesc.Size = New System.Drawing.Size(323, 26)
        Me.txtAuthDesc.TabIndex = 63
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(52, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 17)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Authority Code (3 char) :"
        '
        'txtAuthCode
        '
        Me.txtAuthCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAuthCode.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuthCode.Location = New System.Drawing.Point(224, 122)
        Me.txtAuthCode.MaxLength = 3
        Me.txtAuthCode.Name = "txtAuthCode"
        Me.txtAuthCode.Size = New System.Drawing.Size(133, 26)
        Me.txtAuthCode.TabIndex = 65
        '
        'btnSubmit
        '
        Me.btnSubmit.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.btnSubmit.FlatAppearance.BorderColor = System.Drawing.Color.MediumSeaGreen
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.Color.Transparent
        Me.btnSubmit.Location = New System.Drawing.Point(282, 181)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 29)
        Me.btnSubmit.TabIndex = 77
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'lblAuth
        '
        Me.lblAuth.AutoSize = True
        Me.lblAuth.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuth.ForeColor = System.Drawing.Color.DarkRed
        Me.lblAuth.Location = New System.Drawing.Point(134, 9)
        Me.lblAuth.Name = "lblAuth"
        Me.lblAuth.Size = New System.Drawing.Size(113, 20)
        Me.lblAuth.TabIndex = 78
        Me.lblAuth.Text = "ADD AUTHORITY"
        '
        'frmAuth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ClientSize = New System.Drawing.Size(384, 222)
        Me.Controls.Add(Me.lblAuth)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAuthCode)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtAuthDesc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAuth"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Authority"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label23 As Label
    Friend WithEvents txtAuthDesc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAuthCode As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents lblAuth As Label
End Class

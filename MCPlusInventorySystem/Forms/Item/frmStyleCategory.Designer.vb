<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStyleCategory
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
        Me.btnSCatCancel = New System.Windows.Forms.Button()
        Me.btnSCatAdd = New System.Windows.Forms.Button()
        Me.txtSCatCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSCatDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.cbWear = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTypeCode = New System.Windows.Forms.Label()
        Me.lblWearCode = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSCatCancel
        '
        Me.btnSCatCancel.Location = New System.Drawing.Point(289, 253)
        Me.btnSCatCancel.Name = "btnSCatCancel"
        Me.btnSCatCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnSCatCancel.TabIndex = 41
        Me.btnSCatCancel.Text = "Cancel"
        Me.btnSCatCancel.UseVisualStyleBackColor = True
        '
        'btnSCatAdd
        '
        Me.btnSCatAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSCatAdd.Location = New System.Drawing.Point(208, 253)
        Me.btnSCatAdd.Name = "btnSCatAdd"
        Me.btnSCatAdd.Size = New System.Drawing.Size(75, 32)
        Me.btnSCatAdd.TabIndex = 40
        Me.btnSCatAdd.Text = "Add"
        Me.btnSCatAdd.UseVisualStyleBackColor = True
        '
        'txtSCatCode
        '
        Me.txtSCatCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSCatCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSCatCode.Location = New System.Drawing.Point(217, 71)
        Me.txtSCatCode.MaxLength = 2
        Me.txtSCatCode.Name = "txtSCatCode"
        Me.txtSCatCode.Size = New System.Drawing.Size(147, 22)
        Me.txtSCatCode.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(74, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 16)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Style Category Code :"
        '
        'txtSCatDesc
        '
        Me.txtSCatDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSCatDesc.Location = New System.Drawing.Point(115, 39)
        Me.txtSCatDesc.Name = "txtSCatDesc"
        Me.txtSCatDesc.Size = New System.Drawing.Size(249, 22)
        Me.txtSCatDesc.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 16)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Style Category"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Item Type"
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(103, 126)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(261, 26)
        Me.cbType.TabIndex = 73
        '
        'cbWear
        '
        Me.cbWear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbWear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbWear.FormattingEnabled = True
        Me.cbWear.Location = New System.Drawing.Point(105, 180)
        Me.cbWear.Name = "cbWear"
        Me.cbWear.Size = New System.Drawing.Size(261, 26)
        Me.cbWear.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Wear Type"
        '
        'lblTypeCode
        '
        Me.lblTypeCode.AutoSize = True
        Me.lblTypeCode.Location = New System.Drawing.Point(354, 110)
        Me.lblTypeCode.Name = "lblTypeCode"
        Me.lblTypeCode.Size = New System.Drawing.Size(0, 13)
        Me.lblTypeCode.TabIndex = 76
        '
        'lblWearCode
        '
        Me.lblWearCode.AutoSize = True
        Me.lblWearCode.Location = New System.Drawing.Point(346, 164)
        Me.lblWearCode.Name = "lblWearCode"
        Me.lblWearCode.Size = New System.Drawing.Size(0, 13)
        Me.lblWearCode.TabIndex = 77
        '
        'frmStyleCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 307)
        Me.Controls.Add(Me.lblWearCode)
        Me.Controls.Add(Me.lblTypeCode)
        Me.Controls.Add(Me.cbWear)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSCatCancel)
        Me.Controls.Add(Me.btnSCatAdd)
        Me.Controls.Add(Me.txtSCatCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSCatDesc)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStyleCategory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStyleCategory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSCatCancel As Button
    Friend WithEvents btnSCatAdd As Button
    Friend WithEvents txtSCatCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSCatDesc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbType As ComboBox
    Friend WithEvents cbWear As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTypeCode As Label
    Friend WithEvents lblWearCode As Label
End Class

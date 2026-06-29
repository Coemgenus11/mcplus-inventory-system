<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollection
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
        Me.btnColStatus = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnColCancel = New System.Windows.Forms.Button()
        Me.btnColAdd = New System.Windows.Forms.Button()
        Me.txtColCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtColDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnColStatus
        '
        Me.btnColStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnColStatus.Location = New System.Drawing.Point(206, 102)
        Me.btnColStatus.Name = "btnColStatus"
        Me.btnColStatus.Size = New System.Drawing.Size(103, 23)
        Me.btnColStatus.TabIndex = 51
        Me.btnColStatus.Text = "active"
        Me.btnColStatus.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(115, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Status :"
        '
        'btnColCancel
        '
        Me.btnColCancel.Location = New System.Drawing.Point(287, 143)
        Me.btnColCancel.Name = "btnColCancel"
        Me.btnColCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnColCancel.TabIndex = 49
        Me.btnColCancel.Text = "Cancel"
        Me.btnColCancel.UseVisualStyleBackColor = True
        '
        'btnColAdd
        '
        Me.btnColAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnColAdd.Location = New System.Drawing.Point(206, 143)
        Me.btnColAdd.Name = "btnColAdd"
        Me.btnColAdd.Size = New System.Drawing.Size(75, 32)
        Me.btnColAdd.TabIndex = 48
        Me.btnColAdd.Text = "Add"
        Me.btnColAdd.UseVisualStyleBackColor = True
        '
        'txtColCode
        '
        Me.txtColCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColCode.Location = New System.Drawing.Point(206, 65)
        Me.txtColCode.MaxLength = 1
        Me.txtColCode.Name = "txtColCode"
        Me.txtColCode.Size = New System.Drawing.Size(156, 22)
        Me.txtColCode.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(84, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 16)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Collection Code :"
        '
        'txtColDesc
        '
        Me.txtColDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColDesc.Location = New System.Drawing.Point(87, 27)
        Me.txtColDesc.Name = "txtColDesc"
        Me.txtColDesc.Size = New System.Drawing.Size(275, 22)
        Me.txtColDesc.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Collection :"
        '
        'frmCollection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 202)
        Me.Controls.Add(Me.btnColStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnColCancel)
        Me.Controls.Add(Me.btnColAdd)
        Me.Controls.Add(Me.txtColCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtColDesc)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCollection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCollection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnColStatus As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnColCancel As Button
    Friend WithEvents btnColAdd As Button
    Friend WithEvents txtColCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtColDesc As TextBox
    Friend WithEvents Label1 As Label
End Class

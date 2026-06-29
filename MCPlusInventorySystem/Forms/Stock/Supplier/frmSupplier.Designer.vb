<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplier
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSupDesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSupCode = New System.Windows.Forms.TextBox()
        Me.txtSupTIN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSupAddr = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSupContact = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSupEmail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSupAdd = New System.Windows.Forms.Button()
        Me.btnSupCancel = New System.Windows.Forms.Button()
        Me.txtPaymentTerms = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Supplier :"
        '
        'txtSupDesc
        '
        Me.txtSupDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupDesc.Location = New System.Drawing.Point(100, 50)
        Me.txtSupDesc.Name = "txtSupDesc"
        Me.txtSupDesc.Size = New System.Drawing.Size(249, 22)
        Me.txtSupDesc.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(97, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Supplier Code :"
        '
        'txtSupCode
        '
        Me.txtSupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupCode.Location = New System.Drawing.Point(202, 85)
        Me.txtSupCode.MaxLength = 2
        Me.txtSupCode.Name = "txtSupCode"
        Me.txtSupCode.Size = New System.Drawing.Size(147, 22)
        Me.txtSupCode.TabIndex = 3
        '
        'txtSupTIN
        '
        Me.txtSupTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupTIN.Location = New System.Drawing.Point(100, 129)
        Me.txtSupTIN.Name = "txtSupTIN"
        Me.txtSupTIN.Size = New System.Drawing.Size(249, 22)
        Me.txtSupTIN.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(48, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "TIN :"
        '
        'txtSupAddr
        '
        Me.txtSupAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupAddr.Location = New System.Drawing.Point(100, 168)
        Me.txtSupAddr.Name = "txtSupAddr"
        Me.txtSupAddr.Size = New System.Drawing.Size(249, 22)
        Me.txtSupAddr.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Address :"
        '
        'txtSupContact
        '
        Me.txtSupContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupContact.Location = New System.Drawing.Point(100, 207)
        Me.txtSupContact.Name = "txtSupContact"
        Me.txtSupContact.Size = New System.Drawing.Size(249, 22)
        Me.txtSupContact.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Contact :"
        '
        'txtSupEmail
        '
        Me.txtSupEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupEmail.Location = New System.Drawing.Point(100, 247)
        Me.txtSupEmail.Name = "txtSupEmail"
        Me.txtSupEmail.Size = New System.Drawing.Size(249, 22)
        Me.txtSupEmail.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(36, 253)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Email :"
        '
        'btnSupAdd
        '
        Me.btnSupAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupAdd.Location = New System.Drawing.Point(193, 345)
        Me.btnSupAdd.Name = "btnSupAdd"
        Me.btnSupAdd.Size = New System.Drawing.Size(75, 32)
        Me.btnSupAdd.TabIndex = 12
        Me.btnSupAdd.Text = "Add"
        Me.btnSupAdd.UseVisualStyleBackColor = True
        '
        'btnSupCancel
        '
        Me.btnSupCancel.Location = New System.Drawing.Point(274, 345)
        Me.btnSupCancel.Name = "btnSupCancel"
        Me.btnSupCancel.Size = New System.Drawing.Size(75, 32)
        Me.btnSupCancel.TabIndex = 13
        Me.btnSupCancel.Text = "Cancel"
        Me.btnSupCancel.UseVisualStyleBackColor = True
        '
        'txtPaymentTerms
        '
        Me.txtPaymentTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaymentTerms.Location = New System.Drawing.Point(220, 295)
        Me.txtPaymentTerms.Name = "txtPaymentTerms"
        Me.txtPaymentTerms.Size = New System.Drawing.Size(129, 22)
        Me.txtPaymentTerms.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(91, 301)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Payment Terms :"
        '
        'frmSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 389)
        Me.Controls.Add(Me.txtPaymentTerms)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnSupCancel)
        Me.Controls.Add(Me.btnSupAdd)
        Me.Controls.Add(Me.txtSupEmail)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSupContact)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSupAddr)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSupTIN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSupCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSupDesc)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSupplier"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Supplier"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtSupDesc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSupCode As TextBox
    Friend WithEvents txtSupTIN As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSupAddr As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSupContact As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSupEmail As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnSupAdd As Button
    Friend WithEvents btnSupCancel As Button
    Friend WithEvents txtPaymentTerms As TextBox
    Friend WithEvents Label7 As Label
End Class

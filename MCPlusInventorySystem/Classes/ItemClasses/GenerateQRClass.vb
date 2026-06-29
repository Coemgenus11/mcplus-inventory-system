Imports System.Drawing.Printing
Imports System.Reflection.Emit
Imports MS.Internal
Imports QRCoder

Public Class GenerateQRClass

    Private Shared qrImage As Bitmap
    Public Shared Function AddTextToQR(qrBitmap As Bitmap, textAbove As String, textBelow As String, textRight As String, textBrand As String, textVariant As String) As Bitmap
        Dim extraHeight As Integer = 80 ' Space for bottom text
        Dim extraWidth As Integer = 330 ' Space for right text
        Dim extraTopHeight As Integer = 90 ' Space for top text
        Dim width As Integer = qrBitmap.Width + extraWidth
        Dim height As Integer = qrBitmap.Height + extraHeight

        Dim finalImage As New Bitmap(width + 350, height + 200)
        Using g As Graphics = Graphics.FromImage(finalImage)
            g.Clear(Color.White)
            g.DrawImage(qrBitmap, 15, 40)

            Dim brush As New SolidBrush(Color.Black)

            ' Draw top text
            Dim fontTop As New Font("Calibri", 63, FontStyle.Bold)
            Dim formatTop As New StringFormat() With {
                .Alignment = StringAlignment.Near,
                .LineAlignment = StringAlignment.Near
            }
            Dim textTopRectangle As New Rectangle(0, 0, 0, extraTopHeight)
            g.DrawString(textAbove, fontTop, brush, textTopRectangle, formatTop)

            ' Draw bottom text SKU
            Dim font1 As New Font("Trebuchet MS", 53, FontStyle.Bold)
            Dim formatBottom As New StringFormat() With {
                .Alignment = StringAlignment.Near,
                .LineAlignment = StringAlignment.Near
            }
            Dim textRectangle As New Rectangle(50, qrBitmap.Height - 15, qrBitmap.Width + 200, extraHeight)
            g.DrawString(textBelow, font1, brush, textRectangle, formatBottom)

            ' Draw right text BRAND
            Dim fontBrand As New Font("Calibri", 75, FontStyle.Bold)
            Dim formatBrand As New StringFormat() With {
                .Alignment = StringAlignment.Near,
                .LineAlignment = StringAlignment.Near
            }
            Dim textBrandRectangle As New Rectangle(qrBitmap.Width + 60, qrBitmap.Height - 30, 0, extraHeight)
            g.DrawString(textBrand, fontBrand, brush, textBrandRectangle, formatBrand)

            ' Draw bottom text VARIANT
            Dim fontVariant As New Font("Calibri", 60, FontStyle.Regular)
            Dim formatVariant As New StringFormat() With {
                .Alignment = StringAlignment.Near,
                .LineAlignment = StringAlignment.Near
            }
            Dim textVariantRectangle As New Rectangle(0, qrBitmap.Height + 50, 1350, 0)
            g.DrawString(textVariant, fontVariant, brush, textVariantRectangle, formatVariant)


            ' Draw right text COMPANY NAME
            Dim font2 As New Font("Arial", 190, FontStyle.Bold)
            Dim formatLeft As New StringFormat() With {
                .Alignment = StringAlignment.Near,
                .LineAlignment = StringAlignment.Near
            }
            Dim textRightRectangle As New Rectangle(qrBitmap.Width - 20, 200, 0, qrBitmap.Height)
            g.DrawString(textRight, font2, brush, textRightRectangle, formatLeft)


            ' TEMPORARY FOR NASUGBU
            'Dim fontBranch As New Font("Arial", 50, FontStyle.Italic)
            'Dim formatBranch As New StringFormat() With {
            '    .Alignment = StringAlignment.Near,
            '    .LineAlignment = StringAlignment.Near
            '}
            'Dim textBranch As New Rectangle(qrBitmap.Width - 15, 150, 0, qrBitmap.Height)
            'g.DrawString("SUB1", fontBranch, brush, textBranch, formatBranch)


        End Using

        Return finalImage
    End Function

    Public Shared Sub PrintLabels(dg As DataGridView, ByVal form As String)
        For Each row As DataGridViewRow In dg.Rows
            Dim isChecked As Boolean = Convert.ToBoolean(row.Cells("sku_selectprint").Value)
            If isChecked Then
                Dim copies As Integer = Convert.ToInt32(row.Cells("no_print").Value)

                ' Generate QR code (as before)
                Dim qrGenerator As New QRCodeGenerator()
                Dim qrData As QRCodeData = qrGenerator.CreateQrCode(row.Cells("sku_link").Value.ToString(), QRCodeGenerator.ECCLevel.Q)
                Dim qrCode As New QRCode(qrData)
                Dim baseImage As Bitmap = qrCode.GetGraphic(15)

                'Dim variation_desc  = get_variation_desc(row.Cells("comp_code").Value.ToString(), row.Cells("item_fam_code").Value.ToString(), row.Cells("item_brand_code").Value.ToString(), row.Cells("item_var_code").Value.ToString())
                Dim printed As Integer = Convert.ToInt32(If(row.Cells("printed").Value, 0))
                Dim noToPrint As Integer = Convert.ToInt32(If(row.Cells("no_print").Value, 0))

                'ORIGINAL 
                qrImage = GenerateQRClass.AddTextToQR(baseImage, row.Cells("sku_type").Value.ToString() + " - " + row.Cells("sku_gender").Value.ToString() + " " + row.Cells("sku_color").Value.ToString(), row.Cells("sku_code").Value.ToString(), get_company_desc(row.Cells("comp_code").Value.ToString()),
                                                           row.Cells("sku_col").Value.ToString(), row.Cells("sku_cat").Value.ToString() + " " + row.Cells("sku_variant").Value.ToString())

                If frmItem.PictureBoxQRCode.IsHandleCreated Then
                    frmItem.PictureBoxQRCode.Invoke(Sub()
                                                        frmItem.PictureBoxQRCode.Image = qrImage
                                                    End Sub)
                End If

                ' Create print document and custom controller
                Dim printDoc As New PrintDocument()
                AddHandler printDoc.PrintPage, AddressOf PrintDocument_PrintPage

                Dim controller As New CancelAwarePrintController()
                Dim uiController As New PrintControllerWithStatusDialog(controller, "Printing Label...")
                printDoc.PrintController = uiController
                printDoc.PrinterSettings.Copies = copies
                printDoc.Print()

                If Not controller.WasPrinted Then
                    MsgBox("Printing was canceled.")
                    Exit For

                ElseIf controller.WasPrinted Then
                    If form = "item" Then  'if form is from item sku module
                        Dim sumPrinted As Integer = printed + noToPrint
                        If update_printed(row.Cells("comp_code").Value.ToString(), row.Cells("sku_code").Value.ToString(), sumPrinted) Then
                            row.Cells("printed").Value = sumPrinted
                            row.Cells("sku_selectprint").Value = False
                            row.Cells("no_print").Value = 1
                        End If

                    ElseIf form = "mpl" Then 'if form is from manual purchase module
                        Dim skuItemPrinted As Integer = Convert.ToInt32(If(row.Cells("skuprinted").Value, 0))
                        Dim sumPrintedItem As Integer = skuItemPrinted + noToPrint
                        Dim sumPrinted As Integer = printed + noToPrint
                        If update_printed_mpl(row.Cells("comp_code").Value.ToString(), row.Cells("mpl_id").Value.ToString(), row.Cells("sku_code").Value.ToString(), sumPrinted) Then
                            row.Cells("printed").Value = sumPrinted
                            row.Cells("sku_selectprint").Value = False
                            row.Cells("no_print").Value = 1
                            row.Cells("skuprinted").Value = sumPrintedItem

                            update_printed(row.Cells("comp_code").Value.ToString(), row.Cells("sku_code").Value.ToString(), sumPrintedItem)
                        End If

                    ElseIf form = "por" Then 'if form is from manual purchase module
                        Dim skuItemPrinted As Integer = Convert.ToInt32(If(row.Cells("skuprinted").Value, 0))
                        Dim sumPrintedItem As Integer = skuItemPrinted + noToPrint
                        Dim sumPrinted As Integer = printed + noToPrint
                        If update_printed_por(row.Cells("comp_code").Value.ToString(), row.Cells("receiving_id").Value.ToString(), row.Cells("po_num").Value.ToString(), row.Cells("sku_code").Value.ToString(), sumPrinted) Then
                            row.Cells("printed").Value = sumPrinted
                            row.Cells("sku_selectprint").Value = False
                            row.Cells("no_print").Value = 1
                            row.Cells("skuprinted").Value = sumPrintedItem

                            update_printed(row.Cells("comp_code").Value.ToString(), row.Cells("sku_code").Value.ToString(), sumPrintedItem)
                        End If
                    End If

                End If
            End If
        Next
    End Sub


    Public Shared Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
        If qrImage IsNot Nothing Then
            Dim printWidth As Integer = 118
            Dim printHeight As Integer = 79
            Dim x As Integer = 0
            Dim y As Integer = (e.PageBounds.Height - printHeight) \ 2
            Dim destRect As New Rectangle(x, y, printWidth, printHeight)

            e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            e.Graphics.DrawImage(qrImage, destRect)

            e.HasMorePages = False
        End If
    End Sub
End Class

Public Class CancelAwarePrintController
    Inherits StandardPrintController

    Public Property WasPrinted As Boolean = False

    Public Overrides Function OnStartPage(document As PrintDocument, e As PrintPageEventArgs) As Graphics
        WasPrinted = True
        Return MyBase.OnStartPage(document, e)
    End Function
End Class


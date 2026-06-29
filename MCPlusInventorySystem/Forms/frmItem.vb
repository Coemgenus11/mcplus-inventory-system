Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Web.UI.WebControls
Imports System.Windows.Controls
Imports Google.Protobuf.WellKnownTypes
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Common
Imports Org.BouncyCastle.Asn1.Cmp
Imports QRCoder


Public Class frmItem
    Dim userLoginComp As String
    Dim compDesc As String
    Private Sub frmModule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.centralAuditDB IsNot "" Then
            userLoginComp = get_user_comp(My.Settings.CurrentUserID)
            compDesc = get_company_desc(userLoginComp)
        End If

    End Sub
    Private Sub tcItemModule_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcItemModule.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor

        Try
            If tcItemModule.SelectedTab.Name = "tpSKU" Then
                SKUClass.show_ItemSKU()
                btnPrint.Enabled = False
            End If

            'If tcItemModule.SelectedTab.Name = "tpCol" Then
            '    CollectionClass.ColCancelOrSave()
            '    CollectionClass.show_collection()
            'End If

            If tcItemModule.SelectedTab.Name = "tpTransaction" Then
                TransactionClass.show_ItemTransactions()
                TransactionClass.load_ItemTransactions_To_frmItem()
            End If

            If tcItemModule.SelectedTab.Name = "tpModules" Then ' Gender
                ColorClass.show_colors()
                CollectionClass.show_collection()
                GenderClass.show_genders()
            End If
            If tcItemModule.SelectedTab.Name = "tpCategory" Then
                StyleCategoryClass.show_weartype()
                StyleCategoryClass.show_types()
                StyleCategoryClass.show_stylecat()
            End If
            If tcItemModule.SelectedTab.Name = "tpParentSKU" Then
                SKUCreationClass.show_parentSKU()
            End If

            'If tcItemModule.SelectedTab.Name = "tpBrand" Then
            '    BrandClass.BrandCancelOrSave()
            '    BrandClass.show_brands()
            'End If

        Finally
            ' Change the cursor back to the default cursor when finished
            Me.Cursor = Cursors.Default
        End Try

    End Sub



    'SKU TAB =================================================================================
    'Print QR BUTTON
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        GenerateQRClass.PrintLabels(dgSKU, "item")
    End Sub
    Private Sub dgSKU_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgSKU.CellValueChanged
        btnPrint.Enabled = dgSKU.Rows.Cast(Of DataGridViewRow)().Any(Function(r) CBool(r.Cells("sku_selectprint").Value))
    End Sub

    Private Sub dgSKU_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgSKU.CurrentCellDirtyStateChanged
        If dgSKU.IsCurrentCellDirty Then dgSKU.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgSKU_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSKU.CellClick

        ' Ensure the click is not on the header row
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgSKU.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgSKU.Rows(e.RowIndex)
            ' Get existing values

            SKUClass.LoadSkuFromRow(dgSKU.Rows(e.RowIndex))
            If columnName = "no_print" Then
                dgSKU.CurrentCell = dgSKU.Rows(e.RowIndex).Cells("no_print")
                dgSKU.BeginEdit(True)

            ElseIf columnName = "sku_code" Then

                Dim valueToCopy As String = dgSKU.Rows(e.RowIndex).Cells("sku_code").Value.ToString()
                Clipboard.SetText(valueToCopy)
                MessageBox.Show("Copied: " & valueToCopy)
            End If
        End If
    End Sub


    Private Sub btnSkuNmi_Click(sender As Object, e As EventArgs) Handles btnSkuNmi.Click
        If dgSKU.Rows.Count = 0 OrElse dgSKU.CurrentRow Is Nothing Then Exit Sub

        If MessageBox.Show("Are you sure you want to update this?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Dim selectedRow As DataGridViewRow = dgSKU.CurrentRow
            Dim isYes As Boolean = (btnSkuNmi.Text = "Yes")

            btnSkuNmi.Text = If(isYes, "No", "Yes")
            selectedRow.Cells("sku_nmicode").Value = btnSkuNmi.Text
            update_NMI(userLoginComp, txtSkuCode.Text, If(isYes, 0, 1))
            SKUClass.cachedItems = Nothing
        End If
    End Sub

    Private Sub btnSkuStatus_Click(sender As Object, e As EventArgs) Handles btnSkuStatus.Click
        If dgSKU.Rows.Count = 0 OrElse dgSKU.CurrentRow Is Nothing Then Exit Sub

        If MessageBox.Show("Are you sure you want to update this?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Dim selectedRow As DataGridViewRow = dgSKU.CurrentRow
            Dim isActive As Boolean = (btnSkuStatus.Text = "active")

            btnSkuStatus.Text = If(isActive, "inactive", "active")
            selectedRow.Cells("sku_status").Value = btnSkuStatus.Text
            update_SkuStatus(userLoginComp, txtSkuCode.Text, If(isActive, 0, 1))
            SKUClass.cachedItems = Nothing
        End If
    End Sub



    'STYLE CATEGORY TAB =========================================================================================================================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnWT.Click
        frmWearType.ShowDialog()
    End Sub

    Private Sub dgWearType_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgWearType.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgWearType.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgWearType.Rows(e.RowIndex)

            ' Get existing values
            Dim compCode As String = selectedRow.Cells("wt_compcode").Value.ToString() ' Company Code
            Dim wearCode As String = selectedRow.Cells("wt_code").Value.ToString()
            Dim wearDesc As String = selectedRow.Cells("wt_desc").Value.ToString()

            'MsgBox("Status Code: " & statusCode)

            If columnName = "wt_edit" Then

                frmWearType.txtWTDesc.Text = wearDesc
                frmWearType.txtWTCode.Text = wearCode
                frmWearType.txtWTCode.Enabled = False
                frmWearType.btnWTAdd.Text = "Update"
                frmWearType.ShowDialog()
            End If
        End If
    End Sub

    Private Sub dgType_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgType.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgType.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgType.Rows(e.RowIndex)

            ' Get existing values
            Dim compCode As String = selectedRow.Cells("type_compcode").Value.ToString() ' Company Code
            Dim typeCode As String = selectedRow.Cells("type_code").Value.ToString()
            Dim typeDesc As String = selectedRow.Cells("type_desc").Value.ToString()

            'MsgBox("Status Code: " & statusCode)

            If columnName = "type_edit" Then

                frmItemType.txtTypeDesc.Text = typeDesc
                frmItemType.txtTypeCode.Text = typeCode
                frmItemType.txtTypeCode.Enabled = False
                frmItemType.btnTypeAdd.Text = "Update"
                frmItemType.ShowDialog()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmItemType.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        StyleCategoryClass.show_stylecat()
        StyleCategoryClass.show_types()
        StyleCategoryClass.show_weartype()
        StyleCategoryClass.LoadCBWear()
        StyleCategoryClass.LoadCBType()
        frmStyleCategory.ShowDialog()
    End Sub

    Private Sub dgStyleCat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStyleCat.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgStyleCat.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgStyleCat.Rows(e.RowIndex)

            ' Get existing values
            Dim compCode As String = selectedRow.Cells("scat_compcode").Value.ToString() ' Company Code
            Dim scatCode As String = selectedRow.Cells("scat_code").Value.ToString()
            Dim scatDesc As String = selectedRow.Cells("scat_desc").Value.ToString()
            Dim scatTypeCode As String = selectedRow.Cells("scat_type_code").Value.ToString()
            Dim scatTypeDesc As String = selectedRow.Cells("scat_itemtype").Value.ToString()
            Dim scatWearCode As String = selectedRow.Cells("scat_wear_code").Value.ToString()
            Dim scatWearDesc As String = selectedRow.Cells("scat_wt").Value.ToString()

            'MsgBox("Status Code: " & statusCode)

            If columnName = "scat_edit" Then
                StyleCategoryClass.show_stylecat()
                StyleCategoryClass.show_types()
                StyleCategoryClass.show_weartype()
                StyleCategoryClass.LoadCBWear()
                StyleCategoryClass.LoadCBType()

                frmStyleCategory.txtSCatDesc.Text = scatDesc
                frmStyleCategory.txtSCatCode.Text = scatCode

                frmStyleCategory.cbType.Text = scatTypeDesc
                frmStyleCategory.lblTypeCode.Text = scatTypeCode

                frmStyleCategory.cbWear.Text = scatWearDesc
                frmStyleCategory.lblWearCode.Text = scatWearCode
                frmStyleCategory.txtSCatCode.Enabled = False
                frmStyleCategory.btnSCatAdd.Text = "Update"
                frmStyleCategory.ShowDialog()

            ElseIf columnName = "scat_view" Then
                txtStyleVarSCDesc.Text = scatDesc
                txtStyleVarSCCode.Text = scatCode
                StyleCategoryClass.show_stylevar()
                StyleCategoryClass.ShowStyleVarByStyleCat(scatCode)
                gbStyleVar.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmStyleVariant.lblSVarSCDesc.Text = txtStyleVarSCDesc.Text
        frmStyleVariant.lblSVarSCCode.Text = txtStyleVarSCCode.Text
        frmStyleVariant.ShowDialog()
    End Sub
    Private Sub dgStyleVar_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStyleVar.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgStyleVar.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgStyleVar.Rows(e.RowIndex)

            ' Get existing values
            Dim compCode As String = selectedRow.Cells("svar_compcode").Value.ToString() ' Company Code
            Dim svarCode As String = selectedRow.Cells("svar_code").Value.ToString()
            Dim svarDesc As String = selectedRow.Cells("svar_desc").Value.ToString()

            Dim svarsSCCode As String = txtStyleVarSCCode.Text.Trim()
            Dim svarSCDesc As String = txtStyleVarSCDesc.Text.Trim()

            'MsgBox("Status Code: " & statusCode)

            If columnName = "svar_edit" Then

                frmStyleVariant.txtSVarDesc.Text = svarDesc
                frmStyleVariant.txtSVarCode.Text = svarCode
                frmStyleVariant.lblSVarSCDesc.Text = svarSCDesc
                frmStyleVariant.lblSVarSCCode.Text = svarsSCCode
                frmStyleVariant.txtSVarCode.Enabled = False
                frmStyleVariant.btnSVarAdd.Text = "Update"
                frmStyleVariant.ShowDialog()
            End If
        End If
    End Sub



    'MODULE TAB ==============================================================================================================
    'GENDER 
    Private Sub btnGender_Click(sender As Object, e As EventArgs) Handles btnGender.Click
        frmGender.ShowDialog()
    End Sub
    Private Sub dgGender_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgGender.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgGender.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgGender.Rows(e.RowIndex)

            ' Get existing values
            Dim compCode As String = selectedRow.Cells("gender_compcode").Value.ToString() ' Company Code
            Dim genderCode As String = selectedRow.Cells("gender_code").Value.ToString()
            Dim genderDesc As String = selectedRow.Cells("gender_desc").Value.ToString()
            Dim genderStatus As String = selectedRow.Cells("gender_status").Value.ToString()

            'MsgBox("Status Code: " & statusCode)

            If columnName = "gender_edit" Then

                frmGender.txtGenderDesc.Text = genderDesc
                frmGender.txtGenderCode.Text = genderCode
                frmGender.btnGenderStatus.Text = genderStatus
                frmGender.txtGenderCode.Enabled = False
                frmGender.btnGenderAdd.Text = "Update"
                frmGender.ShowDialog()
            End If
        End If
    End Sub

    'COLOR  
    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        frmColor.ShowDialog()
    End Sub
    Private Sub dgColor_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgColor.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgColor.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgColor.Rows(e.RowIndex)

            ' Get existing values
            Dim compCode As String = selectedRow.Cells("color_compcode").Value.ToString() ' Company Code
            Dim colorCode As String = selectedRow.Cells("color_code").Value.ToString()
            Dim colorDesc As String = selectedRow.Cells("color_desc").Value.ToString()
            Dim colorStatus As String = selectedRow.Cells("color_status").Value.ToString()

            'MsgBox("Status Code: " & statusCode)

            If columnName = "color_edit" Then

                frmColor.txtColorDesc.Text = colorDesc
                frmColor.txtColorCode.Text = colorCode
                frmColor.btnColorStatus.Text = colorStatus
                frmColor.txtColorCode.Enabled = False
                frmColor.btnColorAdd.Text = "Update"
                frmColor.ShowDialog()
            End If
        End If
    End Sub

    'COLLECTION

    Private Sub btnCol_Click(sender As Object, e As EventArgs) Handles btnCol.Click
        frmCollection.ShowDialog()
    End Sub
    Private Sub dgCol_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCol.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgCol.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgCol.Rows(e.RowIndex)

            ' Get existing values
            Dim compCode As String = selectedRow.Cells("col_compcode").Value.ToString() ' Company Code
            Dim colCode As String = selectedRow.Cells("col_code").Value.ToString()
            Dim colDesc As String = selectedRow.Cells("col_desc").Value.ToString()
            Dim colStatus As String = selectedRow.Cells("col_status").Value.ToString()

            'MsgBox("Status Code: " & statusCode)

            If columnName = "col_edit" Then

                frmCollection.txtColDesc.Text = colDesc
                frmCollection.txtColCode.Text = colCode
                frmCollection.btnColStatus.Text = colStatus
                frmCollection.txtColCode.Enabled = False
                frmCollection.btnColAdd.Text = "Update"
                frmCollection.ShowDialog()
            End If
        End If
    End Sub

    'PARENT SKU CREATION ============================================================================
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        CollectionClass.show_collection()
        ColorClass.show_colors()
        GenderClass.show_genders()
        StyleCategoryClass.show_types()
        StyleCategoryClass.show_weartype()
        StyleCategoryClass.show_stylecat()
        StyleCategoryClass.show_stylevar()

        SKUCreationClass.LoadCBGender()
        SKUCreationClass.LoadCBColor()
        SKUCreationClass.LoadCBCollection()
        SKUCreationClass.LoadCBTypes()
        frmParentSKU.panelParView.SendToBack()
        frmParentSKU.ShowDialog()
    End Sub

    Private Sub dgPar_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPar.CellClick

        If e.RowIndex >= 0 Then
            Dim columnName As String = dgPar.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgPar.Rows(e.RowIndex)

            ' Get existing values
            Dim compCode As String = selectedRow.Cells("par_compcode").Value.ToString() ' Company Code
            Dim parCode As String = selectedRow.Cells("par_code").Value.ToString()
            Dim genCode As String = selectedRow.Cells("par_gen_code").Value.ToString()
            Dim colCode As String = selectedRow.Cells("par_col_code").Value.ToString()
            Dim typeCode As String = selectedRow.Cells("par_type_code").Value.ToString()
            Dim stylecatCode As String = selectedRow.Cells("par_stylecat_code").Value.ToString()
            Dim stylevarCode As String = selectedRow.Cells("par_stylevar_code").Value.ToString()
            Dim colorCode As String = selectedRow.Cells("par_color_code").Value.ToString()

            Dim genDesc As String = selectedRow.Cells("par_gen_desc").Value.ToString()
            Dim colDesc As String = selectedRow.Cells("par_col_desc").Value.ToString()
            Dim typeDesc As String = selectedRow.Cells("par_type_desc").Value.ToString()
            Dim stylecatDesc As String = selectedRow.Cells("par_stylecat_desc").Value.ToString()
            Dim stylevarDesc As String = selectedRow.Cells("par_stylevar_desc").Value.ToString()
            Dim colorDesc As String = selectedRow.Cells("par_color_desc").Value.ToString()

            Dim parStatus As String = selectedRow.Cells("par_status").Value.ToString()


            'MsgBox("Status Code: " & statusCode)

            If columnName = "par_edit" Then

                frmParentSKU.lblParGender.Text = genCode
                frmParentSKU.lblParCol.Text = colCode
                frmParentSKU.lblParType.Text = typeCode
                frmParentSKU.lblParSCat.Text = stylecatCode
                frmParentSKU.lblParSVar.Text = stylevarCode
                frmParentSKU.lblParColor.Text = colorCode

                frmParentSKU.txtParGender.Text = genDesc
                frmParentSKU.txtParCol.Text = colDesc
                frmParentSKU.txtParType.Text = typeDesc
                frmParentSKU.txtParSCat.Text = stylecatDesc
                frmParentSKU.txtParSVar.Text = stylevarDesc
                frmParentSKU.txtParColor.Text = colorDesc

                frmParentSKU.txtParCode.Text = parCode
                frmParentSKU.btnParStatus.Text = parStatus

                frmParentSKU.panelPar.Enabled = False

                frmParentSKU.btnParAdd.Text = "Update"
                frmParentSKU.panelPar.SendToBack()
                frmParentSKU.ShowDialog()

            ElseIf columnName = "par_view" Then
                txtParDesc.Text = genDesc + " " + colDesc + " " + typeDesc + " " + stylecatDesc + " " + stylevarDesc + " " + colorDesc
                txtParCode.Text = parCode
                SKUCreationClass.get_variations()
                SKUCreationClass.show_itemvariant(parCode)
                gbParVar.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmProductVariant.txtParDesc.Text = txtParDesc.Text
        frmProductVariant.txtParCode.Text = txtParCode.Text
        frmProductVariant.ShowDialog()
    End Sub

    Private Sub dgParVar_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgParVar.CellClick
        If e.RowIndex >= 0 Then
            Dim columnName As String = dgParVar.Columns(e.ColumnIndex).Name
            Dim selectedRow As DataGridViewRow = dgParVar.Rows(e.RowIndex)

            ' Get existing values
            Dim compCode As String = selectedRow.Cells("var_compcode").Value.ToString() ' Company Code
            Dim varCode As String = selectedRow.Cells("var_code").Value.ToString()
            Dim varDesc As String = selectedRow.Cells("var_variant").Value.ToString()

            Dim parCode As String = txtParCode.Text.Trim()
            Dim parDesc As String = txtParDesc.Text.Trim()

            'MsgBox("Status Code: " & statusCode)

            If columnName = "var_edit" Then

                frmProductVariant.txtParVarDesc.Text = varDesc
                frmProductVariant.txtParVarCode.Text = varCode
                frmProductVariant.txtParDesc.Text = parDesc
                frmProductVariant.txtParCode.Text = parCode
                frmProductVariant.txtParVarCode.Enabled = False
                frmProductVariant.btnParVarAdd.Text = "Update"
                frmProductVariant.ShowDialog()
            End If
        End If
    End Sub

    Private Sub txtItemSearch_TextChanged(sender As Object, e As EventArgs) Handles txtItemSearch.TextChanged
        SKUClass.skuFilterData(txtItemSearch.Text)
    End Sub

    Private Sub txtParSearch_TextChanged(sender As Object, e As EventArgs) Handles txtParSearch.TextChanged
        SKUCreationClass.parFilterData(txtParSearch.Text)
    End Sub
End Class
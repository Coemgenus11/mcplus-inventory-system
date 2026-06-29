Public Class SKUCreationClass

    Public Shared cachedParentSKU As DataTable = Nothing
    Public Shared cachedVariant As DataTable = Nothing
    Public Shared Sub show_parentSKU(Optional forceRefresh As Boolean = False)

        ' Load from DB if cache is empty or refresh is requested
        If cachedParentSKU Is Nothing OrElse forceRefresh Then
            cachedParentSKU = get_parent_sku(get_user_comp(My.Settings.CurrentUserID))
            frmItem.dgPar.Refresh()
            frmItem.dgPar.Rows.Clear()
            frmMain.dgPar.Refresh()
            frmMain.dgPar.Rows.Clear()

            If cachedParentSKU.Rows.Count > 0 Then
                For Each Row As DataRow In cachedParentSKU.Rows
                    Dim status As String = If(Convert.ToInt32(Row("status")) = 1, "active", "inactive")
                    frmItem.dgPar.Rows.Add(Row("company_code"), Row("parent_sku_code"), Row("gen_code"), Row("col_code"), Row("type_code"), Row("stylecat_code"), Row("stylevar_code"), Row("type_desc"), Row("stylecat_desc"), Row("stylevar_desc"), Row("color_code"), Row("gen_desc"), Row("col_desc"), Row("type_desc") + " " + Row("stylecat_desc") + "-" + Row("stylevar_desc"), Row("color_desc"), status)
                    frmMain.dgPar.Rows.Add(Row("parent_sku_code"), Row("gen_desc") + " " + Row("col_desc") + " - " + Row("type_desc") + " " + Row("stylecat_desc") + " " + Row("stylevar_desc"), Row("color_desc"), status)
                Next
            End If
            get_variations()
        End If
    End Sub
    Public Shared Sub get_variations(Optional forceRefresh As Boolean = False)
        ' Reload if walang cache or pinilit mag refresh
        If cachedVariant Is Nothing OrElse forceRefresh Then
            cachedVariant = get_parentsku_variations(get_user_comp(My.Settings.CurrentUserID))
        End If
    End Sub

    Public Shared Sub show_itemvariant(parent_sku_code As String)

        If cachedVariant Is Nothing Then Exit Sub

        frmItem.dgParVar.Rows.Clear()

        Dim rows = cachedVariant.Select("parent_sku_code = '" & parent_sku_code & "'")

        For Each row As DataRow In rows
            frmItem.dgParVar.Rows.Add(
            row("company_code"),
            row("var_code"),
            row("variant")
        )
        Next
    End Sub

    Public Shared Sub parFilterData(searchText As String)
        If frmItem.dgPar.Rows.Count > 0 Then
            For Each row As DataGridViewRow In frmItem.dgPar.Rows
                If row.Cells("par_code").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("par_gen_desc").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("par_col_desc").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("par_type_cat_desc").Value.ToString().ToLower().Contains(searchText.ToLower()) Or
                    row.Cells("par_color_desc").Value.ToString().ToLower().Contains(searchText.ToLower()) Then
                    row.Visible = True
                Else
                    row.Visible = False
                End If
            Next
        End If
    End Sub

    ' =========================
    ' TYPE COMBOBOX
    ' =========================
    Public Shared Sub LoadCBTypes()
        Try
            Dim table_auth = StyleCategoryClass.cachedTypes

            With frmParentSKU.cbParType
                RemoveHandler .SelectedIndexChanged, AddressOf cbParType_SelectedIndexChanged

                .Items.Clear()
                .DisplayMember = "Key"
                .ValueMember = "Value"

                .Items.Add(New KeyValuePair(Of String, String)("- Select -", ""))

                For Each row As DataRow In table_auth.Rows
                    Dim typeDesc As String = row("type_desc").ToString()
                    Dim typeCode As String = row("type_code").ToString()

                    .Items.Add(New KeyValuePair(Of String, String)(typeDesc, typeCode))
                Next

                .SelectedIndex = 0

                AddHandler .SelectedIndexChanged, AddressOf cbParType_SelectedIndexChanged
            End With

            ' Reset dependent controls
            frmParentSKU.lblParType.Text = "-"
            LoadCBStyleCat("")
            LoadCBStyleVar("")

        Catch ex As Exception
            MsgBox("Error loading Type ComboBox: " & ex.Message)
        End Try
    End Sub

    Private Shared Sub cbParType_SelectedIndexChanged(sender As Object, e As EventArgs)
        If frmParentSKU.cbParType.SelectedItem Is Nothing Then Exit Sub

        Dim selectedItem = CType(frmParentSKU.cbParType.SelectedItem, KeyValuePair(Of String, String))
        Dim typeCode As String = selectedItem.Value

        frmParentSKU.lblParType.Text = If(typeCode = "", "-", typeCode)

        LoadCBStyleCat(typeCode)
        LoadCBStyleVar("") ' reset next level
        GenerateParentSKU()
    End Sub


    ' =========================
    ' STYLE CATEGORY COMBOBOX
    ' =========================
    Public Shared Sub LoadCBStyleCat(Optional typeCode As String = "")

        StyleCategoryClass.show_stylecat()
        Try
            Dim table_auth = StyleCategoryClass.cachedStyleCat

            With frmParentSKU.cbParSCat
                RemoveHandler .SelectedIndexChanged, AddressOf cbParSCat_SelectedIndexChanged

                .Items.Clear()
                .DisplayMember = "Key"
                .ValueMember = "Value"

                .Items.Add(New KeyValuePair(Of String, String)("- Select -", ""))

                If String.IsNullOrEmpty(typeCode) Then
                    .Enabled = False
                Else
                    .Enabled = True

                    For Each row As DataRow In table_auth.Rows
                        If row("type_code").ToString() = typeCode Then
                            Dim scatDesc As String = row("stylecat_desc").ToString()
                            Dim scatCode As String = row("stylecat_code").ToString()

                            .Items.Add(New KeyValuePair(Of String, String)(scatDesc, scatCode))
                        End If
                    Next
                End If

                .SelectedIndex = 0

                AddHandler .SelectedIndexChanged, AddressOf cbParSCat_SelectedIndexChanged
            End With

            frmParentSKU.lblParSCat.Text = "-"
            frmParentSKU.lblParSVar.Text = "-"

        Catch ex As Exception
            MsgBox("Error loading Style Category ComboBox: " & ex.Message)
        End Try
    End Sub

    Private Shared Sub cbParSCat_SelectedIndexChanged(sender As Object, e As EventArgs)
        If frmParentSKU.cbParSCat.SelectedItem Is Nothing Then Exit Sub

        Dim selectedItem = CType(frmParentSKU.cbParSCat.SelectedItem, KeyValuePair(Of String, String))
        Dim scatCode As String = selectedItem.Value

        frmParentSKU.lblParSCat.Text = If(scatCode = "", "-", scatCode)

        LoadCBStyleVar(scatCode)
        GenerateParentSKU()
    End Sub


    ' =========================
    ' STYLE VARIANT COMBOBOX
    ' =========================
    Public Shared Sub LoadCBStyleVar(Optional scatCode As String = "")

        StyleCategoryClass.show_stylevar()
        Try
            Dim table_auth = StyleCategoryClass.cachedStyleVar

            With frmParentSKU.cbParSVar
                RemoveHandler .SelectedIndexChanged, AddressOf cbParSVar_SelectedIndexChanged

                .Items.Clear()
                .DisplayMember = "Key"
                .ValueMember = "Value"

                .Items.Add(New KeyValuePair(Of String, String)("- Select -", ""))

                If String.IsNullOrEmpty(scatCode) Then
                    .Enabled = False
                Else
                    .Enabled = True

                    For Each row As DataRow In table_auth.Rows
                        If row("stylecat_code").ToString() = scatCode Then
                            Dim svarDesc As String = row("stylevar_desc").ToString()
                            Dim svarCode As String = row("stylevar_code").ToString()

                            .Items.Add(New KeyValuePair(Of String, String)(svarDesc, svarCode))
                        End If
                    Next
                End If

                .SelectedIndex = 0

                AddHandler .SelectedIndexChanged, AddressOf cbParSVar_SelectedIndexChanged
            End With

            frmParentSKU.lblParSVar.Text = "-"

        Catch ex As Exception
            MsgBox("Error loading Style Variant ComboBox: " & ex.Message)
        End Try
    End Sub

    Private Shared Sub cbParSVar_SelectedIndexChanged(sender As Object, e As EventArgs)
        If frmParentSKU.cbParSVar.SelectedItem Is Nothing Then Exit Sub

        Dim selectedItem = CType(frmParentSKU.cbParSVar.SelectedItem, KeyValuePair(Of String, String))

        frmParentSKU.lblParSVar.Text = If(selectedItem.Value = "", "-", selectedItem.Value)

        GenerateParentSKU()
    End Sub

    Public Shared Sub LoadCBGender()
        Try
            Dim table_auth = GenderClass.cachedGenders

            With frmParentSKU.cbParGender
                .Items.Clear()
                .DisplayMember = "Key"
                .ValueMember = "Value"

                .Items.Add(New KeyValuePair(Of String, String)("- Select -", ""))

                For Each row As DataRow In table_auth.Rows
                    Dim genderDesc As String = row("gen_desc").ToString()
                    Dim genderCode As String = row("gen_code").ToString()

                    .Items.Add(New KeyValuePair(Of String, String)(genderDesc, genderCode))
                Next

                .SelectedIndex = 0
            End With

            RemoveHandler frmParentSKU.cbParGender.SelectedIndexChanged, Nothing

            AddHandler frmParentSKU.cbParGender.SelectedIndexChanged,
            Sub(sender As Object, e As EventArgs)
                Dim selectedItem = CType(frmParentSKU.cbParGender.SelectedItem, KeyValuePair(Of String, String))
                frmParentSKU.lblParGender.Text = If(selectedItem.Value = "", "-", selectedItem.Value)
                GenerateParentSKU()
            End Sub

        Catch ex As Exception
            MsgBox("Error loading Type ComboBox: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub LoadCBColor()
        Try
            Dim table_auth = ColorClass.cachedColors

            With frmParentSKU.cbParColor
                .Items.Clear()
                .DisplayMember = "Key"
                .ValueMember = "Value"

                .Items.Add(New KeyValuePair(Of String, String)("- Select -", ""))

                For Each row As DataRow In table_auth.Rows
                    Dim colorDesc As String = row("color_desc").ToString()
                    Dim colorCode As String = row("color_code").ToString()

                    .Items.Add(New KeyValuePair(Of String, String)(colorDesc, colorCode))
                Next

                .SelectedIndex = 0
            End With

            RemoveHandler frmParentSKU.cbParColor.SelectedIndexChanged, Nothing

            AddHandler frmParentSKU.cbParColor.SelectedIndexChanged,
            Sub(sender As Object, e As EventArgs)
                Dim selectedItem = CType(frmParentSKU.cbParColor.SelectedItem, KeyValuePair(Of String, String))
                frmParentSKU.lblParColor.Text = If(selectedItem.Value = "", "-", selectedItem.Value)
                GenerateParentSKU()
            End Sub

        Catch ex As Exception
            MsgBox("Error loading Type ComboBox: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub LoadCBCollection()
        Try
            Dim table_auth = CollectionClass.cachedCollections

            With frmParentSKU.cbParCol
                .Items.Clear()
                .DisplayMember = "Key"
                .ValueMember = "Value"

                .Items.Add(New KeyValuePair(Of String, String)("- Select -", ""))

                For Each row As DataRow In table_auth.Rows
                    Dim colDesc As String = row("col_desc").ToString()
                    Dim colCode As String = row("col_code").ToString()

                    .Items.Add(New KeyValuePair(Of String, String)(colDesc, colCode))
                Next

                .SelectedIndex = 0
            End With

            RemoveHandler frmParentSKU.cbParCol.SelectedIndexChanged, Nothing

            AddHandler frmParentSKU.cbParCol.SelectedIndexChanged,
            Sub(sender As Object, e As EventArgs)
                Dim selectedItem = CType(frmParentSKU.cbParCol.SelectedItem, KeyValuePair(Of String, String))
                frmParentSKU.lblParCol.Text = If(selectedItem.Value = "", "-", selectedItem.Value)
                GenerateParentSKU()
            End Sub

        Catch ex As Exception
            MsgBox("Error loading Type ComboBox: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub GenerateParentSKU()
        If frmParentSKU.lblParGender.Text <> "-" AndAlso frmParentSKU.lblParCol.Text <> "-" AndAlso frmParentSKU.lblParType.Text <> "-" AndAlso frmParentSKU.lblParSCat.Text <> "-" AndAlso frmParentSKU.lblParSVar.Text <> "-" AndAlso frmParentSKU.lblParColor.Text <> "-" Then
            frmParentSKU.txtParCode.Text = $"{frmParentSKU.lblParGender.Text}{frmParentSKU.lblParCol.Text}{frmParentSKU.lblParType.Text}{frmParentSKU.lblParSCat.Text}{frmParentSKU.lblParSVar.Text}{frmParentSKU.lblParColor.Text}"
        Else
            frmParentSKU.txtParCode.Text = ""
        End If
    End Sub
End Class

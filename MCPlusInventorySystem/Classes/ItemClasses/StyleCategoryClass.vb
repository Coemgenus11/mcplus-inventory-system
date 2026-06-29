Public Class StyleCategoryClass

    Public Shared cachedWearType As DataTable = Nothing
    Public Shared cachedTypes As DataTable = Nothing
    Public Shared cachedStyleCat As DataTable = Nothing
    Public Shared cachedStyleVar As DataTable = Nothing


    Public Shared Sub show_weartype(Optional forceRefresh As Boolean = False)

        ' Load from DB if cache is empty or refresh is requested
        If cachedWearType Is Nothing OrElse forceRefresh Then
            cachedWearType = get_itemwear(get_user_comp(My.Settings.CurrentUserID))
            frmItem.dgWearType.Refresh()
            frmItem.dgWearType.Rows.Clear()

            If cachedWearType.Rows.Count > 0 Then
                For Each Row As DataRow In cachedWearType.Rows
                    frmItem.dgWearType.Rows.Add(Row("company_code"), Row("wear_code"), Row("wear_desc"))
                Next
            End If
        End If
    End Sub


    Public Shared Sub show_types(Optional forceRefresh As Boolean = False)
        ' Reload if walang cache or pinilit mag refresh
        If cachedTypes Is Nothing OrElse forceRefresh Then
            cachedTypes = get_itemtype(get_user_comp(My.Settings.CurrentUserID))

            If cachedTypes.Rows.Count > 0 Then
                frmItem.dgType.Rows.Clear()

                For Each Row As DataRow In cachedTypes.Rows

                    frmItem.dgType.Rows.Add(
                    Row("company_code"),
                    Row("type_code"),
                    Row("type_desc"))
                Next
            End If
        End If
    End Sub

    Public Shared Sub show_stylecat(Optional forceRefresh As Boolean = False)
        ' Reload if walang cache or pinilit mag refresh
        If cachedStyleCat Is Nothing OrElse forceRefresh Then
            cachedStyleCat = get_stylecat(get_user_comp(My.Settings.CurrentUserID))

            If cachedStyleCat.Rows.Count > 0 Then
                frmItem.dgStyleCat.Rows.Clear()
                frmMain.dgCategory.Rows.Clear()

                For Each Row As DataRow In cachedStyleCat.Rows


                    frmMain.dgCategory.Rows.Add(Row("stylecat_code"), Row("stylecat_desc"), Row("type_desc"))

                    frmItem.dgStyleCat.Rows.Add(
                    Row("company_code"),
                    Row("stylecat_code"),
                    Row("wear_code"),
                    Row("type_code"),
                    Row("stylecat_desc"),
                    Row("wear_desc"),
                    Row("type_desc"))
                Next
            End If
            show_stylevar()
        End If
    End Sub

    Public Shared Sub show_stylevar(Optional forceRefresh As Boolean = False)
        ' Reload if walang cache or pinilit mag refresh
        If cachedStyleVar Is Nothing OrElse forceRefresh Then
            cachedStyleVar = get_itemstylevar(get_user_comp(My.Settings.CurrentUserID))
        End If
    End Sub

    Public Shared Sub ShowStyleVarByStyleCat(styleCatCode As String)

        If cachedStyleVar Is Nothing Then Exit Sub

        frmItem.dgStyleVar.Rows.Clear()

        Dim rows = cachedStyleVar.Select("stylecat_code = '" & styleCatCode & "'")

        For Each row As DataRow In rows
            frmItem.dgStyleVar.Rows.Add(
            row("company_code"),
            row("stylevar_code"),
            row("stylevar_desc")
        )
        Next
    End Sub

    Public Shared Sub LoadCBType()
        Try
            Dim table_auth = cachedTypes

            With frmStyleCategory.cbType
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
            End With

            RemoveHandler frmStyleCategory.cbType.SelectedIndexChanged, Nothing

            AddHandler frmStyleCategory.cbType.SelectedIndexChanged,
            Sub(sender As Object, e As EventArgs)
                Dim selectedItem = CType(frmStyleCategory.cbType.SelectedItem, KeyValuePair(Of String, String))
                frmStyleCategory.lblTypeCode.Text = If(selectedItem.Value = "", "-", selectedItem.Value)
            End Sub

        Catch ex As Exception
            MsgBox("Error loading Type ComboBox: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub LoadCBWear()
        Try
            Dim table_auth = cachedWearType

            With frmStyleCategory.cbWear
                .Items.Clear()
                .DisplayMember = "Key"
                .ValueMember = "Value"

                .Items.Add(New KeyValuePair(Of String, String)("- Select -", ""))

                For Each row As DataRow In table_auth.Rows
                    Dim wearDesc As String = row("wear_desc").ToString()
                    Dim wearCode As String = row("wear_code").ToString()

                    .Items.Add(New KeyValuePair(Of String, String)(wearDesc, wearCode))
                Next

                .SelectedIndex = 0
            End With

            ' ⚠️ Prevent duplicate event handlers
            RemoveHandler frmStyleCategory.cbWear.SelectedIndexChanged, Nothing

            AddHandler frmStyleCategory.cbWear.SelectedIndexChanged,
            Sub(sender As Object, e As EventArgs)
                If frmStyleCategory.cbWear.SelectedItem IsNot Nothing Then
                    Dim selectedItem = CType(frmStyleCategory.cbWear.SelectedItem, KeyValuePair(Of String, String))
                    frmStyleCategory.lblWearCode.Text = If(selectedItem.Value = "", "-", selectedItem.Value)
                End If
            End Sub

        Catch ex As Exception
            MsgBox("Error loading Wear ComboBox: " & ex.Message)
        End Try
    End Sub

End Class

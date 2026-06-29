Public Class TransferClass

    Public Shared Sub LoadTTStoreCB()
        Try
            Dim originalTable As DataTable = get_store(get_user_comp(My.Settings.CurrentUserID))
            If originalTable.Rows.Count = 0 Then Exit Sub

            frmStockOut.txtTTDR.Text = GenerateDR(get_user_comp(My.Settings.CurrentUserID), My.Settings.Store)

            ' Clone the schema and filter out the current store
            Dim table As DataTable = originalTable.Clone()
            For Each row As DataRow In originalTable.Rows
                If row("store_code").ToString() <> My.Settings.Store Then
                    table.ImportRow(row)
                End If
            Next

            ' Add blank row for "no selection"
            Dim newRow As DataRow = table.NewRow()
            newRow("store_code") = ""
            newRow("store_desc") = ""
            table.Rows.InsertAt(newRow, 0)

            ' Bind to ComboBox
            With frmStockOut.cbTTStoreDest
                .DataSource = table
                .DisplayMember = "store_desc" ' What user sees
                .ValueMember = "store_code"   ' What is used internally
                .SelectedIndex = 0
            End With

            AddHandler frmStockOut.cbTTStoreDest.SelectedIndexChanged, Sub()
                                                                           Dim cb = frmStockOut.cbTTStoreDest
                                                                           If cb.SelectedIndex >= 0 Then
                                                                               frmStockOut.lblTTStoreCodeDest.Text = cb.SelectedValue.ToString()
                                                                           Else
                                                                               frmStockOut.lblTTStoreCodeDest.Text = "Store Code"
                                                                           End If
                                                                       End Sub

        Catch ex As Exception
            MsgBox("Error loading suppliers: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Shared Sub itemListSearch(searchText As String, Optional filterStore As String = "")
        If frmStockOut.dgTransferAll.Rows.Count = 0 Then Exit Sub

        searchText = searchText.ToLower()
        filterStore = filterStore.ToLower()

        For Each row As DataGridViewRow In frmStockOut.dgTransferAll.Rows

            Dim matchSearch As Boolean =
            row.Cells("th_drAll").Value.ToString().ToLower().Contains(searchText) Or
            row.Cells("th_orderIDAll").Value.ToString().ToLower().Contains(searchText)

            Dim mathcStore As Boolean = True

            If filterStore <> "" Then
                mathcStore = row.Cells("th_storedestAll").Value.ToString().ToLower() = filterStore
            End If

            row.Visible = matchSearch And mathcStore

        Next
    End Sub
    Public Shared Sub LoadCBStoreAll()
        Try
            Dim table As DataTable = get_store(get_user_comp(My.Settings.CurrentUserID))

            If table.Rows.Count = 0 Then Exit Sub


            Dim tableclone As DataTable = table.Clone()
            For Each row As DataRow In table.Rows
                If row("store_code").ToString() <> My.Settings.Store Then
                    tableclone.ImportRow(row)
                End If
            Next

            Dim newRow As DataRow = tableclone.NewRow()
            newRow("store_code") = ""
            newRow("store_desc") = ""
            tableclone.Rows.InsertAt(newRow, 0)

            With frmStockOut.cbAllStatusStore
                .DataSource = tableclone
                .DisplayMember = "store_desc" ' What user sees
                .ValueMember = "store_code"   ' What is used internally
                .SelectedIndex = 0
            End With

            AddHandler frmStockOut.cbAllStatusStore.SelectedIndexChanged, Sub(sender As Object, e As EventArgs)
                                                                              Dim cb = frmStockOut.cbAllStatusStore

                                                                              If cb.SelectedValue IsNot Nothing Then
                                                                                  frmStockOut.lblTTStoreCodeDestAll.Text = cb.SelectedValue.ToString()
                                                                              Else
                                                                                  frmStockOut.lblTTStoreCodeDestAll.Text = ""
                                                                              End If

                                                                              itemListSearch(frmStockOut.txtAllStatusFind.Text, frmStockOut.lblTTStoreCodeDestAll.Text)
                                                                          End Sub
        Catch ex As Exception
            MsgBox("Error loading collection list: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class

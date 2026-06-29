Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives

Public Class TransactionClass


    Public Shared cachedItemTransactions As DataTable = Nothing

    Public Shared Sub show_ItemTransactions(Optional forceRefresh As Boolean = False)

        If cachedItemTransactions Is Nothing OrElse forceRefresh Then
            cachedItemTransactions = get_item_transactions(
            get_user_comp(My.Settings.CurrentUserID),
            My.Settings.Store
        )
        End If

        If cachedItemTransactions Is Nothing Then Exit Sub

        ' Main grid always update
        frmMain.dgTrans.Rows.Clear()

        For Each row As DataRow In cachedItemTransactions.Rows
            frmMain.dgTrans.Rows.Add(
            row("iditemmvt"),
            row("sku_code"),
            row("mvt_code"),
            row("location"),
            row("item_qty")
        )
        Next
    End Sub
    Public Shared Sub load_ItemTransactions_To_frmItem()

        If cachedItemTransactions Is Nothing Then Exit Sub

        frmItem.dgTrans.Rows.Clear()

        For Each row As DataRow In cachedItemTransactions.Rows

            Dim originInfo As String = $"{row("origin")} ({row("itemloc_origin")})"
            Dim destInfo As String = $"{row("destination")} ({row("itemloc_dest")})"
            Dim movement As String = $"{originInfo} to {destInfo}"

            Dim dateTimeInfo As String = ""

            If Not IsDBNull(row("create_date")) Then
                Dim dt As DateTime = CDate(row("create_date"))

                If Not IsDBNull(row("create_time")) Then
                    Dim timeStr As String = row("create_time").ToString()
                    dateTimeInfo = $"{dt:dd/MM/yyyy} {timeStr}"
                Else
                    dateTimeInfo = dt.ToString("dd/MM/yyyy")
                End If
            End If
            frmItem.dgTrans.Rows.Add(
                row("iditemmvt"),
                row("doc_no"),
                row("sku_code"),
                row("gen_desc") + " " + row("col_desc") + " " + row("type_desc") + " " + row("stylecat_desc") + " " + row("stylevar_desc"),
                row("color_desc"),
                row("variant"),
                movement,
                row("mvt_code"),
                row("location"),
                row("item_qty"),
                dateTimeInfo,
                row("create_by")
            )

        Next

    End Sub

End Class

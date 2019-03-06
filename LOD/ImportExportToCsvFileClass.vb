Imports System.IO

Public Class ImportExportToCsvFileClass
    Inherits LogOfDestinyWindow

    Friend Sub ExportToCsv(ByVal strExportFileName As String, _
                           ByVal DataGridView As DataGridView, _
                           Optional ByVal blnWriteColumnHeaderNames As Boolean = False, _
                           Optional ByVal strDelimiterType As String = ",")

        Dim thisStreamWriter As StreamWriter = File.CreateText(strExportFileName)
        Dim strDelimiter As String = strDelimiterType
        Dim intColumnCount As Integer = DataGridView.Columns.Count - 1
        Dim strRowData As String = ""
        Dim saveIntX, saveIntRowData As Integer

        thisStreamWriter.WriteLine(currentConfig)
        thisStreamWriter.WriteLine(LogEntryClass.exerciseIsRunning.ToString)

        If blnWriteColumnHeaderNames Then

            For intX As Integer = 0 To intColumnCount

                saveIntX = intX

                strRowData += Replace(DataGridView.Columns(intX).Name, strDelimiter, "") & _
                    IIf(intX < intColumnCount, strDelimiter, "")

            Next intX

            thisStreamWriter.WriteLine(strRowData)

        End If

        Try

            For intX As Integer = 0 To DataGridView.Rows.Count - 1

                saveIntX = intX

                strRowData = ""

                For intRowData As Integer = 0 To intColumnCount

                    saveIntRowData = intRowData

                    strRowData += Replace(DataGridView.Rows(intX).Cells(intRowData).Value, strDelimiter, "") & _
                        IIf(intRowData < intColumnCount, strDelimiter, "") '''''''''highlights this row

                Next intRowData

                thisStreamWriter.WriteLine(strRowData)

            Next intX

        Catch ex As Exception

            MsgBox(ex.Message & "  Row =  " & saveIntX + 1 & "  Column  = " & saveIntRowData + 1 & _
                   ".  LOD suggests that you edit or delete that ROW immediately to prevent additional errors.  The line in question reads as follows: " & _
                   strRowData)

        End Try

        thisStreamWriter.Close()

    End Sub



End Class

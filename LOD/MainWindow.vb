Option Explicit On
Imports System.IO
Imports System.Net.Sockets

Public Class MainWindow

    Dim Client As TcpClient

    Dim thisConfig As String
    Dim thisFileName As String
    Public Shared OpenFromExistingFile As Boolean = False

    Private Sub LaunchLODbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaunchLODbutton.Click

        'Debug.Print("LaunchLODbutton_Click")

        LodFormThread.RunWorkerAsync()

        'Debug.Print("After LodFormThread.RunAsync")

        SendConfigToLodWindow()

        SendFileNameToLodWindow()

    End Sub

    Private Sub LodFormThread_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles LodFormThread.DoWork

        Debug.Print("Enter LodFormThread_DoWork")

        Dim LogOfDestinyWindow1 = New LogOfDestinyWindow
        Debug.Print("DIM LOD Window complete")

        Debug.Print("Starting App")
        Application.Run(LogOfDestinyWindow1)
        Debug.Print("App started")

        Debug.Print("DIM and Application.Run of LOD Window")

        'ConfigurationFileOperationsClass.ReadConfigFile()

        Debug.Print("Exiting LodFormThread_DoWork")

    End Sub

    Private Sub MetricsThread_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles MetricsThread.DoWork

        'Dim MetricsWindow1 As New MetricsWindow

        Application.Run(New MetricsWindow)
        'Application.Run(MetricsWindow1)

    End Sub

    Private Sub CountdownClockThread_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles CountdownClockThread.DoWork

        Application.Run(New CountdownTimerWindow)
        'Application.Run(New MetricsWindow)

    End Sub

    Private Sub HistoricDataThread_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles HistoricDataThread.DoWork

    End Sub

    Private Sub LaunchMetricsWindowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaunchMetricsWindowButton.Click

        'If MetricsThread IsNot Nothing Then

        '    MsgBox("MetricsThread exists")

        'Else : MsgBox("MetricsThread does not exist")

        'End If


        MetricsThread.RunWorkerAsync()

    End Sub

    Private Sub isBL9A_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isBL9A.Click

        thisConfig = "isBL9A"

        'Debug.Print("isBL9A_checked:: " & thisConfig)

    End Sub

    Private Sub isBL9C_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isBL9C.Click

        thisConfig = "isBL9C"

        'Debug.Print("isBL9C_checked:: " & thisConfig)

    End Sub

    Private Sub isBL9D_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isBL9D.Click

        thisConfig = "isBL9D"

        'Debug.Print("isBL9D_checked:: " & thisConfig)

    End Sub

    Private Sub isBL9E_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isBL9E.Click

        thisConfig = "isBL9E"

        'Debug.Print("isBL9E_checked:: " & thisConfig)

    End Sub

    Private Sub isJ6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isJ6.Click

        thisConfig = "isJ6"

        'Debug.Print("isJ6_checked:: " & thisConfig)

    End Sub

    Private Sub isAWD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isAWD.Click

        thisConfig = "isAWD"

        'Debug.Print("isAWD_checked:: " & thisConfig)

    End Sub

    Private Sub SendConfigToLodWindow()

        Debug.Print("Enter SendConfigToLodWindow")

        Try
            Dim thisClientComplete As Boolean = False

            While thisClientComplete = False
                Debug.Print("Creating new sendconfig client")
                Client = New TcpClient("127.0.0.1", 8000)
                Debug.Print("TCPClient created")
                thisClientComplete = True
            End While

            Debug.Print("Creating writer")
            Dim Writer As New StreamWriter(Client.GetStream())
            Debug.Print("Writer init complete")

            Debug.Print("Sending config")
            Writer.Write("MT002 " & thisConfig & "<\>")
            Debug.Print("Config Sent")

            Writer.Flush()
            Debug.Print("Flushed")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Debug.Print("Exiting SendConfigToLodWindow")

    End Sub

    Private Sub SendFileNameToLodWindow()

        Debug.Print("Entering SendFileNameToLodWindow")

        Try
            Debug.Print("Creating new client")
            Client = New TcpClient("127.0.0.1", 8000)
            Debug.Print("Filename Client created")

            Debug.Print("Creating new writer")
            Dim Writer As New StreamWriter(Client.GetStream())
            Debug.Print("Writer created")

            Debug.Print("Sending filename")
            Writer.Write("MT001 " & thisFileName & "<\>")
            Debug.Print("Filename sent")

            Writer.Flush()
            Debug.Print("Flushed filename")

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        Debug.Print("exiting send filename")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ''Test to send configuration to LOD
        'Try
        '    Client = New TcpClient("127.0.0.1", 8000)
        '    Dim Writer As New StreamWriter(Client.GetStream())
        '    Writer.Write("</> " & thisConfig & "<\>")
        '    Writer.Flush()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        ''END Test to send configuration to LOD

    End Sub

    Private Sub OutputFileNameBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OutputFileNameBox.TextChanged

        thisFileName = OutputFileNameBox.Text

    End Sub

    Private Sub OpenFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFileButton.Click

        'Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "C:\Documents and Settings\ktooley\My Documents\"
        'openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
        openFileDialog1.Filter = "csv files (*.csv)|*.csv"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(openFileDialog1.FileName)

            TextFileReader.TextFieldType = FileIO.FieldType.Delimited
            'TextFileReader.SetDelimiters(";")
            TextFileReader.SetDelimiters(",")

            Dim dataField As String()

            While Not TextFileReader.EndOfData

                Try

                    dataField = TextFileReader.ReadFields()
                    'Debug.Print(dataField(0).ToString)
                    thisConfig = dataField(0)
                    Debug.Print(thisConfig)
                    Exit While

                Catch ex As Exception

                End Try

            End While

            'TextFileTable = Nothing

            'Dim Column As DataColumn
            'Dim Row As DataRow
            'Dim UpperBound As Int32
            'Dim ColumnCount As Int32
            'Dim CurrentRow As String()

            'While Not TextFileReader.EndOfData
            '    Try
            '        CurrentRow = TextFileReader.ReadFields()
            '        If Not CurrentRow Is Nothing Then
            '            'Check if DataTable has been created
            '            If TextFileTable Is Nothing Then
            '                TextFileTable = New DataTable("TextFileTable")
            '                'Get number of columns
            '                UpperBound = CurrentRow.GetUpperBound(0)
            '                'Create new DataTable
            '                For ColumnCount = 0 To UpperBound
            '                    Column = New DataColumn()
            '                    Column.DataType = System.Type.GetType("System.String")
            '                    Column.ColumnName = "Column" & ColumnCount
            '                    Column.Caption = "Column" & ColumnCount
            '                    Column.ReadOnly = True
            '                    Column.Unique = False
            '                    TextFileTable.Columns.Add(Column)
            '                Next
            '            End If
            '            Row = TextFileTable.NewRow
            '            For ColumnCount = 0 To UpperBound
            '                Row("Column" & ColumnCount) = CurrentRow(ColumnCount).ToString
            '            Next
            '            TextFileTable.Rows.Add(Row)
            '        End If
            '    Catch ex As  _
            '    Microsoft.VisualBasic.FileIO.MalformedLineException
            '        MsgBox("Line " & ex.Message & _
            '        "is not valid and will be skipped.")
            '    End Try
            'End While
            'TextFileReader.Dispose()
            'Form1.DataGridView1.DataSource = TextFileTable

            thisFileName = openFileDialog1.FileName
            OpenFromExistingFile = True

            LodFormThread.RunWorkerAsync()

            SendConfigToLodWindow()

            SendFileNameToLodWindow()

        End If

    End Sub

    Private Sub OutputFileNameTextbox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'thisFileName = OutputFileNameBox2.Text

    End Sub

End Class

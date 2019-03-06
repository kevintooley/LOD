'Developer:  Kevin Tooley
'   Changes:
'   25FEB2014:  Issue_2:  Add MsgBox for .NET framework limitation
'   25FEB2014:  Issue_9:  Add flag for TOR NEEDED
'   26FEB2014:  Issue_12:  Remove redundant GroupBox Name
'   26FEB2014:  Issue_11:  Add 'Set All to UP' button
'   26FEB2014:  Issue_14:  Manual Time Entry defaults to DateandTime.Now
'   26FEB2014:  Issue_20:  UP or DOWN text entry causes change in background
'   27FEB2014:  Issue_30:  Create CSV in MyDocuments folder
'   27FEB2014:  Issue_26:  ElementLabel is cut off
'   28FEB2014:  Issue_22:  Add C: and path to file label
'   26MAR2014:  Issue_35:  Reorder Cell Formating logic in dataGridView_CellFormatting

Option Explicit On
Imports System.IO
Imports System.Net.Sockets

Public Class LogOfDestinyWindow

    Dim Listener As New TcpListener(8000)
    Dim Client As New TcpClient

    Public Shared elementArray() As ElementClass
    Friend Shared elementXmlDataArray(1, 4)

    Public Shared TextFileTable As DataTable = Nothing

    Friend Shared currentConfig As String
    Friend Shared thisFileName As String
    Friend configIsSet As Boolean = False
    Friend controlsAreSet As Boolean = False
    Friend formDataTableIsSet As Boolean = False

    Friend Shared manualTime As Date
    Friend Shared isManualTimeEntry As Boolean

    Dim TestGroupBox As GroupBox
    Dim TestGroupBox1 As GroupBox

    Friend Shared TorNeeded As Boolean = False

    Public Event CellFormatting As DataGridViewCellFormattingEventHandler

    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
                                             ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

        Try

            If e.Value IsNot Nothing Then

                Dim stringValue As String = CType(e.Value, String)

                stringValue = stringValue.ToLower()

                '' Issue_35 BEGIN Issue_9 END 
                If ((stringValue.IndexOf("tor needed") > -1)) Then

                    e.CellStyle.ForeColor = Color.Red                           '' Issue_9 END Issue_35 END

                ElseIf ((stringValue.IndexOf("up") > -1)) Then                  '' Issue_35

                    If e.ColumnIndex > 2 Then                                   '' Issue_20

                        e.CellStyle.BackColor = Color.Green

                    End If                                                      '' Issue_20

                ElseIf ((stringValue.IndexOf("dgrd") > -1)) Then

                    If e.ColumnIndex > 2 Then                                   '' Issue_20

                        e.CellStyle.BackColor = Color.Yellow

                    End If                                                      '' Issue_20

                ElseIf ((stringValue.IndexOf("down") > -1)) Then

                    If e.ColumnIndex > 2 Then                                   '' Issue_20

                        e.CellStyle.BackColor = Color.Red

                    End If                                                      '' Issue_20

                    '' Issue_35 BEGIN Issue_9 BEGIN
                    'ElseIf ((stringValue.IndexOf("tor needed") > -1)) Then

                    '    e.CellStyle.ForeColor = Color.Red                   '' Issue_9 END Issue_35 END

                End If

            End If

        Catch ex As Exception

            'MsgBox("You selected an invalid cell, try again: " & ex.Message)

            DataGridView1.CancelEdit()

        End Try

    End Sub

    Sub setupFormDataTable()

        While formDataTableIsSet = False

            If MainWindow.OpenFromExistingFile = False Then

                Dim Column As DataColumn
                'Dim Row As DataRow
                Dim UpperBound As Integer = elementArray.Length
                Debug.Print(elementArray.Length)
                'Dim UpperBound As Integer = 5

                Dim ColumnCount As Integer
                'Dim CurrentRow As String()

                If TextFileTable Is Nothing Then

                    TextFileTable = New DataTable("TextFileTable")

                    For ColumnCount = 0 To UpperBound + 2
                        Column = New DataColumn()
                        Column.DataType = System.Type.GetType("System.String")
                        If ColumnCount = 0 Then
                            Column.ColumnName = "GMT"
                            Column.Caption = "GMT"
                        ElseIf ColumnCount = 1 Then
                            Column.ColumnName = "Local"
                            Column.Caption = "Local"
                        ElseIf ColumnCount = 2 Then
                            Column.ColumnName = "Log Entry"
                            Column.Caption = "Log Entry"
                        Else
                            Column.ColumnName = elementArray(ColumnCount - 3).getName()
                            Column.Caption = elementArray(ColumnCount - 3).getName()
                        End If

                        'Column.ColumnName = "Column" & ColumnCount
                        'Column.Caption = "Column" & ColumnCount

                        Column.ReadOnly = False
                        Column.Unique = False
                        TextFileTable.Columns.Add(Column)
                    Next

                End If

                DataGridView1.DataSource = TextFileTable

                'DataGridView1.Columns("ADS").Width = 60

                For Each formColumn As DataGridViewColumn In DataGridView1.Columns

                    formColumn.Width = 60

                Next

                DataGridView1.Columns("GMT").Width = 150
                DataGridView1.Columns("Local").Width = 150
                DataGridView1.Columns("Log Entry").Width = 300
                'dtRows.DefaultView.Sort = "date ASC"
                DataGridView1.Sort(DataGridView1.Columns("GMT"), System.ComponentModel.ListSortDirection.Ascending)

            Else

                Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(thisFileName)
                Dim inputFileLineNumber As Integer = 3

                TextFileReader.TextFieldType = FileIO.FieldType.Delimited
                TextFileReader.SetDelimiters(",")

                TextFileTable = Nothing

                Dim Column As DataColumn
                Dim Row As DataRow
                Dim UpperBound As Int32
                Dim ColumnCount As Int32
                Dim CurrentRow As String()

                While Not TextFileReader.EndOfData
                    Try
                        CurrentRow = TextFileReader.ReadFields()
                        If Not CurrentRow Is Nothing Then
                            'Check if DataTable has been created
                            If TextFileTable Is Nothing Then
                                TextFileTable = New DataTable("TextFileTable")

                            Else

                                'Get number of columns
                                UpperBound = CurrentRow.Length - 1

                                If UpperBound > 0 Then

                                    For ColumnCount = 0 To UpperBound

                                        If inputFileLineNumber = 3 Then

                                            Column = New DataColumn()
                                            Column.DataType = System.Type.GetType("System.String")
                                            If ColumnCount = 0 Then
                                                Column.ColumnName = "GMT"
                                                Column.Caption = "GMT"
                                            ElseIf ColumnCount = 1 Then
                                                Column.ColumnName = "Local"
                                                Column.Caption = "Local"
                                            ElseIf ColumnCount = 2 Then
                                                Column.ColumnName = "Log Entry"
                                                Column.Caption = "Log Entry"
                                            Else
                                                Column.ColumnName = elementArray(ColumnCount - 3).getName()
                                                Column.Caption = elementArray(ColumnCount - 3).getName()

                                            End If
                                            Column.ReadOnly = False
                                            Column.Unique = False
                                            TextFileTable.Columns.Add(Column)

                                            'inputFileLineNumber += 1

                                        ElseIf inputFileLineNumber > 3 Then

                                            Row = TextFileTable.NewRow

                                            Dim completingNewRow As Boolean = True

                                            While completingNewRow = True

                                                Row(ColumnCount) = CurrentRow(ColumnCount).ToString

                                                If ColumnCount < UpperBound Then

                                                    ColumnCount += 1

                                                Else

                                                    completingNewRow = False

                                                End If

                                            End While

                                            TextFileTable.Rows.Add(Row)

                                        End If

                                    Next

                                    inputFileLineNumber += 1

                                End If
                            End If
                        End If

                    Catch ex As  _
                    Microsoft.VisualBasic.FileIO.MalformedLineException
                        MsgBox("Line " & ex.Message & _
                        "is not valid and will be skipped.")
                    End Try
                End While

                DataGridView1.DataSource = TextFileTable

                For Each formColumn As DataGridViewColumn In DataGridView1.Columns

                    formColumn.Width = 60

                Next

                DataGridView1.Columns("GMT").Width = 150
                DataGridView1.Columns("Local").Width = 150
                DataGridView1.Columns("Log Entry").Width = 300
                'dtRows.DefaultView.Sort = "date ASC"
                DataGridView1.Sort(DataGridView1.Columns("GMT"), System.ComponentModel.ListSortDirection.Ascending)

                TextFileReader.Dispose()
                DataGridView1.DataSource = TextFileTable

            End If

            formDataTableIsSet = True

        End While

    End Sub

    '' Issue_11 BEGIN
    Private Sub SetAllToUpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetAllToUpButton.Click

        For Each element As ElementClass In elementArray

            element.elementStatusBox.SelectedIndex = 1

        Next

    End Sub                                                             '' Issue_11 END

    Private Sub LogOfDestinyWindow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Listener.Stop()

    End Sub

    Private Sub LogOfDestinyWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Debug.Print("LogOfDestinyWindow_Load called")

        ConfigurationMessageTimer.Start()

        Listener.Start()

        ConfigBackgroundWorker.RunWorkerAsync()

        FormLoadTimer.Start()

        AutoSaveTimer.Start()

    End Sub

    Private Sub ConfigurationMessageTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConfigurationMessageTimer.Tick

        Debug.Print("Starting ConfigMessageTimer_tick")

        Dim Message As String
        'Dim MT001Message As String
        Dim nStart As Integer
        Dim nLast As Integer
        If Listener.Pending = True Then

            Debug.Print("Message pending...")

            Message = ""
            'MT002Message = ""
            Client = Listener.AcceptTcpClient()
            Dim Reader As New StreamReader(Client.GetStream())
            While Reader.Peek > -1
                Message &= Convert.ToChar(Reader.Read()).ToString
            End While
            If Message.Contains("MT002") Then

                'nStart = InStr(Message, "</>") + 6
                'nLast = InStr(Message, "<\>")
                'Message = Mid(Message, nStart, nLast - nStart)

                nStart = InStr(Message, "MT002") + 6
                nLast = InStr(Message, "<\>")
                Message = Mid(Message, nStart, nLast - nStart)
                currentConfig = Message

            ElseIf Message.Contains("MT001") Then

                nStart = InStr(Message, "MT001") + 6
                nLast = InStr(Message, "<\>")
                Message = Mid(Message, nStart, nLast - nStart)
                Label1.Text = Message
                thisFileName = Message

            End If

            'Label1.Text = Message
            'currentConfig = Message

            Debug.Print("***currentConfig: " & currentConfig)

            If currentConfig = "" Then

                configIsSet = False

            Else : configIsSet = True

            End If

        End If

    End Sub

    Private Sub LogEntryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogEntryButton.Click

        If ManualTimeEntryBox.CustomFormat = " " Then

            LogEntryTextBox.Text = LogEntryClass.EnterButtonClick(LogEntryTextBox.Text)

        Else

            manualTime = ManualTimeEntryBox.Value
            isManualTimeEntry = True
            LogEntryTextBox.Text = LogEntryClass.EnterButtonClick(manualTime, LogEntryTextBox.Text)
            'ManualTimeEntryBox.Value = "01/01/2013 00:00:00"
            'manualTime = Nothing

        End If

        ManualTimeEntryBox.Format = Windows.Forms.DateTimePickerFormat.Custom
        ManualTimeEntryBox.CustomFormat = " "
        manualTime = Nothing

        isManualTimeEntry = False

        TorNeededCheckbox.CheckState = 0            '' Issue_9

        'Label1.Text = thisFileName

    End Sub

    Sub ConfigureElementControls()

        While controlsAreSet = False

            For i = 0 To elementArray.Count - 1

                Dim myTab As Integer
                Dim myBoxRow As Integer
                Dim myBoxColumn As Integer
                Dim myName = elementArray(i).getName()
                'Debug.Print("myName: " & myName)
                'Debug.Print("elementArray(" & i & ").getName(): " & elementArray(i).getName())

                myTab = elementArray(i).getElementTab()
                myBoxRow = elementArray(i).getElementRow()
                myBoxColumn = elementArray(i).getElementColumn()

                elementArray(i).elementGroupBox.Location = New Point(myBoxColumn, myBoxRow)
                'elementArray(i).elementGroupBox.Size = New Size(149, 42)
                elementArray(i).elementGroupBox.Size = New Size(190, 60)
                'elementArray(i).elementGroupBox.Text = myName                                  '' Issue_12
                If myTab = 2 Then

                    ConsoleGroupBox.Controls.Add(elementArray(i).elementGroupBox)

                Else : ShipElementsGroupBox.Controls.Add(elementArray(i).elementGroupBox)

                End If

                'elementArray(i).elementLabel.Location = New Point(7, 20)                       '' Issue_26
                elementArray(i).elementLabel.Location = New Point(4, 20)                        '' Issue_26
                'elementArray(i).elementLabel.Size = New Size(39, 13)                           '' Issue_26
                'elementArray(i).elementLabel.Size = New Size(48, 13)                            '' Issue_26
                elementArray(i).elementLabel.Size = New Size(70, 17) '9/29/2017
                elementArray(i).elementLabel.Text = myName
                elementArray(i).elementGroupBox.Controls.Add(elementArray(i).elementLabel)

                'elementArray(i).elementStatusBox.Location = New Point(52, 17)
                elementArray(i).elementStatusBox.Location = New Point(75, 17) '9/29/2017
                'elementArray(i).elementStatusBox.Size = New Size(70, 21)
                elementArray(i).elementStatusBox.Size = New Size(80, 21) '9/29/2017
                elementArray(i).elementStatusBox.DataSource = System.Enum.GetValues(GetType(ElementStatusClass.StatusEnumeration))
                elementArray(i).elementGroupBox.Controls.Add(elementArray(i).elementStatusBox)

                If elementArray(i).isComposite = True Then

                    'elementArray(i).elementIsOverride.Location = New Point(128, 19)
                    elementArray(i).elementIsOverride.Location = New Point(160, 19) '9/29/2017
                    elementArray(i).elementIsOverride.Size = New Size(15, 14)
                    elementArray(i).elementIsOverride.Text = ""
                    elementArray(i).elementGroupBox.Controls.Add(elementArray(i).elementIsOverride)

                End If

            Next

            controlsAreSet = True

        End While

    End Sub

    Private Sub FormLoadTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormLoadTimer.Tick

        ConfigureElementControls()

        setupFormDataTable()

        'While configIsSet = False

        If configIsSet = True Then

            FormLoadTimer.Stop()

        End If

        'End While

        'FormLoadTimer.Stop()

        MsgBox("Due to a .NET framework bug, please confirm that the both the Element Tab and and Console Tab loaded correctly.  If the pages did not load correctly, restart the LOD.")        '' Issue_2

    End Sub

    Private Sub ConfigBackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConfigBackgroundWorker.DoWork

        Dim x = False

        While x = False

            If configIsSet = False Then

                Debug.Print("Waiting for config from MainWindow")

            ElseIf configIsSet = True Then

                Dim ConfigurationFileOperationsClass1 = New ConfigurationFileOperationsClass
                ConfigurationFileOperationsClass1.PopulateElementXmlArray()

                Debug.Print("elementArray(0).getName: " & elementArray(0).getName)
                Debug.Print("elementArray(1).getName: " & elementArray(1).getName)

                'ConfigureElementControls()

                'setupFormDataTable()

                x = True

            End If

        End While

    End Sub

    Private Sub AutoSaveTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSaveTimer.Tick

        'ImportExportToCsvFileClass.ExportToCsv("C:\Test.csv", DataGridView1, blnWriteColumnHeaderNames:=True)
        AutoSaveBackgroundWorker.RunWorkerAsync()

    End Sub

    Public Sub AutoSaveBackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles AutoSaveBackgroundWorker.DoWork

        Debug.Print("AutoSave started: " & Date.Now.ToString("HH:mm:ss"))

        If thisFileName.StartsWith("C:") Then

            If DataGridView1 Is DBNull.Value Then
                MsgBox("IT IS NULL")
            End If

            ImportExportToCsvFileClass.ExportToCsv(thisFileName, DataGridView1, blnWriteColumnHeaderNames:=True)

        Else 'ImportExportToCsvFileClass.ExportToCsv("C:\" & thisFileName & ".csv", DataGridView1, blnWriteColumnHeaderNames:=True)         '' Issue_30

            'My.Computer.FileSystem.CreateDirectory("%userprofile%\Documents")                                                              '' Issue_30
            thisFileName = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, thisFileName & ".csv")             '' Issue_30
            'MsgBox("Saving file to: " & thisFileName)
            ImportExportToCsvFileClass.ExportToCsv(thisFileName, DataGridView1, blnWriteColumnHeaderNames:=True)                            '' Issue_30

            SetText(thisFileName)                   '' Issue_22


        End If

    End Sub

    Private Sub StartBreakButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartBreakButton.Click

        'If Not (Me.ToDateField.CustomFormat = " ") Then 
        'Code here to add to my SQL statement 
        'End If

        If ManualTimeEntryBox.CustomFormat = " " Then

            StartBreakButton.Text = LogEntryClass.StartBreakButtonClick()

        Else

            manualTime = ManualTimeEntryBox.Value
            isManualTimeEntry = True
            StartBreakButton.Text = LogEntryClass.StartBreakButtonClick()

        End If

        LogEntryTextBox.Text = ""
        ManualTimeEntryBox.Format = Windows.Forms.DateTimePickerFormat.Custom
        ManualTimeEntryBox.CustomFormat = " "
        manualTime = Nothing

    End Sub

    Private Sub ExerciseCompleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExerciseCompleteButton.Click

        'display message on form closing
        Dim Result As DialogResult
        Result = MessageBox.Show("Do you wish to finish this log?", "Complete log?", MessageBoxButtons.YesNo)

        'if user clicked no, cancel form closing
        If Result = System.Windows.Forms.DialogResult.No Then
            'e.Cancel = True

        Else

            'LogEntryClass.CompleteExercise()
            If ManualTimeEntryBox.CustomFormat = " " Then

                LogEntryTextBox.Text = LogEntryClass.EnterButtonClick(True)

            Else

                manualTime = ManualTimeEntryBox.Value
                isManualTimeEntry = True
                LogEntryTextBox.Text = LogEntryClass.EnterButtonClick(True, manualTime)

            End If

            ManualTimeEntryBox.Format = Windows.Forms.DateTimePickerFormat.Custom
            ManualTimeEntryBox.CustomFormat = " "
            manualTime = Nothing

            isManualTimeEntry = False

            Debug.Print("AutoSave Timer stopping...")
            AutoSaveTimer.Stop()
            AutoSaveBackgroundWorker.RunWorkerAsync()

        End If

    End Sub

    Public Shared Function GetLodDataForExport()

        Return TextFileTable

    End Function

    Private Sub ManualTimeEntryBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualTimeEntryBox.Enter

        Dim Result As DialogResult
        Result = MessageBox.Show("Do you wish to enter a manual time entry?", "Manual Time Entry?", MessageBoxButtons.YesNo)

        'if user clicked no, cancel form closing
        If Result = System.Windows.Forms.DialogResult.No Then
            'e.Cancel = True

            ManualTimeEntryBox.Format = Windows.Forms.DateTimePickerFormat.Custom
            ManualTimeEntryBox.CustomFormat = " "
            manualTime = Nothing

        Else

            'manualTime = ManualTimeEntryBox.Value
            'Debug.Print(manualTime.ToString)

            Debug.Print("Changing format")
            ManualTimeEntryBox.Value = Date.UtcNow                                      '' Issue_14
            ManualTimeEntryBox.Format = Windows.Forms.DateTimePickerFormat.Custom
            ManualTimeEntryBox.CustomFormat = "M/dd/yyyy HH:mm:ss"

        End If

        'manualTime = ManualTimeEntryBox.Value
        'Debug.Print(manualTime.ToString)

        'Debug.Print("Changing format")
        'ManualTimeEntryBox.Format = Windows.Forms.DateTimePickerFormat.Custom
        'ManualTimeEntryBox.CustomFormat = "M/dd/yyyy HH:mm:ss"

    End Sub

    '' Issue_9 -->
    Private Sub TorNeededCheckbox_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TorNeededCheckbox.CheckedChanged

        If TorNeededCheckbox.CheckState = 1 Then

            TorNeeded = True

        Else : TorNeeded = False

        End If

    End Sub                 '' --> Issue_9

    '' Issue_22 BEGIN
    Private Sub SetText(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.

        If Label1.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            Label1.Text = [text]
        End If

    End Sub

    Delegate Sub SetTextCallback(ByVal [text] As String)                '' Issue_22 END


End Class
'Developer:  Kevin Tooley
'   Changes:
'   25FEB2014:  Issue_7:  Add the Minor Dependencies functionality
'   25FEB2014:  Issue_9:  Add flag for TOR NEEDED


Public Class LogEntryClass
    Inherits LogOfDestinyWindow

    Friend Shared exerciseIsRunning As Boolean = False

    Function ManualTimeEntry(ByVal itsManualTime As Date, ByVal itsLogEntry As String)

        ''DataGridView1.Rows.Add(New String(){Value1, Value2, Value3})
        ''DataGridView1.Rows.Insert(rowPosition, New String(){value1, value2, value3})

        ''For i = 1 To TextFileTable.Rows.Count - 1 (maybe the -1) loop
        ''check each Item(0) entry to see if less than
        ''If manualTime < Item(0) Then
        ''Insert row above the evaluated row

        'For i = 0 To TextFileTable.Rows.Count - 1 'maybe -1

        '    'Dim itsGmtTimeStamp As Date
        '    Debug.Print(itsManualTime.ToString("MM/dd/yyyy HH:mm:ss"))
        '    'Dim manualTimeEntry As Date = CDate(ManualTimeEntryBox.Text)

        '    'Debug.Print(TextFileTable.Rows(i).Item(0))
        '    Debug.Print(TextFileTable.Rows.IndexOf(TextFileTable.Rows(i)))

        '    If TextFileTable(i).Item(0) > itsManualTime Then

        '        'DataRow newBlankRow1 = detailsTable.NewRow(); 
        '        'detailsTable.Rows.InsertAt(newBlankRow1, currentSourceRow);

        '        Dim newBlankRow As DataRow = TextFileTable.NewRow()

        '        TextFileTable.Rows.InsertAt(newBlankRow, i)
        '        'DataGridView1.Rows.Insert(
        '        TextFileTable(i).Item(0) = itsManualTime.ToString("MM/dd/yyyy HH:mm:ss")
        '        'TextFileTable(i).Item(1) = localTime
        '        TextFileTable(i).Item(2) = LogEntryTextBox.Text

        '        For Each element As ElementClass In elementArray

        '            TextFileTable(i).Item(element.getElementTextTableColumn()) = element.getStatus()

        '        Next

        '        LogEntryTextBox.Text = ""

        '        Exit For

        '    End If

        'Next






        Dim localTime = Date.Now '.ToString("MM/dd/yyyy HH:mm:ss")
        Dim gmtTime = itsManualTime.ToString("MM/dd/yyyy HH:mm:ss")
        Dim currentRow = TextFileTable.Rows.Count

        TextFileTable.Rows.Add(gmtTime)
        TextFileTable(currentRow).Item("Local") = localTime
        'TextFileTable(currentRow).Item(
        'TextFileTable(currentRow).Item(2) = "TEST"
        'TextFileTable(currentRow).Item(2) = LogEntryTextBox.Text
        TextFileTable(currentRow).Item("Log Entry") = itsLogEntry

        'If exerciseIsRunning = True Then

        '    For Each element As ElementClass In elementArray

        '        TextFileTable(currentRow).Item(element.getElementTextTableColumn()) = element.getStatus()

        '    Next

        'Else

        '    For Each element As ElementClass In elementArray

        '        TextFileTable(currentRow).Item(element.getElementTextTableColumn()) = element.getStatus("BREAK")

        '    Next

        'End If

        LogEachElementStatus(currentRow)

        Return ""

    End Function

    ''' <summary>
    ''' This function is used for a regular log entry with no manual time entry required
    ''' </summary>
    ''' <param name="itsLogEntry"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overloads Function EnterButtonClick(ByVal itsLogEntry As String) ''Regular Log Entry

        'Dim gmtTime = Date.UtcNow.ToString("MM/dd/yyyy HH:mm:ss")
        Dim gmtTime = Date.UtcNow '.ToString("MM/dd/yyyy HH:mm:ss")
        'Dim localTime = Date.Now.ToString("MM/dd/yyyy HH:mm:ss")
        Dim localTime = Date.Now '.ToString("MM/dd/yyyy HH:mm:ss")

        Dim currentRow = TextFileTable.Rows.Count

        'TextFileTable.Rows.Add(gmtTime)
        'TextFileTable(currentRow).Item("Local") = localTime
        'TextFileTable(currentRow).Item("Log Entry") = itsLogEntry

        'LogEachElementStatus(currentRow)

        CommonLogEntrySub(gmtTime, localTime, currentRow, itsLogEntry)

        Return ""

    End Function

    ''' <summary>
    ''' This function is used for a regular log entry WITH a manual time entered by the operator
    ''' </summary>
    ''' <param name="itsManualTime"></param>
    ''' <param name="itsLogEntry"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overloads Function EnterButtonClick(ByVal itsManualTime As Date, ByVal itsLogEntry As String) ''Manual Time log enter

        Dim gmtTime = itsManualTime '.ToString("MM/dd/yyyy HH:mm:ss")
        Dim localTime = Date.Now '.ToString("MM/dd/yyyy HH:mm:ss")

        Dim currentRow = TextFileTable.Rows.Count

        CommonLogEntrySub(gmtTime, localTime, currentRow, itsLogEntry)

        Return ""

    End Function

    ''' <summary>
    ''' This function is for an exercise complete with no manual time entry
    ''' </summary>
    ''' <param name="isExerciseComplete"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overloads Function EnterButtonClick(ByVal isExerciseComplete As Boolean)  ''Exercise complete log entry 

        Dim gmtTime = Date.UtcNow '.ToString("MM/dd/yyyy HH:mm:ss")
        Dim localTime = Date.Now '.ToString("MM/dd/yyyy HH:mm:ss")

        Dim currentRow = TextFileTable.Rows.Count

        'TextFileTable.Rows.Add(gmtTime)
        'TextFileTable(currentRow).Item(1) = localTime
        'TextFileTable(currentRow).Item(2) = "FINEX"

        'LogEachElementStatus(currentRow)

        CommonLogEntrySub(gmtTime, localTime, currentRow, "FINEX")

        Return ""

    End Function

    ''' <summary>
    ''' This function is for an Exercise Complete WITH a manual time entry
    ''' </summary>
    ''' <param name="isExerciseComplete"></param>
    ''' <param name="itsManualTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overloads Function EnterButtonClick(ByVal isExerciseComplete As Boolean, ByVal itsManualTime As Date) ''Exercise Complete with manual time entry

        Dim gmtTime = itsManualTime '.ToString("MM/dd/yyyy HH:mm:ss")
        Dim localTime = Date.Now '.ToString("MM/dd/yyyy HH:mm:ss")

        Dim currentRow = TextFileTable.Rows.Count

        CommonLogEntrySub(gmtTime, localTime, currentRow, "FINEX")

        Return ""

    End Function

    Function StartBreakButtonClick() As String

        If exerciseIsRunning = False Then

            exerciseIsRunning = True

            If LogOfDestinyWindow.isManualTimeEntry = False Then

                EnterButtonClick("Exercise Start")

            Else

                'manualTime = CDate(ManualTimeEntryBox.Value)
                ManualTimeEntry(LogOfDestinyWindow.manualTime, "Exercise Start")

            End If

            'EnterButtonClick("Exercise Start")

            isManualTimeEntry = False
            Return "Press to enter BREAK"

        Else

            exerciseIsRunning = False

            If LogOfDestinyWindow.isManualTimeEntry = False Then

                EnterButtonClick("Break")

            Else

                'manualTime = CDate(ManualTimeEntryBox.Value)
                ManualTimeEntry(LogOfDestinyWindow.manualTime, "Break")

            End If

            isManualTimeEntry = False
            Return "Press to Resume Exercise"

        End If

        'Debug.Print("exerciseIsRunning set to: " & exerciseIsRunning)

    End Function

    Sub CompleteExercise()

        Dim localTime = Date.Now '.ToString("MM/dd/yyyy HH:mm:ss")
        Dim gmtTime = Date.UtcNow '.ToString("MM/dd/yyyy HH:mm:ss")
        Dim currentRow = TextFileTable.Rows.Count

        TextFileTable.Rows.Add(gmtTime)
        TextFileTable(currentRow).Item(1) = localTime
        TextFileTable(currentRow).Item(2) = "FINEX"

        LogEachElementStatus(currentRow)

    End Sub

    Sub Dependencies()

        For Each compositeElement As ElementClass In elementArray

            If compositeElement.isComposite = "true" Then

                If compositeElement.getOverride() = False Then

                    Dim isMajorUp As Boolean = False                '' ISSUE_7
                    Dim isMinorUp As Boolean = False                '' ISSUE_7

                    Dim isMajorDegraded As Boolean = False          '' ISSUE_7

                    Dim isMajorDown As Boolean = False              '' ISSUE_7
                    Dim isMinorDown As Boolean = False              '' ISSUE_7

                    Dim splitMajorString() As String
                    Dim splitMinorString() As String
                    'Dim thisStatusArray() As String                ''  ISSUE_7
                    Dim thisStatusArrayMajor() As String            ''  ISSUE_7
                    Dim thisStatusArrayMinor() As String            ''  ISSUE_7

                    splitMajorString = Split(compositeElement.elementMajorDependencies, ",")
                    splitMinorString = Split(compositeElement.elementMinorDependencies, ",")
                    thisStatusArrayMajor = Split(compositeElement.elementMajorDependencies, ",")        '' ISSUE_7
                    thisStatusArrayMinor = Split(compositeElement.elementMinorDependencies, ",")        '' ISSUE_7

                    'Set the Major Dependency Status
                    For i = 0 To UBound(splitMajorString)

                        thisStatusArrayMajor(i) = getComponentStatus(splitMajorString(i))               '' ISSUE_7

                    Next

                    '' ISSUE_7 BEGIN -->
                    'Set the Minor Dependency Status
                    For i = 0 To UBound(splitMinorString)

                        thisStatusArrayMinor(i) = getComponentStatus(splitMinorString(i))

                    Next                                                                                '' <-- ISSUE_7 END

                    For Each statusString As String In thisStatusArrayMajor                             '' ISSUE_7

                        'Debug.Print(statusString)
                        If statusString = "DOWN" Then

                            'Debug.Print("WE HAVE A DOWN MAJOR STATUS")
                            isMajorDown = True                                                          '' ISSUE_7        
                            Exit For

                        End If

                    Next

                    '' ISSUE_7 BEGIN -->
                    For Each statusString As String In thisStatusArrayMinor

                        'Debug.Print(statusString)
                        If statusString = "DOWN" Then

                            'Debug.Print("WE HAVE A DOWN MINOR STATUS")
                            isMinorDown = True
                            Exit For

                        End If

                    Next                                                                                '' <-- ISSUE_7 END

                    For Each statusString As String In thisStatusArrayMajor                             '' ISSUE_7

                        'Debug.Print(statusString)
                        If statusString = "DGRD" Then

                            'Debug.Print("WE HAVE A DGRD STATUS")
                            isMajorDegraded = True                                                      '' ISSUE_7
                            Exit For

                        End If

                    Next

                    For Each statusString As String In thisStatusArrayMajor                             '' ISSUE_7

                        'Debug.Print(statusString)
                        If statusString = "UP" Then

                            'Debug.Print("WE HAVE A UP STATUS")
                            isMajorUp = True                                                            '' ISSUE_7
                            Exit For

                        End If

                    Next

                    '' ISSUE_7 BEGIN -->
                    For Each statusString As String In thisStatusArrayMinor

                        'Debug.Print(statusString)
                        If statusString = "UP" Or statusString = "OFFLINE" Or statusString = "" Then

                            'Debug.Print("WE HAVE A UP STATUS")
                            isMinorUp = True
                            Exit For

                        End If

                    Next                                                                                '' <-- ISSUE_7 END

                    If isMajorDown = True Then                                                          '' ISSUE_7

                        compositeElement.elementStatusBox.SelectedItem = ElementStatusClass.StatusEnumeration.DOWN

                    ElseIf isMajorDegraded = True Or isMinorDown = True Then                            '' ISSUE_7

                        compositeElement.elementStatusBox.SelectedItem = ElementStatusClass.StatusEnumeration.DGRD

                    ElseIf isMajorUp = True And isMinorUp = True Then                                   '' ISSUE_7

                        compositeElement.elementStatusBox.SelectedItem = ElementStatusClass.StatusEnumeration.UP

                    End If

                End If

            End If

        Next

    End Sub

    Sub LogEachElementStatus(ByVal itsRow As Integer)

        Dependencies()

        If exerciseIsRunning = True Then

            For Each element As ElementClass In elementArray

                'TextFileTable(itsRow).Item(element.getElementTextTableColumn()) = element.getStatus()
                TextFileTable(itsRow).Item(element.getName()) = element.getStatus()

            Next

        Else

            For Each element As ElementClass In elementArray

                'TextFileTable(itsRow).Item(element.getElementTextTableColumn()) = element.getStatus("BREAK")
                TextFileTable(itsRow).Item(element.getName()) = element.getStatus("BREAK")

            Next

        End If

    End Sub

    Sub CommonLogEntrySub(ByVal itsGmtTime As Date, _
                          ByVal itsLocalTime As Date, _
                          ByVal itsRow As Integer, _
                          ByVal itsLogEntry As String)

        Dim gmt = itsGmtTime.ToString("MM/dd/yyyy HH:mm:ss")
        Dim local = itsLocalTime.ToString("MM/dd/yyyy HH:mm:ss")

        TextFileTable.Rows.Add(gmt)
        TextFileTable(itsRow).Item("Local") = local

        '' Issue_9 -->
        If TorNeeded = True Then

            itsLogEntry = "TOR NEEDED: " & itsLogEntry

        End If          '' <-- Issue_9

        TextFileTable(itsRow).Item("Log Entry") = itsLogEntry

        TorNeededCheckbox.CheckState = 0

        LogEachElementStatus(itsRow)

    End Sub

    Function getComponentStatus(ByVal itsShortName As String)

        Dim itsStatus = ""

        Try

            For Each element As ElementClass In elementArray

                If element.getName() = itsShortName Then

                    itsStatus = element.getStatus()

                    Exit For

                End If

            Next

        Catch ex As Exception

            MsgBox("A program error has occurred in getComponentStatus: " & ex.Message)

        End Try

        Return itsStatus

    End Function

End Class

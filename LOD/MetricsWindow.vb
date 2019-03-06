Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop

Public Class MetricsWindow

    Friend Shared MetricsCalcInProgress As Boolean = False

    Friend elementMetricsArray() As String
    Friend timeMetricsArray() As Date
    Friend resultingTimeDeltaArray() As TimeSpan

    Dim TestDataTable As DataTable = Nothing

    Friend Shared OutlookExcelLog As Excel.Application
    Friend Shared ExcelWorkbook As Excel.Workbook
    Friend Shared ExcelSheet As Excel.Worksheet

    ''' <summary>
    ''' This is the tactical version of UpMetricCalculation
    ''' </summary>
    ''' <param name="itsCount"></param>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub UpMetricCalculation(ByVal itsCount As Integer, _
                            ByVal thisDataGridView As DataTable, _
                            ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True



        For i = 0 To itsCount - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "UP" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "DGRD" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or _
                    elementMetricsArray(i) = "DGRD" Or _
                    elementMetricsArray(i) = "OFFLINE" Or _
                    elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "UP" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                End If

            End If

        Next

        For Each element As ElementClass In LogOfDestinyWindow.elementArray

            If element.getName() = elementName Then

                'Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
                '            " and " & resultingTimeDeltaArray(4).ToString)

                element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.UP, resultingTimeDeltaArray, arrayCount)

                Exit For

            End If

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the test version of UpMetricCalculation
    ''' </summary>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub UpMetricCalculation(ByVal thisDataGridView As DataTable, ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True

        For i = 0 To TestDataTable.Rows.Count - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "UP" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "DGRD" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or _
                    elementMetricsArray(i) = "DGRD" Or _
                    elementMetricsArray(i) = "OFFLINE" Or _
                    elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "UP" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                End If

            End If

            Debug.Print("ResultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString & " " & elementName)

        Next

        'For Each element As ElementClass In LogOfDestinyWindow.elementArray

        '    If element.getName() = elementName Then

        '        Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
        '                    " and " & resultingTimeDeltaArray(4).ToString)

        '        element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.UP, resultingTimeDeltaArray, arrayCount)

        '        Exit For

        '    End If

        'Next

        For i = 0 To 20

            TestDataTable(i).Item(2) = resultingTimeDeltaArray(i).ToString

        Next


        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the tactical version of DegradedMetricCalculation
    ''' </summary>
    ''' <param name="itsCount"></param>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub DegradedMetricCalculation(ByVal itsCount As Integer, _
                            ByVal thisDataGridView As DataTable, _
                            ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True

        For i = 0 To itsCount - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "DGRD" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "UP" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or _
                    elementMetricsArray(i) = "UP" Or _
                    elementMetricsArray(i) = "OFFLINE" Or _
                    elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "DGRD" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                End If

            End If

        Next

        For Each element As ElementClass In LogOfDestinyWindow.elementArray

            If element.getName() = elementName Then

                'Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
                ' " and " & resultingTimeDeltaArray(4).ToString)

                element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.DEGRADED, resultingTimeDeltaArray, arrayCount)

                Exit For

            End If

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the test version of DegradedMetricCalculation
    ''' </summary>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub DegradedMetricCalculation(ByVal thisDataGridView As DataTable, ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True

        For i = 0 To TestDataTable.Rows.Count - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "DGRD" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "UP" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or _
                    elementMetricsArray(i) = "UP" Or _
                    elementMetricsArray(i) = "OFFLINE" Or _
                    elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "DGRD" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                End If

            End If

        Next

        'For Each element As ElementClass In LogOfDestinyWindow.elementArray

        '    If element.getName() = elementName Then

        '        Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
        '                    " and " & resultingTimeDeltaArray(4).ToString)

        '        element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.DEGRADED, resultingTimeDeltaArray, arrayCount)

        '        Exit For

        '    End If

        'Next

        For i = 0 To 20

            TestDataTable(i).Item(2) = resultingTimeDeltaArray(i).ToString

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the tactical version of DownMetricCalculation
    ''' </summary>
    ''' <param name="itsCount"></param>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub DownMetricCalculation(ByVal itsCount As Integer, _
                            ByVal thisDataGridView As DataTable, _
                            ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True



        For i = 0 To itsCount - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "DOWN" Then

                    If elementMetricsArray(i - 1) = "UP" Or _
                        elementMetricsArray(i - 1) = "DGRD" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "UP" Or _
                    elementMetricsArray(i) = "DGRD" Or _
                    elementMetricsArray(i) = "OFFLINE" Or _
                    elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "DOWN" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                End If

            End If

        Next

        For Each element As ElementClass In LogOfDestinyWindow.elementArray

            If element.getName() = elementName Then

                'Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
                '            " and " & resultingTimeDeltaArray(4).ToString)

                element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.DOWN, resultingTimeDeltaArray, arrayCount)

                Exit For

            End If

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the test version of DegradedMetricsCalculation
    ''' </summary>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub DownMetricCalculation(ByVal thisDataGridView As DataTable, ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True



        For i = 0 To TestDataTable.Rows.Count - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "DOWN" Then

                    If elementMetricsArray(i - 1) = "UP" Or _
                        elementMetricsArray(i - 1) = "DGRD" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "UP" Or _
                    elementMetricsArray(i) = "DGRD" Or _
                    elementMetricsArray(i) = "OFFLINE" Or _
                    elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "DOWN" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                End If

            End If

        Next

        'For Each element As ElementClass In LogOfDestinyWindow.elementArray

        '    If element.getName() = elementName Then

        '        Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
        '                    " and " & resultingTimeDeltaArray(4).ToString)

        '        element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.DOWN, resultingTimeDeltaArray, arrayCount)

        '        Exit For

        '    End If

        'Next

        For i = 0 To 20

            TestDataTable(i).Item(2) = resultingTimeDeltaArray(i).ToString

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the tactical version of OfflineMetricCalculation
    ''' </summary>
    ''' <param name="itsCount"></param>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub OfflineMetricCalculation(ByVal itsCount As Integer, _
                            ByVal thisDataGridView As DataTable, _
                            ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True



        For i = 0 To itsCount - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "OFFLINE" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "DGRD" Or _
                        elementMetricsArray(i - 1) = "UP" Or _
                        elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or _
                    elementMetricsArray(i) = "DGRD" Or _
                    elementMetricsArray(i) = "UP" Or _
                    elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "OFFLINE" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                End If

            End If

        Next

        For Each element As ElementClass In LogOfDestinyWindow.elementArray

            If element.getName() = elementName Then

                'Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
                '" and " & resultingTimeDeltaArray(4).ToString)

                element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.OFFLINE, resultingTimeDeltaArray, arrayCount)

                Exit For

            End If

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the test version of OfflineMetricCalculation
    ''' </summary>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub OfflineMetricCalculation(ByVal thisDataGridView As DataTable, ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True

        For i = 0 To TestDataTable.Rows.Count - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "OFFLINE" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "DGRD" Or _
                        elementMetricsArray(i - 1) = "UP" Or _
                        elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or _
                    elementMetricsArray(i) = "DGRD" Or _
                    elementMetricsArray(i) = "UP" Or _
                    elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "OFFLINE" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                End If

            End If

        Next

        'For Each element As ElementClass In LogOfDestinyWindow.elementArray

        '    If element.getName() = elementName Then

        '        Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
        '                    " and " & resultingTimeDeltaArray(4).ToString)

        '        element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.OFFLINE, resultingTimeDeltaArray, arrayCount)

        '        Exit For

        '    End If

        'Next

        For i = 0 To 20

            TestDataTable(i).Item(2) = resultingTimeDeltaArray(i).ToString

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the tactical version of BreakMetricCalculation
    ''' </summary>
    ''' <param name="itsCount"></param>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub BreakMetricCalculation(ByVal itsCount As Integer, _
                            ByVal thisDataGridView As DataTable, _
                            ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True



        For i = 0 To itsCount - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "DGRD" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "UP" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or _
                    elementMetricsArray(i) = "DGRD" Or _
                    elementMetricsArray(i) = "OFFLINE" Or _
                    elementMetricsArray(i) = "UP" Then

                    If elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                End If

            End If

        Next

        For Each element As ElementClass In LogOfDestinyWindow.elementArray

            If element.getName() = elementName Then

                'Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
                '            " and " & resultingTimeDeltaArray(4).ToString)

                element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.BREAK, resultingTimeDeltaArray, arrayCount)

                Exit For

            End If

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the test version of BreakMetricCalculation
    ''' </summary>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub BreakMetricCalculation(ByVal thisDataGridView As DataTable, ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True



        For i = 0 To TestDataTable.Rows.Count - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "DGRD" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "UP" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or _
                    elementMetricsArray(i) = "DGRD" Or _
                    elementMetricsArray(i) = "OFFLINE" Or _
                    elementMetricsArray(i) = "UP" Then

                    If elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                End If

            End If

        Next

        'For Each element As ElementClass In LogOfDestinyWindow.elementArray

        '    If element.getName() = elementName Then

        '        Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
        '                    " and " & resultingTimeDeltaArray(4).ToString)

        '        element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.BREAK, resultingTimeDeltaArray, arrayCount)

        '        Exit For

        '    End If

        'Next

        For i = 0 To 20

            TestDataTable(i).Item(2) = resultingTimeDeltaArray(i).ToString

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the tactical version of MaxFclMetricCalculation
    ''' </summary>
    ''' <param name="itsCount"></param>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub MaxFclMetricCalculation(ByVal itsCount As Integer, _
                            ByVal thisDataGridView As DataTable, _
                            ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True

        For i = 0 To itsCount - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "UP" Or elementMetricsArray(i) = "DGRD" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or elementMetricsArray(i - 1) = "OFFLINE" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    ElseIf elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "UP" Or elementMetricsArray(i - 1) = "DGRD" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    ElseIf elementMetricsArray(i - 1) = "DOWN" Or elementMetricsArray(i - 1) = "OFFLINE" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or elementMetricsArray(i) = "OFFLINE" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or elementMetricsArray(i - 1) = "OFFLINE" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                    ElseIf elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                    End If

                End If

            End If

        Next

        For Each element As ElementClass In LogOfDestinyWindow.elementArray

            If element.getName() = elementName Then

                'Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
                '            " and " & resultingTimeDeltaArray(4).ToString)

                element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.MAX, resultingTimeDeltaArray, arrayCount)

                Exit For

            End If

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the test version of MaxFclMetricCalculation
    ''' </summary>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub MaxFclMetricCalculation(ByVal thisDataGridView As DataTable, ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True

        For i = 0 To TestDataTable.Rows.Count - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "UP" Or elementMetricsArray(i) = "DGRD" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or elementMetricsArray(i - 1) = "OFFLINE" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    ElseIf elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "UP" Or elementMetricsArray(i - 1) = "DGRD" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    ElseIf elementMetricsArray(i - 1) = "DOWN" Or elementMetricsArray(i - 1) = "OFFLINE" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or elementMetricsArray(i) = "OFFLINE" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or elementMetricsArray(i - 1) = "OFFLINE" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                    ElseIf elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                    End If

                End If

            End If

        Next

        'For Each element As ElementClass In LogOfDestinyWindow.elementArray

        '    If element.getName() = elementName Then

        '        Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
        '                    " and " & resultingTimeDeltaArray(4).ToString)

        '        element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.MAX, resultingTimeDeltaArray, arrayCount)

        '        Exit For

        '    End If

        'Next

        For i = 0 To 20

            TestDataTable(i).Item(2) = resultingTimeDeltaArray(i).ToString

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the tactical version of MaxFullUpMetricCalculation
    ''' </summary>
    ''' <param name="itsCount"></param>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub MaxFullUpMetricCalculation(ByVal itsCount As Integer, _
                            ByVal thisDataGridView As DataTable, _
                            ByVal elementName As String)


        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True

        For i = 0 To itsCount - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "UP" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "DGRD" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    ElseIf elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "UP" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    ElseIf elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "DGRD" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or _
                    elementMetricsArray(i) = "OFFLINE" Or _
                    elementMetricsArray(i) = "DGRD" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "DGRD" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                    ElseIf elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                    End If

                End If

            End If

        Next

        For Each element As ElementClass In LogOfDestinyWindow.elementArray

            If element.getName() = elementName Then

                'Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
                '            " and " & resultingTimeDeltaArray(4).ToString)

                element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.MaxFullUp, resultingTimeDeltaArray, arrayCount)

                Exit For

            End If

        Next

        MetricsCalcInProgress = False

    End Sub

    ''' <summary>
    ''' This is the test version of MaxFullUpMetricCalculation
    ''' </summary>
    ''' <param name="thisDataGridView"></param>
    ''' <param name="elementName"></param>
    ''' <remarks></remarks>
    Overloads Sub MaxFullUpMetricCalculation(ByVal thisDataGridView As DataTable, ByVal elementName As String)

        Dim arrayCount = thisDataGridView.Rows.Count

        ReDim elementMetricsArray(arrayCount)
        ReDim timeMetricsArray(arrayCount)
        ReDim resultingTimeDeltaArray(arrayCount)

        MetricsCalcInProgress = True

        For i = 0 To TestDataTable.Rows.Count - 1

            elementMetricsArray(i) = thisDataGridView(i).Item(elementName).ToString
            'Debug.Print("elementMetricsArray(" & i & "): " & elementMetricsArray(i).ToString)

            timeMetricsArray(i) = thisDataGridView(i).Item("GMT")
            'Debug.Print("timeMetricsArray(" & i & "): " & timeMetricsArray(i).ToString)


            If i = 0 Then

                resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i)

            Else

                If elementMetricsArray(i) = "UP" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "DGRD" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                        'Debug.Print("Tsub0 resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    ElseIf elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubX resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "BREAK" Then

                    If elementMetricsArray(i - 1) = "UP" Then

                        resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                        'Debug.Print("TsubF resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    ElseIf elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "DGRD" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                    Else : resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                        'Debug.Print("Carryover: resultingTimeDeltaArray(" & i & "): " & resultingTimeDeltaArray(i).ToString)

                    End If

                ElseIf elementMetricsArray(i) = "DOWN" Or _
                    elementMetricsArray(i) = "OFFLINE" Or _
                    elementMetricsArray(i) = "DGRD" Then

                    If elementMetricsArray(i - 1) = "DOWN" Or _
                        elementMetricsArray(i - 1) = "OFFLINE" Or _
                        elementMetricsArray(i - 1) = "DGRD" Then

                        'resultingTimeDeltaArray(i) = 0
                        resultingTimeDeltaArray(i) = New TimeSpan(0, 0, 0)

                    ElseIf elementMetricsArray(i - 1) = "BREAK" Then

                        resultingTimeDeltaArray(i) = resultingTimeDeltaArray(i - 1)

                    Else : resultingTimeDeltaArray(i) = timeMetricsArray(i) - timeMetricsArray(i - 1) + resultingTimeDeltaArray(i - 1)

                    End If

                End If

            End If

        Next

        'For Each element As ElementClass In LogOfDestinyWindow.elementArray

        '    If element.getName() = elementName Then

        '        Debug.Print("Array.copy sending: " & resultingTimeDeltaArray(1).ToString & _
        '                    " and " & resultingTimeDeltaArray(4).ToString)

        '        element.CopyMetricsArrayData(MetricsArrayEnumeration.MetricsArray.MaxFullUp, resultingTimeDeltaArray, arrayCount)

        '        Exit For

        '    End If

        'Next

        For i = 0 To 20

            TestDataTable(i).Item(2) = resultingTimeDeltaArray(i).ToString

        Next

        MetricsCalcInProgress = False

    End Sub

    Sub ElementAvailabilityCalculation(ByVal elementName As String)

        For Each element As ElementClass In LogOfDestinyWindow.elementArray

            If element.getName() = elementName Then

                'element.elementAvailabilityMetricLabel.Text = element.UpMetricsArray.Max.Add(element.DegradedMetricsArray.Max).ToString
                'Debug.Print(element.UpMetricsArray.Max.TotalSeconds.ToString)
                element.elementAvailabilityMetricLabel.Text = FormatNumber((element.UpMetricsArray.Max.TotalSeconds + element.DegradedMetricsArray.Max.TotalSeconds) / _
                    (element.UpMetricsArray.Max.TotalSeconds + element.DegradedMetricsArray.Max.TotalSeconds + element.DownMetricsArray.Max.TotalSeconds) * _
                    100, 1) & "%"
                'Debug.Print(element.elementAvailabilityMetricLabel.Text)

                Exit For

            End If

        Next

    End Sub

    Private Sub CalculateMetricsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculateMetricsButton.Click

        For Each element As ElementClass In LogOfDestinyWindow.elementArray

            Dim elementName = element.getName()

            UpMetricCalculation(LogOfDestinyWindow.TextFileTable.Rows.Count, LogOfDestinyWindow.TextFileTable, elementName)
            DegradedMetricCalculation(LogOfDestinyWindow.TextFileTable.Rows.Count, LogOfDestinyWindow.TextFileTable, elementName)
            DownMetricCalculation(LogOfDestinyWindow.TextFileTable.Rows.Count, LogOfDestinyWindow.TextFileTable, elementName)
            OfflineMetricCalculation(LogOfDestinyWindow.TextFileTable.Rows.Count, LogOfDestinyWindow.TextFileTable, elementName)
            BreakMetricCalculation(LogOfDestinyWindow.TextFileTable.Rows.Count, LogOfDestinyWindow.TextFileTable, elementName)
            MaxFclMetricCalculation(LogOfDestinyWindow.TextFileTable.Rows.Count, LogOfDestinyWindow.TextFileTable, elementName)
            MaxFullUpMetricCalculation(LogOfDestinyWindow.TextFileTable.Rows.Count, LogOfDestinyWindow.TextFileTable, elementName)
            ElementAvailabilityCalculation(elementName)

        Next

        'UpMetricCalculation(LogOfDestinyWindow.TextFileTable.Rows.Count, LogOfDestinyWindow.TextFileTable, "ADS")

        ''These are the test functions for the metrics
        'CreateTestDataTable("UP", "DGRD", "ADS")
        'UpMetricCalculation(TestDataTable, "ADS")

        'CreateTestDataTable("DGRD", "BREAK", "ADS")
        'DegradedMetricCalculation(TestDataTable, "ADS")

        'CreateTestDataTable("DOWN", "BREAK", "ADS")
        'DownMetricCalculation(TestDataTable, "ADS")

        'CreateTestDataTable("OFFLINE", "BREAK", "ADS")
        'OfflineMetricCalculation(TestDataTable, "ADS")

        'CreateTestDataTable("BREAK", "OFFLINE", "ADS")
        'BreakMetricCalculation(TestDataTable, "ADS")

        'CreateTestDataTable("BREAK", "OFFLINE", "ADS")
        'MaxFclMetricCalculation(TestDataTable, "ADS")

        'CreateTestDataTable("BREAK", "OFFLINE", "ADS")
        'MaxFullUpMetricCalculation(TestDataTable, "ADS")

    End Sub

    'Private Sub CreateTestDataTable(ByVal itsStatus As String, ByVal alternateStatus As String, ByVal elementName As String)

    '    Dim Column As DataColumn
    '    'Dim Row As DataRow
    '    Dim UpperBound As Integer = 2
    '    Dim ColumnCount As Integer
    '    'Dim CurrentRow As String()

    '    If TestDataTable Is Nothing Then

    '        TestDataTable = New DataTable("TextFileTable")

    '        For ColumnCount = 0 To UpperBound
    '            Column = New DataColumn()
    '            Column.DataType = System.Type.GetType("System.String")
    '            If ColumnCount = 0 Then
    '                Column.ColumnName = "GMT"
    '                Column.Caption = "GMT"
    '            ElseIf ColumnCount = 1 Then
    '                Column.ColumnName = elementName
    '                Column.Caption = elementName
    '            ElseIf ColumnCount = 2 Then
    '                Column.ColumnName = "Metric"
    '                Column.Caption = "Metric"
    '            End If

    '            'Column.ColumnName = "Column" & ColumnCount
    '            'Column.Caption = "Column" & ColumnCount

    '            Column.ReadOnly = False
    '            Column.Unique = False
    '            TestDataTable.Columns.Add(Column)
    '        Next

    '    End If

    '    'DataGridView1.DataSource = TestDataTable
    '    'DataGridView1.Columns("GMT").Width = 150

    '    For i = 0 To 20

    '        Dim gmtTime As Date = Date.UtcNow.ToString("MM/dd/yyyy HH:mm:ss")
    '        Dim newTime As Date

    '        'newTime = gmtTime + DateAdd(DateInterval.Hour, i, gmtTime)
    '        newTime = gmtTime + TimeSpan.FromHours(i)

    '        'TestDataTable(i).Item(0) = newTime
    '        TestDataTable.Rows.Add(newTime)

    '        If i = 5 Or i = 6 Or i = 14 Or i = 15 Then
    '            TestDataTable(i).Item(1) = alternateStatus
    '        Else : TestDataTable(i).Item(1) = itsStatus
    '        End If
    '        'TestDataTable(i).Item(1) = itsStatus

    '        Debug.Print("TestDataTable.Row: " & i & " - " & _
    '                    TestDataTable(i).Item(0).ToString & " " & _
    '                    TestDataTable(i).Item(1).ToString)

    '    Next

    'End Sub

    Private Sub MetricsWindow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        PopulateGroupBoxes(TabPage1)
        PopulateGroupBoxes(TabPage2)
        PopulateGroupBoxes(TabPage3)
        'PopulateGroupBoxes(TabPage4)

        ''For Each gb As GroupBox In frmLogEntry.TabPage1.Controls.OfType(Of GroupBox)()

        'For Each gb In TabPage1.Controls.OfType(Of GroupBox)()

        '    'For Each element As CElement In frmLogEntry.elementArray

        '    For Each element As ElementClass In LogOfDestinyWindow.elementArray

        '        If element.elementMetricsBox = gb.Name Then

        '            gb.Text = element.getName()

        '            'element.upButton.Location = New Point(4, 17)
        '            'gb.Controls.Add(element.upButton)

        '            '16, 29, 42, 55, 68, 81
        '            '10, 29, 48, 67, 85, 102

        '            element.elementUpMetricLabel.Location = New Point(78, 10) '16
        '            element.elementDegradedMetricLabel.Location = New Point(78, 29) '32
        '            element.elementDownMetricLabel.Location = New Point(78, 48)
        '            'element.elementOfflineMetricLabel.Location = New Point(78, 67)
        '            element.elementBreakMetricLabel.Location = New Point(78, 67)
        '            element.elementMaxMetricLabel.Location = New Point(78, 85)
        '            element.elementMaxFullUpMetricLabel.Location = New Point(78, 102)

        '            gb.Controls.Add(element.elementUpMetricLabel)
        '            gb.Controls.Add(element.elementDegradedMetricLabel)
        '            gb.Controls.Add(element.elementDownMetricLabel)
        '            gb.Controls.Add(element.elementBreakMetricLabel)
        '            gb.Controls.Add(element.elementMaxMetricLabel)
        '            gb.Controls.Add(element.elementMaxFullUpMetricLabel)

        '        End If

        '    Next

        'Next

        'For Each gb In TabPage1.Controls.OfType(Of GroupBox)()

        '    If gb.Text = "" Then

        '        gb.Visible = False

        '    End If

        'Next

    End Sub

    Sub PopulateGroupBoxes(ByVal thisTabPage As TabPage)

        For Each gb In thisTabPage.Controls.OfType(Of GroupBox)()

            For Each element As ElementClass In LogOfDestinyWindow.elementArray

                If element.elementMetricsBox = gb.Name Then

                    gb.Text = element.getName()

                    '10, 29, 48, 67, 85, 102

                    element.elementUpMetricLabel.Location = New Point(100, 12) '16  10
                    element.elementDegradedMetricLabel.Location = New Point(100, 36) '32  29
                    element.elementDownMetricLabel.Location = New Point(100, 59)  '48
                    'element.elementOfflineMetricLabel.Location = New Point(78, 67)
                    element.elementBreakMetricLabel.Location = New Point(100, 82)  '67
                    element.elementMaxMetricLabel.Location = New Point(100, 105)  '85
                    element.elementMaxFullUpMetricLabel.Location = New Point(100, 126)  '102
                    element.elementAvailabilityMetricLabel.Location = New Point(100, 149)  '121

                    gb.Controls.Add(element.elementUpMetricLabel)
                    gb.Controls.Add(element.elementDegradedMetricLabel)
                    gb.Controls.Add(element.elementDownMetricLabel)
                    gb.Controls.Add(element.elementBreakMetricLabel)
                    gb.Controls.Add(element.elementMaxMetricLabel)
                    gb.Controls.Add(element.elementMaxFullUpMetricLabel)
                    gb.Controls.Add(element.elementAvailabilityMetricLabel)

                    Exit For

                End If

            Next

        Next

        For Each gb In thisTabPage.Controls.OfType(Of GroupBox)()

            If gb.Text = "" Then

                gb.Visible = False

            End If

        Next

    End Sub

    Sub OpenLogTemplate(Optional ByVal itsWorksheet As String = "")

        ' Start Excel and get Application object.
        OutlookExcelLog = CreateObject("Excel.Application")

        OutlookExcelLog.Visible = True

        ' Get a new workbook.
        Dim myDataDirectory = Application.UserAppDataPath

        ExcelWorkbook = OutlookExcelLog.Workbooks.Add()

        'ExportLogOfDestinyOutputToSpreadsheet()

    End Sub

    Sub ExportLogOfDestinyOutputToSpreadsheet()

        ExcelSheet = ExcelWorkbook.Worksheets("Sheet1")

        FormatExcelWorksheet.newWorksheetSetup(ExcelSheet, "Log")

        Dim thisDataTable As DataTable = LogOfDestinyWindow.GetLodDataForExport()

        'Debug.Print(thisDataTable(0).Item(0).ToString)

        For c = 0 To thisDataTable.Columns.Count - 1

            ExcelSheet.Cells(1, c + 1).Value = thisDataTable.Columns(c).ColumnName

        Next

        For r = 0 To thisDataTable.Rows.Count - 1

            For c = 0 To thisDataTable.Columns.Count - 1

                ExcelSheet.Cells(r + 2, c + 1).Value = thisDataTable(r).Item(c).ToString

            Next

        Next

        ExcelSheet = ExcelWorkbook.Worksheets("Sheet2")
        FormatExcelWorksheet.newMetricsPageSetup(ExcelSheet, "Metrics")

        ExcelSheet.Cells(2, 1) = "UP"
        ExcelSheet.Cells(3, 1) = "DEGRADED"
        ExcelSheet.Cells(4, 1) = "DOWN"
        ExcelSheet.Cells(5, 1) = "OFFLINE"
        ExcelSheet.Cells(6, 1) = "BREAK"
        ExcelSheet.Cells(7, 1) = "MAX"
        ExcelSheet.Cells(8, 1) = "MAXFullUP"
        ExcelSheet.Cells(9, 1) = "Availability"

        Dim thisColumn As Integer = 2

        For Each Element As ElementClass In LogOfDestinyWindow.elementArray

            ExcelSheet.Cells(1, thisColumn) = Element.getName()

            For thisRow = 0 To 6   'ElementStatusClass.StatusEnumeration LENGTH

                Dim thisMetricArray() As TimeSpan = Element.GetMetricArraysForExport(thisRow)

                ExcelSheet.Cells(thisRow + 2, thisColumn) = thisMetricArray.Max.ToString

            Next

            ExcelSheet.Cells(9, thisColumn).Value = Element.elementAvailabilityMetricLabel.Text

            thisColumn += 1

        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        OpenLogTemplate()

        ExportLogOfDestinyOutputToSpreadsheet()

    End Sub

End Class
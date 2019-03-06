Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop

Public Class FormatExcelWorksheet
    Inherits MetricsWindow

    Sub newWorksheetSetup(ByVal WorksheetName As Excel.Worksheet, ByVal myName As String)

        WorksheetName.Name = myName
        WorksheetName.Columns("A:B").ColumnWidth = 16
        WorksheetName.Columns("C:C").ColumnWidth = 27
        WorksheetName.Columns("D:AS").ColumnWidth = 2.86
        'WorksheetName.Columns("M:M").Hidden = True

        Dim Selection As Excel.Range = WorksheetName.Range("A1:AO200")
        With Selection

            .Font.Name = "Arial"

        End With


        Selection = WorksheetName.Range("D1:AO1")
        With Selection

            .Orientation = 90
            .Font.Bold = True

        End With

        Selection = WorksheetName.Columns("C:C")
        With Selection

            .WrapText = True

        End With

    End Sub

    Sub newMetricsPageSetup(ByVal WorksheetName As Excel.Worksheet, ByVal myName As String)

        WorksheetName.Name = myName

        Dim Selection As Excel.Range = WorksheetName.Columns("A:A")
        With Selection

            .ColumnWidth = 11
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Font.Bold = True

        End With

        Selection = WorksheetName.Columns("B:BF") ' was "B:L"
        With Selection

            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

        End With

        Selection = WorksheetName.Range("B1:BF1")
        With Selection

            .Font.Bold = True
            .Font.Color = RGB(255, 255, 255)
            .Interior.Color = RGB(0, 0, 0)

        End With

        Selection = WorksheetName.Range("A2:BF2") ''UP row
        With Selection

            .Font.Color = RGB(255, 255, 255)
            .Interior.Color = RGB(0, 128, 128)

        End With

        Selection = WorksheetName.Range("A3:BF3") ''DEGRADED row
        With Selection

            '.Font.Color = RGB(255, 255, 255)
            .Interior.Color = RGB(255, 255, 153)

        End With

        Selection = WorksheetName.Range("A4:BF4") ''DOWN row
        With Selection

            .Font.Color = RGB(255, 255, 255)
            .Interior.Color = RGB(255, 0, 0)

        End With

        Selection = WorksheetName.Range("A7:BF7") ''MAX row
        With Selection

            .Font.Color = RGB(255, 255, 255)
            .Interior.Color = RGB(0, 0, 0)

        End With

        Selection = WorksheetName.Range("A8:BF8") ''MAXFR row
        With Selection

            .Font.Color = RGB(255, 255, 255)
            .Interior.Color = RGB(0, 128, 0)

        End With

        Selection = WorksheetName.Range("B9:BF9") ''AVAIL row
        With Selection

            .FormatConditions.Add(Type:=Excel.XlFormatConditionType.xlCellValue, _
                                  Operator:=Excel.XlFormatConditionOperator.xlLessEqual, _
                                  Formula1:="69.9%")
            .FormatConditions(Selection.FormatConditions.Count).SetFirstPriority()

            With .FormatConditions(1)

                .Font.Color = RGB(0, 0, 0)
                .Interior.Color = RGB(255, 0, 0)


            End With

        End With

        With Selection

            .FormatConditions.Add(Type:=Excel.XlFormatConditionType.xlCellValue, _
                                  Operator:=Excel.XlFormatConditionOperator.xlBetween, _
                                  Formula1:="70%", _
                                  Formula2:="89.9%")
            .FormatConditions(Selection.FormatConditions.Count).SetFirstPriority()

            With .FormatConditions(1)

                .Font.Color = RGB(0, 0, 0)
                .Interior.Color = RGB(255, 255, 0)


            End With

        End With

        With Selection

            .FormatConditions.Add(Type:=Excel.XlFormatConditionType.xlCellValue, _
                                  Operator:=Excel.XlFormatConditionOperator.xlBetween, _
                                  Formula1:="90%", _
                                  Formula2:="100%")
            .FormatConditions(Selection.FormatConditions.Count).SetFirstPriority()

            With .FormatConditions(1)

                .Font.Color = RGB(255, 255, 255)
                .Interior.Color = RGB(0, 176, 80)


            End With

        End With

    End Sub

    Sub setupHeaderLine1(ByVal thisWorksheet As Excel.Worksheet, ByVal lineNumber As Integer)

        Dim Selection As Excel.Range = thisWorksheet.Range("A" & lineNumber & ":L" & lineNumber)
        With Selection
            .Merge()
            .Font.Name = "Arial"
            .Font.Size = 10
            .Font.Bold = True
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .BorderAround()
        End With

    End Sub

    Sub setupHeaderLine2(ByVal thisWorksheet As Excel.Worksheet, ByVal lineNumber As Integer)

        Dim Selection = thisWorksheet.Range("D" & lineNumber & ":J" & lineNumber)
        With Selection
            .Merge()
            .BorderAround()
        End With
        Selection = thisWorksheet.Range("A" & lineNumber & _
                                        ", B" & lineNumber & _
                                        ", C" & lineNumber & _
                                        ", K" & lineNumber & _
                                        ", L" & lineNumber)
        With Selection
            .BorderAround()
        End With

    End Sub

    Sub setupHeaderLine3(ByVal thisWorksheet As Excel.Worksheet, ByVal lineNumber As Integer)

        Dim Selection = thisWorksheet.Range("A" & lineNumber & _
                                            ", B" & lineNumber & _
                                            ", C" & lineNumber & _
                                            ", D" & lineNumber & _
                                            ", E" & lineNumber & _
                                            ", F" & lineNumber & _
                                            ", G" & lineNumber & _
                                            ", H" & lineNumber & _
                                            ", I" & lineNumber & _
                                            ", J" & lineNumber & _
                                            ", K" & lineNumber & _
                                            ", L" & lineNumber)
        With Selection
            .Font.Name = "Arial"
            .Font.Size = 8
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .BorderAround()
        End With
        thisWorksheet.Range("A" & lineNumber).Value = "Start Time"
        thisWorksheet.Range("B" & lineNumber).Value = "End Time"
        thisWorksheet.Range("C" & lineNumber).Value = "Element"
        thisWorksheet.Range("D" & lineNumber).Value = "B/L"
        thisWorksheet.Range("E" & lineNumber).Value = "CDLMS1"
        thisWorksheet.Range("F" & lineNumber).Value = "CDLMS2"
        thisWorksheet.Range("G" & lineNumber).Value = "UMG1"
        thisWorksheet.Range("H" & lineNumber).Value = "UMG2"
        thisWorksheet.Range("I" & lineNumber).Value = "CEC"
        thisWorksheet.Range("J" & lineNumber).Value = "JMCIS"
        thisWorksheet.Range("K" & lineNumber).Value = "Responsible Individual(s)"
        thisWorksheet.Range("L" & lineNumber).Value = "Support"

    End Sub

    Sub setupNewLine(ByVal thisWorksheet As Excel.Worksheet, ByVal lineNumber As Integer)

        ''thisWorksheet.Rows(currentRow:currentRow).RowHeight = 17
        'Dim Selection = thisWorksheet.Range(currentRow)

        'With Selection
        '    .Font.Size = 8
        '    .RowHeight = 17
        'End With

        Dim Selection = thisWorksheet.Range("A" & lineNumber & _
                                            ", B" & lineNumber)

        With Selection
            .EntireRow.Font.Name = "Arial"
            .EntireRow.Font.Size = 8
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .NumberFormat = "0000"
            .BorderAround()
            .EntireRow.RowHeight = 17
        End With

        Selection = thisWorksheet.Range("C" & lineNumber & _
                                            ", D" & lineNumber & _
                                            ", E" & lineNumber & _
                                            ", F" & lineNumber & _
                                            ", G" & lineNumber & _
                                            ", H" & lineNumber & _
                                            ", I" & lineNumber & _
                                            ", J" & lineNumber & _
                                            ", K" & lineNumber & _
                                            ", L" & lineNumber)

        With Selection
            .Font.Name = "Arial"
            .Font.Size = 9
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .BorderAround()
        End With

    End Sub

    Sub setupDateLine(ByVal thisWorksheet As Excel.Worksheet, ByVal lineNumber As Integer)

        Dim Selection = thisWorksheet.Range("A" & lineNumber & _
                                            ", B" & lineNumber & _
                                            ", C" & lineNumber & _
                                            ", D" & lineNumber & _
                                            ", E" & lineNumber & _
                                            ", F" & lineNumber & _
                                            ", G" & lineNumber & _
                                            ", H" & lineNumber & _
                                            ", I" & lineNumber & _
                                            ", J" & lineNumber & _
                                            ", K" & lineNumber & _
                                            ", L" & lineNumber)
        With Selection
            .Font.Name = "Arial"
            .Font.Size = 8
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .BorderAround()
            '.Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            .Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlThick
        End With
        Selection = thisWorksheet.Range("A" & lineNumber & _
                                        ", B" & lineNumber)
        With Selection
            .Font.Color = RGB(0, 51, 204)
            .Font.Bold = True
        End With

    End Sub

    Sub setupSiteMaintenanceLine(ByVal thisWorksheet As Excel.Worksheet, ByVal lineNumber As Integer)

        Dim Selection = thisWorksheet.Range("A" & lineNumber & _
                                                    ", B" & lineNumber & _
                                                    ", C" & lineNumber & _
                                                    ", D" & lineNumber & _
                                                    ", E" & lineNumber & _
                                                    ", F" & lineNumber & _
                                                    ", G" & lineNumber & _
                                                    ", H" & lineNumber & _
                                                    ", I" & lineNumber & _
                                                    ", J" & lineNumber & _
                                                    ", K" & lineNumber & _
                                                    ", L" & lineNumber)
        With Selection
            .Font.Name = "Arial"
            .Font.Size = 8
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .BorderAround()
            .Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlMedium
            .Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlMedium
            .Interior.Color = RGB(191, 191, 191)
        End With

        Selection = thisWorksheet.Range("C" & lineNumber)
        With Selection
            .Font.Size = 9
            .Font.Bold = True
            .Font.Color = RGB(255, 0, 0)
            .Value = "Site Maintenance"
        End With

        Selection = thisWorksheet.Range("A" & lineNumber & _
                                        ", B" & lineNumber)
        With Selection
            .NumberFormat = "0000"
        End With

    End Sub

    Sub insertNewLine(ByVal thisWorksheet As Excel.Worksheet, _
                      ByVal lineNumber As Integer, _
                      ByVal itsStartTime As Integer, _
                      ByVal itsEndTime As Integer, _
                      ByVal itsShotTitle As String)

        Dim Selection = thisWorksheet.Range("A" & lineNumber)

        With Selection
            .EntireRow.Insert()
        End With

        Selection = thisWorksheet.Range("A" & lineNumber & _
                                            ", B" & lineNumber)

        With Selection
            .EntireRow.Font.Name = "Arial"
            .EntireRow.Font.Size = 8
            .EntireRow.Font.Color = RGB(0, 0, 0)
            .EntireRow.Font.Bold = False
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .NumberFormat = "0000"
            .BorderAround()
            .EntireRow.RowHeight = 17
            .Interior.Color = 65535
            .Interior.TintAndShade = 0
            .Interior.PatternTintAndShade = 0
            '.Value = "TEST INSERT"
        End With

        Selection = thisWorksheet.Range("C" & lineNumber & _
                                            ", D" & lineNumber & _
                                            ", E" & lineNumber & _
                                            ", F" & lineNumber & _
                                            ", G" & lineNumber & _
                                            ", H" & lineNumber & _
                                            ", I" & lineNumber & _
                                            ", J" & lineNumber & _
                                            ", K" & lineNumber & _
                                            ", L" & lineNumber)

        With Selection
            .Font.Name = "Arial"
            .Font.Size = 9
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .BorderAround()
        End With

        thisWorksheet.Range("A" & lineNumber).Value = itsStartTime
        thisWorksheet.Range("B" & lineNumber).Value = itsEndTime

        Selection = thisWorksheet.Range("C" & lineNumber)

        With Selection
            .Value = itsShotTitle
            .Interior.Color = 65535
            .Interior.TintAndShade = 0
            .Interior.PatternTintAndShade = 0
        End With

    End Sub

    Sub deleteLine(ByVal thisWorksheet As Excel.Worksheet, _
                   ByVal lineNumber As Integer)

        Dim Selection = thisWorksheet.Range("A" & lineNumber)

        With Selection
            .EntireRow.Delete()
        End With

    End Sub

End Class

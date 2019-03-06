Public Class ElementClass
    Inherits LogOfDestinyWindow

    Friend isComposite As Boolean
    Friend isOverride As Boolean

    Friend elementName As String
    Friend elementStatus As String
    Friend elementMajorDependencies As String
    Friend elementMinorDependencies As String

    Friend elementGroupBox As New GroupBox
    Friend elementLabel As New Label
    Friend WithEvents elementStatusBox As New ComboBox
    Friend WithEvents elementIsOverride As New CheckBox
    Friend elementRow As Integer
    Friend elementColumn As Integer
    Friend elementTab As Integer

    Friend elementMetricsBox As String

    Friend UpMetricsArray() As TimeSpan
    Friend DegradedMetricsArray() As TimeSpan
    Friend DownMetricsArray() As TimeSpan
    Friend OfflineMetricsArray() As TimeSpan
    Friend BreakMetricsArray() As TimeSpan
    Friend MaxMetricsArray() As TimeSpan
    Friend MaxFullUpMetricsArray() As TimeSpan

    Public WithEvents elementUpMetricLabel As New Label() With {.Text = "", _
                                                                .Anchor = (AnchorStyles.Top Or AnchorStyles.Left), _
                                                                .Size = New Size(78, 13)}

    Public WithEvents elementDegradedMetricLabel As New Label() With {.Text = "", _
                                                                .Anchor = (AnchorStyles.Top Or AnchorStyles.Left), _
                                                                .Size = New Size(78, 13)}

    Public WithEvents elementDownMetricLabel As New Label() With {.Text = "", _
                                                                .Anchor = (AnchorStyles.Top Or AnchorStyles.Left), _
                                                                .Size = New Size(78, 13)}

    Public WithEvents elementOfflineMetricLabel As New Label() With {.Text = "", _
                                                                .Anchor = (AnchorStyles.Top Or AnchorStyles.Left), _
                                                                .Size = New Size(78, 13)}

    Public WithEvents elementBreakMetricLabel As New Label() With {.Text = "", _
                                                                .Anchor = (AnchorStyles.Top Or AnchorStyles.Left), _
                                                                .Size = New Size(78, 13)}

    Public WithEvents elementMaxMetricLabel As New Label() With {.Text = "", _
                                                                .Anchor = (AnchorStyles.Top Or AnchorStyles.Left), _
                                                                .Size = New Size(78, 13)}

    Public WithEvents elementMaxFullUpMetricLabel As New Label() With {.Text = "", _
                                                                .Anchor = (AnchorStyles.Top Or AnchorStyles.Left), _
                                                                .Size = New Size(78, 13)}

    Public WithEvents elementAvailabilityMetricLabel As New Label() With {.Text = "", _
                                                                .Anchor = (AnchorStyles.Top Or AnchorStyles.Left), _
                                                                .Size = New Size(78, 13)}

    'Public WithEvents elementGroupBox As New RadioButton() With {.Text = "UP", _
    '                                                           .Anchor = (AnchorStyles.Top Or AnchorStyles.Left), _
    '                                                           .Size = New Size(36, 36)}

    'Public WithEvents elementGroupBox As New GroupBox() With {.Text = "TEST", _
    '                                                          .Anchor = (AnchorStyles.Top Or AnchorStyles.Left), _
    '                                                          .Size = New Size(200, 100)}

    Sub CopyMetricsArrayData(ByVal whichArray As Integer, ByVal thisArray() As TimeSpan, ByVal itsArrayCount As Integer)

        If whichArray = 0 Then

            ReDim UpMetricsArray(itsArrayCount)
            Array.Copy(thisArray, UpMetricsArray, itsArrayCount)
            'Debug.Print(elementName & " Array.copy copied: UP " & UpMetricsArray(1).ToString & " and " & UpMetricsArray(4).ToString)
            'Debug.Print("UP Metric is: " & UpMetricsArray.Max.ToString)
            elementUpMetricLabel.Text = UpMetricsArray.Max.ToString

        ElseIf whichArray = 1 Then

            ReDim DegradedMetricsArray(itsArrayCount)
            Array.Copy(thisArray, DegradedMetricsArray, itsArrayCount)
            'Debug.Print(elementName & " Array.copy copied: DGRD " & DegradedMetricsArray(1).ToString & " and " & DegradedMetricsArray(4).ToString)
            elementDegradedMetricLabel.Text = DegradedMetricsArray.Max.ToString

        ElseIf whichArray = 2 Then

            ReDim DownMetricsArray(itsArrayCount)
            Array.Copy(thisArray, DownMetricsArray, itsArrayCount)
            'Debug.Print(elementName & " Array.copy copied: DOWN " & DownMetricsArray(1).ToString & " and " & DownMetricsArray(4).ToString)
            elementDownMetricLabel.Text = DownMetricsArray.Max.ToString

        ElseIf whichArray = 3 Then

            ReDim OfflineMetricsArray(itsArrayCount)
            Array.Copy(thisArray, OfflineMetricsArray, itsArrayCount)
            'Debug.Print(elementName & " Array.copy copied: OFF " & OfflineMetricsArray(1).ToString & " and " & OfflineMetricsArray(4).ToString)
            elementOfflineMetricLabel.Text = OfflineMetricsArray.Max.ToString

        ElseIf whichArray = 4 Then

            ReDim BreakMetricsArray(itsArrayCount)
            Array.Copy(thisArray, BreakMetricsArray, itsArrayCount)
            'Debug.Print(elementName & " Array.copy copied: BREAK " & BreakMetricsArray(1).ToString & " and " & BreakMetricsArray(4).ToString)
            elementBreakMetricLabel.Text = BreakMetricsArray.Max.ToString

        ElseIf whichArray = 5 Then

            ReDim MaxMetricsArray(itsArrayCount)
            Array.Copy(thisArray, MaxMetricsArray, itsArrayCount)
            'Debug.Print(elementName & " Array.copy copied: MAX " & MaxMetricsArray(1).ToString & " and " & MaxMetricsArray(4).ToString)
            elementMaxMetricLabel.Text = MaxMetricsArray.Max.ToString

        ElseIf whichArray = 6 Then

            ReDim MaxFullUpMetricsArray(itsArrayCount)
            Array.Copy(thisArray, MaxFullUpMetricsArray, itsArrayCount)
            'Debug.Print(elementName & " Array.copy copied: MAXFU " & UpMetricsArray(1).ToString & " and " & UpMetricsArray(4).ToString)
            elementMaxFullUpMetricLabel.Text = MaxFullUpMetricsArray.Max.ToString

        End If


        'Array.Copy(thisArray, UpMetricsArray, itsArrayCount)

        'Debug.Print("Array.copy copied: " & UpMetricsArray(1).ToString & " and " & UpMetricsArray(4).ToString)

    End Sub

    Function getElementTab()

        Return elementTab

    End Function

    Sub setElementTab(ByVal itsTab As String)

        Try

            Dim myTab As String = itsTab
            Dim Value As Integer
            Value = DirectCast([Enum].Parse(GetType(TabEnumeration.Tab), "Tab" & myTab), Integer) ''THIS RETURNS THE ENUM VALUE
            'Debug.Print(Value)

            elementTab = Value
            'Debug.Print("elementTab: " & elementTab)

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Function getElementRow()

        Return elementRow

    End Function

    Sub setElementRow(ByVal itsRow As String)

        Try

            Dim myRow As String = itsRow
            Dim Value As Integer
            'Value = DirectCast([Enum].Parse(GetType(RowEnumeration.Row), myRow), Integer) ''THIS RETURNS THE ENUM NAME
            Value = DirectCast([Enum].Parse(GetType(RowEnumeration.Row), "Row" & myRow), Integer) ''THIS RETURNS THE ENUM VALUE
            'Debug.Print(Value)

            elementRow = Value
            'Debug.Print("elementRow: " & elementRow)

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Function getElementColumn()

        Return elementColumn

    End Function

    Sub setElementColumn(ByVal itsColumn As Integer)

        Try

            'elementColumn = itsColumn

            Dim myColumn As String = itsColumn
            Dim Value As Integer
            'Value = DirectCast([Enum].Parse(GetType(RowEnumeration.Row), myRow), Integer) ''THIS RETURNS THE ENUM NAME
            Value = DirectCast([Enum].Parse(GetType(ColumnEnumeration.Column), "Column" & myColumn), Integer) ''THIS RETURNS THE ENUM VALUE
            'Debug.Print(Value)

            elementColumn = Value
            'Debug.Print("elementRow: " & elementRow)

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Function getElementLabel()

        Return elementLabel.Name

    End Function

    Sub setElementLabel()

        Try

            elementLabel.Name = elementName

        Catch ex As Exception

        End Try

    End Sub

    Function getElementIsOverride()

        Return elementIsOverride.Name

    End Function

    Sub setElementIsOverride()

        Try

            elementIsOverride.Name = elementName

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Function getElementStatusBox()

        Return elementStatusBox.Name

    End Function

    Sub setElementStatusBox()

        Try

            elementStatusBox.Name = elementName

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Function getStatus(Optional ByVal itsManualStatus As String = "")

        If itsManualStatus = "" Then

            Return elementStatus

        Else

            Return itsManualStatus

        End If

        'Return elementStatus

    End Function

    Sub setStatus(ByVal itsStatusEnum As ElementStatusClass.StatusEnumeration)

        'Element has elementGroupBox that contains elementDropDown which sets the Status of the 
        'element based on the ElementStatusClass::StatusEnumeration

        Try

            Dim myStatus As Integer = itsStatusEnum

            'Value = DirectCast([Enum].Parse(GetType(RowEnumeration.Row), myRow), Integer) ''THIS RETURNS THE ENUM NAME
            'Value = DirectCast([Enum].Parse(GetType(RowEnumeration.Row), "Row" & myRow), Integer) ''THIS RETURNS THE ENUM VALUE
            'elementStatus = DirectCast([Enum].Parse(GetType(ElementStatusClass.StatusEnumeration), myStatus), Integer)

            elementStatus = [Enum].GetName(GetType(ElementStatusClass.StatusEnumeration), myStatus)
            'Debug.Print("elementStatus: " & getStatus())

            'elementStatus = itsStatus

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Function getComposite()

        'Gets the boolean value of isComposite
        Return isComposite

    End Function

    Sub setComposite(ByVal itsIsComposite As Boolean)

        'Sets the boolean value of isComposite after reading the data from the XMLFile.  
        'This function might not be needed after populating the elementArray() array

        Try

            isComposite = itsIsComposite

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Function getName()

        Return elementName

    End Function

    Sub setName(ByVal itsElementName As String)

        Try

            elementName = itsElementName

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        setElementLabel()
        setElementStatusBox()
        setElementIsOverride()

    End Sub

    Function getOverride()

        'Checks the override status.  If TRUE, the LOD will not adjust the status based on dependencies

        Return isOverride

    End Function

    Sub setOverride(ByVal itsOverrideStatus As Boolean)

        'Sets the override status
        Try

            isOverride = itsOverrideStatus

            'Debug.Print("isOverride: " & getOverride())

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Function getGroupBox()

        Return elementGroupBox.Name

    End Function

    Sub setGroupBox(ByVal itsGroupBox As String)

        Try
            'elementGroupBox = New GroupBox
            elementGroupBox.Name = itsGroupBox

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Function getMajorDependencies()

        Return elementMajorDependencies

    End Function

    Sub setMajorDependencies(ByVal itsMajorDependencies As String)

        Try

            elementMajorDependencies = itsMajorDependencies

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Function getMinorDependencies()

        Return elementMinorDependencies

    End Function

    Sub setMinorDependencies(ByVal itsMinorDependencies As String)

        Try

            elementMinorDependencies = itsMinorDependencies

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Function getElementMetricsBox()

        Return elementMetricsBox

    End Function

    Sub setElementMetricsBox(ByVal itsElementBox As String)

        Try

            elementMetricsBox = itsElementBox

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Sub CreateElementGroupBox()

        Try

            'Debug.Print("Entered ElementClass::CreateElementGroupBox()")

            'elementGroupBox = New GroupBox

            ShipElementsGroupBox.Controls.Add(elementGroupBox)

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try


    End Sub

    Private Sub elementStatusBox_SelectedValueChanged(ByVal sender As Object, _
                                                      ByVal e As System.EventArgs) Handles elementStatusBox.SelectedValueChanged

        Try

            setStatus(elementStatusBox.SelectedValue)

            'Debug.Print("elementStatus changed: " & getStatus())

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub elementIsOverride_CheckedChanged(ByVal sender As Object, _
                                                 ByVal e As System.EventArgs) Handles elementIsOverride.CheckedChanged

        Try

            setOverride(elementIsOverride.Checked)
            'Debug.Print(getName() & " Override checkedChanged")
            'Debug.Print(getName() & " elementIsOverride.Checked: " & elementIsOverride.Checked)

        Catch ex As Exception

        End Try

    End Sub

    Public Function GetMetricArraysForExport(ByVal whichArray As Integer)

        'Return UpMetricsArray

        If whichArray = 0 Then

            Return UpMetricsArray

        ElseIf whichArray = 1 Then

            Return DegradedMetricsArray

        ElseIf whichArray = 2 Then

            Return DownMetricsArray

        ElseIf whichArray = 3 Then

            Return OfflineMetricsArray

        ElseIf whichArray = 4 Then

            Return BreakMetricsArray

        ElseIf whichArray = 5 Then

            Return MaxMetricsArray

        Else

            'whichArray = 6
            Return MaxFullUpMetricsArray

        End If

    End Function

End Class

Imports System.Xml

Public Class ConfigurationFileOperationsClass
    Inherits LogOfDestinyWindow

    Friend Shared configFileLocation As String

    Function GetConfigFile() As Boolean

        'COMPILE
        'Sets the configFileLocation string with the location of the appropriate Ship Config xml file
        Dim myDataDirectory = Application.UserAppDataPath
        'Dim myDataDirectory = "C:\Users\ktooley\source\repos\LOD\LOD\"

        'Dim whatIsMyConfig As String
        'Message.Create(MainWindow, 1, thisConfig, dontKnown)

        Try

            'While configIsSet = False

            '    If currentConfig = "" Then

            '    Else : configIsSet = True
            '    End If

            '    Sleep(500)

            'End While

            ''COMPILE PATHS
            If currentConfig = "isBL9A" Then

                Debug.Print("GetConfigFile::MainWindow.isBL9A is checked")
                configFileLocation = myDataDirectory & "\Config_AMOD_CG.xml"
                'configFileLocation = "C:\Documents and Settings\ktooley\My Documents\Visual Studio 2010\Projects\LOD\LOD\Config_AMOD_CG.xml"
                'configIsSet = True
                'Return True

            ElseIf currentConfig = "isBL9C" Then

                Debug.Print("GetConfigFile::MainWindow.isBL9C is checked")
                configFileLocation = myDataDirectory & "\Config_AMOD_DDG.xml"
                'configFileLocation = "C:\Users\ktooley\Documents\Visual Studio 2010\Projects\LOD\LOD\Config_AMOD_DDG.xml"
                'configIsSet = True
                'Return True

            ElseIf currentConfig = "isBL9D" Then

                Debug.Print("GetConfigFile::MainWindow.isBL9D is checked")
                configFileLocation = myDataDirectory & "\Config_AMOD_DDG.xml"
                'configFileLocation = "C:\Users\ktooley\Documents\Visual Studio 2010\Projects\LOD\LOD\Config_AMOD_DDG.xml"
                configIsSet = True
                Return True

            ElseIf currentConfig = "isBL9E" Then

                Debug.Print("GetConfigFile::MainWindow.isBL9E is checked")
                configFileLocation = myDataDirectory & "\Config_AMOD_DDG.xml"
                'configFileLocation = "C:\Users\ktooley\Documents\Visual Studio 2010\Projects\LOD\LOD\Config_AMOD_DDG.xml"
                'configIsSet = True
                'Return True

            ElseIf currentConfig = "isJ6" Then

                Debug.Print("GetConfigFile::MainWindow.isJ6 is checked")
                configFileLocation = myDataDirectory & "\Config_J6.xml"
                'configFileLocation = "C:\Users\ktooley\Documents\Visual Studio 2010\Projects\LOD\LOD\Config_J6.xml"
                'configIsSet = True
                'Return True

            ElseIf currentConfig = "isAWD" Then

                Debug.Print("GetConfigFile::MainWindow.isAWD is checked")
                configFileLocation = myDataDirectory & "\Config_AWD.xml"
                'configFileLocation = "C:\Documents and Settings\ktooley\My Documents\Visual Studio 2010\Projects\LOD\LOD\Config_AWD.xml"
                'configIsSet = True
                'Return True

            Else : MsgBox("A valid configuration was not selected.  Please try again.")

                Return False

                Exit Try

            End If

            'Sleep(5000)

            'End While

        Catch ex As Exception

            MsgBox("A program error has occurred in determineConfig(): " & ex.Message)

        End Try

        Debug.Print("GetConfigFile::configFileLocation is " & configFileLocation)
        'Return configFileLocation
        Return True

    End Function

    Sub PopulateElementXmlArray()  'Read the config file and populate the elementXmlDataArray() array

        Debug.Print("currentConfig: " & currentConfig)
        Debug.Print("Before setting ConfigurationFileOperationsClass::configFileLocation: " & configFileLocation)

        If GetConfigFile() = True Then

            Debug.Print("After setting ConfigurationFileOperationsClass::configFileLocation: " & configFileLocation)

            Dim xmlDoc = XDocument.Load(configFileLocation)
            Dim itsCount = xmlDoc.Descendants("element").Count

            Debug.Print("xmlDoc.Descendants::element.Count: " & itsCount)

            ReDim elementXmlDataArray(itsCount - 1, 10)
            ReDim elementArray(itsCount - 1)
            'ReDim LogOfDestinyWindow.elementXmlDataArray(xmlDoc.Descendants("element").Count - 1, 4)
            'ReDim LogOfDestinyWindow.elementArray(xmlDoc.Descendants("element").Count - 1)

            'Debug.Print("Printing elementArray(): " & elementArray.All)

            'If GetConfigFile() = True Then

            'Try

            Dim i = 0

            For Each element In xmlDoc.Descendants("element")

                elementXmlDataArray(i, 0) = element.Descendants("elementName").Value
                elementXmlDataArray(i, 1) = element.Descendants("elementTab").Value
                elementXmlDataArray(i, 2) = element.Descendants("elementRow").Value
                elementXmlDataArray(i, 3) = element.Descendants("elementColumn").Value
                elementXmlDataArray(i, 4) = element.Descendants("elementGroupBox").Value
                'elementXmlDataArray(i, 5) = element.Descendants("elementStatusBox").Value
                'elementXmlDataArray(i, 6) = element.Descendants("elementIsOverride").Value
                elementXmlDataArray(i, 7) = element.Descendants("isComposite").Value
                elementXmlDataArray(i, 8) = element.Descendants("majorDependencies").Value
                elementXmlDataArray(i, 9) = element.Descendants("minorDependencies").Value
                elementXmlDataArray(i, 10) = element.Descendants("elementMetricsBox").Value


                'Debug.Print("*************")
                'Debug.Print("elementName: " & elementXmlDataArray(i, 0))
                'Debug.Print("elementTab: " & elementXmlDataArray(i, 1))
                'Debug.Print("elementRow: " & elementXmlDataArray(i, 2))
                'Debug.Print("elementColumn: " & elementXmlDataArray(i, 3))
                'Debug.Print("elementGroupBox: " & elementXmlDataArray(i, 4))
                'Debug.Print("elementStatusBox: " & elementXmlDataArray(i, 5))
                'Debug.Print("elementIsOverride: " & elementXmlDataArray(i, 6))
                'Debug.Print("isComposite: " & elementXmlDataArray(i, 7))
                'Debug.Print("majorDependencies: " & elementXmlDataArray(i, 8))
                'Debug.Print("minorDependencies: " & elementXmlDataArray(i, 9))
                'Debug.Print("elementMetricsBox: " & elementXmlDataArray(i, 10))
                'Debug.Print("elementXmlDataArray Length: " & elementXmlDataArray.Length)

                'elementArray(i) = New ElementClass 'With {.elementName = "TEST"}
                PopulateElementArray(i)

                'Debug.Print("Second verficiation*************")
                'Debug.Print("ElementArray(" & i & ").getName: " & elementArray(i).getName())
                'Debug.Print("ElementArray(" & i & ").getElementRow: " & elementArray(i).getElementRow())
                'Debug.Print("ElementArray(" & i & ").getElementColumn: " & elementArray(i).getElementColumn())
                'Debug.Print("ElementArray(" & i & ").getGroupBox: " & elementArray(i).getGroupBox())
                'Debug.Print("ElementArray(" & i & ").getElementStatusBox: " & elementArray(i).getElementStatusBox())
                'Debug.Print("ElementArray(" & i & ").getElementIsOverride: " & elementArray(i).getElementIsOverride())
                'Debug.Print("ElementArray(" & i & ").getComposite: " & elementArray(i).getComposite())
                'Debug.Print("ElementArray(" & i & ").getMajorDependencies: " & elementArray(i).getMajorDependencies())
                'Debug.Print("ElementArray(" & i & ").getMinorDependencies: " & elementArray(i).getMinorDependencies())
                'Debug.Print("ElementArray.count: " & elementArray.Count())

                i = i + 1

            Next

            'For Each TEST As ElementClass In elementArray

            '    Debug.Print("AFTER NEXT: elementArray(x).getName: " & TEST.getName)

            'Next

            'Catch ex As Exception

            '    MsgBox("A program error has occurred in readXmlFile::createArrays: " & ex.Message)

            'End Try

            'For Each element As ElementClass In elementArray

            '    Debug.Print("AFTER TRY: elementArray(x).getName: " & element.getName)

            'Next

        End If

    End Sub

    Sub PopulateElementArray(ByVal itsIndex As Integer) 'Use the elementXmlDataArray() array to populate the elementArray() with ElementClass objects

        Try

            elementArray(itsIndex) = New ElementClass  ''Declare the element array
            elementArray(itsIndex).setName(elementXmlDataArray(itsIndex, 0)) ''set the element Name
            elementArray(itsIndex).setElementTab(elementXmlDataArray(itsIndex, 1)) ''set the element Tab
            elementArray(itsIndex).setElementRow(elementXmlDataArray(itsIndex, 2))
            elementArray(itsIndex).setElementColumn(elementXmlDataArray(itsIndex, 3))
            elementArray(itsIndex).setGroupBox(elementXmlDataArray(itsIndex, 4))
            'elementArray(itsIndex).setElementStatusBox(elementXmlDataArray(itsIndex, 5))
            'elementArray(itsIndex).setElementIsOverride(elementXmlDataArray(itsIndex, 6))
            elementArray(itsIndex).setComposite(elementXmlDataArray(itsIndex, 7))  ''set the element composite boolean
            elementArray(itsIndex).setMajorDependencies(elementXmlDataArray(itsIndex, 8)) ''set the major dependencies
            elementArray(itsIndex).setMinorDependencies(elementXmlDataArray(itsIndex, 9)) ''set the minor dependencies
            elementArray(itsIndex).setElementMetricsBox(elementXmlDataArray(itsIndex, 10))

            'Debug.Print("ElementArray(" & itsIndex & ").getName: " & elementArray(itsIndex).getName())
            'Debug.Print("ElementArray(" & itsIndex & ").getTab: " & elementArray(itsIndex).getElementTab())
            'Debug.Print("ElementArray(" & itsIndex & ").getElementRow: " & elementArray(itsIndex).getElementRow())
            'Debug.Print("ElementArray(" & itsIndex & ").getElementColumn: " & elementArray(itsIndex).getElementColumn())
            'Debug.Print("ElementArray(" & itsIndex & ").getGroupBox: " & elementArray(itsIndex).getGroupBox())
            'Debug.Print("ElementArray(" & itsIndex & ").getElementStatusBox: " & elementArray(itsIndex).getElementStatusBox())
            'Debug.Print("ElementArray(" & itsIndex & ").getElementIsOverride: " & elementArray(itsIndex).getElementIsOverride())
            'Debug.Print("ElementArray(" & itsIndex & ").getComposite: " & elementArray(itsIndex).getComposite())
            'Debug.Print("ElementArray(" & itsIndex & ").getMajorDependencies: " & elementArray(itsIndex).getMajorDependencies())
            'Debug.Print("ElementArray(" & itsIndex & ").getMinorDependencies: " & elementArray(itsIndex).getMinorDependencies())
            'Debug.Print("ElementArray(" & itsIndex & ").getElementTextTableColumn: " & elementArray(itsIndex).getElementMetricsBox())
            'Debug.Print("ElementArray.count: " & elementArray.Count())


            'elementArray(itsIndex) = New ElementClass  ''Declare the element array
            'itsElement.setName(elementXmlDataArray(itsIndex, 0)) ''set the element Name
            'itsElement.setElementRow(elementXmlDataArray(itsIndex, 1))
            'itsElement.setElementColumn(elementXmlDataArray(itsIndex, 2))
            'itsElement.setGroupBox(elementXmlDataArray(itsIndex, 3))
            ''elementArray(itsIndex).setElementStatusBox(elementXmlDataArray(itsIndex, 4))
            ''elementArray(itsIndex).setElementIsOverride(elementXmlDataArray(itsIndex, 5))
            'itsElement.setComposite(elementXmlDataArray(itsIndex, 6))  ''set the element composite boolean
            'itsElement.setMajorDependencies(elementXmlDataArray(itsIndex, 7)) ''set the major dependencies
            'itsElement.setMinorDependencies(elementXmlDataArray(itsIndex, 8)) ''set the minor dependencies

            'Debug.Print("ElementArray(" & itsIndex & ").getName: " & itsElement.getName())
            'Debug.Print("ElementArray(" & itsIndex & ").getElementRow: " & itsElement.getElementRow())
            'Debug.Print("ElementArray(" & itsIndex & ").getElementColumn: " & itsElement.getElementColumn())
            'Debug.Print("ElementArray(" & itsIndex & ").getGroupBox: " & itsElement.getGroupBox())
            'Debug.Print("ElementArray(" & itsIndex & ").getElementStatusBox: " & itsElement.getElementStatusBox())
            'Debug.Print("ElementArray(" & itsIndex & ").getElementIsOverride: " & itsElement.getElementIsOverride())
            'Debug.Print("ElementArray(" & itsIndex & ").getComposite: " & itsElement.getComposite())
            'Debug.Print("ElementArray(" & itsIndex & ").getMajorDependencies: " & itsElement.getMajorDependencies())
            'Debug.Print("ElementArray(" & itsIndex & ").getMinorDependencies: " & itsElement.getMinorDependencies())
            'Debug.Print("ElementArray.count: " & elementArray.Count())

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

End Class

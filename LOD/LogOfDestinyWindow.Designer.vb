<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogOfDestinyWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SetAllToUpButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ConfigurationMessageTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShipElementsGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LogEntryButton = New System.Windows.Forms.Button()
        Me.FormLoadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ConfigBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.AutoSaveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AutoSaveBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.LogEntryTextBox = New System.Windows.Forms.TextBox()
        Me.StartBreakButton = New System.Windows.Forms.Button()
        Me.ExerciseCompleteButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ManualTimeEntryBox = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.ConsoleGroupBox = New System.Windows.Forms.GroupBox()
        Me.TorNeededCheckbox = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ShipElementsGroupBox.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Tab1.SuspendLayout()
        Me.Tab2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SetAllToUpButton
        '
        Me.SetAllToUpButton.Location = New System.Drawing.Point(17, 5)
        Me.SetAllToUpButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SetAllToUpButton.Name = "SetAllToUpButton"
        Me.SetAllToUpButton.Size = New System.Drawing.Size(100, 28)
        Me.SetAllToUpButton.TabIndex = 0
        Me.SetAllToUpButton.Text = "Set All to UP"
        Me.SetAllToUpButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 603)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1285, 240)
        Me.DataGridView1.TabIndex = 1
        '
        'ConfigurationMessageTimer
        '
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(309, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(845, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'ShipElementsGroupBox
        '
        Me.ShipElementsGroupBox.Controls.Add(Me.Label9)
        Me.ShipElementsGroupBox.Location = New System.Drawing.Point(8, 7)
        Me.ShipElementsGroupBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ShipElementsGroupBox.Name = "ShipElementsGroupBox"
        Me.ShipElementsGroupBox.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ShipElementsGroupBox.Size = New System.Drawing.Size(1048, 449)
        Me.ShipElementsGroupBox.TabIndex = 3
        Me.ShipElementsGroupBox.TabStop = False
        Me.ShipElementsGroupBox.Text = "Elements"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(346, 12)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 17)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Override"
        '
        'LogEntryButton
        '
        Me.LogEntryButton.Location = New System.Drawing.Point(1099, 468)
        Me.LogEntryButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LogEntryButton.Name = "LogEntryButton"
        Me.LogEntryButton.Size = New System.Drawing.Size(203, 63)
        Me.LogEntryButton.TabIndex = 4
        Me.LogEntryButton.Text = "ENTER"
        Me.LogEntryButton.UseVisualStyleBackColor = True
        '
        'FormLoadTimer
        '
        Me.FormLoadTimer.Interval = 1000
        '
        'ConfigBackgroundWorker
        '
        '
        'AutoSaveTimer
        '
        Me.AutoSaveTimer.Interval = 60000
        '
        'AutoSaveBackgroundWorker
        '
        '
        'LogEntryTextBox
        '
        Me.LogEntryTextBox.Location = New System.Drawing.Point(17, 543)
        Me.LogEntryTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LogEntryTextBox.Multiline = True
        Me.LogEntryTextBox.Name = "LogEntryTextBox"
        Me.LogEntryTextBox.Size = New System.Drawing.Size(703, 52)
        Me.LogEntryTextBox.TabIndex = 5
        '
        'StartBreakButton
        '
        Me.StartBreakButton.Location = New System.Drawing.Point(1099, 66)
        Me.StartBreakButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.StartBreakButton.Name = "StartBreakButton"
        Me.StartBreakButton.Size = New System.Drawing.Size(203, 63)
        Me.StartBreakButton.TabIndex = 6
        Me.StartBreakButton.Text = "Press to Start Exercise"
        Me.StartBreakButton.UseVisualStyleBackColor = True
        '
        'ExerciseCompleteButton
        '
        Me.ExerciseCompleteButton.Location = New System.Drawing.Point(1099, 137)
        Me.ExerciseCompleteButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ExerciseCompleteButton.Name = "ExerciseCompleteButton"
        Me.ExerciseCompleteButton.Size = New System.Drawing.Size(203, 63)
        Me.ExerciseCompleteButton.TabIndex = 7
        Me.ExerciseCompleteButton.Text = "Press to FINEX"
        Me.ExerciseCompleteButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(729, 548)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Manual Time Entry (GMT)"
        '
        'ManualTimeEntryBox
        '
        Me.ManualTimeEntryBox.CustomFormat = " "
        Me.ManualTimeEntryBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ManualTimeEntryBox.Location = New System.Drawing.Point(908, 543)
        Me.ManualTimeEntryBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ManualTimeEntryBox.Name = "ManualTimeEntryBox"
        Me.ManualTimeEntryBox.Size = New System.Drawing.Size(180, 22)
        Me.ManualTimeEntryBox.TabIndex = 9
        Me.ManualTimeEntryBox.Value = New Date(2014, 2, 26, 0, 0, 0, 0)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Tab1)
        Me.TabControl1.Controls.Add(Me.Tab2)
        Me.TabControl1.Location = New System.Drawing.Point(16, 39)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1075, 496)
        Me.TabControl1.TabIndex = 10
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.ShipElementsGroupBox)
        Me.Tab1.Location = New System.Drawing.Point(4, 25)
        Me.Tab1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tab1.Size = New System.Drawing.Size(1067, 467)
        Me.Tab1.TabIndex = 0
        Me.Tab1.Text = "Elements"
        Me.Tab1.UseVisualStyleBackColor = True
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.ConsoleGroupBox)
        Me.Tab2.Location = New System.Drawing.Point(4, 25)
        Me.Tab2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tab2.Size = New System.Drawing.Size(1067, 467)
        Me.Tab2.TabIndex = 1
        Me.Tab2.Text = "Consoles"
        Me.Tab2.UseVisualStyleBackColor = True
        '
        'ConsoleGroupBox
        '
        Me.ConsoleGroupBox.Location = New System.Drawing.Point(8, 7)
        Me.ConsoleGroupBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ConsoleGroupBox.Name = "ConsoleGroupBox"
        Me.ConsoleGroupBox.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ConsoleGroupBox.Size = New System.Drawing.Size(1048, 449)
        Me.ConsoleGroupBox.TabIndex = 4
        Me.ConsoleGroupBox.TabStop = False
        Me.ConsoleGroupBox.Text = "Consoles"
        '
        'TorNeededCheckbox
        '
        Me.TorNeededCheckbox.AutoSize = True
        Me.TorNeededCheckbox.Location = New System.Drawing.Point(733, 575)
        Me.TorNeededCheckbox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TorNeededCheckbox.Name = "TorNeededCheckbox"
        Me.TorNeededCheckbox.Size = New System.Drawing.Size(220, 21)
        Me.TorNeededCheckbox.TabIndex = 11
        Me.TorNeededCheckbox.Text = "TOR Needed for this log entry"
        Me.TorNeededCheckbox.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(231, 11)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Saved to:"
        '
        'LogOfDestinyWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1317, 854)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TorNeededCheckbox)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ManualTimeEntryBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ExerciseCompleteButton)
        Me.Controls.Add(Me.StartBreakButton)
        Me.Controls.Add(Me.LogEntryTextBox)
        Me.Controls.Add(Me.LogEntryButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.SetAllToUpButton)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "LogOfDestinyWindow"
        Me.Text = "LOD Log Entry Window"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ShipElementsGroupBox.ResumeLayout(False)
        Me.ShipElementsGroupBox.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.Tab1.ResumeLayout(False)
        Me.Tab2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SetAllToUpButton As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ConfigurationMessageTimer As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ShipElementsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents LogEntryButton As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents FormLoadTimer As System.Windows.Forms.Timer
    Friend WithEvents ConfigBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents AutoSaveTimer As System.Windows.Forms.Timer
    Friend WithEvents AutoSaveBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents StartBreakButton As System.Windows.Forms.Button
    Friend WithEvents ExerciseCompleteButton As System.Windows.Forms.Button
    Public WithEvents LogEntryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ManualTimeEntryBox As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Tab1 As System.Windows.Forms.TabPage
    Friend WithEvents Tab2 As System.Windows.Forms.TabPage
    Friend WithEvents ConsoleGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents TorNeededCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

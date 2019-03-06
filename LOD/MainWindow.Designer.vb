<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
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
        Me.LodFormThread = New System.ComponentModel.BackgroundWorker()
        Me.MetricsThread = New System.ComponentModel.BackgroundWorker()
        Me.CountdownClockThread = New System.ComponentModel.BackgroundWorker()
        Me.HistoricDataThread = New System.ComponentModel.BackgroundWorker()
        Me.LaunchLODbutton = New System.Windows.Forms.Button()
        Me.LaunchMetricsWindowButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.OutputFileNameBox = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.isBL9C = New System.Windows.Forms.RadioButton()
        Me.isAWD = New System.Windows.Forms.RadioButton()
        Me.isBL9A = New System.Windows.Forms.RadioButton()
        Me.isJ6 = New System.Windows.Forms.RadioButton()
        Me.isBL9D = New System.Windows.Forms.RadioButton()
        Me.isBL9E = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.OpenFileButton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LodFormThread
        '
        '
        'MetricsThread
        '
        '
        'CountdownClockThread
        '
        '
        'HistoricDataThread
        '
        '
        'LaunchLODbutton
        '
        Me.LaunchLODbutton.Location = New System.Drawing.Point(13, 233)
        Me.LaunchLODbutton.Name = "LaunchLODbutton"
        Me.LaunchLODbutton.Size = New System.Drawing.Size(386, 48)
        Me.LaunchLODbutton.TabIndex = 0
        Me.LaunchLODbutton.Text = "Launch LOD"
        Me.LaunchLODbutton.UseVisualStyleBackColor = True
        '
        'LaunchMetricsWindowButton
        '
        Me.LaunchMetricsWindowButton.Location = New System.Drawing.Point(13, 287)
        Me.LaunchMetricsWindowButton.Name = "LaunchMetricsWindowButton"
        Me.LaunchMetricsWindowButton.Size = New System.Drawing.Size(386, 47)
        Me.LaunchMetricsWindowButton.TabIndex = 1
        Me.LaunchMetricsWindowButton.Text = "Launch Metrics Window"
        Me.LaunchMetricsWindowButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 169)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "LOD Setup"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(374, 141)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(366, 115)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "New...."
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.OutputFileNameBox)
        Me.GroupBox3.Location = New System.Drawing.Point(179, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(181, 92)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Step 2: Name the output file..."
        '
        'OutputFileNameBox
        '
        Me.OutputFileNameBox.Location = New System.Drawing.Point(6, 29)
        Me.OutputFileNameBox.Name = "OutputFileNameBox"
        Me.OutputFileNameBox.Size = New System.Drawing.Size(169, 20)
        Me.OutputFileNameBox.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.isBL9C)
        Me.GroupBox2.Controls.Add(Me.isAWD)
        Me.GroupBox2.Controls.Add(Me.isBL9A)
        Me.GroupBox2.Controls.Add(Me.isJ6)
        Me.GroupBox2.Controls.Add(Me.isBL9D)
        Me.GroupBox2.Controls.Add(Me.isBL9E)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(167, 92)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Step 1: Select a Config..."
        '
        'isBL9C
        '
        Me.isBL9C.AutoSize = True
        Me.isBL9C.Location = New System.Drawing.Point(6, 42)
        Me.isBL9C.Name = "isBL9C"
        Me.isBL9C.Size = New System.Drawing.Size(47, 17)
        Me.isBL9C.TabIndex = 1
        Me.isBL9C.TabStop = True
        Me.isBL9C.Text = "9C.1"
        Me.isBL9C.UseVisualStyleBackColor = True
        '
        'isAWD
        '
        Me.isAWD.AutoSize = True
        Me.isAWD.Location = New System.Drawing.Point(63, 65)
        Me.isAWD.Name = "isAWD"
        Me.isAWD.Size = New System.Drawing.Size(51, 17)
        Me.isAWD.TabIndex = 5
        Me.isAWD.TabStop = True
        Me.isAWD.Text = "AWD"
        Me.isAWD.UseVisualStyleBackColor = True
        '
        'isBL9A
        '
        Me.isBL9A.AutoSize = True
        Me.isBL9A.Location = New System.Drawing.Point(6, 19)
        Me.isBL9A.Name = "isBL9A"
        Me.isBL9A.Size = New System.Drawing.Size(47, 17)
        Me.isBL9A.TabIndex = 0
        Me.isBL9A.TabStop = True
        Me.isBL9A.Text = "9A.0"
        Me.isBL9A.UseVisualStyleBackColor = True
        '
        'isJ6
        '
        Me.isJ6.AutoSize = True
        Me.isJ6.Location = New System.Drawing.Point(63, 42)
        Me.isJ6.Name = "isJ6"
        Me.isJ6.Size = New System.Drawing.Size(36, 17)
        Me.isJ6.TabIndex = 4
        Me.isJ6.TabStop = True
        Me.isJ6.Text = "J6"
        Me.isJ6.UseVisualStyleBackColor = True
        '
        'isBL9D
        '
        Me.isBL9D.AutoSize = True
        Me.isBL9D.Location = New System.Drawing.Point(6, 65)
        Me.isBL9D.Name = "isBL9D"
        Me.isBL9D.Size = New System.Drawing.Size(48, 17)
        Me.isBL9D.TabIndex = 2
        Me.isBL9D.TabStop = True
        Me.isBL9D.Text = "9D.0"
        Me.isBL9D.UseVisualStyleBackColor = True
        '
        'isBL9E
        '
        Me.isBL9E.AutoSize = True
        Me.isBL9E.Location = New System.Drawing.Point(63, 19)
        Me.isBL9E.Name = "isBL9E"
        Me.isBL9E.Size = New System.Drawing.Size(47, 17)
        Me.isBL9E.TabIndex = 3
        Me.isBL9E.TabStop = True
        Me.isBL9E.Text = "9E.0"
        Me.isBL9E.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.OpenFileButton)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(366, 115)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Open..."
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'OpenFileButton
        '
        Me.OpenFileButton.Location = New System.Drawing.Point(45, 40)
        Me.OpenFileButton.Name = "OpenFileButton"
        Me.OpenFileButton.Size = New System.Drawing.Size(274, 33)
        Me.OpenFileButton.TabIndex = 0
        Me.OpenFileButton.Text = "Step 1: Press to open a file...."
        Me.OpenFileButton.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(136, 340)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Test Message"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(386, 40)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Welcome to the LOD.  If you wish to start a NEW log, use the ""New..."" tab.  If yo" & _
            "u wish to open a previous log, use the ""Open..."" tab."
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 373)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LaunchMetricsWindowButton)
        Me.Controls.Add(Me.LaunchLODbutton)
        Me.Name = "MainWindow"
        Me.Text = "Control Panel"
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LodFormThread As System.ComponentModel.BackgroundWorker
    Friend WithEvents MetricsThread As System.ComponentModel.BackgroundWorker
    Friend WithEvents CountdownClockThread As System.ComponentModel.BackgroundWorker
    Friend WithEvents HistoricDataThread As System.ComponentModel.BackgroundWorker
    Friend WithEvents LaunchLODbutton As System.Windows.Forms.Button
    Friend WithEvents LaunchMetricsWindowButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents isBL9E As System.Windows.Forms.RadioButton
    Friend WithEvents isBL9D As System.Windows.Forms.RadioButton
    Friend WithEvents isBL9C As System.Windows.Forms.RadioButton
    Friend WithEvents isBL9A As System.Windows.Forms.RadioButton
    Friend WithEvents isAWD As System.Windows.Forms.RadioButton
    Friend WithEvents isJ6 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OutputFileNameBox As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents OpenFileButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class

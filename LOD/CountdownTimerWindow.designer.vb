<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CountdownTimerWindow
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.hourTensUpDown = New System.Windows.Forms.NumericUpDown()
        Me.hourOnesUpDown = New System.Windows.Forms.NumericUpDown()
        Me.minTensUpDown = New System.Windows.Forms.NumericUpDown()
        Me.minOnesUpDown = New System.Windows.Forms.NumericUpDown()
        Me.startButton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.hourTensUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.hourOnesUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minTensUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minOnesUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.MinimumSize = New System.Drawing.Size(140, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 93)
        Me.Label1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(172, 9)
        Me.Label2.MinimumSize = New System.Drawing.Size(140, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 93)
        Me.Label2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(135, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 91)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(336, 9)
        Me.Label4.MinimumSize = New System.Drawing.Size(140, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 93)
        Me.Label4.TabIndex = 3
        '
        'hourTensUpDown
        '
        Me.hourTensUpDown.Location = New System.Drawing.Point(32, 105)
        Me.hourTensUpDown.Name = "hourTensUpDown"
        Me.hourTensUpDown.Size = New System.Drawing.Size(41, 20)
        Me.hourTensUpDown.TabIndex = 4
        '
        'hourOnesUpDown
        '
        Me.hourOnesUpDown.Location = New System.Drawing.Point(79, 105)
        Me.hourOnesUpDown.Name = "hourOnesUpDown"
        Me.hourOnesUpDown.Size = New System.Drawing.Size(36, 20)
        Me.hourOnesUpDown.TabIndex = 5
        '
        'minTensUpDown
        '
        Me.minTensUpDown.Location = New System.Drawing.Point(196, 105)
        Me.minTensUpDown.Name = "minTensUpDown"
        Me.minTensUpDown.Size = New System.Drawing.Size(41, 20)
        Me.minTensUpDown.TabIndex = 6
        '
        'minOnesUpDown
        '
        Me.minOnesUpDown.Location = New System.Drawing.Point(243, 105)
        Me.minOnesUpDown.Name = "minOnesUpDown"
        Me.minOnesUpDown.Size = New System.Drawing.Size(42, 20)
        Me.minOnesUpDown.TabIndex = 7
        '
        'startButton
        '
        Me.startButton.Location = New System.Drawing.Point(203, 131)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(75, 23)
        Me.startButton.TabIndex = 8
        Me.startButton.Text = "Start"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(297, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 91)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = ":"
        '
        'TimerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 166)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.minOnesUpDown)
        Me.Controls.Add(Me.minTensUpDown)
        Me.Controls.Add(Me.hourOnesUpDown)
        Me.Controls.Add(Me.hourTensUpDown)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Name = "TimerForm"
        Me.Text = "Timer"
        CType(Me.hourTensUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.hourOnesUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minTensUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minOnesUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents hourTensUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents hourOnesUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents minTensUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents minOnesUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents startButton As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlForm))
        Me.btn_Connect = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.freq = New System.Windows.Forms.TextBox()
        Me.FanOff = New System.Windows.Forms.RadioButton()
        Me.FanOn = New System.Windows.Forms.RadioButton()
        Me.fanPower = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.fanPower, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Connect
        '
        Me.btn_Connect.Location = New System.Drawing.Point(18, 21)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(191, 81)
        Me.btn_Connect.TabIndex = 0
        Me.btn_Connect.Text = "Connect"
        Me.btn_Connect.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fan Freq:"
        '
        'freq
        '
        Me.freq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.freq.Location = New System.Drawing.Point(155, 140)
        Me.freq.Name = "freq"
        Me.freq.Size = New System.Drawing.Size(178, 38)
        Me.freq.TabIndex = 2
        '
        'FanOff
        '
        Me.FanOff.AutoSize = True
        Me.FanOff.Checked = True
        Me.FanOff.Location = New System.Drawing.Point(483, 21)
        Me.FanOff.Name = "FanOff"
        Me.FanOff.Size = New System.Drawing.Size(146, 36)
        Me.FanOff.TabIndex = 3
        Me.FanOff.TabStop = True
        Me.FanOff.Text = "Fan Off"
        Me.FanOff.UseVisualStyleBackColor = True
        '
        'FanOn
        '
        Me.FanOn.AutoSize = True
        Me.FanOn.Location = New System.Drawing.Point(483, 66)
        Me.FanOn.Name = "FanOn"
        Me.FanOn.Size = New System.Drawing.Size(146, 36)
        Me.FanOn.TabIndex = 4
        Me.FanOn.Text = "Fan On"
        Me.FanOn.UseVisualStyleBackColor = True
        '
        'fanPower
        '
        Me.fanPower.Location = New System.Drawing.Point(12, 282)
        Me.fanPower.Name = "fanPower"
        Me.fanPower.Size = New System.Drawing.Size(617, 114)
        Me.fanPower.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 32)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "30%"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(541, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 32)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "100%"
        '
        'ControlForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 361)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.fanPower)
        Me.Controls.Add(Me.FanOn)
        Me.Controls.Add(Me.FanOff)
        Me.Controls.Add(Me.freq)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Connect)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ControlForm"
        Me.Text = "FanControl"
        CType(Me.fanPower, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Connect As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents freq As TextBox
    Friend WithEvents FanOff As RadioButton
    Friend WithEvents FanOn As RadioButton
    Friend WithEvents fanPower As TrackBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class

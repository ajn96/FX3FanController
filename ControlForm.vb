Imports System.IO
Imports System.Timers
Imports FX3Api

Public Class ControlForm

    Private WithEvents FX3 As FX3Connection
    Private updateState As Timer
    Private selectedPower As Double

    Private Sub ControlForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As String
        Try
            path = GetPathToFile("Resources\")
            FX3 = New FX3Connection(path, path, path)
        Catch ex As Exception
            MsgBox("Error loading resources! " + ex.Message)
            btn_Connect.Enabled = False
        End Try
        fanPower.Minimum = 30
        fanPower.Maximum = 100
        selectedPower = 0.5
        SetButtons(False)
        updateState = New Timers.Timer(500)
        updateState.Enabled = False
        updateState.AutoReset = False
        AddHandler updateState.Elapsed, New ElapsedEventHandler(AddressOf FanThreadWork)
    End Sub

    Private Sub btn_Connect_Click(sender As Object, e As EventArgs) Handles btn_Connect.Click
        Dim sn As String = ""

        If FX3.AvailableFX3s.Count > 0 Then
            sn = FX3.AvailableFX3s(0)
        ElseIf FX3.BusyFX3s.Count > 0 Then
            FX3.ResetAllFX3s()
            FX3.WaitForBoard(5)
            btn_Connect_Click(Nothing, Nothing)
        Else
            MsgBox("ERROR: No control board found!")
            Exit Sub
        End If

        Try
            FX3.Connect(sn)
        Catch ex As Exception
            MsgBox("Connection error occurred! " + ex.Message)
            Exit Sub
        End Try

        SetButtons(True)
        updateState.Enabled = True
        'put a pull up on tachy input
        FX3.SetPinResistorSetting(FX3.DIO2, FX3PinResistorSetting.PullUp)
    End Sub

    Private Sub SetButtons(active As Boolean)
        If active Then
            btn_Connect.Enabled = False
            FanOn.Enabled = True
            FanOn.Enabled = True
            fanPower.Enabled = True
            freq.Enabled = True
        Else
            btn_Connect.Enabled = True
            FanOn.Enabled = False
            FanOn.Enabled = False
            fanPower.Enabled = False
            freq.Enabled = False
        End If
    End Sub

    Private Sub DisconnectHandler() Handles FX3.UnexpectedDisconnect
        MsgBox("Board disconnected!")
        SetButtons(False)
    End Sub

    Private Sub FanOn_CheckedChanged(sender As Object, e As EventArgs) Handles FanOn.CheckedChanged
        If FanOn.Checked Then
            EnableFan()
            FanOff.Checked = False
        End If
    End Sub

    Private Sub FanOff_CheckedChanged(sender As Object, e As EventArgs) Handles FanOff.CheckedChanged
        If FanOff.Checked Then
            FanOn.Checked = False
            DisableFan()
        End If
    End Sub

    Private Sub DisableFan()
        'turn power off
        If Not IsNothing(FX3) Then FX3.DutSupplyMode = DutVoltage.Off
    End Sub

    Private Sub EnableFan()
        'turn power on
        If Not IsNothing(FX3) Then FX3.DutSupplyMode = DutVoltage.On5_0Volts
    End Sub

    Private Sub FanThreadWork()
        Dim mesfreq As Double

        updateState.Enabled = False
        mesfreq = GetFanFreq()
        Me.Invoke(New MethodInvoker(Sub() freq.Text = mesfreq.ToString() + "Hz"))
        SetTargetPower(selectedPower)
        updateState.Enabled = True
    End Sub

    Private Function GetFanFreq() As Double
        Dim rawFreq As Double
        Try
            rawFreq = FX3.MeasurePinFreq(FX3.DIO2, 1, 100, 20)
        Catch ex As Exception
            rawFreq = 0.0
        End Try
        If rawFreq = Double.PositiveInfinity Then
            Return 0.0
        End If
        Return rawFreq / 2.0
    End Function

    Private Sub SetTargetPower(power As Double)
        Static lastVal As Double = 0.0
        If power <> lastVal Then
            FX3.StartPWM(25000, power, FX3.DIO1)
            lastVal = power
        End If
    End Sub

    Private Function GetPathToFile(Name As String) As String
        Dim pathStr As String = System.AppDomain.CurrentDomain.BaseDirectory
        pathStr = Path.Combine(pathStr, Name)
        Return pathStr
    End Function

    Private Sub Shutdown() Handles Me.Closed
        updateState.Enabled = False
        If Not IsNothing(FX3) Then
            FX3.Disconnect()
        End If
    End Sub

    Private Sub fanPower_Scroll(sender As Object, e As EventArgs) Handles fanPower.Scroll
        selectedPower = fanPower.Value / (100.0)
        If selectedPower > 0.99 Then selectedPower = 0.99
    End Sub
End Class

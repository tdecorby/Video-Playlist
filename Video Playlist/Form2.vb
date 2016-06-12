Public Class Form2
    Public url As String
    Private f1 As Form1
    Private mon1 As Boolean
    Private mon2 As Boolean
    Private WithEvents timer1 As Timer

    Public Sub InitTimer()
        timer1 = New Timer()
        timer1.Interval = 500
        timer1.Start()
    End Sub
    Public Sub timer1_tick(sender As Object, e As EventArgs) Handles timer1.Tick
        If WMPlayer IsNot Nothing And WMPlayer.currentMedia IsNot Nothing Then
            f1.videoList.Rows(f1.currentIndex).Cells(3).Value = TimeSpan.FromSeconds(WMPlayer.Ctlcontrols.currentPosition).ToString("hh\:mm\:ss")
            If WMPlayer.playState = WMPLib.WMPPlayState.wmppsReady Then
                WMPlayer.Ctlcontrols.play()
            End If
        End If
    End Sub
    Public Sub sendFormData(f As Form1)
        f1 = f
    End Sub
    Private Sub on_load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitTimer()
        If Me.Location.X < (1920 - Me.Width / 2) Then
            mon1 = True
            mon2 = False
        Else
            mon2 = True
            mon1 = False
        End If
        Me.Name = "Video Player"
    End Sub

    Private Sub form2closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        timer1.Stop()
    End Sub

    Private Sub pauseFullscreen(sender As Object, e As AxWMPLib._WMPOCXEvents_KeyDownEvent) Handles WMPlayer.KeyDownEvent
        If Not WMPlayer.playState = WMPLib.WMPPlayState.wmppsTransitioning Then
            Select Case e.nKeyCode
                Case Keys.Space
                    If WMPlayer.Ctlcontrols.isAvailable("pause") Then
                        WMPlayer.Ctlcontrols.pause()
                    Else
                        WMPlayer.Ctlcontrols.play()
                    End If
                Case Keys.F
                    WMPlayer.fullScreen = If(WMPlayer.fullScreen, False, True)
                Case Keys.S
                    f1.playNext()
                Case Keys.A
                    f1.playPrev()
            End Select
        End If
    End Sub
    Public Sub play()
        WMPlayer.Ctlcontrols.play()
    End Sub
    Private Sub onMediaEnded(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles WMPlayer.PlayStateChange
        If e.newState = WMPLib.WMPPlayState.wmppsMediaEnded Then
            f1.playNext()
        End If

    End Sub

    Private Sub multimontiormove(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        'Console.WriteLine(Me.Location.ToString)
        If Me.Location.X > (1920 - Me.Width / 2) And mon1 Then
            refreshVideo()
            mon1 = False
            mon2 = True
        ElseIf Me.Location.X < (1920 - Me.Width / 2) And mon2 Then
            refreshVideo()
            mon2 = False
            mon1 = True
        End If

    End Sub

    Public Sub refreshVideo()
        Dim cp As Double = WMPlayer.Ctlcontrols.currentPosition
        WMPlayer.URL = WMPlayer.URL
        WMPlayer.Ctlcontrols.currentPosition = cp
    End Sub
End Class
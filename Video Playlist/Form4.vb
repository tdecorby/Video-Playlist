Public Class Form4
    Private f1 As Form1


    Public Sub setMedia(url As String)
        VlcControl1.SetMedia(New IO.FileInfo(url))
        VlcControl1.Play()
    End Sub

    Public Sub sendFormData(f As Form1)
        f1 = f
    End Sub

    Private Sub buttonPressed(sender As Object, e As KeyPressEventArgs) Handles VlcControl1.KeyPress
        Select Case Char.ToUpper(e.KeyChar)
            Case ChrW(Keys.Space)
                If VlcControl1.IsPlaying Then
                    VlcControl1.Pause()
                Else
                    VlcControl1.Play()
                End If
            Case ChrW(Keys.F)
                'WMPlayer.fullScreen = If(WMPlayer.fullScreen, False, True)
                'fs = WMPlayer.fullScreen
                'VlcControl1.f
            Case ChrW(Keys.S) 's
                f1.playNext()
            Case ChrW(Keys.A) 'a
                f1.playPrev()
        End Select
        e.Handled = True
    End Sub

    Private Sub updateProgressBar(sender As Object, e As Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs) Handles VlcControl1.TimeChanged
        If ProgressBar1.Maximum = VlcControl1.Length Then
            ProgressBar1.Value = VlcControl1.Time
            f1.videoList.Rows(f1.currentIndex).Cells(3).Value = TimeSpan.FromMilliseconds(VlcControl1.Time).ToString("hh\:mm\:ss")
        Else
            ProgressBar1.Maximum = VlcControl1.Length
        End If

    End Sub


    Private Sub setVideoValue(sender As Object, e As Vlc.DotNet.Core.VlcMediaPlayerMediaChangedEventArgs)

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.CheckForIllegalCrossThreadCalls = False
    End Sub
End Class

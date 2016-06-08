Public Class Form2
    Public con As WMPLib.IWMPControls3
    Public url As String
    Private f1 As Form1

    Private Sub playPausePlayback(sender As Object, e As PreviewKeyDownEventArgs) Handles WMPlayer.PreviewKeyDown
        If con.isAvailable("pause") And e.KeyCode = Keys.Space Then
            con.pause()
        Else
            con.play()
        End If
    End Sub

    Private Sub play_pause(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If con.isAvailable("pause") And e.KeyCode = Keys.Space Then
            con.pause()
        Else
            con.play()
        End If
    End Sub

    Private WithEvents timer1 As Timer
    Public Sub InitTimer()
        timer1 = New Timer()
        timer1.Interval = 1000
        timer1.Start()
    End Sub
    Public Sub timer1_tick(sender As Object, e As EventArgs) Handles timer1.Tick

        If WMPlayer IsNot Nothing And WMPlayer.currentMedia IsNot Nothing Then
            For Each row As DataGridViewRow In f1.videoList.Rows
                If row.Cells(0).Value.ToString() = WMPlayer.currentMedia.sourceURL() Then
                    row.Cells(3).Value = TimeSpan.FromSeconds(con.currentPosition).ToString("hh\:mm\:ss")
                    Exit For
                End If
            Next
        End If
    End Sub
    Public Sub sendSaveData(f As Form1)
        f1 = f
    End Sub
    Private Sub on_load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitTimer()
        con = WMPlayer.Ctlcontrols

    End Sub

    Private Sub form2closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        timer1.Stop()
    End Sub
End Class
Imports System.IO
Imports Newtonsoft.Json
Imports WMPLib

Public Structure settings
    Public lastopenedfile As String
End Structure


Public Class Form1

    Dim videoForm As New Form2
    Dim playlistSaveLoc As String
    Public currentIndex As Integer
    Public saveLoc As String = "C:\test2"


    Private Sub SetupDataGridView()

        Me.Controls.Add(videoList)

        videoList.ColumnCount = 5
        With videoList.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
        End With

        With videoList
            .Name = "videoList"
            .AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .GridColor = Color.Black
            .RowHeadersVisible = False


            .Columns(0).Name = "File Location"
            .Columns(0).Visible = False

            .Columns(1).Name = "File Name"
            .Columns(2).Name = "Length"
            .Columns(3).Name = "Watched"
            .Columns(4).Name = "beenWatched"
            .Columns(4).Visible = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            '.Dock = DockStyle.Fill
        End With

    End Sub


    Private Sub OpenButton_Click(sender As Object, e As EventArgs) Handles OpenVideo.Click
        With OpenFileDialog
            .Filter = "All Files (*.*)|*.*|*AVI|*avi|*MP4|*mp4|*MKV|*mkv"
            .ShowDialog()
            videoForm.Show()
            videoForm.WMPlayer.URL = OpenFileDialog.FileName
        End With
    End Sub

    Private Sub NewPlayist_Click(sender As Object, e As EventArgs) Handles NewPlayist.Click
        Dim plname As String = "NewPlaylist"

        Dim playlistNameDialog As Form3
        playlistNameDialog = New Form3()
        playlistNameDialog.StartPosition = FormStartPosition.CenterParent

        If playlistNameDialog.ShowDialog(Me) = DialogResult.OK Then
            If playlistNameDialog.answer IsNot "" Then
                plname = playlistNameDialog.answer
            End If
            PlaylistName.Text = plname

            With OpenFileDialog
                .Filter = "All Files (*.*)|*.*|*AVI|*avi|*MP4|*mp4|*MKV|*mkv"
                .Multiselect = True
                .ShowDialog()

                videoList.Rows.Clear()
                Dim t As TimeSpan
                For Each filename As String In OpenFileDialog.FileNames
                    If My.Computer.FileSystem.FileExists(filename) Then
                        Dim wmp As WindowsMediaPlayer = New WindowsMediaPlayer
                        Dim mediainfo As IWMPMedia = wmp.newMedia(filename)
                        t = TimeSpan.FromSeconds(mediainfo.duration)
                    End If

                    Dim time = t.Hours.ToString.PadLeft(2, "0"c) & ":" &
                        t.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                        t.Seconds.ToString.PadLeft(2, "0"c)

                    videoList.Rows.Add(filename, Path.GetFileName(filename), time, "00:00:00", "False")
                Next



            End With

            savePlaylist(videoList, PlaylistName.Text, saveLoc)
            saveSettings()
        End If

    End Sub

    Public Sub savePlaylist(dgv As DataGridView, playlistName As String, saveLoc As String)
        Dim playlist As New Dictionary(Of String, String())
        For Each row As DataGridViewRow In dgv.Rows
            playlist.Add(row.Cells(0).Value, New String() {row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value})
        Next
        File.WriteAllText(saveLoc + "\" + playlistName + ".json", JsonConvert.SerializeObject(playlist))
    End Sub

    Private Sub saveSettings()
        Dim setting As New settings
        setting.lastopenedfile = PlaylistName.Text
        File.WriteAllText(saveLoc + "\settings.json", JsonConvert.SerializeObject(setting))
    End Sub

    Private Sub onformLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        If My.Computer.FileSystem.FileExists(saveLoc + "/settings.json") Then
            Dim setting As settings = JsonConvert.DeserializeObject(Of settings)(File.ReadAllText(saveLoc + "\settings.json"))
            If My.Computer.FileSystem.FileExists(saveLoc + "/" + setting.lastopenedfile + ".json") Then
                loadPlaylistFromFile(saveLoc + "\" + setting.lastopenedfile + ".json")
            End If
        End If

    End Sub
    Private Sub getNextVideo()
        For Each row As DataGridViewRow In videoList.Rows
            If row.Cells(4).Value.ToString() = "False" Then
                currentIndex = row.Index
                Exit Sub
            End If
        Next
    End Sub
    Private Sub ContinuePlaylist_Click(sender As Object, e As EventArgs) Handles ContinuePlaylist.Click
        getNextVideo()
        If videoList.Rows(currentIndex).Cells(4).Value.ToString() = "False" Then
            If Not videoForm.Visible Or videoForm.IsDisposed Then
                videoForm = New Form2
                videoForm.sendFormData(Me)
                videoForm.Location = Me.Location
                videoForm.Show()
            End If
            videoForm.WMPlayer.URL = videoList.Rows(currentIndex).Cells(0).Value
            videoForm.WMPlayer.Ctlcontrols.currentPosition = TimeSpan.Parse(videoList.Rows(currentIndex).Cells(3).Value).TotalSeconds()
            videoList.Rows(currentIndex).Cells(1).Style.ForeColor = Color.Blue
            videoList.Rows(currentIndex).Cells(2).Style.ForeColor = Color.Blue
            videoList.Rows(currentIndex).Cells(3).Style.ForeColor = Color.Blue
            Exit Sub
        End If


    End Sub

    Private Sub OpenPlaylist_Click(sender As Object, e As EventArgs) Handles OpenPlaylist.Click
        With OpenFileDialog
            .Filter = "All Files (*.*)|*.*|Json|*.json"
            .Multiselect = False
            .InitialDirectory = saveLoc

            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                savePlaylist(videoList, PlaylistName.Text, saveLoc)
                loadPlaylistFromFile(OpenFileDialog.FileName)
            End If

        End With
    End Sub

    Private Sub loadPlaylistFromFile(filepath As String)
        videoList.Rows.Clear()
        PlaylistName.Text = System.IO.Path.GetFileNameWithoutExtension(filepath)
        For Each item As KeyValuePair(Of String, String()) In JsonConvert.DeserializeObject(Of Dictionary(Of String, String()))(File.ReadAllText(filepath))
            videoList.Rows.Add(item.Key, item.Value(0), item.Value(1), item.Value(2), item.Value(3))
        Next
        For Each row As DataGridViewRow In videoList.Rows
            If row.Cells(4).Value.ToString() = "True" Then
                row.Cells(1).Style.ForeColor = Color.Silver
                row.Cells(2).Style.ForeColor = Color.Silver
                row.Cells(3).Style.ForeColor = Color.Silver
            End If
        Next
        saveSettings()
    End Sub

    Private Sub saveBeforeClose(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        savePlaylist(videoList, PlaylistName.Text, saveLoc)
    End Sub

    Public Sub playNext()
        videoList.Rows(currentIndex).Cells(4).Value = "True"
        videoList.Rows(currentIndex).Cells(1).Style.ForeColor = Color.Silver
        videoList.Rows(currentIndex).Cells(2).Style.ForeColor = Color.Silver
        videoList.Rows(currentIndex).Cells(3).Style.ForeColor = Color.Silver
        currentIndex += 1
        If Not videoForm.Visible Or videoForm.IsDisposed Then
            videoForm = New Form2
            videoForm.Location = Me.Location
            videoForm.sendFormData(Me)
            videoForm.Show()
        End If
        videoForm.WMPlayer.URL = videoList.Rows(currentIndex).Cells(0).Value
        videoForm.WMPlayer.Ctlcontrols.currentPosition = TimeSpan.Parse(videoList.Rows(currentIndex).Cells(3).Value).TotalSeconds()
        videoList.Rows(currentIndex).Cells(1).Style.ForeColor = Color.Blue
        videoList.Rows(currentIndex).Cells(2).Style.ForeColor = Color.Blue
        videoList.Rows(currentIndex).Cells(3).Style.ForeColor = Color.Blue

        savePlaylist(videoList, PlaylistName.Text, saveLoc)
    End Sub
    Public Sub playPrev()
        videoList.Rows(currentIndex).Cells(4).Value = "False"
        videoList.Rows(currentIndex).Cells(1).Style.ForeColor = Color.Black
        videoList.Rows(currentIndex).Cells(2).Style.ForeColor = Color.Black
        videoList.Rows(currentIndex).Cells(3).Style.ForeColor = Color.Black
        currentIndex -= 1
        If Not videoForm.Visible Or videoForm.IsDisposed Then
            videoForm = New Form2
            videoForm.Location = Me.Location
            videoForm.sendFormData(Me)
            videoForm.Show()
        End If
        videoForm.WMPlayer.URL = videoList.Rows(currentIndex).Cells(0).Value
        If TimeSpan.Parse(videoList.Rows(currentIndex).Cells(3).Value).TotalSeconds() = TimeSpan.Parse(videoList.Rows(currentIndex).Cells(2).Value).TotalSeconds() Then
            videoList.Rows(currentIndex).Cells(3).Value = "00:00:00"
        End If
        videoForm.WMPlayer.Ctlcontrols.currentPosition = TimeSpan.Parse(videoList.Rows(currentIndex).Cells(3).Value).TotalSeconds()
        videoList.Rows(currentIndex).Cells(4).Value = "False"
        videoList.Rows(currentIndex).Cells(1).Style.ForeColor = Color.Blue
        videoList.Rows(currentIndex).Cells(2).Style.ForeColor = Color.Blue
        videoList.Rows(currentIndex).Cells(3).Style.ForeColor = Color.Blue

        savePlaylist(videoList, PlaylistName.Text, saveLoc)
    End Sub
    Public Sub refreshVideo()
        videoForm.WMPlayer.URL = videoList.Rows(currentIndex).Cells(0).Value
        videoForm.WMPlayer.Ctlcontrols.currentPosition = TimeSpan.Parse(videoList.Rows(currentIndex).Cells(3).Value).TotalSeconds()
    End Sub
    Private Sub DeletePlayist_Click(sender As Object, e As EventArgs) Handles DeletePlayist.Click
        Dim deletePlaylist As deleteConfim
        deletePlaylist = New deleteConfim()
        deletePlaylist.StartPosition = FormStartPosition.CenterParent
        deletePlaylist.question = "Are you sure you want to delete the Playlist '" + PlaylistName.Text + "'?"
        If deletePlaylist.ShowDialog(Me) = DialogResult.Yes Then
            My.Computer.FileSystem.DeleteFile(saveLoc + "/" + PlaylistName.Text + ".json",
                Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin)
            videoList.Rows.Clear()
            PlaylistName.Text = ""
        End If
    End Sub
End Class

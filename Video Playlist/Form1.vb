Imports System.IO
Imports Newtonsoft.Json
Imports WMPLib

Public Structure settings
    Public lastOpenedPlaylist As String
    Public lastOpenedFileLoc As String
End Structure


Public Class Form1

    Private setting As New settings
    Private videoForm As New Form2
    Public currentIndex As Integer
    Private saveLoc As String = "C:\test2"
    Private lastOpenedLocation As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    Private playlistLoaded As Boolean = False


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
        With OpenVideoFiles
            .Filter = "All Files (*.*)|*.*|*AVI|*avi|*MP4|*mp4|*MKV|*mkv"
            .ShowDialog()
            videoForm.Show()
            videoForm.WMPlayer.URL = OpenVideoFiles.FileName
        End With
    End Sub

    Private Sub NewPlayist_Click(sender As Object, e As EventArgs) Handles NewPlayist.Click
        If playlistLoaded Then
            savePlaylist(videoList, PlaylistName.Text, saveLoc)
        End If
        createNewPlaylist()
    End Sub
    Private Sub createNewPlaylist()
        Dim plname As String = "NewPlaylist"

        Dim playlistNameDialog As Form3
        playlistNameDialog = New Form3()
        playlistNameDialog.StartPosition = FormStartPosition.CenterParent

        If playlistNameDialog.ShowDialog(Me) = DialogResult.OK Then
            If playlistNameDialog.answer IsNot "" Then
                plname = playlistNameDialog.answer
            End If
            PlaylistName.Text = plname
            videoList.Rows.Clear()
            addVideosToList()
            playlistLoaded = True
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
        setting.lastOpenedPlaylist = PlaylistName.Text
        File.WriteAllText(saveLoc + "\settings.json", JsonConvert.SerializeObject(setting))
    End Sub

    Private Sub onformLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        If My.Computer.FileSystem.FileExists(saveLoc + "/settings.json") Then
            setting = JsonConvert.DeserializeObject(Of settings)(File.ReadAllText(saveLoc + "\settings.json"))
            If My.Computer.FileSystem.FileExists(saveLoc + "/" + setting.lastOpenedPlaylist + ".json") Then
                loadPlaylistFromFile(saveLoc + "\" + setting.lastOpenedPlaylist + ".json")
            End If
            If Not My.Computer.FileSystem.DirectoryExists(setting.lastOpenedFileLoc) Then
                setting.lastOpenedFileLoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
        End If

    End Sub
    Private Function getNextVideo()
        For Each row As DataGridViewRow In videoList.Rows
            If row.Cells(4).Value.ToString() = "False" And row.Cells(1).Style.ForeColor <> Color.Red Then
                currentIndex = row.Index
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub ContinuePlaylist_Click(sender As Object, e As EventArgs) Handles ContinuePlaylist.Click
        If playlistLoaded Then
            If getNextVideo() Then
                playFile(videoList.Rows(currentIndex).Cells(0).Value, TimeSpan.Parse(videoList.Rows(currentIndex).Cells(3).Value).TotalSeconds())
                colorRow(currentIndex, Color.Blue)
            Else
                MessageBox.Show("Playlist ended")
            End If
        End If
    End Sub
    Private Sub colorRow(index As Integer, color As Color)
        videoList.Rows(index).Cells(1).Style.ForeColor = color
        videoList.Rows(index).Cells(2).Style.ForeColor = color
        videoList.Rows(index).Cells(3).Style.ForeColor = color
        videoList.Rows(index).Cells(1).Style.SelectionForeColor = color
        videoList.Rows(index).Cells(2).Style.SelectionForeColor = color
        videoList.Rows(index).Cells(3).Style.SelectionForeColor = color
    End Sub

    Private Sub OpenPlaylist_Click(sender As Object, e As EventArgs) Handles OpenPlaylist.Click
        With openSystemfiles
            .Filter = "All Files (*.*)|*.*|Json|*.json"
            .Multiselect = False
            .InitialDirectory = saveLoc

            If openSystemfiles.ShowDialog() = DialogResult.OK Then
                If playlistLoaded Then
                    savePlaylist(videoList, PlaylistName.Text, saveLoc)
                End If
                loadPlaylistFromFile(openSystemfiles.FileName)
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
                colorRow(row.Index, Color.Silver)
            End If
            If Not My.Computer.FileSystem.FileExists(row.Cells(0).Value) Then
                colorRow(row.Index, Color.Red)
            End If
        Next
        saveSettings()
        playlistLoaded = True
    End Sub

    Private Sub saveBeforeClose(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If playlistLoaded Then
            savePlaylist(videoList, PlaylistName.Text, saveLoc)
        End If
    End Sub

    Public Sub playNext()
        If playlistLoaded Then
            Dim brokenLink As Boolean = False
            If currentIndex < videoList.RowCount - 1 Then
                Dim index As Integer = currentIndex
                Do
                    index += 1
                    If videoList.Rows(index).Cells(1).Style.ForeColor = Color.Red Then
                        brokenLink = True
                    Else
                        brokenLink = False
                        Exit Do
                    End If
                Loop Until index = videoList.RowCount - 1
                savePlaylist(videoList, PlaylistName.Text, saveLoc)

                If index < videoList.RowCount And Not brokenLink Then
                    videoList.Rows(currentIndex).Cells(4).Value = "True"
                    colorRow(currentIndex, Color.Silver)
                    currentIndex = index
                    playFile(videoList.Rows(currentIndex).Cells(0).Value, TimeSpan.Parse(videoList.Rows(currentIndex).Cells(3).Value).TotalSeconds())
                    colorRow(currentIndex, Color.Blue)
                Else
                    MessageBox.Show("You are at the end of the Playlist")
                End If
            Else
                videoForm.Close()
                MessageBox.Show("You are at the end of the Playlist")
            End If
        End If
    End Sub
    Public Sub playPrev()
        If playlistLoaded Then
            Dim brokenLink As Boolean = False
            If currentIndex - 1 >= 0 Then
                Dim index As Integer = currentIndex
                Do
                    index -= 1
                    If videoList.Rows(index).Cells(1).Style.ForeColor = Color.Red Then
                        brokenLink = True
                    Else
                        brokenLink = False
                        Exit Do
                    End If
                Loop Until index = 0
                savePlaylist(videoList, PlaylistName.Text, saveLoc)

                If index >= 0 And Not brokenLink Then
                    videoList.Rows(currentIndex).Cells(4).Value = "False"
                    colorRow(currentIndex, Color.Black)
                    currentIndex = index
                    If TimeSpan.Parse(videoList.Rows(currentIndex).Cells(3).Value).TotalSeconds() = TimeSpan.Parse(videoList.Rows(currentIndex).Cells(2).Value).TotalSeconds() Then
                        videoList.Rows(currentIndex).Cells(3).Value = "00:00:00"
                    End If
                    videoList.Rows(currentIndex).Cells(4).Value = "False"
                    playFile(videoList.Rows(currentIndex).Cells(0).Value, TimeSpan.Parse(videoList.Rows(currentIndex).Cells(3).Value).TotalSeconds())
                    colorRow(currentIndex, Color.Blue)
                Else
                    MessageBox.Show("You are at the start of the playlist")
                End If
            Else
                MessageBox.Show("You are at the start of the playlist")
            End If
        End If
    End Sub
    Private Sub DeletePlayist_Click(sender As Object, e As EventArgs) Handles DeletePlayist.Click
        If playlistLoaded Then
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
                playlistLoaded = False
            End If
        End If
    End Sub

    Private Sub AddVideos_Click(sender As Object, e As EventArgs) Handles AddVideos.Click
        If playlistLoaded Then
            addVideosToList()
        Else
            createNewPlaylist()
        End If
    End Sub
    Private Sub addVideosToList()
        With OpenVideoFiles
            .Filter = "All Files (*.*)|*.*|*AVI|*avi|*MP4|*mp4|*MKV|*mkv"
            .Multiselect = True
            .InitialDirectory = setting.lastOpenedFileLoc
            If OpenVideoFiles.ShowDialog() = DialogResult.OK Then
                setting.lastOpenedFileLoc = Path.GetDirectoryName(OpenVideoFiles.FileName)

                Dim t As TimeSpan
                For Each filename As String In OpenVideoFiles.FileNames
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
            End If
        End With

        savePlaylist(videoList, PlaylistName.Text, saveLoc)
        saveSettings()
    End Sub

    Private Sub StartPlaylistFromBeg_Click(sender As Object, e As EventArgs) Handles StartPlaylistFromBeg.Click
        If playlistLoaded Then
            currentIndex = 0
            For Each row As DataGridViewRow In videoList.Rows
                If row.Cells(1).Style.ForeColor <> Color.Red Then
                    row.Cells(4).Value = "False"
                    row.Cells(3).Value = "00:00:00"
                    colorRow(row.Index, Color.Black)
                End If
            Next
            For Each row As DataGridViewRow In videoList.Rows
                If row.Cells(1).Style.ForeColor <> Color.Red Then
                    Exit For
                End If
                currentIndex += 1
            Next
            playFile(videoList.Rows(currentIndex).Cells(0).Value, TimeSpan.Parse(videoList.Rows(currentIndex).Cells(3).Value).TotalSeconds())
            colorRow(currentIndex, Color.Blue)
        End If
    End Sub
    Private Sub playFile(url As String, time As Double)
        If Not videoForm.Visible Or videoForm.IsDisposed Then
            videoForm = New Form2
            videoForm.sendFormData(Me)
            videoForm.Location = Me.Location
            videoForm.Show()
        End If
        videoForm.WMPlayer.URL = url
        videoForm.WMPlayer.Ctlcontrols.currentPosition = time
    End Sub
End Class

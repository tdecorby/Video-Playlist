Imports System.IO
Imports Newtonsoft.Json
Imports WMPLib

Public Structure settings
    Public lastopenedfile As String
End Structure


Public Class Form1

    Dim videoForm As New Form2
    Dim playlistSaveLoc As String
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

                    videoList.Rows.Add(filename, Path.GetFileName(filename), time, "0", "False")
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
            loadPlaylistFromFile(saveLoc + "\" + setting.lastopenedfile + ".json")
        End If

    End Sub

    Private Sub ContinuePlaylist_Click(sender As Object, e As EventArgs) Handles ContinuePlaylist.Click
        Dim filename = ""

        For Each row As DataGridViewRow In videoList.Rows
            If row.Cells(4).Value.ToString() = "False" Then
                'If videoForm Is Nothing Then
                videoForm = New Form2
                'End If
                videoForm.Show()
                videoForm.sendSaveData(Me)
                videoForm.WMPlayer.URL = row.Cells(0).Value
                videoForm.con.currentPosition = row.Cells(3).Value

                Exit Sub

            End If
        Next


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
        saveSettings()
    End Sub

    Private Sub saveBeforeClose(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        savePlaylist(videoList, PlaylistName.Text, saveLoc)
    End Sub
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.openSystemfiles = New System.Windows.Forms.OpenFileDialog()
        Me.videoList = New System.Windows.Forms.DataGridView()
        Me.VideoListContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PlayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToBottomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToggleWatchedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetWatchedTo0ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContinuePlaylist = New System.Windows.Forms.Button()
        Me.NewPlayist = New System.Windows.Forms.Button()
        Me.OpenPlaylist = New System.Windows.Forms.Button()
        Me.AddVideos = New System.Windows.Forms.Button()
        Me.StartPlaylistFromBeg = New System.Windows.Forms.Button()
        Me.DeletePlayist = New System.Windows.Forms.Button()
        Me.PlaylistName = New System.Windows.Forms.Label()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenVideoFiles = New System.Windows.Forms.OpenFileDialog()
        Me.WatchedRatio = New System.Windows.Forms.Label()
        Me.TimeLeft = New System.Windows.Forms.Label()
        CType(Me.videoList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VideoListContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'openSystemfiles
        '
        Me.openSystemfiles.FileName = "openSystemfiles"
        '
        'videoList
        '
        Me.videoList.AllowUserToAddRows = False
        Me.videoList.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.videoList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.videoList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.videoList.ContextMenuStrip = Me.VideoListContextMenu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.videoList.DefaultCellStyle = DataGridViewCellStyle2
        Me.videoList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.videoList.Location = New System.Drawing.Point(166, 41)
        Me.videoList.Name = "videoList"
        Me.videoList.Size = New System.Drawing.Size(578, 446)
        Me.videoList.TabIndex = 4
        '
        'VideoListContextMenu
        '
        Me.VideoListContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayToolStripMenuItem, Me.MoveUpToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToggleWatchedToolStripMenuItem, Me.SetWatchedTo0ToolStripMenuItem})
        Me.VideoListContextMenu.Name = "VideoListContextMenu"
        Me.VideoListContextMenu.Size = New System.Drawing.Size(164, 114)
        '
        'PlayToolStripMenuItem
        '
        Me.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem"
        Me.PlayToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.PlayToolStripMenuItem.Text = "Play"
        '
        'MoveUpToolStripMenuItem
        '
        Me.MoveUpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpToolStripMenuItem, Me.DownToolStripMenuItem, Me.ToTopToolStripMenuItem, Me.ToBottomToolStripMenuItem})
        Me.MoveUpToolStripMenuItem.Name = "MoveUpToolStripMenuItem"
        Me.MoveUpToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.MoveUpToolStripMenuItem.Text = "Move..."
        '
        'UpToolStripMenuItem
        '
        Me.UpToolStripMenuItem.Name = "UpToolStripMenuItem"
        Me.UpToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.UpToolStripMenuItem.Text = "Up"
        '
        'DownToolStripMenuItem
        '
        Me.DownToolStripMenuItem.Name = "DownToolStripMenuItem"
        Me.DownToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.DownToolStripMenuItem.Text = "Down"
        '
        'ToTopToolStripMenuItem
        '
        Me.ToTopToolStripMenuItem.Name = "ToTopToolStripMenuItem"
        Me.ToTopToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.ToTopToolStripMenuItem.Text = "To Top"
        '
        'ToBottomToolStripMenuItem
        '
        Me.ToBottomToolStripMenuItem.Name = "ToBottomToolStripMenuItem"
        Me.ToBottomToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.ToBottomToolStripMenuItem.Text = "To Bottom"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToggleWatchedToolStripMenuItem
        '
        Me.ToggleWatchedToolStripMenuItem.Name = "ToggleWatchedToolStripMenuItem"
        Me.ToggleWatchedToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ToggleWatchedToolStripMenuItem.Text = "Toggle Watched"
        '
        'SetWatchedTo0ToolStripMenuItem
        '
        Me.SetWatchedTo0ToolStripMenuItem.Name = "SetWatchedTo0ToolStripMenuItem"
        Me.SetWatchedTo0ToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.SetWatchedTo0ToolStripMenuItem.Text = "Set Watched to 0"
        '
        'ContinuePlaylist
        '
        Me.ContinuePlaylist.Location = New System.Drawing.Point(12, 41)
        Me.ContinuePlaylist.Name = "ContinuePlaylist"
        Me.ContinuePlaylist.Size = New System.Drawing.Size(138, 23)
        Me.ContinuePlaylist.TabIndex = 5
        Me.ContinuePlaylist.Text = "Continue Playlist"
        Me.ContinuePlaylist.UseVisualStyleBackColor = True
        '
        'NewPlayist
        '
        Me.NewPlayist.Location = New System.Drawing.Point(12, 111)
        Me.NewPlayist.Name = "NewPlayist"
        Me.NewPlayist.Size = New System.Drawing.Size(138, 23)
        Me.NewPlayist.TabIndex = 6
        Me.NewPlayist.Text = "New Playlist"
        Me.NewPlayist.UseVisualStyleBackColor = True
        '
        'OpenPlaylist
        '
        Me.OpenPlaylist.Location = New System.Drawing.Point(13, 140)
        Me.OpenPlaylist.Name = "OpenPlaylist"
        Me.OpenPlaylist.Size = New System.Drawing.Size(137, 23)
        Me.OpenPlaylist.TabIndex = 7
        Me.OpenPlaylist.Text = "Open Playlist"
        Me.OpenPlaylist.UseVisualStyleBackColor = True
        '
        'AddVideos
        '
        Me.AddVideos.Location = New System.Drawing.Point(12, 169)
        Me.AddVideos.Name = "AddVideos"
        Me.AddVideos.Size = New System.Drawing.Size(137, 23)
        Me.AddVideos.TabIndex = 8
        Me.AddVideos.Text = "Add Videos"
        Me.AddVideos.UseVisualStyleBackColor = True
        '
        'StartPlaylistFromBeg
        '
        Me.StartPlaylistFromBeg.Location = New System.Drawing.Point(12, 70)
        Me.StartPlaylistFromBeg.Name = "StartPlaylistFromBeg"
        Me.StartPlaylistFromBeg.Size = New System.Drawing.Size(137, 34)
        Me.StartPlaylistFromBeg.TabIndex = 9
        Me.StartPlaylistFromBeg.Text = "Start Playlist from Beginning"
        Me.StartPlaylistFromBeg.UseVisualStyleBackColor = True
        '
        'DeletePlayist
        '
        Me.DeletePlayist.Location = New System.Drawing.Point(12, 198)
        Me.DeletePlayist.Name = "DeletePlayist"
        Me.DeletePlayist.Size = New System.Drawing.Size(137, 23)
        Me.DeletePlayist.TabIndex = 10
        Me.DeletePlayist.Text = "Delete Playlist"
        Me.DeletePlayist.UseVisualStyleBackColor = True
        '
        'PlaylistName
        '
        Me.PlaylistName.AutoSize = True
        Me.PlaylistName.Location = New System.Drawing.Point(173, 15)
        Me.PlaylistName.Name = "PlaylistName"
        Me.PlaylistName.Size = New System.Drawing.Size(70, 13)
        Me.PlaylistName.TabIndex = 12
        Me.PlaylistName.Text = "Playlist Name"
        '
        'OpenVideoFiles
        '
        Me.OpenVideoFiles.FileName = "OpenVideoFiles"
        '
        'WatchedRatio
        '
        Me.WatchedRatio.AutoSize = True
        Me.WatchedRatio.Location = New System.Drawing.Point(372, 15)
        Me.WatchedRatio.Name = "WatchedRatio"
        Me.WatchedRatio.Size = New System.Drawing.Size(76, 13)
        Me.WatchedRatio.TabIndex = 13
        Me.WatchedRatio.Text = "WatchedRatio"
        '
        'TimeLeft
        '
        Me.TimeLeft.AutoSize = True
        Me.TimeLeft.Location = New System.Drawing.Point(498, 15)
        Me.TimeLeft.Name = "TimeLeft"
        Me.TimeLeft.Size = New System.Drawing.Size(48, 13)
        Me.TimeLeft.TabIndex = 14
        Me.TimeLeft.Text = "TimeLeft"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 499)
        Me.Controls.Add(Me.TimeLeft)
        Me.Controls.Add(Me.WatchedRatio)
        Me.Controls.Add(Me.PlaylistName)
        Me.Controls.Add(Me.DeletePlayist)
        Me.Controls.Add(Me.StartPlaylistFromBeg)
        Me.Controls.Add(Me.AddVideos)
        Me.Controls.Add(Me.ContinuePlaylist)
        Me.Controls.Add(Me.NewPlayist)
        Me.Controls.Add(Me.OpenPlaylist)
        Me.Controls.Add(Me.videoList)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.MinimumSize = New System.Drawing.Size(772, 538)
        Me.Name = "Form1"
        Me.Text = "Video Playlist"
        CType(Me.videoList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VideoListContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents openSystemfiles As OpenFileDialog
    Friend WithEvents ContinuePlaylist As Button
    Friend WithEvents NewPlayist As Button
    Friend WithEvents OpenPlaylist As Button
    Friend WithEvents AddVideos As Button
    Friend WithEvents StartPlaylistFromBeg As Button
    Friend WithEvents DeletePlayist As Button
    Friend WithEvents PlaylistName As Label
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents OpenVideoFiles As OpenFileDialog
    Friend WithEvents WatchedRatio As Label
    Friend WithEvents TimeLeft As Label
    Friend WithEvents VideoListContextMenu As ContextMenuStrip
    Friend WithEvents PlayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MoveUpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToTopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToBottomToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToggleWatchedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetWatchedTo0ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents videoList As DataGridView
End Class

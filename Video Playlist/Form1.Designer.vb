<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.OpenVideo = New System.Windows.Forms.Button()
        Me.openSystemfiles = New System.Windows.Forms.OpenFileDialog()
        Me.videoList = New System.Windows.Forms.DataGridView()
        Me.ContinuePlaylist = New System.Windows.Forms.Button()
        Me.NewPlayist = New System.Windows.Forms.Button()
        Me.OpenPlaylist = New System.Windows.Forms.Button()
        Me.AddVideos = New System.Windows.Forms.Button()
        Me.StartPlaylistFromBeg = New System.Windows.Forms.Button()
        Me.DeletePlayist = New System.Windows.Forms.Button()
        Me.PlaylistName = New System.Windows.Forms.Label()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenVideoFiles = New System.Windows.Forms.OpenFileDialog()
        CType(Me.videoList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenVideo
        '
        Me.OpenVideo.Location = New System.Drawing.Point(12, 12)
        Me.OpenVideo.Name = "OpenVideo"
        Me.OpenVideo.Size = New System.Drawing.Size(138, 23)
        Me.OpenVideo.TabIndex = 3
        Me.OpenVideo.Text = "Open Video"
        Me.OpenVideo.UseVisualStyleBackColor = True
        '
        'openSystemfiles
        '
        Me.openSystemfiles.FileName = "openSystemfiles"
        '
        'videoList
        '
        Me.videoList.AllowUserToAddRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.videoList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.videoList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.videoList.DefaultCellStyle = DataGridViewCellStyle4
        Me.videoList.Location = New System.Drawing.Point(166, 41)
        Me.videoList.Name = "videoList"
        Me.videoList.Size = New System.Drawing.Size(578, 446)
        Me.videoList.TabIndex = 4
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
        Me.NewPlayist.Location = New System.Drawing.Point(12, 70)
        Me.NewPlayist.Name = "NewPlayist"
        Me.NewPlayist.Size = New System.Drawing.Size(138, 23)
        Me.NewPlayist.TabIndex = 6
        Me.NewPlayist.Text = "New Playlist"
        Me.NewPlayist.UseVisualStyleBackColor = True
        '
        'OpenPlaylist
        '
        Me.OpenPlaylist.Location = New System.Drawing.Point(12, 99)
        Me.OpenPlaylist.Name = "OpenPlaylist"
        Me.OpenPlaylist.Size = New System.Drawing.Size(137, 23)
        Me.OpenPlaylist.TabIndex = 7
        Me.OpenPlaylist.Text = "Open Playlist"
        Me.OpenPlaylist.UseVisualStyleBackColor = True
        '
        'AddVideos
        '
        Me.AddVideos.Location = New System.Drawing.Point(12, 128)
        Me.AddVideos.Name = "AddVideos"
        Me.AddVideos.Size = New System.Drawing.Size(137, 23)
        Me.AddVideos.TabIndex = 8
        Me.AddVideos.Text = "Add Videos"
        Me.AddVideos.UseVisualStyleBackColor = True
        '
        'StartPlaylistFromBeg
        '
        Me.StartPlaylistFromBeg.Location = New System.Drawing.Point(12, 158)
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 499)
        Me.Controls.Add(Me.PlaylistName)
        Me.Controls.Add(Me.DeletePlayist)
        Me.Controls.Add(Me.StartPlaylistFromBeg)
        Me.Controls.Add(Me.AddVideos)
        Me.Controls.Add(Me.OpenVideo)
        Me.Controls.Add(Me.ContinuePlaylist)
        Me.Controls.Add(Me.NewPlayist)
        Me.Controls.Add(Me.OpenPlaylist)
        Me.Controls.Add(Me.videoList)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.MinimumSize = New System.Drawing.Size(772, 538)
        Me.Name = "Form1"
        Me.Text = "Video Playlist"
        CType(Me.videoList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenVideo As Button
    Friend WithEvents openSystemfiles As OpenFileDialog
    Friend WithEvents videoList As DataGridView
    Friend WithEvents ContinuePlaylist As Button
    Friend WithEvents NewPlayist As Button
    Friend WithEvents OpenPlaylist As Button
    Friend WithEvents AddVideos As Button
    Friend WithEvents StartPlaylistFromBeg As Button
    Friend WithEvents DeletePlayist As Button
    Friend WithEvents PlaylistName As Label
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents OpenVideoFiles As OpenFileDialog
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.WMPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        CType(Me.WMPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WMPlayer
        '
        Me.WMPlayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WMPlayer.Enabled = True
        Me.WMPlayer.Location = New System.Drawing.Point(0, 0)
        Me.WMPlayer.Name = "WMPlayer"
        Me.WMPlayer.OcxState = CType(resources.GetObject("WMPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.WMPlayer.Size = New System.Drawing.Size(430, 330)
        Me.WMPlayer.TabIndex = 0
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 330)
        Me.Controls.Add(Me.WMPlayer)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.WMPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WMPlayer As AxWMPLib.AxWindowsMediaPlayer
End Class

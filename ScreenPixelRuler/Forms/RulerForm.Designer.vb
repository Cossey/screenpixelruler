<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RulerForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RulerForm))
        Me.tmrPosition = New System.Windows.Forms.Timer(Me.components)
        Me.RulerMenu = New System.Windows.Forms.ContextMenu()
        Me.MenuOptions = New System.Windows.Forms.MenuItem()
        Me.MenuAbout = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuExit = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'tmrPosition
        '
        Me.tmrPosition.Enabled = True
        Me.tmrPosition.Interval = 30
        '
        'RulerMenu
        '
        Me.RulerMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuOptions, Me.MenuAbout, Me.MenuItem3, Me.MenuExit})
        resources.ApplyResources(Me.RulerMenu, "RulerMenu")
        '
        'MenuOptions
        '
        resources.ApplyResources(Me.MenuOptions, "MenuOptions")
        Me.MenuOptions.Index = 0
        '
        'MenuAbout
        '
        resources.ApplyResources(Me.MenuAbout, "MenuAbout")
        Me.MenuAbout.Index = 1
        '
        'MenuItem3
        '
        resources.ApplyResources(Me.MenuItem3, "MenuItem3")
        Me.MenuItem3.Index = 2
        '
        'MenuExit
        '
        resources.ApplyResources(Me.MenuExit, "MenuExit")
        Me.MenuExit.Index = 3
        '
        'RulerForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RulerForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tmrPosition As Timer
    Friend WithEvents RulerMenu As ContextMenu
    Friend WithEvents MenuOptions As MenuItem
    Friend WithEvents MenuAbout As MenuItem
    Friend WithEvents MenuItem3 As MenuItem
    Friend WithEvents MenuExit As MenuItem
End Class

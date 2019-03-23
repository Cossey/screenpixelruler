<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsForm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LanguageLabel = New System.Windows.Forms.Label()
        Me.LanguageList = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.DefaultButton = New System.Windows.Forms.Button()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.PositionOffsetLabel = New System.Windows.Forms.Label()
        Me.PositionOffset = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.RulerColour2 = New System.Windows.Forms.PictureBox()
        Me.RulerColour1 = New System.Windows.Forms.PictureBox()
        Me.RulerColourLabel = New System.Windows.Forms.Label()
        Me.TickColour = New System.Windows.Forms.PictureBox()
        Me.TickColourLabel = New System.Windows.Forms.Label()
        Me.HighlightColourLabel = New System.Windows.Forms.Label()
        Me.NumberColour = New System.Windows.Forms.PictureBox()
        Me.NumberColourLabel = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.HighlightTextColour = New System.Windows.Forms.PictureBox()
        Me.HighlightColour = New System.Windows.Forms.PictureBox()
        Me.ColourPickerDialog = New System.Windows.Forms.ColorDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PositionOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.RulerColour2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RulerColour1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TickColour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberColour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.HighlightTextColour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HighlightColour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.LanguageLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LanguageList, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.PositionOffsetLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PositionOffset, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RulerColourLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TickColour, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TickColourLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.HighlightColourLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.NumberColour, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.NumberColourLabel, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'LanguageLabel
        '
        resources.ApplyResources(Me.LanguageLabel, "LanguageLabel")
        Me.LanguageLabel.Name = "LanguageLabel"
        '
        'LanguageList
        '
        resources.ApplyResources(Me.LanguageList, "LanguageList")
        Me.LanguageList.DisplayMember = "Value"
        Me.LanguageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LanguageList.FormattingEnabled = True
        Me.LanguageList.Name = "LanguageList"
        Me.LanguageList.ValueMember = "Key"
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.DefaultButton, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CancelButton, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.OKButton, 1, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'DefaultButton
        '
        resources.ApplyResources(Me.DefaultButton, "DefaultButton")
        Me.DefaultButton.Name = "DefaultButton"
        Me.DefaultButton.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        resources.ApplyResources(Me.CancelButton, "CancelButton")
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        resources.ApplyResources(Me.OKButton, "OKButton")
        Me.OKButton.Name = "OKButton"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'PositionOffsetLabel
        '
        resources.ApplyResources(Me.PositionOffsetLabel, "PositionOffsetLabel")
        Me.PositionOffsetLabel.Name = "PositionOffsetLabel"
        '
        'PositionOffset
        '
        resources.ApplyResources(Me.PositionOffset, "PositionOffset")
        Me.PositionOffset.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.PositionOffset.Minimum = New Decimal(New Integer() {300, 0, 0, -2147483648})
        Me.PositionOffset.Name = "PositionOffset"
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.RulerColour2, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RulerColour1, 0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'RulerColour2
        '
        resources.ApplyResources(Me.RulerColour2, "RulerColour2")
        Me.RulerColour2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RulerColour2.Name = "RulerColour2"
        Me.RulerColour2.TabStop = False
        '
        'RulerColour1
        '
        resources.ApplyResources(Me.RulerColour1, "RulerColour1")
        Me.RulerColour1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RulerColour1.Name = "RulerColour1"
        Me.RulerColour1.TabStop = False
        '
        'RulerColourLabel
        '
        resources.ApplyResources(Me.RulerColourLabel, "RulerColourLabel")
        Me.RulerColourLabel.Name = "RulerColourLabel"
        '
        'TickColour
        '
        resources.ApplyResources(Me.TickColour, "TickColour")
        Me.TickColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TickColour.Name = "TickColour"
        Me.TickColour.TabStop = False
        '
        'TickColourLabel
        '
        resources.ApplyResources(Me.TickColourLabel, "TickColourLabel")
        Me.TickColourLabel.Name = "TickColourLabel"
        '
        'HighlightColourLabel
        '
        resources.ApplyResources(Me.HighlightColourLabel, "HighlightColourLabel")
        Me.HighlightColourLabel.Name = "HighlightColourLabel"
        '
        'NumberColour
        '
        resources.ApplyResources(Me.NumberColour, "NumberColour")
        Me.NumberColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumberColour.Name = "NumberColour"
        Me.NumberColour.TabStop = False
        '
        'NumberColourLabel
        '
        resources.ApplyResources(Me.NumberColourLabel, "NumberColourLabel")
        Me.NumberColourLabel.Name = "NumberColourLabel"
        '
        'TableLayoutPanel4
        '
        resources.ApplyResources(Me.TableLayoutPanel4, "TableLayoutPanel4")
        Me.TableLayoutPanel4.Controls.Add(Me.HighlightTextColour, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.HighlightColour, 0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        '
        'HighlightTextColour
        '
        resources.ApplyResources(Me.HighlightTextColour, "HighlightTextColour")
        Me.HighlightTextColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HighlightTextColour.Name = "HighlightTextColour"
        Me.HighlightTextColour.TabStop = False
        '
        'HighlightColour
        '
        resources.ApplyResources(Me.HighlightColour, "HighlightColour")
        Me.HighlightColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HighlightColour.Name = "HighlightColour"
        Me.HighlightColour.TabStop = False
        '
        'ColourPickerDialog
        '
        Me.ColourPickerDialog.AnyColor = True
        Me.ColourPickerDialog.FullOpen = True
        '
        'OptionsForm
        '
        Me.AcceptButton = Me.OKButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionsForm"
        Me.ShowIcon = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.PositionOffset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.RulerColour2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RulerColour1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TickColour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberColour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.HighlightTextColour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HighlightColour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LanguageLabel As Label
    Friend WithEvents LanguageList As ComboBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents OKButton As Button
    Friend WithEvents CancelButton As Button
    Friend WithEvents PositionOffsetLabel As Label
    Friend WithEvents PositionOffset As NumericUpDown
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents RulerColour2 As PictureBox
    Friend WithEvents RulerColour1 As PictureBox
    Friend WithEvents RulerColourLabel As Label
    Friend WithEvents ColourPickerDialog As ColorDialog
    Friend WithEvents TickColour As PictureBox
    Friend WithEvents TickColourLabel As Label
    Friend WithEvents HighlightColourLabel As Label
    Friend WithEvents NumberColour As PictureBox
    Friend WithEvents NumberColourLabel As Label
    Friend WithEvents DefaultButton As Button
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents HighlightTextColour As PictureBox
    Friend WithEvents HighlightColour As PictureBox
End Class

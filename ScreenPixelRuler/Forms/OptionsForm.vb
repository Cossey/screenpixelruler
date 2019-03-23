Public Class OptionsForm

    Private Sub LoadFormSettings()
        LanguageList.SelectedValue = My.Settings.Language
        PositionOffset.Value = My.Settings.PositionOffset
        RulerColour1.BackColor = My.Settings.RulerColour1
        RulerColour2.BackColor = My.Settings.RulerColour2
        TickColour.BackColor = My.Settings.RulerTickColour
        HighlightColour.BackColor = My.Settings.RulerHighlightColour
        NumberColour.BackColor = My.Settings.RulerNumberColour
        HighlightTextColour.BackColor = My.Settings.RulerHightlightTextColour
    End Sub

    Private Sub OptionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = String.Format(Text, My.Application.Info.Title)
        LanguageList.DataSource = Language.GetLanguages()

        LoadFormSettings()
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Dim LanguageDifferent = LanguageList.SelectedValue <> My.Settings.Language
        My.Settings.Language = LanguageList.SelectedValue
        My.Settings.PositionOffset = PositionOffset.Value
        My.Settings.RulerColour1 = RulerColour1.BackColor
        My.Settings.RulerColour2 = RulerColour2.BackColor
        My.Settings.RulerTickColour = TickColour.BackColor
        My.Settings.RulerHighlightColour = HighlightColour.BackColor
        My.Settings.RulerNumberColour = NumberColour.BackColor
        My.Settings.RulerHightlightTextColour = HighlightTextColour.BackColor
        If LanguageDifferent Then
            If MessageBox.Show(My.Resources.ChangeLanguageMessage, My.Resources.ChangeLangageTitle, MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Application.Restart()
            End If
        End If
        Close()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Close()
    End Sub

    Private Sub RulerColour1_Click(sender As Object, e As EventArgs) Handles RulerColour1.Click
        ColourPickerDialog.Color = RulerColour1.BackColor
        If ColourPickerDialog.ShowDialog() = DialogResult.OK Then
            RulerColour1.BackColor = ColourPickerDialog.Color
        End If
    End Sub

    Private Sub RulerColour2_Click(sender As Object, e As EventArgs) Handles RulerColour2.Click
        ColourPickerDialog.Color = RulerColour2.BackColor
        If ColourPickerDialog.ShowDialog() = DialogResult.OK Then
            RulerColour2.BackColor = ColourPickerDialog.Color
        End If
    End Sub

    Private Sub TickColour_Click(sender As Object, e As EventArgs) Handles TickColour.Click
        ColourPickerDialog.Color = TickColour.BackColor
        If ColourPickerDialog.ShowDialog() = DialogResult.OK Then
            TickColour.BackColor = ColourPickerDialog.Color
        End If
    End Sub

    Private Sub HighlightColour_Click(sender As Object, e As EventArgs) Handles HighlightColour.Click
        ColourPickerDialog.Color = HighlightColour.BackColor
        If ColourPickerDialog.ShowDialog() = DialogResult.OK Then
            HighlightColour.BackColor = ColourPickerDialog.Color
        End If
    End Sub

    Private Sub NumberColour_Click(sender As Object, e As EventArgs) Handles NumberColour.Click
        ColourPickerDialog.Color = NumberColour.BackColor
        If ColourPickerDialog.ShowDialog() = DialogResult.OK Then
            NumberColour.BackColor = ColourPickerDialog.Color
        End If
    End Sub

    Private Sub DefaultButton_Click(sender As Object, e As EventArgs) Handles DefaultButton.Click
        My.Settings.Reset()
        LoadFormSettings()
    End Sub

    Private Sub HighlightTextColour_Click(sender As Object, e As EventArgs) Handles HighlightTextColour.Click
        ColourPickerDialog.Color = HighlightTextColour.BackColor
        If ColourPickerDialog.ShowDialog() = DialogResult.OK Then
            HighlightTextColour.BackColor = ColourPickerDialog.Color
        End If
    End Sub
End Class
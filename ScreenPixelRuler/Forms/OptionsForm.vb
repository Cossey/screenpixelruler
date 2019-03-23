Public Class OptionsForm
    Private Sub OptionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = String.Format(Text, My.Application.Info.Title)
        LanguageList.DataSource = Language.GetLanguages()
        LanguageList.SelectedValue = My.Settings.Language
        PositionOffset.Value = My.Settings.PositionOffset
        RulerColour1.BackColor = My.Settings.RulerColour1
        RulerColour2.BackColor = My.Settings.RulerColour2
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Dim LanguageDifferent = LanguageList.SelectedValue <> My.Settings.Language
        My.Settings.Language = LanguageList.SelectedValue
        My.Settings.PositionOffset = PositionOffset.Value
        My.Settings.RulerColour1 = RulerColour1.BackColor
        My.Settings.RulerColour2 = RulerColour2.BackColor

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
End Class
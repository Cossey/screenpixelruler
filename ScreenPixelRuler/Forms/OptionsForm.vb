Public Class OptionsForm
    Private Sub OptionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = String.Format(Text, My.Application.Info.Title)
        LanguageList.DataSource = Language.GetLanguages()
        LanguageList.SelectedValue = My.Settings.Language
        PositionOffset.Value = My.Settings.PositionOffset
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Dim LanguageDifferent = LanguageList.SelectedValue <> My.Settings.Language
        My.Settings.Language = LanguageList.SelectedValue
        My.Settings.PositionOffset = PositionOffset.Value

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

End Class
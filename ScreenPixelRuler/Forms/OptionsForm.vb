Public Class OptionsForm
    Private Sub OptionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = String.Format(Text, My.Application.Info.Title)
        LanguageList.DataSource = Language.GetLanguages()
    End Sub
End Class
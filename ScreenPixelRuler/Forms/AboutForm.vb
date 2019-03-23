Public NotInheritable Class AboutForm

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Text = String.Format(Text, My.Application.Info.Title)
        LabelProductName.Text = My.Application.Info.ProductName
        LabelVersion.Text = String.Format(LabelVersion.Text, My.Application.Info.Version.ToString)

        LinkGit.Links.Add(New LinkLabel.Link(0, 18, "https://github.com/Cossey/screenpixelruler/issues"))
        LinkGit.Links.Add(New LinkLabel.Link(19, 12, "https://github.com/Cossey/screenpixelruler/releases"))
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Close()
    End Sub

    Private Sub LinkGit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkGit.LinkClicked
        Process.Start(e.Link.LinkData)
    End Sub

    Private Sub LogoPictureBox_Click(sender As Object, e As EventArgs) Handles LogoPictureBox.Click
        Threading.Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("mi")
    End Sub
End Class

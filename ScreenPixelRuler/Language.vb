Imports System.ComponentModel
Imports System.Globalization

Module Language

    Function GetLanguages() As List(Of KeyValuePair(Of String, String))
        Return New List(Of KeyValuePair(Of String, String)) From {
            New KeyValuePair(Of String, String)("", "English"),
            New KeyValuePair(Of String, String)("mi", "Maori")
        }
    End Function

    Sub SetNativeDialogLanguage()
        MessageBoxManager.No = My.Resources.No
        MessageBoxManager.Yes = My.Resources.Yes
        MessageBoxManager.OK = My.Resources.Ok
        MessageBoxManager.Cancel = My.Resources.Cancel
        MessageBoxManager.Register()
    End Sub

End Module

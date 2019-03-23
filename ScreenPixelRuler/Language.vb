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
        NativeDialogHandler.No = My.Resources.No
        NativeDialogHandler.Yes = My.Resources.Yes
        NativeDialogHandler.OK = My.Resources.Ok
        NativeDialogHandler.Cancel = My.Resources.Cancel
        NativeDialogHandler.AddToCustomColours = My.Resources.AddToCustomColours
        NativeDialogHandler.DefineCustomColours = My.Resources.DefineCustomColours
        NativeDialogHandler.Colour = My.Resources.Colour
        NativeDialogHandler.Register()
    End Sub

End Module

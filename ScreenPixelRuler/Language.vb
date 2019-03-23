Module Language

    Function GetLanguages() As List(Of KeyValuePair(Of String, String))
        Return New List(Of KeyValuePair(Of String, String)) From {
            New KeyValuePair(Of String, String)("", "English"),
            New KeyValuePair(Of String, String)("mi", "Maori")
        }
    End Function

End Module

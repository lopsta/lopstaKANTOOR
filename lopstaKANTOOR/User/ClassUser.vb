Imports System.Xml.Serialization

<Serializable>
Public Class ClassUser

    Public Property UserID As String
    Public Property Nachname As String

    Public Property Vorname As String

    Public Property Titel As String

    Public Property Anrede As String

    <Xml.Serialization.XmlIgnore>
    Public ReadOnly Property Label As String
        Get
            Dim sb As New System.Text.StringBuilder
            With sb
                .Append(Nachname)
                .Append(", ")
                .Append(Vorname)
                If Not String.IsNullOrEmpty(Titel) Then
                    .Append(" (" & Titel & ")")
                End If
            End With
            Return sb.ToString
        End Get
    End Property

    Public Property PathPROJEKTE As String = Nothing
    Public Property PathRECHNUNGEN As String = Nothing
    Public Property PathTEXTBAUSTEINE As String = Nothing
    Public Property PathWORDVORLAGEN As String = Nothing
    Public Property PathEXCELVORLAGEN As String = Nothing

    Public Property ExtensionWORD As String = "dotx"
    Public Property ExtensionEXCEL As String = ""

End Class

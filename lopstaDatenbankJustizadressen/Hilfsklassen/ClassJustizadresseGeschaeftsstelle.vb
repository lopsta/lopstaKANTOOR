Imports System.Xml.Serialization
Imports System.Text

<Serializable>
Public Class ClassJustizadresseGeschaeftsstelle
    Inherits ClassJustizadresse

    Public Property Bezeichnung As String
    Public Property Ansprechpartner As String
    Public Property Zimmer As String
    Public Property DurchwahlTelefon As String
    Public Property DurchwahlFax As String
    Public Property DurchwahlEmail As String

    ' Eigenschaften, die nicht gespeichert und nur für die Anzeige gebraucht werden
    <NonSerialized>
    Private _label As String
    Public Overrides ReadOnly Property Label As String
        Get
            Dim sb As New StringBuilder
            With sb
                .Append(Name)
                .Append(" (Geschäftsstelle: ")
                .Append(Bezeichnung)
                .Append(")")
            End With
            Return sb.ToString
        End Get
    End Property

End Class

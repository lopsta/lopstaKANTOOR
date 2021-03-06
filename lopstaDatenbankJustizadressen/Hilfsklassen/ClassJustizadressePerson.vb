Imports System.Xml.Serialization
Imports System.Text

<Serializable>
Public Class ClassJustizadressePerson
    Inherits ClassJustizadresse

    Public Property Anrede As String
    Public Property Dienstbezeichnung As String
    Public Property Nachname As String
    Public Property Vorname As String
    Public Property Titel As String
    Public Property Zimmer As String
    Public Property DurchwahlTelefon As String
    Public Property DurchwahlMobil As String
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
                .Append(" (Durchwahl: ")
                .Append(Nachname)
                If Not String.IsNullOrEmpty(Titel) Then
                    .Append(", ")
                    .Append(Titel)
                End If
                If Not String.IsNullOrEmpty(Vorname) Then
                    .Append(" ")
                Else
                    If Not String.IsNullOrEmpty(Titel) Then
                        .Append(", ")
                    End If
                    .Append(Vorname)
                End If
                .Append(")")
            End With
            Return sb.ToString
        End Get
    End Property

End Class

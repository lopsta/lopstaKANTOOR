Imports System.Xml.Serialization
Imports System.Text

<Serializable>
Public Class ClassJustizadresse

    Public Property ID As String
    Public Property xJustizID As String
    Public Property Typ As String
    Public Property Name As String
    Public Property Zusatz As String
    Public Property Strasse As String
    Public Property Postleitzahl As String
    Public Property Ort As String
    Public Property Postfach As String
    Public Property PostleitzahlPostfach As String
    Public Property Bundesland As String
    Public Property Telefon As String
    Public Property Fax As String
    Public Property Email As String
    Public Property Internet As String
    Public Property Kontoinhaber As String
    Public Property Bank As String
    Public Property IBAN As String
    Public Property BIC As String
    Public Property Text As String

    ' Eigenschaften, die nicht gespeichert und nur für die Anzeige gebraucht werden
    '<NonSerialized>
    <Xml.Serialization.XmlIgnore>
    Private _label As String
    Public Overridable ReadOnly Property Label As String
        Get
            Return Name
        End Get
    End Property

End Class

'Imports lopstaControlAdressenVerzeichnis
Imports System.Xml.Serialization
Imports System.Text

<Serializable>
Public Class ClassGeschaeftsstelle
    Inherits lopstaDatenbankJustizadressen.ClassJustizadresse
    Implements IComparable(Of ClassGeschaeftsstelle)

    Public Property ClassTyp As String

    'Eigenschaft für das AKtenzeichen ------------------------------------------------
    Public Property Aktenzeichen As String

    ' Eigenschaften für den Betreff --------------------------------------------------
    Public Property Betreff001 As String
    Public Property Betreff002 As String
    Public Property Betreff003 As String
    Public Property Betreff004 As String

    Public Property Bezeichnung As String
    Public Property Ansprechpartner As String
    Public Property Zimmer As String
    Public Property DurchwahlTelefon As String
    Public Property DurchwahlFax As String
    Public Property DurchwahlEmail As String

    ' Eigenschaften, die nicht gespeichert und nur für die Anzeige gebraucht werden
    '<NonSerialized>
    <Xml.Serialization.XmlIgnore>
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

    Public Function CompareTo(other As ClassGeschaeftsstelle) As Integer Implements IComparable(Of ClassGeschaeftsstelle).CompareTo
        'Throw New NotImplementedException()
        Return Me.Label().CompareTo(other.Label)
    End Function

End Class

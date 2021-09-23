Imports System.Text

<Serializable>
Public Class ClassPolizei
    Implements IComparable(Of ClassJustizAdresse)

    Public Property ID As String

    'Bezeichnung
    Public Property Name As String
    Public Property Zusatz As String

    ' Anschriften
    Public Property Strasse As String
    Public Property Postleitzahl As String
    Public Property Ort As String
    Public Property Postfach As String
    Public Property PostleitzahlPostfach As String
    Public Property Bundesland As String

    ' Telefon, Fax, Email, Internet
    Public Property Telefon As String
    Public Property Fax As String
    Public Property Email As String
    Public Property Internet As String

    ' Text
    Public Property Text As String

    'Eigenschaft für das AKtenzeichen ------------------------------------------------
    Public Property Aktenzeichen As String

    ' Eigenschaften für den Betreff --------------------------------------------------
    Public Property Betreff001 As String
    Public Property Betreff002 As String
    Public Property Betreff003 As String
    Public Property Betreff004 As String

    '<NonSerialized>
    <Xml.Serialization.XmlIgnore>
    Private _betreff As String = "-- noch nicht eingegeben --"
    Public ReadOnly Property Betreff As String
        Get
            Dim sb As New StringBuilder
            With sb
                .Append(Betreff001)
                .Append(" ")
                .Append(Betreff002)
                .Append(" ")
                .Append(Betreff003)
                .Append(" ")
                .Append(Betreff004)
            End With
            Return sb.ToString
        End Get
    End Property

    ' Eigenschaften, die nicht gespeichert und nur für die Anzeige gebraucht werden
    '<NonSerialized>
    <Xml.Serialization.XmlIgnore>
    Private _label As String
    Public Overridable ReadOnly Property Label As String
        Get
            Return Name
        End Get
    End Property

    Public Function CompareTo(other As ClassJustizAdresse) As Integer Implements IComparable(Of ClassJustizAdresse).CompareTo
        Return Me.Label().CompareTo(other.Label)
    End Function

End Class

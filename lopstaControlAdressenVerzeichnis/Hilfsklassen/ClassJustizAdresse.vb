Imports System.Text

<Serializable>
Public Class ClassJustizAdresse
    Inherits lopstaDatenbankJustizadressen.ClassJustizadresse
    Implements IComparable(Of ClassJustizAdresse)

    Public Property ClassTyp As String

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

    Public Function CompareTo(other As ClassJustizAdresse) As Integer Implements IComparable(Of ClassJustizAdresse).CompareTo
        Return Me.Label().CompareTo(other.Label)
    End Function

End Class

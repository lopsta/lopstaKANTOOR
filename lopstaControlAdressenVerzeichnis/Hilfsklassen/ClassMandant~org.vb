Imports System.Xml.Serialization
Imports System.Text

<Serializable>
Public Class ClassMandantORG

    ' Eigenschaften für die Verwaltung des Datensatze
    Public Property ID As String
    Public Property Typ As String


    ' Eigenschaften für Aktenzeichen und Betreff
    Public Property Betreff001 As String
    Public Property Betreff002 As String
    Public Property Betreff003 As String


    ' Eigenschaften => Name, Vorname usw.
    Public Property Anrede As String
    Public Property Nachname As String
    Public Property Vorname As String
    Public Property Titel As String

    Public Property IsBriefanredeDu As Boolean = False


    ' Eigenschaften für die Postkorrespondenz
    Public Property Zusatz As String
    Public Property Strasse As String
    Public Property Postleitzahl As String
    Public Property Ort As String


    ' Eigenschaften für die Kommunikation => Telefon, Email usw.
    Public Property Telefon As String
    Public Property Mobil001 As String
    Public Property Mobil002 As String
    Public Property Mobil003 As String
    Public Property Fax As String
    Public Property Email As String


    ' Eigenschaften Bankverbindung
    Public Property Kontoinhaber As String
    Public Property IBAN As String
    Public Property BIC As String


    ' Eigenschaften für Bemerkungen
    Public Property Text As String


    ' Eigenschaften, die nicht gespeichert und nur für die Anzeige gebraucht werden
    <NonSerialized>
    Private _label As String
    Public ReadOnly Property Label As String
        Get
            Return Nachname & ", " & Vorname & ", " & Titel
        End Get
    End Property

    <NonSerialized>
    Private _briefanrede
    Public ReadOnly Property Briefanrede As String
        Get
            If IsBriefanredeDu Then
                Select Case Anrede
                    Case "Herr"
                        Return "Lieber " & Vorname
                    Case "Frau"
                        Return "Liebe " & Vorname
                    Case Else
                        Return "Hallo" & Vorname
                End Select
            Else
                Dim sb As New StringBuilder
                With sb
                    Select Case Anrede
                        Case "Herr"
                            .Append("Sehr geehrter Herr ")
                        Case "Frau"
                            .Append("Sehr geehrte Frau ")
                        Case Else
                            .Append("# # #  F E H L E R # # # ")
                    End Select
                    If Not String.IsNullOrEmpty(Titel) Then
                        .Append(Titel & " ")
                    End If
                    .Append(Nachname)
                End With
                Return sb.ToString
            End If
            Return "# # # F E H L E R ! # # #"
        End Get
    End Property



End Class

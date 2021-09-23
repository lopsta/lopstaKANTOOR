Public Class ClassPublicMandant

    Private Shared _mandant As ClassMandant
    Public Shared Property Mandant As ClassMandant
        Get
            Return _mandant
        End Get
        Set(value As ClassMandant)
            _mandant = value
        End Set
    End Property

    Public Shared ReadOnly Property AnredeG As String
        Get
            Select Case _mandant.Anrede
                Case "Herr"
                    Return "Herrn"
                Case "Frau"
                    Return "Frau"
                Case "Firma"
                    Return "Firma"
            End Select
            Return ""
        End Get
    End Property

    Public Shared ReadOnly Property Briefanrede As String
        Get
            Select Case _mandant.Anrede
                Case "Herr"
                    Return "Sehr geehrter Herr " & _mandant.Nachname
                Case "Frau"
                    Return "Sehr geehrter Frau " & _mandant.Nachname
                Case "Firma"
                    Return "Sehr geehrter Damen und Herren "
            End Select
            Return "### FEHLER: Keine Brihefanrede verfügbar! ###"
        End Get
    End Property

    Public Shared ReadOnly Property Name As String
        Get
            Dim sb As New Text.StringBuilder
            If Not String.IsNullOrEmpty(_mandant.Titel) Then
                sb.Append(_mandant.Titel)
                sb.Append(" ")
            End If
            If Not String.IsNullOrEmpty(_mandant.Vorname) Then
                sb.Append(_mandant.Vorname)
                sb.Append(" ")
            End If
            sb.Append(_mandant.Nachname)
            Return sb.ToString.Trim
        End Get
    End Property

    Public Shared ReadOnly Property Adresse As String
        Get
            Dim sb As New Text.StringBuilder
            sb.Append(_mandant.Strasse)
            sb.Append(", ")
            sb.Append(_mandant.Postleitzahl)
            sb.Append(" ")
            sb.Append(_mandant.Ort)
            If Not String.IsNullOrEmpty(_mandant.Land) Then
                sb.Append(", ")
                sb.Append(_mandant.Land)
            End If
            Return sb.ToString.Trim
        End Get
    End Property

    Public Shared Function GetMandant(ByRef adrl As ClassAdressen) As ClassMandant
        Try
            If adrl.Mandant.Count > 0 Then
                Return adrl.Mandant.First
            Else
                Dim m As New ClassMandant
                With m
                    .Nachname = "Noch keine Adresse hinzugefügt."
                    .Vorname = ""
                    .Titel = ""
                    .Anrede = ""
                    .Strasse = ""
                    .Postleitzahl = ""
                    .Ort = ""
                    .Land = ""
                End With
                Return m
            End If
        Catch ex As Exception

        End Try
        Return Nothing
    End Function

End Class

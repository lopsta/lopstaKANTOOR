Public Class ClassPublicSelectedAdress

    Private Shared _adresse As Object
    Public Shared Property Adresse As Object
        Get
            Return _adresse
        End Get
        Set(value As Object)
            _adresse = value
        End Set
    End Property

    Private Shared _adressetyp As String
    Public Shared Property AdresseTyp As String
        Get
            Return _adressetyp
        End Get
        Set(value As String)
            _adressetyp = value
        End Set
    End Property

    Private Shared _adressfeld As ClassADRESSFELD = Nothing

    Public Shared ReadOnly Property GetPostanschriftAnrede As String
        Get
            Try
                Select Case _adressetyp
                    Case "lopstaControlAdressenVerzeichnis.ClassAdresse"
                        Select Case _adresse.Anrede
                            Case "Herr"
                                Return "Herrn"
                            Case "Frau"
                                Return "Frau"
                            Case "Firma"
                                Return "Firma"
                            Case Else
                                Return " "
                        End Select
                        Return "### FEHLER: Keine Anrede verfügbar! ###"
                    Case "lopstaControlAdressenVerzeichnis.ClassMandant"
                        Select Case _adresse.Anrede
                            Case "Herr"
                                Return "Herrn"
                            Case "Frau"
                                Return "Frau"
                            Case "Firma"
                                Return "Firma"
                            Case Else
                                Return " "
                        End Select
                        Return "### FEHLER: Keine Anrede verfügbar! ###"
                    Case "lopstaControlAdressenVerzeichnis.ClassJustizAdresse"

                    Case "lopstaControlAdressenVerzeichnis.ClassPolizei"

                    Case Else

                End Select
            Catch ex As Exception

            End Try
            Return " "
        End Get
    End Property

    Public Shared Function GetPostanschrift(Optional z As Integer = Nothing) As String
        _adressfeld = New ClassADRESSFELD
        Try
            Select Case _adressetyp
                Case "lopstaControlAdressenVerzeichnis.ClassAdresse"
                    _adressfeld.Zeile01 = _adresse.Vorname & " " & _adresse.Nachname
                    _adressfeld.Zeile02 = _adresse.Strasse
                    _adressfeld.Zeile03 = _adresse.Postleitzahl & " " & _adresse.Ort
                    _adressfeld.Zeile04 = " "
                    If String.IsNullOrEmpty(_adresse.Fax) Then
                        _adressfeld.Zeile05 = " "
                    Else
                        _adressfeld.Zeile05 = "per Telefax: " & _adresse.Fax
                    End If
                    If String.IsNullOrEmpty(_adresse.Email) Then
                        _adressfeld.Zeile05 = " "
                    Else
                        _adressfeld.Zeile05 = "per Email: " & _adresse.Email
                    End If
                    _adressfeld.Zeile06 = " "
                Case "lopstaControlAdressenVerzeichnis.ClassMandant"
                    _adressfeld.Zeile01 = _adresse.Vorname & " " & _adresse.Nachname
                    _adressfeld.Zeile02 = _adresse.Strasse
                    _adressfeld.Zeile03 = _adresse.Postleitzahl & " " & _adresse.Ort
                    _adressfeld.Zeile04 = " "
                    If String.IsNullOrEmpty(_adresse.Fax) Then
                        _adressfeld.Zeile05 = " "
                    Else
                        _adressfeld.Zeile05 = "per Telefax: " & _adresse.Fax
                    End If
                    If String.IsNullOrEmpty(_adresse.Email) Then
                        _adressfeld.Zeile05 = " "
                    Else
                        _adressfeld.Zeile05 = "per Email: " & _adresse.Email
                    End If
                    _adressfeld.Zeile06 = " "
                Case "lopstaControlAdressenVerzeichnis.ClassJustizAdresse"
                    _adressfeld.Zeile01 = _adresse.Name
                    _adressfeld.Zeile02 = _adresse.Strasse
                    _adressfeld.Zeile03 = _adresse.Postleitzahl & " " & _adresse.Ort
                    _adressfeld.Zeile04 = " "
                    _adressfeld.Zeile05 = _adresse.Fax
                    _adressfeld.Zeile06 = " "
                Case "lopstaControlAdressenVerzeichnis.ClassPolizei"
                    _adressfeld.Zeile01 = _adresse.Name
                    _adressfeld.Zeile02 = _adresse.Strasse
                    _adressfeld.Zeile03 = _adresse.Postleitzahl & " " & _adresse.Ort
                    _adressfeld.Zeile04 = " "
                    _adressfeld.Zeile05 = _adresse.Fax
                    _adressfeld.Zeile06 = " "
                Case Else
                    _adressfeld.Zeile01 = " "
                    _adressfeld.Zeile02 = " "
                    _adressfeld.Zeile03 = " "
                    _adressfeld.Zeile04 = " "
                    _adressfeld.Zeile05 = " "
                    _adressfeld.Zeile06 = " "
            End Select
        Catch ex As Exception

        End Try
        Select Case z
            Case 1
                Return _adressfeld.Zeile01
            Case 2
                Return _adressfeld.Zeile02
            Case 3
                Return _adressfeld.Zeile03
            Case 4
                Return _adressfeld.Zeile04
            Case 5
                Return _adressfeld.Zeile05
            Case 6
                Return _adressfeld.Zeile06
            Case Else
                Return _adressfeld.ToString
        End Select
        Return _adressfeld.ToString
    End Function


    Public Shared ReadOnly Property GetBetreff As ClassBETREFF
        Get
            Dim a As New ClassBETREFF
            If IsNothing(_adresse) Then
                Return a
            End If
            Try
                If String.IsNullOrEmpty(_adresse.Aktenzeichen) Then
                    a.Aktenzeichen = " "
                Else
                    a.Aktenzeichen = _adresse.Aktenzeichen
                End If
                If String.IsNullOrEmpty(_adresse.Betreff001) Then
                    a.Zeile01 = " "
                Else
                    a.Zeile01 = _adresse.Betreff001
                End If
                If String.IsNullOrEmpty(_adresse.Betreff002) Then
                    a.Zeile02 = " "
                Else
                    a.Zeile02 = _adresse.Betreff002
                End If
                If String.IsNullOrEmpty(_adresse.Betreff003) Then
                    a.Zeile03 = " "
                Else
                    a.Zeile03 = _adresse.Betreff003
                End If
                If String.IsNullOrEmpty(_adresse.Betreff004) Then
                    a.Zeile04 = " "
                Else
                    a.Zeile04 = _adresse.Betreff004
                End If
            Catch ex As Exception

            End Try
            Return a
        End Get
    End Property

    Public Shared ReadOnly Property GetBriefanrede As String
        Get
            Try
                Select Case _adressetyp
                    Case "lopstaControlAdressenVerzeichnis.ClassAdresse"
                        Select Case _adresse.Anrede
                            Case "Herr"
                                Return "Sehr geehrter Herr " & _adresse.Nachname
                            Case "Frau"
                                Return "Sehr geehrter Frau " & _adresse.Nachname
                            Case "Firma"
                                Return "Sehr geehrter Damen und Herren"
                        End Select
                        Return "### FEHLER: Keine Brihefanrede verfügbar! ###"
                    Case "lopstaControlAdressenVerzeichnis.ClassMandant"
                        Select Case _adresse.Anrede
                            Case "Herr"
                                Return "Sehr geehrter Herr " & _adresse.Nachname
                            Case "Frau"
                                Return "Sehr geehrter Frau " & _adresse.Nachname
                            Case "Firma"
                                Return "Sehr geehrter Damen und Herren"
                        End Select
                        Return "### FEHLER: Keine Brihefanrede verfügbar! ###"
                    Case "lopstaControlAdressenVerzeichnis.ClassJustizAdresse"
                        Return ""
                    Case "lopstaControlAdressenVerzeichnis.ClassPolizei"

                    Case Else
                        Return "### FEHLER: Keine Briefanrede verfügbar! ###"
                End Select
            Catch ex As Exception

            End Try
            Return "### FEHLER: Keine Briefanrede verfügbar! ###"
        End Get
    End Property

    Public Shared Property Mandant As ClassMandant

End Class

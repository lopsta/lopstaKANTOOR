Public Class UserControlTEST

    ' ====================================================================================================
    ' Eigenschaft
    ' Einschalten (true) / Ausschalten (false) der Leiste mit den ControlButtons OK und Cancel
    ' ====================================================================================================
    Private _showControlButtons As Boolean = False
    Public WriteOnly Property ShowControlButtons As Boolean
        Set(value As Boolean)
            _showControlButtons = value
            Select Case _showControlButtons
                Case True
                    StackPanelUserControlBUTONS.Visibility = Visibility.Visible
                Case False
                    StackPanelUserControlBUTONS.Visibility = Visibility.Collapsed
            End Select
        End Set
    End Property


    ' ====================================================================================================
    ' Eigenschaft
    ' Adresse = DatenBindung für die Formulare
    ' ====================================================================================================
    Private _adresse As ClassAdresse
    Public Property Adresse As ClassAdresse
        Get
            Return _adresse
        End Get
        Set(value As ClassAdresse)
            _adresse = value
            GridCONTROL.DataContext = _adresse
        End Set
    End Property


    ' ====================================================================================================
    ' Ereignisse
    ' OK und Cancel
    ' ====================================================================================================
    Public Event OK(sender As Object, e As RoutedEventArgs)
    Public Event CANCEL(sender As Object, e As RoutedEventArgs)

    ' ====================================================================================================
    '  ControlButton => Button OK
    ' ====================================================================================================
    Private Sub ButtonOk_Click(sender As Object, e As RoutedEventArgs) Handles ButtonOk.Click
        TakeUserInput()
        AutoSave()
        RaiseEvent OK(Me, New RoutedEventArgs())
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As RoutedEventArgs) Handles ButtonCancel.Click
        RaiseEvent CANCEL(Me, New RoutedEventArgs())
    End Sub

    ' ====================================================================================================
    ' Mehtode (privat)
    ' Benutzereingaben in Datenquelle übernehmen
    ' ====================================================================================================
    Public Sub TakeUserInput()
        With _adresse

            ' Name
            .Anrede = TextBoxANREDE.Text.Trim
            .Nachname = TextBoxNAME.Text.Trim
            .Vorname = TextBoxVORNAME.Text.Trim
            .Titel = TextBoxTITEL.Text.Trim

            ' Telefon
            .Telefon = TextBoxTELEFON.Text.Trim
            .Mobil001 = TextBoxMOBIL001.Text.Trim
            .Mobil002 = TextBoxMOBIL002.Text.Trim
            .Mobil003 = TextBoxMOBIL003.Text.Trim
            .Fax = TextBoxFAX.Text.Trim
            .Email = TextBoxEMAIL.Text.Trim

            ' Adresse
            .Strasse = TextBoxSTRASSE.Text.Trim
            .Postleitzahl = TextBoxPOSTLEITZAHL.Text.Trim
            .Ort = TextBoxORT.Text.Trim
            .Land = TextBoxLAND.Text.Trim

            ' Bankverbindung
            .Bank = TextBoxBANK.Text.Trim
            .Kontoinhaber = TextBoxKONTOINHABER.Text.Trim
            .IBAN = TextBoxIBAN.Text.Trim
            .BIC = TextBoxBIC.Text.Trim

            'Betreff
            .Aktenzeichen = TextBoxAKTENZEICHEN.Text.Trim
            .Betreff001 = TextBoxBETREFF001.Text.Trim
            .Betreff002 = TextBoxBETREFF002.Text.Trim
            .Betreff003 = TextBoxBETREFF003.Text.Trim
            .Betreff004 = TextBoxBETREFF004.Text.Trim
        End With
    End Sub

    Private Sub AutoSave()
        If lopstaAppSettings.ClassSettings.IsAutoSave Then
            '_adresse.AdressenXmlDateiSpeichern(lopstaPROJEKTDATEN.AktivesProjekt.FullName)
        End If
    End Sub


End Class

Public Class UserControlJustizadresse

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
    Private _adresse As ClassJustizAdresse
    Public Property Adresse As ClassJustizAdresse
        Get
            Return _adresse
        End Get
        Set(value As ClassJustizAdresse)
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

            '.xJustizID = TextBoxIBAN.Text

            ' Name
            '.Name = TextBoxNAME.Text

            ' Telefon
            '.Telefon = TextBoxTELEFON.Text
            '.Fax = TextBoxFAX.Text
            '.Email = TextBoxEMAIL.Text

            ' Adresse
            '.Strasse = TextBoxSTRASSE.Text
            '.Postleitzahl = TextBoxPOSTLEITZAHL.Text
            '.Ort = TextBoxORT.Text
            '.Bundesland = TextBoxLAND.Text

            ' Bankverbindung
            '.Bank = TextBoxBANK.Text
            '.Kontoinhaber = TextBoxKONTOINHABER.Text
            '.IBAN = TextBoxIBAN.Text
            '.BIC = TextBoxBIC.Text

            'Betreff
            .Aktenzeichen = TextBoxAKTENZEICHEN.Text
            .Betreff001 = TextBoxBETREFF001.Text
            .Betreff002 = TextBoxBETREFF002.Text
            .Betreff003 = TextBoxBETREFF003.Text
            .Betreff004 = TextBoxBETREFF004.Text
        End With
    End Sub

End Class

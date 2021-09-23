Public Class UserControlDurchwahl

    ' ====================================================================================================
    ' Eigenschaft
    ' Einschalten (true) / Ausschalten (false) der Leiste mit den ControlButtons OK und Cancel
    ' ====================================================================================================
    Private _showControlButtons As Boolean = True
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
    Private _adresse As ClassJustizDurchwahl
    Public Property Adresse As ClassJustizDurchwahl
        Get
            Return _adresse
        End Get
        Set(value As ClassJustizDurchwahl)
            _adresse = value
            GridCONTROL.DataContext = _adresse
        End Set
    End Property

    ' ====================================================================================================
    ' Eigenschaft
    ' zugehörige Justizadresse
    ' ====================================================================================================
    Private _justizadresse As ClassJustizAdresse
    Public Property JustizAdresse As ClassJustizAdresse
        Get
            Return _justizadresse
        End Get
        Set(value As ClassJustizAdresse)
            _justizadresse = value
            GridFORMULAR000.DataContext = _justizadresse
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
    ' Methode (privat)
    ' Benutzereingaben in Datenquelle übernehmen
    ' ====================================================================================================
    Public Sub TakeUserInput()
        With _adresse

            .Anrede = TextBoxAnrede.Text
            .Dienstbezeichnung = TextBoxDienstbezeichnung.Text
            .Nachname = TextBoxNACHNAME.Text
            .Vorname = TextBoxVORNAME.Text
            .Titel = TextBoxTITEL.Text

            .DurchwahlTelefon = TextBoxTELEFON.Text
            .DurchwahlMobil = TextBoxDURCHWAHLMOBIL.Text
            .Fax = TextBoxFAX.Text
            .Email = TextBoxEMAIL.Text

        End With
    End Sub

End Class

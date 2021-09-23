Public Class UserControlDateinamePOSTEINGANG

    Private _dlg As WindowUserDialog

    ' ==========================================
    ' XML-Dokumente für die Inhalte von
    ' ComboBoxen in den Tabs-Dateiname
    ' ==========================================
    Private xmlDateinameEMPFAENGER As Xml.XmlDocument
    Private xmlDateinameBEZEICHNUNGEN As Xml.XmlDocument

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        ComboBoxenMitItemsAusXmlDateiFuellen()

        TextBoxDateinameDATUM.Text = ClassHilfsfunktionen.nkDatum

    End Sub

    Public Sub New(ByRef d As WindowUserDialog)

        _dlg = d

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        ComboBoxenMitItemsAusXmlDateiFuellen()

        TextBoxDateinameDATUM.Text = ClassHilfsfunktionen.nkDatum

    End Sub


    Private Sub ComboBoxenMitItemsAusXmlDateiFuellen()
        xmlDateinameEMPFAENGER = New Xml.XmlDocument
        Try
            xmlDateinameEMPFAENGER.Load("Resources\DateinameEmpfaenger.xml")
            With ComboBoxDateinameEMPFAENGER
                .ItemsSource = xmlDateinameEMPFAENGER.GetElementsByTagName("item")
                .DisplayMemberPath = "label"
                .SelectedValuePath = "value"
            End With
        Catch ex As Exception
            MessageBox.Show("Die XML-Datei 'DateinameEmpfaenger.xml' konnte nicht geladen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try

        xmlDateinameBEZEICHNUNGEN = New Xml.XmlDocument
        Try
            xmlDateinameBEZEICHNUNGEN.Load("Resources\DateinameBezeichnungen.xml")
            With ComboBoxDateinameBEZEICHNUNG
                .ItemsSource = xmlDateinameBEZEICHNUNGEN.GetElementsByTagName("item")
                .DisplayMemberPath = "label"
                .SelectedValuePath = "value"
            End With
        Catch ex As Exception
            MessageBox.Show("Die XML-Datei 'DateinameBezeichnungen.xml' konnte nicht geladen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    ' ===========================================================================================
    ' Button (Click)
    ' ButtonCOPY
    ' => Kopiert ein komplettes Akten-Verzeichnis mit Unterverzeichnissen und Datein in die
    ' Zwischenablage
    ' ===========================================================================================
    Private Sub ButtonCOPY_Click(sender As Object, e As RoutedEventArgs) Handles ButtonCOPY.Click
        If TextBoxClipboard.Text IsNot String.Empty Then
            If TextBoxClipboard.Text.Length > 85 Then
                MessageBox.Show("Der Dateiname kann nicht übernommen werden, weil er mehr als 85 Zeichen hat.", "Hinweis!", MessageBoxButton.OK, MessageBoxImage.Exclamation)
            Else
                Clipboard.SetText(TextBoxClipboard.Text)
            End If
        End If
    End Sub

    ' =====================================================================
    ' RESET
    ' Zurücksetzen der Einträge in dem Tab-Control
    ' =====================================================================

    ' =============================================================================================
    ' Setzt die Eingabe-Controls für die Dateinamen in dem Tab-Control zurück
    ' =============================================================================================
    Private Sub ButtonRESET_Click(sender As Object, e As RoutedEventArgs) Handles ButtonRESET.Click
        TextBoxClipboard.Text = String.Empty
    End Sub

    ' ==========================================================
    ' Reset aller Eingaben in dem Tab "Dateiname"
    ' ==========================================================
    Private Sub resetUserInput()
        'TextBoxDateinameDATUM.Text = String.Empty
        TextBoxDateinameDATUM.Text = ClassHilfsfunktionen.nkDatum
        ComboBoxDateinameBEZEICHNUNG.Text = String.Empty
        ComboBoxDateinameBEZEICHNUNG.SelectedIndex = -1
        ComboBoxDateinameEMPFAENGER.Text = String.Empty
        ComboBoxDateinameEMPFAENGER.SelectedIndex = -1
        TextBoxDateinameBESCHREIBUNG.Text = String.Empty
    End Sub


    ' =================================================================================================================
    ' Button Erstellen "Dateiname"
    ' Erstellt den Dateinamen und fügt ihn in die Eingabe Clipboard ein
    ' =================================================================================================================
    Private Sub ButtonERSTELLEN_Click(sender As Object, e As RoutedEventArgs) Handles ButtonDateinameERSTELLEN.Click

        Dim s As String = ModuleDateinameErstellenPOSTEINGANG.erstellen(Me)
        If CeckBoxMitPfad.IsChecked Then
            If Not String.IsNullOrEmpty(lopstaPROJEKTDATEN.AktivesProjekt.FullName) Then
                s = System.IO.Path.Combine(lopstaPROJEKTDATEN.AktivesProjekt.FullName, "02_Handakte", "b_Posteingang", s)
            End If
        End If
        TextBoxClipboard.Text = s
        Clipboard.SetText(s)
        If CeckBoxAutoSchliessen.IsChecked Then
            _dlg.Close()
            _dlg.Dispose()
        End If

    End Sub

End Class

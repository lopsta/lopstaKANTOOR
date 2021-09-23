Imports System.ComponentModel
Imports System.IO
Imports System.Threading

Partial Public Class UserControlContainer

    ' ==========================================
    ' FileSystemWatcher
    ' für die Verzeichnisse
    '  => Word-Vorlagen
    ' ==========================================
    Private fswWORDVORLAGEN As FileSystemWatcher

    ' ==========================================
    ' Delegate für ListBoxUpdate
    ' ==========================================

    Public Delegate Sub ReloadListBoxItems()

    ' ==========================================
    ' Extension der Wordvorlagen
    ' ==========================================
    Private _extensionWORD As String = "dotx"
    Public WriteOnly Property ExtensionWord As String
        Set(value As String)
            Select Case value.ToLower
                Case "dot"
                    _extensionWORD = "dot"
                Case ".dot"
                    _extensionWORD = "dot"
                Case "dotx"
                    _extensionWORD = "dotx"
                Case ".dotx"
                    _extensionWORD = "dotx"
                Case Else
                    _extensionWORD = value
            End Select
        End Set
    End Property

    ' ==========================================
    ' Pfad zu dem Word-Vorlagen-Verzeichnis
    ' ==========================================
    Private _pathWORD As String = "Vorlagen\Word" ' zunälchst (osicherheitshalber auf Standardwert setzen
    Public WriteOnly Property PathWORD As String
        Set(value As String)
            If Directory.Exists(value) Then ' Prüfen, ob der angegebene Pfad existiert
                _pathWORD = value ' dann neuen Wert übernehmen
                SetfswWORDVORLAGEN()
                'WordvorlagenNeuEinlesen(Me, New EventArgs)
                VorlagenEinlesenWord()
            Else
                If Directory.Exists("Vorlagen\Word") Then ' prüfen, ob der Standardpfad existiert
                    _pathWORD = "Vorlagen\Word"
                    SetfswWORDVORLAGEN()
                    VorlagenEinlesenWord()
                    'WordvorlagenNeuEinlesen(Me, New EventArgs)
                Else ' sonst Word Vorlagen abschlaten
                    TabItemWordVorlagen.IsEnabled = False
                    ListBoxVORALGENWord.IsEnabled = False
                End If
            End If
        End Set
    End Property

    ' ==========================================
    ' Word-Vorlagen-Verzeichnis
    ' ==========================================
    Private _wordvorlagen As IEnumerable(Of FileInfo)
    Public ReadOnly Property Wordvorlagen As IEnumerable(Of FileInfo)
        Get
            If IsNothing(_wordvorlagen) Then
                Try
                    Dim di As New DirectoryInfo(_pathWORD)
                    Dim dn As New System.Text.StringBuilder
                    With dn
                        .Append("*")
                        .Append(".")
                        .Append(_extensionWORD)
                    End With
                    _wordvorlagen = From i As FileInfo In di.GetFiles(dn.ToString)
                                    Where i.Attributes <> 34
                                    Select i
                Catch ex As Exception
                    MessageBox.Show("Die Word-Dokumentenvorlagen konnten nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Information)
                End Try
            End If
            Return _wordvorlagen
        End Get
    End Property

    'FileSystemWatcher für die Word-Vorlagen'
    Private Sub SetfswWORDVORLAGEN()
        Try
            fswWORDVORLAGEN = New FileSystemWatcher(_pathWORD)
            With fswWORDVORLAGEN
                .EnableRaisingEvents = True
                AddHandler .Created, AddressOf WordvorlagenNeuEinlesen
                AddHandler .Deleted, AddressOf WordvorlagenNeuEinlesen
                ' AddHandler .Changed, AddressOf WordvorlagenNeuEinlesen
                AddHandler .Renamed, AddressOf WordvorlagenNeuEinlesen
            End With
        Catch ex As Exception
            Console.WriteLine("FileSystemWatcher für WordVorlagen konnte nicht erstellt werden")
        End Try
    End Sub

    ' ==========================================================
    ' Einlesen der Word-Vorlagen in die Auswahlliste
    ' ==========================================================
    Private Sub VorlagenEinlesenWord()
        If ListBoxVORALGENWord.Dispatcher.CheckAccess() Then
            VorlagenNeuEinlesenWord()
        Else
            ListBoxVORALGENWord.Dispatcher.Invoke(New ReloadListBoxItems(AddressOf VorlagenNeuEinlesenWord), New Object)
        End If
    End Sub

    Private Sub VorlagenNeuEinlesenWord()
        _wordvorlagen = Nothing
        ListBoxVORALGENWord.ItemsSource = Wordvorlagen
    End Sub

    ' ==============================================================================
    ' FileSystemWatcher (Änderungen in dem Verzeichnis Word-Vorlagen)
    ' Liest den Inhalt des Verzeichnisses neu in die Listbox ein
    ' DEPRECATED => ist durch die Funktion VorlagenEinlesenWord, die Funktion VorlagenNeuEinlesenWord und de Delegaten ReloadListBoxItems erledigt
    ' Die Funktion ist nur als Merkposten noch vorhanden und kann eigentlich gelöscht werden
    ' ==============================================================================
    Private Sub WordvorlagenNeuEinlesen(sender As Object, e As FileSystemEventArgs)
        'Throw New NotImplementedException()
        Dispatcher.Invoke(Sub()
                              _wordvorlagen = Nothing
                              Try
                                  ListBoxVORALGENWord.ItemsSource = Wordvorlagen 'New DirectoryInfo(fl).GetFiles
                              Catch ex As Exception
                                  MessageBox.Show("Die Word-Dokumentenvorlagen konnten am angegebenen Ort nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Exclamation)
                              End Try
                          End Sub
        )
    End Sub

    ' ===================================================================================================================================
    ' ListBox (Auswahl => Doppelklick)
    ' ListBoxVORALGENWord
    ' => Öffnet eine Word-Dokumentenvorlage
    ' ===================================================================================================================================
    Private Sub ListBoxVORALGENWord_MouseDoubleClick(sender As Object, e As RoutedEventArgs) Handles ListBoxVORALGENWord.MouseDoubleClick
        Try
            ' An die Funktion zum Öffnen eines neuen Schreibens muss der aktive Briefkopf und die Textdatei übergeben werden
            lopstaWordSchnittstelleTextbausteine.ClassVorlageOeffnen.Oeffnen(ActiveBriefkopf, ListBoxVORALGENWord.SelectedItem.FullName)

            Dim d As New Dictionary(Of String, String)
            With d
                ' ........................................
                ' Werte werden in der Klasse UserControlAdressenListe 
                ' initialisiert, wenn Adresse ausgewählt wird
                ' ........................................
                .Add("Anschrift+Anrede", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschriftAnrede)
                .Add("Anschrift+Zeile01", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(1))
                .Add("Anschrift+Zeile02", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(2))
                .Add("Anschrift+Zeile03", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(3))
                .Add("Anschrift+Zeile04", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(4))
                .Add("Anschrift+Zeile05", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(5))
                .Add("Anschrift+Zeile06", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(6))
                .Add("Betreff+Zeile01", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBetreff.Zeile01)
                .Add("Betreff+Zeile02", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBetreff.Zeile02)
                .Add("Betreff+Zeile03", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBetreff.Zeile03)
                .Add("Betreff+Zeile04", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBetreff.Zeile04)
                .Add("RegNr", lopstaPROJEKTDATEN.AktivesProjekt.Registernummer)
                .Add("Datum", Date.Now.ToShortDateString)
                .Add("Aktenzeichen", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBetreff.Aktenzeichen)
                .Add("Briefanrede", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBriefanrede)
                ' ........................................
                ' Werte werden in der Klasse UserControlAdressenListe 
                ' initialisiert, wenn Adresse ausgewählt wird
                ' ........................................
                If Not IsNothing(lopstaControlAdressenVerzeichnis.ClassPublicMandant.Mandant) Then
                    .Add("Mdt+Name", lopstaControlAdressenVerzeichnis.ClassPublicMandant.Name)
                    .Add("Mdt+AnredeG", lopstaControlAdressenVerzeichnis.ClassPublicMandant.AnredeG)
                    .Add("Mdt+Anrede", lopstaControlAdressenVerzeichnis.ClassPublicMandant.Mandant.Anrede)
                    .Add("Mdt+Nachname", lopstaControlAdressenVerzeichnis.ClassPublicMandant.Mandant.Nachname)
                    .Add("Mdt+Vorname", lopstaControlAdressenVerzeichnis.ClassPublicMandant.Mandant.Vorname)
                    .Add("Mdt+Strasse", lopstaControlAdressenVerzeichnis.ClassPublicMandant.Mandant.Strasse)
                    .Add("Mdt+Postleitzahl", lopstaControlAdressenVerzeichnis.ClassPublicMandant.Mandant.Postleitzahl)
                    .Add("Mdt+Ort", lopstaControlAdressenVerzeichnis.ClassPublicMandant.Mandant.Ort)
                    .Add("Mdt+Adresse", lopstaControlAdressenVerzeichnis.ClassPublicMandant.Adresse)
                End If
            End With

            Select Case lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.AdresseTyp
                Case "lopstaControlAdressenVerzeichnis.ClassMandant"
                    ClassAdresseMandantUebernehmen.InListeTextfelderEinfuegen(d, lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.Mandant)
                    With d
                        ' .Add("Anrede", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.Mandant.Anrede)
                        ' .Add("Briefanrede", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.Mandant.Briefanrede)
                    End With
            End Select


            lopstaWordSchnittstelleTextbausteine.ClassFelderErsetzen.Ersetzen(d)
            'BringIntoView(System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application"))

        Catch ex As Exception
            MessageBox.Show("Die Word-Dokumentenvorlage lässt sich leider nicht verarbeiten." & ex.Message, "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub


    ' ===================================================================================================================================
    ' Suchen in der Liste der Vorlagen
    ' Eingaben in dem Textfeld TextBox<xxx>VorlageSUCHEN werden gefiltert.
    ' Die gefilterte Liste wird als ItemSource angebunden
    ' ===================================================================================================================================
    Private Sub TextBoxWordVorlageSUCHEN_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxWordVorlageSUCHEN.KeyUp
        ListBoxVORALGENWord.ItemsSource = From i In Wordvorlagen
                                          Where i.Name.Contains(sender.Text)
                                          Select i
    End Sub

    Private Sub TextBoxWordVorlageSUCHEN_GotKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles TextBoxWordVorlageSUCHEN.GotKeyboardFocus
        sender.text = String.Empty
    End Sub

    Private Sub ButtonBriefkopfBlanco_Click(sender As Object, e As RoutedEventArgs) Handles ButtonBriefkopfBlanco.Click
        Try
            ' An die Funktion zum Öffnen eines neuen Schreibens muss der aktive Briefkopf und die Textdatei übergeben werden
            lopstaWordSchnittstelleTextbausteine.ClassVorlageOeffnen.Oeffnen(ActiveBriefkopf, "blanko")

            If Not IsNothing(lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.AdresseTyp) Then

                Dim d As New Dictionary(Of String, String)
                With d
                    ' ........................................
                    ' Werte werden in der Klasse UserControlAdressenListe 
                    ' initialisiert, wenn Adresse ausgewählt wird
                    ' ........................................
                    .Add("Anschrift+Anrede", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschriftAnrede)
                    .Add("Anschrift+Zeile01", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(1))
                    .Add("Anschrift+Zeile02", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(2))
                    .Add("Anschrift+Zeile03", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(3))
                    .Add("Anschrift+Zeile04", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(4))
                    .Add("Anschrift+Zeile05", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(5))
                    .Add("Anschrift+Zeile06", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetPostanschrift(6))
                    .Add("Betreff+Zeile01", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBetreff.Zeile01)
                    .Add("Betreff+Zeile02", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBetreff.Zeile02)
                    .Add("Betreff+Zeile03", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBetreff.Zeile03)
                    .Add("Betreff+Zeile04", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBetreff.Zeile04)
                    .Add("RegNr", lopstaPROJEKTDATEN.AktivesProjekt.Registernummer)
                    .Add("Datum", Date.Now.ToShortDateString)
                    .Add("Aktenzeichen", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBetreff.Aktenzeichen)
                    .Add("Briefanrede", lopstaControlAdressenVerzeichnis.ClassPublicSelectedAdress.GetBriefanrede)
                End With

                lopstaWordSchnittstelleTextbausteine.ClassFelderErsetzen.Ersetzen(d)

                ' lopstaWordSchnittstelleTextbausteine.ClassActiveDocumentSaveAs.DocumentSaveAs(lopstaPROJEKTDATEN.AktivesProjekt.FullName, "testAutoSave")

            End If

            ' lopstaWordSchnittstelleTextbausteine.ClassListAllDocumentProperties.ListAllDocumentProperties()

        Catch ex As Exception
            MessageBox.Show("Die Word-Dokumentenvorlage lässt sich leider nicht verarbeiten." & ex.Message, "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

End Class
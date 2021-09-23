Imports System.ComponentModel
Imports System.IO
Imports System.Threading

Partial Public Class UserControlContainer

    ' ==========================================
    ' FileSystemWatcher
    ' für die Verzeichnisse
    '  => Vorlagen (Andere)
    ' ==========================================
    Private fswANDERE As FileSystemWatcher

    ' ==========================================
    ' Extension der Vorlagen
    ' ==========================================
    Private _extensionANDERE As String = "*"
    Public WriteOnly Property ExtensionANDERE As String
        Set(value As String)
            _extensionANDERE = "*"
        End Set
    End Property
    ' ==========================================
    ' Pfad zu dem Andere-Vorlagen-Verzeichnis
    ' ==========================================
    Private _pathANDERE As String
    Public WriteOnly Property PathANDERE As String
        Set(value As String)
            _pathANDERE = value
            If IsNothing(_pathANDERE) Then
                _pathANDERE = "Vorlagen\Andere"
            End If
            If Not Directory.Exists(_pathANDERE) Then
                Console.WriteLine(_pathANDERE)
            End If
            VorlagenEinlesenAndere()
            SetfswANDERE()
        End Set
    End Property

    ' ==========================================
    ' Andere-Vorlagen-Verzeichnis
    ' ==========================================
    Private _anderevorlagen As IEnumerable(Of FileInfo)
    Public ReadOnly Property AndereVorlagen As IEnumerable(Of FileInfo)
        Get
            If IsNothing(_anderevorlagen) Then
                Try
                    Dim di As New DirectoryInfo(_pathANDERE)
                    _anderevorlagen = di.GetFiles("*." & _extensionANDERE)
                Catch ex As Exception
                    MessageBox.Show("Die Vorlagen (Andere) konnten nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Information)
                End Try
            End If
            Return _anderevorlagen
        End Get
    End Property

    'FileSystemWatcher für die Anderen-Vorlagen'
    Private Sub SetfswANDERE()
        Try
            fswANDERE = New FileSystemWatcher
            With fswANDERE
                .Path = _pathANDERE
                .Filter = "*." & _extensionANDERE
                .EnableRaisingEvents = True
                AddHandler .Created, AddressOf AndereNeuEinlesen
                AddHandler .Deleted, AddressOf AndereNeuEinlesen
                AddHandler .Changed, AddressOf AndereNeuEinlesen
            End With
        Catch ex As Exception
            Console.WriteLine("FileSystemWatcher für Vorlagen  (Andere) konnte nicht erstellt werden")
        End Try
    End Sub

    ' ==========================================================
    ' Einlesen der Andere-Vorlagen in die Auswahlliste
    ' ==========================================================
    Private Sub VorlagenEinlesenAndere()
        ListBoxVORALGENAndere.ItemsSource = Nothing
        Dim fl As String
        Dim w = String.Empty ' MUSS BEREINIGT WERDEN
        If w IsNot String.Empty Then
            fl = ""
        Else
            If Directory.Exists("Vorlagen\Andere") Then
                fl = "Vorlagen\Andere"
            Else
                MessageBox.Show("Die Vorlagen (Andere) können nicht eingelesen werden. Es muss erst ein entsprechendes Verzeichnis erstellt und/oder angegeben werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Exclamation)
                ListBoxVORALGENAndere.IsEnabled = False
                Exit Sub
            End If
        End If
        Try
            ListBoxVORALGENAndere.ItemsSource = New DirectoryInfo(fl).GetFiles
        Catch ex As Exception
            MessageBox.Show("Die Vorlagen (Andere) konnten am angegebenen Ort nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End Try
    End Sub

    ' ==============================================================================
    ' FileSystemWatcher (Änderungen in dem Verzeichnis Andere-Vorlagen)
    ' Liest den Inhalt des Verzeichnisses neu in die Listbox ein
    ' ==============================================================================
    Private Sub AndereNeuEinlesen(sender As Object, e As FileSystemEventArgs)
        'Throw New NotImplementedException()
        Dispatcher.Invoke(Sub()
                              _anderevorlagen = Nothing
                              ListBoxVORALGENAndere.ItemsSource = AndereVorlagen
                          End Sub
        )
    End Sub

    ' ===================================================================================================================================
    ' ListBox (Auswahl => Doppelklick)
    ' ListBoxVORALGENAndere
    ' => Öffnet eine Vorlage
    ' ===================================================================================================================================
    Private Sub ListBoxVORALGENAndere_MouseDoubleClick(sender As Object, e As RoutedEventArgs) Handles ListBoxVORALGENAndere.MouseDoubleClick
        Try
            Process.Start(ListBoxVORALGENAndere.SelectedItem.FullName)
        Catch ex As Exception
            MessageBox.Show("Die Vorlage (Andere) lässt sich leider nicht öffnen.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub


    ' ===================================================================================================================================
    ' Suchen in der Liste der Vorlagen
    ' Eingaben in dem Textfeld TextBox<xxx>VorlageSUCHEN werden gefiltert.
    ' Die gefilterte Liste wird als ItemSource angebunden
    ' ===================================================================================================================================
    Private Sub TextBoxAndereVorlageSUCHEN_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxAndereVorlageSUCHEN.KeyUp
        ListBoxVORALGENAndere.ItemsSource = From i In AndereVorlagen
                                            Where i.Name.Contains(sender.Text)
                                            Select i
    End Sub

End Class
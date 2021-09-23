Imports System.ComponentModel
Imports System.IO
Imports System.Threading

Partial Public Class UserControlContainer

    ' ==========================================
    ' FileSystemWatcher
    ' für die Verzeichnisse
    '  => Vorlagen (Andere)
    ' ==========================================
    Private fswVOLLMACHTEN As FileSystemWatcher

    ' ==========================================
    ' Extension der Vorlagen
    ' ==========================================
    Private _extensionVOLLMACHTEN As String = "*"
    Public WriteOnly Property ExtensionVOLLMACHTEN As String
        Set(value As String)
            _extensionVOLLMACHTEN = "*"
        End Set
    End Property
    ' ==========================================
    ' Pfad zu dem Vollmachten-Vorlagen-Verzeichnis
    ' ==========================================
    Private _pathVOLLMACHTEN As String
    Public WriteOnly Property PathVOLLMACHTEN As String
        Set(value As String)
            _pathVOLLMACHTEN = value
            If IsNothing(_pathVOLLMACHTEN) Then
                _pathVOLLMACHTEN = "Vorlagen\Vollmachten"
            End If
            If Not Directory.Exists(_pathVOLLMACHTEN) Then
                Console.WriteLine(_pathVOLLMACHTEN)
            End If
            VorlagenEinlesenVollmachten()
            SetfswVOLLMACHTEN()
        End Set
    End Property

    ' ==========================================
    ' Vollmachten-Vorlagen-Verzeichnis
    ' ==========================================
    Private _vollmachten As IEnumerable(Of FileInfo)
    Public ReadOnly Property Vollmachten As IEnumerable(Of FileInfo)
        Get
            If IsNothing(_vollmachten) Then
                Try
                    Dim di As New DirectoryInfo(_pathVOLLMACHTEN)
                    _vollmachten = di.GetFiles("*." & _extensionVOLLMACHTEN)
                Catch ex As Exception
                    MessageBox.Show("Die Vorlagen (Andere) konnten nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Information)
                End Try
            End If
            Return _vollmachten
        End Get
    End Property

    'FileSystemWatcher für die Vorlagen (Vollmachten)'
    Private Sub SetfswVOLLMACHTEN()
        Try
            fswVOLLMACHTEN = New FileSystemWatcher
            With fswVOLLMACHTEN
                .Path = _pathVOLLMACHTEN
                .Filter = "*." & _extensionVOLLMACHTEN
                .EnableRaisingEvents = True
                AddHandler .Created, AddressOf VollmachtenNeuEinlesen
                AddHandler .Deleted, AddressOf VollmachtenNeuEinlesen
                AddHandler .Changed, AddressOf VollmachtenNeuEinlesen
            End With
        Catch ex As Exception
            Console.WriteLine("FileSystemWatcher für Vorlagen  (Vollmachten) konnte nicht erstellt werden")
        End Try
    End Sub

    ' ==========================================================
    ' Einlesen der Vorlagen (Vollmachten) in die Auswahlliste
    ' ==========================================================
    Private Sub VorlagenEinlesenVollmachten()
        ListBoxVORALGENVollmachten.ItemsSource = Nothing
        Dim fl As String
        Dim w = String.Empty ' MUSS BEREINIGT WERDEN
        If w IsNot String.Empty Then
            fl = ""
        Else
            If Directory.Exists("Vorlagen\Vollmachten") Then
                fl = "Vorlagen\Vollmachten"
            Else
                MessageBox.Show("Die Vorlagen (Vollmachten) können nicht eingelesen werden. Es muss erst ein entsprechendes Verzeichnis erstellt und/oder angegeben werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Exclamation)
                ListBoxVORALGENVollmachten.IsEnabled = False
                Exit Sub
            End If
        End If
        Try
            ListBoxVORALGENVollmachten.ItemsSource = New DirectoryInfo(fl).GetFiles
        Catch ex As Exception
            MessageBox.Show("Die Vorlagen (Vollmachten) konnten am angegebenen Ort nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End Try
    End Sub

    ' ==============================================================================
    ' FileSystemWatcher (Änderungen in dem Verzeichnis Vollmachten-Vorlagen)
    ' Liest den Inhalt des Verzeichnisses neu in die Listbox ein
    ' ==============================================================================
    Private Sub VollmachtenNeuEinlesen(sender As Object, e As FileSystemEventArgs)
        'Throw New NotImplementedException()
        Dispatcher.Invoke(Sub()
                              _vollmachten = Nothing
                              ListBoxVORALGENVollmachten.ItemsSource = Vollmachten
                          End Sub
        )
    End Sub

    ' ===================================================================================================================================
    ' ListBox (Auswahl => Doppelklick)
    ' ListBoxVORALGENVollmachten
    ' => Öffnet eine Vorlage
    ' ===================================================================================================================================
    Private Sub ListBoxVORALGENVollmachten_MouseDoubleClick(sender As Object, e As RoutedEventArgs) Handles ListBoxVORALGENVollmachten.MouseDoubleClick
        Try
            Process.Start(ListBoxVORALGENVollmachten.SelectedItem.FullName)
        Catch ex As Exception
            MessageBox.Show("Die Vorlage (Vollmacht) lässt sich leider nicht öffnen.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    ' ===================================================================================================================================
    ' Suchen in der Liste der Vorlagen
    ' Eingaben in dem Textfeld TextBox<xxx>VorlageSUCHEN werden gefiltert.
    ' Die gefilterte Liste wird als ItemSource angebunden
    ' ===================================================================================================================================
    Private Sub TextBoxVollmachtenVorlageSUCHEN_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxVollmachtenVorlageSUCHEN.KeyUp
        ListBoxVORALGENVollmachten.ItemsSource = From i In Vollmachten
                                                 Where i.Name.Contains(sender.Text)
                                                 Select i
    End Sub

End Class
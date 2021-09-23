Imports System.ComponentModel
Imports System.IO
Imports System.Threading

Partial Public Class UserControlContainer

    ' ==========================================
    ' FileSystemWatcher
    ' für die Verzeichnisse
    '  => Word-Vorlagen
    ' ==========================================
    Private fswFORMULARE As FileSystemWatcher

    ' ==========================================
    ' Extension der Wordvorlagen
    ' ==========================================
    Private _extensionFORMULARE As String = "pdf"
    Public WriteOnly Property ExtensionFORMULARE As String
        Set(value As String)
            Select Case value.ToLower
                Case "dot"
                    _extensionFORMULARE = "dot"
                Case ".dot"
                    _extensionFORMULARE = "dot"
                Case "dotx"
                    _extensionFORMULARE = "dotx"
                Case ".dotx"
                    _extensionFORMULARE = "dotx"
                Case ".pdf"
                    _extensionFORMULARE = "pdf"
                Case Else
                    _extensionFORMULARE = value
            End Select
        End Set
    End Property
    ' ==========================================
    ' Pfad zu dem Word-Vorlagen-Verzeichnis
    ' ==========================================
    Private _pathFORMULARE As String
    Public WriteOnly Property PathFORMULARE As String
        Set(value As String)
            _pathFORMULARE = value
            If IsNothing(_pathFORMULARE) Then
                _pathFORMULARE = "Vorlagen\Formulare"
            End If
            If Not Directory.Exists(_pathFORMULARE) Then
                Console.WriteLine(_pathFORMULARE)
            End If
            VorlagenEinlesenFormulare()
            SetfswFORMULARE()
        End Set
    End Property

    ' ==========================================
    ' Word-Vorlagen-Verzeichnis
    ' ==========================================
    Private _formulare As IEnumerable(Of FileInfo)
    Public ReadOnly Property Formulare As IEnumerable(Of FileInfo)
        Get
            If IsNothing(_formulare) Then
                Try
                    Dim di As New DirectoryInfo(_pathFORMULARE)
                    _formulare = di.GetFiles("*." & _extensionFORMULARE)
                Catch ex As Exception
                    MessageBox.Show("Die Formulare konnten nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Information)
                End Try
            End If
            Return _formulare
        End Get
    End Property

    'FileSystemWatcher für die Word-Vorlagen'
    Private Sub SetfswFORMULARE()
        Try
            fswFORMULARE = New FileSystemWatcher
            With fswFORMULARE
                .Path = _pathFORMULARE
                .Filter = "*." & _extensionFORMULARE
                .EnableRaisingEvents = True
                AddHandler .Created, AddressOf FormulareNeuEinlesen
                AddHandler .Deleted, AddressOf FormulareNeuEinlesen
                AddHandler .Changed, AddressOf FormulareNeuEinlesen
            End With
        Catch ex As Exception
            Console.WriteLine("FileSystemWatcher für Formulare konnte nicht erstellt werden")
        End Try
    End Sub

    ' ==========================================================
    ' Einlesen der Formulare in die Auswahlliste
    ' ==========================================================
    Private Sub VorlagenEinlesenFormulare()
        ListBoxVORALGENFormulare.ItemsSource = Nothing
        Dim fl As String
        Dim w = String.Empty ' MUSS BEREINIGT WERDEN
        If w IsNot String.Empty Then
            fl = ""
        Else
            If Directory.Exists("Vorlagen\Formulare") Then
                fl = "Vorlagen\Formulare"
            Else
                MessageBox.Show("Die Formulare können nicht eingelesen werden. Es muss erst ein entsprechendes Verzeichnis erstellt und/oder angegeben werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Exclamation)
                ListBoxVORALGENFormulare.IsEnabled = False
                Exit Sub
            End If
        End If
        Try
            ListBoxVORALGENFormulare.ItemsSource = New DirectoryInfo(fl).GetFiles
        Catch ex As Exception
            MessageBox.Show("Die Formulare konnten am angegebenen Ort nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End Try
    End Sub

    ' ==============================================================================
    ' FileSystemWatcher (Änderungen in dem Verzeichnis Formulare)
    ' Liest den Inhalt des Verzeichnisses neu in die Listbox ein
    ' ==============================================================================
    Private Sub FormulareNeuEinlesen(sender As Object, e As FileSystemEventArgs)
        'Throw New NotImplementedException()
        Dispatcher.Invoke(Sub()
                              _formulare = Nothing
                              ListBoxVORALGENFormulare.ItemsSource = Formulare
                          End Sub
        )
    End Sub

    ' ===================================================================================================================================
    ' ListBox (Auswahl => Doppelklick)
    ' ListBoxVORALGENFormulare
    ' => Öffnet ein Formular
    ' ===================================================================================================================================
    Private Sub ListBoxVORALGENFormulare_MouseDoubleClick(sender As Object, e As RoutedEventArgs) Handles ListBoxVORALGENFormulare.MouseDoubleClick
        Try
            Process.Start(ListBoxVORALGENFormulare.SelectedItem.FullName)
        Catch ex As Exception
            MessageBox.Show("Die Word-Dokumentenvorlage lässt sich leider nicht öffnen.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
        ListBoxVORALGENFormulare.SelectedIndex = -1
    End Sub

    ' ===================================================================================================================================
    ' Suchen in der Liste der Vorlagen
    ' Eingaben in dem Textfeld TextBox<xxx>VorlageSUCHEN werden gefiltert.
    ' Die gefilterte Liste wird als ItemSource angebunden
    ' ===================================================================================================================================
    Private Sub TextBoxFormularVorlageSUCHEN_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxFormularVorlageSUCHEN.KeyUp
        ListBoxVORALGENFormulare.ItemsSource = From i In Formulare
                                               Where i.Name.Contains(sender.Text)
                                               Select i
    End Sub


End Class

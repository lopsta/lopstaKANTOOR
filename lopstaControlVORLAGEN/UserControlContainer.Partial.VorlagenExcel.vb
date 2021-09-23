Imports System.ComponentModel
Imports System.IO
Imports System.Threading

Partial Public Class UserControlContainer

    ' ==========================================
    ' FileSystemWatcher
    ' für die Verzeichnisse
    '  => Excel-Vorlagen
    ' ==========================================
    Private fswEXCELVORLAGEN As FileSystemWatcher

    ' ==========================================
    ' Extension der Excelvorlagen
    ' ==========================================
    Private _extensionEXCEL As String = "xlt*"
    Public WriteOnly Property ExtensionEXCEL As String
        Set(value As String)
            Select Case value.ToLower
                Case "xlt"
                    _extensionEXCEL = "xlt"
                Case ".xlt"
                    _extensionEXCEL = "xlt"
                Case "xltx"
                    _extensionEXCEL = "xltx"
                Case ".xltx"
                    _extensionEXCEL = "xltx"
                Case "xlt*"
                    _extensionEXCEL = "xlt*"
                Case ".xlt*"
                    _extensionEXCEL = "xlt*"
                Case "*"
                    _extensionEXCEL = "*"
                Case ".*"
                    _extensionEXCEL = "*"
                Case "any"
                    _extensionEXCEL = "*"
                Case "alle"
                    _extensionEXCEL = "*"
                Case ""
                    _extensionEXCEL = "*"
                Case "excel"
                    _extensionEXCEL = "xlt*"
                Case Else
                    _extensionEXCEL = value
            End Select
        End Set
    End Property
    ' ==========================================
    ' Pfad zu dem Excel-Vorlagen-Verzeichnis
    ' ==========================================
    Private _pathEXCEL As String
    Public WriteOnly Property PathEXCEL As String
        Set(value As String)
            _pathEXCEL = value
            If IsNothing(_pathEXCEL) Then
                _pathEXCEL = "Vorlagen\Excel"
            End If
            If Not Directory.Exists(_pathEXCEL) Then
                Console.WriteLine(_pathEXCEL)

            End If
            VorlagenEinlesenExcel()
            SetfswEXCELVORLAGEN()
        End Set
    End Property

    ' ==========================================
    ' Excel-Vorlagen-Verzeichnis
    ' ==========================================
    Private _excelvorlagen As IEnumerable(Of FileInfo)
    Public ReadOnly Property Excelvorlagen As IEnumerable(Of FileInfo)
        Get
            If IsNothing(_excelvorlagen) Then
                Try
                    Dim di As New DirectoryInfo(_pathEXCEL)
                    _excelvorlagen = di.GetFiles("*." & _extensionEXCEL)
                Catch ex As Exception
                    MessageBox.Show("Die Excel-Dokumentenvorlagen konnten nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Information)
                End Try
            End If
            Return _excelvorlagen
        End Get
    End Property

    'FileSystemWatcher für die Excel-Vorlagen'
    Private Sub SetfswEXCELVORLAGEN()
        Try
            fswEXCELVORLAGEN = New FileSystemWatcher
            With fswEXCELVORLAGEN
                .Path = _pathEXCEL
                .Filter = "*." & _extensionEXCEL
                .EnableRaisingEvents = True
                AddHandler .Created, AddressOf ExcelvorlagenNeuEinlesen
                AddHandler .Deleted, AddressOf ExcelvorlagenNeuEinlesen
                AddHandler .Changed, AddressOf ExcelvorlagenNeuEinlesen
            End With
        Catch ex As Exception
            Console.WriteLine("FileSystemWatcher für ExcelVorlagen konnte nicht erstellt werden")
        End Try
    End Sub

    ' ==========================================================
    ' Einlesen der Excel-Vorlagen in die Auswahlliste
    ' ==========================================================
    Private Sub VorlagenEinlesenExcel()
        ListBoxVORALGENExcel.ItemsSource = Nothing
        Dim fl As String
        Dim w = String.Empty ' MUSS BEREINIGT WERDEN
        If w IsNot String.Empty Then
            fl = ""
        Else
            If Directory.Exists("Vorlagen\Excel") Then
                fl = "Vorlagen\Excel"
            Else
                MessageBox.Show("Die Excel-Dokumentenvorlagen können nicht eingelesen werden. Es muss erst ein entsprechendes Verzeichnis erstellt und/oder angegeben werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Exclamation)
                ListBoxVORALGENExcel.IsEnabled = False
                Exit Sub
            End If
        End If
        Try
            ListBoxVORALGENExcel.ItemsSource = New DirectoryInfo(fl).GetFiles
        Catch ex As Exception
            MessageBox.Show("Die Excel-Dokumentenvorlagen konnten am angegebenen Ort nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        End Try
    End Sub

    ' ==============================================================================
    ' FileSystemWatcher (Änderungen in dem Verzeichnis Excel-Vorlagen)
    ' Liest den Inhalt des Verzeichnisses neu in die Listbox ein
    ' ==============================================================================
    Private Sub ExcelvorlagenNeuEinlesen(sender As Object, e As FileSystemEventArgs)
        'Throw New NotImplementedException()
        Dispatcher.Invoke(Sub()
                              _excelvorlagen = Nothing
                              ListBoxVORALGENExcel.ItemsSource = Excelvorlagen
                          End Sub
        )
    End Sub

    ' ===================================================================================================================================
    ' ListBox (Auswahl => Doppelklick)
    ' ListBoxVORALGENExcel
    ' => Öffnet eine Excel-Dokumentenvorlage
    ' ===================================================================================================================================
    Private Sub ListBoxVORALGENExcel_MouseDoubleClick(sender As Object, e As RoutedEventArgs) Handles ListBoxVORALGENExcel.MouseDoubleClick
        Try
            Process.Start(ListBoxVORALGENExcel.SelectedItem.FullName)
        Catch ex As Exception
            MessageBox.Show("Die Excel-Dokumentenvorlage lässt sich leider nicht öffnen.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub


    ' ===================================================================================================================================
    ' Suchen in der Liste der Vorlagen
    ' Eingaben in dem Textfeld TextBox<xxx>VorlageSUCHEN werden gefiltert.
    ' Die gefilterte Liste wird als ItemSource angebunden
    ' ===================================================================================================================================
    Private Sub TextBoxExcelVorlageSUCHEN_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxExcelVorlageSUCHEN.KeyUp
        ListBoxVORALGENExcel.ItemsSource = From i In Excelvorlagen
                                           Where i.Name.Contains(sender.Text)
                                           Select i
    End Sub

End Class
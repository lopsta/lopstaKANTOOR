Imports System.ComponentModel
Imports System.IO
Imports System.Threading

Partial Public Class UserControlContainer

    Dim _activebriefkopf As String
    Public ReadOnly Property ActiveBriefkopf As String
        Get
            Return _activebriefkopf
        End Get
    End Property

    ' ==========================================
    ' Delegate für ComboBox Update
    ' ==========================================

    Public Delegate Sub ReloadComboBoxItemsBriefkoepfe()

    ' ==========================================
    ' FileSystemWatcher
    ' für die Verzeichnisse
    '  => Briefkopf
    ' ==========================================
    Private fswBRIEFKOPF As FileSystemWatcher

    ' ==========================================
    ' Pfad zu dem Briefkopf-Verzeichnis
    ' ==========================================
    Private _pathBRIEFKOPF As String = "Vorlagen\Briefkopf" ' zunälchst (osicherheitshalber auf Standardwert setzen
    Public WriteOnly Property PathBRIEFKOPF As String
        Set(value As String)
            If Directory.Exists(value) Then ' Prüfen, ob der angegebene Pfad existiert
                _pathBRIEFKOPF = value ' dann neuen Wert übernehmen
                SetfswBRIEFKOPF()
                BriefkoepfeEinlesen()
            Else
                If Directory.Exists("Vorlagen\Briefkopf") Then ' prüfen, ob der Standardpfad existiert
                    _pathBRIEFKOPF = "Vorlagen\Briefkopf"
                    SetfswBRIEFKOPF()
                    BriefkoepfeEinlesen()
                Else ' sonst Word Vorlagen abschlaten
                    TabItemWordVorlagen.IsEnabled = False
                    ListBoxVORALGENWord.IsEnabled = False
                    ComboBoxBriefkoepfe.IsEnabled = False
                End If
            End If
        End Set
    End Property

    ' ==========================================
    ' Verzeichnis Briefkoepfe
    ' ==========================================
    Private _briefkoepfe As IEnumerable(Of FileInfo)
    Public ReadOnly Property Briefkoepfe As IEnumerable(Of FileInfo)
        Get
            If IsNothing(_briefkoepfe) Then
                Try
                    Dim di As New DirectoryInfo(_pathBRIEFKOPF)
                    Dim dn As New System.Text.StringBuilder
                    With dn
                        .Append("*")
                        .Append(".")
                        .Append(_extensionWORD)
                    End With
                    _briefkoepfe = From i As FileInfo In di.GetFiles(dn.ToString)
                                   Where i.Attributes <> 34
                                   Where Not i.Name.Contains("~")
                                   Select i
                Catch ex As Exception
                    MessageBox.Show("Die Briefköpfe konnten nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Information)
                End Try
            End If
            Return _briefkoepfe
        End Get
    End Property

    'FileSystemWatcher für die Briefköpfe'
    Private Sub SetfswBRIEFKOPF()
        Try
            fswBRIEFKOPF = New FileSystemWatcher(_pathBRIEFKOPF)
            With fswBRIEFKOPF
                '.EnableRaisingEvents = True
                'AddHandler .Created, AddressOf BriefkoepfeEinlesen
                'AddHandler .Deleted, AddressOf BriefkoepfeEinlesen
                'AddHandler .Renamed, AddressOf BriefkoepfeEinlesen
            End With
        Catch ex As Exception
            Console.WriteLine("FileSystemWatcher für WordVorlagen konnte nicht erstellt werden")
        End Try
    End Sub

    ' ==========================================================
    ' Einlesen der Briefköpfe in die Combobox
    ' ==========================================================
    Private Sub BriefkoepfeEinlesen()
        If ComboBoxBriefkoepfe.Dispatcher.CheckAccess() Then
            BriefkoepfeNeuEinlesen()
        Else
            ComboBoxBriefkoepfe.Dispatcher.Invoke(New ReloadComboBoxItemsBriefkoepfe(AddressOf BriefkoepfeNeuEinlesen), New Object)
        End If
    End Sub

    Private Sub BriefkoepfeNeuEinlesen()
        _briefkoepfe = Nothing
        ComboBoxBriefkoepfe.ItemsSource = Briefkoepfe
        If ComboBoxBriefkoepfe.Items.Count > 0 Then
            _activebriefkopf = ComboBoxBriefkoepfe.Items(0).FullName
            ComboBoxBriefkoepfe.SelectedIndex = 0
        Else
            Dim di As New DirectoryInfo("Vorlagen\Briefkopf")
            _activebriefkopf = di.GetFiles.First.FullName
        End If

    End Sub

    Private Sub ComboBoxBriefkoepfe_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ComboBoxBriefkoepfe.SelectionChanged
        If ComboBoxBriefkoepfe.Items.Count > 1 Then
            _activebriefkopf = ComboBoxBriefkoepfe.SelectedItem.FullName
        End If
    End Sub
End Class

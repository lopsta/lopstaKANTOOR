Imports System.ComponentModel
Imports System.IO

Class MainWindow



    ' NEW #####################################################################################################################################
    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        _isinstalled = CheckIsInstalled()
        _isportable = CheckIsPortable()

        ' ..................................................................................
        ' Prüfen, und ggfls. erstellen der Settings.
        ' Entbehrlich, wenn beim Programmstart auf die Eigenschaft AppSettings zugegriffen
        ' wird, da die Funktion dort implementiert ist
        ' ..................................................................................
        CheckAndGenerateAppSettings()
        CheckAndGenerateUserSettings()

        ' ..................................................................................
        ' Die Benutzerauswahl auf den ersten eingetragenen Benutzer setzen
        ' ..................................................................................
        ' @ToDo kann wohl gelöscht werden ....
        'SelectedUserIndex = 0
        'Me.Title = "lopstaDateiBrowser " & User.Item(SelectedUserIndex).Label & " [" & User.Item(SelectedUserIndex).UserID & "]"


    End Sub

    ' L O A D E D #############################################################################################################################
    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Try
            If _appsettings.IsMultiUser Then
                If Not String.IsNullOrEmpty(_appsettings.LastUsedUser) Then
                    SelectedUserKey = _appsettings.LastUsedUser
                Else
                    ShowDialogBenutzerAuswaehlen()
                End If
            Else
                ButtonLeftMenuBenutzer.Visibility = Visibility.Collapsed
                SelectedUserKey = User.Keys(0)
            End If
        Catch ex As Exception
            MessageBox.Show("Beim Start des Programms ist ein schwerer Fehler aufgetreten, so dass das Programm nicht gestartet werden kann.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
            My.Application.Shutdown()
        End Try
        ' Setup der verschiedenen Programmbestandteile
        Try
            ' Fenstertitel anpassen ........................................................
            Me.Title = "lopstaKANTOOR (Benutzer: " & User(SelectedUserKey).Label & ")"
            ' Auswahlliste der Projekte laden und einfügen .................................
            '_pathPROJEKTE = Nothing
            '_projekte = Nothing
            'ListBoxPROJEKTE.ItemsSource = Projekte
            AenderungenInSettingsUebernehmen()
        Catch ex As Exception
            MessageBox.Show("Leider ist beim start des Programms ein Fehler aufgetreten.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub




    ' W I N D O W S T A T E ###################################################################################################################
    Private Sub MainWindow_StateChanged(sender As Object, e As EventArgs) Handles Me.StateChanged

    End Sub

    ' C L O S I N G ###########################################################################################################################
    Private Sub MainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        WriteAppSettings(PathFileAppSettings)
    End Sub

    ' F I N A L I Z E #############################################################################################################
    Protected Overrides Sub Finalize()

        MyBase.Finalize()

    End Sub


    ' E I G E N S C H A F T E N ###############################################################################################################


    ' =======================================
    ' Pfad zum Installationsverzeichnis des
    ' Programms.
    ' Wird zur Vereinfachung genutzt
    ' =======================================
    Private _pathapp As String = String.Empty
    Private ReadOnly Property PathApp As String
        Get
            If String.IsNullOrEmpty(_pathapp) Then
                _pathapp = My.Application.Info.DirectoryPath
            End If
            Return _pathapp
        End Get
    End Property


    ' ===========================================
    ' Pfad zum Verzeichnis
    ' c:\user\<Benutzer>\AppData\Local\<Programmname>
    ' Wird zur Vereinfachung genutzt.
    ' Das Verzeichnis wird mit Unterverzeichnissen
    ' angelegt, wenn es nicht vorhanden ist.
    ' ===========================================
    Private _pathappdata As String = String.Empty
    Public ReadOnly Property PathAppData As String
        Get
            If IsInstalled Then
                If String.IsNullOrEmpty(_pathappdata) Then
                    Dim di As New DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), My.Application.Info.AssemblyName))
                    If Not di.Exists Then
                        di.Create()
                        'di.CreateSubdirectory("Benutzer")
                        'di.CreateSubdirectory("Einstellungen")
                    End If
                    _pathappdata = di.FullName
                End If
                Return _pathappdata
            End If
            Return Nothing
        End Get
    End Property


    ' ======================================
    ' Gibt an, ob es sich um eine Portable
    ' Version des Programms handelt.
    ' Das ist der Fall, wenn das Programm
    ' nicht in einem Verzeichnis 
    ' c:\Program Files oder c:\Program Files [86]
    ' gespeichert ist.
    ' ======================================
    Private _isportable As Boolean
    Public ReadOnly Property IsPortable As Boolean
        Get
            Return _isportable
        End Get
    End Property


    ' =======================================
    ' Prüft, ob es sich um eine installierte
    ' Programmversion handelt. Dazu muss das
    ' Programm in einem der beiden std.
    ' Programmverzeichnissen gespeichert sein.
    ' Sie auch Beschreibung zu IsPortable
    ' =======================================
    Private _isinstalled As Boolean
    Public ReadOnly Property IsInstalled As Boolean
        Get
            Return _isinstalled
        End Get
    End Property


    ' E R E I G N I S S E #####################################################################################################################

    ' D E L E G A T E N #######################################################################################################################

    ' M E T H O D E N #########################################################################################################################

    ' ...............................................................................................
    ' Prüfen, ob es sich um eine installierte Version handelt
    ' Die Funktion gibt True oder False zurück
    ' Sie ist erforderlich, da keine Public Property mit dem Anfangswert Nothing
    ' erstellt werden kann. 
    ' Die Funktion soll in New aufgerufen werden.
    ' ...............................................................................................
    Private Function CheckIsInstalled() As Boolean
        Dim drvinf As New DriveInfo(Path.GetPathRoot(PathApp))
        If drvinf.DriveType = DriveType.Fixed Then
            Select Case Directory.GetParent(My.Application.Info.DirectoryPath).FullName
                Case System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86)
                    Return True
                Case System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles)
                    Return True
                Case "c:\Program Files"
                    Return True
                Case "c:\Program Files (x86)"
                    Return True
                Case Else
                    Return False
            End Select
        End If
        Return False
    End Function

    ' ...............................................................................................
    ' Prüfen, ob es sich um eine portable Version handelt. Dazu muss das Programm in einem 
    ' Verzeichnis auf einem "Remouvable" Datenträger gespeichert sein.
    ' Siehe auch Funktion CheckIsInstalled
    ' ...............................................................................................
    Private Function CheckIsPortable() As Boolean
        Dim drvinf As New DriveInfo(Path.GetPathRoot(PathApp))
        If drvinf.DriveType = DriveType.Removable Then
            Return True
        Else
            Return False
        End If
        Return False
    End Function

    Private Function CheckIsMultiUser() As Boolean
        If Not IsNothing(AppSettings.IsMultiUser) Then
            Return AppSettings.IsMultiUser
        End If
        Return False
    End Function

    ' S E T T I N G S  O R  U S E R S E T T I N G S  C H A N G E D ############################################################################


    ' B U T T O N  C L I C K  E R E I G N I S S E #############################################################################################

    ' L I S T B O X  S E L E C T I O N  C H A N G E D  E R E I G N I S S E ####################################################################

End Class

Imports System.IO

Partial Public Class MainWindow

    ' E I G E N S C H A F T E N ###############################################################################################################

    ' @ToDO kann wohl gelöscht werden, wenn in Settings gespeichert
    Private _isMultiUser As Boolean
    Public ReadOnly Property IsMultiUser As Boolean
        Get
            'Return _isMultiUser
            Return _appsettings.IsMultiUser
        End Get
    End Property

    ' ==========================================
    ' Pfad zu den Benutzer XML-Dateien
    ' Standard-Pfad ist das Unterverzeichnis
    ' Benutzer (relativ zum Anwendungs.exe)
    ' Der Wert ist in der App.config fest eingestellt
    ' und kann nur dort angepasst werden
    ' ==========================================
    Private _pathusers As String = String.Empty
    Public ReadOnly Property PathUsers As String
        Get
            If String.IsNullOrEmpty(_pathusers) Then
                If IsInstalled Then
                    Dim di As New DirectoryInfo(Path.Combine(PathAppData, "Benutzer"))
                    If Not di.Exists Then
                        Try
                            di.Create()
                        Catch ex As Exception
                            MessageBox.Show("Es konnte kein Verzeichnis zum Speichern der Benutzer gefunden oder angelegt werden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error)
                        End Try
                    End If
                    _pathusers = Path.Combine(PathAppData, "Benutzer")
                Else
                    Dim di As New DirectoryInfo(Path.Combine(PathApp, "Benutzer"))
                    If Not di.Exists Then
                        Try
                            di.Create()
                        Catch ex As Exception
                            MessageBox.Show("Es konnte kein Verzeichnis zum Speichern der Benutzer gefunden oder angelegt werden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error)
                        End Try
                    End If
                    _pathusers = Path.Combine(PathApp, "Benutzer")
                End If
            End If
            Return _pathusers
        End Get
    End Property


    ' ==========================================
    ' Liste aller Benutzer im Verzeichnis Benutzer.
    ' Wurde noch kein Benutzer anglegt wird eine Standarddatei im Verzeichnis Benutzer erzeugt.
    ' ==========================================

    Private _user As Dictionary(Of String, ClassUser) = Nothing
    Public ReadOnly Property User As Dictionary(Of String, ClassUser)
        Get
            If IsNothing(_user) Then
                Try
                    _user = New Dictionary(Of String, ClassUser)
                    Dim di As New DirectoryInfo(PathUsers)
                    If di.GetFiles("*.user.xml").Count < 1 Then
                        SaveDefaultUser()
                        MessageBox.Show("Es musste ein neuer ´Default Benutzer´ angelegt werden. Das Programm kann daher nicht fortgesetzt werden. Bitte starten Sie das Programm neu.", "Wichtiger Hinweis!", MessageBoxButton.OK, MessageBoxImage.Exclamation)
                        My.Application.Shutdown()
                    End If
                    For Each f As FileInfo In di.GetFiles("*.user.xml")
                        _user.Add(f.FullName, ReadUserSettings(f.FullName))
                    Next
                Catch ex As Exception
                    MessageBox.Show("Die Liste der Nenutzer konnte nicht eingelesen werden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error)
                End Try
            End If
            Return _user
        End Get
    End Property


    ' ==========================================
    ' im Multibenutzermodus der ausgewählte Benutzer als Index
    ' ==========================================
    Private _selelecteduserkey As String = Nothing
    Public Property SelectedUserKey As String
        Get
            If IsNothing(_selelecteduserkey) Then
                Try
                    _selelecteduserkey = User.Keys(0).ToString
                Catch ex As Exception
                    MessageBox.Show("In der Benutzerverwaltung ist ein schwerer Fehler aufgetreten. Es muss wenigstens ein Benutzer angelegt sein.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
                End Try
            End If
            Return _selelecteduserkey
        End Get
        Set(value As String)
            _selelecteduserkey = value
            _appsettings.LastUsedUser = _selelecteduserkey
        End Set
    End Property


    Public ReadOnly Property DefaultUser As ClassUser
        Get
            Dim u As New ClassUser With {.UserID = "XDEFAULT-USER-USER-USER-000000000000",
                        .Anrede = "",
                        .Nachname = "Benutzer",
                        .Vorname = "Default",
                        .Titel = ""}
            If IsInstalled Then
                With u
                    .PathPROJEKTE = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                    '.PathTEXTBAUSTEINE = Path.Combine(PathApp, "Textbausteine"),
                    .PathWORDVORLAGEN = Path.Combine(PathApp, "Vorlagen", "Word")
                    '.PathEXCELVORLAGEN = Path.Combine(PathApp, "Vorlagen", "Excel")
                End With
            Else
                With u
                    .PathPROJEKTE = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                    '.PathTEXTBAUSTEINE = Path.Combine(PathApp, "Textbausteine"),
                    .PathWORDVORLAGEN = Path.Combine(PathApp, "Vorlagen", "Word")
                    '.PathEXCELVORLAGEN = Path.Combine(PathApp, "Vorlagen", "Excel")
                End With
            End If
            Return u
        End Get
    End Property


    ' E R E I G N I S S E #####################################################################################################################
    'Private Event SelectedUserChanged(sender As Object, e As RoutedEventArgs)



    ' D E L E G A T E N #######################################################################################################################



    ' M E T H O D E N #########################################################################################################################


    ' B U T T O N  C L I C K  E R E I G N I S S E #############################################################################################
    Private Sub ButtonLeftMenuBenutzer_Click(sender As Object, e As RoutedEventArgs) Handles ButtonLeftMenuBenutzer.Click
        ShowDialogBenutzerAuswaehlen()
    End Sub

    Private Sub ShowDialogBenutzerAuswaehlen()
        Using dlg As New DialogWindowUser
            With dlg
                .Topmost = True
                .ShowInTaskbar = False
                ' .Title = "Einstellungen [Benutzer: " & User(SelectedUserIndex).Label & " " & User(SelectedUserIndex).UserID ' Anpassen der angezeigten Fensterüberschrift
                .Users = User
            End With
            ClassDialogPositioning.SetDialogPosition(dlg)
            dlg.ShowDialog()
            ' ...........................................................................
            ' => Änderungen, wenn in der Benutzerauswahl ein anderer Benutzer gewählt wurde
            ' ...........................................................................
            If dlg.DialogResult = True Then
                With dlg
                    SelectedUserKey = .SelectedUserKey
                End With
                ' Änderungen übernehmen ................................................
                Me.Title = "lopstaKANZLEI (Benutzer: " & User(SelectedUserKey).Label & ")" ' Window-Title anpassen
                ' Änderungen in Projekte
                _pathPROJEKTE = Nothing
                _projekte = Nothing
                ListBoxPROJEKTE.ItemsSource = Projekte
                ' Änderungen in dem Modul lopstaControlVORLAGEN ........................
                With UserControlVORLAGEN
                    .ExtensionWord = "dot?"
                    .PathWORD = User(SelectedUserKey).PathWORDVORLAGEN
                    .PathBRIEFKOPF = User(SelectedUserKey).PathWORDVORLAGEN
                End With
            End If
        End Using
    End Sub

End Class

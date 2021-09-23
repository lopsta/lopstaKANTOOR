' ==============================================================================
' Settings
' ==============================================================================

Imports System.IO

Partial Public Class MainWindow


    ' E I G E N S C H A F T E N ###############################################################################################################


    ' ===============================================
    ' Liest und Schreibt die die Einstellungen.
    ' Zum Speicherort siehe Beschreibung zu 
    ' PathFileAppSettings.
    ' Wenn IsAutoSaveAppSettings gesetzt ist, dann
    ' kann die Speicherung nach einer Änderung der
    ' Einstellungen automatisch erfolgen.
    ' ===============================================
    Private _appsettings As ClassSettings
    Public Property AppSettings As ClassSettings
        Get
            If IsNothing(_appsettings) Then
                ReadAppSettings(PathFileAppSettings)
            End If
            Return _appsettings
        End Get
        Set(value As ClassSettings)
            _appsettings = value
            If IsAutoSaveAppSettings Then
                WriteAppSettings(PathFileAppSettings)
            Else
                If MessageBox.Show("Sollen die Einstellungen jetzt gespeichert werden?", "Einstellungen speichern ...", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) = MessageBoxResult.Yes Then
                    WriteAppSettings(PathFileAppSettings)
                End If
            End If
        End Set
    End Property


    ' ================================================
    ' Pfad zu der XML-Datei, in der die Einstellungen
    ' gespeichert sind. 
    ' Handelt es sich um eine installierte Programmversion
    ' (IsInstalled), dann werden die Einstellungen in
    ' dem Verzeichnis AppData\<Programmname>
    ' gespeichert.
    ' Bei der portablen Version werden die Einstellungen
    ' im gleichen Verzeichnis, wie das Programm gespeichert
    ' ================================================
    Private _pathfileappsettings As String = String.Empty
    Public ReadOnly Property PathFileAppSettings As String
        Get
            If String.IsNullOrEmpty(_pathfileappsettings) Then
                If IsInstalled Then
                    _pathfileappsettings = Path.Combine(PathAppData, "Einstellungen", "Einstellungen.xml")
                Else
                    _pathfileappsettings = Path.Combine(PathApp, "Einstellungen.xml")
                End If
            End If
            Return _pathfileappsettings
        End Get
    End Property


    ' ==============================================
    ' Bezeichnet, ob Änderungen der Einstellungen
    ' automatisch gespeichert werden dürfen.
    ' Wird ggfla. automatisch auf True gesetzt.
    ' ==============================================
    Private _isautosaveappsettings As Nullable(Of Boolean)
    Public Property IsAutoSaveAppSettings As Boolean
        Get
            If IsNothing(_isautosaveappsettings) Then
                _isautosaveappsettings = True
            End If
            Return _isautosaveappsettings
        End Get
        Set(value As Boolean)
            _isautosaveappsettings = value
        End Set
    End Property


    ' E R E I G N I S S E #####################################################################################################################

    ' D E L E G A T E N #######################################################################################################################


    ' M E T H O D E N #########################################################################################################################


    ' =====================================================================================
    ' Lesen der AppSettings
    ' =====================================================================================
    Private Sub ReadAppSettings(p As String)
        _appsettings = New ClassSettings
        Try
            Dim s As New Xml.Serialization.XmlSerializer(GetType(ClassSettings)) ' searializer
            Dim r As New FileStream(p, FileMode.Open) ' reader
            _appsettings = s.Deserialize(r)
            GrabSettingsTolopstaAppSettings() ' ToDo Die kompletten Setting müssten nach dorthin ausgelagert werden. Es ist ungünstig, wenn die Settings im Hauptprogramm liegen und deshalb nicht einfach von den UserControls abgerufen werden können
            r.Dispose()
            r = Nothing
            s = Nothing
        Catch ex As Exception
            MessageBox.Show("Die Einstellungen konnten leider nicht geladen werden. " & ex.Message, "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub


    ' =====================================================================================
    ' Schreiben der AppSettings
    ' =====================================================================================
    Private Sub WriteAppSettings(p As String)
        Dim s As New Xml.Serialization.XmlSerializer(GetType(ClassSettings)) ' searializer
        Try
            Using w As New FileStream(p, FileMode.Create) ' writer
                s.Serialize(w, AppSettings)
            End Using
        Catch ex As Exception
            MessageBox.Show("Die Einstellungen konnten leider nicht gespeichert werden. " & ex.Message, "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
        s = Nothing
    End Sub

    ' =====================================================================================
    ' Übernimmt die Settings in lopstaAppSettings
    ' Dies Klasse soll langfristig wegfallen, wenn alls Settings in lopstaAppSettings ausgelagert sind,
    ' damit die Settings einfach von allem Modulen aufgerufen werden können
    ' =====================================================================================
    Private Sub GrabSettingsTolopstaAppSettings()
        Try
            lopstaAppSettings.ClassSettings.IsAutoSave = _appsettings.AutoSave
        Catch ex As Exception

        End Try
    End Sub

    ' =====================================================================================
    ' Legt AppSettings an, wenn nicht vorhanden
    ' =====================================================================================
    Private Sub CheckAndGenerateAppSettings()
        Dim di As DirectoryInfo
        Dim fi As FileInfo
        Try
            If IsInstalled Then ' Wenn es sich um eine Programmversion handelt, die im Verzeichnis Program Files under Program Files(x86) fest installiert ist.

                di = New DirectoryInfo(Path.Combine(PathAppData, "Einstellungen"))
                If Not di.Exists Then ' Prüfen, ob in dem Verzeichnis <user>\AppData\Local\lopsta<PROGRAMMNAME> ein Unterverzeichnis Einstellungen besteht.
                    Try ' Andernfalls anlegen. Wenn anlegen scheitert, Programm beenden.
                        di.Create()
                    Catch ex As Exception
                        MessageBox.Show("Das Verzeichnis zum Speichern der Einstellungen konnte nicht angelegt werden. Bitte wenden Sie sich an Ihren Administrator.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
                        My.Application.Shutdown()
                    End Try
                End If

                fi = New FileInfo(Path.Combine(PathAppData, "Einstellungen", "Einstellungen.xml"))
                If Not fi.Exists Then ' Prüfen, ob in dem Verzeichnis <user>\AppData\Local\lopsta<PROGRAMMNAME>\Einstellungen eine Datei Einstellungen.xml existiert.
                    'Dim s As New ClassSettings ' Andernfalls anlegen. Wenn anlegen scheitert, Programm beenden.
                    _appsettings = New ClassSettings
                    ' Hier ggfls Vorbelegungen für Einstellungen vornehmen
                    With _appsettings
                        .IsMultiUser = False
                        .FormatAktenzeichen = "yy-0000"
                    End With
                    WriteAppSettings(fi.FullName)
                End If
                ReadAppSettings(fi.FullName)
            Else ' Wenn es sich um eine portable Version handelt ...

                'fi = New FileInfo(Path.Combine(PathApp, "Einstellungen.xml")) ' PathFileAppSettings
                fi = New FileInfo(PathFileAppSettings)
                If Not fi.Exists Then
                    'Dim s As New ClassSettings ' Andernfalls anlegen. Wenn anlegen scheitert, Programm beenden.
                    _appsettings = New ClassSettings
                    ' Hier ggfls Vorbelegungen für Einstellungen vornehmen
                    With _appsettings
                        .IsMultiUser = False
                        .FormatAktenzeichen = "yy-0000"
                    End With
                    WriteAppSettings(PathFileAppSettings)
                End If
                ReadAppSettings(fi.FullName)
            End If

        Catch ex As Exception
            MessageBox.Show("Es stehen keine Einstellungen zur Verfügung. Das Programm muss beendet werden. Bitte wenden Sie sich an Ihren Administrator", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
            My.Application.Shutdown()

        End Try
    End Sub



    ' B U T T O N  C L I C K  E R E I G N I S S E #############################################################################################


    ' ===========================================================================================================
    ' Button (Click)
    ' ButtonMenuSETTINGS
    ' Öffnet das Benutzerfenster zum Ändern der Einstellungen
    ' ===========================================================================================================
    Private Sub ButtonMenuLeftSettings_Click(sender As Object, e As RoutedEventArgs) Handles ButtonMenuLeftSettings.Click
        Using dlg As New DialogWindowSettings ' Neuen Settings-Dialog instanziieren
            With dlg ' Settings-Dialog anpassen
                .Topmost = True
                .ShowInTaskbar = False
                ' .Title = "Einstellungen [Benutzer: " & User(SelectedUserIndex).Label & " " & User(SelectedUserIndex).UserID ' Anpassen der angezeigten Fensterüberschrift
                .AppSettings = AppSettings ' Werte in Dialog übernehmen
            End With
            ClassDialogPositioning.SetDialogPosition(dlg) ' Positionierung des Dialogs am rechten Rand
            dlg.ShowDialog() ' Dialog öffnen
            If dlg.DialogResult = True Then ' Wenn der OK-Button gedrückt wurde ....
                ' Schreibt die neuen Einstellungen in die Einstellungen.xml Datei
                WriteAppSettings(PathFileAppSettings)
                ' Änderungen übernehmen ..............................................
                AenderungenInSettingsUebernehmen() ' Anpassungen des
            End If
        End Using
    End Sub


End Class

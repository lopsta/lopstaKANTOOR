' ==============================================================================
' UserSettings
' ==============================================================================

Imports System.IO

Partial Public Class MainWindow

    ' E I G E N S C H A F T E N ###############################################################################################################


    ' E R E I G N I S S E #####################################################################################################################

    ' D E L E G A T E N #######################################################################################################################


    ' M E T H O D E N #########################################################################################################################

    Private Sub SaveDefaultUser()
        If Not IsPortable Then
            Try
                ClassXmlSerializer.Write(Path.Combine(PathUsers, DefaultUser.UserID & ".user.xml"), DefaultUser)
            Catch ex As Exception
                MessageBox.Show("Die Benutzer-Datei konnte nicht angelegt werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
            End Try
        End If
    End Sub

    ' =====================================================================================
    ' Lesen der AppUserSettings
    ' =====================================================================================
    Private Function ReadUserSettings(p As String)
        Dim s As New Xml.Serialization.XmlSerializer(GetType(ClassUser)) ' searializer
        Dim r As New FileStream(p, FileMode.Open) ' reader
        Try
            Return s.Deserialize(r)
        Catch ex As Exception
            MessageBox.Show("Die Einstellungen konnten leider nicht geladen werden. " & ex.Message, "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        Finally
            r.Dispose()
            r = Nothing
            s = Nothing
        End Try
        Return Nothing
    End Function


    ' =====================================================================================
    ' Schreiben der AppSettings
    ' =====================================================================================
    Private Sub WriteUserSettings(p As String)
        Dim s As New Xml.Serialization.XmlSerializer(GetType(ClassUser)) ' searializer
        Dim w As New FileStream(p, FileMode.Create) ' writer
        Try
            s.Serialize(w, _user(p))
        Catch ex As Exception
            MessageBox.Show("Die Einstellungen konnten leider nicht gespeichert werden. " & ex.Message, "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        Finally
            s = Nothing
            w.Dispose()
            w = Nothing
        End Try
    End Sub


    ' =====================================================================================
    ' Legt User an, wenn nicht vorhanden
    ' =====================================================================================
    Private Sub CheckAndGenerateUserSettings()
        Dim di As DirectoryInfo
        Dim fi As FileInfo
        Try
            di = New DirectoryInfo(Path.Combine(PathUsers))
            If Not di.Exists Then ' Prüfen, ob ein Unterverzeichnis Benutzer besteht.
                Try ' Andernfalls anlegen. Wenn anlegen scheitert, Programm beenden.
                    di.Create()
                    SaveDefaultUser() ' Default Benutzer anlegen, da Verzeichnis ja leer
                Catch ex As Exception
                    MessageBox.Show("Das Verzeichnis zum Speichern der Benutzer konnte nicht angelegt werden. Bitte wenden Sie sich an Ihren Administrator.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
                    My.Application.Shutdown()
                End Try
            End If

            ' Wenn das Verzeichnis bereits besteht prüfen, ob wenigstens ein Benutzer gespeichert ist, sonst DefaultBenutzer anlegen
            If di.GetFiles("*.user.xml").Count < 1 Then
                SaveDefaultUser()
            End If
        Catch ex As Exception
            MessageBox.Show("Es stehen keine Benutzer-Einstellungen zur Verfügung.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        Finally
            di = Nothing
            fi = Nothing
        End Try
    End Sub


    ' B U T T O N  C L I C K  E R E I G N I S S E #############################################################################################

    ' ===========================================================================================================
    ' Button (Click)
    ' ButtonMenuLeftUsersettings
    ' Öffnet das Benutzerfenster zum Ändern der Benutzereinstellungen
    ' ===========================================================================================================
    Private Sub ButtonMenuLeftUsersettings_Click(sender As Object, e As RoutedEventArgs) Handles ButtonMenuLeftUsersettings.Click
        If _selelecteduserkey IsNot Nothing Then
            Using dlg As New DialogWindowUserSettings
                With dlg
                    .Topmost = True
                    .ShowInTaskbar = False
                    .Title = "Einstellungen [Benutzer: " & User(SelectedUserKey).Label & " " & User(SelectedUserKey).UserID ' Anpassen der angezeigten Fensterüberschrift
                    .User = User(SelectedUserKey)
                    .AppSettings = _appsettings
                End With
                ClassDialogPositioning.SetDialogPosition(dlg)
                dlg.ShowDialog()
                If dlg.DialogResult = True Then
                    User(SelectedUserKey) = dlg.User
                    If IsAutoSaveAppSettings Then
                        'ClassXmlSerializer.Write(SelectedUserKey, User(SelectedUserKey))
                        WriteUserSettings(SelectedUserKey)
                    Else
                        If MessageBox.Show("Sollen die Benutzer-Einstellungen jetzt gespeichert werden?", "Bitte bestätigen ...", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) = MessageBoxResult.Yes Then
                            'ClassXmlSerializer.Write(SelectedUserKey, User(SelectedUserKey))
                            WriteUserSettings(SelectedUserKey)
                        End If
                    End If
                    ' Änderungen übernehmen ..............................................
                    Me.Title = "lopstaKANZLEI (Benutzer: " & User(SelectedUserKey).Label & ")" ' Window-Title anpassen
                    AenderungenInSettingsUebernehmen()
                End If
            End Using
        Else
            MessageBox.Show("Die Benutzer-Einstellungen können erst angezeigt werden, wenn ein Benutzer ausgewählt ist. Bitte einen Benutzer auswählen.", "Hinweis!", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub


End Class

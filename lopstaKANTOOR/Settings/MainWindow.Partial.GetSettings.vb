Partial Public Class MainWindow


    Private Sub AenderungenInSettingsUebernehmen()
        ' Anpassungen an das Menü insbesondere Mehrbenutzer Modus/ Einzelbenutzer Modus
        ' Schaltet die Buttons für das Benutzerauswahlmenü und die Benutzersettings an oder aus
        If IsMultiUser Then
            ButtonLeftMenuBenutzer.Visibility = Visibility.Visible
            ButtonMenuLeftUsersettings.Visibility = Visibility.Visible
        Else
            ButtonLeftMenuBenutzer.Visibility = Visibility.Collapsed
            ButtonMenuLeftUsersettings.Visibility = Visibility.Collapsed
        End If

        ' Wenn die Settings oder Benutzersettings für das Projekteverzeichnis geändert wurden
        ' Liste der Projekte neue einlesen
        Try
            _pathPROJEKTE = Nothing
            _projekte = Nothing
            ListBoxPROJEKTE.ItemsSource = Projekte
        Catch ex As Exception
            MessageBox.Show("Der Dateipfad zu dem Projekte-Verzeichnis ist fehlerhaft.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try

        ' Modul mit den Vorlagen anpassen
        With UserControlVORLAGEN ' => bezieht sich auf die dll lopstaControlVorlagen

            ' ... WORD ............
            .ExtensionWord = "dot?"
            ' Hier wird der Pfad aus den Settings für das Control Vorlagen/Word übernommen
            ' Wenn der in den Settings gespeicherte Pfad ungültig ist, dass wird auf den Standardpfad gesetzt.
            .PathWORD = _appsettings.PfadVorlagenWord

            ' ... Briefkopf ........................
            ' Hier wird der Pfad zu den Briefkoepfen an die Komponente Vorlagen weitergereicht
            .PathBRIEFKOPF = _appsettings.PfadBriefkoepfe

            ' ... Excel ...........
            .ExtensionEXCEL = "xlt?"
            .PathEXCEL = _appsettings.PfadVorlagenExcel
            ' ... Andere ..........
            .PathANDERE = _appsettings.PfadVorlagenAndere
            ' ... Vollmachten .....
            .PathVOLLMACHTEN = _appsettings.PfadVorlagenVollmachten
            ' ... Formulare .......
            .ExtensionFORMULARE = "pdf"
            .PathFORMULARE = _appsettings.PfadVorlagenFormulare
        End With

        ' Wenn automatisches Speichern (AutoSave) eingeschaltet ist, das Diskettensymbol ausblenden
        ' Dieser Schritt soll wegfallen, wenn alle Settings nur durch lopstaAppSettings verwaltet werden.
        lopstaAppSettings.ClassSettings.IsAutoSave = _appsettings.AutoSave


    End Sub



End Class

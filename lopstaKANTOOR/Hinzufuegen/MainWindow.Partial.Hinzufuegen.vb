Imports System.IO

Partial Public Class MainWindow
    ' E I G E N S C H A F T E N ###############################################################################################################

    ' E R E I G N I S S E #####################################################################################################################

    ' D E L E G A T E N #######################################################################################################################

    ' M E T H O D E N #########################################################################################################################

    ' B U T T O N  C L I C K  E R E I G N I S S E #############################################################################################
    ' ===========================================================================================================
    ' Button (Click)
    ' ButtonMenuLeftOeffnen
    ' Öffnet das Benutzerfenster zum Ändern der Einstellungen
    ' ===========================================================================================================
    Private Sub ButtonMenuLeftNeu_Click(sender As Object, e As RoutedEventArgs) Handles ButtonMenuLeftNeu.Click

        If String.IsNullOrEmpty(PathPROJEKTE) Then
            MessageBox.Show("Es kann kein neus Projekt angelegt werden, da noch kein Pfad zum Projekte-Ordner angegben wurde.", "Hinweis!", MessageBoxButton.OK, MessageBoxImage.Information)
            Exit Sub
        End If
        ' Einlesen der Vorlage (Akte.Template.xml) zum Erstellen der Ordnerstruktur
        Dim xd As New Xml.XmlDocument

        ' Läd die Templatedatei Akte.Template.xml
        Try
            xd.Load("Resources\Akte.Template.xml")
        Catch ex As Exception
            MessageBox.Show("Das Muster für das Anlegen einer neuen Akte konnte nicht geladen werden. Es wir deshalb keine Akte angelegt." & ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error)
            Exit Sub
        End Try
        ' getLetzteRegisternummer()
        Using dlg As New DialogWindowHinzufuegen
            With dlg
                .Topmost = True
                .ShowInTaskbar = False
                ' .Title = "Einstellungen [Benutzer: " & User(SelectedUserIndex).Label & " " & User(SelectedUserIndex).UserID ' Anpassen der angezeigten Fensterüberschrift
                .Registernummer = getLetzteRegisternummer()
            End With
            ClassDialogPositioning.SetDialogPosition(dlg)
            dlg.ShowDialog()
            If dlg.DialogResult = True Then
                ' Anlegen des neuen Verzeichnis für die Akte und die Unterverzeichnisse
                Try
                    ' Name des neues Ordners aus den Dialogfeldern zusammensetzen
                    Dim neuerOrdnername As New System.Text.StringBuilder
                    With neuerOrdnername
                        .Append(getRegisterNummerMitJahrgang(dlg.TextBoxREGNR.Text.Trim, dlg.TextBoxJAHRGANG.Text.Trim))
                        .Append(" ")
                        .Append(dlg.TextBoxNAME.Text.Trim)
                        If Not String.IsNullOrEmpty(dlg.TextBoxVORNAME.Text.Trim) And Not String.IsNullOrEmpty(dlg.TextBoxBezeichnung.Text.Trim) Then
                            .Append(", ")
                            .Append(dlg.TextBoxVORNAME.Text.Trim)
                            .Append(", ")
                            .Append(dlg.TextBoxBezeichnung.Text.Trim)
                        ElseIf Not String.IsNullOrEmpty(dlg.TextBoxVORNAME.Text.Trim) And String.IsNullOrEmpty(dlg.TextBoxBezeichnung.Text.Trim) Then
                            .Append(", ")
                            .Append(dlg.TextBoxVORNAME.Text.Trim)
                        ElseIf String.IsNullOrEmpty(dlg.TextBoxVORNAME.Text.Trim) And Not String.IsNullOrEmpty(dlg.TextBoxBezeichnung.Text.Trim) Then
                            .Append(", , ")
                            .Append(dlg.TextBoxBezeichnung.Text.Trim)
                        End If

                    End With
                    Dim di As New DirectoryInfo(Path.Combine(PathPROJEKTE, neuerOrdnername.ToString.Trim))
                    di.Create()
                    For Each i As Xml.XmlElement In xd.SelectNodes("//list/item")
                        'Console.WriteLine(i.SelectNodes("value").Item(0).InnerText)
                        Dim sdi = di.CreateSubdirectory(i.SelectNodes("value").Item(0).InnerText.Trim)
                        If i.SelectNodes("item").Count > 0 Then
                            For Each s As Xml.XmlElement In i.SelectNodes("item")
                                ' Console.WriteLine(s.SelectNodes("value").Item(0).InnerText)
                                sdi.CreateSubdirectory(s.SelectNodes("value").Item(0).InnerText.Trim)
                            Next
                        End If
                    Next
                Catch ex As Exception
                    MessageBox.Show("Das Verzeichnis für die neue Akte konnte nicht richtig angelegt werden. Bitte überprüfen!", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
                End Try
            End If
        End Using
    End Sub
End Class

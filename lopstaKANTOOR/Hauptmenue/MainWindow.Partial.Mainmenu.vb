Partial Public Class MainWindow

    ' E I G E N S C H A F T E N ###############################################################################################################

    ' E R E I G N I S S E #####################################################################################################################

    ' D E L E G A T E N #######################################################################################################################

    ' M E T H O D E N #########################################################################################################################

    ' B U T T O N  C L I C K  E R E I G N I S S E #############################################################################################


    ' ===========================================================================================================
    ' Button (Click)
    ' ButtonMenuSETTINGS
    ' Öffnet das Benutzerfenster zum Ändern der Einstellungen
    ' ===========================================================================================================

    Private Sub ButtonLeftMenuMAINMENU_Click(sender As Object, e As RoutedEventArgs) Handles ButtonLeftMenuMAINMENU.Click
        Using dlg As New DialogWindowMainmenu
            With dlg
                .Topmost = True
                .ShowInTaskbar = False
                ' .Title = "Einstellungen [Benutzer: " & User(SelectedUserIndex).Label & " " & User(SelectedUserIndex).UserID ' Anpassen der angezeigten Fensterüberschrift
            End With
            ClassDialogPositioning.SetDialogPosition(dlg)
            dlg.ShowDialog()

            If dlg.DialogResult = True Then

                ' ClassXmlSerializer.Write(UserFileNames(SelectedUserIndex), User(SelectedUserIndex))
            End If
        End Using
    End Sub
End Class

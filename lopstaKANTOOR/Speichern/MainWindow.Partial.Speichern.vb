Partial Public Class MainWindow

    Private Sub ButtonMenuLeftSpeichern_Click(sender As Object, e As RoutedEventArgs) Handles ButtonMenuLeftSpeichern.Click
        If ListBoxPROJEKTE.SelectedIndex > -1 Then
            'ProjektAdressen.AdressenXmlDateiSpeichern(ListBoxPROJEKTE.SelectedItem.FullName)
            ProjektAdressen.AdressenXmlDateiSpeichern()
        End If
    End Sub

End Class

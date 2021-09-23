Public Class UserControlMenuLeiste

    Private Sub ButtonPostausgang_Click(sender As Object, e As RoutedEventArgs) Handles ButtonPostausgang.Click
        Using dlg As New WindowUserDialog
            With dlg
                .Title = "Dateiname für einen Postausgang erzeugen ..."
                .ContainerUserControl.Children.Add(New UserControlDateinamePOSTAUSGANG(dlg))
                ClassDialogPositioning.SetDialogPosition(dlg) ' Positionierung des Dialogs am rechten Rand
            End With
            dlg.ShowDialog()
        End Using
    End Sub

    Private Sub ButtonPosteingang_Click(sender As Object, e As RoutedEventArgs) Handles ButtonPosteingang.Click
        Using dlg As New WindowUserDialog
            With dlg
                .Title = "Dateiname für einen Posteingang erzeugen ..."
                .ContainerUserControl.Children.Add(New UserControlDateinamePOSTEINGANG(dlg))
                ClassDialogPositioning.SetDialogPosition(dlg) ' Positionierung des Dialogs am rechten Rand
            End With
            dlg.ShowDialog()
        End Using
    End Sub

    Private Sub ButtonBea_Click(sender As Object, e As RoutedEventArgs) Handles ButtonBea.Click
        Using dlg As New WindowUserDialog
            With dlg
                .Title = "Dateiname für eine beA-Übersendung erzeugen ..."
                .ContainerUserControl.Children.Add(New UserControlDateinameBEA(dlg))
                ClassDialogPositioning.SetDialogPosition(dlg) ' Positionierung des Dialogs am rechten Rand
            End With
            dlg.ShowDialog()
        End Using
    End Sub

    Private Sub ButtonHonorar_Click(sender As Object, e As RoutedEventArgs) Handles ButtonHonorar.Click
        Using dlg As New WindowUserDialog
            With dlg
                .Title = "Dateiname für eine Rechnung oder Honorar erzeugen ..."
                .ContainerUserControl.Children.Add(New UserControlDateinameHONORAR(dlg))
                ClassDialogPositioning.SetDialogPosition(dlg) ' Positionierung des Dialogs am rechten Rand
            End With
            dlg.ShowDialog()
        End Using
    End Sub

End Class

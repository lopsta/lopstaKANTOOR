Public Class ClassDialogPositioning

    Public Shared Sub SetDialogPosition(ByRef dlg As Window)
        With dlg
            .Top = Application.Current.MainWindow.Top + 100
            .Left = Application.Current.MainWindow.Left + (Application.Current.MainWindow.Width - dlg.Width) / 2
        End With
    End Sub

End Class

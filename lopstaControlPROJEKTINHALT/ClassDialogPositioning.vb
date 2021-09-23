Public Class ClassDialogPositioning

    Public Shared Sub SetDialogPosition(ByRef dlg As Window)
        With dlg

            If Application.Current.MainWindow.WindowState = WindowState.Maximized Then
                .Top = 53
                .Left = 40
            ElseIf Application.Current.MainWindow.WindowState = WindowState.Normal Then
                .Top = Application.Current.MainWindow.Top + 61
                .Left = Application.Current.MainWindow.Left + 47
            End If
        End With
    End Sub

End Class

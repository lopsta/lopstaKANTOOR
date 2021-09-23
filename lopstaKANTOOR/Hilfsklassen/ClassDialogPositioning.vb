Public Class ClassDialogPositioning

    Public Shared Sub SetDialogPosition(ByRef dlg As Window)
        With dlg
            If My.Application.MainWindow.WindowState = WindowState.Maximized Then
                .Top = 53
                .Left = 40
            ElseIf My.Application.MainWindow.WindowState = WindowState.Normal Then
                .Top = My.Application.MainWindow.Top + 61
                .Left = My.Application.MainWindow.Left + 47
            End If
        End With
    End Sub

End Class

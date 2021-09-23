Public Class DialogWindow

    Private _dialogbuttonoklabel As String = "OK."
    Public WriteOnly Property DialogButtonOkLabel As String
        Set(value As String)
            _dialogbuttonoklabel = value
            ButtonOk.Content = _dialogbuttonoklabel
        End Set
    End Property

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As RoutedEventArgs) Handles ButtonOk.Click
        OK()
    End Sub

    Public Sub OK()
        Me.DialogResult = True
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As RoutedEventArgs) Handles ButtonCancel.Click
        Cancel()
    End Sub

    Public Sub Cancel()
        Me.DialogResult = False
        Me.Close()
    End Sub

End Class

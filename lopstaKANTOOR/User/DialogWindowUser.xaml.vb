Imports System
Imports System.ComponentModel

Public Class DialogWindowUser
    Implements IDisposable

    Private _selecteduser As ClassUser
    Public ReadOnly Property SelectedUser As ClassUser
        Get
            Return _selecteduser
        End Get
    End Property

    Private _selecteduserkey As String = Nothing
    Public ReadOnly Property SelectedUserKey As String
        Get
            Return _selecteduserkey
        End Get
    End Property

    Private _users As Dictionary(Of String, ClassUser)
    Public Property Users As Dictionary(Of String, ClassUser)
        Get
            Return _users
        End Get
        Set(value As Dictionary(Of String, ClassUser))
            _users = value
        End Set
    End Property

    ' N E W ###################################################################################################################################

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub


    ' D I S P O S I N G #######################################################################################################################

    Public Sub Dispose() Implements IDisposable.Dispose
        'Dispose of unmanaged resources.
        Dispose(True)
        'Suppress finalization.
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If disposing Then
            ' TODO: Verwalteten Zustand löschen (verwaltete Objekte).

        End If
    End Sub


    ' F I N A L I Z E #########################################################################################################################
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    ' M E T H O D E N #########################################################################################################################



    ' B U T T O N  C L I C K  E R E I G N I S S E #############################################################################################

    Private Sub OK_Click(sender As Object, e As RoutedEventArgs) Handles OK.Click
        If ListBoxUSER.SelectedIndex > -1 Then
            Me.DialogResult = True
            Me.Close()
        Else
            MessageBox.Show("Sie haben noch keinen Benutzer ausgewählt. Wählen Sie ggfls. Abbrechen.", "Hinweis!", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As RoutedEventArgs) Handles Cancel.Click
        Me.DialogResult = False
        Me.Close()
    End Sub


    ' L I S T B O X  S E L E C T I O N  C H A N G E D  E R E I G N I S S E ####################################################################
    Private Sub ListBoxUSER_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ListBoxUSER.SelectionChanged
        If sender.SelectedIndex > -1 Then
            _selecteduser = sender.SelectedItem.Value
            _selecteduserkey = sender.SelectedItem.Key
        End If
    End Sub

    Private Sub ListBoxUSER_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles ListBoxUSER.MouseDoubleClick
        OK_Click(Nothing, Nothing)
    End Sub
End Class

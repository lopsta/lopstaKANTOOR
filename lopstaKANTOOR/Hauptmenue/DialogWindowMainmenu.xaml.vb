Public Class DialogWindowMainmenu

    Implements IDisposable


    ' E I G E N S C H A F T E N ###############################################################################################################


    ' E R E I G N I S S E #####################################################################################################################


    ' D E L E G A T E N #######################################################################################################################



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





    ' Dialog Buttons ===================================================================================================================



    ' Dialog Button OK .......................................................................................
    Private Sub ButtonOk_Click(sender As Object, e As RoutedEventArgs) Handles ButtonOk.Click

    End Sub

    ' Dialog Button Abbrechen ................................................................................
    Private Sub ButtonCancel_Click(sender As Object, e As RoutedEventArgs) Handles ButtonCancel.Click
        Me.DialogResult = False
        Me.Close()
    End Sub


End Class

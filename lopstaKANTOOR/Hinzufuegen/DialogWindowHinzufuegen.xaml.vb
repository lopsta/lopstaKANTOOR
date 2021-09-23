Public Class DialogWindowHinzufuegen
    Implements IDisposable


    ' E I G E N S C H A F T E N ###############################################################################################################

    Private _ordnername As String
    Public Property Ordnername As String
        Get
            Return _ordnername
        End Get
        Set(value As String)
            _ordnername = value
        End Set
    End Property

    Private _registernummer As String
    Public Property Registernummer As String
        Get
            Return _registernummer
        End Get
        Set(value As String)
            _registernummer = value
        End Set
    End Property


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
        If ValidateUserInputREGNR() = False Then
            Exit Sub
        End If
        If ValidateUserInputJAHRGANG() = False Then
            Exit Sub
        End If
        If ValidateUserInputNAME() = False Then
            Exit Sub
        End If
        Me.DialogResult = True
        Me.Close()
    End Sub

    ' Dialog Button Abbrechen ................................................................................
    Private Sub ButtonCancel_Click(sender As Object, e As RoutedEventArgs) Handles ButtonCancel.Click
        Me.DialogResult = False
        Me.Close()
    End Sub

    Private Sub DialogWindowHinzufuegen_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        TextBoxJAHRGANG.Text = DateTime.Today.ToString("yy")
        TextBoxREGNR.Focus()
    End Sub


    ' L I S T B O X  S E L E C T I O N  C H A N G E D  E R E I G N I S S E ####################################################################

    ' Ü B E R P R Ü F U N G  D E R  B E N U T Z E R E I N G A B E N ###########################################################################

    Private Function ValidateUserInputREGNR()
        Dim rgx As New System.Text.RegularExpressions.Regex("^\d{2,5}$")
        If Not rgx.IsMatch(TextBoxREGNR.Text) Then
            'TextBoxREGNR.ToolTip = "Sie haben eine ungültige Registernummer eingegeben."
            TextBoxREGNR.Background = Brushes.DarkOrange
            TextBoxREGNR.Focus()
            Return False
        End If
        TextBoxREGNR.Background = Brushes.White
        Return True
    End Function

    Private Sub TextBoxREGNR_LostKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles TextBoxREGNR.LostKeyboardFocus
        ValidateUserInputREGNR()
    End Sub

    Private Function ValidateUserInputJAHRGANG()
        Dim rgx As New System.Text.RegularExpressions.Regex("^\d{2,4}$")
        If Not rgx.IsMatch(TextBoxJAHRGANG.Text) Then
            'TextBoxREGNR.ToolTip = "Sie haben eine ungültige Registernummer eingegeben."
            TextBoxJAHRGANG.Background = Brushes.DarkOrange
            TextBoxJAHRGANG.Focus()
            Return False
        End If
        TextBoxJAHRGANG.Background = Brushes.White
        Return True
    End Function

    Private Sub TextBoxJAHRGANG_LostKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles TextBoxJAHRGANG.LostKeyboardFocus
        ValidateUserInputJAHRGANG()
    End Sub

    Private Function ValidateUserInputNAME()
        Dim rgx As New System.Text.RegularExpressions.Regex("^[a-zäöüßA-ZÄÖÜ0-9-_&]{2,20}$")
        If Not rgx.IsMatch(TextBoxNAME.Text.Trim) Then
            'TextBoxREGNR.ToolTip = "Sie haben eine ungültige Registernummer eingegeben."
            TextBoxNAME.Background = Brushes.DarkOrange
            TextBoxNAME.Focus()
            Return False
        End If
        TextBoxNAME.Background = Brushes.White
        Return True
    End Function

    Private Sub TextBoxNAME_LostKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles TextBoxNAME.LostKeyboardFocus
        ValidateUserInputNAME()
    End Sub

    Private Function ValidateUserInputVORNAME()
        Dim rgx As New System.Text.RegularExpressions.Regex("^[a-zäöüßA-ZÄÖÜ0-9-_&]{2,15}$")
        If Not rgx.IsMatch(TextBoxVORNAME.Text.Trim) Then
            'TextBoxREGNR.ToolTip = "Sie haben eine ungültige Registernummer eingegeben."
            TextBoxVORNAME.Background = Brushes.DarkOrange
            TextBoxVORNAME.Focus()
            Return False
        End If
        TextBoxVORNAME.Background = Brushes.White
        Return True
    End Function

    Private Sub TextBoxVORNAME_LostKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles TextBoxVORNAME.LostKeyboardFocus
        ValidateUserInputVORNAME()
    End Sub

    Private Function ValidateUserInputBEZEICHNUNG()
        Dim rgx As New System.Text.RegularExpressions.Regex("^[a-zäöüßA-ZÄÖÜ0-9-_&]{2,15}$")
        If Not rgx.IsMatch(TextBoxBezeichnung.Text) Then
            TextBoxBezeichnung.Background = Brushes.DarkOrange
            TextBoxBezeichnung.Focus()
            Return False
        End If
        TextBoxBezeichnung.Background = Brushes.White
        Return True
    End Function

    Private Sub TextBoxBezeichnung_LostKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles TextBoxBezeichnung.LostKeyboardFocus
        ValidateUserInputBEZEICHNUNG()
    End Sub
End Class

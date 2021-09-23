Imports System
Imports System.ComponentModel

Public Class DialogWindowUserSettings

    Implements IDisposable


    ' E I G E N S C H A F T E N ###############################################################################################################

    Private _appsettings As ClassSettings
    Public Property AppSettings As ClassSettings
        Get
            Return _appsettings
        End Get
        Set(value As ClassSettings)
            _appsettings = value
        End Set
    End Property

    Private _user As ClassUser
    Public Property User As ClassUser
        Get
            Return _user
        End Get
        Set(value As ClassUser)
            _user = value
        End Set
    End Property

    Private _selelecteduserkey As String = Nothing
    Public Property SelectedUserKey As String
        Get
            Return _selelecteduserkey
        End Get
        Set(value As String)
            _selelecteduserkey = value
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

    Private Sub ChangePage(page As String)
        GridPage001.Visibility = Visibility.Collapsed
        GridPage002.Visibility = Visibility.Collapsed
        Select Case page
            Case "001"
                GridPage001.Visibility = Visibility.Visible
            Case "002"
                GridPage002.Visibility = Visibility.Visible
        End Select
    End Sub


    ' B U T T O N  C L I C K  E R E I G N I S S E #############################################################################################


    ' Auswahlmenü Buttons ==============================================================================================================

    ' Menü Button Seite001 ...................................................................................
    Private Sub ButtonSeite001_Click(sender As Object, e As RoutedEventArgs) Handles ButtonSeite001.Click
        'FramePages.Navigate(New Uri("/lopstaNoSleep;component/Settings/PageSettings001.xaml", UriKind.Relative))
        ChangePage("001")
    End Sub

    ' Menü Button Seite002 ...................................................................................
    Private Sub ButtonSeite002_Click(sender As Object, e As RoutedEventArgs) Handles ButtonSeite002.Click
        'FramePages.Navigate(New Uri("/lopstaNoSleep;component/Settings/PageSettings002.xaml", UriKind.Relative))
        ChangePage("002")
    End Sub


    ' Dialog Buttons ===================================================================================================================


    ' Dialog Button OK .......................................................................................
    Private Sub ButtonOk_Click(sender As Object, e As RoutedEventArgs) Handles ButtonOk.Click
        ' Eingaben übernehmen
        With _user
            .Anrede = ComboBoxAnrede.Text
            .Nachname = TextBoxNachname.Text
            .Vorname = TextBoxVorname.Text
            .Titel = TextBoxTitel.Text
            .PathPROJEKTE = TextBoxAKTEN.Text
            .PathRECHNUNGEN = TextBoxRECHNUNGEN.Text
            .PathTEXTBAUSTEINE = TextBoxTEXTBAUSTEINE.Text
            .PathWORDVORLAGEN = TextBoxWORD.Text
            .PathEXCELVORLAGEN = TextBoxEXCEL.Text
        End With
        Me.DialogResult = True
        Me.Close()
    End Sub

    ' Dialog Button Abbrechen ................................................................................
    Private Sub ButtonCancel_Click(sender As Object, e As RoutedEventArgs) Handles ButtonCancel.Click
        ' Eingaben verwerfen
        Me.DialogResult = False
        Me.Close()
    End Sub

    ' Buttons für die Pfadauswahl ............................................................................
    Private Sub ButtonAKTEN_Click(sender As Object, e As RoutedEventArgs) Handles ButtonAKTEN.Click
        MyOpenFolderBrowserDialog(TextBoxAKTEN)
    End Sub

    Private Sub ButtonRECHNUNGEN_Click(sender As Object, e As RoutedEventArgs) Handles ButtonRECHNUNGEN.Click
        MyOpenFolderBrowserDialog(TextBoxRECHNUNGEN)
    End Sub

    Private Sub ButtonTEXTBAUSTEINE_Click(sender As Object, e As RoutedEventArgs) Handles ButtonTEXTBAUSTEINE.Click
        MyOpenFolderBrowserDialog(TextBoxTEXTBAUSTEINE)
    End Sub

    Private Sub ButtonWORD_Click(sender As Object, e As RoutedEventArgs) Handles ButtonWORD.Click
        MyOpenFolderBrowserDialog(TextBoxWORD)
    End Sub

    Private Sub ButtonEXCEL_Click(sender As Object, e As RoutedEventArgs) Handles ButtonEXCEL.Click
        MyOpenFolderBrowserDialog(TextBoxEXCEL)
    End Sub

    ' Hilfsfunktion für den Pfad-Auswahl-Dialog
    Private Sub MyOpenFolderBrowserDialog(ByRef tb As TextBox)
        Using dlg As New System.Windows.Forms.FolderBrowserDialog
            If dlg.ShowDialog() = Forms.DialogResult.OK Then
                tb.Text = dlg.SelectedPath
            End If
        End Using
    End Sub

    Private Sub ButtonSTANDARDWERTE002_Click(sender As Object, e As RoutedEventArgs) Handles ButtonSTANDARDWERTE002.Click
        With _appsettings
            TextBoxAKTEN.Text = .PfadProjekte
            TextBoxRECHNUNGEN.Text = .PfadRechnungen
            TextBoxTEXTBAUSTEINE.Text = .PfadTextbausteine
            TextBoxWORD.Text = .PfadVorlagenWord
            TextBoxEXCEL.Text = .PfadVorlagenExcel
        End With
    End Sub


    ' L I S T B O X  S E L E C T I O N  C H A N G E D  E R E I G N I S S E ####################################################################



End Class

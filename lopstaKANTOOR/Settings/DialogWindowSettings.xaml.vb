Imports System
Imports System.ComponentModel

Public Class DialogWindowSettings

    Implements IDisposable


    ' E I G E N S C H A F T E N ###############################################################################################################
    Private _appsettings As ClassSettings
    Public Property AppSettings As ClassSettings
        Get
            Return _appsettings
        End Get
        Set(value As ClassSettings)
            _appsettings = value
            ' Me.DataContext = _appsettings
            'Anpassungen des Dialogs an die Einstellungen vornehmen
            CheckBoxIsMultiUser.IsChecked = _appsettings.IsMultiUser
            EnableDisableMultiUserSettings()
            VisibilityMultiUserSettings()
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
        ChangePage("001")
    End Sub

    ' Menü Button Seite002 ...................................................................................
    Private Sub ButtonSeite002_Click(sender As Object, e As RoutedEventArgs) Handles ButtonSeite002.Click
        ChangePage("002")
    End Sub


    ' Dialog Buttons ===================================================================================================================

    ' Dialog Button OK .......................................................................................
    Private Sub ButtonOk_Click(sender As Object, e As RoutedEventArgs) Handles ButtonOk.Click
        Me.DialogResult = True
        WerteUebernehmen()
        Me.Close()
    End Sub

    ' Dialog Button Abbrechen ................................................................................
    Private Sub ButtonCancel_Click(sender As Object, e As RoutedEventArgs) Handles ButtonCancel.Click
        Me.DialogResult = False
        Me.Close()
    End Sub

    ' Button Click-Ereignisse auf den einzelnen Seiten .......................................................

    Private Sub ButtonSTANDARDWERTE002_Click(sender As Object, e As RoutedEventArgs) Handles ButtonSTANDARDWERTE002.Click
        TextBoxAKTEN.Text = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "lopstaAKTEN")
        TextBoxRECHNUNGEN.Text = System.IO.Path.Combine(TextBoxAKTEN.Text, ".Rechnungen")
        'TextBoxTEXTBAUSTEINE.Text = "Textbausteine"
        TextBoxBRIEFKOPF.Text = "Vorlagen\Briefkopf"
        TextBoxWORD.Text = "Vorlagen\Word"
        TextBoxEXCEL.Text = "Vorlagen\Excel"
        TextBoxANDERE.Text = "Vorlagen\Andere"
        TextBoxVollmachten.Text = "Vorlagen\Vollmachten"
        TextBoxFormulare.Text = "Vorlagen\Formulare"
    End Sub


    ' L I S T B O X  S E L E C T I O N  C H A N G E D  E R E I G N I S S E ####################################################################


    ' H I L F S F U N K T I O N E N ###########################################################################################################

    Private Sub WerteUebernehmen()

        With _appsettings

            ' Einstellungen Page001

            ' Einstellungen Page002
            .PfadProjekte = TextBoxAKTEN.Text.Trim
            .PfadRechnungen = TextBoxRECHNUNGEN.Text.Trim

            '.PfadTextbausteine = TextBoxTEXTBAUSTEINE.Text
            .PfadBriefkoepfe = TextBoxBRIEFKOPF.Text.Trim
            .PfadVorlagenWord = TextBoxWORD.Text.Trim
            .PfadVorlagenExcel = TextBoxEXCEL.Text.Trim
            .PfadVorlagenAndere = TextBoxANDERE.Text.Trim
            .PfadVorlagenVollmachten = TextBoxVollmachten.Text.Trim
            .PfadVorlagenFormulare = TextBoxFormulare.Text.Trim

            ' Einstellungen Page 003
            .IsMultiUser = CheckBoxIsMultiUser.IsChecked
            .PfadBenutzer = TextBoxUSER.Text.Trim
            .BenutzerUeberschreibtSettings = CheckBoxUserOverridesSettings.IsChecked

            .AutoSave = CheckBoxAutoSave.IsChecked

        End With

    End Sub

    Private Sub ButtonAKTEN_Click(sender As Object, e As RoutedEventArgs) Handles ButtonAKTEN.Click
        Using dlg As New System.Windows.Forms.FolderBrowserDialog
            If dlg.ShowDialog() = Forms.DialogResult.OK Then
                TextBoxAKTEN.Text = dlg.SelectedPath
            End If
        End Using
    End Sub

    Private Sub ButtonRECHNUNGEN_Click(sender As Object, e As RoutedEventArgs) Handles ButtonRECHNUNGEN.Click
        Using dlg As New System.Windows.Forms.FolderBrowserDialog
            If dlg.ShowDialog() = Forms.DialogResult.OK Then
                TextBoxRECHNUNGEN.Text = dlg.SelectedPath
            End If
        End Using
    End Sub

    Private Sub ButtonTEXTBAUSTEINE_Click(sender As Object, e As RoutedEventArgs) Handles ButtonTEXTBAUSTEINE.Click
        Using dlg As New System.Windows.Forms.FolderBrowserDialog
            If dlg.ShowDialog() = Forms.DialogResult.OK Then
                TextBoxTEXTBAUSTEINE.Text = dlg.SelectedPath
            End If
        End Using
    End Sub

    Private Sub ButtonBRIEFKOPF_Click(sender As Object, e As RoutedEventArgs) Handles ButtonBRIEFKOPF.Click
        Using dlg As New System.Windows.Forms.FolderBrowserDialog
            If dlg.ShowDialog() = Forms.DialogResult.OK Then
                TextBoxBRIEFKOPF.Text = dlg.SelectedPath
            End If
        End Using
    End Sub

    Private Sub ButtonWORD_Click(sender As Object, e As RoutedEventArgs) Handles ButtonWORD.Click
        Using dlg As New System.Windows.Forms.FolderBrowserDialog
            If dlg.ShowDialog() = Forms.DialogResult.OK Then
                TextBoxWORD.Text = dlg.SelectedPath
            End If
        End Using
    End Sub

    Private Sub ButtonEXCEL_Click(sender As Object, e As RoutedEventArgs) Handles ButtonEXCEL.Click
        Using dlg As New System.Windows.Forms.FolderBrowserDialog
            If dlg.ShowDialog() = Forms.DialogResult.OK Then
                TextBoxEXCEL.Text = dlg.SelectedPath
            End If
        End Using
    End Sub

    Private Sub ButtonUSER_Click(sender As Object, e As RoutedEventArgs) Handles ButtonUSER.Click
        Using dlg As New System.Windows.Forms.FolderBrowserDialog
            If dlg.ShowDialog() = Forms.DialogResult.OK Then
                TextBoxUSER.Text = dlg.SelectedPath
            End If
        End Using
    End Sub

    ' Anpassen der Oberfläche, wenn die IsMultiUser Checkbox geklickt wird
    Private Sub CheckBoxIsMultiUser_Checked(sender As Object, e As RoutedEventArgs) Handles CheckBoxIsMultiUser.Checked
        EnableDisableMultiUserSettings()
        VisibilityMultiUserSettings()
    End Sub

    Private Sub CheckBoxIsMultiUser_Unchecked(sender As Object, e As RoutedEventArgs) Handles CheckBoxIsMultiUser.Unchecked
        EnableDisableMultiUserSettings()
        VisibilityMultiUserSettings()
    End Sub

    Private Sub EnableDisableMultiUserSettings()
        TextBoxUSER.IsEnabled = CheckBoxIsMultiUser.IsChecked
        ButtonUSER.IsEnabled = CheckBoxIsMultiUser.IsChecked
        CheckBoxUserOverridesSettings.IsEnabled = CheckBoxIsMultiUser.IsChecked
    End Sub

    Private Sub VisibilityMultiUserSettings()
        Dim myState As Visibility
        If CheckBoxIsMultiUser.IsChecked Then
            myState = Visibility.Visible
        Else
            myState = Visibility.Collapsed
        End If
        LabelUser.Visibility = myState
        TextBoxUSER.Visibility = myState
        ButtonUSER.Visibility = myState
        LabelOverridesSettings.Visibility = myState
        CheckBoxUserOverridesSettings.Visibility = myState
    End Sub

    Private Sub DialogWindowSettings_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Me.DialogResult = False Then
        End If
    End Sub

End Class


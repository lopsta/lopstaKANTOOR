Imports System.ComponentModel
Imports lopstaControlAdressenVerzeichnis

Public Class DialogWindowAdresseHinzufuegen
    Implements IDisposable

    ' E I G E N S C H A F T E N ###############################################################################################################
    Private _adresse As Object
    Public ReadOnly Property Adresse As Object
        Get
            Return _adresse
        End Get
    End Property


    ' I N I T I A L I Z E #####################################################################################################################

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub



    ' Make disposable ##########################################################################################################################
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



    ' L O A D E D  A N D  C L O S I N G #######################################################################################################
    Private Sub DialogWindowAdresseHinzufuegen_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

    End Sub

    Private Sub DialogWindowAdresseHinzufuegen_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub DialogWindowAdresseHinzufuegen_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub


    ' B U T T O N  C L I C K  E R E I G N I S S E ############################################################################################

    ' Dialog Buttons OK und Cancel ...........................................................................................................
    Private Sub ButtonOk_Click(sender As Object, e As RoutedEventArgs) Handles ButtonOk.Click
        If TabItemJUSTIZADRESSEN.IsSelected Then
            If UserControlSelectJUSTIZADRESSE.ListBoxADRESSEN.SelectedIndex > -1 Then
                If UserControlSelectJUSTIZADRESSE.RadioButtonGESCHAEFTSSTELLE.IsChecked Then
                    GeschaeftsstelleUebernehmen()
                ElseIf UserControlSelectJUSTIZADRESSE.RadioButtonDURCHWAHL.IsChecked Then
                    JustizDurchwahlUebernehmen()
                Else
                    JustizAdresseUebernehmen()
                End If
            Else
                MessageBox.Show("Sie müssen eine Adresse aus der Liste auswählen.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Warning)
                Exit Sub
            End If
        ElseIf TabItemMANDANT.IsSelected Then
            If String.IsNullOrEmpty(TextBoxMandantNAME.Text) Then
                TextBoxMandantNAME.Text = "Neue Adresse (Mandant*in)"
            End If
            MandantAdresseUebernehmen()
        ElseIf TabItemPOLIZEI.IsSelected Then
            If String.IsNullOrEmpty(TextBoxAllgemeinNAME.Text) Then
                TextBoxPolizeiNAME.Text = "Neue Adresse (Polizei)"
            End If
            PolizeiAdresseUebernehmen()
        ElseIf TabItemANDERE.IsSelected Then
            If String.IsNullOrEmpty(TextBoxAllgemeinNAME.Text) Then
                TextBoxAllgemeinNAME.Text = "Neue Adresse (andere)"
            End If
            AndereAdresseUebernehmen()
        Else
            MessageBox.Show("Sie müssen zunächst einen Adressentyp auswählen.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information)
            Exit Sub
        End If
        Me.DialogResult = True
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As RoutedEventArgs) Handles ButtonCancel.Click
        Me.DialogResult = False
        Me.Close()
    End Sub


    ' H I L F S F U N K T I O N E N ###########################################################################################################

    Private Sub JustizAdresseUebernehmen()
        _adresse = New ClassJustizAdresse
        _adresse = UserControlSelectJUSTIZADRESSE.Adresse
    End Sub

    Private Sub GeschaeftsstelleUebernehmen()
        _adresse = New ClassGeschaeftsstelle
        _adresse = UserControlSelectJUSTIZADRESSE.Geschaeftsstelle
    End Sub

    Private Sub JustizDurchwahlUebernehmen()
        _adresse = New ClassJustizDurchwahl
        _adresse = UserControlSelectJUSTIZADRESSE.Durchwahl
    End Sub

    Private Sub PolizeiAdresseUebernehmen()
        _adresse = New ClassPolizei
        With _adresse
            .ID = Guid.NewGuid.ToString
            .Name = TextBoxPolizeiNAME.Text
        End With
    End Sub

    Private Sub MandantAdresseUebernehmen()
        _adresse = New ClassMandant
        With _adresse
            .ID = Guid.NewGuid.ToString
            '.ClassTyp = "ClassMandant"
            .Anrede = TextBoxMandantANREDE.Text
            .Nachname = TextBoxMandantNAME.Text
            .Vorname = TextBoxMandantVORNAME.Text
            .Titel = TextBoxMandantTITEL.Text
        End With
    End Sub

    Private Sub AndereAdresseUebernehmen()
        _adresse = New ClassAdresse
        With _adresse
            .ID = Guid.NewGuid.ToString
            '.ClassTyp = "ClassAdresse"
            .Anrede = TextBoxAllgemeinANREDE.Text
            .Nachname = TextBoxAllgemeinNAME.Text
            .Vorname = TextBoxAllgemeinVORNAME.Text
            .Titel = TextBoxAllgemeinTITEL.Text
        End With
    End Sub

End Class

Imports System.Data

Public Class UserControlJustizadressenAuswahl

    'Private _justizadressen As New lopstaDatenbankJustizadressen.Justizadressen

    Private _dv As DataView

    Private _typadresse As String
    Public ReadOnly Property TypAdresse As String
        Get
            Return _typadresse
        End Get
    End Property

    Private _adresse As ClassJustizAdresse
    Public ReadOnly Property Adresse As ClassJustizAdresse
        Get
            Return _adresse
        End Get
    End Property

    Private _geschaeftsstelle As ClassGeschaeftsstelle
    Public ReadOnly Property Geschaeftsstelle As ClassGeschaeftsstelle
        Get
            Return _geschaeftsstelle
        End Get
    End Property

    Private _durchwahl As ClassJustizDurchwahl
    Public ReadOnly Property Durchwahl As ClassJustizDurchwahl
        Get
            Return _durchwahl
        End Get
    End Property



    Private Sub UserControlJustizadressenAuswahl_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        RadioButtonADRESSE.IsChecked = True
    End Sub



    Private Sub ButtonSTAATSANWALTSCHAFTEN_Click(sender As Object, e As RoutedEventArgs) Handles ButtonSTAATSANWALTSCHAFTEN.Click
        'ListBoxADRESSEN.ItemsSource = lopstaDatenbankJustizadressen.Justizadressen.DataViewStaatsanwaltschaften
        _dv = lopstaDatenbankJustizadressen.Justizadressen.DataViewStaatsanwaltschaften
        ListBoxADRESSEN.ItemsSource = _dv
    End Sub

    Private Sub ButtonAMTSGERICHTE_Click(sender As Object, e As RoutedEventArgs) Handles ButtonAMTSGERICHTE.Click
        _dv = lopstaDatenbankJustizadressen.Justizadressen.DataViewAmtsgerichte
        ListBoxADRESSEN.ItemsSource = _dv
    End Sub

    Private Sub ButtonLANDGERICHTE_Click(sender As Object, e As RoutedEventArgs) Handles ButtonLANDGERICHTE.Click
        _dv = lopstaDatenbankJustizadressen.Justizadressen.DataViewLandgerichte
        ListBoxADRESSEN.ItemsSource = _dv
    End Sub

    Private Sub ButtonOBERLANDESGERICHTE_Click(sender As Object, e As RoutedEventArgs) Handles ButtonOBERLANDESGERICHTE.Click
        _dv = lopstaDatenbankJustizadressen.Justizadressen.DataViewOberlandesgerichte
        ListBoxADRESSEN.ItemsSource = _dv
    End Sub

    Private Sub ButtonBUNDESGERICHTSHOF_Click(sender As Object, e As RoutedEventArgs) Handles ButtonBUNDESGERICHTSHOF.Click
        _dv = lopstaDatenbankJustizadressen.Justizadressen.DataViewBundesgerichtshof
        ListBoxADRESSEN.ItemsSource = _dv
    End Sub

    Private Sub ButtonBUNDESVERFASSUNGSGERICHT_Click(sender As Object, e As RoutedEventArgs) Handles ButtonBUNDESVERFASSUNGSGERICHT.Click
        _dv = lopstaDatenbankJustizadressen.Justizadressen.DataViewBundesverfassungsgericht
        ListBoxADRESSEN.ItemsSource = _dv
    End Sub

    Private Sub ButtonJUSTIZVOLLZUGSANSTALTEN_Click(sender As Object, e As RoutedEventArgs) Handles ButtonJUSTIZVOLLZUGSANSTALTEN.Click
        _dv = lopstaDatenbankJustizadressen.Justizadressen.DataViewJustizvollzugsanstalten
        ListBoxADRESSEN.ItemsSource = _dv
    End Sub

    Private Sub TextBoxSuchen_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxSuchen.KeyUp
        ListBoxADRESSEN.ItemsSource = From i As DataRowView In _dv
                                      Where i("Name").Contains(sender.Text)
                                      Select i
    End Sub

    Private Sub RadioButton_Checked(sender As Object, e As RoutedEventArgs)
        GrabAdresse()
    End Sub

    Private Sub ListBoxADRESSEN_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ListBoxADRESSEN.SelectionChanged
        GrabAdresse()
    End Sub

    Private Sub GrabAdresse()
        If ListBoxADRESSEN.SelectedIndex > -1 Then
            If RadioButtonGESCHAEFTSSTELLE.IsChecked Then
                DataRowViewToClassGeschaeftsstelleKonverter()
            ElseIf RadioButtonDURCHWAHL.IsChecked Then
                DataRowViewToClassDurchwahlKonverter()
            Else
                DataRowViewToClassJustizAdresseKonverter()
            End If
        End If
    End Sub

    Private Sub DataRowViewToClassJustizAdresseKonverter()
        _adresse = New ClassJustizAdresse
        With _adresse
            .ID = ListBoxADRESSEN.SelectedItem("ID").ToString
            .xJustizID = ListBoxADRESSEN.SelectedItem("xJustizID")
            '.Typ = ListBoxADRESSEN.SelectedItem("Typ")
            .Name = ListBoxADRESSEN.SelectedItem("Name")
            .Zusatz = ListBoxADRESSEN.SelectedItem("Zusatz")
            .Strasse = ListBoxADRESSEN.SelectedItem("Strasse")
            .Postleitzahl = ListBoxADRESSEN.SelectedItem("Postleitzahl")
            .Ort = ListBoxADRESSEN.SelectedItem("Ort")
            .Bundesland = ListBoxADRESSEN.SelectedItem("Bundesland")
            .Postfach = ListBoxADRESSEN.SelectedItem("Postfach")
            .PostleitzahlPostfach = ListBoxADRESSEN.SelectedItem("PostleitzahlPostfach")
            .Telefon = ListBoxADRESSEN.SelectedItem("Telefon")
            .Fax = ListBoxADRESSEN.SelectedItem("Fax")
            .Email = ListBoxADRESSEN.SelectedItem("Email")
            .Internet = ListBoxADRESSEN.SelectedItem("Internet")
            '.Bank = ListBoxADRESSEN.SelectedItem("Bank")
            .Kontoinhaber = ListBoxADRESSEN.SelectedItem("Kontoinhaber")
            .IBAN = ListBoxADRESSEN.SelectedItem("IBAN")
            .BIC = ListBoxADRESSEN.SelectedItem("BIC")
            .Aktenzeichen = ""
            .Betreff001 = ""
            .Betreff002 = ""
            .Betreff003 = ""
            .Betreff004 = ""
        End With
    End Sub

    Private Sub DataRowViewToClassGeschaeftsstelleKonverter()
        _geschaeftsstelle = New ClassGeschaeftsstelle
        With _geschaeftsstelle
            .ID = ListBoxADRESSEN.SelectedItem("ID").ToString
            .xJustizID = ListBoxADRESSEN.SelectedItem("xJustizID")
            '.Typ = ListBoxADRESSEN.SelectedItem("Typ")
            .Name = ListBoxADRESSEN.SelectedItem("Name")
        End With
    End Sub

    Private Sub DataRowViewToClassDurchwahlKonverter()
        _durchwahl = New ClassJustizDurchwahl
        With _durchwahl
            .ID = ListBoxADRESSEN.SelectedItem("ID").ToString
            .xJustizID = ListBoxADRESSEN.SelectedItem("xJustizID")
            '.Typ = ListBoxADRESSEN.SelectedItem("Typ")
            .Name = ListBoxADRESSEN.SelectedItem("Name")
        End With
    End Sub


End Class

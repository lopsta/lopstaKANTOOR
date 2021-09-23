Imports System.Data
Imports System.IO

Public Class UserControlAdressenListe
    Implements IDisposable

    Private _fullname As String
    Public Property FullName As String
        Get
            Return _fullname
        End Get
        Set(value As String)
            _fullname = value
            _adressenxmldatei = Path.Combine(_fullname, "Adressen.lopsta.xml")
            AdressenXmlDateiLaden()
            ListViewADRESSEN.ItemsSource = Nothing
            ListViewADRESSEN.ItemsSource = _projektadressen.Alle
            'ListViewADRESSEN.ItemsSource = ClassAdressen.Alle
        End Set
    End Property

    Private _adressenxmldatei As String

    Private _projektadressen As ClassAdressen
    Public Property ProjektAdressen As ClassAdressen
        Get
            Return _projektadressen
        End Get
        Set(value As ClassAdressen)
            _projektadressen = value
            ListViewADRESSEN.ItemsSource = Nothing
            ListViewADRESSEN.ItemsSource = _projektadressen.Alle
        End Set
    End Property

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

    Public Sub AdressenXmlDateiLaden()
        'Dim f As String = Path.Combine(p, "Adressen.lopsta.xml")
        If File.Exists(_adressenxmldatei) Then
            _projektadressen = ClassLesen.Lesen(_adressenxmldatei)
        Else
            _projektadressen = New ClassAdressen
            ClassSchreiben.Schreiben(_adressenxmldatei, _projektadressen)
        End If
    End Sub


    Public Sub AdressenXmlDateiSpeichern()
        'Dim f As String = Path.Combine(p, "Adressen.lopsta.xml")
        ClassSchreiben.Schreiben(_adressenxmldatei, _projektadressen)
    End Sub



    ' B U T T O N  C L I C K  E R E I G N I S S E #############################################################################################

    Private Sub ButtonEDIT_Click(sender As Object, e As RoutedEventArgs) Handles ButtonEDIT.Click
        If ListViewADRESSEN.SelectedIndex > -1 Then
            Select Case ListViewADRESSEN.SelectedItem.Klasse
                Case GetType(ClassMandant).ToString
                    Dim r As ClassMandant = _projektadressen.Mandant.Find(Function(x As ClassMandant) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    'Dim r As ClassMandant = ClassAdressen.Mandant.Find(Function(x As ClassMandant) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    Using dlg As New DialogWindowAdresse
                        With dlg
                            .Title = r.Label & " (" & r.Aktenzeichen & ") "
                            .UserControlADRESSE.Adresse = r
                            ClassDialogPositioning.SetDialogPosition(dlg)
                        End With
                        dlg.ShowDialog()
                        If dlg.DialogResult = True Then
                            ListViewADRESSEN.ItemsSource = Nothing
                            ListViewADRESSEN.ItemsSource = _projektadressen.Alle
                            'ListViewADRESSEN.ItemsSource = ClassAdressen.Alle
                            AutoSaveChanges()
                        End If
                    End Using
                Case GetType(ClassJustizAdresse).ToString
                    Dim r As ClassJustizAdresse = _projektadressen.Justizadressen.Find(Function(x As ClassJustizAdresse) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    'Dim r As ClassJustizAdresse = ClassAdressen.Justizadressen.Find(Function(x As ClassJustizAdresse) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    Using dlg As New DialogWindowJustizAdresse
                        With dlg
                            .Title = r.Label & " (" & ") "
                            .UserControlFORMULAR.Adresse = r
                            ClassDialogPositioning.SetDialogPosition(dlg)
                        End With
                        dlg.ShowDialog()
                        If dlg.DialogResult = True Then
                            ListViewADRESSEN.ItemsSource = Nothing
                            ListViewADRESSEN.ItemsSource = _projektadressen.Alle
                            'ListViewADRESSEN.ItemsSource = ClassAdressen.Alle
                            AutoSaveChanges()
                        End If
                    End Using
                Case GetType(ClassGeschaeftsstelle).ToString
                    Dim r As ClassGeschaeftsstelle = _projektadressen.Geschaeftsstellen.Find(Function(x As ClassGeschaeftsstelle) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    'Dim r As ClassGeschaeftsstelle = ClassAdressen.Geschaeftsstellen.Find(Function(x As ClassGeschaeftsstelle) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    Dim b As ClassJustizAdresse = _projektadressen.Justizadressen.Find(Function(x As ClassJustizAdresse) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    'Dim b As ClassJustizAdresse = ClassAdressen.Justizadressen.Find(Function(x As ClassJustizAdresse) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    If IsNothing(b) Then
                        b = New ClassJustizAdresse With {.Name = "Bitte die passende  Justizadresse hinzufügen.", .Aktenzeichen = "***", .Betreff001 = "***"}
                    End If
                    Using dlg As New DialogWindowGeschaeftsstelle
                        With dlg
                            .Title = r.Label & " (" & ") "
                            .UserControlFORMULAR.Adresse = r
                            .UserControlFORMULAR.JustizAdresse = b
                            ClassDialogPositioning.SetDialogPosition(dlg)
                        End With
                        dlg.ShowDialog()
                        If dlg.DialogResult = True Then
                            ListViewADRESSEN.ItemsSource = Nothing
                            ListViewADRESSEN.ItemsSource = _projektadressen.Alle
                            'ListViewADRESSEN.ItemsSource = ClassAdressen.Alle
                            AutoSaveChanges()
                        End If
                    End Using
                Case GetType(ClassJustizDurchwahl).ToString
                    Dim r As ClassJustizDurchwahl = _projektadressen.Durchwahlen.Find(Function(x As ClassJustizDurchwahl) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    'Dim r As ClassJustizDurchwahl = ClassAdressen.Durchwahlen.Find(Function(x As ClassJustizDurchwahl) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    Dim b As ClassJustizAdresse = _projektadressen.Justizadressen.Find(Function(x As ClassJustizAdresse) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    'Dim b As ClassJustizAdresse = ClassAdressen.Justizadressen.Find(Function(x As ClassJustizAdresse) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    If IsNothing(b) Then
                        b = New ClassJustizAdresse With {.Name = "Bitte die passende  Justizadresse hinzufügen.", .Aktenzeichen = "***", .Betreff001 = "***"}
                    End If
                    Using dlg As New DialogWindowDurchwahl
                        With dlg
                            .Title = r.Label & " (" & ") "
                            .UserControlFORMULAR.Adresse = r
                            .UserControlFORMULAR.JustizAdresse = b
                            ClassDialogPositioning.SetDialogPosition(dlg)
                        End With
                        dlg.ShowDialog()
                        If dlg.DialogResult = True Then
                            ListViewADRESSEN.ItemsSource = Nothing
                            ListViewADRESSEN.ItemsSource = _projektadressen.Alle
                            'ListViewADRESSEN.ItemsSource = ClassAdressen.Alle
                            AutoSaveChanges()
                        End If
                    End Using
                'Polizei
                Case GetType(ClassPolizei).ToString
                    Dim r As ClassPolizei = _projektadressen.Polizei.Find(Function(x As ClassPolizei) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    'Dim r As ClassPolizei = ClassAdressen.Polizei.Find(Function(x As ClassPolizei) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    Using dlg As New DialogWindowPolizei
                        With dlg
                            .Title = r.Label & " (" & ") "
                            .UserControlFORMULAR.Adresse = r
                            ClassDialogPositioning.SetDialogPosition(dlg)
                        End With
                        dlg.ShowDialog()
                        If dlg.DialogResult = True Then
                            ListViewADRESSEN.ItemsSource = Nothing
                            ListViewADRESSEN.ItemsSource = _projektadressen.Alle
                            'ListViewADRESSEN.ItemsSource = ClassAdressen.Alle
                            AutoSaveChanges()
                        End If
                    End Using
                Case GetType(ClassAdresse).ToString
                    Dim r As ClassAdresse = _projektadressen.Andere.Find(Function(x As ClassAdresse) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    'Dim r As ClassAdresse = ClassAdressen.Andere.Find(Function(x As ClassAdresse) x.ID = ListViewADRESSEN.SelectedItem.ID)
                    Using dlg As New DialogWindowAdresse
                        With dlg
                            .Title = r.Label & " (" & r.Aktenzeichen & ") "
                            .UserControlADRESSE.Adresse = r
                            ClassDialogPositioning.SetDialogPosition(dlg)
                        End With
                        dlg.ShowDialog()
                        If dlg.DialogResult = True Then
                            ListViewADRESSEN.ItemsSource = Nothing
                            ListViewADRESSEN.ItemsSource = _projektadressen.Alle
                            'ListViewADRESSEN.ItemsSource = ClassAdressen.Alle
                            AutoSaveChanges()
                        End If
                    End Using
            End Select
        End If
    End Sub

    Private Sub ButtonNEU_Click(sender As Object, e As RoutedEventArgs) Handles ButtonNEU.Click
        Using dlg As New DialogWindowAdresseHinzufuegen
            ClassDialogPositioning.SetDialogPosition(dlg)
            dlg.ShowDialog()
            If dlg.DialogResult = True Then
                Select Case dlg.Adresse.GetType().ToString
                    Case GetType(ClassMandant).ToString
                        _projektadressen.Mandant.Add(dlg.Adresse)
                        'ClassAdressen.Mandant.Add(dlg.Adresse)
                    Case GetType(ClassJustizAdresse).ToString
                        _projektadressen.Justizadressen.Add(dlg.Adresse)
                        'ClassAdressen.Justizadressen.Add(dlg.Adresse)
                    Case GetType(ClassGeschaeftsstelle).ToString
                        _projektadressen.Geschaeftsstellen.Add(dlg.Adresse)
                        'ClassAdressen.Geschaeftsstellen.Add(dlg.Adresse)
                    Case GetType(ClassJustizDurchwahl).ToString
                        _projektadressen.Durchwahlen.Add(dlg.Adresse)
                        'ClassAdressen.Durchwahlen.Add(dlg.Adresse)
                    Case GetType(ClassPolizei).ToString
                        _projektadressen.Polizei.Add(dlg.Adresse)
                        'ClassAdressen.Polizei.Add(dlg.Adresse)
                    Case GetType(ClassAdresse).ToString
                        _projektadressen.Andere.Add(dlg.Adresse)
                        'ClassAdressen.Andere.Add(dlg.Adresse)
                    Case Else
                        MsgBox("Die Adresse konnte keiner Kategorie zugeordnet werden.")
                End Select
                ListViewADRESSEN.ItemsSource = Nothing
                ListViewADRESSEN.ItemsSource = _projektadressen.Alle
                'ListViewADRESSEN.ItemsSource = ClassAdressen.Alle
                AutoSaveChanges()
            End If
        End Using
    End Sub


    Private Sub ButtonLOESCHEN_Click(sender As Object, e As RoutedEventArgs) Handles ButtonLOESCHEN.Click
        If ListViewADRESSEN.SelectedIndex > -1 Then
            Select Case ListViewADRESSEN.SelectedItem.Klasse
                Case GetType(ClassMandant).ToString
                    Dim i As ClassMandant
                    i = _projektadressen.Mandant.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    'i = ClassAdressen.Mandant.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    If i IsNot Nothing Then
                        If MessageBox.Show("Soll die Adresse " & i.Label & " wirklich gelöscht werden?", "Achtung!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) = MessageBoxResult.Yes Then
                            _projektadressen.Mandant.Remove(i)
                            'ClassAdressen.Mandant.Remove(i)
                        End If
                    End If
                Case GetType(ClassJustizAdresse).ToString
                    Dim i As ClassJustizAdresse
                    i = _projektadressen.Justizadressen.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    'i = ClassAdressen.Justizadressen.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    If i IsNot Nothing Then
                        If MessageBox.Show("Soll die Adresse " & i.Label & " wirklich gelöscht werden?", "Achtung!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) = MessageBoxResult.Yes Then
                            _projektadressen.Justizadressen.Remove(i)
                            'ClassAdressen.Justizadressen.Remove(i)
                        End If
                    End If
                Case GetType(ClassGeschaeftsstelle).ToString
                    Dim i As ClassGeschaeftsstelle
                    i = _projektadressen.Geschaeftsstellen.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    'i = ClassAdressen.Geschaeftsstellen.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    If i IsNot Nothing Then
                        If MessageBox.Show("Soll die Adresse " & i.Label & " wirklich gelöscht werden?", "Achtung!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) = MessageBoxResult.Yes Then
                            _projektadressen.Geschaeftsstellen.Remove(i)
                            'ClassAdressen.Geschaeftsstellen.Remove(i)
                        End If
                    End If
                Case GetType(ClassJustizDurchwahl).ToString
                    Dim i As ClassJustizDurchwahl
                    i = _projektadressen.Durchwahlen.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    'i = ClassAdressen.Durchwahlen.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    If i IsNot Nothing Then
                        If MessageBox.Show("Soll die Adresse " & i.Label & " wirklich gelöscht werden?", "Achtung!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) = MessageBoxResult.Yes Then
                            _projektadressen.Durchwahlen.Remove(i)
                            'ClassAdressen.Durchwahlen.Remove(i)
                        End If
                    End If
                Case GetType(ClassPolizei).ToString
                    Dim i As ClassPolizei
                    i = _projektadressen.Polizei.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    'i = ClassAdressen.Polizei.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    If i IsNot Nothing Then
                        If MessageBox.Show("Soll die Adresse " & i.Label & " wirklich gelöscht werden?", "Achtung!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) = MessageBoxResult.Yes Then
                            _projektadressen.Polizei.Remove(i)
                            'ClassAdressen.Polizei.Remove(i)
                        End If
                    End If
                Case GetType(ClassAdresse).ToString
                    Dim i As ClassAdresse
                    i = _projektadressen.Andere.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    'i = ClassAdressen.Andere.Where(Function(a) a.ID = ListViewADRESSEN.SelectedItem.ID).First
                    If i IsNot Nothing Then
                        If MessageBox.Show("Soll die Adresse " & i.Label & " wirklich gelöscht werden?", "Achtung!", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) = MessageBoxResult.Yes Then
                            _projektadressen.Andere.Remove(i)
                            'ClassAdressen.Andere.Remove(i)
                        End If
                    End If
            End Select
            ListViewADRESSEN.ItemsSource = Nothing
            ListViewADRESSEN.ItemsSource = _projektadressen.Alle
            'ListViewADRESSEN.ItemsSource = ClassAdressen.Alle
            AutoSaveChanges()
        End If
    End Sub

    Private Sub ListViewADRESSEN_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ListViewADRESSEN.SelectionChanged
        If ListViewADRESSEN.SelectedIndex > -1 Then
            'SelectedAdress = ListViewADRESSEN.SelectedItem
            ClassPublicSelectedAdress.AdresseTyp = ListViewADRESSEN.SelectedItem.Klasse
            Select Case ListViewADRESSEN.SelectedItem.Klasse
                Case "lopstaControlAdressenVerzeichnis.ClassAdresse"
                    Try
                        ClassPublicSelectedAdress.Adresse = _projektadressen.Andere.Find(Function(i) i.ID = ListViewADRESSEN.SelectedItem.ID)
                        'ClassPublicSelectedAdress.Adresse = ClassAdressen.Andere.Find(Function(i) i.ID = ListViewADRESSEN.SelectedItem.ID)
                    Catch ex As Exception
                        ClassPublicSelectedAdress.Adresse = New ClassAdresse With {.Nachname = "Datensatz fehlerhaft!"}
                    End Try
                Case "lopstaControlAdressenVerzeichnis.ClassMandant"
                    Try
                        ClassPublicSelectedAdress.Adresse = _projektadressen.Mandant.Find(Function(i) i.ID = ListViewADRESSEN.SelectedItem.ID)
                        'ClassPublicSelectedAdress.Adresse = ClassAdressen.Mandant.Find(Function(i) i.ID = ListViewADRESSEN.SelectedItem.ID)
                    Catch ex As Exception
                        ClassPublicSelectedAdress.Adresse = New ClassAdresse With {.Nachname = "Datensatz fehlerhaft!"}
                    End Try
                Case "lopstaControlAdressenVerzeichnis.ClassJustizAdresse"
                    Try
                        ClassPublicSelectedAdress.Adresse = _projektadressen.Justizadressen.Find(Function(i) i.ID = ListViewADRESSEN.SelectedItem.ID)
                        'ClassPublicSelectedAdress.Adresse = ClassAdressen.Justizadressen.Find(Function(i) i.ID = ListViewADRESSEN.SelectedItem.ID)
                    Catch ex As Exception
                        ClassPublicSelectedAdress.Adresse = New ClassAdresse With {.Nachname = "Datensatz fehlerhaft!"}
                    End Try
                Case "lopstaControlAdressenVerzeichnis.ClassPolizei"
                    Try
                        ClassPublicSelectedAdress.Adresse = _projektadressen.Polizei.Find(Function(i) i.ID = ListViewADRESSEN.SelectedItem.ID)
                        'ClassPublicSelectedAdress.Adresse = ClassAdressen.Polizei.Find(Function(i) i.ID = ListViewADRESSEN.SelectedItem.ID)
                    Catch ex As Exception
                        ClassPublicSelectedAdress.Adresse = New ClassAdresse With {.Nachname = "Datensatz fehlerhaft!"}
                    End Try
                Case Else
                    ClassPublicSelectedAdress.Adresse = New ClassAdresse With {.Nachname = "", .Vorname = "", .Strasse = "", .Postleitzahl = "", .Ort = ""}
            End Select

            ' ===============================================
            ' übernimmt den zu den Adressen gespeicherten ersten Mandanten
            ' zur Weiterverarbeitung z.B. in Word
            ' wird z.B. in UserControlContainer.Partial.VorlagenWord weiterverarbeitet
            ' ===============================================
            If _projektadressen.Mandant.Count > 0 Then
                ClassPublicSelectedAdress.Mandant = _projektadressen.Mandant.First
                ClassPublicMandant.Mandant = _projektadressen.Mandant.First
            Else
                ClassPublicSelectedAdress.Mandant = New ClassMandant With {.Nachname = "### KEIN MANDANT ANGELRGT ###"}
                ClassPublicMandant.Mandant = New ClassMandant With {.Nachname = "### KEIN MANDANT ANGELRGT ###"}
            End If

        End If
    End Sub

    Private Sub AutoSaveChanges()
        If lopstaAppSettings.ClassSettings.IsAutoSave Then
            AdressenXmlDateiSpeichern()
        End If
    End Sub

    ' Dialog Buttons ===================================================================================================================

End Class

Imports System.IO
Imports System.Text
Partial Public Class MainWindow

    ' ==========================================
    ' Pfad zu dem Projekte-Verzeichnis
    ' ==========================================
    Private _pathPROJEKTE As String = String.Empty
    Public ReadOnly Property PathPROJEKTE As String
        Get
            If String.IsNullOrEmpty(_pathPROJEKTE) Then
                If AppSettings.BenutzerUeberschreibtSettings And AppSettings.IsMultiUser = True And Not String.IsNullOrEmpty(SelectedUserKey) Then
                    _pathPROJEKTE = User.Item(SelectedUserKey).PathPROJEKTE
                ElseIf Not String.IsNullOrEmpty(AppSettings.PfadProjekte) Then
                    _pathPROJEKTE = AppSettings.PfadProjekte
                End If
                SetFileSystemWatcherPROJEKTE()
            End If
            Return _pathPROJEKTE
        End Get
    End Property


    ' ====================================================================================
    ' Eigenschaften für die Inhalte der ListBoxen (Akten, Textbausteine, Word-Vorlagen, Excel-Vorlagen)
    ' für die Anbindung der Listen im XAML-Code
    ' ====================================================================================

    ' ==========================================
    ' Akten-Verzeichnis
    ' ==========================================
    Private _projekte As IEnumerable(Of DirectoryInfo) = Nothing
    Public ReadOnly Property Projekte As IEnumerable(Of DirectoryInfo)
        Get
            Try
                If IsNothing(_projekte) And Not String.IsNullOrEmpty(PathPROJEKTE) Then
                    Dim rgx As New RegularExpressions.Regex(RegExAktenzeichenGenerator)
                    _projekte = From d In New DirectoryInfo(PathPROJEKTE).GetDirectories()
                                Where (rgx.IsMatch(d.Name))
                                Select d Order By d.Name Descending
                End If
            Catch ex As Exception
                MessageBox.Show("Ihre Projekte konnten nicht eingelesen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Information)
            End Try
            Return _projekte
        End Get
    End Property


    ' ======================================================================
    ' FileSystemWatcher (Änderungen in dem Verzeichnis Projekte)
    ' Liest den Inhalt des Verzeichnisses neu in die Listbox ein
    ' ======================================================================
    Private Sub ProjekteNeuEinlesen(sender As Object, e As FileSystemEventArgs)
        'Throw New NotImplementedException()
        Dispatcher.Invoke(Sub()
                              _projekte = Nothing
                              _pathPROJEKTE = Nothing
                              ListBoxPROJEKTE.ItemsSource = Projekte
                          End Sub
        )
    End Sub



    Private Function RegExAktenzeichenGenerator() As String
        Select Case _appsettings.FormatAktenzeichen
            Case "00"
                Return "^(0{0,1}\d{1,2})"
            Case "000"
                Return "^(0{0,2}\d{1,3})"
            Case "0000"
                Return "^(0{0,3}\d{1,4})"
            Case "00000"
                Return "^(0{0,4}\d{1,5})"
            Case "00-yy"
                Return "^(0{0,1}\d{1,2})\-\d{2}"
            Case "000-yy"
                Return "^(0{0,2}\d{1,3})\-\d{2}"
            Case "0000-yy"
                Return "^(0{0,3}\d{1,4})\-\d{2}"
            Case "00000-yy"
                Return "^(0{0,4}\d{1,5})\-\d{2}"
            Case "00-yyyy"
                Return "^(0{0,1}\d{1,2})\-\d{4}"
            Case "000-yyyy"
                Return "^(0{0,2}\d{1,3})\-\d{4}"
            Case "0000-yyyy"
                Return "^(0{0,3}\d{1,4})\-\d{4}"
            Case "00000-yyyy"
                Return "^(0{0,4}\d{1,5})\-\d{4}"
            Case "yy-00"
                Return "^\d{2}\-(0{0,1}\d{1,2})"
            Case "yy-000"
                Return "^\d{2}\-(0{0,2}\d{1,3})"
            Case "yy-0000"
                Return "^\d{2}\-(0{0,3}\d{1,4})"
            Case "yy-00000"
                Return "^\d{2}\-(0{0,4}\d{1,5})"
            Case "yyyy-00"
                Return "^\d{4}\-(0{0,1}\d{1,2})"
            Case "yyyy-000"
                Return "^\d{4}\-(0{0,2}\d{1,3})"
            Case "yyyy-0000"
                Return "^\d{4}\-(0{0,3}\d{1,4})"
            Case "yyyy-00000"
                Return "^\d{4}\-(0{0,4}\d{1,5})"
            Case Else
                Return _appsettings.FormatAktenzeichen
        End Select
    End Function


    Private Function getRegisternummerFromPath(p As String) As String
        Dim rgx As New RegularExpressions.Regex(RegExAktenzeichenGenerator)
        Dim m = rgx.Match(p)
        If m.Success Then
            Return m.ToString
        Else
            Return "xxxFehlerxxx"
        End If
    End Function


    Private Function getLetzteRegisternummer() As String
        Dim nr As String = "0"
        If Not IsNothing(Projekte) And Projekte.Count > 0 Then
            Dim rgx As New RegularExpressions.Regex(RegExAktenzeichenGenerator)
            Dim m = rgx.Match(Projekte.First.Name)
            If m.Success Then
                nr = CType(CType(m.Groups(1).Value, Integer) + 1, String)
                Select Case _appsettings.FormatAktenzeichen
                    Case "00"
                        Return nr.PadLeft(2, "0")
                    Case "000"
                        Return nr.PadLeft(3, "0")
                    Case "0000"
                        Return nr.PadLeft(4, "0")
                    Case "00000"
                        Return nr.PadLeft(5, "0")
                    Case "00-yy"
                        Return nr.PadLeft(2, "0")
                    Case "000-yy"
                        Return nr.PadLeft(3, "0")
                    Case "0000-yy"
                        Return nr.PadLeft(4, "0")
                    Case "00000-yy"
                        Return nr.PadLeft(5, "0")
                    Case "00-yyyy"
                        Return nr.PadLeft(2, "0")
                    Case "000-yyyy"
                        Return nr.PadLeft(3, "0")
                    Case "0000-yyyy"
                        Return nr.PadLeft(4, "0")
                    Case "00000-yyyy"
                        Return nr.PadLeft(5, "0")
                    Case "yy-00"
                        Return nr.PadLeft(2, "0")
                    Case "yy-000"
                        Return nr.PadLeft(3, "0")
                    Case "yy-0000"
                        Return nr.PadLeft(4, "0")
                    Case "yy-00000"
                        Return nr.PadLeft(5, "0")
                    Case "yyyy-00"
                        Return nr.PadLeft(2, "0")
                    Case "yyyy-000"
                        Return nr.PadLeft(3, "0")
                    Case "yyyy-0000"
                        Return nr.PadLeft(4, "0")
                    Case "yyyy-00000"
                        Return nr.PadLeft(5, "0")
                    Case Else
                        Return "0"
                End Select
            Else
                Return "0"
            End If
        End If
        Return "0"
    End Function


    Private Function getRegisterNummerMitJahrgang(ByVal Nr As String, Optional ByVal Jahr As String = "0000") As String
        If CType(Nr, Integer) = 0 Or String.IsNullOrEmpty(Nr) Then
            Nr = "1"
        End If
        Dim neueRegisternummer As New System.Text.StringBuilder
        Select Case _appsettings.FormatAktenzeichen
            Case "00"
                With neueRegisternummer
                    .Append(Nr.PadLeft(2, "0"))
                End With
                Return neueRegisternummer.ToString
            Case "000"
                With neueRegisternummer
                    .Append(Nr.PadLeft(3, "0"))
                End With
                Return neueRegisternummer.ToString
            Case "0000"
                With neueRegisternummer
                    .Append(Nr.PadLeft(4, "0"))
                End With
                Return neueRegisternummer.ToString
            Case "00000"
                With neueRegisternummer
                    .Append(Nr.PadLeft(5, "0"))
                End With
                Return neueRegisternummer.ToString
            Case "00-yy"
                With neueRegisternummer
                    .Append(Nr.PadLeft(2, "0"))
                    .Append("-")
                    .Append(Jahr.Substring(-1, 2))
                End With
                Return neueRegisternummer.ToString
            Case "000-yy"
                With neueRegisternummer
                    .Append(Nr.PadLeft(3, "0"))
                    .Append("-")
                    .Append(Jahr.Substring(Jahr.Length - 2))
                End With
                Return neueRegisternummer.ToString
            Case "0000-yy"
                With neueRegisternummer
                    .Append(Nr.PadLeft(4, "0"))
                    .Append("-")
                    .Append(Jahr.Substring(Jahr.Length - 2))
                End With
                Return neueRegisternummer.ToString
            Case "00000-yy"
                With neueRegisternummer
                    .Append(Nr.PadLeft(5, "0"))
                    .Append("-")
                    .Append(Jahr.Substring(Jahr.Length - 2))
                End With
                Return neueRegisternummer.ToString
            Case "00-yyyy"
                With neueRegisternummer
                    .Append(Nr.PadLeft(2, "0"))
                    .Append("-")
                    .Append(Jahr.Substring(Jahr.Length - 4))
                End With
                Return neueRegisternummer.ToString
            Case "000-yyyy"
                With neueRegisternummer
                    .Append(Nr.PadLeft(3, "0"))
                    .Append("-")
                    .Append(Jahr.Substring(Jahr.Length - 4))
                End With
                Return neueRegisternummer.ToString
            Case "0000-yyyy"
                With neueRegisternummer
                    .Append(Nr.PadLeft(4, "0"))
                    .Append("-")
                    .Append(Jahr.Substring(Jahr.Length - 4))
                End With
                Return neueRegisternummer.ToString
            Case "00000-yyyy"
                With neueRegisternummer
                    .Append(Nr.PadLeft(5, "0"))
                    .Append("-")
                    .Append(Jahr.Substring(Jahr.Length - 4))
                End With
                Return neueRegisternummer.ToString
            Case "yy-00"
                With neueRegisternummer
                    .Append(Jahr.Substring(Jahr.Length - 2))
                    .Append("-")
                    .Append(Nr.PadLeft(2, "0"))
                End With
                Return neueRegisternummer.ToString
            Case "yy-000"
                With neueRegisternummer
                    .Append(Jahr.Substring(Jahr.Length - 2))
                    .Append("-")
                    .Append(Nr.PadLeft(3, "0"))
                End With
                Return neueRegisternummer.ToString
            Case "yy-0000"
                With neueRegisternummer
                    .Append(Jahr.Substring(Jahr.Length - 2))
                    .Append("-")
                    .Append(Nr.PadLeft(4, "0"))
                End With
                Return neueRegisternummer.ToString
            Case "yy-00000"
                With neueRegisternummer
                    .Append(Jahr.Substring(Jahr.Length - 2))
                    .Append("-")
                    .Append(Nr.PadLeft(5, "0"))
                End With
                Return neueRegisternummer.ToString
            Case "yyyy-00"
                With neueRegisternummer
                    .Append(Jahr.Substring(Jahr.Length - 4))
                    .Append("-")
                    .Append(Nr.PadLeft(2, "0"))
                End With
                Return neueRegisternummer.ToString
            Case "yyyy-000"
                With neueRegisternummer
                    .Append(Jahr.Substring(Jahr.Length - 4))
                    .Append("-")
                    .Append(Nr.PadLeft(3, "0"))
                End With
                Return neueRegisternummer.ToString
            Case "yyyy-0000"
                With neueRegisternummer
                    .Append(Jahr.Substring(Jahr.Length - 4))
                    .Append("-")
                    .Append(Nr.PadLeft(4, "0"))
                End With
                Return neueRegisternummer.ToString
            Case "yyyy-00000"
                With neueRegisternummer
                    .Append(Jahr.Substring(Jahr.Length - 4))
                    .Append("-")
                    .Append(Nr.PadLeft(5, "0"))
                End With
                Return neueRegisternummer.ToString
            Case Else
                Return "XXXFEHLERXXX"
        End Select
        Return "XXXFEHLERXXX"
    End Function


    Private Sub ListBoxPROJEKTE_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles ListBoxPROJEKTE.MouseDoubleClick
        Try
            If ListBoxPROJEKTE.SelectedIndex > -1 Then
                If Directory.Exists(ListBoxPROJEKTE.SelectedItem.FullName.ToString) Then
                    Process.Start(ListBoxPROJEKTE.SelectedItem.FullName.ToString)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Das Projektverzeichnis konnte nicht geöffnet werden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    ' ========================================================================================================
    ' Suchfunktion
    ' Filtern der Einträge in der ListBox Akten
    ' Es werden nur die Einträge angezeigt, die den Suchtext beinhalten
    ' ========================================================================================================
    Private Sub TextBoxAktenSUCHEN_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxAktenSUCHEN.KeyUp
        With ListBoxPROJEKTE
            ListBoxPROJEKTE.ItemsSource = From i In _projekte
                                          Where i.Name.Contains(sender.Text)
                                          Select i
        End With
    End Sub

    Private Sub ButtonAktenCOPY_Click(sender As Object, e As RoutedEventArgs) Handles ButtonAktenCOPY.Click
        If ListBoxPROJEKTE.SelectedIndex > -1 Then
            Try
                ' MsgBox(ListBoxAkten.SelectedItem.FullName.ToString)
                Dim f As New Specialized.StringCollection
                f.Add(ListBoxPROJEKTE.SelectedItem.FullName)
                Clipboard.SetFileDropList(f)
            Catch ex As Exception
                MessageBox.Show("Der Ordner mit der Akte konnte nicht in die Zwischenablage kopiert werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
            End Try
        Else
            MessageBox.Show("Bitte erst ein Projekt auswählen.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub

    Private Sub ButtonAktenCopyPATH_Click(sender As Object, e As RoutedEventArgs) Handles ButtonAktenCopyPATH.Click
        If ListBoxPROJEKTE.SelectedIndex > -1 Then
            Clipboard.SetText(ListBoxPROJEKTE.SelectedItem.FullName)
        Else
            MessageBox.Show("Bitte erst ein Projekt auswählen.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information)
        End If
    End Sub

    Private Sub ButtonAktenLOCATION_Click(sender As Object, e As RoutedEventArgs) Handles ButtonAktenLOCATION.Click
        Try
            If ListBoxPROJEKTE.SelectedIndex > -1 Then
                Process.Start(ListBoxPROJEKTE.SelectedItem.FullName.ToString)
            End If
        Catch ex As Exception
            MessageBox.Show("Das Projekt (Verzeichnis) konnte leider an dem angegebenen Ort nicht geöffnet werden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning)
        End Try
    End Sub

    Private Sub ListBoxPROJEKTE_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ListBoxPROJEKTE.SelectionChanged
        If ListBoxPROJEKTE.SelectedIndex > -1 Then
            'Einlesen der Adressen des Projektes
            'ProjektAdressen.ProjektAdressen = New ClassAdressen
            'ProjektAdressen.AdressenXmlDateiLaden(ListBoxPROJEKTE.SelectedItem.FullName.ToString)
            ProjektAdressen.FullName = ListBoxPROJEKTE.SelectedItem.FullName.ToString
            ' Einlesen der List mit den Projektdateien
            ProjektInhalte.FullName = ListBoxPROJEKTE.SelectedItem.FullName.ToString
            ProjektAdressen.IsEnabled = True
            ProjektInhalte.IsEnabled = True
            lopstaPROJEKTDATEN.AktivesProjekt.FullName = ListBoxPROJEKTE.SelectedItem.FullName.ToString
            lopstaPROJEKTDATEN.AktivesProjekt.Registernummer = getRegisternummerFromPath(ListBoxPROJEKTE.SelectedItem.Name.ToString)
        End If
    End Sub

    Private Sub TextBoxAktenSUCHEN_GotKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles TextBoxAktenSUCHEN.GotKeyboardFocus
        sender.Text = String.Empty
    End Sub
End Class

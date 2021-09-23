Imports System.IO
Imports System.Text.RegularExpressions

Public Class UserControlPROJEKTINHALT

    ' E I G E N S C H A F T E N ###############################################################################################################

    Private _fullname As String
    Public Property FullName As String
        Get
            Return _fullname
        End Get
        Set(value As String)
            _fullname = value
            DataGridDATEIEN.ItemsSource = Nothing
            '_inhalt = Nothing
            _inhalt = New List(Of ClassDatei)
            AuswahlHyperlinksHandakteErzeugen(_fullname)
            'ProjektVerzeichnisEinlesen("Alle")
            ProjktVerzeichnisAlleEinlesen()
            DataGridDATEIEN.ItemsSource = Nothing
            DataGridDATEIEN.ItemsSource = _inhalt.OrderBy(Function(x) x.Datum).Reverse
        End Set
    End Property

    Private _projektverzeichnis As DirectoryInfo
    Public Property ProjektVerzeichnis As DirectoryInfo
        Get
            Return _projektverzeichnis
        End Get
        Set(value As DirectoryInfo)
            _projektverzeichnis = value
        End Set
    End Property

    Private _inhalt As List(Of ClassDatei)

    Private _akte As List(Of FileInfo)


    ' E R E I G N I S S E #####################################################################################################################

    ' D E L E G A T E N #######################################################################################################################
    Delegate Sub Test(sender As Object)


    ' M E T H O D E N #########################################################################################################################

    Private Sub AuswahlHyperlinksErzeugen(ByVal d As String)
        WrapPanelAUSWAHLHYPERLINKS.Children.Clear()
        Try
            Dim di As New DirectoryInfo(d)
            If di.Exists Then
                For Each v As DirectoryInfo In di.GetDirectories
                    Dim t As New TextBlock
                    Dim hl As New Hyperlink
                    With hl
                        .Tag = v.FullName
                        .Inlines.Add(New TextBlock With {.Text = v.Name})
                    End With
                    t.Inlines.Add(hl)
                    WrapPanelAUSWAHLHYPERLINKS.Children.Add(t)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AuswahlHyperlinksHandakteErzeugen(ByVal d As String)
        WrapPanelAUSWAHLHYPERLINKS.Children.Clear()
        Try
            Dim di As New DirectoryInfo(Path.Combine(d, "02_Handakte"))
            Dim rgx As New Regex("(?:[\p{L}\d]{0,3}_{1})?([\p{L}\d]{1,100})")
            If di.Exists Then
                Dim t As TextBlock
                Dim hl As Hyperlink
                t = New TextBlock
                hl = New Hyperlink
                With hl
                    .Inlines.Add("Alle")
                    .Tag = "Alle"
                    .ToolTip = di.FullName
                    AddHandler hl.Click, AddressOf HyperlinkFilter_Click
                End With
                t.Inlines.Add(hl)
                WrapPanelAUSWAHLHYPERLINKS.Children.Add(t)
                For Each v As DirectoryInfo In di.GetDirectories
                    t = New TextBlock
                    hl = New Hyperlink
                    With hl
                        .Tag = v.FullName
                        .ToolTip = v.FullName
                        Dim m As Match
                        m = rgx.Match(v.Name)
                        If m.Success Then
                            .Inlines.Add(m.Groups(1).ToString)
                        Else
                            .Inlines.Add(v.Name.Trim)
                        End If

                    End With
                    t.Inlines.Add(hl)
                    WrapPanelAUSWAHLHYPERLINKS.Children.Add(t)
                    AddHandler hl.Click, AddressOf HyperlinkFilter_Click
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AuswahlHyperlinksAkteErzeugen(ByVal d As String)
        WrapPanelAUSWAHLHYPERLINKS.Children.Clear()
        Dim di As New DirectoryInfo(Path.Combine(d, "01_Akte"))
        If di.GetDirectories.Length < 1 Then
            Exit Sub
        End If
        Try


            Dim rgx As New Regex("(?:[\p{L}\d]{0,3}_{1})?([\p{L}\d]{1,100})")
            If di.Exists Then
                Dim t As TextBlock
                Dim hl As Hyperlink
                t = New TextBlock
                hl = New Hyperlink
                With hl
                    .Inlines.Add("Alle")
                    .Tag = "Alle"
                    .ToolTip = di.FullName
                    AddHandler hl.Click, AddressOf HyperlinkFilterAkte_Click
                End With
                t.Inlines.Add(hl)
                WrapPanelAUSWAHLHYPERLINKS.Children.Add(t)
                For Each v As DirectoryInfo In di.GetDirectories
                    t = New TextBlock
                    hl = New Hyperlink
                    With hl
                        .Tag = v.FullName
                        .ToolTip = v.FullName
                        Dim m As Match
                        m = rgx.Match(v.Name)
                        If m.Success Then
                            .Inlines.Add(m.Groups(1).ToString)
                        Else
                            .Inlines.Add(v.Name.Trim)
                        End If

                    End With
                    t.Inlines.Add(hl)
                    WrapPanelAUSWAHLHYPERLINKS.Children.Add(t)
                    AddHandler hl.Click, AddressOf HyperlinkFilter_Click
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ProjektVerzeichnisEinlesen(ByVal d As String)
        Try
            Dim di As New DirectoryInfo(d)
            Dim rgx As New Regex("^(\d{4}\-\d{2}\-\d{2})_([a-zöäüA-ZÄÖÜ0-9()]{2,10})_([a-zöäüA-ZÄÖÜ0-9()]{2,10}).*")
            If di.Exists Then
                For Each fi As FileInfo In di.GetFiles.Where(Function(x) x.Attributes <> 34)
                    Dim f As New ClassDatei
                    f.Name = Path.GetFileNameWithoutExtension(fi.Name)
                    f.FullName = fi.FullName
                    f.LastChanged = fi.LastWriteTime
                    f.Suffix = fi.Extension
                    If rgx.IsMatch(Path.GetFileNameWithoutExtension(f.Name)) Then
                        Dim teile As String() = f.Name.Split("_")
                        f.Datum = teile(0)
                        If teile(1).Length <= 15 Then
                            f.Typ = teile(1)
                        Else
                            f.Typ = teile(1).Substring(0, 12) & "..."
                        End If
                        If teile.Count >= 3 Then
                            If teile(2).Length <= 15 Then
                                f.Adressat = teile(2)
                            Else
                                f.Adressat = teile(2).Substring(0, 12) & "..."
                            End If
                        End If
                        If teile.Count >= 4 Then
                            f.Bezeichnung = teile(3)
                        End If
                        If teile.Count >= 5 Then
                            'f.Entwurf = teile(4)
                            f.Bezeichnung &= teile(4)
                        End If
                    Else
                        f.Datum = fi.LastWriteTime.ToString("yyyy-MM-dd")
                        f.Typ = ""
                        f.Adressat = ""
                        f.Bezeichnung = Path.GetFileNameWithoutExtension(f.Name)
                        'f.Entwurf = ""
                    End If
                    _inhalt.Add(f)
                    '_inhalt.Sort(Function(x, y) x.Datum.CompareTo(y.Datum))
                Next
            End If
        Catch ex001 As DirectoryNotFoundException
            MessageBox.Show("Das Projekt-Verzeichnis wurde nicht gefunden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error)
        Catch ex As Exception
            MessageBox.Show("Leider ist bei dem Versuch die Projekt-Dateien einzulesen ein Fehler aufgetreten.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    Private Sub ProjktVerzeichnisAlleEinlesen()
        Dim d As New DirectoryInfo(Path.Combine(_fullname, "02_Handakte"))
        Try
            If d.Exists Then
                For Each sd As DirectoryInfo In d.GetDirectories
                    ProjektVerzeichnisEinlesen(sd.FullName)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Das Verzeichnis mit dem Projekt kann nicht eingelesen werden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub


    Private Sub AkteUnterverzeichnisEinlesen(ByVal d As String)
        _inhalt.Clear()
        Try
            Dim di As New DirectoryInfo(Path.Combine(d, "01_Akte"))
            Dim rgx As New Regex("(?:[\p{L}\d]{0,3}_{1})?([\p{L}\d]{1,100})")
            If di.Exists Then
                For Each fi As FileInfo In di.GetFiles.Where(Function(x) x.Attributes <> 34)
                    Dim f As New ClassDatei
                    f.Datum = fi.LastWriteTime.ToString("yyyy-MM-dd")
                    f.Bezeichnung = fi.Name
                    f.FullName = fi.FullName
                    _inhalt.Add(f)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Der Inhalt des Verzeichnisses konnte nicht eingelesen werden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning)
        End Try
    End Sub

    Private Sub ProjektVerzeichnisAkteAlleEinlesen()
        Dim d As New DirectoryInfo(Path.Combine(_fullname, "01_Akte"))
        Try
            If d.Exists Then
                For Each sd As DirectoryInfo In d.GetDirectories
                    AkteUnterverzeichnisEinlesen(sd.FullName)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Das Verzeichnis 'Akte' kann nicht eingelesen werden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    Private Sub DataGridDATEIEN_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles DataGridDATEIEN.MouseDoubleClick
        Try
            If DataGridDATEIEN.SelectedIndex > -1 Then
                If File.Exists(DataGridDATEIEN.SelectedItem.FullName.ToString) Then
                    Process.Start(DataGridDATEIEN.SelectedItem.FullName.ToString)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Die Datei konnte leider nicht geöffnet werden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning)
        End Try
    End Sub

    ' B U T T O N  C L I C K  E R E I G N I S S E #############################################################################################



    ' H Y P E R L I N K  C L I C K E R E I G N I S S E ########################################################################################

    Public Sub HyperlinkFilter_Click(sender As Object, e As System.EventArgs)
        _inhalt = New List(Of ClassDatei)
        If sender.Tag = "Alle" Then
            ProjktVerzeichnisAlleEinlesen()
        Else
            ProjektVerzeichnisEinlesen(sender.Tag)
        End If
        DataGridDATEIEN.ItemsSource = Nothing
        DataGridDATEIEN.ItemsSource = _inhalt
    End Sub

    Public Sub HyperlinkFilterAkte_Click(sender As Object, e As System.EventArgs)
        If sender.Tag = "Alle" Then
            ProjktVerzeichnisAlleEinlesen()
        Else
            DataGridDATEIEN.ItemsSource = Nothing
            DataGridDATEIEN.ItemsSource = sender.Tag
        End If
    End Sub

    Private Sub ButtonDateiLOESCHEN_Click(sender As Object, e As RoutedEventArgs) Handles ButtonDateiLOESCHEN.Click
        If DataGridDATEIEN.SelectedIndex > -1 Then
            If MessageBox.Show("Soll die Datei " & DataGridDATEIEN.SelectedItem.Name & " wirklich gelöscht werden?", "Sicherheitshinweis", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) = MessageBoxResult.Yes Then
                Try
                    File.Delete(DataGridDATEIEN.SelectedItem.FullName)
                Catch ex As Exception
                    MessageBox.Show("Bei dem Versuch die Datei " & DataGridDATEIEN.SelectedItem.Name & " zu löschen ist leider ein Fehler aufgetreten.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub TextBoxDateiSUCHEN_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxDateiSUCHEN.KeyUp
        Dim rgx As New Regex("^(Datum\:|datum\:|Typ\:|typ\:|Adressat\:adressat\:)\s?(.*)")
        Dim s As Match = rgx.Match(sender.text)
        If s.Success Then
            Select Case s.Groups(1).ToString
                Case "Datum:"
                    DataGridDATEIEN.ItemsSource = From i In _inhalt
                                                  Where i.Datum.Contains(s.Groups(2).ToString)
                                                  Select i
                Case "datum:"
                    DataGridDATEIEN.ItemsSource = From i In _inhalt
                                                  Where i.Datum.Contains(s.Groups(2).ToString)
                                                  Select i
                Case "Typ:"
                    DataGridDATEIEN.ItemsSource = From i In _inhalt
                                                  Where i.Typ.Contains(s.Groups(2).ToString)
                                                  Select i
                Case "typ:"
                    DataGridDATEIEN.ItemsSource = From i In _inhalt
                                                  Where i.Typ.Contains(s.Groups(2).ToString)
                                                  Select i
                Case "Adressat:"
                    DataGridDATEIEN.ItemsSource = From i In _inhalt
                                                  Where i.Adressat.Contains(s.Groups(2).ToString)
                                                  Select i
                Case "adressat:"
                    DataGridDATEIEN.ItemsSource = From i In _inhalt
                                                  Where i.Adressat.Contains(s.Groups(2).ToString)
                                                  Select i
            End Select
        Else
            DataGridDATEIEN.ItemsSource = From i In _inhalt
                                          Where i.Name.Contains(sender.text)
                                          Select i
        End If
    End Sub

    Private Sub HyperLinkHANDAKTE_Click(sender As Object, e As RoutedEventArgs) Handles HyperLinkHANDAKTE.Click
        AuswahlHyperlinksHandakteErzeugen(_fullname)
        ProjktVerzeichnisAlleEinlesen()
        DataGridDATEIEN.ItemsSource = Nothing
        DataGridDATEIEN.ItemsSource = _inhalt.OrderBy(Function(x) x.Datum).Reverse
    End Sub

    Private Sub HyperLinkAKTE_Click(sender As Object, e As RoutedEventArgs) Handles HyperLinkAKTE.Click
        AuswahlHyperlinksAkteErzeugen(_fullname)
        AkteUnterverzeichnisEinlesen(_fullname)
        DataGridDATEIEN.ItemsSource = Nothing
        DataGridDATEIEN.ItemsSource = _inhalt
    End Sub

    ' L I S T B O X  S E L E C T I O N  C H A N G E D  E R E I G N I S S E ####################################################################

End Class

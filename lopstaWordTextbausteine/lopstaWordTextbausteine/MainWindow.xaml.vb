Imports System.IO

Class MainWindow
    Private Sub ButtonEinfuegen_Click(sender As Object, e As RoutedEventArgs) Handles ButtonEinfuegen.Click
        If String.IsNullOrEmpty(TextBoxPfad.Text) Then
            MsgBox("Bitte erst eine Datei aus der Liste auswählen ...")
            Exit Sub
        End If
        lopstaWordSchnittstelleTextbausteine.ClassTextbausteinAlsHtmlEinfuegen.InsertHtml(TextBoxPfad.Text)
        'lopstaWordSchnittstelleTextbausteine.ClassTextbausteinAlsDateiEinfuegen.InsertHtml(TextBoxPfad.Text)
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        FillListViewWithFiles("k:\engineering WORD\Testbausteine")
    End Sub

    Private Sub FillListViewWithFiles(p As String)
        Dim di As New DirectoryInfo(p)
        If di.Exists Then
            Try
                ListViewTextbausteine.ItemsSource = Nothing
                ListViewTextbausteine.ItemsSource = di.GetFiles()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ListViewTextbausteine_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ListViewTextbausteine.SelectionChanged
        TextBoxPfad.Text = ListViewTextbausteine.SelectedItem.FullName
    End Sub
End Class

Imports Microsoft.Office.Interop

Public Class ClassTextbausteinAlsDateiEinfuegen

    Private Shared wrd As Word.Application
    Private Shared doc As Word.Document

    Public Shared Sub InsertHtml(f As String)

        Dim wrd As Word.Application
        Dim doc As Word.Document

        If ClassCheckWordIsStarted.Check(wrd) And ClassActivateWord.Activate(wrd, doc) Then
            Try
                wrd.Selection.FormattedText.InsertFile(f)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

End Class

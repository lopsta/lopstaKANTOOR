Imports Microsoft.Office.Interop
Imports System.Text.RegularExpressions

Public Class ClassFelderErsetzen

    Private Shared wrd As Word.Application
    Private Shared doc As Word.Document

    Public Shared Sub Ersetzen(ByVal d As Dictionary(Of String, String))
        ' Dim wrd As Word.Application = Nothing
        ' Dim doc As Word.Document = Nothing

        If ClassCheckWordIsStarted.Check(wrd) And ClassActivateWord.Activate(wrd, doc) Then
            'If ClassCheckWordIsStarted.Check(wrd) Then
            doc = wrd.ActiveDocument
            Try
                For Each k As String In d.Keys
                    Dim suchen As String = "«" & k & "»"
                    Dim ersetzen As String = d(k)
                    doc.Content.Find.Execute(FindText:=suchen, ReplaceWith:=ersetzen, Replace:=WdReplace.wdReplaceAll, Forward:=True)
                Next
                doc.Activate()
                wrd.Activate()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

End Class

Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core

Public Class ClassActivateWord

    Public Shared Function Activate(ByRef wrd As Word.Application, ByRef doc As Word.Document) As Boolean
        Try
            If wrd.Documents.Count > 0 Then
                doc = wrd.ActiveDocument
                wrd.Activate()
                doc.Activate()
                Return True
            Else
                MsgBox("Es ist noch  kein Word-Dokument geöffnet. Textbausteine können nur in ein Dokument eingefügt werden, das sich bereits in Bearbeitung befindet.")
                Return False
            End If
        Catch ex As Exception
            MsgBox("Das Word-Dokument konnte nicht aktiviert werden.")
            Return False
        End Try
        Return False
    End Function

End Class

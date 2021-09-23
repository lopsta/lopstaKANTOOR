Imports Microsoft.Office.Interop
Imports System.IO
Public Class ClassActiveDocumentSaveAs

    'Private Shared wrd As Word.Application
    'Private Shared doc As Word.Document

    Shared Sub DocumentSaveAs(ByVal p As String, ByVal n As String)

        Dim wrd As Word.Application
        Dim doc As Word.Document

        wrd = GetObject(, "Word.Application")

        If Not IsNothing(wrd.ActiveDocument) And wrd.ActiveDocument.Saved = False Then
            Dim docPath As String = Nothing
            If Not IsNothing(p) Then
                docPath = Path.Combine(p, n)
            Else
                docPath = n
            End If
            doc = wrd.ActiveDocument
            doc.BuiltInDocumentProperties("Title").Value = n
            'wrd.ChangeFileOpenDirectory(p) => kann den Pfad des Dokumentes ändern
            Dim dlg As Word.Dialog = wrd.Dialogs(Word.WdWordDialog.wdDialogFileSaveAs)
            dlg.Name = docPath ' => wird nicht nur der Dateiname sondern auch ein Pfad angegeben, wird der Pfad in der Ordner-Zeile oben angezeigt.
            'dlg.Execute()
            ''dlg.GetType().InvokeMember("Name", Reflection.BindingFlags.SetProperty, Nothing, dlg, New Object() {"Test"}) => Refelctions sind bei der oben gezeigten Lösung nicht erforderlich
            dlg.Show()
            ' doc.SaveAs2(Path.Combine(p, n))
        End If

    End Sub

End Class

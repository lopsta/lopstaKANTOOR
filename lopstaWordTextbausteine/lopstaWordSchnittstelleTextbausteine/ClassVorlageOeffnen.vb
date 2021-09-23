Imports Microsoft.Office.Interop

Public Class ClassVorlageOeffnen

    Private Shared wrd As Word.Application
    Private Shared doc As Word.Document

    Public Shared Sub Oeffnen(b As String, f As String)

        If ClassCheckWordIsStarted.Check(wrd) Then
            Try
                'doc = wrd.Documents.Add(f)
                doc = wrd.Documents.Add(b)

                ' ====================================
                ' Fügt der Vorlage eigene Properties hinzu
                ' ====================================
                Try
                    doc.CustomDocumentProperties.Add("lopstaRegNr", False, MsoDocProperties.msoPropertyTypeString, "20-0001")
                    doc.CustomDocumentProperties.Add("lopstaDocPath", False, MsoDocProperties.msoPropertyTypeString, "Pfad")
                Catch ex As Exception
                    MsgBox("Hinzufügen der CustomProperties" & ex.Message)
                End Try

                If Not f = "blanko" Then
                    Dim r As Range = doc.Range
                    r.Find.Execute(FindText:="«Text»")
                    r.InsertFile(f)
                End If
                wrd.Activate()
                'doc.Activate()
                wrd.ScreenRefresh()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

End Class

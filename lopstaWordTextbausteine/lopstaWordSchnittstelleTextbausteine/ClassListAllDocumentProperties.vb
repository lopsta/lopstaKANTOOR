Imports Microsoft.Office.Interop
Public Class ClassListAllDocumentProperties

    Public Shared Sub ListAllDocumentProperties()

        Dim wrd As Word.Application
        Dim doc As Word.Document

        wrd = GetObject(, "Word.Application")
        doc = wrd.ActiveDocument

        Dim rngDoc As Range

        rngDoc = doc.Content

        Try
            rngDoc.InsertAfter("BuiltInDocumentProperties ===================================================")
            rngDoc.InsertParagraphAfter()
            rngDoc.InsertAfter("Anzahl: " & doc.BuiltInDocumentProperties.Count)
            For Each i In doc.BuiltInDocumentProperties
                With rngDoc
                    .InsertParagraphAfter()
                    .InsertAfter(i.Name & "= ")
                    .InsertAfter(i.Value)
                End With
            Next
        Catch ex As Exception
            rngDoc.InsertParagraphAfter()
            rngDoc.InsertAfter("Fehler => BuiltInDocumentProperties")
            rngDoc.InsertAfter(ex.Message)
        End Try

        Try
            doc.CustomDocumentProperties.Add("lopstaRegNr", False, MsoDocProperties.msoPropertyTypeString, "20-0001")
            doc.CustomDocumentProperties.Add("lopstaDocPath", False, MsoDocProperties.msoPropertyTypeString, "Pfad")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'doc.CustomDocumentProperties.Add(Name:="RegNr", LinkToContent:=False, Value:="21-0001")

        Try
            rngDoc.InsertParagraphAfter()

            rngDoc.InsertAfter("CustomDocumentProperties =======================================================")
            rngDoc.InsertParagraphAfter()
            rngDoc.InsertAfter("Anzahl: " & doc.CustomDocumentProperties.Count)
            For Each i In doc.CustomDocumentProperties
                With rngDoc
                    .InsertParagraphAfter()
                    .InsertAfter(i.Name & "= ")
                    .InsertAfter(i.Value)
                End With
            Next
        Catch ex As Exception
            rngDoc.InsertParagraphAfter()
            rngDoc.InsertAfter("Fehler => CustomDocumentProperties")
            rngDoc.InsertAfter(ex.Message)
        End Try

    End Sub


End Class

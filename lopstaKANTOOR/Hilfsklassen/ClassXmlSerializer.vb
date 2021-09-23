Imports System.IO

Public Class ClassXmlSerializer

    ' Lesen
    Public Shared Function Read(ByVal p As String, ByRef o As Object) As Object
        Dim s As New Xml.Serialization.XmlSerializer(o.GetType) ' searializer
        Dim r As New FileStream(p, FileMode.Open) ' readerFileStream
        Try
            o = s.Deserialize(r)
            r.Dispose()
            r = Nothing
            Return o
        Catch ex As Exception
            MessageBox.Show("Die Datei '" & p & "' konnte nicht geladen werden.", "Fehler beim Laden!", MessageBoxButton.OK, MessageBoxImage.Error)
            r.Dispose()
            r = Nothing
        End Try
        Return Nothing
    End Function

    ' Schreiben
    Public Shared Function Write(ByVal p As String, ByRef o As Object) As Boolean
        Dim s As New Xml.Serialization.XmlSerializer(o.GetType) ' searializer
        Dim w As New FileStream(p, FileMode.Create) ' writer
        Try
            s.Serialize(w, o)
            Return True
        Catch ex As Exception
            MessageBox.Show("Die XML-Datei '" & o.GetType.ToString & "' konnte nicht gespeichert werden.", "Fehler beim Speichern!", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
        Return False
    End Function

End Class

Imports System.IO

Public Class ClassLesen
    Implements IDisposable

    ' D I S P O S E A B L E ##################################################################################################################################
#Region "IDisposable Support"
    Private disposedValue As Boolean ' Dient zur Erkennung redundanter Aufrufe.

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: verwalteten Zustand (verwaltete Objekte) entsorgen.
            End If

            ' TODO: nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalize() weiter unten überschreiben.
            ' TODO: große Felder auf Null setzen.
        End If
        disposedValue = True
    End Sub

    ' TODO: Finalize() nur überschreiben, wenn Dispose(disposing As Boolean) weiter oben Code zur Bereinigung nicht verwalteter Ressourcen enthält.
    'Protected Overrides Sub Finalize()
    '    ' Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(disposing As Boolean) weiter oben ein.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Dieser Code wird von Visual Basic hinzugefügt, um das Dispose-Muster richtig zu implementieren.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(disposing As Boolean) weiter oben ein.
        Dispose(True)
        ' TODO: Auskommentierung der folgenden Zeile aufheben, wenn Finalize() oben überschrieben wird.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

    Public Shared Function Lesen(ByVal p As String) As ClassAdressen
        Dim a As New ClassAdressen
        Dim s As New Xml.Serialization.XmlSerializer(GetType(ClassAdressen)) ' searializer
        Using r As New FileStream(p, FileMode.Open) ' readerFileStream
            Try
                a = s.Deserialize(r)
            Catch ex As Exception
                MessageBox.Show("Die Liste der Adressen konnte nicht geladen werden.", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error)
            End Try
        End Using
        s = Nothing
        Return a
    End Function


End Class

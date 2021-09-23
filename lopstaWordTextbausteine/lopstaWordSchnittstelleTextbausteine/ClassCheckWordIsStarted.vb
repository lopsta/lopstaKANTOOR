Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core

Public Class ClassCheckWordIsStarted

    Public Shared Function Check(ByRef wrd As Word.Application) As Boolean
        ' Prüfen ob Word bereits geöffnet ist, andernfalls starten. Wenn mehr als ein WINWORD-Prozess gefunden wird Abbruch
        Try
            Dim pr As Array = Process.GetProcessesByName("WINWORD")
            Array.Sort(pr)
            If pr.Length >= 1 Then
                Try
                    wrd = GetObject(, "Word.Application") 'System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application")
                    wrd.Activate()
                    Return True
                Catch ex As Exception
                    MsgBox("Fehler es konnte kein geöffnetes Word-Programm gefunden werden.")
                    Return False
                End Try
            ElseIf pr.Length = 0 Then
                Try
                    Process.Start("winword.exe")
                    'Shell("winword")
                    Threading.Thread.Sleep(7000)
                    wrd = GetObject(, "Word.Application") 'System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application")
                    wrd.Activate()
                    Return True
                Catch ex As Exception
                    MsgBox("Fehler es konnte kein geöffnetes Word-Programm gefunden und Word konnte auch nicht gestartet werden.")
                    Return False
                End Try
            ElseIf pr.Length > 1 Then
                MsgBox("Fehler: Es sind mehrere Word-Instanzen geöffnet.")
                Return False
            Else
                MsgBox("Ein Textbaustein kann nur in ein bereits geöffnetes Dokument eingefügt werden. Bitte zuerst Word starten.")
                Return False
            End If
        Catch ex As Exception
            MsgBox("Die Überprüfung, ob Word bereits gestartet ist, lässt sich nicht durchführen.")
            Return False
        End Try

        Return False
    End Function

End Class

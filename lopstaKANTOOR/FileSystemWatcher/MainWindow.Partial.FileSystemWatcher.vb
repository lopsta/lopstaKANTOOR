Imports System.ComponentModel
Imports System.IO
Imports System.Threading

Partial Public Class MainWindow

    ' ==========================================
    ' FileSystemWatcher
    ' für die Verzeichnisse
    '  => Projekte
    ' ==========================================
    Private fswProjekte As FileSystemWatcher


    Private Sub SetFileSystemWatcherPROJEKTE()
        fswProjekte = New FileSystemWatcher
        Try
            With fswProjekte
                .Path = _pathPROJEKTE
                .EnableRaisingEvents = True
                AddHandler .Created, AddressOf ProjekteNeuEinlesen
                AddHandler .Deleted, AddressOf ProjekteNeuEinlesen
                AddHandler .Changed, AddressOf ProjekteNeuEinlesen
                AddHandler .Renamed, AddressOf ProjekteNeuEinlesen
            End With
        Catch ex As Exception

        End Try
    End Sub

End Class

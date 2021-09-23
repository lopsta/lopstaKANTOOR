Imports lopstaControlPROJEKTINHALT

Public Class ClassDatei

    Implements IComparable(Of ClassDatei)

    Public Property Icon As String

    Public Property Name As String
    Public Property FullName As String
    Public Property Suffix As String
    Public Property LastChanged As String

    Public Property Datum As String
    Public Property Adressat As String
    Public Property Typ As String
    Public Property Bezeichnung As String

    Public Function CompareTo(other As ClassDatei) As Integer Implements IComparable(Of ClassDatei).CompareTo
        Throw New NotImplementedException()
        Return Me.Datum.CompareTo(other.Datum)
    End Function

    ' TODO ggfls. löschen => Entwurf wird mit Bezeichnung zusammengeführt
    'Public Property Entwurf As String

End Class

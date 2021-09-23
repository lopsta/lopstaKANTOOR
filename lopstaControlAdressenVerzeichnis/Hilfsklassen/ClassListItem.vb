Public Class ClassListItem
    Implements IComparable(Of ClassListItem)

    Public Property ID As String

    Public Property Typ As String

    Public Property Klasse As String

    Public Property Label As String

    Public Function CompareTo(other As ClassListItem) As Integer Implements IComparable(Of ClassListItem).CompareTo
        Return Me.Label().CompareTo(other.Label)
    End Function
End Class

Imports System.Xml.Serialization
Imports System.Text
Imports System.IO

<Serializable>
Public Class ClassAdressen


    '<NonSerialized>
    <Xml.Serialization.XmlIgnore>
    Private _alle As List(Of ClassListItem)
    Public ReadOnly Property Alle As List(Of ClassListItem)
        Get
            _alle = New List(Of ClassListItem)
            Mandant.Sort()
            For Each i As ClassAdresse In Mandant
                _alle.Add(New ClassListItem With {.ID = i.ID, .Klasse = i.GetType().ToString, .Label = i.Label})
            Next
            Justizadressen.Sort()
            For Each i As ClassJustizAdresse In Justizadressen
                _alle.Add(New ClassListItem With {.ID = i.ID, .Klasse = i.GetType().ToString, .Label = i.Label})
            Next
            Geschaeftsstellen.Sort()
            For Each i As ClassGeschaeftsstelle In Geschaeftsstellen
                _alle.Add(New ClassListItem With {.ID = i.ID, .Klasse = i.GetType().ToString, .Label = i.Label})
            Next
            Durchwahlen.Sort()
            For Each i As ClassJustizDurchwahl In Durchwahlen
                _alle.Add(New ClassListItem With {.ID = i.ID, .Klasse = i.GetType().ToString, .Label = i.Label})
            Next
            Polizei.Sort()
            For Each i As ClassPolizei In Polizei
                _alle.Add(New ClassListItem With {.ID = i.ID, .Klasse = i.GetType().ToString, .Label = i.Label})
            Next
            Andere.Sort()
            For Each i As ClassAdresse In Andere
                _alle.Add(New ClassListItem With {.ID = i.ID, .Klasse = i.GetType().ToString, .Label = i.Label})
            Next
            _alle.Sort()
            Return _alle
        End Get
    End Property

    Public Property Mandant As New List(Of ClassMandant)

    Public Property Justizadressen As New List(Of ClassJustizAdresse)

    Public Property Geschaeftsstellen As New List(Of ClassGeschaeftsstelle)

    Public Property Durchwahlen As New List(Of ClassJustizDurchwahl)

    Public Property Polizei As New List(Of ClassPolizei)

    Public Property Andere As New List(Of ClassAdresse)


End Class

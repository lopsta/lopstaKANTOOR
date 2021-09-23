Imports System.IO
Imports System.Data
Imports System.Xml.Serialization
Imports System.Xml

Public Class Justizadressen

    Private Shared _dsfile As String = "Resources\Justizadressen.xml"
    Private Shared _ds As DataSetJustizadressen
    Private Shared _dspath As String = Directory.GetCurrentDirectory

    Private _dv As DataView
    Public ReadOnly Property DV As DataView
        Get
            Return _dv
        End Get
    End Property

    Private Shared _dvstaatsanwaltschaften As DataView
    Public Shared ReadOnly Property DataViewStaatsanwaltschaften As DataView
        Get
            If _dvstaatsanwaltschaften Is Nothing Then
                If _ds Is Nothing Then
                    AdressenLaden()
                End If
                _dvstaatsanwaltschaften = New DataView(_ds.Staatsanwaltschaften)
                _dvstaatsanwaltschaften.Sort = "Ort"
            End If
            Return _dvstaatsanwaltschaften
        End Get
    End Property

    Private Shared _dvamtsgerichte As DataView
    Public Shared ReadOnly Property DataViewAmtsgerichte As DataView
        Get
            If _dvamtsgerichte Is Nothing Then
                If _ds Is Nothing Then
                    AdressenLaden()
                End If
                _dvamtsgerichte = New DataView(_ds.Amtsgerichte)
                _dvamtsgerichte.Sort = "Ort"
            End If
            Return _dvamtsgerichte
        End Get
    End Property

    Private Shared _dvlandgerichte As DataView
    Public Shared ReadOnly Property DataViewLandgerichte As DataView
        Get
            If _dvlandgerichte Is Nothing Then
                If _ds Is Nothing Then
                    AdressenLaden()
                End If
                _dvlandgerichte = New DataView(_ds.Landgerichte)
                _dvlandgerichte.Sort = "Ort"
            End If
            Return _dvlandgerichte
        End Get
    End Property

    Private Shared _dvoberlandesgerichte As DataView
    Public Shared ReadOnly Property DataViewOberlandesgerichte As DataView
        Get
            If _dvoberlandesgerichte Is Nothing Then
                If _ds Is Nothing Then
                    AdressenLaden()
                End If
                _dvoberlandesgerichte = New DataView(_ds.Oberlandesgerichte)
                _dvoberlandesgerichte.Sort = "Ort"
            End If
            Return _dvoberlandesgerichte
        End Get
    End Property

    Private Shared _dvbundesgerichtshof As DataView
    Public Shared ReadOnly Property DataViewBundesgerichtshof As DataView
        Get
            If _dvbundesgerichtshof Is Nothing Then
                If _ds Is Nothing Then
                    'AdressenLaden()
                End If
                '_dvbundesgerichtshof = New DataView()
                '_dvbundesgerichtshof.Sort = "Ort"
            End If
            'Return _dvbundesgerichtshof
        End Get
    End Property

    Private Shared _dvbundesverfassungsgericht As DataView
    Public Shared ReadOnly Property DataViewBundesverfassungsgericht As DataView
        Get
            If _dvbundesverfassungsgericht Is Nothing Then
                If _ds Is Nothing Then
                    AdressenLaden()
                End If
                _dvbundesverfassungsgericht.Sort = "Ort"
            End If
            Return _dvbundesverfassungsgericht
        End Get
    End Property

    Private Shared _dvjustizvollzugsanstalten As DataView
    Public Shared ReadOnly Property DataViewJustizvollzugsanstalten As DataView
        Get
            If _dvjustizvollzugsanstalten Is Nothing Then
                If _ds Is Nothing Then
                    AdressenLaden()
                End If
                _dvjustizvollzugsanstalten = New DataView(_ds.Justizvollzugsanstalten)
                _dvjustizvollzugsanstalten.Sort = "Ort"
            End If
            Return _dvjustizvollzugsanstalten
        End Get
    End Property

    Public Sub New()
        AdressenLaden()
    End Sub

    Private Shared Sub AdressenLaden()
        _ds = New DataSetJustizadressen
        Try
            _ds.ReadXml(Path.Combine(_dsfile))

        Catch ex As Exception
            MessageBox.Show("Die Datenbank datei lässt sich nicht lesen! (UserControlDatabaseFRONTEND#001)", "Schwerwiegender Fehler!", MessageBoxButton.OKCancel, MessageBoxImage.Error)
        End Try
        Console.Write(_ds.ToString)
    End Sub

    Public Shared Function GetAdresseById(ByVal t As String, ByVal id As String) As DataRowView
        Select Case t
            Case "Staatsanwaltschaften"
                Return lopstaDatenbankJustizadressen.Justizadressen.DataViewStaatsanwaltschaften(lopstaDatenbankJustizadressen.Justizadressen.DataViewStaatsanwaltschaften.Find(id))
            Case "Amtsgerichte"
                Return lopstaDatenbankJustizadressen.Justizadressen.DataViewAmtsgerichte(lopstaDatenbankJustizadressen.Justizadressen.DataViewAmtsgerichte.Find(id))
            Case "Landgerichte"
                Return lopstaDatenbankJustizadressen.Justizadressen.DataViewLandgerichte(lopstaDatenbankJustizadressen.Justizadressen.DataViewLandgerichte.Find(id))
            Case "Oberlandesgerichte"
                Return lopstaDatenbankJustizadressen.Justizadressen.DataViewOberlandesgerichte(lopstaDatenbankJustizadressen.Justizadressen.DataViewOberlandesgerichte.Find(id))
            Case "Bundesgerichtshof"
                Return lopstaDatenbankJustizadressen.Justizadressen.DataViewBundesgerichtshof(lopstaDatenbankJustizadressen.Justizadressen.DataViewBundesgerichtshof.Find(id))
            Case "Bundesverfassungsgericht"
                Return lopstaDatenbankJustizadressen.Justizadressen.DataViewBundesverfassungsgericht(lopstaDatenbankJustizadressen.Justizadressen.DataViewBundesverfassungsgericht.Find(id))
            Case "Justizvollzugsanstalten"
                Return lopstaDatenbankJustizadressen.Justizadressen.DataViewJustizvollzugsanstalten(lopstaDatenbankJustizadressen.Justizadressen.DataViewJustizvollzugsanstalten.Find(id))
        End Select
        Return Nothing
    End Function

End Class

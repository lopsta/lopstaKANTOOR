Public Class UserControlAdresse

    Private _adresse As ClassAdresse
    Public Property Adresse As ClassAdresse
        Get
            Return _adresse
        End Get
        Set(value As ClassAdresse)
            _adresse = value
            GridFORMULAR.DataContext = _adresse
        End Set
    End Property

    Private _mandant As ClassMandant
    Public Property Mandant As ClassMandant
        Get
            Return _mandant
        End Get
        Set(value As ClassMandant)
            _mandant = value
            GridFORMULAR.DataContext = _mandant
        End Set
    End Property

End Class

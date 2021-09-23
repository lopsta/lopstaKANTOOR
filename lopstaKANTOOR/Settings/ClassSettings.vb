<Serializable>
Public Class ClassSettings

    ' ===============================================================================
    ' Benutzer
    ' ===============================================================================
    Public Property IsMultiUser As Boolean = True ' legt fest, ob mehrerer Benutzer
    Public Property LastUsedUser As String ' speichert den zuletzt ausgewählten Benutzer
    Public Property PfadBenutzer As String ' Pfad zu den Benutzer.xml-Dateien
    Public Property BenutzerUeberschreibtSettings As Boolean = True


    ' ===============================================================================
    ' Projekte
    ' ===============================================================================
    Public Property PfadProjekte As String
    Public Property FormatAktenzeichen As String = "yy-0000"


    ' ===============================================================================
    ' Rechnungen
    ' ===============================================================================
    Public Property PfadRechnungen As String


    ' ===============================================================================
    ' Textbausteine
    ' ===============================================================================
    Public Property PfadTextbausteine As String

    ' ===============================================================================
    ' Briefköpfe 
    ' ===============================================================================
    Public Property PfadBriefkoepfe As String

    ' ===============================================================================
    ' Word-Vorlagen
    ' ===============================================================================
    Public Property PfadVorlagenWord As String
    Public Property ExtensionWORD As String = "dot?"

    ' ===============================================================================
    ' Excel-Vorlagen
    ' ===============================================================================
    Public Property PfadVorlagenExcel As String

    ' ===============================================================================
    ' Andere-Vorlagen
    ' ===============================================================================
    Public Property PfadVorlagenAndere As String

    ' ===============================================================================
    ' Vollmachten-Vorlagen
    ' ===============================================================================
    Public Property PfadVorlagenVollmachten As String

    ' ===============================================================================
    ' Formulare-Vorlagen
    ' ===============================================================================
    Public Property PfadVorlagenFormulare As String

    ' ===============================================================================
    ' AutoSave
    ' ===============================================================================
    Public Property AutoSave As Boolean = True

End Class

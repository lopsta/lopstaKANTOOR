Public Class ClassAdresseMandantUebernehmen

    Public Shared Sub InListeTextfelderEinfuegen(ByRef d As Dictionary(Of String, String), a As lopstaControlAdressenVerzeichnis.ClassMandant)
        With d
            .Add("Mandant.Anrede", a.Anrede)
            .Add("Mandant.Nachname", a.Nachname)
            .Add("Mandant.Vorname", a.Vorname)
            .Add("Mandant.Titel", a.Titel)
            .Add("Mandant.Briefanrede", a.Briefanrede)
            .Add("Mandant.Strasse", a.Strasse)
            .Add("Mandant.Postleitzahl", a.Postleitzahl)
            .Add("Mandant.Ort", a.Ort)
            .Add("Mandant.Land", a.Land)
            .Add("Mandant.Zusatz", a.Zusatz)
            .Add("Mandant.Kontoinhaber", a.Kontoinhaber)
            .Add("Mandant.Bank", a.Bank)
            .Add("Mandant.IBAN", a.IBAN)
            .Add("Mandant.BIC", a.BIC)
        End With
    End Sub


End Class

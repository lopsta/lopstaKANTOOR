Public Class ClassHilfsfunktionen

    ' ===================================================================================
    ' HILFSMETHODEN
    ' ===================================================================================




    ' ==========================================================
    ' Generiert ein Datum in dem Format
    ' YYYY-MM-DD
    ' ==========================================================
    Public Shared Function nkDatum()
        Dim sb As New System.Text.StringBuilder
        With sb
            .Append(DateTime.Now.Year.ToString.PadLeft(4, "0"))
            .Append("-")
            .Append(DateTime.Now.Month.ToString.PadLeft(2, "0"))
            .Append("-")
            .Append(DateTime.Now.Day.ToString.PadLeft(2, "0"))
        End With
        Return sb.ToString
    End Function

End Class

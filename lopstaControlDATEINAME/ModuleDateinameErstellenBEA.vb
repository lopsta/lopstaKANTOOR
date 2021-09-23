Module ModuleDateinameErstellenBEA

    Public Function erstellen(ByRef uc As UserControlDateinameBEA) As String

        Dim separator = "_"
        Dim sb As New System.Text.StringBuilder

        If uc.TextBoxDateinameDATUM.Text IsNot String.Empty Then
            sb.Append(uc.TextBoxDateinameDATUM.Text)
        Else
            sb.Append("xxxx-xx-xx")
        End If

        If Not String.IsNullOrEmpty(uc.TextBoxDateinameORDNUNGSNUMMER.Text) Then
            If Not String.IsNullOrEmpty(sb.ToString) Then
                sb.Append(separator)
            End If
            sb.Append(uc.TextBoxDateinameORDNUNGSNUMMER.Text.PadLeft(3, "0"))
        End If

        If uc.ComboBoxDateinameBEZEICHNUNG.Text IsNot String.Empty Then
            If Not String.IsNullOrEmpty(sb.ToString) Then
                sb.Append(separator)
            End If
            With uc.ComboBoxDateinameBEZEICHNUNG
                If IsNothing(.SelectedValue) Then
                    sb.Append(.Text)
                Else
                    sb.Append(.SelectedValue)
                End If
            End With
            'sb.Append(ComboBoxDateinameBEZEICHNUNG.SelectedValue)
        Else
            sb.Append(separator)
            sb.Append("xxx")
        End If

        If uc.ComboBoxDateinameEMPFAENGER.Text IsNot String.Empty Then
            If Not String.IsNullOrEmpty(sb.ToString) Then
                sb.Append(separator)
            End If
            With uc.ComboBoxDateinameEMPFAENGER
                If IsNothing(.SelectedValue) Then
                    sb.Append(.Text)
                Else
                    sb.Append(.SelectedValue)
                End If
            End With
        Else
            sb.Append(separator)
            sb.Append("xxx")
        End If

        If uc.TextBoxDateinameBESCHREIBUNG.Text IsNot String.Empty Then
            If Not String.IsNullOrEmpty(sb.ToString) Then
                sb.Append(separator)
            End If
            sb.Append(uc.TextBoxDateinameBESCHREIBUNG.Text)
        End If

        Return sb.ToString
    End Function

End Module

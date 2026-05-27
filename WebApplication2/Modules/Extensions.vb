Imports System.Runtime.CompilerServices
Imports System.Reflection
Imports System.ComponentModel

Module Extensions

#Region "String Extensions"

    <Extension()>
    Public Function SQLPrep(ByVal str As String) As String
        If str Is Nothing Then
            str = ""
        End If
        Return "'" & str.Replace("'", "''").Trim & "'"
    End Function

#End Region
End Module
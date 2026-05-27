Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class ItemDefinitionSyncController
        Inherits ApiController

        ' GET: api/TableSync
        Public Function GetValues() As String
            Return ""
        End Function

        ' GET: api/TableSync/5
        Public Function GetValue(ByVal id As Integer) As String
            Return "value"
        End Function

        ' POST: api/TableSync
        Public Sub PostValue(<FromBody()> ByVal value As ItemDefinition)

            InsertRecord("testdump", "datadump", "'test'")
            If Not value Is Nothing Then
                InsertRecord("testdump", "datadump", value.IDSyncBlob.SQLPrep)
                value.SyncIDBlob(HttpContext.Current.Request.ServerVariables("REMOTE_ADDR"))
            End If

        End Sub

        ' PUT: api/TableSync/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/TableSync/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace
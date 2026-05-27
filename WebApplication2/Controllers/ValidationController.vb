Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class ValidationController
        Inherits ApiController

        ' GET: api/Validation
        Public Function GetValues() As String
            Return ""
        End Function

        ' GET: api/Validation/5
        Public Function GetValue(ByVal id As Integer) As Dictionary(Of String, Object)
            'this is used for getting a new key
            Dim dictData As New Dictionary(Of String, Object)

            Dim query As String = "select l.license, lip.customercode ,  l.expirationdate, l.onhold" &
                " from Licensing l " &
                " left join LicensingIPRanges lip on lip.customerCode = l.customerCode  
                and lip.deleted = 0  
                and dbo.IsIPAddressInRange(" & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").SQLPrep & ",lip.start_ip_address, lip.end_ip_address) = 1 " &
                " where l.deleted = 0 " &
                " and l.customerCode = " & id

            Dim ip As IPAddress
            If Not IPAddress.TryParse(HttpContext.Current.Request.ServerVariables("REMOTE_ADDR"), ip) Then
                dictData.Add("license", "")
                dictData.Add("expirationdate", "")
                dictData.Add("onhold", True)
                dictData.Add("error", "IP Address not valid")
                dictData.Add("errorcode", 1)

                Return dictData
            End If

            Using ldt As DataTable = SelectQuery(query)
                'nothing found or maybe IP not matching
                If ldt Is Nothing OrElse ldt.Rows.Count = 0 Then

                    dictData.Add("license", "")
                    dictData.Add("expirationdate", "")
                    dictData.Add("onhold", True)
                    dictData.Add("error", "No valid license found")
                    dictData.Add("errorcode", 2)

                    SendValidationErrorEmail(id, HttpContext.Current.Request.ServerVariables("REMOTE_ADDR"), validationEmail.noIP)
                ElseIf IsDBNull(ldt.Rows(0)("customercode")) Then
                    'customer code is fine but IP is not
                    dictData.Add("license", "")
                    dictData.Add("expirationdate", "")
                    dictData.Add("onhold", ldt.Rows(0)("onhold"))
                    dictData.Add("error", "IP validation failed")
                    dictData.Add("errorcode", 1)

                    SendValidationErrorEmail(id, HttpContext.Current.Request.ServerVariables("REMOTE_ADDR"), validationEmail.wrongIP)
                Else
                    'everything worked out!
                    dictData.Add("license", ldt.Rows(0)("license"))
                    dictData.Add("expirationdate", ldt.Rows(0)("expirationdate"))
                    dictData.Add("onhold", ldt.Rows(0)("onhold"))
                    dictData.Add("error", "")
                    dictData.Add("errorcode", 0)

                End If
            End Using

            Return dictData


        End Function

        ' POST: api/Validation
        Public Sub PostValue(<FromBody()> ByVal value As CompanySetup)
            'this is used for license checkins
            'properties from value come from API call. They MUST match same properties in companysetup
            'a good way to test is using Restlet Client - REST API Testing

            InsertRecord("LicensingValidationHistory", "customercode,ipaddress", value.CustomerCode & "," & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").SQLPrep)
            UpdateRecord("Licensing", "validationDate=getdate(),ipaddress=" & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").SQLPrep & ",productVersion=" & value.ProductVersion.SQLPrep, "customercode=" & value.CustomerCode)
        End Sub

        ' PUT: api/Validation/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Validation/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace
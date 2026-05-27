
Imports System.ComponentModel
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports Microsoft.AspNet.Identity

Module Functions

    Public Function ValidateRandomOFF(letter As String) As Boolean

        If InStr("INV0JX", letter) = 0 Then
            ValidateRandomOFF = False
            Exit Function
        End If

        ValidateRandomOFF = True
    End Function
    Public Function GetKeyExpireDate(txtLicense As String) As String
        Dim binaryMask As Integer

        Dim b5 As String = Mid(txtLicense, 23, 1)
        Dim b6 As String = Mid(txtLicense, 24, 1)
        Dim b7 As String = Mid(txtLicense, 25, 1)

        If Not ValidateRandomOFF(b7) Then
            If Not Val("&H" & b7) > 0 And Val("&H" & b7) < 16 Then
                Return ""
                Exit Function
            End If
            'Expiration Date
            binaryMask = Val("&H" & b7)
            'if OFF validate else
            If binaryMask >= 2 Then
                binaryMask = binaryMask - 2
                'chkboxExpires.Checked = True 'Expiration Date
            Else
                Return ""
            End If
        Else
            Return ""
        End If




        Dim expireYYY As String = Convert.ToInt32(Mid(txtLicense, 7, 3), 16)
        Dim expireDD As String = Mid(txtLicense, 10, 2) 'unecrypted
        Dim expireMM As String = MonthTranslate(Mid(txtLicense, 5, 2))

        GetKeyExpireDate = expireYYY & "-" & expireMM + "-" + expireDD

    End Function

    Private Function MonthTranslate(ByVal monthstr As String) As String

        monthstr = monthstr.Replace("~", "0")
        monthstr = monthstr.Replace("?", "1")
        monthstr = monthstr.Replace("!", "2")
        monthstr = monthstr.Replace("@", "3")
        monthstr = monthstr.Replace("#", "4")
        monthstr = monthstr.Replace("$", "5")
        monthstr = monthstr.Replace("%", "6")
        monthstr = monthstr.Replace("^", "7")
        monthstr = monthstr.Replace("&", "8")
        monthstr = monthstr.Replace("*", "9")

        Return monthstr
    End Function
    Public Function GetMd5Hash(ByVal input As String) As String
        input = "!nv0" & input & "t3ch"
        Dim data As Byte()
        Using md5Hash As MD5 = MD5.Create()
            ' Convert the input string to a byte array and compute the hash.
            data = md5Hash.ComputeHash(Encoding.Unicode.GetBytes(input))
        End Using

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return UCase(sBuilder.ToString())


    End Function 'GetMd5Hash
    Public Sub SendEmail(ByVal subjectStr As String, ByVal bodyStr As String, ByVal recipient As String, ByVal isHTML As Boolean)
        Dim Smtp_Server As New SmtpClient("SMTP.1AND1.COM")
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False

        Smtp_Server.Credentials = New NetworkCredential("test@invosupport.com", "Invotech9800")

        Smtp_Server.EnableSsl = True

        e_mail = New MailMessage()

        e_mail.IsBodyHtml = isHTML

        e_mail.From = New MailAddress("licensing@invosupport.com")


        'pending translation
        e_mail.Body = bodyStr
        e_mail.Body &= vbCrLf
        e_mail.Body &= vbCrLf

        ' e_mail.Body &= Session("UserNo")
        e_mail.Subject = subjectStr
        'e_mail.IsBodyHtml = False

        If recipient.Contains("@") Then
            e_mail.To.Add(recipient)
        Else
            e_mail.To.Add(ConfigurationManager.AppSettings(recipient))
        End If

        Smtp_Server.Send(e_mail)
    End Sub

    Public Sub EmailCustomerUpdate(ByVal customerStr As String, ByVal licenseStr As String, ByVal customerCode As Integer)

        Try


            Dim comp As New CompanySetup
            comp.UserLicense = licenseStr
            comp.CustomerCode = customerCode
            comp.CompanyName = customerStr
            comp.ParseLicense()
            Dim featureList As New List(Of String)

            Dim emailbody As String = "<style>td { border: 1px solid lightgrey;}</style><body style=""font-family:arial"">"

            emailbody &= "An InvoTech license has been updated. Please see the details below:<br><br>" & vbCrLf
            emailbody &= "<table style=""font-family:arial;border: 2px solid grey;border-radius: 5px;padding:2px;"" >"

            emailbody &= ReturnHTMLTableRow("Customer Name", customerStr)
            emailbody &= ReturnHTMLTableRow("Customer Code", customerCode)
            emailbody &= ReturnHTMLTableRow("License", licenseStr)

            With comp

                If .MultiProperty Then
                    emailbody &= ReturnHTMLTableRow("Multi-Site", comp.PropertyCount)
                End If

                If .Expires Then
                    emailbody &= ReturnHTMLTableRow("Expires", .ExpireDate)
                End If

                If .InventoryLimit Then
                    emailbody &= ReturnHTMLTableRow("Inventory Limit", .LimitCount)
                ElseIf .EmployeeAssignLimit Then
                    emailbody &= ReturnHTMLTableRow("Assign Limit", .LimitCount)
                ElseIf .LimitCount > 0 Then
                    emailbody &= ReturnHTMLTableRow("Employee Limit", .LimitCount)
                End If

                If .HandheldDownload Then
                    featureList.Add("Handheld")
                End If

                If .HumanResources Then
                    featureList.Add("Human Resources")
                End If

                If .RFID Then
                    featureList.Add("RFID Interface")
                End If

                If .Laundry Then
                    featureList.Add("Laundry Interface")
                End If

                If .Laundry2 Then
                    featureList.Add("Crown Laundry Interface")
                End If

                If .LaundryGIMS Then
                    featureList.Add("GIMS Laundry Interface")
                End If

                If .WhiteUPickIt Then
                    featureList.Add("White Conveyor U-Pick-It")
                End If

                If .Phoenix Then
                    featureList.Add("Phoenix Conveyor")
                End If

                If .SRSConveyor Then
                    featureList.Add("SRS Conveyor")
                End If

                If .WhiteConveyor Then
                    featureList.Add("White Conveyor")
                End If

                If .AutoValet Then
                    featureList.Add("Autovalet")
                End If

                If .HiemacInterface Then
                    featureList.Add("Hiemac Conveyor")
                End If

                If .SRSConveyorAUDS Then
                    featureList.Add("SRS Conveyors AUDS")
                End If

                If .Accounting Then
                    featureList.Add("Accounting")
                End If

                If .Purchasing Then
                    featureList.Add("MMS")
                End If

                If .Demo Then
                    featureList.Add("Demo")
                End If

                If .RestrictedItem Then
                    featureList.Add("Restricted Item Control")
                End If

                If .CoatCheck Then
                    featureList.Add("White Conveyors Coatcheck")
                End If

                If .WhiteScrubs Then
                    featureList.Add("White Conveyors One-for-One Scrubs")
                End If

                If .WhiteSortConveyor Then
                    featureList.Add("White Sorting Conveyor")
                End If

                If .MPCommonEmployees Then
                    featureList.Add("Multi-Property Common Employees")
                End If

                If .SelfIssueStation Then
                    featureList.Add("Self-Issue Automated Station")
                End If

                If .SelfIssuePortal Then
                    featureList.Add("Self-Issue Portal")
                End If

                If .EventUniforms Then
                    featureList.Add("Event Staff")
                End If


            End With


            If featureList.Count > 0 Then
                emailbody &= "<tr><td>Features/Interfaces</td><td>"
                featureList.Sort()

                For Each x In featureList
                    emailbody &= x & "<br>"
                Next

                emailbody &= "</td></tr>"
            End If

            emailbody &= "</table>"

            emailbody &= "<br><br>Updated by: " & HttpContext.Current.Session("userName")

            emailbody &= "<br><br>DO NOT REPLY TO THIS EMAIL"

            emailbody &= "</body>"

            SendEmail("License update - " & customerStr, emailbody, emailTypes.Licenses.Description.ToString, True)


        Catch ex As Exception

        End Try
    End Sub

    Private Function ReturnHTMLTableRow(ByVal leftcellStr As String, ByVal rightcellStr As String) As String
        Dim htmlStr As String = ""
        htmlStr = "<tr><td style=""font-weight:bold;text-align:right;vertical-align:top;"">"
        htmlStr &= leftcellStr
        htmlStr &= "</td><td>"
        htmlStr &= rightcellStr
        htmlStr &= "</td></tr>" & vbCrLf

        Return htmlStr
    End Function

    Public Sub SendValidationErrorEmail(ByVal customerCode As Integer, ByVal ipAddress As String, ByVal emailType As Integer)
        Try

            Dim body As String = ""
            Dim customer As String = ""
            Dim ipaddresses As String = ""
            Dim foundCustomer As Boolean = False

            body = "<style>td { border: 1px solid lightgrey;}</style><body style=""font-family:arial"">"
            body &= "A property has connected using an invalid IP address to validate licensing<br><br>"
            body &= "<table style=""font-family:arial;border: 2px solid grey;border-radius: 5px;padding:2px;"" >"


            Using licensesDT As DataTable = SelectQuery("select l.customer, l.customercode, lip.start_ip_address, lip.end_ip_address " &
                                                        " from Licensing l " &
                                                        " left join LicensingIPRanges lip on lip.customercode = l.customercode and l.deleted = 0 and lip.deleted = 0 " &
                                                        " where l.customercode= " & customerCode)
                If licensesDT.Rows.Count > 0 Then
                    foundCustomer = True

                    customer = licensesDT.Rows(0)("customer")

                    body &= ReturnHTMLTableRow("Customer", customer)

                End If

                body &= ReturnHTMLTableRow("Customer Code", customerCode)
                body &= ReturnHTMLTableRow("IP address", ipAddress)

                If emailType = validationEmail.wrongIP Then
                    For Each dr As DataRow In licensesDT.Rows
                        If Not IsDBNull(dr("start_ip_address")) Then
                            ipaddresses &= dr("start_ip_address") & " - " & dr("end_ip_address") & "<br>"
                        End If
                    Next
                    body &= ReturnHTMLTableRow("Valid IP addresses", ipaddresses)
                End If


            End Using

            body &= "</table>"

            Dim substr As String = "Validation Error: "
            If foundCustomer Then
                substr &= customer
            Else
                substr &= "UNKNOWN CUSTOMER"
            End If

            SendEmail(substr, body, emailTypes.Licenses.Description.ToString, True)

        Catch ex As Exception

        End Try

    End Sub
End Module

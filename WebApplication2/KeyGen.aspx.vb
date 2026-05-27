Public Class KeyGen
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer = 0

        If Not Me.Page.User.Identity.IsAuthenticated Or Session("userNo") Is Nothing Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Not Me.IsPostBack Then

            End If
        End If

        If TextBoxIP.Text <> "" Then
            TextBoxIP.Enabled = True
        End If

        If DropDownListEmpLimit.Items.Count = 0 Then
            Do While i <= 20000
                DropDownListEmpLimit.Items.Add(New ListItem(i.ToString(), i.ToString()))
                i += 100
            Loop

            i = 21000
            Do While i <= 125000
                DropDownListEmpLimit.Items.Add(New ListItem(i.ToString(), i.ToString()))
                i += 1000
            Loop
        End If


        i = 10000
        If DropDownListInvLimit.Items.Count = 0 Then
            Do While i <= 200000
                DropDownListInvLimit.Items.Add(New ListItem(i.ToString(), i.ToString()))
                i += 10000
            Loop

            DropDownListEmpLimit.Items.Add(New ListItem("Unlimited", "Unlimited"))
        End If

        i = 0
        Do While i <= 16
            combosledLimit.Items.Add(New ListItem(i.ToString(), i.ToString()))
            i += 1
        Loop


        DropDownListEmpLimit.Attributes.Add("style", "display:")
        DropDownListInvLimit.Attributes.Add("style", "display:none")

    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            GenerateNETLicense()
            LabelValidation.Text = ""
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnValidate_Click(sender As Object, e As EventArgs) Handles btnValidate.Click
        Try
            Dim cust As New CompanySetup
            txtLicense.Text = txtLicense.Text.Trim()
            cust.UserLicense = txtLicense.Text

            IsDisconnected.Checked = True

            If cust.ParseLicense Then
                LabelValidation.Text = "License is valid"
                LabelValidation.Visible = True
                With cust

                    If .DisconnectedMode Then
                        TextBoxIP.Text = .SQLIP
                        IsDisconnected.Checked = True
                        TextBoxIP.Enabled = True
                    Else
                        TextBoxIP.Text = ""
                        IsConnected.Checked = True
                        IsDisconnected.Checked = False
                    End If


                    chkboxHandheld.Checked = .HandheldDownload
                    chkboxHR.Checked = .HumanResources
                    chkboxRFID.Checked = .RFID
                    chkboxMulti.Checked = .MultiProperty
                    If cust.MultiProperty Then
                        txtMulti.Text = .PropertyCount
                    End If

                    chkboxLaundryInterface.Checked = .Laundry
                    chkboxCrown.Checked = .Laundry2
                    chkboxGIMSLaundry.Checked = .LaundryGIMS

                    If cust.Expires Then
                        chkboxExpires.Checked = True
                        txtExpire.Text = .ExpireDate.ToString("MM/dd/yyyy")
                    End If

                    chkboxWhiteUpick.Checked = .WhiteUPickIt
                    chkboxPhoenix.Checked = .Phoenix
                    chkboxSRS.Checked = .SRSConveyor
                    chkboxWhiteConveyor.Checked = .WhiteConveyor
                    chkboxAutoValet.Checked = .AutoValet
                    chkboxHiemac.Checked = .HiemacInterface
                    chkboxSRSConveyorAUDS.Checked = .SRSConveyorAUDS
                    chkboxEventUniforms.Checked = .EventUniforms
                    chkboxFornet.Checked = .FornetLaundry
                    chkboxACS.Checked = .ACS

                    chkboxAccounting.Checked = .Accounting
                    chkboxMMS.Checked = .Purchasing
                    chkboxDemo.Checked = .Demo
                    chkboxRestricted.Checked = .RestrictedItem
                    chkboxCoatcheck.Checked = .CoatCheck
                    chkboxOneforOneScrubs.Checked = .WhiteScrubs
                    chkboxWhiteBiometric.Checked = .WhiteBiometric
                    chkboxWhiteSortingConveyorsConveyor.Checked = .WhiteSortConveyor
                    chkboxMPCommonEmployees.Checked = .MPCommonEmployees


                    chkboxSelfIssueStation.Checked = .SelfIssueStation
                    chkboxSelfIssuePortal.Checked = .SelfIssuePortal
                    chkboxInventoryLimit.Checked = .InventoryLimit
                    chkboxEmployeeLimit.Checked = .EmployeeAssignLimit
                    chkboxITPasswords.Checked = .ITPassword
                    chkboxMetalProgretti.Checked = .MetalProgetti
                    chkboxLaundryExport.Checked = .LaundryExport
                    chkboxCruiseCrewsExport.Checked = .CruiseCrewsInactive
                    chkboxPolytex.Checked = .Polytex


                    If cust.Sleds > 0 Then
                        combosledLimit.Enabled = True
                        combosledLimit.Text = .Sleds
                    End If

                    If .InventoryLimit Then
                        If .LimitCount > 0 Then
                            DropDownListInvLimit.SelectedValue = .LimitCount
                        Else
                            DropDownListInvLimit.SelectedValue = 0
                        End If
                    Else
                        If .LimitCount > 0 Then
                            DropDownListEmpLimit.SelectedValue = .LimitCount
                        Else
                            DropDownListEmpLimit.SelectedValue = 0
                        End If
                    End If
                End With
            Else
                LabelValidation.Text = "License invalid"
                LabelValidation.Visible = True
            End If

            'If Not ValidateNETLicense() Then
            '    LabelValidation.Text = "License invalid"
            '    LabelValidation.Visible = True
            'Else
            '    LabelValidation.Text = "License is valid"
            '    LabelValidation.Visible = True
            'End If
        Catch ex As Exception

        End Try

    End Sub
    Private Function GenerateRandomHEX() As String
        Dim seed As Integer

        Randomize()
        seed = Int(15 * Rnd() + 1)

        GenerateRandomHEX = Hex(seed)

    End Function

    Private Sub GenerateNETLicense()
        Dim license As String
        Dim i As Integer
        Dim employeeQty2 As String
        Dim mac1, mac2, mac3, mac4, mac5, mac6, chkSum As String
        Dim checkSum As Integer
        Dim binaryMask As Integer
        Dim ipsegments As String()

        mac1 = GenerateRandomHEX() & GenerateRandomHEX()
        mac2 = GenerateRandomHEX() & GenerateRandomHEX()
        
        If IsDisconnected.Checked Then
            ipsegments = TextBoxIP.Text.Split(".")

            mac3 = Right("00" & Hex(Right("00" & ipsegments(0), 3)), 2)
            mac4 = Right("00" & Hex(Right("00" & ipsegments(1), 3)), 2)
            mac5 = Right("00" & Hex(Right("00" & ipsegments(2), 3)), 2)
            mac6 = Right("00" & Hex(Right("00" & ipsegments(3), 3)), 2)
        Else
            TextBoxIP.Text = ""
            mac3 = GenerateRandomHEX() & GenerateRandomHEX()
            mac4 = GenerateRandomHEX() & GenerateRandomHEX()
            mac5 = GenerateRandomHEX() & GenerateRandomHEX()
            mac6 = GenerateRandomHEX() & GenerateRandomHEX()
        End If


        license = mac1 & mac2

        'Expiration Date
        If chkboxExpires.Checked Then
            Dim year As String

            year = txtExpire.Text.Substring(6, 4)

            'Month is coded to two symbols
            For i = 1 To 2
                Select Case txtExpire.Text.Substring(-1 + i, 1)
                    Case "0"
                        license = license & "~"
                    Case "1"
                        license = license & "?"
                    Case "2"
                        license = license & "!"
                    Case "3"
                        license = license & "@"
                    Case "4"
                        license = license & "#"
                    Case "5"
                        license = license & "$"
                    Case "6"
                        license = license & "%"
                    Case "7"
                        license = license & "^"
                    Case "8"
                        license = license & "&"
                    Case "9"
                        license = license & "*"
                End Select
            Next

            'Year in HEX, day unencrypted
            license = license & Hex(Val(year))
            license = license & txtExpire.Text.Substring(3, 2)
        Else
            license = license & "UNIF0RM"
        End If

        employeeQty2 = "X"

        '# Employees / Inventory
        If chkboxInventoryLimit.Checked Then
            Select Case Val(DropDownListInvLimit.SelectedValue)
                Case Is <= 200000
                    license = license & "A"
                    employeeQty2 = Chr((Val(DropDownListInvLimit.Text) / 10000) + 64)
                Case Else
                    LabelValidation.Text = "Invalid Number of Inventory Items Entered."
                    LabelValidation.Visible = True
                    DropDownListInvLimit.Text = "10000"
                    Exit Sub
            End Select
            DropDownListInvLimit.Attributes.Add("style", "display:")
        Else
            DropDownListEmpLimit.Attributes.Add("style", "display:")
            If UCase$(DropDownListEmpLimit.Text) = "UNLIMITED" Then
                license = license & "C"
                employeeQty2 = "O"
            Else
                Select Case Val(DropDownListEmpLimit.Text)
                    Case Is <= 2600
                        license = license + "D"
                        employeeQty2 = Chr(Val(DropDownListEmpLimit.Text) / 100 + 64)
                    Case Is <= 5200
                        license = license + "E"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 2600) / 100 + 64)
                    Case Is <= 7800
                        license = license + "F"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 5200) / 100 + 64)
                    Case Is <= 10400
                        license = license + "G"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 7800) / 100 + 64)
                    Case Is <= 13000
                        license = license + "H"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 10400) / 100 + 64)
                    Case Is <= 15600
                        license = license + "I"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 13000) / 100 + 64)
                    Case Is <= 18200
                        license = license + "J"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 15600) / 100 + 64)
                    Case Is <= 20000
                        license = license + "M"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 18200) / 100 + 64)


                    Case Is <= 30000
                        license = license + "N"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 20000) / 1000 + 64)
                    Case Is <= 40000
                        license = license + "O"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 30000) / 1000 + 64)

                    Case Is <= 50000
                        license = license + "P"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 40000) / 1000 + 64)
                    Case Is <= 60000
                        license = license + "Q"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 50000) / 1000 + 64)
                    Case Is <= 70000
                        license = license + "R"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 60000) / 1000 + 64)
                    Case Is <= 80000
                        license = license + "S"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 70000) / 1000 + 64)
                    Case Is <= 90000
                        license = license + "T"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 80000) / 1000 + 64)
                    Case Is <= 100000
                        license = license + "U"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 90000) / 1000 + 64)
                    Case Is <= 110000
                        license = license + "V"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 100000) / 1000 + 64)
                    Case Is <= 120000
                        license = license + "W"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 110000) / 1000 + 64)
                    Case Is <= 130000
                        license = license + "X"
                        employeeQty2 = Chr((Val(DropDownListEmpLimit.Text) - 120000) / 1000 + 64)


                    Case Else
                        LabelValidation.Text = "Invalid Number of Users Entered."
                        LabelValidation.Visible = True
                        DropDownListEmpLimit.Text = "100"
                        Exit Sub
                End Select
            End If
        End If

        license = license & "-"

        'Interfaces / Features

        'Inventory Limiting(10) White Sorting Conveyor(24) Self-Issue Portal (25)
        'Binary mask method 16 options FFFF 4 Digits
        'Inventory Limiting(10)
        binaryMask = 0
        If chkboxInventoryLimit.Checked Then binaryMask += INVENTORY_LIMITING_MASK
        If chkboxMPCommonEmployees.Checked Then binaryMask += MULTIPROPERTY_COMMONEMPLOYEES_MASK
        If chkboxLaundryExport.Checked Then binaryMask += LAUNDRY_EXPORT_MASK


        '    If chkboxWhiteUpick.checked Then bin = bin + 2
        '    If chkboxWhiteUpick.checked Then bin = bin + 4
        '    If chkboxWhiteUpick.checked Then bin = bin + 8
        If binaryMask > 0 Then
            license = license & Hex(binaryMask)
        Else
            license = license & GenerateRandomOFF()
        End If
        'White Sorting Conveyor(24)
        binaryMask = 0
        If chkboxWhiteSortingConveyorsConveyor.Checked Then binaryMask = WHITESORTING_MASK
        If chkboxCruiseCrewsExport.Checked Then binaryMask += CRUISECREWS_INACTIVE_MASK
        If chkboxACS.Checked Then binaryMask += ACS_MASK

        If binaryMask > 0 Then
            license = license & Hex(binaryMask)
        Else
            license = license & GenerateRandomOFF()
        End If




        'Self-Issue Portal (25)
        binaryMask = 0
        'If OptionLicenseValidation(0).Value Then binaryMask = binaryMask + 2
        If IsDisconnected.Checked Then binaryMask += LICENSEVALIDATION_MASK
        If chkboxSelfIssuePortal.Checked Then binaryMask = binaryMask + SELFISSUEPORTAL_MASK

        If binaryMask > 0 Then
            license = license & Hex(binaryMask)
        Else
            license = license & GenerateRandomOFF()
        End If


        'Multiproperty Common Employees
        binaryMask = 0
        If chkboxMPCommonEmployees.Checked Then binaryMask = binaryMask + MULTIPROPERTY_COMMONEMPLOYEES_MASK

        If binaryMask > 0 Then
            license = license & Hex(binaryMask)
        Else
            license = license & GenerateRandomOFF()
        End If

        'Existing alphanumeric method 20 options ABCDE
        'A HR(5) Phoenix(16) Restricted Item Control (14) MMS (11) Demo(23)
        If chkboxPhoenix.Checked And chkboxHR.Checked And chkboxRestricted.Checked And chkboxMMS.Checked And chkboxDemo.Checked Then
            license = license + "O"
        ElseIf chkboxPhoenix.Checked And chkboxHR.Checked And chkboxRestricted.Checked And chkboxMMS.Checked Then
            license = license + "L"
        ElseIf chkboxHR.Checked And chkboxMMS.Checked And chkboxRestricted.Checked And chkboxDemo.Checked Then
            license = license + "U"
        ElseIf chkboxHR.Checked And chkboxMMS.Checked And chkboxPhoenix.Checked And chkboxDemo.Checked Then
            license = license + "Y"
        ElseIf chkboxMMS.Checked And chkboxRestricted.Checked And chkboxPhoenix.Checked And chkboxDemo.Checked Then
            license = license + "N"
        ElseIf chkboxHR.Checked And chkboxRestricted.Checked And chkboxPhoenix.Checked And chkboxDemo.Checked Then
            license = license + "2" 'A
        ElseIf chkboxHR.Checked And chkboxRestricted.Checked And chkboxPhoenix.Checked Then
            license = license + "A"
        ElseIf chkboxMMS.Checked And chkboxRestricted.Checked And chkboxPhoenix.Checked Then
            license = license + "M"
        ElseIf chkboxHR.Checked And chkboxMMS.Checked And chkboxRestricted.Checked Then
            license = license + "G" '"N"
        ElseIf chkboxHR.Checked And chkboxMMS.Checked And chkboxPhoenix.Checked Then
            license = license + "Q"
        ElseIf chkboxHR.Checked And chkboxMMS.Checked And chkboxDemo.Checked Then
            license = license + "X"
        ElseIf chkboxHR.Checked And chkboxRestricted.Checked And chkboxDemo.Checked Then
            license = license + "B"
        ElseIf chkboxHR.Checked And chkboxPhoenix.Checked And chkboxDemo.Checked Then
            license = license + "9" '3
        ElseIf chkboxMMS.Checked And chkboxRestricted.Checked And chkboxDemo.Checked Then
            license = license + "R"
        ElseIf chkboxMMS.Checked And chkboxPhoenix.Checked And chkboxDemo.Checked Then
            license = license + "Z"
        ElseIf chkboxRestricted.Checked And chkboxPhoenix.Checked And chkboxDemo.Checked Then
            license = license + "H"
        ElseIf chkboxRestricted.Checked And chkboxHR.Checked Then
            license = license + "F"
        ElseIf chkboxPhoenix.Checked And chkboxRestricted.Checked Then
            license = license + "5"
        ElseIf chkboxPhoenix.Checked And chkboxHR.Checked Then
            license = license + "D"
        ElseIf chkboxPhoenix.Checked And chkboxMMS.Checked Then
            license = license + "I" '"R"
        ElseIf chkboxRestricted.Checked And chkboxMMS.Checked Then
            license = license + "S"
        ElseIf chkboxHR.Checked And chkboxMMS.Checked Then
            license = license + "T"
        ElseIf chkboxHR.Checked And chkboxDemo.Checked Then
            license = license + "P"
        ElseIf chkboxMMS.Checked And chkboxDemo.Checked Then
            license = license + "8"
        ElseIf chkboxRestricted.Checked And chkboxDemo.Checked Then
            license = license + "K"
        ElseIf chkboxPhoenix.Checked And chkboxDemo.Checked Then
            license = license + "W"
        ElseIf chkboxPhoenix.Checked Then
            license = license + "7"
        ElseIf chkboxHR.Checked Then
            license = license + "3"
        ElseIf chkboxRestricted.Checked Then
            license = license + "C"
        ElseIf chkboxMMS.Checked Then
            license = license + "J" '"P"
        ElseIf chkboxDemo.Checked Then
            license = license + "E"
        Else
            license = license + "1"
        End If

        'B White Conveyor(0) Laundry(6) SRS Conveyor(1) Scrubs(19) EmployeeLimit(21)
        If chkboxWhiteConveyor.Checked And chkboxLaundryInterface.Checked And chkboxEmployeeLimit.Checked Then
            license = license + "9"
        ElseIf chkboxSRS.Checked And chkboxLaundryInterface.Checked And chkboxEmployeeLimit.Checked Then
            license = license + "M"
        ElseIf chkboxOneforOneScrubs.Checked And chkboxLaundryInterface.Checked And chkboxEmployeeLimit.Checked Then
            license = license + "Q"
        ElseIf chkboxWhiteConveyor.Checked And chkboxLaundryInterface.Checked Then
            license = license + "D"
        ElseIf chkboxSRS.Checked And chkboxLaundryInterface.Checked Then
            license = license + "7"
        ElseIf chkboxOneforOneScrubs.Checked And chkboxLaundryInterface.Checked Then
            license = license + "T"
        ElseIf chkboxWhiteConveyor.Checked And chkboxEmployeeLimit.Checked Then
            license = license + "G"
        ElseIf chkboxLaundryInterface.Checked And chkboxEmployeeLimit.Checked Then
            license = license + "2"
        ElseIf chkboxSRS.Checked And chkboxEmployeeLimit.Checked Then
            license = license + "J"
        ElseIf chkboxOneforOneScrubs.Checked And chkboxEmployeeLimit.Checked Then
            license = license + "V"
        ElseIf chkboxWhiteConveyor.Checked Then
            license = license + "C"
        ElseIf chkboxLaundryInterface.Checked Then
            license = license + "5"
        ElseIf chkboxSRS.Checked Then
            license = license + "6"
        ElseIf chkboxOneforOneScrubs.Checked Then
            license = license + "S"
        ElseIf chkboxEmployeeLimit.Checked Then
            license = license + "I"
        Else
            license = license + "4"
        End If

        'C Autovalet(2) Infinium(4) Multi-Site(15) Biometric(20) SelfIssue(22)
        If chkboxAutoValet.Checked And chkboxAccounting.Checked And chkboxMulti.Checked And chkboxWhiteBiometric.Checked And chkboxSelfIssueStation.Checked Then
            license = license + "A"
        ElseIf chkboxAutoValet.Checked And chkboxAccounting.Checked And chkboxMulti.Checked And chkboxWhiteBiometric.Checked Then
            license = license + "Z"
        ElseIf chkboxAutoValet.Checked And chkboxAccounting.Checked And chkboxMulti.Checked And chkboxSelfIssueStation.Checked Then
            license = license + "H"
        ElseIf chkboxAutoValet.Checked And chkboxAccounting.Checked And chkboxWhiteBiometric.Checked And chkboxSelfIssueStation.Checked Then
            license = license + "R"
        ElseIf chkboxAutoValet.Checked And chkboxMulti.Checked And chkboxWhiteBiometric.Checked And chkboxSelfIssueStation.Checked Then
            license = license + "T"
        ElseIf chkboxAccounting.Checked And chkboxMulti.Checked And chkboxWhiteBiometric.Checked And chkboxSelfIssueStation.Checked Then
            license = license + "K"
        ElseIf chkboxAutoValet.Checked And chkboxAccounting.Checked And chkboxMulti.Checked Then
            license = license + "D"
        ElseIf chkboxAutoValet.Checked And chkboxMulti.Checked And chkboxWhiteBiometric.Checked Then
            license = license + "Y"
        ElseIf chkboxMulti.Checked And chkboxAccounting.Checked And chkboxWhiteBiometric.Checked Then
            license = license + "X"
        ElseIf chkboxAutoValet.Checked And chkboxAccounting.Checked And chkboxWhiteBiometric.Checked Then
            license = license + "W"
        ElseIf chkboxSelfIssueStation.Checked And chkboxAutoValet.Checked And chkboxAccounting.Checked Then
            license = license + "F"
        ElseIf chkboxSelfIssueStation.Checked And chkboxAutoValet.Checked And chkboxMulti.Checked Then
            license = license + "I"
        ElseIf chkboxSelfIssueStation.Checked And chkboxAutoValet.Checked And chkboxWhiteBiometric.Checked Then
            license = license + "J"
        ElseIf chkboxSelfIssueStation.Checked And chkboxAccounting.Checked And chkboxMulti.Checked Then
            license = license + "6"
        ElseIf chkboxSelfIssueStation.Checked And chkboxAccounting.Checked And chkboxWhiteBiometric.Checked Then
            license = license + "9"
        ElseIf chkboxSelfIssueStation.Checked And chkboxMulti.Checked And chkboxWhiteBiometric.Checked Then
            license = license + "N"
        ElseIf chkboxAutoValet.Checked And chkboxMulti.Checked Then
            license = license + "E"
        ElseIf chkboxMulti.Checked And chkboxAccounting.Checked Then
            license = license + "8"
        ElseIf chkboxAutoValet.Checked And chkboxAccounting.Checked Then
            license = license + "5"
        ElseIf chkboxAutoValet.Checked And chkboxWhiteBiometric.Checked Then
            license = license + "Q"
        ElseIf chkboxAccounting.Checked And chkboxWhiteBiometric.Checked Then
            license = license + "M"
        ElseIf chkboxMulti.Checked And chkboxWhiteBiometric.Checked Then
            license = license + "L"
        ElseIf chkboxAutoValet.Checked And chkboxSelfIssueStation.Checked Then
            license = license + "7"
        ElseIf chkboxAccounting.Checked And chkboxSelfIssueStation.Checked Then
            license = license + "P"
        ElseIf chkboxMulti.Checked And chkboxSelfIssueStation.Checked Then
            license = license + "G"
        ElseIf chkboxWhiteBiometric.Checked And chkboxSelfIssueStation.Checked Then
            license = license + "3"
        ElseIf chkboxAutoValet.Checked Then
            license = license + "4"
        ElseIf chkboxAccounting.Checked Then
            license = license + "1"
        ElseIf chkboxMulti.Checked Then
            license = license + "2"
        ElseIf chkboxWhiteBiometric.Checked Then
            license = license + "B"
        ElseIf chkboxSelfIssueStation.Checked Then
            license = license + "S"
        Else
            license = license + "0"
        End If

        'D Datamars(7) UPickit(8) SRS Conveyors AUDS(18)
        If chkboxWhiteUpick.Checked And chkboxRFID.Checked Then
            license = license + "E"
        ElseIf chkboxSRSConveyorAUDS.Checked And chkboxRFID.Checked Then
            license = license + "W"
            'ElseIf chkboxMetalProgretti.Checked And chkboxRFID.Checked Then
            '    license = license + "Q"
        ElseIf chkboxWhiteUpick.Checked Then
            license = license + "A"
        ElseIf chkboxRFID.Checked Then
            license = license + "C"
        ElseIf chkboxSRSConveyorAUDS.Checked Then
            license = license + "S"
            'ElseIf chkboxMetalProgretti.Checked Then
            '    license = license + "M"
        Else
            license = license + "8"
        End If

        'E Handheld(9) Crown Laundry Int (13) GIMS Laundry (17)
        If chkboxHandheld.Checked And chkboxCrown.Checked Then
            license = license + "F"
        ElseIf chkboxHandheld.Checked And chkboxGIMSLaundry.Checked Then
            license = license + "Y"
        ElseIf chkboxHandheld.Checked Then
            license = license + "C"
        ElseIf chkboxCrown.Checked Then
            license = license + "3"
        ElseIf chkboxGIMSLaundry.Checked Then
            license = license + "Z"
        Else
            license = license + "7"
        End If

        'Heimac(12) Coatcheck Daybag(3) Expiration(26)
        'Binary mask method 12 options FFF 3 Digits
        'Heimac(12)
        binaryMask = 0
        If chkboxHiemac.Checked Then binaryMask = HIEMAC_MASK
        If chkboxPolytex.Checked Then binaryMask += POLYTEX_MASK
        If chkboxFornet.Checked Then binaryMask += FORNET_LAUNDRY_MASK

        If binaryMask > 0 Then
            license = license & Hex(binaryMask)
        Else
            license = license & GenerateRandomOFF()
        End If

        'Coatcheck Daybag(3)
        binaryMask = 0
        If chkboxCoatcheck.Checked Then binaryMask += COATCHECK_MASK
        If chkboxEventUniforms.Checked Then binaryMask += EVENTUNIFORMS_MASK
        If chkboxITPasswords.Checked Then binaryMask += ITPASSWORD_MASK

        If binaryMask > 0 Then
            license = license & Hex(binaryMask)
        Else
            license = license & GenerateRandomOFF()
        End If

        'Expiration(26)
        binaryMask = 0
        If chkboxExpires.Checked Then binaryMask = EXPIRATION_MASK
        If chkboxMetalProgretti.Checked Then binaryMask += METALPROGETTI_MASK
        If binaryMask > 0 Then
            license = license & Hex(binaryMask)
        Else
            license = license & GenerateRandomOFF()
        End If



        'Multiproperty
        license = license & "-"
        If chkboxMulti.Checked Then
            If Val(txtMulti.Text) < 11 Then
                binaryMask = 80 + Val(txtMulti.Text)
            ElseIf Val(txtMulti.Text) < 27 Then
                binaryMask = 91 - Val(txtMulti.Text)
            Else
                binaryMask = 165 + Val(txtMulti.Text)
            End If
            license = license + Chr(binaryMask)
        Else
            license = license & GenerateRandomOFF() ' HEX
        End If

        'Second part of # employee /inventory
        license = license & employeeQty2

        'Second part of IP or checksum
        license = license & mac3 & mac4

        'Checksum, last 2 digits of Hex sum of MAC address digits or randomly generated 6 2 byte numbers
        checkSum = Val("&H" & mac1) + Val("&H" & mac2) + Val("&H" & mac3) + Val("&H" & mac4) + Val("&H" & mac5) + Val("&H" & mac6)
        'checkSum = Val("&H" & ip1) + Val("&H" & ip2) + Val("&H" & ip3) + Val("&H" & ip4)
        chkSum = Hex(checkSum)

        If Len(chkSum) > 2 Then
            chkSum = Mid(chkSum, Len(chkSum) - 1, 2)
        ElseIf Len(chkSum) = 1 Then
            chkSum = "0" & chkSum
        End If

        license = license & chkSum & mac5 & mac6

        txtLicense.Text = license

        UpdateLabel()
    End Sub

    Private Function ParseNETInterfaces() As Boolean
        Dim invalid As Boolean
        Dim b1, b2, b3, b4 As String
        Dim a, b, c, d, e As String
        Dim b5, b6, b7 As String
        Dim binaryMask As Integer

        b1 = Mid(txtLicense.Text, 14, 1)
        b2 = Mid(txtLicense.Text, 15, 1)
        b3 = Mid(txtLicense.Text, 16, 1)
        b4 = Mid(txtLicense.Text, 17, 1)

        If Not ValidateRandomOFF(b1) Then
            If Not Val("&H" & b1) > 0 And Val("&H" & b1) < 16 Then
                ParseNETInterfaces = False
                Exit Function
            End If

            binaryMask = Val("&H" & b1)

            If binaryMask >= 8 Then
                binaryMask = binaryMask - 8
                'Check1(77).Value = true
            End If
            If binaryMask >= 4 Then
                binaryMask = binaryMask - 4
                'Check1(88).Value = true
            End If
            If binaryMask >= 2 Then
                binaryMask = binaryMask - 2
                'Check1(99).Value = true
            End If
            If binaryMask >= 1 Then
                chkboxInventoryLimit.Checked = True 'Inventory Assignment Limit
            End If
        End If

        If Not ValidateRandomOFF(b2) Then
            If Not Val("&H" & b2) > 0 And Val("&H" & b2) < 16 Then
                ParseNETInterfaces = False
                Exit Function
            End If
            'White Sorting Conveyor(24)
            binaryMask = Val("&H" & b2)
            'if OFF validate else
            If binaryMask >= 8 Then
                binaryMask = binaryMask - 8
                chkboxWhiteSortingConveyorsConveyor.Checked = True
            End If

            chkboxCruiseCrewsExport.Checked = (binaryMask And CRUISECREWS_INACTIVE_MASK)
        End If

        If Not ValidateRandomOFF(b3) Then
            If Not Val("&H" & b3) > 0 And Val("&H" & b3) < 16 Then
                ParseNETInterfaces = False
                Exit Function
            End If
            'Self-Issue Portal (25) Disc/Internet Validation Mode
            binaryMask = Val("&H" & b3)
            'if OFF validate else
            If binaryMask >= SELFISSUEPORTAL_MASK Then
                binaryMask = binaryMask - SELFISSUEPORTAL_MASK
                chkboxSelfIssuePortal.Checked = True
            End If

            If binaryMask >= LICENSEVALIDATION_MASK Then
                binaryMask -= LICENSEVALIDATION_MASK
            End If
        Else

        End If

        If Not ValidateRandomOFF(b4) Then
            If Not Val("&H" & b4) > 0 And Val("&H" & b4) < 16 Then
                ParseNETInterfaces = False
                Exit Function
            End If

            binaryMask = Val("&H" & b4)
            'if OFF validate else
            If binaryMask >= MULTIPROPERTY_COMMONEMPLOYEES_MASK Then
                binaryMask = binaryMask - MULTIPROPERTY_COMMONEMPLOYEES_MASK
                chkboxMPCommonEmployees.Checked = True
            End If

        End If

        a = Mid(txtLicense.Text, 18, 1)
        b = Mid(txtLicense.Text, 19, 1)
        c = Mid(txtLicense.Text, 20, 1)
        d = Mid(txtLicense.Text, 21, 1)
        e = Mid(txtLicense.Text, 22, 1)

        Select Case a
            Case "O"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxHR.Checked = True 'HR
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxMMS.Checked = True 'MMS
                chkboxDemo.Checked = True 'Demo
            Case "L"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxHR.Checked = True 'HR
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxMMS.Checked = True 'MMS
            Case "U"
                chkboxHR.Checked = True 'HR
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxMMS.Checked = True 'MMS
                chkboxDemo.Checked = True 'Demo
            Case "Y"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxHR.Checked = True 'HR
                chkboxMMS.Checked = True 'MMS
                chkboxDemo.Checked = True 'Demo
            Case "N"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxMMS.Checked = True 'MMS
                chkboxDemo.Checked = True 'Demo
            Case "2" 'A"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxHR.Checked = True 'HR
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxDemo.Checked = True 'Demo
            Case "A"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxHR.Checked = True 'HR
                chkboxRestricted.Checked = True 'Restricted Item
            Case "M"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxMMS.Checked = True 'MMS
            Case "G" '"N"
                chkboxHR.Checked = True 'HR
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxMMS.Checked = True 'MMS
            Case "Q"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxHR.Checked = True 'HR
                chkboxMMS.Checked = True 'MMS
            Case "X"
                chkboxHR.Checked = True 'HR
                chkboxMMS.Checked = True 'MMS
                chkboxDemo.Checked = True 'Demo
            Case "B"
                chkboxHR.Checked = True 'HR
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxDemo.Checked = True 'Demo
            Case "9" '3"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxHR.Checked = True 'HR
                chkboxDemo.Checked = True 'Demo
            Case "R"
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxMMS.Checked = True 'MMS
                chkboxDemo.Checked = True 'Demo
            Case "Z"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxMMS.Checked = True 'MMS
                chkboxDemo.Checked = True 'Demo
            Case "H"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxDemo.Checked = True 'Demo
            Case "F"
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxHR.Checked = True 'HR
            Case "5"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxRestricted.Checked = True 'Restricted Item
            Case "D"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxHR.Checked = True 'HR
            Case "I" '"R"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxMMS.Checked = True 'MMS
            Case "S"
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxMMS.Checked = True 'MMS
            Case "T"
                chkboxHR.Checked = True 'HR
                chkboxMMS.Checked = True 'MMS
            Case "P"
                chkboxHR.Checked = True 'HR
                chkboxDemo.Checked = True 'Demo
            Case "8"
                chkboxMMS.Checked = True 'MMS
                chkboxDemo.Checked = True 'Demo
            Case "K"
                chkboxRestricted.Checked = True 'Restricted Item
                chkboxDemo.Checked = True 'Demo
            Case "W"
                chkboxPhoenix.Checked = True 'Phoenix
                chkboxDemo.Checked = True 'Demo
            Case "C"
                chkboxRestricted.Checked = True 'Restricted Item
            Case "3"
                chkboxHR.Checked = True 'HR
            Case "7"
                chkboxPhoenix.Checked = True 'Phoenix
            Case "J" '"P"
                chkboxMMS.Checked = True 'MMS
            Case "E"
                chkboxDemo.Checked = True 'Demo
            Case "1"
            Case Else
                invalid = True
        End Select

        Select Case b
            Case "9"
                chkboxWhiteConveyor.Checked = True 'White
                chkboxLaundryInterface.Checked = True 'Laundry
                chkboxEmployeeLimit.Checked = True 'Employee Assignment Limit
            Case "M"
                chkboxSRS.Checked = True 'SRS
                chkboxLaundryInterface.Checked = True 'Laundry
                chkboxEmployeeLimit.Checked = True 'Employee Assignment Limit
            Case "Q"
                chkboxLaundryInterface.Checked = True 'Laundry
                chkboxOneforOneScrubs.Checked = True 'White One-for-One Scrubs
                chkboxEmployeeLimit.Checked = True 'Employee Assignment Limit
            Case "G"
                chkboxWhiteConveyor.Checked = True 'White
                chkboxEmployeeLimit.Checked = True 'Employee Assignment Limit
            Case "2"
                chkboxLaundryInterface.Checked = True 'Laundry
                chkboxEmployeeLimit.Checked = True 'Employee Assignment Limit
            Case "J"
                chkboxSRS.Checked = True 'SRS
                chkboxEmployeeLimit.Checked = True 'Employee Assignment Limit
            Case "V"
                chkboxOneforOneScrubs.Checked = True 'White One-for-One Scrubs
                chkboxEmployeeLimit.Checked = True 'Employee Assignment Limit
            Case "D"
                chkboxWhiteConveyor.Checked = True 'White
                chkboxLaundryInterface.Checked = True 'Laundry
            Case "7"
                chkboxSRS.Checked = True 'SRS
                chkboxLaundryInterface.Checked = True 'Laundry
            Case "T"
                chkboxLaundryInterface.Checked = True 'Laundry
                chkboxOneforOneScrubs.Checked = True 'White One-for-One Scrubs
            Case "C"
                chkboxWhiteConveyor.Checked = True 'White
            Case "5"
                chkboxLaundryInterface.Checked = True 'Laundry
            Case "6"
                chkboxSRS.Checked = True 'SRS
            Case "S"
                chkboxOneforOneScrubs.Checked = True 'White One-for-One Scrubs
            Case "I"
                chkboxEmployeeLimit.Checked = True 'Employee Assignment Limit
            Case "4"
            Case Else
                invalid = True
        End Select

        Select Case c
            Case "A"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxAccounting.Checked = True 'Infinium
                chkboxMulti.Checked = True 'Multi-Site
                chkboxWhiteBiometric.Checked = True 'Biometric
                chkboxSelfIssueStation.Checked = True 'Self-Issue Station
            'multiproperty_yesno = True
            Case "Z"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxAccounting.Checked = True 'Infinium
                chkboxMulti.Checked = True 'Multi-Site
                chkboxWhiteBiometric.Checked = True 'Biometric
            'multiproperty_yesno = True
            Case "H"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxAccounting.Checked = True 'Infinium
                chkboxMulti.Checked = True 'Multi-Site
                chkboxSelfIssueStation.Checked = True 'Self-Issue Station
            'multiproperty_yesno = True
            Case "R"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxAccounting.Checked = True 'Infinium
                chkboxSelfIssueStation.Checked = True 'Self-Issue Station
                chkboxWhiteBiometric.Checked = True 'Biometric
            Case "T"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxSelfIssueStation.Checked = True 'Self-Issue Station
                chkboxMulti.Checked = True 'Multi-Site
                chkboxWhiteBiometric.Checked = True 'Biometric
            'multiproperty_yesno = True
            Case "K"
                chkboxSelfIssueStation.Checked = True 'Self-Issue Station
                chkboxAccounting.Checked = True 'Infinium
                chkboxMulti.Checked = True 'Multi-Site
                chkboxWhiteBiometric.Checked = True 'Biometric
            'multiproperty_yesno = True
            Case "D"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxAccounting.Checked = True 'Infinium
                chkboxMulti.Checked = True 'Multi-Site
            'multiproperty_yesno = True
            Case "Y"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxMulti.Checked = True 'Multi-Site
                chkboxWhiteBiometric.Checked = True 'Biometric
            'multiproperty_yesno = True
            Case "X"
                chkboxAccounting.Checked = True 'Infinium
                chkboxMulti.Checked = True 'Multi-Site
                chkboxWhiteBiometric.Checked = True 'Biometric
            'multiproperty_yesno = True
            Case "W"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxAccounting.Checked = True 'Infinium
                chkboxWhiteBiometric.Checked = True 'Biometric
            Case "F"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxAccounting.Checked = True 'Infinium
                chkboxSelfIssueStation.Checked = True 'Self-Issue
            Case "I"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxMulti.Checked = True 'Multi-Site
                'multiproperty_yesno = True
                chkboxSelfIssueStation.Checked = True 'Self-Issue
            Case "J"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxWhiteBiometric.Checked = True 'Biometric
                chkboxSelfIssueStation.Checked = True 'Self-Issue
            Case "6"
                chkboxAccounting.Checked = True 'Infinium
                chkboxMulti.Checked = True 'Multi-Site
                'multiproperty_yesno = True
                chkboxSelfIssueStation.Checked = True 'Self-Issue
            Case "9"
                chkboxAccounting.Checked = True 'Infinium
                chkboxWhiteBiometric.Checked = True 'Biometric
                chkboxSelfIssueStation.Checked = True 'Self-Issue
            Case "N"
                chkboxMulti.Checked = True 'Multi-Site
                chkboxWhiteBiometric.Checked = True 'Biometric
                'multiproperty_yesno = True
                chkboxSelfIssueStation.Checked = True 'Self-Issue
            Case "E"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxMulti.Checked = True 'Multi-Site
             'multiproperty_yesno = True
            Case "8"
                chkboxAccounting.Checked = True 'Infinium
                chkboxMulti.Checked = True 'Multi-Site
            'multiproperty_yesno = True
            Case "5"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxAccounting.Checked = True 'Infinium
            Case "Q"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxWhiteBiometric.Checked = True 'Biometric
            Case "M"
                chkboxAccounting.Checked = True 'Infinium
                chkboxWhiteBiometric.Checked = True 'Biometric
            Case "L"
                chkboxMulti.Checked = True 'Multi-Site
                'multiproperty_yesno = True
                chkboxWhiteBiometric.Checked = True 'Biometric
            Case "7"
                chkboxAutoValet.Checked = True 'Autovalet
                chkboxSelfIssueStation.Checked = True 'Self-Issue
            Case "3"
                chkboxWhiteBiometric.Checked = True 'Biometric
                chkboxSelfIssueStation.Checked = True 'Self-Issue
            Case "P"
                chkboxAccounting.Checked = True 'Infinium
                chkboxSelfIssueStation.Checked = True 'Self-Issue
            Case "G"
                chkboxMulti.Checked = True 'Multi-Site
                'multiproperty_yesno = True
                chkboxSelfIssueStation.Checked = True 'Self-Issue
            Case "B"
                chkboxWhiteBiometric.Checked = True 'Biometric
            Case "4"
                chkboxAutoValet.Checked = True 'Autovalet
            Case "2"
                chkboxMulti.Checked = True 'Multi-Site
             'multiproperty_yesno = True
            Case "1"
                chkboxAccounting.Checked = True 'Infinium
            Case "S"
                chkboxSelfIssueStation.Checked = True 'Self-Issue
            Case "0"
            Case Else
                invalid = True
        End Select

        Select Case d
            Case "E"
                chkboxWhiteUpick.Checked = True 'U-Pick-It
                chkboxRFID.Checked = True 'RFID
            Case "W"
                chkboxSRSConveyorAUDS.Checked = True 'SRS Conveyors AUDS
                chkboxRFID.Checked = True 'RFID
            Case "C"
                chkboxRFID.Checked = True 'RFID
            Case "A"
                chkboxWhiteUpick.Checked = True 'U-Pick-It
            Case "S"
                chkboxSRSConveyorAUDS.Checked = True 'SRS Conveyors AUDS
            Case "8"
            Case Else
                invalid = True
        End Select

        Select Case e
            Case "F"
                chkboxHandheld.Checked = True 'Handheld
                chkboxCrown.Checked = True 'Crown Laundry
            Case "Y"
                chkboxHandheld.Checked = True 'Handheld
                chkboxGIMSLaundry.Checked = True 'GIMS-LE
            Case "C"
                chkboxHandheld.Checked = True 'Handheld
            Case "3"
                chkboxCrown.Checked = True 'Crown Laundry
            Case "Z"
                chkboxGIMSLaundry.Checked = True 'GIMS-LE
            Case "7"
            Case Else
                invalid = True
        End Select

        b5 = Mid(txtLicense.Text, 23, 1)
        b6 = Mid(txtLicense.Text, 24, 1)
        b7 = Mid(txtLicense.Text, 25, 1)

        If Not ValidateRandomOFF(b5) Then
            If Not Val("&H" & b5) > 0 And Val("&H" & b5) < 16 Then
                ParseNETInterfaces = False
                Exit Function
            End If
            'Hiemac
            binaryMask = Val("&H" & b5)
            'if OFF validate else
            If binaryMask >= HIEMAC_MASK Then
                binaryMask = binaryMask - HIEMAC_MASK
                chkboxHiemac.Checked = True 'Hiemac
            End If

            If binaryMask >= FORNET_LAUNDRY_MASK Then
                binaryMask -= FORNET_LAUNDRY_MASK
                chkboxFornet.Checked = True
            End If

            If binaryMask And ACS_MASK Then
                chkboxACS.Checked = True
            End If

        End If
        If Not ValidateRandomOFF(b6) Then
            If Not Val("&H" & b6) > 0 And Val("&H" & b6) < 16 Then
                ParseNETInterfaces = False
                Exit Function
            End If
            'White CoatCheck
            binaryMask = Val("&H" & b6)
            'if OFF validate else
            If binaryMask >= COATCHECK_MASK Then
                binaryMask = binaryMask - COATCHECK_MASK
                chkboxCoatcheck.Checked = True 'White CoatCheck
            End If

            If binaryMask >= EVENTUNIFORMS_MASK Then
                binaryMask = binaryMask - EVENTUNIFORMS_MASK
                chkboxEventUniforms.Checked = True
            End If

            If binaryMask >= ITPASSWORD_MASK Then
                binaryMask = binaryMask - ITPASSWORD_MASK
                chkboxITPasswords.Checked = True
            End If
        End If
        If Not ValidateRandomOFF(b7) Then
            If Not Val("&H" & b7) > 0 And Val("&H" & b7) < 16 Then
                ParseNETInterfaces = False
                Exit Function
            End If
            'Expiration Date
            binaryMask = Val("&H" & b7)
            'if OFF validate else
            If binaryMask >= EXPIRATION_MASK Then
                binaryMask = binaryMask - EXPIRATION_MASK
                chkboxExpires.Checked = True 'Expiration Date
            End If
        End If

        If invalid Then
            chkboxWhiteConveyor.Checked = False 'White
            chkboxSRS.Checked = False 'SRS
            chkboxAutoValet.Checked = False 'Autovalet
            chkboxCoatcheck.Checked = False 'Coatcheck
            chkboxAccounting.Checked = False 'Infinium
            chkboxHR.Checked = False 'HR
            chkboxLaundryInterface.Checked = False 'Laundry
            chkboxRFID.Checked = False 'RFID
            chkboxWhiteUpick.Checked = False 'U-Pick-It
            chkboxHandheld.Checked = False 'Handheld
            chkboxInventoryLimit.Checked = False 'Inventory Limit
            chkboxMMS.Checked = False 'MMS
            chkboxHiemac.Checked = False 'Hiemac
            chkboxCrown.Checked = False 'Crown Laundry
            chkboxRestricted.Checked = False
            chkboxMulti.Checked = False 'Multi-Site
            chkboxPhoenix.Checked = False 'Phoenix
            chkboxGIMSLaundry.Checked = False 'GIMS-LE
            chkboxSRSConveyorAUDS.Checked = False 'SRS Conveyors AUDS
            chkboxOneforOneScrubs.Checked = False
            chkboxWhiteBiometric.Checked = False
            chkboxEmployeeLimit.Checked = False 'Employee Assignment
            chkboxSelfIssueStation.Checked = False
            chkboxDemo.Checked = False
            chkboxWhiteSortingConveyorsConveyor.Checked = False
            chkboxSelfIssuePortal.Checked = False
            chkboxExpires.Checked = False 'Expiration
            ParseNETInterfaces = False
            chkboxMetalProgretti.Checked = False
            chkboxCruiseCrewsExport.Checked = False
            chkboxPolytex.Checked = False
            Exit Function
        End If

        If chkboxInventoryLimit.Checked Then DropDownListInvLimit.Attributes.Add("style", "display:")
        If chkboxEmployeeLimit.Checked Then DropDownListEmpLimit.Attributes.Add("style", "display:")

        UpdateLabel()

        ParseNETInterfaces = True
    End Function

    Private Function GenerateRandomOFF() As String
        Dim seed As Integer

        Randomize()
        seed = Int(6 * Rnd() + 1) '4

        Select Case seed
            Case 1
                GenerateRandomOFF = "0"
            Case 2
                GenerateRandomOFF = "X"
            Case 3
                GenerateRandomOFF = "J"
            Case 4
                GenerateRandomOFF = "V"
            Case 5
                GenerateRandomOFF = "N"
            Case 6
                GenerateRandomOFF = "I"
        End Select
    End Function

    Private Sub UpdateLabel()
        If chkboxEmployeeLimit.Checked Then
            lblLimit.InnerText = "Employee limit: "
            DropDownListInvLimit.Attributes.Add("style", "display:none")
        End If

        If chkboxInventoryLimit.Checked Then
            lblLimit.InnerText = "Inventory limit: "
            DropDownListEmpLimit.Attributes.Add("style", "display:none")
        End If

    End Sub

End Class
Imports System.ComponentModel

Public Class CompanySetup

#Region "Properties"
    Private mySleds As Integer
    Public Property Sleds As Integer
        Get
            Return mySleds
        End Get
        Set(value As Integer)
            mySleds = value
        End Set
    End Property

    Private myProductVersion As String
    Public Property ProductVersion() As String
        Get
            Return myProductVersion
        End Get
        Set(value As String)
            myProductVersion = value
        End Set
    End Property

    Private myCustomerCode As Integer
    Public Property CustomerCode() As Integer
        Get
            Return myCustomerCode
        End Get
        Set(ByVal value As Integer)
            myCustomerCode = value
        End Set
    End Property


    Private myCompanyName As String
    Public Property CompanyName() As String
        Get
            Return myCompanyName
        End Get
        Set(ByVal value As String)
            myCompanyName = value

        End Set
    End Property

    Private myPropertyCount As Integer
    Public Property PropertyCount As Integer
        Get
            Return myPropertyCount
        End Get
        Set(value As Integer)
            myPropertyCount = value
        End Set
    End Property
    Private mySQLIP As String
    <Description("SQL IP")> Public Property SQLIP() As String
        Get
            Return mySQLIP
        End Get
        Set(ByVal value As String)
            mySQLIP = value
        End Set
    End Property



    Private myUserLicense As String

    <Description("User License")> Public Property UserLicense() As String
        Get
            Return myUserLicense
        End Get
        Set(ByVal value As String)
            myUserLicense = value
        End Set
    End Property

    Private myDisconnectedMode As Boolean
    <Description("Disconnected Mode")> Public Property DisconnectedMode() As Boolean
        Get
            Return myDisconnectedMode
        End Get
        Set(ByVal value As Boolean)
            myDisconnectedMode = value
        End Set
    End Property

    Private myACS As Boolean
    <Description("ACS")> Public Property ACS() As Boolean
        Get
            Return myACS
        End Get
        Set(ByVal value As Boolean)
            myACS = value
        End Set
    End Property


    Private myAutoValet As Boolean
    <Description("Auto Valet")> Public Property AutoValet() As Boolean
        Get
            Return myAutoValet
        End Get
        Set(ByVal value As Boolean)
            myAutoValet = value
        End Set
    End Property

    Private myFornetLaundry As Boolean
    Public Property FornetLaundry As Boolean
        Get
            Return myFornetLaundry
        End Get
        Set(value As Boolean)
            myFornetLaundry = value
        End Set
    End Property


    Private myHiemacInterface As Boolean
    Public Property HiemacInterface() As Boolean
        Get
            Return myHiemacInterface
        End Get
        Set(ByVal value As Boolean)
            myHiemacInterface = value

        End Set
    End Property


    Private myLaundryGIMS As Boolean
    Public Property LaundryGIMS() As Boolean
        Get
            Return myLaundryGIMS
        End Get
        Set(ByVal value As Boolean)
            myLaundryGIMS = value
        End Set
    End Property

    Private myPurchasing As Boolean
    Public Property Purchasing() As Boolean
        Get
            Return myPurchasing
        End Get
        Set(ByVal value As Boolean)
            myPurchasing = value
        End Set
    End Property

    Private myRestrictedItem As Boolean
    Public Property RestrictedItem() As Boolean
        Get
            Return myRestrictedItem
        End Get
        Set(ByVal value As Boolean)
            myRestrictedItem = value
        End Set
    End Property


    Private myLaundry As Boolean
    Public Property Laundry() As Boolean
        Get
            Return myLaundry
        End Get
        Set(ByVal value As Boolean)
            myLaundry = value
        End Set
    End Property

    Private myLaundry2 As Boolean
    Public Property Laundry2() As Boolean
        Get
            Return myLaundry2
        End Get
        Set(ByVal value As Boolean)
            myLaundry2 = value
        End Set
    End Property

    Private myMetalProgetti
    <Description("Metal Progetti")> Public Property MetalProgetti() As Boolean
        Get
            Return myMetalProgetti
        End Get
        Set(ByVal value As Boolean)
            myMetalProgetti = value
        End Set
    End Property

    Private myRFID As Boolean
    <Description("RFID")> Public Property RFID() As Boolean
        Get
            Return myRFID
        End Get
        Set(ByVal value As Boolean)
            myRFID = value
        End Set
    End Property



    Private myMultiProperty As Boolean
    <Description("Multi Property")> Public Property MultiProperty() As Boolean
        Get
            Return myMultiProperty
        End Get
        Set(ByVal value As Boolean)
            myMultiProperty = value
        End Set
    End Property

    Private myWhiteScrubs As Boolean
    <Description("White Scrubs")> Public Property WhiteScrubs() As Boolean
        Get
            Return myWhiteScrubs
        End Get
        Set(ByVal value As Boolean)
            myWhiteScrubs = value
        End Set
    End Property
    Private myWhiteSort As Boolean
    <Description("White Sort")> Public Property WhiteSort() As Boolean
        Get
            Return myWhiteSort
        End Get
        Set(ByVal value As Boolean)
            myWhiteSort = value
        End Set
    End Property

    Private myWhiteConveyor As Boolean
    Public Property WhiteConveyor() As Boolean
        Get
            Return myWhiteConveyor
        End Get
        Set(ByVal value As Boolean)
            myWhiteConveyor = value
        End Set
    End Property

    Private myWhiteSortConveyor As Boolean
    Public Property WhiteSortConveyor() As Boolean
        Get
            Return myWhiteSortConveyor
        End Get
        Set(ByVal value As Boolean)
            myWhiteSortConveyor = value
        End Set
    End Property

    Private myWhiteUPickIt As Boolean
    <Description("White UPickIt")> Public Property WhiteUPickIt() As Boolean
        Get
            Return myWhiteUPickIt
        End Get
        Set(ByVal value As Boolean)
            myWhiteUPickIt = value
        End Set
    End Property

    Private myCompanyBranding As Boolean
    <Description("Company Logo Branding")> Public Property CompanyBranding() As Boolean
        Get
            Return myCompanyBranding
        End Get
        Set(ByVal value As Boolean)
            myCompanyBranding = value
        End Set
    End Property

    Private myPhoenix As Boolean
    Public Property Phoenix() As Boolean
        Get
            Return myPhoenix
        End Get
        Set(ByVal value As Boolean)
            myPhoenix = value
        End Set
    End Property



    Private myCoatCheck As Boolean
    Public Property CoatCheck() As Boolean
        Get
            Return myCoatCheck
        End Get
        Set(ByVal value As Boolean)
            myCoatCheck = value
        End Set
    End Property
    Private myEventUniforms As Boolean 'license feature
    Public Property EventUniforms() As Boolean
        Get
            Return myEventUniforms
        End Get
        Set(ByVal value As Boolean)
            myEventUniforms = value
        End Set
    End Property

    Private myITPassword As Boolean
    Public Property ITPassword() As Boolean
        Get
            Return myITPassword
        End Get
        Set(ByVal value As Boolean)
            myITPassword = value
        End Set
    End Property

    Private myHandheldDownload As Boolean
    Public Property HandheldDownload() As Boolean
        Get
            Return myHandheldDownload
        End Get
        Set(ByVal value As Boolean)
            myHandheldDownload = value
        End Set
    End Property

    Private myHumanResources As Boolean
    Public Property HumanResources() As Boolean
        Get
            Return myHumanResources
        End Get
        Set(ByVal value As Boolean)
            myHumanResources = value
        End Set
    End Property

    Private mySRSConveyor As Boolean
    Public Property SRSConveyor() As Boolean
        Get
            Return mySRSConveyor
        End Get
        Set(ByVal value As Boolean)
            mySRSConveyor = value
        End Set
    End Property

    Private mySRSConveyorAUDS As Boolean
    Public Property SRSConveyorAUDS() As Boolean
        Get
            Return mySRSConveyorAUDS
        End Get
        Set(ByVal value As Boolean)
            mySRSConveyorAUDS = value
        End Set
    End Property

    Private myEmployeeAssignLimit As Boolean
    Public Property EmployeeAssignLimit() As Boolean
        Get
            Return myEmployeeAssignLimit
        End Get
        Set(ByVal value As Boolean)
            myEmployeeAssignLimit = value
        End Set
    End Property

    Private myLimitCount As Integer
    Public Property LimitCount As Integer
        Get
            Return myLimitCount
        End Get
        Set(value As Integer)
            myLimitCount = value
        End Set
    End Property

    Private myInventoryLimit As Boolean
    Public Property InventoryLimit() As Boolean
        Get
            Return myInventoryLimit
        End Get
        Set(ByVal value As Boolean)
            myInventoryLimit = value
        End Set
    End Property

    Private myWhiteBiometric As Boolean
    Public Property WhiteBiometric() As Boolean
        Get
            Return myWhiteBiometric
        End Get
        Set(ByVal value As Boolean)
            myWhiteBiometric = value
        End Set
    End Property
    Private myselfissuestation As Boolean
    Public Property SelfIssueStation() As Boolean
        Get
            Return myselfissuestation
        End Get
        Set(ByVal value As Boolean)
            myselfissuestation = value
        End Set
    End Property

    Private mySelfIssuePortal As Boolean
    Public Property SelfIssuePortal() As Boolean
        Get
            Return mySelfIssuePortal
        End Get
        Set(ByVal value As Boolean)
            mySelfIssuePortal = value
        End Set
    End Property

    Private mydemo As Boolean
    Public Property Demo() As Boolean
        Get
            Return mydemo
        End Get
        Set(ByVal value As Boolean)
            mydemo = value
        End Set
    End Property


    Private myExpireDate As Date

    Public Property ExpireDate() As Date
        Get
            Return myExpireDate
        End Get
        Set(ByVal value As Date)
            myExpireDate = value
        End Set
    End Property

    Public ReadOnly Property Expires() As Boolean
        Get
            Return Not Mid(UserLicense, 5, 7).Contains("UNIF0RM")
        End Get
    End Property

    Private myMPCommonEmployees As Boolean
    Public Property MPCommonEmployees() As Boolean
        Get
            Return myMPCommonEmployees
        End Get
        Set(ByVal value As Boolean)
            myMPCommonEmployees = value
        End Set
    End Property

    Private myLaundryExport As Boolean
    Public Property LaundryExport As Boolean
        Get
            Return myLaundryExport
        End Get
        Set(value As Boolean)
            myLaundryExport = value
        End Set
    End Property

    Private myIsBrandedLogo As Boolean
    Public Property IsBrandedLogo() As Boolean
        Get
            Return myIsBrandedLogo
        End Get
        Set(ByVal value As Boolean)
            myIsBrandedLogo = value
        End Set
    End Property


    Private myAccounting As Boolean

    Public Sub New()

    End Sub

    Public Property Accounting() As Boolean
        Get
            Return myAccounting
        End Get
        Set(ByVal value As Boolean)
            myAccounting = value
        End Set
    End Property

    Private myCruiseCrewsInactive As Boolean
    Public Property CruiseCrewsInactive
        Get
            Return myCruiseCrewsInactive
        End Get
        Set(value)
            myCruiseCrewsInactive = value
        End Set
    End Property

    Private myPolytex As Boolean
    Public Property Polytex As Boolean
        Get
            Return myPolytex
        End Get
        Set(value As Boolean)
            myPolytex = True
        End Set
    End Property
#End Region

#Region "Methods"

    Public Function ParseLicense() As Boolean
        Try

            Dim ip1, ip2, ip3, ip4, ip5, ip6 As Integer
            Dim checkSum, bin As Integer
            Dim chkSum As String
            Dim i As Integer


            If Len(Trim$(UserLicense)) <> 38 Then
                ParseLicense = False
                Exit Function
            End If

            'sql IP
            SQLIP = Val("&H" & Mid(UserLicense, 29, 2)) & "." & Val("&H" & Mid(UserLicense, 31, 2)) & "." & Val("&H" & Mid(UserLicense, 35, 2)) & "." & Val("&H" & Mid(UserLicense, 37, 2))


            'Checksum
            ip1 = Val("&H" & Mid(Trim$(UserLicense), 1, 2))
            ip2 = Val("&H" & Mid(Trim$(UserLicense), 3, 2))
            ip3 = Val("&H" & Mid(Trim$(UserLicense), 29, 2))
            ip4 = Val("&H" & Mid(Trim$(UserLicense), 31, 2))
            ip5 = Val("&H" & Mid(Trim$(UserLicense), 35, 2))
            ip6 = Val("&H" & Mid(Trim$(UserLicense), 37, 2))

            checkSum = ip1 + ip2 + ip3 + ip4 + ip5 + ip6
            'checkSum = mac1 + mac2 + mac3 + mac4 + mac5 + mac6
            chkSum = Hex(checkSum)
            If Len(chkSum) > 2 Then chkSum = Mid(chkSum, Len(chkSum) - 1, 2)

            If Val("&H" & Mid(Trim$(UserLicense), 33, 2)) <> Val("&H" & chkSum) Then
                ParseLicense = False
                Exit Function
            End If

            'parse interfaces
            Dim invalid As Boolean
            Dim b1, b2, b3, b4 As String
            Dim a, b, c, d, e As String
            Dim b5, b6, b7 As String
            Dim binaryMask As Integer

            b1 = Mid(UserLicense, 14, 1)
            b2 = Mid(UserLicense, 15, 1)
            b3 = Mid(UserLicense, 16, 1)
            b4 = Mid(UserLicense, 17, 1)
            'group 1
            If Not ValidateRandomOFF(b1) Then
                If Not Val("&H" & b1) > 0 And Val("&H" & b1) < 16 Then
                    ParseLicense = False
                    Exit Function

                End If

                binaryMask = Val("&H" & b1)

                If binaryMask >= 8 Then
                    binaryMask = binaryMask - 8
                    'Check1(77).Value = true
                End If
                If binaryMask And LAUNDRY_EXPORT_MASK Then
                    LaundryExport = True
                    'Check1(88).Value = true
                End If

                If binaryMask And INVENTORY_LIMITING_MASK Then
                    InventoryLimit = True 'Inventory Assignment Limit
                End If

                If binaryMask And MULTIPROPERTY_COMMONEMPLOYEES_MASK Then
                    MPCommonEmployees = True
                End If
            End If
            'group 2
            If Not ValidateRandomOFF(b2) Then
                If Not Val("&H" & b2) > 0 And Val("&H" & b2) < 16 Then
                    ParseLicense = False
                    Exit Function

                End If
                'White Sorting Conveyor(24)
                binaryMask = Val("&H" & b2)
                'if OFF validate else
                If binaryMask And WHITESORTING_MASK Then
                    binaryMask = binaryMask - WHITESORTING_MASK
                    WhiteSortConveyor = True
                End If

                If binaryMask And CRUISECREWS_INACTIVE_MASK Then
                    CruiseCrewsInactive = True
                End If

                If binaryMask And ACS_MASK Then
                    ACS = True
                End If



            End If
            'group 3
            If Not ValidateRandomOFF(b3) Then
                If Not Val("&H" & b3) > 0 And Val("&H" & b3) < 16 Then
                    ParseLicense = False
                    Exit Function

                End If
                'Self-Issue Portal (25) Disc/Internet Validation Mode
                binaryMask = Val("&H" & b3)
                'if OFF validate else
                If binaryMask >= SELFISSUEPORTAL_MASK Then
                    binaryMask = binaryMask - SELFISSUEPORTAL_MASK
                    SelfIssuePortal = True
                End If

                'disconnected mode...
                If binaryMask >= LICENSEVALIDATION_MASK Then
                    binaryMask -= LICENSEVALIDATION_MASK
                    DisconnectedMode = True
                End If
            Else

            End If



            a = Mid(UserLicense, 18, 1)
            b = Mid(UserLicense, 19, 1)
            c = Mid(UserLicense, 20, 1)
            d = Mid(UserLicense, 21, 1)
            e = Mid(UserLicense, 22, 1)

            Select Case a
                Case "O"
                    Phoenix = True 'Phoenix
                    HumanResources = True 'HR
                    RestrictedItem = True 'Restricted Item
                    Purchasing = True 'MMS
                    Demo = True 'Demo
                Case "L"
                    Phoenix = True 'Phoenix
                    HumanResources = True 'HR
                    RestrictedItem = True 'Restricted Item
                    Purchasing = True 'MMS
                Case "U"
                    HumanResources = True 'HR
                    RestrictedItem = True 'Restricted Item
                    Purchasing = True 'MMS
                    Demo = True 'Demo
                Case "Y"
                    Phoenix = True 'Phoenix
                    HumanResources = True 'HR
                    Purchasing = True 'MMS
                    Demo = True 'Demo
                Case "N"
                    Phoenix = True 'Phoenix
                    RestrictedItem = True 'Restricted Item
                    Purchasing = True 'MMS
                    Demo = True 'Demo
                Case "2" 'A"
                    Phoenix = True 'Phoenix
                    HumanResources = True 'HR
                    RestrictedItem = True 'Restricted Item
                    Demo = True 'Demo
                Case "A"
                    Phoenix = True 'Phoenix
                    HumanResources = True 'HR
                    RestrictedItem = True 'Restricted Item
                Case "M"
                    Phoenix = True 'Phoenix
                    RestrictedItem = True 'Restricted Item
                    Purchasing = True 'MMS
                Case "G" '"N"
                    HumanResources = True 'HR
                    RestrictedItem = True 'Restricted Item
                    Purchasing = True 'MMS
                Case "Q"
                    Phoenix = True 'Phoenix
                    HumanResources = True 'HR
                    Purchasing = True 'MMS
                Case "X"
                    HumanResources = True 'HR
                    Purchasing = True 'MMS
                    Demo = True 'Demo
                Case "B"
                    HumanResources = True 'HR
                    RestrictedItem = True 'Restricted Item
                    Demo = True 'Demo
                Case "9" '3"
                    Phoenix = True 'Phoenix
                    HumanResources = True 'HR
                    Demo = True 'Demo
                Case "R"
                    RestrictedItem = True 'Restricted Item
                    Purchasing = True 'MMS
                    Demo = True 'Demo
                Case "Z"
                    Phoenix = True 'Phoenix
                    Purchasing = True 'MMS
                    Demo = True 'Demo
                Case "H"
                    Phoenix = True 'Phoenix
                    RestrictedItem = True 'Restricted Item
                    Demo = True 'Demo
                Case "F"
                    RestrictedItem = True 'Restricted Item
                    HumanResources = True 'HR
                Case "5"
                    Phoenix = True 'Phoenix
                    RestrictedItem = True 'Restricted Item
                Case "D"
                    Phoenix = True 'Phoenix
                    HumanResources = True 'HR
                Case "I" '"R"
                    Phoenix = True 'Phoenix
                    Purchasing = True 'MMS
                Case "S"
                    RestrictedItem = True 'Restricted Item
                    Purchasing = True 'MMS
                Case "T"
                    HumanResources = True 'HR
                    Purchasing = True 'MMS
                Case "P"
                    HumanResources = True 'HR
                    Demo = True 'Demo
                Case "8"
                    Purchasing = True 'MMS
                    Demo = True 'Demo
                Case "K"
                    RestrictedItem = True 'Restricted Item
                    Demo = True 'Demo
                Case "W"
                    Phoenix = True 'Phoenix
                    Demo = True 'Demo
                Case "C"
                    RestrictedItem = True 'Restricted Item
                Case "3"
                    HumanResources = True 'HR
                Case "7"
                    Phoenix = True 'Phoenix
                Case "J" '"P"
                    Purchasing = True 'MMS
                Case "E"
                    Demo = True 'Demo
                Case "1"
                Case Else
                    invalid = True
            End Select

            Select Case b
                Case "9"
                    WhiteConveyor = True 'White
                    Laundry = True 'Laundry
                    EmployeeAssignLimit = True 'Employee Assignment Limit
                Case "M"
                    SRSConveyor = True 'SRS
                    Laundry = True 'Laundry
                    EmployeeAssignLimit = True 'Employee Assignment Limit
                Case "Q"
                    Laundry = True 'Laundry
                    WhiteScrubs = True 'White One-for-One Scrubs
                    EmployeeAssignLimit = True 'Employee Assignment Limit
                Case "G"
                    WhiteConveyor = True 'White
                    EmployeeAssignLimit = True 'Employee Assignment Limit
                Case "2"
                    Laundry = True 'Laundry
                    EmployeeAssignLimit = True 'Employee Assignment Limit
                Case "J"
                    SRSConveyor = True 'SRS
                    EmployeeAssignLimit = True 'Employee Assignment Limit
                Case "V"
                    WhiteScrubs = True 'White One-for-One Scrubs
                    EmployeeAssignLimit = True 'Employee Assignment Limit
                Case "D"
                    WhiteConveyor = True 'White
                    Laundry = True 'Laundry
                Case "7"
                    SRSConveyor = True 'SRS
                    Laundry = True 'Laundry
                Case "T"
                    Laundry = True 'Laundry
                    WhiteScrubs = True 'White One-for-One Scrubs
                Case "C"
                    WhiteConveyor = True 'White
                Case "5"
                    Laundry = True 'Laundry
                Case "6"
                    SRSConveyor = True 'SRS
                Case "S"
                    WhiteScrubs = True 'White One-for-One Scrubs
                Case "I"
                    EmployeeAssignLimit = True 'Employee Assignment Limit
                Case "4"
                Case Else
                    invalid = True
            End Select

            Select Case c
                Case "A"
                    AutoValet = True 'Autovalet
                    Accounting = True 'Infinium
                    MultiProperty = True 'Multi-Site
                    WhiteBiometric = True 'Biometric
                    SelfIssueStation = True 'Self-Issue Station
            'multiproperty_yesno = True
                Case "Z"
                    AutoValet = True 'Autovalet
                    Accounting = True 'Infinium
                    MultiProperty = True 'Multi-Site
                    WhiteBiometric = True 'Biometric
            'multiproperty_yesno = True
                Case "H"
                    AutoValet = True 'Autovalet
                    Accounting = True 'Infinium
                    MultiProperty = True 'Multi-Site
                    SelfIssueStation = True 'Self-Issue Station
            'multiproperty_yesno = True
                Case "R"
                    AutoValet = True 'Autovalet
                    Accounting = True 'Infinium
                    SelfIssueStation = True 'Self-Issue Station
                    WhiteBiometric = True 'Biometric
                Case "T"
                    AutoValet = True 'Autovalet
                    SelfIssueStation = True 'Self-Issue Station
                    MultiProperty = True 'Multi-Site
                    WhiteBiometric = True 'Biometric
            'multiproperty_yesno = True
                Case "K"
                    SelfIssueStation = True 'Self-Issue Station
                    Accounting = True 'Infinium
                    MultiProperty = True 'Multi-Site
                    WhiteBiometric = True 'Biometric
            'multiproperty_yesno = True
                Case "D"
                    AutoValet = True 'Autovalet
                    Accounting = True 'Infinium
                    MultiProperty = True 'Multi-Site
            'multiproperty_yesno = True
                Case "Y"
                    AutoValet = True 'Autovalet
                    MultiProperty = True 'Multi-Site
                    WhiteBiometric = True 'Biometric
            'multiproperty_yesno = True
                Case "X"
                    Accounting = True 'Infinium
                    MultiProperty = True 'Multi-Site
                    WhiteBiometric = True 'Biometric
            'multiproperty_yesno = True
                Case "W"
                    AutoValet = True 'Autovalet
                    Accounting = True 'Infinium
                    WhiteBiometric = True 'Biometric
                Case "F"
                    AutoValet = True 'Autovalet
                    Accounting = True 'Infinium
                    SelfIssueStation = True 'Self-Issue
                Case "I"
                    AutoValet = True 'Autovalet
                    MultiProperty = True 'Multi-Site
                    'multiproperty_yesno = True
                    SelfIssueStation = True 'Self-Issue
                Case "J"
                    AutoValet = True 'Autovalet
                    WhiteBiometric = True 'Biometric
                    SelfIssueStation = True 'Self-Issue
                Case "6"
                    Accounting = True 'Infinium
                    MultiProperty = True 'Multi-Site
                    'multiproperty_yesno = True
                    SelfIssueStation = True 'Self-Issue
                Case "9"
                    Accounting = True 'Infinium
                    WhiteBiometric = True 'Biometric
                    SelfIssueStation = True 'Self-Issue
                Case "N"
                    MultiProperty = True 'Multi-Site
                    WhiteBiometric = True 'Biometric
                    'multiproperty_yesno = True
                    SelfIssueStation = True 'Self-Issue
                Case "E"
                    AutoValet = True 'Autovalet
                    MultiProperty = True 'Multi-Site
             'multiproperty_yesno = True
                Case "8"
                    Accounting = True 'Infinium
                    MultiProperty = True 'Multi-Site
            'multiproperty_yesno = True
                Case "5"
                    AutoValet = True 'Autovalet
                    Accounting = True 'Infinium
                Case "Q"
                    AutoValet = True 'Autovalet
                    WhiteBiometric = True 'Biometric
                Case "M"
                    Accounting = True 'Infinium
                    WhiteBiometric = True 'Biometric
                Case "L"
                    MultiProperty = True 'Multi-Site
                    'multiproperty_yesno = True
                    WhiteBiometric = True 'Biometric
                Case "7"
                    AutoValet = True 'Autovalet
                    SelfIssueStation = True 'Self-Issue
                Case "3"
                    WhiteBiometric = True 'Biometric
                    SelfIssueStation = True 'Self-Issue
                Case "P"
                    Accounting = True 'Infinium
                    SelfIssueStation = True 'Self-Issue
                Case "G"
                    MultiProperty = True 'Multi-Site
                    'multiproperty_yesno = True
                    SelfIssueStation = True 'Self-Issue
                Case "B"
                    WhiteBiometric = True 'Biometric
                Case "4"
                    AutoValet = True 'Autovalet
                Case "2"
                    MultiProperty = True 'Multi-Site
             'multiproperty_yesno = True
                Case "1"
                    Accounting = True 'Infinium
                Case "S"
                    SelfIssueStation = True 'Self-Issue
                Case "0"
                Case Else
                    invalid = True
            End Select

            Select Case d
                Case "E"
                    WhiteUPickIt = True 'U-Pick-It
                    RFID = True 'RFID
                Case "W"
                    SRSConveyorAUDS = True 'SRS Conveyors AUDS
                    RFID = True 'RFID

                Case "C"
                    RFID = True 'RFID
                Case "A"
                    WhiteUPickIt = True 'U-Pick-It
                Case "S"
                    SRSConveyorAUDS = True 'SRS Conveyors AUDS

                Case "8"
                Case Else
                    invalid = True
            End Select

            Select Case e
                Case "F"
                    HandheldDownload = True 'Handheld
                    Laundry2 = True 'Crown Laundry
                Case "Y"
                    HandheldDownload = True 'Handheld
                    LaundryGIMS = True 'GIMS-LE
                Case "C"
                    HandheldDownload = True 'Handheld
                Case "3"
                    Laundry2 = True 'Crown Laundry
                Case "Z"
                    LaundryGIMS = True 'GIMS-LE
                Case "7"
                Case Else
                    invalid = True
            End Select

            b5 = Mid(UserLicense, 23, 1)
            b6 = Mid(UserLicense, 24, 1)
            b7 = Mid(UserLicense, 25, 1)



            If Not ValidateRandomOFF(b5) Then
                If Not Val("&H" & b5) > 0 And Val("&H" & b5) < 16 Then


                End If
                'Hiemac
                binaryMask = Val("&H" & b5)
                'if OFF validate else
                If binaryMask >= HIEMAC_MASK Then
                    binaryMask = binaryMask - HIEMAC_MASK
                    HiemacInterface = True 'Hiemac
                End If

                If binaryMask >= FORNET_LAUNDRY_MASK Then
                    binaryMask = binaryMask - FORNET_LAUNDRY_MASK
                    FornetLaundry = True
                End If

                If binaryMask And POLYTEX_MASK Then
                    Polytex = True
                End If
            End If


            If Not ValidateRandomOFF(b6) Then
                If Not Val("&H" & b6) > 0 And Val("&H" & b6) < 16 Then


                End If
                'White CoatCheck
                binaryMask = Val("&H" & b6)
                'if OFF validate else
                If binaryMask >= COATCHECK_MASK Then
                    binaryMask = binaryMask - COATCHECK_MASK
                    CoatCheck = True 'White CoatCheck
                End If

                If binaryMask >= ITPASSWORD_MASK Then
                    binaryMask = binaryMask - ITPASSWORD_MASK
                    ITPassword = True
                End If

                If binaryMask >= EVENTUNIFORMS_MASK Then
                    binaryMask = binaryMask - EVENTUNIFORMS_MASK
                    EventUniforms = True
                End If


            End If


            If Not ValidateRandomOFF(b7) Then
                If Not Val("&H" & b7) > 0 And Val("&H" & b7) < 16 Then


                End If
                'Expiration Date
                binaryMask = Val("&H" & b7)
                'if OFF validate else
                If binaryMask >= EXPIRATION_MASK Then
                    binaryMask = binaryMask - EXPIRATION_MASK
                    '  Expires = True 'Expiration Date
                End If

                If binaryMask >= METALPROGETTI_MASK Then
                    binaryMask = binaryMask - METALPROGETTI_MASK
                    MetalProgetti = True
                End If
            End If


            'Group 4
            If HandheldDownload Then
                binaryMask = Asc(b4)
                Sleds = 0
                If (binaryMask >= 74 And binaryMask <= 90) Then
                    Sleds = 90 - binaryMask

                ElseIf b4 = "2" Then
                    MPCommonEmployees = True

                ElseIf b4 <> "I" And b4 <> "0" Then
                    ParseLicense = False
                    Exit Function
                End If

            ElseIf Not ValidateRandomOFF(b4) Then
                ParseLicense = False
                Exit Function
            End If


            If invalid Then
                WhiteConveyor = False 'White
                SRSConveyor = False 'SRS
                AutoValet = False 'Autovalet
                CoatCheck = False 'Coatcheck
                Accounting = False 'Infinium
                HumanResources = False 'HR
                Laundry = False 'Laundry
                RFID = False 'RFID
                WhiteUPickIt = False 'U-Pick-It
                HandheldDownload = False 'Handheld
                InventoryLimit = False 'Inventory Limit
                Purchasing = False 'MMS
                HiemacInterface = False 'Hiemac
                Laundry2 = False 'Crown Laundry
                RestrictedItem = False
                MultiProperty = False 'Multi-Site
                Phoenix = False 'Phoenix
                LaundryGIMS = False 'GIMS-LE
                SRSConveyorAUDS = False 'SRS Conveyors AUDS
                WhiteScrubs = False
                WhiteBiometric = False
                EmployeeAssignLimit = False 'Employee Assignment
                SelfIssueStation = False
                Demo = False
                WhiteSortConveyor = False
                SelfIssuePortal = False


            End If




            'Disconnected, set IP


            'Multiproperty
            If MultiProperty Then
                bin = Asc(Mid(Trim$(UserLicense), 27, 1))

                If bin <= 80 Then
                    PropertyCount = Str(91 - bin).Trim
                ElseIf bin <= 90 Then
                    PropertyCount = Str(bin - 80).Trim
                Else
                    PropertyCount = Str(bin - 165).Trim
                End If
            Else
                If Not ValidateRandomOFF(Mid(Trim$(UserLicense), 27, 1)) Then
                    ParseLicense = False
                    Exit Function
                End If
            End If

            'Expiration Date
            If Expires Then
                Dim dateStr As String = ""

                'Month is coded to two symbols
                For i = 0 To 1
                    Select Case Mid(UserLicense, 5 + i, 1)
                        Case "~"
                            dateStr = dateStr & "0"
                        Case "?"
                            dateStr = dateStr & "1"
                        Case "!"
                            dateStr = dateStr & "2"
                        Case "@"
                            dateStr = dateStr & "3"
                        Case "#"
                            dateStr = dateStr & "4"
                        Case "$"
                            dateStr = dateStr & "5"
                        Case "%"
                            dateStr = dateStr & "6"
                        Case "^"
                            dateStr = dateStr & "7"
                        Case "&"
                            dateStr = dateStr & "8"
                        Case "*"
                            dateStr = dateStr & "9"
                    End Select
                Next

                ExpireDate = Str(CLng("&H" & Mid(UserLicense, 7, 3))).Trim & "-" & dateStr + "-" + Mid(UserLicense, 10, 2)
            Else
                If Mid(UserLicense, 5, 7) <> "UNIF0RM" Then
                    ParseLicense = False
                    Exit Function

                End If
            End If

            '# Employees / Inventory
            If InventoryLimit Then
                Select Case Mid(Trim$(UserLicense), 12, 1)
                    Case "A"
                        LimitCount = Trim$(Str((Asc(Mid(Trim$(UserLicense), 28, 1)) - 64)) & "0000")
                    Case Else
                        ParseLicense = False
                        Exit Function

                End Select
            Else
                Select Case Mid(Trim$(UserLicense), 12, 1)
'           Case "A"    'AA to AZ inc of 100 100-2600
'               LimitCount = Str(100 + (100 * (Asc(Mid(Trim$(substring), 6, 1)) - 65)))
'           Case "B"    'BA to BC inc of 100 2700-2900
'               LimitCount = Str(2700 + (100 * (Asc(Mid(Trim$(substring), 6, 1)) - 65)))
                    Case "C"    'CO
                        If Mid(Trim$(UserLicense), 28, 1) = "O" Then
                            LimitCount = 0 '"Unlimited" 'Str(3000 + (500 * (Asc(Mid(Trim$(substring), 6, 1)) - 65)))
                        Else
                            ParseLicense = False
                            Exit Function

                        End If
                    Case "D"    'DA 100-2600
                        LimitCount = Str(100 + (100 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 65))).Trim
                    Case "E"    'EA  2700-5200
                        LimitCount = Str(2700 + (100 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 65))).Trim
                    Case "F"    'FA  5300-7800
                        LimitCount = Str(5300 + (100 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 65))).Trim
                    Case "G"    'GA  7900-10400
                        LimitCount = Str(7900 + (100 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 65))).Trim
                    Case "H"    'HA  10500-13000
                        LimitCount = Str(10500 + (100 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 65))).Trim
                    Case "I"    'IA  13100-15600
                        LimitCount = Str(13100 + (100 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 65))).Trim
                    Case "J"    'JA  15700-18200
                        LimitCount = Str(15700 + (100 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 65))).Trim
                    Case "M"    'MA 18300-20000
                        LimitCount = Str(18300 + (100 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 65))).Trim
                    Case "N" 'N 21-30K
                        LimitCount = 20000 + (1000 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 64))
                    Case "O" '0 31-40K
                        LimitCount = 30000 + (1000 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 64))
                    Case "P" 'P 41-50K
                        LimitCount = 40000 + (1000 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 64))
                    Case "Q" 'Q 51-60K
                        LimitCount = 50000 + (1000 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 64))
                    Case "R" 'R 61-70K
                        LimitCount = 60000 + (1000 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 64))
                    Case "S" 'S 71-80K
                        LimitCount = 70000 + (1000 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 64))
                    Case "T" 'T 81-90K
                        LimitCount = 80000 + (1000 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 64))
                    Case "U" 'U 91-100K
                        LimitCount = 90000 + (1000 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 64))
                    Case "V" 'V 101-110K
                        LimitCount = 100000 + (1000 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 64))
                    Case "W" 'W 111-120K
                        LimitCount = 110000 + (1000 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 64))
                    Case "X" 'X 121-130K
                        LimitCount = 120000 + (1000 * (Asc(Mid(Trim$(UserLicense), 28, 1)) - 64))
                    Case Else
                        ParseLicense = False
                        Exit Function
                End Select
            End If

            Return True

        Catch ex As Exception

        End Try
    End Function





#End Region


End Class


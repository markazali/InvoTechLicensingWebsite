Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Module GlobalsModule


    'Group 1
    Public Const INVENTORY_LIMITING_MASK = &H1
    Public Const LAUNDRY_EXPORT_MASK = &H4

    'Group 2
    Public Const CRUISECREWS_INACTIVE_MASK = &H1
    Public Const ACS_MASK = &H2
    Public Const WHITESORTING_MASK = &H8

    'Group 3
    Public Const LICENSEVALIDATION_MASK = &H2
    Public Const SELFISSUEPORTAL_MASK = &H4

    'Group 4
    Public Const MULTIPROPERTY_COMMONEMPLOYEES_MASK = &H2
    Public Const COMPANYLOGO_MASK = &H8

    'Group 5
    Public Const POLYTEX_MASK = &H2
    Public Const FORNET_LAUNDRY_MASK = &H4
    Public Const HIEMAC_MASK = &H8

    'Group 6
    Public Const ITPASSWORD_MASK = &H2
    Public Const COATCHECK_MASK = &H4

    'Group 7
    Public Const METALPROGETTI_MASK = &H1
    Public Const EXPIRATION_MASK = &H2

    Public Const EVENTUNIFORMS_MASK = &H1



    Public Enum emailTypes
        <Description("errorrecipients")> Errors
        <Description("licenserecipients")> Licenses
    End Enum

    Public Enum validationEmail
        wrongIP
        noIP
    End Enum
#Region "Enum Extensions"
    ''This procedure gets the <Description> attribute of an enum constant, if any.
    ''Otherwise it gets the string name of the enum member.
    <Extension()>
    Public Function Description(ByVal EnumConstant As [Enum]) As String
        Dim fi As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
        Dim aattr() As DescriptionAttribute = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
        If aattr.Length > 0 Then
            Return aattr(0).Description
        Else
            Return EnumConstant.ToString()
        End If
    End Function
#End Region
End Module

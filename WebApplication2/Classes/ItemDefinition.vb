Public Class ItemDefinition
    'Private myCustomerCode As Integer
    'Public Property CustomerCode As Integer
    '    Get
    '        Return myCustomerCode
    '    End Get
    '    Set(value As Integer)
    '        myCustomerCode = value
    '    End Set
    'End Property

    'Private myType As String
    'Public Property Type As String
    '    Get
    '        Return myType
    '    End Get
    '    Set(value As String)
    '        myType = value
    '    End Set
    'End Property

    'Private myStyle As String
    'Public Property Style As String
    '    Get
    '        Return myStyle
    '    End Get
    '    Set(value As String)
    '        myStyle = value
    '    End Set
    'End Property

    'Private myitemdefinitionno As Integer
    'Public Property itemdefinitionno As Integer
    '    Get
    '        Return myitemdefinitionno
    '    End Get
    '    Set(value As Integer)
    '        myitemdefinitionno = value
    '    End Set
    'End Property

    Private myIDSyncBlob As String
    Public Property IDSyncBlob As String
        Get
            Return myIDSyncBlob

        End Get
        Set(value As String)
            myIDSyncBlob = value
        End Set
    End Property

    Public Sub SyncIDBlob(ByVal ipstring As String)

        SyncItemDefinitions(IDSyncBlob, ipstring)
    End Sub

End Class

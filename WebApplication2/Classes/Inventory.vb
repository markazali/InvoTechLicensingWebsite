Public Class Inventory
    Private myCustomerCode As Integer
    Public Property CustomerCode As Integer
        Get
            Return myCustomerCode
        End Get
        Set(value As Integer)
            myCustomerCode = value
        End Set
    End Property

    Private myitemdefinitionno As Integer
    Public Property itemdefinitionno As Integer
        Get
            Return myitemdefinitionno
        End Get
        Set(value As Integer)
            myitemdefinitionno = value
        End Set
    End Property

    Private myQuantity As Integer
    Public Property Quantity As Integer
        Get
            Return myQuantity
        End Get
        Set(value As Integer)
            myQuantity = value
        End Set
    End Property

    Private mySize As String
    Public Property Size As String
        Get
            Return mySize

        End Get
        Set(value As String)
            mySize = value
        End Set
    End Property

    Private myLength As String
    Public Property Length As String
        Get
            Return myLength
        End Get
        Set(value As String)
            myLength = value
        End Set
    End Property

End Class

Public Class Laundry
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

    Private myShipDate As Date
    Public Property ShipDate As Date
        Get
            Return myShipDate
        End Get
        Set(value As Date)
            myShipDate = value
        End Set
    End Property

    Private myReceiveDate As Date
    Public Property ReceiveDate As Date
        Get
            Return myReceiveDate
        End Get
        Set(value As Date)
            myReceiveDate = value
        End Set
    End Property

    Private myCheckinDate As Date
    Public Property CheckinDate As Date
        Get
            Return myCheckinDate
        End Get
        Set(value As Date)
            myCheckinDate = value
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

    Private myCost As Decimal
    Public Property Cost As Decimal
        Get
            Return myCost
        End Get
        Set(value As Decimal)
            myCost = value
        End Set
    End Property

End Class

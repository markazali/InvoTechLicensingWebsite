Imports System.Data.SqlClient

Public Class PropertiesLookup
    Inherits System.Web.UI.Page

    Dim searchfilter As String = ""
    Dim connectionstring As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString

    Dim connectionstringMaster As String = ConfigurationManager.ConnectionStrings("constrMaster").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If Not Me.Page.User.Identity.IsAuthenticated Or Session("userNo") Is Nothing Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Not Me.IsPostBack Then
                Me.BindGrid()
            End If
        End If


    End Sub
    Private Sub BindGrid()
        Using con As New SqlConnection(connectionstring)
            If txtSearch.Text <> "" Then
                searchfilter = " and l.customer like " & (txtSearch.Text.Trim & "%").SQLPrep
            Else
                searchfilter = ""
            End If
            Using cmd As New SqlCommand("SELECT l.customer, p.productName, p.productCode, l.license, l.expirationDate, validationDate=PSTValidationDate	,l.locale	,l.deleted	,l.onHold	,l.ipAddress	,l.customerCode, l.productversion " &
                                        " FROM licensing l join products p on p.productCode = l.productCode " &
                                        " where l.deleted = 0 " & searchfilter)
                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Protected Sub OnRowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        Me.BindGrid()
    End Sub
    Protected Sub OnRowCancelingEdit(sender As Object, e As EventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        Me.BindGrid()
    End Sub
    Private Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim gvcustomerCode As Integer = TryCast(GridView1.Rows(e.RowIndex).FindControl("lblCustomerCode"), Label).Text.ToUpper
        Dim gvlicense As String = TryCast(GridView1.Rows(e.RowIndex).FindControl("lblLicense"), Label).Text.ToUpper

        If Session("userNo") Is Nothing Then Exit Sub




        Try
            Using con As New SqlConnection(connectionstring)
                Using cmd As New SqlCommand("sp_LicenseeAddEdit")
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@license", SqlDbType.NVarChar).Value = gvlicense
                    cmd.Parameters.Add("@customercode", SqlDbType.Int).Value = gvcustomerCode
                    cmd.Parameters.Add("@customer", SqlDbType.NVarChar).Value = TryCast(GridView1.Rows(e.RowIndex).FindControl("lblCustomer"), Label).Text.ToUpper
                    cmd.Parameters.Add("@locale", SqlDbType.NVarChar).Value = TryCast(GridView1.Rows(e.RowIndex).FindControl("lblLocale"), Label).Text
                    If IsDate(TryCast(GridView1.Rows(e.RowIndex).FindControl("lblExpires"), Label).Text) Then
                        cmd.Parameters.Add("@expirationDate", SqlDbType.Date).Value = TryCast(GridView1.Rows(e.RowIndex).FindControl("lblExpires"), Label).Text
                    Else
                        cmd.Parameters.Add("@expirationDate", SqlDbType.Date).Value = DBNull.Value
                    End If
                    cmd.Parameters.Add("@userNo", SqlDbType.Int).Value = Session("userNo")
                    cmd.Parameters.Add("@deleted", SqlDbType.Bit).Value = True
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            GridView1.EditIndex = -1
            Me.BindGrid()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub OnRowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating




        If Session("userNo") Is Nothing Then
            FormsAuthentication.RedirectToLoginPage()
            Exit Sub
        End If

        Dim customerOld As String = ""
        Dim customerNew As String = ""
        Dim gvcustomerCode As Integer
        Try
            Using con As New SqlConnection(connectionstring)
                Using cmd As New SqlCommand("sp_LicenseeAddEdit")

                    Try


                        cmd.CommandType = CommandType.StoredProcedure

                        With GridView1.Rows(GridView1.EditIndex)
                            customerOld = TryCast(.FindControl("lblCustomer"), Label).Text.ToUpper
                            customerNew = TryCast(.FindControl("txtCustomer"), TextBox).Text.ToUpper
                            gvcustomerCode = TryCast(.FindControl("lblCustomerCode"), Label).Text.ToUpper
                            Dim gvlicense As String = TryCast(.FindControl("txtLicense"), TextBox).Text.ToUpper
                            Dim oldlicense As String = TryCast(.FindControl("lblLicense"), Label).Text.ToUpper

                            Dim expireStr As String = GetKeyExpireDate(gvlicense)

                            cmd.Parameters.Add("@license", SqlDbType.NVarChar).Value = gvlicense
                            cmd.Parameters.Add("@locale", SqlDbType.NVarChar).Value = TryCast(.FindControl("txtLocale"), TextBox).Text.ToUpper
                            cmd.Parameters.Add("@customercode", SqlDbType.Int).Value = gvcustomerCode
                            cmd.Parameters.Add("@customer", SqlDbType.NVarChar).Value = customerNew
                            If IsDate(expireStr) Then
                                cmd.Parameters.Add("@expirationDate", SqlDbType.Date).Value = expireStr
                            Else
                                cmd.Parameters.Add("@expirationDate", SqlDbType.Date).Value = DBNull.Value
                            End If
                            cmd.Parameters.Add("@productCode", SqlDbType.NVarChar).Value = TryCast(.FindControl("ddlProductCode"), DropDownList).SelectedValue
                            cmd.Parameters.Add("@userNo", SqlDbType.Int).Value = Session("userNo")
                            cmd.Parameters.Add("@onhold", SqlDbType.Bit).Value = TryCast(.FindControl("CheckBoxHold"), CheckBox).Checked

                            If oldlicense <> gvlicense Then
                                EmailCustomerUpdate(customerNew, gvlicense, gvcustomerCode)
                            End If
                        End With
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                    Catch ex As Exception

                    End Try
                End Using
            End Using

            'update firewall settings
            If customerNew <> customerOld Then
                Using firewallDT As DataTable = SelectQuery("select * from sys.firewall_rules where name=" & customerOld.SQLPrep, True)

                    If firewallDT.Rows.Count > 0 Then
                        FirewallAdd(customerNew, firewallDT.Rows(0)("start_ip_address"), firewallDT.Rows(0)("end_ip_address"), gvcustomerCode)
                        FirewallDelete(customerOld)
                    End If

                End Using
            End If

            GridView1.EditIndex = -1
            Me.BindGrid()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Response.Redirect("PropertiesDetails")
    End Sub

    Private Sub GridView1_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs) Handles GridView1.RowUpdated

    End Sub

    Private Sub GridView1_PreRender(sender As Object, e As EventArgs) Handles GridView1.PreRender
        Try
            ' adds scope attribute
            GridView1.UseAccessibleHeader = True

            'adds <thead> and <tbody> elements
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnshowall_Click(sender As Object, e As EventArgs) Handles btnshowall.Click
        txtSearch.Text = ""
        BindGrid()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindGrid()
    End Sub
End Class
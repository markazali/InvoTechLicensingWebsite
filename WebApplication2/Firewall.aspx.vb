Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports Microsoft.AspNet.Identity

Public Class Firewall
    Inherits System.Web.UI.Page


    Dim searchfilter As String = ""
    Dim firewalls As DataTable
    Dim connectionstring As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
    Protected Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Response.Redirect("FirewallDetails")
    End Sub

    Private Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)


        If Session("userNo") Is Nothing Then Exit Sub

        Try
            FirewallDelete(TryCast(GridView1.Rows(e.RowIndex).FindControl("lblName"), Label).Text.ToUpper)

            GridView1.EditIndex = -1
            Me.BindGrid()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub BindGrid()
        Using con As New SqlConnection(connectionstring)
            If txtSearch.Text <> "" Then
                searchfilter = " and rangename like " & (txtSearch.Text.Trim & "%").SQLPrep
            Else
                searchfilter = ""
            End If

            Using cmd As New SqlCommand("select lip.*, l.customer,  create_date = dbo.GetDateCDT(lip.dateAdded) 
                                        from LicensingIPRanges lip 
                                        join licensing l on l.customercode = lip.customercode  
                                        where lip.deleted = 0 " & searchfilter &
                                        " order by l.customer, lip.rangename")
                Using sda As New SqlDataAdapter()
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        firewalls = dt
                        GridView1.DataSource = firewalls
                        GridView1.DataBind()
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Or Session("userNo") Is Nothing Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Not Me.IsPostBack Then
                Me.BindGrid()
            End If
        End If





    End Sub
    Private Sub GridView1_PreRender(sender As Object, e As EventArgs) Handles GridView1.PreRender
        ' adds scope attribute
        GridView1.UseAccessibleHeader = True

        'adds <thead> and <tbody> elements
        If GridView1.Rows.Count > 0 Then GridView1.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub
    Protected Sub OnRowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        Me.BindGrid()
    End Sub
    Private Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)


        If Session("userNo") Is Nothing Then Exit Sub

        Try

            With GridView1.Rows(e.RowIndex)
                If TryCast(.FindControl("txtName"), TextBox).Text.Trim <> TryCast(.FindControl("lblName"), Label).Text.Trim Then
                    FirewallDelete(TryCast(.FindControl("txtName"), TextBox).Text.Trim)
                End If
                FirewallAdd(TryCast(.FindControl("txtName"), TextBox).Text.ToUpper,
                            TryCast(.FindControl("txtStartIP"), TextBox).Text,
                            TryCast(.FindControl("txtEndIP"), TextBox).Text,
                            TryCast(.FindControl("customercode"), Label).Text)
            End With

            GridView1.EditIndex = -1
            Me.BindGrid()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub OnRowCancelingEdit(sender As Object, e As EventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        Me.BindGrid()
    End Sub
    Private Sub GridView1_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs) Handles GridView1.RowUpdated

    End Sub


    Private Sub btnShowall_Click(sender As Object, e As EventArgs) Handles btnShowall.Click
        txtSearch.Text = ""
        BindGrid()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindGrid()
    End Sub
End Class
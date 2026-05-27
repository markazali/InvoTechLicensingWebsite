Imports System.Data.SqlClient

Public Class Users
    Inherits System.Web.UI.Page

    Dim connectionstring As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString

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
            Using cmd As New SqlCommand("SELECT username,userno,lastlogindate=pstlogindate FROM users where deleted = 0 ")
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


    Protected Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Response.Redirect("usersdetails")
    End Sub

    Private Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Try
            If Session("userNo") Is Nothing Then
                FormsAuthentication.RedirectToLoginPage()
                Exit Sub
            End If
            Using con As New SqlConnection(connectionstring)
                Using cmd As New SqlCommand("update users set deleted = 1,deletedby=" & Session("userNo") & " where userno = " & TryCast(GridView1.Rows(e.RowIndex).FindControl("lbluserNo"), Label).Text.ToUpper)


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
    Private Sub GridView1_PreRender(sender As Object, e As EventArgs) Handles GridView1.PreRender
        Try
            ' adds scope attribute
            GridView1.UseAccessibleHeader = True

            'adds <thead> and <tbody> elements
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader
        Catch ex As Exception

        End Try

    End Sub
End Class
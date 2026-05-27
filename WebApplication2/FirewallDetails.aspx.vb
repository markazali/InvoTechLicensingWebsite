Imports System.Data.SqlClient

Public Class FirewallDetails
    Inherits System.Web.UI.Page




    Dim connectionstring As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
    Dim connectionstringMaster As String = ConfigurationManager.ConnectionStrings("constrMaster").ConnectionString


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Me.Page.User.Identity.IsAuthenticated Or Session("userNo") Is Nothing Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Not Me.IsPostBack Then

            End If
        End If
    End Sub

    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click

        If Session("userNo") Is Nothing Then Response.Redirect("default")

        Dim userNo As Integer = 0

        Try

            'If GetValue("sys.firewall_rules", "id <> 1 and name= N" & txtName.Text.SQLPrep, "id", True) <> 0 Then
            '    txtAlreadyExists.Visible = True
            '    Exit Sub
            'Else
            '    txtAlreadyExists.Visible = False
            'End If

            Try
                FirewallAdd(txtName.Text, txtIPStart.Text, txtIPEnd.Text, DropDownListCustomer.SelectedValue)

            Catch ex As Exception

            End Try

            Response.Redirect("firewall")

        Catch ex As Exception

        End Try

    End Sub
End Class
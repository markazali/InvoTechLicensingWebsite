Public Class UsersDetails
    Inherits System.Web.UI.Page

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

            If GetValue("users", "deleted = 0 and username = " & txtUserName.Text.SQLPrep, "userNo") <> 0 Then
                txtAlreadyExists.Visible = True
                Exit Sub
            Else
                txtAlreadyExists.Visible = False
            End If

            userNo = InsertRecord("users", "username,addedBy,password", txtUserName.Text.SQLPrep & "," & Session("userNo") & ",''")

            ExecuteSQL("update users set password = " & GetMd5Hash(userNo & txtPassword.Text).SQLPrep & " where userno = " & userNo)

            Response.Redirect("users")

        Catch ex As Exception

        End Try

    End Sub
End Class
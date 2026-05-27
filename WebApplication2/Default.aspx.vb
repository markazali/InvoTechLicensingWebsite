Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports Microsoft.AspNet.Identity
Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Me.Page.User.Identity.IsAuthenticated And Not Session("userNo") Is Nothing Then
            Response.Redirect("PropertiesLookup")
        End If
    End Sub

    Protected Sub ValidateUser(sender As Object, e As EventArgs)


        Dim userNo As Integer = GetValue("users", "deleted = 0 and username=" & Login1.UserName.SQLPrep, "userNo")

        If userNo <> 0 Then
            For Each r As DataRow In SelectQuery("select * from users " &
                                                    " where username=" & Login1.UserName.SQLPrep &
                                                    " and password= " & GetMd5Hash(userNo.ToString & Login1.Password).SQLPrep).Rows

                Session("userNo") = r("userno")
                Session("userName") = r("username")

                Dim updatestr As String = "update users " &
                        " set ipaddress =  '" & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR") & "'" &
                        " , lastlogindate=getdate() " &
                        " where userno = " & Session("userNo")

                ExecuteSQL(updatestr)

                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
                Exit Sub
            Next
        End If

        Login1.FailureText = "Username and/or password is incorrect."

    End Sub

End Class
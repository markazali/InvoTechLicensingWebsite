Public Class About
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Or Session("userNo") Is Nothing Then
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub
End Class
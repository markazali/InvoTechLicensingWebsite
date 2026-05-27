Imports System.Data.SqlClient

Public Class Properties
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

    Protected Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click

        If Session("userNo") Is Nothing Then Exit Sub

        Try

            'save company info
            Using con As New SqlConnection(connectionstring)
                Using cmd As New SqlCommand("sp_LicenseeAddEdit")
                    Dim expireStr As String = GetKeyExpireDate(txtLicense.Text)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@license", SqlDbType.NVarChar).Value = txtLicense.Text
                    cmd.Parameters.Add("@locale", SqlDbType.NVarChar).Value = txtLocale.Text
                    cmd.Parameters.Add("@customercode", SqlDbType.Int).Value = DBNull.Value
                    cmd.Parameters.Add("@productCode", SqlDbType.NVarChar).Value = DropDownListProductCode.SelectedValue
                    cmd.Parameters.Add("@customer", SqlDbType.NVarChar).Value = txtCompany.Text.ToUpper
                    If IsDate(expireStr) Then
                        cmd.Parameters.Add("@expirationDate", SqlDbType.Date).Value = expireStr
                    Else
                        cmd.Parameters.Add("@expirationDate", SqlDbType.Date).Value = DBNull.Value
                    End If
                    cmd.Parameters.Add("@userNo", SqlDbType.Int).Value = Session("userNo")
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using


            'save firewall info
            If txtIPStart.Text <> "" And txtIPEnd.Text <> "" Then
                'Using con As New SqlConnection(connectionstringMaster)
                '    Using cmd As New SqlCommand("sp_set_firewall_rule ")
                '        cmd.CommandType = CommandType.StoredProcedure
                '        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtCompany.Text.ToUpper
                '        cmd.Parameters.Add("@start_ip_address", SqlDbType.VarChar).Value = txtIPStart.Text
                '        cmd.Parameters.Add("@end_ip_address", SqlDbType.VarChar).Value = txtIPEnd.Text
                '        cmd.Connection = con
                '        con.Open()
                '        cmd.ExecuteNonQuery()
                '        con.Close()
                '    End Using
                'End Using

                'todo: sp_LicenseeAddEdit should just return the customercode for updates or edits.
                FirewallAdd(txtCompany.Text,
                            txtIPStart.Text,
                            txtIPEnd.Text,
                            GetValue("Licensing", "deleted=0 and license=" & txtLicense.Text.SQLPrep, "customercode"))
            End If



        Catch ex As Exception

        End Try


        Response.Redirect("PropertiesLookup")
    End Sub
End Class
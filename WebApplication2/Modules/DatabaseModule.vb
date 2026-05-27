Imports System.Data.SqlClient
Imports System.Web.Configuration

Module DatabaseModule
    Private connectionstring As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
    Private connectionstringMaster As String = ConfigurationManager.ConnectionStrings("constrMaster").ConnectionString
    Public Function GetValue(ByVal table As String,
                             ByVal where As String,
                             ByVal retrieve As String,
                             Optional ByVal useMaster As Boolean = False) As Decimal

        Dim cmd As New SqlCommand
        Dim cs As String
        If useMaster Then
            cs = connectionstringMaster
        Else
            cs = connectionstring
        End If
        Dim sqlConnection1 As New SqlConnection(cs)

        Try

            cmd.Connection = sqlConnection1

            If where <> vbNullString Then
                cmd.CommandText = "Select " & retrieve & " from " & table & " where " & where
            Else
                cmd.CommandText = "Select " & retrieve & " from " & table
            End If

            sqlConnection1.Open()
            GetValue = CType(cmd.ExecuteScalar(), Decimal)
            sqlConnection1.Close()
        Catch ex As Exception
            Return 0
        Finally
            sqlConnection1.Close()
            cmd.Dispose()
        End Try
    End Function
    Public Sub ExecuteSQL(ByVal query As String,
                             Optional ByVal useMaster As Boolean = False)
        Dim sqlConnection1 As New SqlConnection(connectionstring)
        Dim cmd As New SqlCommand

        Try


            cmd.CommandText = query
            cmd.CommandType = CommandType.Text
            cmd.Connection = sqlConnection1

            sqlConnection1.Open()

            cmd.ExecuteNonQuery()


        Catch ex As Exception

        Finally
            sqlConnection1.Close()
            cmd.Dispose()
        End Try

    End Sub
    Public Function SelectQuery(ByVal query As String, Optional ByVal useMaster As Boolean = False) As DataTable

        Dim cs As String
        If useMaster Then
            cs = connectionstringMaster
        Else
            cs = connectionstring
        End If

        Dim sqlConnection1 As New SqlConnection(cs)

        Dim cmd As New SqlCommand

        Dim table As New DataTable
        Dim da As New SqlDataAdapter
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        sqlConnection1.Open()

        Try
            cmd.CommandText = query

            da.SelectCommand = cmd
            da.Fill(table)
            Return table

        Catch e As Exception
            Return Nothing
        Finally
            sqlConnection1.Close()
            cmd.Dispose()
        End Try

    End Function
    Public Function InsertRecord(ByVal table As String, ByVal fields As String, ByVal values As String) As Integer
        Dim sqlConnection1 As New SqlConnection(connectionstring)
        Dim cmd As New SqlCommand
        Try
            cmd.CommandText = "insert into " & table & "(" & fields & ") values (" & values & ")"
            cmd.CommandText &= ";SELECT isnull(SCOPE_IDENTITY(),0)"
            cmd.CommandType = CommandType.Text
            cmd.Connection = sqlConnection1

            sqlConnection1.Open()
            InsertRecord = cmd.ExecuteScalar()

        Catch ex As Exception
            Return 0
        Finally
            sqlConnection1.Close()
            cmd.Dispose()
        End Try

    End Function
    Public Sub UpdateRecord(ByVal table As String, ByVal setStr As String, ByVal whereStr As String)
        Dim sqlConnection1 As New SqlConnection(connectionstring)
        Dim cmd As New SqlCommand
        Try
            cmd.CommandText = "update  " & table & " set " & setStr & " where " & whereStr
            cmd.CommandType = CommandType.Text
            cmd.Connection = sqlConnection1

            sqlConnection1.Open()

            cmd.ExecuteNonQuery()
        Catch ex As Exception

        Finally
            sqlConnection1.Close()
            cmd.Dispose()
        End Try

    End Sub
    Public Sub FirewallAdd(ByVal rangeName As String, ByVal startIp As String, ByVal endIp As String, ByVal custCode As Integer)
        Try
            ' since the licensing server is now an API, we only need sp_set_firewall_rule for clients directly connecting to the SQL

            Using con As New SqlConnection(connectionstring)
                Using cmd As New SqlCommand("sp_IPRangeAddEdit")
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@rangeName", SqlDbType.NVarChar).Value = rangeName.Trim
                    cmd.Parameters.Add("@start_ip_address", SqlDbType.VarChar).Value = startIp.Trim
                    cmd.Parameters.Add("@end_ip_address", SqlDbType.VarChar).Value = endIp.Trim
                    cmd.Parameters.Add("@customerCode", SqlDbType.Int).Value = custCode
                    cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "E"
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Sub FirewallDelete(ByVal rangeName As String)
        Try

            'Using con As New SqlConnection(connectionstringMaster)
            '    Using cmd As New SqlCommand("sp_delete_firewall_rule ")
            '        cmd.CommandType = CommandType.StoredProcedure
            '        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = rangeName.Trim
            '        cmd.Connection = con
            '        con.Open()
            '        cmd.ExecuteNonQuery()
            '        con.Close()
            '    End Using
            'End Using

            Using con As New SqlConnection(connectionstring)
                Using cmd As New SqlCommand("sp_IPRangeAddEdit ")
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@rangeName", SqlDbType.NVarChar).Value = rangeName.Trim
                    cmd.Parameters.Add("@action", SqlDbType.VarChar).Value = "D"
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using



        Catch ex As Exception

        End Try
    End Sub
    Public Sub SyncItemDefinitions(ByVal blob As String, ByVal ipstring As String)
        Try


            Using con As New SqlConnection(connectionstring)
                Using cmd As New SqlCommand("SyncItemDefinitions")
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@syncblob", SqlDbType.NVarChar).Value = blob
                    cmd.Parameters.Add("@ipdaddress", SqlDbType.NVarChar).Value = ipstring
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Module

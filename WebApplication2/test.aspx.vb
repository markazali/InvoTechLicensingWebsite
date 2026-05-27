
Imports System.IO

Public Class test

    Inherits System.Web.UI.Page

    Private postString As String = ""
    Private lastMinCount As Integer = 0
    Private last5MinCount As Integer = 0
    Private lastHourCount As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try


            If lastHourCount > 0 Then
                LabelLastMin.Text = lastMinCount
                LabelLast5Min.Text = last5MinCount
                LabelLastHour.Text = lastHourCount
            End If

            postString = ""
            Dim readerName As String = ""
            Dim antennaNo As Integer = 0
            Dim postArgs() As String
            Dim ids() As String
            Dim testnum As Integer = 0

            If Page.IsPostBack Then
                postStatus.Text = "postback!"

                For Each est As String In Request.Form.Keys
                    If postString <> "" Then postString &= "&"
                    postString &= est & "=" & Request.Form(est)
                Next

                If postString <> "" Then
                    ' InsertRecord("testdump", "datadump", postString.SQLPrep)
                    ' Dim text As String = "First line" & Environment.NewLine
                End If
            ElseIf Request.HttpMethod = "POST" Then

                For Each est As String In Request.Form.Keys
                    If postString <> "" Then postString &= "&"
                    postString &= est & "=" & Request.Form(est)
                Next

                'InsertRecord("testdump", "datadump", postString.SQLPrep)


                For Each est As String In Request.Form.Keys


                    If est = "reader_name" Then
                        readerName = Request.Form(est).Replace("""", "")
                    End If


                    If est = "field_values" Then
                        For Each x2 In Request.Form(est).Split(vbLf)
                            If x2 <> "" Then
                                'debug
                                'File.AppendAllText("c:\temp\testwrites.txt", x2 & vbCrLf)
                                'File.AppendAllText("c:\temp\testwrites.txt", testnum & vbCrLf)

                                If x2.Split(",")(1) <> "" Then
                                    InsertRecord("testtags", "readername,antennaNo,id, ipaddress",
                    readerName.SQLPrep &
                    "," & x2.Split(",")(0).SQLPrep &
                    "," & x2.Split(",")(1).Replace("""", "").SQLPrep &
                    "," & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").SQLPrep)
                                End If
                            End If
                        Next
                    End If
                Next

                postStatus.Text = "http post is valid"
            Else
                postStatus.Text = "nothing posted!"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)

        If IsNumeric(TextBoxInterval.Text) Then
            If TextBoxInterval.Text * 1000 <> Timer1.Interval Then Timer1.Interval = TextBoxInterval.Text * 1000
        Else
            Timer1.Interval = 3000

        End If

        Using tagsdt As DataTable = SelectQuery("declare @marker as int = (select top 1 rowno from testtags where pstdateadded >= dateadd(day,-1,getdate())) " & vbCrLf &
            "select top 50 *" &
            " ,  lastmincount = (select count(*) from testtags with(nolock) where deleted = 0  and pstdateadded >= dateadd(minute, -1 , dbo.GetDateCDT(getdate()))) " &
            " , last5mincount = (select count(*) from testtags with(nolock)  where deleted = 0  and pstdateadded >= dateadd(minute, -5 , dbo.GetDateCDT(getdate()))) " &
            " , lasthourcount = (select count(*) from testtags  with(nolock) where  deleted = 0  and pstdateadded >= dateadd(minute, -60 , dbo.GetDateCDT(getdate()))) " &
            " , readDate = dbo.GetDateCDT(getdate()) " &
            " from testtags with(nolock) " &
            " where deleted = 0 and rowno >=  @marker " &
            " order by rowno desc")
            If tagsdt.Rows.Count > 0 Then
                GridView2.DataSource = tagsdt
                GridView2.DataBind()
                LabelLastMin.Text = tagsdt.Rows(0)("lastmincount")
                LabelLast5Min.Text = tagsdt.Rows(0)("last5mincount")
                LabelLastHour.Text = tagsdt.Rows(0)("lasthourcount")
                LabelUpdateDate.Text = tagsdt.Rows(0)("readDate")
            End If

        End Using
    End Sub
End Class

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="test.aspx.vb" Inherits="InvoTechLicensingApp.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">



<head runat="server">
    <title></title>
</head>
    <style>
        body {
            font-family: 'Arial Unicode MS';
        }
        .tablereads {
            font-size: 11pt;
       
        }
        .tablereads td {
             padding: 4px;

        }
        .idtag {
            
        }
    </style>
<body >
    <form id="form1" runat="server">
        
        <asp:TextBox ID="postStatus" runat="server" Visible="False"></asp:TextBox><br />


        Update interval (seconds): <asp:TextBox ID="TextBoxInterval" runat="server"></asp:TextBox>
        <asp:RangeValidator runat="server" Type="Integer" MinimumValue="0" MaximumValue="60" ControlToValidate="TextBoxInterval" ErrorMessage="Value must be a whole number between 0 and 60" />
        <div>
            <%=Request.Form("test1") %>
          
        </div>

        <div>
            <%=Request.QueryString("test2") %>
        </div>


            <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            
            <ContentTemplate>
                <table style="border: 1px solid grey; margin-top:10px;margin-bottom:10px; " border="1">
                    <tr>
                        <td>Last updated</td>
                        <td><asp:Label ID="LabelUpdateDate" runat="server" Text=""></asp:Label></td>
                    </tr>
                   
                    <tr>
                        <td colspan="2">Scans in last</td>
                    </tr>
                    <tr>
                        <td>Minute</td>
                        <td style="text-align:center"><asp:Label ID="LabelLastMin" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>5 minutes</td>
                        <td style="text-align:center"><asp:Label ID="LabelLast5Min" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Hour</td>
                        <td style="text-align:center"><asp:Label ID="LabelLastHour" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
               
               
             

                <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>

                  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" AllowSorting="True" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" CssClass="tablereads">

                    <Columns>

                        
                        <asp:BoundField DataField="readername" HeaderText="reader name" ReadOnly="True"  />
                        <asp:BoundField DataField="antennaNo" HeaderText="antenna" ReadOnly="True" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" ItemStyle-HorizontalAlign="right" ItemStyle-CssClass="idtag" />
                        <asp:BoundField DataField="pstdateadded" HeaderText="read date/time" ReadOnly="True" ItemStyle-HorizontalAlign="right" />


                    </Columns>

                </asp:GridView>

            

            </ContentTemplate>

        </asp:UpdatePanel>

    </form>
</body>
</html>

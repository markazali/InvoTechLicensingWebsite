<%@ Page Language="vb" title="Users" MasterPageFile="~/Site.Master"  AutoEventWireup="false" CodeBehind="Users.aspx.vb" Inherits="InvoTechLicensingApp.Users" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"  >
     <asp:Button ID="Add" Text="Add" CssClass="addbutton" runat="server"/>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
           
            <asp:BoundField DataField="username" HeaderText="User Name" />
             <asp:TemplateField HeaderText="User No">
                <EditItemTemplate>
                    <asp:Label ID="lbluserNo" runat="server" Text='<%# Bind("userNo") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbluserNo" runat="server" Text='<%# Bind("userNo") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="aspNetHidden" />
                <ItemStyle CssClass="aspNetHidden" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Login Date (PST)">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("lastlogindate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("lastlogindate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete?'); "></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="gvheader" />
        <RowStyle CssClass="gvrow" />
    </asp:GridView>
    
    </asp:Content>


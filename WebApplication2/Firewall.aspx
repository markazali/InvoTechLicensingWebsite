<%@ Page title="Firewall" Language="vb" MasterPageFile="~/Site.Master"  AutoEventWireup="false" CodeBehind="Firewall.aspx.vb" Inherits="InvoTechLicensingApp.Firewall" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Panel DefaultButton="btnSearch" runat="server">
        
       <asp:Button ID="Add" Text="Add" runat="server" CssClass="addbutton" />

    <div>
        <asp:TextBox runat="server" placeholder="Name" ID="txtSearch">        </asp:TextBox> <asp:Button text="Search" ID="btnSearch" runat="server" CssClass="searchbutton"   />
        <asp:Button text="Show All" ID="btnShowall" runat="server" CssClass="searchbutton"  />
        
        </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="select * from licensingipranges order by rangename"></asp:SqlDataSource>


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%" BorderColor="White" BorderStyle="Solid" BorderWidth="1px">
        <Columns>


        
            <asp:BoundField DataField="Customer" HeaderText="Customer" ReadOnly="True"/> 
                        
            
           

            <asp:TemplateField HeaderText="Customer Code" >
                <EditItemTemplate>
                    <asp:Label ID="customerCode" runat="server" Text='<%# Eval("customercode") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="customerCode" runat="server" Text='<%# Bind("customercode") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Range Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" Text='<%# Bind("rangename") %>'></asp:TextBox>
                    <asp:Label ID="lblName" runat="server" style="display:none" Text='<%# Bind("rangename") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("rangename") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start IP">
                <EditItemTemplate>
                    <asp:TextBox ID="txtStartIP" runat="server" MaxLength="15" Text='<%# Bind("start_ip_address") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("start_ip_address") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="End IP">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEndIP" runat="server" MaxLength="15" Text='<%# Bind("end_ip_address") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("end_ip_address") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="create_date" HeaderText="Added" ReadOnly="True" />
            <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?'); " Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>


        
            <asp:BoundField DataField="iprangeno" HeaderText="iprangeno" ReadOnly="True"   >
                <ItemStyle CssClass="hiddencol"/>
                <HeaderStyle CssClass="hiddencol"/>
            </asp:Boundfield>
                


        
        </Columns>
        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="gvheader" />
        <RowStyle CssClass="gvrow" />
    </asp:GridView>

        
        
    <div runat="server" id="myfirewallstuff">
        
        </div>

        </asp:Panel>
</asp:Content>
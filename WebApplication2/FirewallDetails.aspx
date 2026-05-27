<%@ Page  title="Firewall - Add" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="FirewallDetails.aspx.vb" Inherits="InvoTechLicensingApp.FirewallDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="select customer, customercode from licensing where deleted = 0 order by customer"></asp:SqlDataSource>
    <div class="pdmain">
        <div class="formsection">
            <div class="pdleft">Property</div>
            <div class="pdright">
             <asp:DropDownList ID="DropDownListCustomer" runat="server" DataSourceID="SqlDataSource1" DataTextField="customer" DataValueField="customercode" AppendDataBoundItems="true">
                    <asp:ListItem Text="-- select a property --" Value="0" />
                </asp:DropDownList>
                </div>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownListCustomer" ErrorMessage="Property required" InitialValue="0"  CssClass="validation" ></asp:RequiredFieldValidator>

            
        </div>
        <div class="formsection">
            <div class="pdleft">Name</div>
            <div class="pdright">
                <asp:TextBox ID="txtName" runat="server" MaxLength="50" AutoComplete="off"></asp:TextBox>
                <asp:Label ID="txtAlreadyExists" runat="server" Visible="False" CssClass="validation">This name already exists!</asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required" CssClass="validation"></asp:RequiredFieldValidator>
                            </div>
        </div>


        <div class="formsection">
            <div class="pdleft">IP Range</div>
            <div class="pdright">
                <asp:TextBox ID="txtIPStart" runat="server" MaxLength="15"  AutoComplete="off"></asp:TextBox> - <asp:TextBox ID="txtIPEnd" runat="server" MaxLength="15"  AutoComplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtIPStart" ErrorMessage="Start IP is required" CssClass="validation" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIPEnd" ErrorMessage="End IP is required" CssClass="validation" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>


         <div class="formsection">
        <div class="pdleft">&nbsp;</div>
        <div class="pdright">
            <asp:Button runat="server" Text="Add" ID="Add" CssClass="addbutton" />
        </div>
    </div>

    </div>

   
</asp:Content>

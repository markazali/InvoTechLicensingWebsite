<%@ Page Language="vb" title="Properties - Add" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="PropertiesDetails.aspx.vb" Inherits="InvoTechLicensingApp.Properties" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="select * from products"></asp:SqlDataSource>
    <div class="pdmain">
        <div class="formsection">
            <div class="pdleft">Company</div>
            <div class="pdright">
                <asp:TextBox ID="txtCompany" runat="server" MaxLength="50" AutoComplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompany" ErrorMessage="Company is required" CssClass="validation" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>


        <div class="formsection">
            <div class="pdleft">License</div>
            <div class="pdright">
                <asp:TextBox ID="txtLicense" runat="server" MaxLength="50" AutoComplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLicense" ErrorMessage="License is required" CssClass="validation" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="formsection">
            <div class="pdleft">Product Code</div>
            <div class="pdright">

                <asp:DropDownList ID="DropDownListProductCode" runat="server" DataSourceID="SqlDataSource1" DataTextField="productName" DataValueField="productCode">
                    
                </asp:DropDownList>

            </div>
        </div>

       

        <div class="formsection">
            <div class="pdleft">Locale</div>
            <div class="pdright">
                <asp:TextBox ID="txtLocale" runat="server" MaxLength="50"></asp:TextBox>
            </div>
        </div>

        
        <div class="formsection">
            <div class="pdleft">IP Range</div>
            <div class="pdright">
                <asp:TextBox ID="txtIPStart" runat="server" MaxLength="15" Width="8em" ></asp:TextBox> - <asp:TextBox ID="txtIPEnd" runat="server" MaxLength="15" Width="8em"></asp:TextBox>
            </div>
        </div>

        <div class="formsection">
        <div class="pdleft">&nbsp;</div>
        <div class="pdright">
            <asp:Button runat="server" Text="Add" ID="Add"  CssClass="addbutton"/>
        </div>
    </div>
    </div>

    
</asp:Content>

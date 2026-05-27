<%@ Page Language="vb" title="Users - Add"  MasterPageFile="~/Site.Master"  AutoEventWireup="false" CodeBehind="UsersDetails.aspx.vb" Inherits="InvoTechLicensingApp.UsersDetails" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pdmain">
        <div class="formsection">
            <div class="pdleft">User Name</div>
            <div class="pdright">
                <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" AutoComplete="off"></asp:TextBox>
                <asp:Label ID="txtAlreadyExists" runat="server" Visible="False" CssClass="validation">This user already exists!</asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="User name is required" CssClass="validation" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
        </div>


        <div class="formsection">
            <div class="pdleft">Password</div>
            <div class="pdright">
                <asp:TextBox ID="txtPassword" runat="server" MaxLength="50" TextMode="Password" AutoComplete="off"></asp:TextBox>
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPassword" ID="RegularExpressionValidator3" CssClass="validation" ValidationExpression = "^[\s\S]{8,50}$" runat="server" ErrorMessage="Password minimum is 8 characters. "></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" CssClass="validation" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

         <div class="formsection">
            <div class="pdleft">Confirm Password</div>
            <div class="pdright">
                <asp:TextBox ID="txtPassword2" runat="server" MaxLength="50" TextMode="Password" AutoComplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword2" ErrorMessage="Confirm your password. " CssClass="validation" Display="Dynamic"></asp:RequiredFieldValidator>
                   <asp:CompareValidator ID="CompareValidator1" runat="server"      ControlToValidate="txtPassword2"
    CssClass="validation"
     ControlToCompare="txtPassword"
     ErrorMessage="Passwords do not match!" 
     ToolTip="Password must be the same" />
            </div>
        </div>

         <div class="formsection">
        <div class="pdleft">&nbsp;</div>
        <div class="pdright">
            <asp:Button runat="server" Text="Add" ID="Add" CssClass="addbutton"/>
        </div>
    </div>

    </div>

   
</asp:Content>

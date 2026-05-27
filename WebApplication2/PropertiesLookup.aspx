<%@ Page   Title="Properties" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="PropertiesLookup.aspx.vb" Inherits="InvoTechLicensingApp.PropertiesLookup" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <style>
        /*hide read only fields if display is small*/
        @media all and (max-width: 800px) {
            table td:nth-child(3)
            , th:nth-child(3)
            , td:nth-child(7)
            , th:nth-child(7)
            , td:nth-child(9)
            , th:nth-child(9) {display:none;}
        }
    </style>
    <asp:Panel DefaultButton="btnSearch" runat="server">

   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>" SelectCommand="select * from products"></asp:SqlDataSource>

    
        <asp:Button ID="Add" Text="Add" runat="server" CssClass="addbutton" />
  

    <div>
        <asp:TextBox runat="server" placeholder="Customer" ID="txtSearch">        </asp:TextBox> <asp:Button text="Search" ID="btnSearch" runat="server" CssClass="searchbutton"   />
        <asp:Button text="Show All" ID="btnShowall" runat="server" CssClass="searchbutton"  />
        
    </div>


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%" BorderColor="White" BorderStyle="Solid" BorderWidth="1px">
        <Columns>


            <asp:TemplateField HeaderText="Customer&lt;br /&gt;Code">
                <EditItemTemplate>
                    <asp:Label ID="lblCustomerCode" runat="server" Text='<%# Eval("customercode") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCustomerCode" runat="server" Text='<%# Bind("customercode") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Product Code">
                <EditItemTemplate>

                    <asp:DropDownList ID="ddlProductCode" runat="server"
                        DataSourceID="SqlDataSource1" DataTextField="productName" DataValueField="productCode"
                        SelectedValue='<%# Bind("productCode") %>'>
                    </asp:DropDownList>


                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblProductCode" runat="server" Text='<%# Bind("productName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="productVersion" HeaderText="Version" ReadOnly="True">
            <HeaderStyle Width="50px" />
            <ItemStyle Width="50px" />
            </asp:BoundField>

            <asp:TemplateField HeaderText="Customer">
                <EditItemTemplate>
                    <asp:TextBox ID="txtCustomer" runat="server" Text='<%# Bind("customer") %>' Width="100%" MaxLength="50"></asp:TextBox>
                    <asp:Label ID="lblCustomer" runat ="server" Text='<%# Bind("customer") %>' Visible="false"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCustomer" runat="server" Text='<%# Bind("customer") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="gridheader" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="License">
                <EditItemTemplate>
                    <asp:TextBox ID="txtLicense" runat="server" Text='<%# Bind("License") %>' Width="100%" MaxLength="50"></asp:TextBox>
                    <asp:Label ID="lblLicense" runat="server" Text='<%# Bind("License") %>'  Visible="false"></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLicense" runat="server" Text='<%# Bind("License") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100%" />
                <HeaderStyle CssClass="gridheader" HorizontalAlign="Center" Width="20%" />
                <ItemStyle Width="20%" />
            </asp:TemplateField>

          <asp:TemplateField HeaderText="Expiration Date">
                <EditItemTemplate>
                    <asp:Label ID="lblExpires" runat="server" Text='<%# Eval("expirationdate", "{0:d}") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblExpires" runat="server" Text='<%# Bind("expirationdate", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:BoundField DataField="ValidationDate" HeaderText="Validation<br />Date (PST)" ReadOnly="True" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Center" CssClass="colValidationDate" Width="100px" />
                <ControlStyle CssClass="gridheader" />
                <HeaderStyle CssClass="gridheader" HorizontalAlign="Center" Width="100px" />
            </asp:BoundField>

            <asp:TemplateField HeaderText="On Hold">
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBoxHold" runat="server" Checked='<%# Bind("onhold") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("onhold") %>' Enabled="false" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:BoundField DataField="ipaddress" HeaderText="Last IP Address" ReadOnly="True">
                <HeaderStyle CssClass="gridheader" HorizontalAlign="Center" Width="10%" />
                <ItemStyle HorizontalAlign="Center" CssClass="colIpaddress" Width="10%" />
            </asp:BoundField>

            <asp:TemplateField HeaderText="Locale" ItemStyle-Width="100px" HeaderStyle-Width="100px">
                <EditItemTemplate>
                    <asp:TextBox ID="txtLocale" runat="server" Text='<%# Bind("locale") %>' Width="75px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLocale" runat="server" Text='<%# Bind("locale") %>'></asp:Label>
                </ItemTemplate>

                <HeaderStyle Width="100px"></HeaderStyle>

                <ItemStyle Width="100px"></ItemStyle>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                <HeaderStyle CssClass="gridheader" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>

            <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete?'); "></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle CssClass="gridheader" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="gvheader" />
        <RowStyle CssClass="gvrow" />
    </asp:GridView>


    
    </asp:Panel>



</asp:Content>

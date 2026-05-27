<%@ Page Title="InvoTech Licensing" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="InvoTechLicensingApp._Default" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
      
       
           
         <asp:Login ID="Login1" runat="server" OnAuthenticate= "ValidateUser" LoginButtonText="Login" TitleText="InvoTech Licensing" CssClass="login"  EnableViewState="true" DisplayRememberMe="False">
             <LoginButtonStyle CssClass="logintitle" />
             <TextBoxStyle Width="200px" />
               <TitleTextStyle CssClass="logintitle" />
               </asp:Login>               
           
           

</asp:Content>

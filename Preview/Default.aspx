<%@ Page Title="Preview" Language="VB" MasterPageFile="~/Preview/Preview.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Preview_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<style type="text/css">
    .landingcontainer 
    {
      position:relative;
      width:100%;
      margin: 20px 60px;  
    }
</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="landingcontainer">
    <div id="pagecontent">
        <div runat="server" id="contentDiv">
        </div>
    </div>
    </div>


</asp:Content>


<%@ Page Title="" Language="VB" MasterPageFile="~/Mobile.master" AutoEventWireup="false" CodeFile="Mobile_Content.aspx.vb" Inherits="Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">

    <h2 runat="server" id="pageTitle" class="pageTitle"></h2>

    <center>
        <div class="pageContent" id="pageContent" runat="server"></div>
    </center>
                
</asp:Content>


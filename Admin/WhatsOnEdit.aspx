<%@ Page Title="Edit What's On" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="WhatsOnEdit.aspx.vb" Inherits="Admin_WhatsOnEdit" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

<script type="text/javascript">
    function CuteEditor_FilterHTML(editor, code) {
        return code.split("<div>&nbsp;</div>").join("");
    }

    function CuteEditor_FilterCode(editor, code) {
        return code.split("<div>&nbsp;</div>").join("");
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div class="pageEditDiv">

    <table width="100%">
        <tr>
            <td valign="top">
                <asp:Label ID="titleLabel" runat="server" Text="Title:"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="titleTextBox" runat="server" CssClass="CMS_SecurityTB"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label1" runat="server" Text="Summary:"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="summaryTextBox" runat="server" CssClass="CMS_SecurityTB"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="2">
                <asp:Label Font-Bold="true" runat="server" Text="Leave the below dropdown as '- SELF -' and add some content to the editor before saving to link the item in What's On to the newly created page.
                Or, choose another page to link to."></asp:Label>
            </td>            
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="pageLabel" runat="server" Text="Read More Link:"></asp:Label>
            </td>
            <td valign="top">
                <asp:DropDownList ID="linkPageDD" runat="server" DataSourceID="sqlReadMore" DataValueField="page_id" DataTextField="title" Width="250px"/>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="alwaysLabel" runat="server" Text="Always Show?:"></asp:Label>
            </td>
            <td valign="top">
                <asp:CheckBox ID="alwaysChk" runat="server" />
            </td>
        </tr>
    </table>
 </div>

<br />

<center>        
    <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="button"/>                       
    <p><strong>Leave the below editor blank if you have chosen an already created page for the 'Read More Link'.</strong></p>
    <asp:Label ID="errorLabel" runat="server" Font-Bold="true"></asp:Label>
</center>
<br />

<br />

<div id="currentContent">
    <CE:Editor ID="contentEditor" runat="server" Width="89%" Height="500px" BorderStyle="double" BorderWidth="4px" BorderColor="Black" 
    EditorOnPaste="PasteCleanHTML" ThemeType="Office2007"
    CleanUpHTMLCode="True" CleanUpMicrosoftWordHTML="True"/>
</div>

    <asp:SqlDataSource ID="sqlReadMore" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="proc_CMS_SEL_Page_Names" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

</asp:Content>


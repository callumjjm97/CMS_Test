<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Pages.aspx.vb" MasterPageFile="~/Admin/Admin.Master" Inherits="Pages" Title="Pages" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<script src="../tinymce/js/tinymce/tinymce.min.js"></script>
<script src="../tinymce/js/tinymce/themes/modern/theme.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        tinymce.init({
            selector: '.tinymce',  // change this value according to your HTML
            plugins: ['advlist autolink lists link image charmap print preview anchor textcolor',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table contextmenu paste code help wordcount table'],
            a_plugin_option: true,
            a_configuration_option: 400,
            menubar: false,
            toolbar: 'insert | undo redo |  formatselect | bold italic backcolor  | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent table | removeformat | help | pagebreak code preview ',
            plugin_preview_width: 1000,
            code_dialog_width: 1000,
            height: 600
        });
    });

    function addNew() {
        document.getElementById("newPageDiv").style.display = "block";
        document.getElementById("fadedDiv").style.display = "block";

        document.getElementById("<%= newpageTextBox.ClientID%>").focus();

        return false;
    }

    function cancelNew() {
        document.getElementById("newPageDiv").style.display = "none";
        document.getElementById("fadedDiv").style.display = "none";

        document.getElementById("<%= newpageTextBox.ClientID%>").value = '';
        return false;
    }

    function showPreview() {
        //AR 27 Jul 2017 - 134861: Also use id in Preview
        var page_id = document.getElementById("<%= pageIdHF.ClientID %>").value;
        var url = '../Preview/default.aspx?name=' + document.getElementById("<%= urlTextBox.ClientID %>").value + "&id=" + page_id;
        window.open(url);

        return false;
    }

    function updateCheck(control) {

        controlText = control.value;
        controlText = controlText.toLowerCase();

        return confirm("Are you sure you want to " + controlText + " this page ?");
    }

    function deleteCheck(control) {

        controlText = control.value;
        controlText = controlText.toLowerCase();

        return confirm("Are you sure you want to " + controlText + " this page ? The page and all of its contents cannot be recovered.");
    }

    function urlchange(control) {

        var oldurl = document.getElementById("<%= urlStartLabel.ClientID %>").innerHTML;

        var start = oldurl.lastIndexOf('/') + 1;

        var newurl = oldurl.substring(0, start);

        var newname = control.value;

        newurl = newurl + newname;

        document.getElementById("<%= urlStartLabel.ClientID %>").innerHTML = newurl;
    }

    function CuteEditor_FilterHTML(editor, code)
    {
        return code.split("<div>&nbsp;</div>").join("");
    }

    function CuteEditor_FilterCode(editor, code)
    {
        return code.split("<div>&nbsp;</div>").join("");
    }

</script>

    <asp:HiddenField ID="selectedPageHF" runat="server" EnableViewState="true" />
    <asp:HiddenField ID="loginIdHF" runat="server" EnableViewState="true" />
    <asp:HiddenField ID="pageIdHF" runat="server" EnableViewState="true" Value="1" />
    
    <div class="pageEditDiv">

    <table width="100%">
        <tr>
            <td valign="top">
                <asp:Label ID="titleLabel" runat="server" Text="Page Title:"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="titleTextBox" runat="server" CssClass="CMS_SecurityTB"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="urlLabel" runat="server" Text="Page URL:"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="urlTextBox" runat="server" CssClass="CMS_SecurityTB" onkeyup="urlchange(this)"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="preUrlLabel" runat="server" Text="Pre-Defined URL (Optional): Copy & Paste"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="preUrlTextBox" runat="server" CssClass="CMS_SecurityTB"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <a id="urlAnchor" runat="server" href="">
                <asp:Label ID="urlStartLabel" runat="server" Text=""></asp:Label>
                </a>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="keywordsLabel" runat="server" Text="Keywords:"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="keywordsTextBox" runat="server" CssClass="CMS_SecurityTB_Mulit" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="descLabel" runat="server" Text="Description:"></asp:Label>
            </td>
            <td valign="top">
                <asp:TextBox ID="descTextBox" runat="server" CssClass="CMS_SecurityTB_Mulit" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="statusLabel" runat="server" Text="Page Status:"></asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="statusTextLabel" runat="server" Text="" CssClass="CMS_SecurityTB"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="menuLabel" runat="server" Text="Show in Menu:"></asp:Label>
            </td>
            <td valign="top">
                <asp:CheckBox ID="menuCheckBox" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="parentLabel" runat="server" Text="Has Parent Page:"></asp:Label>
            </td>
            <td valign="top">
                <asp:DropDownList ID="parentPageDD" runat="server" DataSourceID="sqlParent" DataValueField="page_id" DataTextField="title" Width="250px"/>
            </td>
        </tr>
    </table>
    </div>
    <br />
    <center>
        <asp:Button ID="newButton" runat="server" Text="Add New" CssClass="button" OnClientClick="return addNew()" />
        <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="button" />
        <asp:Button ID="previewButton" runat="server" Text="Preview" CssClass="button" OnClientClick="return showPreview()" />
        <asp:Button ID="publishButton" runat="server" Text="Publish" CssClass="button" OnClientClick="return updateCheck(this)" />
        <asp:Button ID="unpublishButton" runat="server" Text="Unpublish" CssClass="button" OnClientClick="return updateCheck(this)" />
        <asp:Button ID="revertButton" runat="server" Text="Revert" CssClass="button" OnClientClick="return updateCheck(this)" />
        <%--AR 9 Feb 2016 - 105074 - Delete page entirely --%>
        <asp:Button ID="deleteButton" runat="server" Text="Delete" CssClass="button" OnClientClick="return deleteCheck(this)"/>
    </center>
    <br />
    <center>
    <div id="currentContent" style="display: inline-block; width:85%;">
        <textarea id="ContentTA" runat="server" class="tinymce" style="width:100%;"/>
    </div>
    </center>
    
    <div id="newPageDiv" class="newPageDiv">
        <asp:Label ID="newpageLabel" runat="server" Text="New page name"></asp:Label>
        &nbsp;
        <asp:TextBox ID="newpageTextBox" runat="server" CssClass="CMS_SecurityTBnew"></asp:TextBox>

        <br /><br />
        <center>
        <asp:Button ID="saveNewButton" runat="server" CssClass="button" Text="Save" />
        <asp:Button ID="cancelNewButton" runat="server" CssClass="button" Text="Cancel" OnClientClick="return cancelNew()" />
        </center>
    </div>

    <div id="fadedDiv" class="fadedDiv">
    </div>
    
    <asp:SqlDataSource ID="sqlstatus" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="proc_CMS_Get_Page_Status" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlParent" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="proc_CMS_Get_Page_Names" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="page_id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlSchedule" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="proc_CMS_Get_Schedules" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

</asp:Content>
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NewEditor.aspx.vb" MasterPageFile="~/Admin/Admin.Master" Inherits="NewEditor" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="../tinymce/js/tinymce/tinymce.min.js"></script>
<script type="text/javascript" language="javascript">

<script type="text/javascript">
    tinymce.init({
        selector: ".tinymce",
        theme: "modern",
        menubar: false,
        resize: false,
        statusbar: false,
        plugins: ["advlist autolink lists charmap preview hr anchor",
                "pagebreak code nonbreaking table contextmenu directionality paste"],
        toolbar1: "styleselect | bold italic underline | pagebreak preview | undo redo",
        toolbar2: "alignleft aligncenter alignright alignjustify | bullist numlist outdent indent"
    });
    </script>
</script>


<%--    <script src="../tinymce/js/tinymce/tinymce.min.js" type="text/javascript"></script>
    <script>
        tinymce.init({
            selector: 'textarea',  // change this value according to your HTML
            plugins: ['advlist autolink lists link image charmap print preview anchor textcolor',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table contextmenu paste code help wordcount'],
            a_plugin_option: true,
            a_configuration_option: 400,
            menubar: false,
            toolbar: 'insert | undo redo |  formatselect | bold italic backcolor  | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | removeformat | help | pagebreak code preview ',
            plugin_preview_height: 1000,
            code_dialog_width: 1000
        });
    </script>--%>

        <asp:TextBox ID="htmlEditorTxt" runat="server"
                TextMode="MultiLine" Rows="20" Style="width: 95%" CssClass="tinymce" />


</asp:Content>

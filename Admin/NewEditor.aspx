<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NewEditor.aspx.vb" MasterPageFile="~/Admin/Admin.Master" Inherits="NewEditor" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<script src="../tinymce/js/tinymce/tinymce.min.js"></script>
<script src="../tinymce/js/tinymce/themes/modern/theme.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
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
        });
  </script>
    <center>
    <div style="display: inline-block; width:50%; height:40%;" />
    <textarea id="ContentTA" runat="server" />
    </center>

</asp:Content>

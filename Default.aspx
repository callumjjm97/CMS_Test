<%@ Page Language="VB" AutoEventWireup="false" Debug="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <script src="/tinymce/js/tinymce/tinymce.min.js" type="text/javascript"></script>
    <script>
        tinymce.init({
            selector: 'textarea',  // change this value according to your HTML
            plugins: ['advlist autolink lists link image charmap print preview anchor textcolor',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table contextmenu paste code help wordcount table'],
            a_plugin_option: true,
            a_configuration_option: 400,
            menubar: false,
            toolbar: 'insert | undo redo |  formatselect | bold italic backcolor table  | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | removeformat | help | pagebreak code preview ',
            plugin_preview_height: 1000,
            code_dialog_width: 1000,
            images_upload_url: 'postAcceptor.php',

            // we override default upload handler to simulate successful upload
            images_upload_handler: function (blobInfo, success, failure) {
                setTimeout(function () {
                    // no matter what you upload, we will turn it into TinyMCE logo :)
                    success('http://moxiecode.cachefly.net/tinymce/v9/images/logo.png');
                }, 2000);
            },

            init_instance_callback: function (ed) {
                ed.execCommand('mceImage');
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <center>
            <div style="margin-top:2%;">
                <textarea id="myTextArea" runat="server" />
            </div>
            <div class="row" style="margin-top:2%; margin-bottom:2%;">
                <div class="col-md-4">
                    <asp:Button runat="server" ID="SubmitBtn" CssClass="btn btn-default pull-left" Text="Submit" />
                </div>
            </div>
            <div class="row">
                <div class="col-lrg-12">
                    <div class="jumbotron" id="DisplayTxt" runat="server">
                    </div>
                </div>
            </div>
            </center>
        </div>
    </form>
</body>
</html>

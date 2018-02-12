<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="FileManager.aspx.vb" Inherits="Admin_FileManager" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

<script type="text/javascript">

    function confirmDelete() {
        var count = document.getElementById("<%= countHF.ClientID %>").value;
        if(confirm("You have selected " + count + " files to delete. Are you sure? The files cannot be recovered. Make sure to remove any references to the files in content pages.")){            
            return true;
        } else {
            return false;
        }
    }

    function deleteFolder(control) {
        return confirm("Are you sure you want to delete this folder? The folder and all of its contents, including files and other folders, will also be deleted and cannot be recovered. Any links to files on page content will still be there.");
    }

    function deleteFile(control, filename) {
        var soapHeader = '<?xml version="1.0" encoding="utf-8"?>'

        soapHeader += '<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">'
        soapHeader += '<soap:Body><SaveDevSupport xmlns="http://tempuri.org/" /></soap:Body></soap:Envelope>'

        var url = window.location.href;

        var postUrl = url.substring(0, url.lastIndexOf("/")) + '/FileLocations.asmx';
        var soapActionUrl;

        soapActionUrl = 'http://tempuri.org/GetFileLocs';

        var xmlhttp = null;

        if (window.XMLHttpRequest) {
            xmlhttp = new XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        else {
            xmlhttp = false;
        }

        var parser;
        var xmlDoc;

        if (xmlhttp) {
            xmlhttp.open('POST', postUrl, false);
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4) {
                    if (xmlhttp.status == 200) {
                        if (window.DOMParser) {
                            parser = new DOMParser();
                            xmlDoc = parser.parseFromString(xmlhttp.responseText, "text/xml");
                            
                        }
                    }
                }
            }
            xmlhttp.setRequestHeader('Content-Type', 'text/xml; charset=utf-8');
            //xmlhttp.setRequestHeader("Host", "localhost");
            xmlhttp.setRequestHeader("SOAPAction", soapActionUrl);
            //xmlhttp.setRequestHeader("Content-Length", soapHeader.length);
            xmlhttp.setRequestHeader("Filename", filename);
            xmlhttp.send(soapHeader);

            debugger;
            return confirm("Are you sure you want to delete this file? The file cannot be recovered and you will have to remove the link from any page content.\n\nPages where this file is used:\n" + xmlDoc.getElementsByTagName("GetFileLocsResult")[0].childNodes[0].nodeValue);

        }
        else {
            alert("XMLHTTP Error");
            return false;
        }
    }

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<asp:HiddenField ID="renameHF" runat="server" Value="" />
<asp:HiddenField ID="removeHF" runat="server" Value="0" />
<asp:HiddenField ID="successHF" runat="server" Value="0" />
<asp:HiddenField ID="checkedHF" runat="server" Value="" />
<asp:HiddenField ID="countHF" runat="server" Value="0" />

<div style="width:80%; margin-left:150px; ">
<h2>File Manager</h2>
<center>
    <asp:Label style="margin-right:10px;" runat="server" Font-Bold="true" Text="Add New File: " Font-Size="Medium"></asp:Label>
    <asp:FileUpload CssClass="button" ID="FileUpload1" runat="server" style="cursor:pointer;" />
    <asp:Button CssClass="button" ID="btnUpload" runat="server" Text="Upload" OnClick="UploadFile" />
    <asp:Label ID="errorLbl" runat="server" ForeColor="Red" Text="" Font-Size="Large"></asp:Label>
</center>
<hr />
<br />
<asp:Label ID="locLabel" runat="server" Font-Size="Medium" Text=""></asp:Label>
<br />
<asp:Label ID="copyLabel" runat="server" Font-Size="Medium" Text="" ForeColor="Blue"></asp:Label>
<br /><br />
<div class="dirBox">
    <asp:ImageButton Width="50px" Height="50px" runat="server" ImageUrl="../images/back.png" ImageAlign="Top" ID="backBtn"
    ToolTip="Go back to Uploads folder" OnClick="BackToUploads"/>
</div>
<asp:Repeater ID="dirRepeater" runat="server">
    <ItemTemplate>
        <div class="dirBox">
            <asp:ImageButton Width="32px" Height="32px" runat="server" ImageUrl="../images/folder.png" ImageAlign="Left" ID="dirBtn"
            ToolTip='<%# Eval("Text") %>' CommandArgument='<%#Eval("Value") %>' OnClick="ChangeDir" />
            <br /><br />
            <asp:Label runat="server" ID="dirname" Text='<%# Eval("Text") %>'></asp:Label>
        </div>
    </ItemTemplate>
</asp:Repeater>
<br /><br />
<center>
    <asp:Button runat="server" CssClass="button" ID="addNewBtn" Text="Add New Folder" />
    <asp:Button runat="server" CssClass="button" ID="deleteBtn" Text="Delete Folder" OnClientClick="return deleteFolder(this)" />
    <asp:Button runat="server" CssClass="button" ID="pasteBtn" Text="Paste File into Folder" />
</center>
<br />
<hr />
<asp:Repeater ID="filesRepeater" runat="server">
    <ItemTemplate>
        <div class="fileBox" id="fileBox" runat="server">
            <div class="filename">
                <asp:Label runat="server" ID="filename" Text='<%# Eval("Text") %>'></asp:Label>
                <asp:HiddenField runat="server" ID="fileHF" Value='<%# Eval("Value") %>' />
             </div>
                <div class="fileBtns">
                    <asp:ImageButton CssClass="fileImgs" ImageUrl="../images/download.png" runat="server"  
                    CommandArgument='<%# Eval("Value") %>' ID="lnkDownload" ToolTip="Download File"/>
                    <asp:ImageButton CssClass="fileImgs" ImageUrl="../images/edit.png" runat="server"  
                    CommandArgument='<%# Eval("Value") %>' ID="lnkEdit" OnClick="RenameFile" ToolTip="Rename File"/>
                    <asp:ImageButton CssClass="fileImgs" ImageUrl="../images/copy.png" runat="server"  
                    CommandArgument='<%# Eval("Value") %>' ID="lnkCopy" OnClick="CopyFile" ToolTip="Copy File"/>
                    <asp:ImageButton CssClass="fileImgs" ImageUrl="../images/delete.png" runat="server"
                    CommandArgument='<%# Eval("Value") %>' ID="lnkDelete" OnClick="DeleteFile" ToolTip="Delete File" OnClientClick='<%# Bodger(Eval("Text")) %>'/>
                    <asp:CheckBox runat="server" ID="deleteCheck" CssClass="checkbox" OnCheckedChanged="CheckedBox" AutoPostBack="true"/>
                </div>           
        </div>
    </ItemTemplate>
</asp:Repeater>
</div>

    <div id="newPageDiv" class="newPageDiv" runat="server">
        <asp:Label ID="newpageLabel" runat="server" Text="New file name (no extension needed)"></asp:Label>
        &nbsp;
        <asp:TextBox ID="newpageTextBox" runat="server" CssClass="CMS_SecurityTBnew"></asp:TextBox>
        <br />
        <br />
        <center>
            <asp:Button ID="saveNewButton" runat="server" CssClass="button" Text="Rename" OnClick="ConfirmRename" />
            <asp:Button ID="cancelNewButton" runat="server" CssClass="button" Text="Cancel" OnClick="CancelRename" />
        </center>
    </div>

    <div id="fadedDiv" class="fadedDiv" runat="server">
    </div>

    <div id="newDirDiv" class="newPageDiv" runat="server">
        <asp:Label ID="newdirLabel" runat="server" Text="New folder name"></asp:Label>
        &nbsp;
        <asp:TextBox ID="newdirTextBox" runat="server" CssClass="CMS_SecurityTBnew"></asp:TextBox>
        <br />
        <br />
        <asp:Label runat="server" ID="errorLabel" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
        <br />
        <br />
        <center>
            <asp:Button ID="saveDirButton" runat="server" CssClass="button" Text="Save" OnClick="ConfirmCreate" />
            <asp:Button ID="cancelDirButton" runat="server" CssClass="button" Text="Cancel" OnClick="CancelCreate" />
        </center>
        <br />
    </div>

    <div runat="server" id="selectionDiv" class="selectionDiv">
        <asp:Button runat="server" ID="deleteAllBtn" CssClass="button" Text="Delete Selected" OnClientClick="return confirmDelete()" />
    </div>

</asp:Content>


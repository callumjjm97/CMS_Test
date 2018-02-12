<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CMS Login</title>
    <link rel="StyleSheet" href="../Styles/Admin.css" type="text/css" />
</head>
<body class="login">

<script type="text/javascript">

    function check() {

        if (document.getElementById("txtUserName").value == '') {
            document.getElementById("txtUserName").style.backgroundColor = "red";
            return false;
        }
        else if( document.getElementById("txtUserPass").value == ''){
            document.getElementById("txtUserPass").style.backgroundColor = "red";
            return false;
        }
        else {
            return true;
        }

    }
</script>

    <form id="Form1" runat="Server" action="">
    <div class="loginBox">
        <center>
            <asp:Label ID="Label1" runat="server" Text="Content Management" Style="font-family: Arial; font-size: 28px; font-weight: bold;"></asp:Label>
        </center>
        <br />
        <table width="60%" style="margin-left: 20%; margin-right: 20%">
            <tr>
                <td>
                    <asp:Label ID="userLabel" runat="server" Text="User Name" Style="font-family: Arial; font-size: 14px; font-weight: Normal;"></asp:Label>
                </td>
                <td>
                    <input id="txtUserName" type="text" runat="server" style="width: 150px" />
                   
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label Style="font-family: Arial; font-size: 14px; font-weight: Normal;" ID="passwordLabel" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <input id="txtUserPass" type="password" runat="server" style="width: 150px" />
       
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <img src="../Captcha.ashx" alt="Captcha"/>
                </td>
            </tr>
            <tr>

                <td colspan="2" align="center">
                    <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <center>
            <asp:Button ID="loginLinkButton" runat="server" Text="Login" CssClass="button" OnClientClick="return check()"></asp:Button>
            <br />
           <asp:Label ID="errorlabel" runat="server" Style="color: #B80C1C" Font-Name="Arial" Font-Size="10"  Text="" />
       <br />
        </center>
    </div>
    </form>
</body>
</html>

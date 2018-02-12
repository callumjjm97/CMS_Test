<%@ Page Title="Security" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="Security.aspx.vb" Inherits="Admin_Security" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<script type="text/javascript">

    function checkDetails() {

        var fail = 0;
        var warningmessage = 'Please address the following: ';

         <% if not userFV.FindControl("passwordTextBox") is nothing  %>

        var password1 = document.getElementById("<%=CType(userFV.FindControl("passwordTextBox"), TextBox).ClientID %>").value;
        var password2 = document.getElementById("<%=CType(userFV.FindControl("confirmpasswordTextBox"), TextBox).ClientID %>").value;

        if (password1 != password2 && password1 != '')
        {
            fail = 1;
            warningmessage = warningmessage + ' Passwords do not match'
        }

        if (fail == 1) {
            alert(warningmessage);
            return false;
        }
        else {
            return true;
        }

         <%end if %>
    }


    function permissionSave(id)
    {
        var permissions = document.getElementById("<%= permissionsHF.ClientID %>").value;

        if (permissions.indexOf(", " + id) != -1)
        {
            document.getElementById("<%= permissionsHF.ClientID %>").value = permissions.replace(", " + id,"");
        }
        else
        {
            document.getElementById("<%= permissionsHF.ClientID %>").value = document.getElementById("<%= permissionsHF.ClientID %>").value + ', ' + id;
        }
    }

     function addNew() {
        document.getElementById("newUserDiv").style.display = "block";
        document.getElementById("fadedDiv").style.display = "block";

        document.getElementById("<%= newuserTextBox.ClientID%>").focus();

        return false;
    }

    function cancelNew() {
        document.getElementById("newUserDiv").style.display = "none";
        document.getElementById("fadedDiv").style.display = "none";

        document.getElementById("<%= newuserTextBox.ClientID%>").value = '';

        return false;
    }

    function ParentClick(control, table)
    {    
        var tGrid = table;
        for (var i = 1; i < tGrid.rows.length; ++i)
        {
            tGrid.rows[i].cells[0].childNodes[0].childNodes[0].checked = control.checked;
            var inner = tGrid.rows[i].cells[0].childNodes[0].innerHTML;
            var start = inner.indexOf('permissionSave(') + 15;
            var end = inner.indexOf('type') - 4;

            inner = inner.substring(start, end);
            permissionSave(inner);
        }
    }

</script>
<script type="text/javascript">
    $(document).ready(function () {
        var newpass = document.getElementById("<%= newpassTextBox.ClientID%>");
        var conpass = document.getElementById("<%= confirmpassTextBox.ClientID %>");
        var password = document.getElementById("<%= passwordHF.ClientID %>");
        var conpassword = document.getElementById("<%= conpasswordHF.ClientID %>");
        $(conpass).keyup(function () {
            var conpswd = $(this).val();
            var newpswd = $(newpass).val();
            if (newpswd != conpswd) {
                $('#no_match').show();
                conpassword.value = "0";
            } else {
                $('#no_match').hide();
                conpassword.value = "1";
            }
        });
        $(newpass).keyup(function () {
            // set password variable
            var pswd = $(this).val();

            //validate the length
            if (pswd.length < 7) {
                $('#length').removeClass('valid').addClass('invalid');
                password.value = "0";
            } else {
                $('#length').removeClass('invalid').addClass('valid');
                password.value = "1";
            }

            //validate letter
            if (pswd.match(/[A-z]/)) {
                $('#letter').removeClass('invalid').addClass('valid');
                password.value = "1";
            } else {
                $('#letter').removeClass('valid').addClass('invalid');
                password.value = "0";
            }

            //validate capital letter
            if (pswd.match(/[A-Z]/)) {
                $('#capital').removeClass('invalid').addClass('valid');
                password.value = "1";
            } else {
                $('#capital').removeClass('valid').addClass('invalid');
                password.value = "0";
            }

            //validate number
            if (pswd.match(/\d/)) {
                $('#number').removeClass('invalid').addClass('valid');
                password.value = "1";
            } else {
                $('#number').removeClass('valid').addClass('invalid');
                password.value = "0";
            }
        }).focus(function () {
            $('#pswd_info').show();
        }).blur(function () {
            $('#pswd_info').hide();
        });

    });
</script>

<asp:HiddenField ID="permissionsHF" runat="server" Value="" />
<asp:HiddenField ID="passwordHF" runat="server" Value="0" />
<asp:HiddenField ID="conpasswordHF" runat="server" Value="0" />

    <div class="CMS_userList">
        <center>
            <asp:Button ID="newButton" runat="server" Text="Add New" CssClass="button" OnClientClick="return addNew()" />
        </center>
        <br />
        <asp:GridView ID="userGV" runat="server" DataSourceID="Sqlusers" AutoGenerateColumns="false" Width="100%">
            <Columns>
                <asp:BoundField DataField="login_id" HeaderText="login_id" SortExpression="login_id">
                    <HeaderStyle CssClass="HiddenColumn" />
                    <ItemStyle CssClass="HiddenColumn" />
                </asp:BoundField>
                <asp:BoundField DataField="names" HeaderText="Name" SortExpression="names" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="CMS_userDetail">
        <asp:FormView ID="userFV" runat="server" DataSourceID="sqluserdetail" DefaultMode="Edit" Width="500px">
            <EditItemTemplate>
                <asp:HiddenField ID="loginidHF" runat="server" Value='<%# Bind("login_Id") %>' />
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="loginnameLabel" runat="server" Text="Login Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="loginnameTextBox" runat="server" Text='<%# Bind("login_name") %>' CssClass="CMS_SecurityTB"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="nameLabel" runat="server" Text="Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("full_name") %>' CssClass="CMS_SecurityTB"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="emailLabel" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="emailTextBox" runat="server" Text='<%# Bind("email_address") %>' CssClass="CMS_SecurityTB"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="changepassLabel" runat="server" Text="Change Password" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="passwordLabel" runat="server" Text="Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="passwordTextBox" runat="server" Text="" CssClass="CMS_SecurityTB"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="confirmpasswordLabel" runat="server" Text="Confirm Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="confirmpasswordTextBox" runat="server" Text="" CssClass="CMS_SecurityTB"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lastloginLabel" runat="server" Text="Last Login" Font-Bold="true"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="logindateLabel" runat="server" Text='<%# Bind("last_Login") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="roleLabel" runat="server" Text="User Role"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="roleDD" runat="server" DataSourceID="sqlRoles" DataValueField="role_id" DataTextField="role_desc" SelectedValue='<%# Bind("role_id") %>' CssClass="CMS_SecurityTB">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="deletedLabel" runat="server" Text="Deleted"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="deletedCheckBox" runat="server" Checked='<%# Bind("Deleted") %>' />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
        <br />
        <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="button" OnClientClick="return checkDetails()" Visible="false"/>
        <br />
        <br />
        <asp:Label ID="permLabel" runat="server" Text="Page Permissions" Visible="false"></asp:Label>
        <br />
        <br />
        <asp:Panel ID="permPanel" runat="server">
        </asp:Panel>
    </div>

    <div id="newUserDiv" class="newPageDiv">
    <table>
    <tr>
        <td><asp:Label ID="newpageLabel" runat="server" Text="Login Name"></asp:Label></td>

        <td><asp:TextBox ID="newuserTextBox" runat="server" CssClass="CMS_SecurityTB"></asp:TextBox></td>
        </tr><tr><td></td></tr><tr>
        <td><asp:Label ID="newPassLabel" runat="server" Text="Password"></asp:Label></td>

        <td><asp:TextBox ID="newpassTextBox" runat="server" CssClass="CMS_SecurityTB" type="password"></asp:TextBox></td>
        </tr> <tr>
        <td><asp:Label ID="confirmPassLabel" runat="server" Text="Confirm Password"></asp:Label></td>

        <td><asp:TextBox ID="confirmpassTextBox" runat="server" CssClass="CMS_SecurityTB" type="password"></asp:TextBox></td>
        </tr>
        </table>
        <br />
        <br />
        <div id="pswd_info">
    <h4>Password must meet the following requirements:</h4>
    <ul>
        <li id="letter" class="invalid">At least <strong>one letter</strong></li>
        <li id="capital" class="invalid">At least <strong>one capital letter</strong></li>
        <li id="number" class="invalid">At least <strong>one number</strong></li>
        <li id="length" class="invalid">Be at least <strong>8 characters</strong></li>
    </ul>
</div>
<div id="no_match">
    <h4 class="invalid"><strong>Passwords do not match</strong></h4>
</div>
<br />
<br />
        <center>
            <asp:Button ID="saveNewButton" runat="server" CssClass="button" Text="Save" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="cancelNewButton" runat="server" CssClass="button" Text="Cancel" OnClientClick="return cancelNew()" />
        </center>
        <br />
    </div>

    <div id="fadedDiv" class="fadedDiv">
    </div>
    
    <asp:SqlDataSource ID="Sqlusers" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="proc_CMS_Get_Users" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqluserdetail" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="proc_CMS_Get_UserDetail" SelectCommandType="StoredProcedure">
         <SelectParameters>
            <asp:Parameter Name="login_id" Type="Int32" DefaultValue="-1" />
         </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlRoles" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="proc_CMS_Get_User_Roles" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

</asp:Content>
<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="Events.aspx.vb" Inherits="Admin_Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

    <link rel="stylesheet" media="all" type="text/css" href="http://code.jquery.com/ui/1.10.4/themes/smoothness/jquery-ui.css" />
    
    <link rel="stylesheet" media="all" type="text/css" href="../Styles/jquery-ui-timepicker-addon.css"  />

    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>

    <script type="text/javascript" src="../Scripts/jquery-ui.min.js"></script>

    <script type="text/javascript" src="../Scripts/jquery-ui-timepicker-addon.js"></script>

   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

<script type="text/javascript">

    $(document).ready(function() {
         	        
	        <%if not (eventFV.FindControl("startTextBox") is nothing) then %>

            $('#<%=eventFV.FindControl("startTextBox").ClientID %>').datetimepicker({ dateFormat: "d MM yy" });

            $('#<%=eventFV.FindControl("endTextBox").ClientID %>').datetimepicker({ dateFormat: "d M yy" });
	   	       
	        <%end if%>

            $('#<%=newdateTextBox.ClientID %>').datetimepicker({ dateFormat: "d M yy" });
           
    });
    
    function addNew() {
        document.getElementById("newEventDiv").style.display = "block";
        document.getElementById("fadedDiv").style.display = "block";

        document.getElementById("<%= newdateTextBox.ClientID%>").focus();

        return false;
    }

    function cancelNew() {
        document.getElementById("newEventDiv").style.display = "none";
        document.getElementById("fadedDiv").style.display = "none";

        document.getElementById("<%= newdateTextBox.ClientID%>").value = '';
        return false;
    }

    function Remove() {

        if (confirm("Are you sure you want to remove this event?")) {
            //Set hidden marker to then remove
            document.getElementById("<%=Remove.ClientID %>").value = "1";
        }
        else {
            document.getElementById("<%=Remove.ClientID %>").value = "0";
        }
    }

</script>

<asp:HiddenField ID="Remove" runat="server" Value="0" />


    <div class="CMS_userList">
    <br />
        <center>
            <asp:Button ID="newButton" runat="server" Text="Add New" CssClass="button" OnClientClick="return addNew()" />
        </center>
        <br /><br />
        <asp:GridView ID="eventGV" runat="server" DataSourceID="sqleventList" AutoGenerateColumns="false" ShowHeader="false" Width="100%" RowStyle-ForeColor="Black" SelectedRowStyle-ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="event_id" HeaderText="event_id">
                    <HeaderStyle CssClass="HiddenColumn" />
                    <ItemStyle CssClass="HiddenColumn" />
                </asp:BoundField>
                <asp:BoundField DataField="event_date" HeaderText="Date" SortExpression="event_date" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center"  ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="eventDate"/>
                <asp:BoundField DataField="Event_Desc" HeaderText="Desc" SortExpression="Event_Desc" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="eventDate"/>
            </Columns>
            <EmptyDataTemplate>
                No Events
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    
    <div class="CMS_userDetail" id="CMS_userDetail" runat="server">
        <div class="eventEditDiv">
            <asp:FormView ID="eventFV" runat="server" DataSourceID="sqlevent" DefaultMode="Edit">
                <EditItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="descLabel" runat="server" Text="Event Description"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="descTextBox" runat="server" CssClass="CMS_SecurityTB" Text='<%# Bind("Event_Desc") %>'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="startLabel" runat="server" Text="Start Date/Time"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="startTextBox" runat="server" CssClass="CMS_SecurityTB" Text='<%# Bind("event_from") %>'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="endLabel" runat="server" Text="End Date/Time"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="endTextBox" runat="server" CssClass="CMS_SecurityTB" Text='<%# Bind("event_to") %>'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="homeLabel" runat="server" Text="Show on Home Page"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="homeCheckBox" runat="server" Checked='<%# Bind("ShowOnHome") %>' />
                            </td>
                        </tr>
                    </table>
                </EditItemTemplate>
            </asp:FormView>
            <br />

            <div id="buttonDiv" runat="server" visible="false">
                <center>
                    <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="button" />
                    <asp:Button ID="deleteButton" runat="server" Text="Delete" CssClass="button" OnClientClick="Remove()"/>
                </center>
            </div>
        </div>

    </div>

    <div id="newEventDiv" class="newEventDiv">
        <center>
            <asp:Label ID="Label1" runat="server" Text="New Event"></asp:Label>
        </center>
        <br />
        <table width="100%">
            <tr>
                <td>
                    <asp:Label ID="newdateLabel" runat="server" Text="Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="newdateTextBox" runat="server" CssClass="CMS_SecurityTBnew"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="newdescLabel" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="newdescTextBox" runat="server" CssClass="CMS_SecurityTBnew"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <center>
            <asp:Button ID="saveNewButton" runat="server" CssClass="button" Text="Save" />
            <asp:Button ID="cancelNewButton" runat="server" CssClass="button" Text="Cancel" OnClientClick="return cancelNew()" />
        </center>
    </div>

    <div id="fadedDiv" class="fadedDiv">
    </div>

    <asp:SqlDataSource ID="sqleventList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="proc_Get_Events" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlevent" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="proc_Get_Event_Single" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="event_id" DefaultValue="-1" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

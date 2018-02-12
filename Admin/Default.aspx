<%@ Page Title="Home Page" Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Admin_Default" MasterPageFile="~/Admin/Admin.Master"  %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div id="detaildiv">
       <%-- <div id="notidiv" class="CMS_dashDiv">
            <asp:Label ID="Label1" runat="server" CssClass="CMS_dashHeader">Live Preview</asp:Label>
            <br /><br />
     
            <asp:Image ID="imgScreenShot" runat="server" Height="300" Width="400" Visible = "false" />
        </div>--%>

        
       <center>
        <div id="statusmaindiv" class="CMS_statsDiv">
            <asp:Label ID="statLabel" runat="server" CssClass="CMS_dashHeader">Current Status of the Website</asp:Label>
            <br />
            <br />
            <asp:FormView ID="statusFV" runat="server" DataSourceID="sqldash" CssClass="CMS_dashstats">
                <ItemTemplate>
                    <div id="usersdiv" class="CMS_dash_userDiv" runat="server">
                        <table width="100%" cellpadding="3">
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label2" runat="server" Text="Active Users"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("active_users") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="height: 22px">
                        &nbsp
                    </div>
                    <br />
                    <div id="completediv" class="CMS_dash_pageDiv">
                        <table width="100%" cellpadding="3">
                            <tr id="totPages" runat="server">
                                <td align="left">
                                    <asp:Label ID="Label16" runat="server" Text="Total pages"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" Text='<%# Bind("total_pages") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div id="Div4" style="background-color: silver; height: 1px; width: 100%">
                                        &nbsp
                                    </div>
                                </td>
                            </tr>
                            <tr id="empPages" runat="server">
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" Text="Pages with no content"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("no_content") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div id="linediv" style="background-color: silver; height: 1px; width: 100%">
                                        &nbsp
                                    </div>
                                </td>
                            </tr>
                            <tr id="offPages" runat="server">
                                <td align="left">
                                    <asp:Label ID="Label12" runat="server" Text="Pages offline"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("offline_pages") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div id="Div3" style="background-color: silver; height: 1px; width: 100%">
                                        &nbsp
                                    </div>
                                </td>
                            </tr>                            
                        </table>
                    </div>
                    <div style="height: 22px">
                        &nbsp
                    </div>
                   <%-- <br />
                    <div id="Div1" class="CMS_dash_userDiv" runat="server">
                    <table width="100%" cellpadding="3">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Offline Pages"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("active_users") %>'></asp:Label>
                                </td>
                            </tr>
                    </table>
                    </div>--%>
                </ItemTemplate>
            </asp:FormView>
        </div>
        </center>
    </div>

    
    <asp:SqlDataSource ID="sqldash" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="proc_CMS_Dashboard" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="login_Id" Type="Int32" DefaultValue="-1" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

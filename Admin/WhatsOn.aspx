<%@ Page Title="News" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="WhatsOn.aspx.vb" Inherits="Admin_WhatsOn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

<script type="text/javascript">
    function Remove() {

        if (confirm("Are you sure you want to remove/undelete this item?")) {
            //Set hidden marker to then remove
            document.getElementById("<%=Remove.ClientID %>").value = "1";
        }
        else {
            document.getElementById("<%=Remove.ClientID %>").value = "0";
        }
    }
    function CheckNewPos() {
        document.getElementById("<%= HF_NewPos.ClientID%>").value = prompt("Enter new position:", "");
        return document.getElementById("<%= HF_NewPos.ClientID%>").value != "";
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<asp:HiddenField ID="Remove" runat="server" Value="0" />
<asp:HiddenField ID="HF_NewPos" runat="server" />
<center>
    <h2 style="font-size:24px">News</h2>
    <asp:Button ID="addNewBtn" runat="server" Text="Add New" CssClass="button" />
</center>
<br />

<asp:GridView ID="whatsonGV" runat="server" AutoGenerateColumns="false" DataSourceID="whatsonDS" Width="80%" style="text-align:center;">
    <Columns>
        <asp:BoundField HeaderText="ID" DataField="wo_id" HeaderStyle-CssClass="HiddenColumn" ItemStyle-CssClass="HiddenColumn" />
        <asp:BoundField HeaderText="Title" DataField="wo_title" />
        <asp:BoundField HeaderText="Summary" DataField="wo_summary" />
        <asp:BoundField HeaderText="Read More Link" DataField="read_more" />
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:Label runat="server" Text="Deleted?"></asp:Label>        
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" Checked='<%# Eval("deleted") %>' ID="chkDeleted" Enabled="false"/>
            </ItemTemplate>
        </asp:TemplateField>      
        <asp:BoundField HeaderText="Date Added" DataField="date_added" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="EditBtn" runat="server" ImageUrl="../Images/editsmall.png"
                          AlternateText="Edit" ToolTip="Edit" PostBackUrl='<%# "./WhatsOnEdit.aspx?id=" & Eval("wo_id") %>'
                         Width="25px" Height="25px" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="RemoveBtn" runat="server" ImageUrl="../Images/deletesmall.png"
                          AlternateText="Delete" ToolTip="Delete/Undelete" OnClientClick='return confirm("Are you sure you want to remove/undelete this item?");' OnCommand="RemoveLine"
                          CommandArgument='<%#Eval("wo_id") %>' Width="25px" Height="25px" />
            </ItemTemplate>
        </asp:TemplateField> 
    </Columns>
</asp:GridView>


<asp:SqlDataSource ID="whatsonDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="proc_CMS_SEL_WhatsOn" SelectCommandType="StoredProcedure">
 </asp:SqlDataSource>

</asp:Content>



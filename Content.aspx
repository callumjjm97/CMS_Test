<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Content.aspx.vb" Inherits="Content" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="head" ID="head" runat="server">

<script type="text/javascript">
    $(window).scroll(function () {
        var x = $(document).height();
        var bottom = x - 100;
        var y = $(window).scrollTop();
        if (y >= 540) {
            $(".priTab").css({ position: 'fixed', top: '50px' });
            $(".secTab").css({ position: 'fixed', top: '150px' });
            $(".sixTab").css({ position: 'fixed', top: '250px' });
        } else {
            $(".priTab").css({ position: 'absolute', top: '545px' });
            $(".secTab").css({ position: 'absolute', top: '645px' });
            $(".sixTab").css({ position: 'absolute', top: '745px' });
        }
    });
</script>


</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="content">
    <div class="wrapper">
<center>

<h2 runat="server" id="pageTitle" class="pageTitle"></h2>
</center>
    <div class="contentContainer">

        

        <div class="pageContent" id="pageContent" runat="server">
        </div>
                
    </div>
</div>



    

</asp:Content>

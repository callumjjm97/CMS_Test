<%@ Page Title="Contact Us" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="contact.aspx.vb" Inherits="contact" MaintainScrollPositionOnPostback="true" %>

<asp:Content ContentPlaceHolderID="head" ID="head" runat="server">

</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="content">
    <div class="wrapper">
<center>
<h2>Contact Us</h2>
    <div class="contactContainer">      

        <div style="float:left; width:40.5%; text-align:left;margin-left:125px;"  >
            <h4 style="color:#0664AE">Fill out our Contact Form</h4>
            <hr class="contactHr" />            
            <asp:TextBox ID="nameTxt" runat="server" Width="350px" placeholder="Name*" CssClass="contactTxt"></asp:TextBox>
            <br />            
            <asp:TextBox ID="emailTxt" runat="server" Width="350px" placeholder="Email*" CssClass="contactTxt"></asp:TextBox>
            <br />            
            <asp:TextBox ID="subjectTxt" runat="server" Width="350px" placeholder="Subject*" CssClass="contactTxt"></asp:TextBox>
            <br />            
            <asp:TextBox ID="messageTxt" runat="server" Width="350px" placeholder="Message*" CssClass="contactTxt" TextMode="MultiLine" Rows="3" ></asp:TextBox>
            <br />
            <center>
                <asp:Label ID="errorLabel" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button runat="server" ID="sendBtn" Text="Send Email" CssClass="contactBtn"/>
            </center>
        </div>

        <div style="float:right; width:40.5%; text-align:left;">
            <h4 style="color:#0664AE">Contact Info</h4>
            <hr class="contactHr" />  
            <asp:label ID="Label6" runat="server" Width="350px" CssClass="contactTxt">Servo & Electronic Sales Ltd</asp:label>
            <br />          
            <asp:label ID="Label5" runat="server" Width="350px" CssClass="contactTxt">Connector House, Harden Road, <br />Lydd <br />TN29 9LX</asp:label>
            <br />            
            <asp:label ID="Label2" runat="server" Width="350px" CssClass="contactTxt"><a class="contactemail" href="mailto:info@servoconnectors.co.uk">info@servoconnectors.co.uk</a></asp:label>
            <br />            
            <asp:label ID="Label3" runat="server" Width="350px" CssClass="contactTxt"><a class="contactemail" href="tel:01797322500">01797 322500<a /></asp:label>                        
        </div>
        
        <div style="clear:both"></div> <br />        
        
        <div class="googleMap">
            <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d10053.43739827781!2d0.915051!3d50.95406!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xfc445a5c2a8a0f27!2sServo+Connectors+(A+division+of+Servo+%26+Electronic+Sales+Ltd.)!5e0!3m2!1sen!2suk!4v1513852569260"
            width="1200" height="400" frameborder="0" style="border:0" allowfullscreen></iframe>
        </div>

    </div>

    
</center>
</div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder2" ID="content2">
</asp:Content>

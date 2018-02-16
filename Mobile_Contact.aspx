<%@ Page Title="" Language="VB" MasterPageFile="~/Mobile.master" AutoEventWireup="false" CodeFile="Mobile_Contact.aspx.vb" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" Runat="Server">

    <center>
        <h2>Contact Us</h2>
        <div class="contactForm">
            <h3>Fill out our Contact Form</h3>
            <table>
                <tr>
                    <td><asp:TextBox ID="nameTxt" CssClass="textbox" placeholder="Name *" runat="server" /></td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                    <td><asp:TextBox ID="emailTxt" CssClass="textbox" placeholder="Email Address *" runat="server" /></td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                    <td><asp:TextBox ID="subjectTxt" CssClass="textbox" placeholder="Subject" runat="server" /></td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>
                    <td><asp:TextBox ID="messageTxt" CssClass="textbox" placeholder="Message *" runat="server" TextMode="MultiLine" Rows="5" /></td>
                </tr>
                <tr><td>&nbsp;</td></tr>
                <tr>                                
                    <td align="center"><asp:Button ID="contactBtn" CssClass="button" runat="server" Text="Send Email" /></td>
                </tr>
            </table>
        </div>
        
        <br />

        <div class="contactInfo">
            <h3>Contact Info</h3>

            <p>Servo &amp; Electronic Sales Ltd</p>
            <p>Connector House</p>
            <p>Harden Road</p>
            <p>Lydd, Kent</p>
            <p>TN29 9LX</p>
            <p>+44 (0) 1797 322500</p>
            <p><a href="mailto:info@servoconnectors.co.uk">info@servoconnectors.co.uk</a></p>
        </div>
        
        <br />

        <div class="contactMap">
            <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d10053.43739827781!2d0.915051!3d50.95406!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xfc445a5c2a8a0f27!2sServo+Connectors+(A+division+of+Servo+%26+Electronic+Sales+Ltd.)!5e0!3m2!1sen!2suk!4v1513852569260"
            width="100%" height="750" frameborder="0" style="border:0" allowfullscreen></iframe>
        </div>

        <br />

    </center>

</asp:Content>


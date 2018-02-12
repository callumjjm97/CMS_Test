Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.IO

Partial Class _Default
    Inherits System.Web.UI.Page

    Sub Page_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs)

        If Not IsPostBack Then
           woRepeater.DataBind()
        End If

    End Sub

    Protected Sub woRepeater_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles woRepeater.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.FindControl("readmoreBtn"), Button).PostBackUrl = "" Then
                CType(e.Item.FindControl("readmoreBtn"), Button).Visible = False
            End If
        End If
    End Sub

    Protected Sub sendRFQ(ByVal sender As Object, ByVal e As System.EventArgs) Handles RFQBtn.Click
        Dim errorString As String = ""
        Dim isError As Integer = 0

        If ContactNameText.Text = "" Then
            errorString += " Name field cannot be empty."
            isError = 1
        ElseIf EmailText.Text = "" Or Not EmailText.Text.Contains("@") Then
            errorString += " Email field is incorrect."
            isError = 1

        ElseIf CompanyNameText.Text = "" Then
            errorString += " Company name field cannot be empty."
            isError = 1

        ElseIf MsgText.Text = "" Then
            errorString += " Message field cannot be empty."
            isError = 1
        End If

        If isError = 1 Then
            errorLabel.Text = errorString
            errorLabel.ForeColor = Drawing.Color.Red
        Else
            Dim toAddress As String

            Dim mm As New MailMessage()
            mm.From = New MailAddress(EmailText.Text)
            mm.To.Add(New MailAddress(ConfigurationManager.AppSettings("EmailAddress")))

            mm.Subject = "Request For Quote"
            mm.IsBodyHtml = True

            Dim bodytext As String

            bodytext = "Name: " & ContactNameText.Text & "<br/><br/>Email: " & EmailText.Text & "<br/><br/>Company Name: " & CompanyNameText.Text &
               "<br/><br/>Country: " & ddlCountry.SelectedValue &
               "<br/><br/>Telephone: " & PhoneText.Text & "<br/><br/>Website: " & WebsiteText.Text & "<br/><br/>Message: " & MsgText.Text
            bodytext = bodytext & "<br/><br/>Sent on: " & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString

            mm.Body = bodytext

            Dim smtp As System.Net.Mail.SmtpClient
            smtp = New System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings("SMTPServer"))

            Try
                smtp.Send(mm)
            Catch ex As Exception
                isError = 1
                errorLabel.Text = "Email failed to send. Please try again shortly."
            End Try

            If isError <> 1 Then

                ContactNameText.Text = ""
                EmailText.Text = ""
                CompanyNameText.Text = ""
                PhoneText.Text = ""
                MsgText.Text = ""
                WebsiteText.Text = ""

                errorLabel.Text = "Thank you for your email. We will get back to you as soon as possible."
                errorLabel.ForeColor = Drawing.Color.Green

            End If


        End If

    End Sub

End Class

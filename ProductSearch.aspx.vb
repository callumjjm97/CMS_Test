Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.IO

Partial Class ProductSearch
    Inherits System.Web.UI.Page

    Sub Page_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            DSParts.SelectParameters.Add("SearchText", Session("SearchTerm"))

        End If

    End Sub

    Protected Sub sendRFQ(ByVal sender As Object, ByVal e As System.EventArgs) Handles RFQBtn.Click
        Dim errorString As String = ""
        Dim isError As Integer = 0

        If ContactNameText.Text = "" Then
            errorString += " Name field cannot be empty."
            isError = 1
        End If
        'AR 31 Oct 2016 - 199019: Changes to error if email doesn't contain @
        If EmailText.Text = "" Or Not EmailText.Text.Contains("@") Then
            errorString += " Email field is incorrect."
            isError = 1
        End If
        If CompanyNameText.Text = "" Then
            errorString += " Company name field cannot be empty."
            isError = 1
        End If
        If MsgText.Text = "" Then
            errorString += " Message field cannot be empty."
            isError = 1
        End If

        If isError = 1 Then
            errorLabel.Text = errorString
            errorLabel.ForeColor = Drawing.Color.Red
        Else
            Dim toAddress As String
            Dim mm As New MailMessage()

            Try

                mm.From = New MailAddress(EmailText.Text)
                mm.To.Add(New MailAddress(ConfigurationManager.AppSettings("EmailAddress")))

            Catch x As Exception
                errorLabel.Text = x.ToString
            End Try

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

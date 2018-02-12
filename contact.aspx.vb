Imports System.Net.Mail
Imports System.IO


Partial Class contact
    Inherits System.Web.UI.Page

    Protected Sub sendBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sendBtn.Click
        Dim errorString As String = ""
        Dim isError As Integer = 0

        If nameTxt.Text = "" Then
            errorString += " Name field cannot be empty."
            isError = 1
        End If
        'AR 31 Oct 2016 - 199019: Changes to error if email doesn't contain @
        If emailTxt.Text = "" Or Not emailTxt.Text.Contains("@") Then
            errorString += " Email field is incorrect."
            isError = 1
        End If
        If subjectTxt.Text = "" Then
            errorString += " Subject field cannot be empty."
            isError = 1
        End If
        If messageTxt.Text = "" Then
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

                mm.From = New MailAddress(emailTxt.Text)
                mm.To.Add(New MailAddress(ConfigurationManager.AppSettings("EmailAddress")))

            Catch x As Exception
                errorLabel.Text = x.ToString
            End Try

            mm.Subject = subjectTxt.Text
            mm.IsBodyHtml = True

            Dim bodytext As String

            bodytext = "Name: " & nameTxt.Text & "<br/><br/>Email: " & emailTxt.Text & "<br/><br/>Message: " & messageTxt.Text
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

                nameTxt.Text = ""
                emailTxt.Text = ""
                subjectTxt.Text = ""
                messageTxt.Text = ""

                errorLabel.Text = "Thank you for your email. We will get back to you as soon as possible."
                errorLabel.ForeColor = Drawing.Color.Green

            End If


        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            
        End If
    End Sub
End Class

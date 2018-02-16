Imports System.Net.Mail

Partial Class Contact
    Inherits CommonCode

    Protected Sub contactBtn_Click(sender As Object, e As System.EventArgs) Handles contactBtn.Click
        Dim errorString As String = ""
        Dim isError As Integer = 0

        If nameTxt.Text = "" Then
            errorString += " Name field cannot be empty."
            isError = 1
        End If

        If emailTxt.Text = "" Then
            errorString += " Email field is incorrect."
            isError = 1
        Else
            If Not Regex.IsMatch(emailTxt.Text, "^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$") Then
                isError = True
                errorString += " Email Address is not valid."
            End If
        End If
        If messageTxt.Text = "" Then
            errorString += " Message field cannot be empty."
            isError = 1
        End If

        If isError = 1 Then
           ASPNET_MsgBox(errorString, "warning")
        Else
            Dim mm As New MailMessage()

            Try
                mm.From = New MailAddress(emailTxt.Text)
                mm.To.Add(New MailAddress(ConfigurationManager.AppSettings("EmailAddress")))

                mm.Subject = IIf(subjectTxt.Text.Trim = "", "Servo Website Contact Form", subjectTxt.Text)
                mm.IsBodyHtml = True

                Dim bodytext As String

                bodytext = "Name: " & nameTxt.Text & "<br/><br/>Email: " & emailTxt.Text & "<br/><br/>Message: " & messageTxt.Text
                bodytext = bodytext & "<br/><br/>Sent on: " & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString

                mm.Body = bodytext

                Dim smtp As System.Net.Mail.SmtpClient
                smtp = New System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings("SMTPServer"))

                smtp.Send(mm)

                ASPNET_MsgBox("Thank you for your email. We will get back to you as soon as possible.", "success")
            Catch ex As Exception
                isError = 1                
                ASPNET_MsgBox("Email failed to send. Please try again shortly. Error: " & ex.Message.ToString, "warning")
            End Try

        End If
    End Sub
End Class

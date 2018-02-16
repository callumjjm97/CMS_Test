Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail

Partial Class _Default
    Inherits CommonCode

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
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

    Protected Sub RFQBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RFQBtn.Click
        Dim IsError As Boolean = False
        Dim ErrorStr As String = ""

        If nameTxt.Text = "" Then
            IsError = True
            ErrorStr += " | Name is empty."
        End If

        If companyTxt.Text = "" Then
            IsError = True
            ErrorStr += " | Company is empty."
        End If

        If messageTxt.Text = "" Then
            IsError = True
            ErrorStr += " | Message is empty."
        End If

        If emailTxt.Text = "" Then
            IsError = True
            ErrorStr += " | Email Address is empty."
        Else
            If Not Regex.IsMatch(emailTxt.Text, "^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$") Then
                IsError = True
                ErrorStr += " | Email Address is not valid."
            End If
        End If

        If IsError = False Then
            Try
                Dim mm As New MailMessage()

                mm.From = New MailAddress(emailTxt.Text)
                mm.To.Add(New MailAddress(ConfigurationManager.AppSettings("EmailAddress")))

                mm.Subject = "Request For Quote"
                mm.IsBodyHtml = True

                Dim bodytext As String

                bodytext = "Name: " & nameTxt.Text & "<br/><br/>Email: " & emailTxt.Text & "<br/><br/>Company: " & companyTxt.Text &
                   "<br/><br/>Country: " & countryDD.SelectedValue &
                   "<br/><br/>Telephone: " & phoneTxt.Text & "<br/><br/>Website: " & websiteTxt.Text & "<br/><br/>Message: " & messageTxt.Text
                bodytext = bodytext & "<br/><br/>Sent on: " & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString

                mm.Body = bodytext

                Dim smtp As System.Net.Mail.SmtpClient
                smtp = New System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings("SMTPServer"))

                smtp.Send(mm)

            Catch ex As Exception
                ASPNET_MsgBox("Failed to send Request For Quote - error: " & ex.Message.ToString, "warning")
            End Try
        Else
            If ErrorStr.Length > 2 Then
                ErrorStr = ErrorStr.Remove(0, 3)
                ErrorStr = "Error has occured while sending Request For Quote: " & ErrorStr
            End If
            ASPNET_MsgBox(ErrorStr, "warning")
        End If

    End Sub
End Class

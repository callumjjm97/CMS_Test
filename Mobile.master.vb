﻿Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail

Partial Class Mobile
    Inherits System.Web.UI.MasterPage
    Sub Page_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim userAgent As String = Request.ServerVariables("HTTP_USER_AGENT")
        Dim OS As New Regex("(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        Dim device As New Regex("1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        Dim device_info As String = String.Empty
        If OS.IsMatch(userAgent) Then
            device_info = OS.Match(userAgent).Groups(0).Value
        End If

        If device.IsMatch(userAgent.Substring(0, 4)) Then
            device_info += device.Match(userAgent).Groups(0).Value
        End If

        If String.IsNullOrEmpty(device_info) Then
            Response.Redirect("./Default.aspx")
        End If

        If Not IsPostBack Then
            PopulateMenu()
        End If

    End Sub

    Private Sub PopulateMenu()

        Using oConn As New SqlConnection
            Using oCmd As New SqlCommand

                oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString
                oConn.Open()

                oCmd.Connection = oConn
                oCmd.CommandText = "proc_SEL_NavMenu_Mobile"
                oCmd.CommandType = Data.CommandType.StoredProcedure

                Dim Menu_Content As New SqlParameter("@Menu_Content", SqlDbType.VarChar, -1)
                Menu_Content.Direction = ParameterDirection.Output
                oCmd.Parameters.Add(Menu_Content)

                oCmd.ExecuteNonQuery()

                navMenu.InnerHtml = Menu_Content.Value

            End Using
        End Using

    End Sub

    Protected Sub sendSubscription(ByVal sender As Object, ByVal e As System.EventArgs) Handles subscribeBtn.Click
        Dim errorString As String = ""
        Dim isError As Integer = 0

        If subscribeTxt.Text = "" Then
            errorString += " Email field is incorrect."
            isError = 1
        Else
            If Not Regex.IsMatch(subscribeTxt.Text, "^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$") Then
                isError = True
                errorString += " Email Address is not valid."
            End If
        End If
        If isError = 1 Then
            ASPNET_MsgBox(errorString, "warning")
        Else

            Dim mm As New MailMessage()
            mm.From = (New MailAddress(ConfigurationManager.AppSettings("EmailAddress")))
            mm.To.Add(New MailAddress(ConfigurationManager.AppSettings("EmailAddressNewsletter")))

            mm.Subject = "Request For Quote"
            mm.IsBodyHtml = True

            Dim bodytext As String

            bodytext = "Hello there, <br/> The following email address has requested a subscription to the newsletter: " & subscribeTxt.Text

            bodytext = bodytext & "<br/><br/>Sent on: " & Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString

            mm.Body = bodytext

            Dim smtp As System.Net.Mail.SmtpClient
            smtp = New System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings("SMTPServer"))

            Try
                smtp.Send(mm)
            Catch ex As Exception
                isError = 1                
                ASPNET_MsgBox("Email failed to send. Please try again shortly.", "warning")
            End Try

            If isError <> 1 Then

                subscribeTxt.Text = ""

                ASPNET_MsgBox("Your subscription to our newsletter was successful!", "success")

            End If


        End If

    End Sub

    Protected Sub ASPNET_MsgBox(ByVal Message As String, ByVal type As String)

        Message = Replace(Message, Chr(13), " ")
        Message = Replace(Message, Chr(10), " ")
        Message = Message.Replace("'", "")

        Dim cs As ClientScriptManager = Page.ClientScript
        cs.RegisterStartupScript(Me.GetType, "z", "showMsg_Box('" & Message & "', '" & type & "');", True)

    End Sub

    Protected Sub searchBtn_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles searchBtn.Click
        Session("SearchTerm") = searchBox.Text

        Response.Redirect("./Mobile_ProductSearch.aspx?search=" + searchBox.Text)
    End Sub
End Class

Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.IO

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim oConn As New Data.SqlClient.SqlConnection

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

        oConn.Open()
    End Sub
    Sub Page_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim dt As DataTable = Me.GetData(0)
            PopulateMenu(dt, 0, Nothing, 0)
        End If

    End Sub

    Private Function GetData(ByVal parentMenuId As Integer) As DataTable

        Dim oCmd As New Data.SqlClient.SqlCommand
        Dim adapter As New Data.SqlClient.SqlDataAdapter

        oCmd.Connection = oConn
        oCmd.CommandText = "proc_SEL_NavMenu"
        oCmd.CommandType = Data.CommandType.StoredProcedure

        Dim dt As New DataTable

        oCmd.Parameters.Add("@parentMenuId", Data.SqlDbType.Int).Value = parentMenuId
        adapter.SelectCommand = oCmd
        adapter.Fill(dt)

        Return dt

        adapter.Dispose()
        oCmd.Dispose()


    End Function

    Private Sub PopulateMenu(ByVal dt As DataTable, ByVal parentMenuId As Integer, ByVal parentMenuItem As MenuItem, IsGran As Integer)
        Dim FirstOne As Integer = 1
        For Each row As DataRow In dt.Rows
            Dim menuItem As New MenuItem With {.Value = row("page_id").ToString, .Text = row("title").ToString, .NavigateUrl = row("url").ToString}
            If parentMenuId = 0 Then
                navMenu.Items.Add(menuItem)
                Dim dtChild As DataTable = Me.GetData(Integer.Parse(menuItem.Value))
                PopulateMenu(dtChild, Integer.Parse(menuItem.Value), menuItem, 0)
            Else
                If IsGran = 1 And FirstOne = 1 Then
                    parentMenuItem.Text = parentMenuItem.Text + "  >>"
                    FirstOne = 0
                End If
                parentMenuItem.ChildItems.Add(menuItem)
                Dim dtGChild As DataTable = Me.GetData(Integer.Parse(menuItem.Value))
                PopulateMenu(dtGChild, Integer.Parse(menuItem.Value), menuItem, 1)
            End If
        Next

        For Each row As DataRow In dt.Rows
            Dim menuItem As New MenuItem With {.Value = row("page_id").ToString, .Text = row("title").ToString, .NavigateUrl = row("url").ToString}
            If parentMenuId = 0 Then
                quickLinks.Items.Add(menuItem)
                'Dim dtChild As DataTable = Me.GetData(Integer.Parse(menuItem.Value))
                'PopulateMenu(dtChild, Integer.Parse(menuItem.Value), menuItem, 0)
            Else

            End If

        Next


    End Sub

    Protected Sub searchClick()

        Session("SearchTerm") = searchBox.Text

        Response.Redirect("ProductSearch.aspx?search=" + searchBox.Text)

    End Sub

    Protected Sub sendSubscription(ByVal sender As Object, ByVal e As System.EventArgs) Handles subscribeBtn.Click
        Dim errorString As String = ""
        Dim isError As Integer = 0
        'AR 31 Oct 2016 - 199019: Changes to error if email doesn't contain @
        If subscribeText.Text = "" Or Not subscribeText.Text.Contains("@") Then
            errorString += " Email field is incorrect."
            isError = 1
        End If
        If isError = 1 Then
            errorLabel.Text = errorString
            errorLabel.ForeColor = Drawing.Color.Red
        Else
            'Dim toAddress As String

            Dim mm As New MailMessage()
            mm.From = (New MailAddress(ConfigurationManager.AppSettings("EmailAddress")))
            mm.To.Add(New MailAddress(ConfigurationManager.AppSettings("EmailAddressNewsletter")))

            mm.Subject = "Request For Quote"
            mm.IsBodyHtml = True

            Dim bodytext As String

            bodytext = "Hello there, <br/> The following email address has requested a subscription to the newsletter: " & subscribeText.Text

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

                subscribeText.Text = ""

                errorLabel.Text = "Subscribed successfully!"
                errorLabel.ForeColor = Drawing.Color.White

            End If


        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oConn.Close()
        oConn.Dispose()
    End Sub

End Class


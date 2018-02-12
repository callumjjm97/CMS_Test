Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail

Partial Class Pages
    Inherits System.Web.UI.Page
    Dim oConn As New Data.SqlClient.SqlConnection

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

        oConn.Open()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            sqlParent.SelectParameters.Item("page_id").DefaultValue = -1
            parentPageDD.DataBind()

            pageIdHF.Value = Request.QueryString("id")

            'scheduleDD.DataBind()
        End If

        'contentEditor.ShowPreviewMode = False

        If Session("Role") = "Approver" Then
            deleteButton.Visible = True
        Else
            deleteButton.Visible = False
        End If

        If Not IsPostBack Then
            loadcontent()
            loginIdHF.Value = Session("User_Id")
        End If
        If IsNothing(Session("User_Id")) Then
            Response.Redirect("login.aspx")
        Else
            If Session("User_Id").ToString = "" Then
                Response.Redirect("login.aspx")
            End If
        End If
    End Sub

    Sub loadcontent()

        If Request.QueryString("id") Is Nothing Then
            Response.Redirect("default.aspx")
        Else

            selectedPageHF.Value = Request.QueryString("id")


            Dim oCmd As New Data.SqlClient.SqlCommand
           
            oCmd.Connection = oConn
            oCmd.CommandText = "proc_Get_Content_byID"
            oCmd.CommandType = Data.CommandType.StoredProcedure
            oCmd.Parameters.Add("@page_id", Data.SqlDbType.Int).Value = Request.QueryString("id")

            Dim title As New SqlParameter("@title", SqlDbType.VarChar, 500)
            title.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(title)

            Dim description As New SqlParameter("@description", SqlDbType.VarChar, 500)
            description.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(description)

            Dim keywords As New SqlParameter("@keywords", SqlDbType.VarChar, 500)
            keywords.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(keywords)

            Dim page_content As New SqlParameter("@page_content", SqlDbType.VarChar, 500000)
            page_content.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(page_content)

            Dim page_name As New SqlParameter("@page_name", SqlDbType.VarChar, 500)
            page_name.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(page_name)

            Dim page_status As New SqlParameter("@page_status", SqlDbType.VarChar, 500)
            page_status.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(page_status)

            Dim parentName As New SqlParameter("@parentName", SqlDbType.VarChar, 500)
            parentName.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(parentName)

            Dim showmenu As New SqlParameter("@showmenu", SqlDbType.Bit)
            showmenu.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(showmenu)

            Dim preUrl As New SqlParameter("@preUrl", SqlDbType.VarChar, 1000)
            preUrl.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(preUrl)

            oCmd.ExecuteNonQuery()

            urlTextBox.Text = page_name.Value

            preUrlTextBox.Text = preUrl.Value

            Page.Title = "Edit - " & title.Value

            titleTextBox.Text = title.Value

            descTextBox.Text = description.Value

            keywordsTextBox.Text = keywords.Value

            statusTextLabel.Text = page_status.Value

            menuCheckBox.Checked = showmenu.Value

            parentPageDD.SelectedValue = parentName.Value

            If page_status.Value = "Awaiting Approval" Then

                'contentEditor.Visible = False

                saveButton.Enabled = False

            End If
            htmlEditorTxt.Text = page_content.Value
            'contentEditor.Text = page_content.Value

            oCmd.Dispose()

            If Session("Role") = "Approver" Then
                publishButton.Enabled = True
                unpublishButton.Enabled = True
                revertButton.Enabled = True
                'contentEditor.Visible = True
            Else
                publishButton.Enabled = False
                unpublishButton.Enabled = False
                revertButton.Enabled = False
            End If

            If preUrl.Value <> "" Then
                urlStartLabel.Text = preUrl.Value
                urlAnchor.HRef = preUrl.Value
                urlAnchor.Target = "_blank"
            Else
                urlStartLabel.Text = ConfigurationManager.AppSettings("URL") & "/" & page_name.Value
                urlAnchor.HRef = ConfigurationManager.AppSettings("URL") & "/" & page_name.Value
                urlAnchor.Target = "_blank"
            End If
            

        End If

    End Sub

    Protected Sub newButton_Click(sender As Object, e As System.EventArgs) Handles newButton.Click

    End Sub

    Sub saveContent()

        Dim oCmd As New Data.SqlClient.SqlCommand



        oCmd.Connection = oConn
        oCmd.CommandText = "proc_CMS_Save_Content"
        oCmd.CommandType = Data.CommandType.StoredProcedure
        oCmd.Parameters.Add("@page_id", Data.SqlDbType.Int).Value = Request.QueryString("id")
        'oCmd.Parameters.Add("@page_content", Data.SqlDbType.VarChar, 500000).Value = contentEditor.Text
        oCmd.Parameters.Add("@title", Data.SqlDbType.VarChar, 500).Value = titleTextBox.Text
        oCmd.Parameters.Add("@keywords", Data.SqlDbType.VarChar, 500).Value = keywordsTextBox.Text
        oCmd.Parameters.Add("@page_desc", Data.SqlDbType.VarChar, 500).Value = descTextBox.Text
        oCmd.Parameters.Add("@page_name", Data.SqlDbType.VarChar, 500).Value = urlTextBox.Text
        oCmd.Parameters.Add("@login_id", Data.SqlDbType.Int).Value = Session("User_Id")
        oCmd.Parameters.Add("@showmenu", Data.SqlDbType.Bit).Value = menuCheckBox.Checked
        oCmd.Parameters.Add("@parent_id", Data.SqlDbType.Int).Value = parentPageDD.SelectedValue
        oCmd.Parameters.Add("@preUrl", Data.SqlDbType.VarChar, 1000).Value = preUrlTextBox.Text


        oCmd.ExecuteNonQuery()

        oCmd.Dispose()

        loadcontent()

    End Sub

    Sub saveContentForApproval()

        Dim oCmd As New Data.SqlClient.SqlCommand

        oCmd.Connection = oConn
        oCmd.CommandText = "proc_CMS_Save_Content_for_Approval"
        oCmd.CommandType = Data.CommandType.StoredProcedure
        oCmd.Parameters.Add("@page_id", Data.SqlDbType.Int).Value = Request.QueryString("id")
        'oCmd.Parameters.Add("@page_content", Data.SqlDbType.VarChar, 500000).Value = contentEditor.Text
        oCmd.Parameters.Add("@title", Data.SqlDbType.VarChar, 500).Value = titleTextBox.Text
        oCmd.Parameters.Add("@keywords", Data.SqlDbType.VarChar, 500).Value = keywordsTextBox.Text
        oCmd.Parameters.Add("@page_desc", Data.SqlDbType.VarChar, 500).Value = descTextBox.Text
        oCmd.Parameters.Add("@page_name", Data.SqlDbType.VarChar, 500).Value = urlTextBox.Text
        oCmd.Parameters.Add("@login_id", Data.SqlDbType.Int).Value = Session("User_Id")

        Dim emailTo As New SqlParameter("@emailTo", SqlDbType.VarChar, 50000)
        emailTo.Direction = ParameterDirection.Output
        oCmd.Parameters.Add(emailTo)

        Dim Approval_Email_From As New SqlParameter("@Approval_Email_From", SqlDbType.VarChar, 50000)
        Approval_Email_From.Direction = ParameterDirection.Output
        oCmd.Parameters.Add(Approval_Email_From)

        Dim Approval_Email_Subject As New SqlParameter("@Approval_Email_Subject", SqlDbType.VarChar, 50000)
        Approval_Email_Subject.Direction = ParameterDirection.Output
        oCmd.Parameters.Add(Approval_Email_Subject)

        Dim Approval_Email_Body As New SqlParameter("@Approval_Email_Body", SqlDbType.VarChar, 50000)
        Approval_Email_Body.Direction = ParameterDirection.Output
        oCmd.Parameters.Add(Approval_Email_Body)

        oCmd.ExecuteNonQuery()

        oCmd.Dispose()


        Dim emailarray As String()
        Dim a As Integer

        Dim smtp As String = ConfigurationManager.AppSettings("SMTP")
        Dim smtp_user As String = ConfigurationManager.AppSettings("SMTP_User")
        Dim smtp_password As String = ConfigurationManager.AppSettings("SMTP_Password")
        Dim emailClient As New SmtpClient(smtp)

        emailarray = emailTo.Value.ToString.Substring(1).ToString.Split(",")

        For a = 0 To emailarray.Length - 1

            Dim message As New System.Net.Mail.MailMessage(Approval_Email_From.Value, emailarray(a), Approval_Email_Subject.Value, Approval_Email_Body.Value)

            message.IsBodyHtml = True

            Dim SMTPUserInfo As New Net.NetworkCredential(smtp_user, smtp_password)

            emailClient.UseDefaultCredentials = False
            emailClient.Credentials = SMTPUserInfo

            'emailClient.Send(message)
        Next

        loadcontent()

    End Sub

    'Protected Sub contentEditor_PostBackCommand(sender As Object, e As System.Web.UI.WebControls.CommandEventArgs) Handles contentEditor.PostBackCommand

    '    If e.CommandName = "Save" Then

    '        If Session("Role") = "Approver" Then
    '            saveContent()
    '        Else
    '            saveContentForApproval()
    '        End If

    '    End If

    'End Sub

    Protected Sub saveButton_Click(sender As Object, e As System.EventArgs) Handles saveButton.Click

        If Session("Role") = "Approver" Then
            saveContent()
        Else
            saveContentForApproval()
        End If

    End Sub

    Protected Sub deleteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteButton.Click
        Dim oCmd As New Data.SqlClient.SqlCommand

        oCmd.Connection = oConn
        oCmd.CommandText = "proc_CMS_Del_Content"
        oCmd.CommandType = Data.CommandType.StoredProcedure
        oCmd.Parameters.Add("@page_id", Data.SqlDbType.Int).Value = Request.QueryString("id")
        'oCmd.Parameters.Add("@page_content", Data.SqlDbType.VarChar, 500000).Value = contentEditor.Text
        oCmd.Parameters.Add("@title", Data.SqlDbType.VarChar, 500).Value = titleTextBox.Text
        oCmd.Parameters.Add("@keywords", Data.SqlDbType.VarChar, 500).Value = keywordsTextBox.Text
        oCmd.Parameters.Add("@page_desc", Data.SqlDbType.VarChar, 500).Value = descTextBox.Text
        oCmd.Parameters.Add("@page_name", Data.SqlDbType.VarChar, 500).Value = urlTextBox.Text
        oCmd.Parameters.Add("@login_id", Data.SqlDbType.Int).Value = Session("User_Id")
        oCmd.Parameters.Add("@showmenu", Data.SqlDbType.Bit).Value = menuCheckBox.Checked

        oCmd.ExecuteNonQuery()

        oCmd.Dispose()


        'AR 9 Feb 2016 - Needed to refresh the content page

        selectedPageHF.Value = 1

        Dim oConn2 As New Data.SqlClient.SqlConnection
        Dim oCmd2 As New Data.SqlClient.SqlCommand
        oConn2.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

        oConn2.Open()
        oCmd2.Connection = oConn2
        oCmd2.CommandText = "proc_Get_Content_byID"
        oCmd2.CommandType = Data.CommandType.StoredProcedure
        oCmd2.Parameters.Add("@page_id", Data.SqlDbType.Int).Value = 2

        Dim title As New SqlParameter("@title", SqlDbType.VarChar, 500)
        title.Direction = ParameterDirection.Output
        oCmd2.Parameters.Add(title)

        Dim description As New SqlParameter("@description", SqlDbType.VarChar, 500)
        description.Direction = ParameterDirection.Output
        oCmd2.Parameters.Add(description)

        Dim keywords As New SqlParameter("@keywords", SqlDbType.VarChar, 500)
        keywords.Direction = ParameterDirection.Output
        oCmd2.Parameters.Add(keywords)

        Dim page_content As New SqlParameter("@page_content", SqlDbType.VarChar, -1)
        page_content.Direction = ParameterDirection.Output
        oCmd2.Parameters.Add(page_content)

        Dim page_name As New SqlParameter("@page_name", SqlDbType.VarChar, 500)
        page_name.Direction = ParameterDirection.Output
        oCmd2.Parameters.Add(page_name)

        Dim page_status As New SqlParameter("@page_status", SqlDbType.VarChar, 500)
        page_status.Direction = ParameterDirection.Output
        oCmd2.Parameters.Add(page_status)

        Dim parentName As New SqlParameter("@parentName", SqlDbType.VarChar, 500)
        parentName.Direction = ParameterDirection.Output
        oCmd2.Parameters.Add(parentName)

        Dim showmenu As New SqlParameter("@showmenu", SqlDbType.Bit)
        showmenu.Direction = ParameterDirection.Output
        oCmd2.Parameters.Add(showmenu)

        Dim preUrl As New SqlParameter("@preUrl", SqlDbType.VarChar, 1000)
        preUrl.Direction = ParameterDirection.Output
        oCmd2.Parameters.Add(preUrl)

        oCmd2.ExecuteNonQuery()

        urlTextBox.Text = page_name.Value

        Page.Title = "Edit - " & title.Value

        titleTextBox.Text = title.Value

        descTextBox.Text = description.Value

        keywordsTextBox.Text = keywords.Value

        statusTextLabel.Text = page_status.Value

        menuCheckBox.Checked = showmenu.Value

        parentPageDD.SelectedValue = parentName.Value

        preUrlTextBox.Text = preUrl.Value

        If page_status.Value = "Awaiting Approval" Then

            'contentEditor.Visible = False

            saveButton.Enabled = False

        End If

        'contentEditor.Text = page_content.Value

        oCmd2.Dispose()
        oConn2.Close()
        oConn2.Dispose()

        If Session("Role") = "Approver" Then
            publishButton.Enabled = True
            unpublishButton.Enabled = True
            revertButton.Enabled = True
            'contentEditor.Visible = True
        Else
            publishButton.Enabled = False
            unpublishButton.Enabled = False
            revertButton.Enabled = False
        End If

        urlStartLabel.Text = ConfigurationManager.AppSettings("URL") & "/" & page_name.Value
        urlAnchor.HRef = ConfigurationManager.AppSettings("URL") & "/" & page_name.Value

        'AR 9 Feb 2016 - Posts back to refresh the treeview with deleted page gone from list

        Dim sbScript As New StringBuilder()

        sbScript.Append("<script language='JavaScript' type='text/javascript'>" + ControlChars.Lf)
        sbScript.Append("<!--" + ControlChars.Lf)
        sbScript.Append((Me.GetPostBackEventReference(Me, "PBArg") + ";" + ControlChars.Lf))
        sbScript.Append("// -->" + ControlChars.Lf)
        sbScript.Append("</")
        sbScript.Append("script>" + ControlChars.Lf)

        Me.RegisterStartupScript("AutoPostBackScript", sbScript.ToString())


    End Sub

    Protected Sub previewButton_Click(sender As Object, e As System.EventArgs) Handles previewButton.Click

        Response.Redirect("~/Preview/default.aspx?name=" & urlTextBox.Text)

    End Sub

    Protected Sub saveNewButton_Click(sender As Object, e As System.EventArgs) Handles saveNewButton.Click

        Dim oCmd As New Data.SqlClient.SqlCommand

        oCmd.Connection = oConn
        oCmd.CommandText = "proc_CMS_Add_Page"
        oCmd.CommandType = Data.CommandType.StoredProcedure
        oCmd.Parameters.Add("@title", Data.SqlDbType.VarChar, 500).Value = newpageTextBox.Text
        oCmd.Parameters.Add("@login_id", SqlDbType.Int).Value = Session("User_Id")

        Dim page_id As New SqlParameter("@page_id", SqlDbType.Int)
        page_id.Direction = ParameterDirection.Output
        oCmd.Parameters.Add(page_id)

        oCmd.ExecuteNonQuery()

        oCmd.Dispose()

        Response.Redirect("pages.aspx?id=" & page_id.Value)

    End Sub

    Protected Sub publishButton_Click(sender As Object, e As System.EventArgs) Handles publishButton.Click

        Dim oCmd As New Data.SqlClient.SqlCommand

        oCmd.Connection = oConn
        oCmd.CommandText = "proc_CMS_Publish_Page"
        oCmd.CommandType = Data.CommandType.StoredProcedure
        oCmd.Parameters.Add("@page_id", Data.SqlDbType.Int).Value = Request.QueryString("id")
        oCmd.Parameters.Add("@login_id", SqlDbType.Int).Value = Session("User_Id")

        oCmd.ExecuteNonQuery()

        oCmd.Dispose()

        loadcontent()

    End Sub

    Protected Sub revertButton_Click(sender As Object, e As System.EventArgs) Handles revertButton.Click

        Dim oCmd As New Data.SqlClient.SqlCommand

        oCmd.Connection = oConn
        oCmd.CommandText = "proc_CMS_Revert_Page"
        oCmd.CommandType = Data.CommandType.StoredProcedure
        oCmd.Parameters.Add("@page_id", Data.SqlDbType.Int).Value = Request.QueryString("id")
        oCmd.Parameters.Add("@login_id", SqlDbType.Int).Value = Session("User_Id")

        oCmd.ExecuteNonQuery()

        oCmd.Dispose()

        loadcontent()

    End Sub

    Protected Sub unpublishButton_Click(sender As Object, e As System.EventArgs) Handles unpublishButton.Click

        Dim oCmd As New Data.SqlClient.SqlCommand

        oCmd.Connection = oConn
        oCmd.CommandText = "proc_CMS_Unpublish_Page"
        oCmd.CommandType = Data.CommandType.StoredProcedure
        oCmd.Parameters.Add("@page_id", Data.SqlDbType.Int).Value = Request.QueryString("id")
        oCmd.Parameters.Add("@login_id", SqlDbType.Int).Value = Session("User_Id")

        oCmd.ExecuteNonQuery()

        oCmd.Dispose()
        

        loadcontent()

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oConn.Close()
        oConn.Dispose()
    End Sub
End Class

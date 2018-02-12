Imports System.Data
Imports System.Data.SqlClient

Partial Class Admin_WhatsOnEdit
    Inherits System.Web.UI.Page
    Dim oConn As New Data.SqlClient.SqlConnection

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

        oConn.Open()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            linkPageDD.DataBind()

            titleTextBox.Focus()

            If Request.QueryString("id") IsNot Nothing Then

                Dim oCmd As New Data.SqlClient.SqlCommand

                oCmd.Connection = oConn
                oCmd.CommandText = "proc_Get_WhatsOn_byID"
                oCmd.CommandType = Data.CommandType.StoredProcedure
                oCmd.Parameters.Add("@wo_id", Data.SqlDbType.Int).Value = Request.QueryString("id")

                Dim page_name As New SqlParameter("@page_name", SqlDbType.VarChar, 500)
                page_name.Direction = ParameterDirection.Output
                oCmd.Parameters.Add(page_name)

                Dim page_content As New SqlParameter("@page_content", SqlDbType.VarChar, -1)
                page_content.Direction = ParameterDirection.Output
                oCmd.Parameters.Add(page_content)

                Dim link_page As New SqlParameter("@link_page", SqlDbType.Int)
                link_page.Direction = ParameterDirection.Output
                oCmd.Parameters.Add(link_page)

                oCmd.ExecuteNonQuery()

                Page.Title = "Edit - " & page_name.Value

                titleTextBox.Text = page_name.Value

                linkPageDD.SelectedValue = link_page.Value

                contentEditor.Text = page_content.Value

                oCmd.Dispose()

            End If
        End If

    End Sub

    Protected Sub saveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveButton.Click
        Dim errorString As String = ""
        Dim isError As Integer = 0

        If titleTextBox.Text = "" Then
            errorString += "Title cannot be empty."
            isError = 1
        End If

        If linkPageDD.SelectedValue = -1 And contentEditor.Text = "" Then
            errorString += " Content cannot be empty when '- SELF -' is selected."
            isError = 1
        End If

        If isError = 1 Then
            errorLabel.Text = errorString
            errorLabel.ForeColor = Drawing.Color.Red
        Else
            Dim oCmd As New Data.SqlClient.SqlCommand

            oCmd.Connection = oConn

            If Request.QueryString("id") IsNot Nothing Then
                oCmd.CommandText = "proc_CMS_UPD_WhatsOn"
                oCmd.CommandType = Data.CommandType.StoredProcedure
                oCmd.Parameters.Add("@id", Data.SqlDbType.Int).Value = Request.QueryString("id")
                oCmd.Parameters.Add("@wo_id", Data.SqlDbType.Int).Value = linkPageDD.SelectedValue
                oCmd.Parameters.Add("@wo_name", Data.SqlDbType.VarChar, 250).Value = linkPageDD.SelectedItem.Text
                oCmd.Parameters.Add("@title", Data.SqlDbType.VarChar, 100).Value = titleTextBox.Text
                oCmd.Parameters.Add("@summary", Data.SqlDbType.VarChar, 400).Value = summaryTextBox.Text
                oCmd.Parameters.Add("@content", Data.SqlDbType.VarChar, -1).Value = contentEditor.Text
                oCmd.Parameters.Add("@always", Data.SqlDbType.Bit).Value = alwaysChk.Checked
            Else
                oCmd.CommandText = "proc_CMS_ADD_WhatsOn"
                oCmd.CommandType = Data.CommandType.StoredProcedure
                oCmd.Parameters.Add("@id", Data.SqlDbType.Int).Value = IIf(Request.QueryString("id") Is Nothing, -1, Request.QueryString("id"))
                oCmd.Parameters.Add("@wo_id", Data.SqlDbType.Int).Value = linkPageDD.SelectedValue
                oCmd.Parameters.Add("@wo_name", Data.SqlDbType.VarChar, 250).Value = linkPageDD.SelectedItem.Text
                oCmd.Parameters.Add("@title", Data.SqlDbType.VarChar, 100).Value = titleTextBox.Text
                oCmd.Parameters.Add("@summary", Data.SqlDbType.VarChar, 400).Value = summaryTextBox.Text
                oCmd.Parameters.Add("@content", Data.SqlDbType.VarChar, -1).Value = contentEditor.Text
                oCmd.Parameters.Add("@always", Data.SqlDbType.Bit).Value = alwaysChk.Checked
            End If


            oCmd.ExecuteNonQuery()

            oCmd.Dispose()


            errorLabel.Text = "Succesfully saved What's On item!"
            errorLabel.ForeColor = Drawing.Color.Green
        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oConn.Close()
        oConn.Dispose()
    End Sub
End Class

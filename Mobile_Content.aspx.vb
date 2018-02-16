Imports System.Data
Imports System.Data.SqlClient

Partial Class Content
    Inherits CommonCode

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetContent()
        End If
    End Sub

    Protected Sub SetContent()
        Dim page_id As Int32 = 0
        Dim page_name As String = ""

        If Not Request.QueryString("id") Is Nothing Then
            Int32.TryParse(Request.QueryString("id"), page_id)
        End If

        Using oConn As New SqlConnection
            Using oCmd As New SqlCommand
                oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString
                oConn.Open()

                If page_id > 0 Then

                    oCmd.Connection = oConn
                    oCmd.CommandText = "proc_Get_Content_byID_Published"
                    oCmd.CommandType = Data.CommandType.StoredProcedure
                    oCmd.Parameters.Add("@page_id", Data.SqlDbType.VarChar, 500).Value = page_id

                    Dim title As New SqlParameter("@title", SqlDbType.VarChar, 500)
                    title.Direction = ParameterDirection.Output
                    oCmd.Parameters.Add(title)

                    Dim keywords As New SqlParameter("@keywords", SqlDbType.VarChar, 500)
                    keywords.Direction = ParameterDirection.Output
                    oCmd.Parameters.Add(keywords)

                    Dim description As New SqlParameter("@description", SqlDbType.VarChar, 500)
                    description.Direction = ParameterDirection.Output
                    oCmd.Parameters.Add(description)

                    Dim page_content As New SqlParameter("@page_content", SqlDbType.VarChar, -1)
                    page_content.Direction = ParameterDirection.Output
                    oCmd.Parameters.Add(page_content)

                    Dim pn As New SqlParameter("@page_name", SqlDbType.VarChar, 500)
                    pn.Direction = ParameterDirection.Output
                    oCmd.Parameters.Add(pn)

                    oCmd.ExecuteNonQuery()

                    redirectMePlease(pn.Value)

                    'Page.Title = title.Value
                    pageTitle.InnerText = title.Value
                    pageContent.InnerHtml = page_content.Value

                Else

                    page_name = Request.QueryString("name")

                    redirectMePlease(page_name)

                    oCmd.Connection = oConn
                    oCmd.CommandText = "proc_Get_Content"
                    oCmd.CommandType = Data.CommandType.StoredProcedure
                    oCmd.Parameters.Add("@page_name", Data.SqlDbType.VarChar, 500).Value = page_name

                    Dim title As New SqlParameter("@title", SqlDbType.VarChar, 500)
                    title.Direction = ParameterDirection.Output
                    oCmd.Parameters.Add(title)

                    Dim keywords As New SqlParameter("@keywords", SqlDbType.VarChar, 500)
                    keywords.Direction = ParameterDirection.Output
                    oCmd.Parameters.Add(keywords)

                    Dim description As New SqlParameter("@description", SqlDbType.VarChar, 500)
                    description.Direction = ParameterDirection.Output
                    oCmd.Parameters.Add(description)

                    Dim page_content As New SqlParameter("@page_content", SqlDbType.VarChar, -1)
                    page_content.Direction = ParameterDirection.Output
                    oCmd.Parameters.Add(page_content)

                    oCmd.ExecuteNonQuery()

                    'Page.Title = title.Value
                    pageTitle.InnerText = title.Value
                    pageContent.InnerHtml = page_content.Value

                End If
            End Using
        End Using

    End Sub

    Protected Sub redirectMePlease(ByVal page_name As String)
        If page_name = "Home" Then
            Response.Redirect("./Mobile_Default.aspx")
        ElseIf page_name = "Contact-Us" Then
            Response.Redirect("./Mobile_Contact.aspx")
        End If
    End Sub

End Class

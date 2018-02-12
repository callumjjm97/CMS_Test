Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Partial Class Content
    Inherits System.Web.UI.Page
    Dim oConn As New Data.SqlClient.SqlConnection

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString
        oConn.Open()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            setContent()
        End If

    End Sub

    Sub setContent()

        Dim page_id As Int32 = 0
        Dim page_name As String = ""

        'MK 8 Mar 2017 - 124372 - Links to use page ids
        If Not Request.QueryString("id") Is Nothing Then
            Int32.TryParse(Request.QueryString("id"), page_id)
        End If

        Dim oCmd As New Data.SqlClient.SqlCommand

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

            Page.Title = title.Value
            pageTitle.InnerText = title.Value
            pageContent.InnerHtml = page_content.Value

        Else

            page_name = Request.QueryString("name")

            redirectMePlease(page_name)

            'If page_name = "Home" Then
            '    Response.Redirect("default.aspx")
            'ElseIf page_name = "Calendar" Then
            '    Response.Redirect("Calendar.aspx")
            'ElseIf page_name = "Contact-Us" Then
            '    Response.Redirect("Contact.aspx")
            'ElseIf page_name = "Teaching-and-Learning" Then
            '    Response.Redirect("TeachAndLearn.aspx")
            'ElseIf page_name = "Vacancies" Then
            '    Response.Redirect("Vacancies.aspx")
            'ElseIf page_name = "Options-Online-System" Then
            '    Response.Redirect("http://www.thejohnwallisacademy.org/options/logon.php")
            'ElseIf page_name = "Login" Then
            '    Response.Redirect("http://www.thejohnwallisacademy.org/hap/login.aspx")
            'End If

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

            Page.Title = title.Value
            pageTitle.InnerText = title.Value

        'Dim PageCarousel As String
        'PageCarousel = "<div><div id=""AdHocCarousel"" class=""carousel-slide carousel fade"" data-ride=""carousel""><div role=""listbox"">"
        'PageCarousel = PageCarousel + "<div class=""item active""><img id=""homeImg2"" runat=""server"" alt=""Carousel Image"" src=""Images/editsmall.png""/></div>"
        'PageCarousel = PageCarousel + "<div class=""item""><img id=""homeImg2"" runat=""server"" alt=""Carousel Image"" src=""images/fixticketsmall.png""/></div>"
        'PageCarousel = PageCarousel + "<div class=""item""><img id=""homeImg2"" runat=""server"" alt=""Carousel Image"" src=""Images/smalldelete.png""/></div>"
        'PageCarousel = PageCarousel + "</div></div></div><br/>"

            pageContent.InnerHtml = page_content.Value

        End If

        oCmd.Dispose()

    End Sub

    'MK 8 Mar 2017 - 124372 - Links to use page ids
    Protected Sub redirectMePlease(ByVal page_name As String)
        If page_name = "Home" Then
            Response.Redirect("default.aspx")
        ElseIf page_name = "Calendar" Then
            Response.Redirect("Calendar.aspx")
        ElseIf page_name = "Contact-Us" Then
            Response.Redirect("Contact.aspx")
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oConn.Close()
        oConn.Dispose()
    End Sub

   
End Class


Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class CheckPageName
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function LookUpPageName() As String

        Dim result As String = ""

        Try
            Dim page_name As String = Context.Request.ServerVariables("HTTP_page_name")
            Dim page_id As Integer = Context.Request.ServerVariables("HTTP_page_id")
            Dim login_id As Integer = Context.Request.ServerVariables("HTTP_login_id")

            Dim oConn As New Data.SqlClient.SqlConnection
            Dim oCmd As New Data.SqlClient.SqlCommand
            oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

            oConn.Open()
            oCmd.Connection = oConn
            oCmd.CommandText = "proc_CMS_Check_Page_Name"
            oCmd.CommandType = Data.CommandType.StoredProcedure
            oCmd.Parameters.Add("@page_name", Data.SqlDbType.VarChar, 500).Value = page_name
            oCmd.Parameters.Add("@page_id", SqlDbType.Int).Value = page_id
            oCmd.Parameters.Add("@login_id", SqlDbType.Int).Value = login_id

            Dim page_exists As New SqlParameter("@page_exists", SqlDbType.Int)
            page_exists.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(page_exists)

            oCmd.ExecuteNonQuery()

            oCmd.Dispose()
            oConn.Close()
            oConn.Dispose()

            result = page_exists.Value.ToString

        Catch ex As Exception
            result = "Faied " & ex.Message
        End Try

        Return result

    End Function

End Class
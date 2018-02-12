Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class FileLocations
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetFileLocs() As String
        Try

            Dim Result As String = ""

            Dim filename As String = Context.Request.ServerVariables("HTTP_Filename")

            Dim oConn As New Data.SqlClient.SqlConnection
            Dim oCmd As New Data.SqlClient.SqlCommand
            Dim reader As System.Data.SqlClient.SqlDataReader

            oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString
            oConn.Open()
            oCmd.Connection = oConn
            oCmd.CommandText = "proc_CMS_Lookup_File"
            oCmd.CommandType = Data.CommandType.StoredProcedure
            oCmd.Parameters.Add("@filename", Data.SqlDbType.VarChar, -1).Value = filename
            reader = oCmd.ExecuteReader()

            While (reader.Read())

                Result += reader("title") & ", "

            End While

            oCmd.Dispose()
            oConn.Close()
            oConn.Dispose()

            Result = Result.Remove(Result.Length - 2)

            Return Result

        Catch ex As Exception
            Return "Failed"
        End Try
    End Function

End Class

Partial Class Admin_WhatsOn
    Inherits System.Web.UI.Page
    Dim oConn As New Data.SqlClient.SqlConnection

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

        oConn.Open()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            whatsonGV.DataBind()
        End If
    End Sub

    Protected Sub addNewBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addNewBtn.Click
        Response.Redirect("WhatsOnEdit.aspx")
    End Sub

    Protected Sub RemoveLine(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim btn As ImageButton = CType(sender, ImageButton)
        Dim CommandArguments As String() = btn.CommandArgument.Split(",")
        Dim rowid As String = CommandArguments(0)


        Dim oCmd As New Data.SqlClient.SqlCommand

        oCmd.Connection = oConn
        oCmd.CommandText = "proc_CMS_DEL_WhatsOn"
        oCmd.CommandType = Data.CommandType.StoredProcedure
        oCmd.Parameters.Add("@wo_id", Data.SqlDbType.Int).Value = rowid

        oCmd.ExecuteNonQuery()

        whatsonGV.DataBind()

        oCmd.Dispose()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oConn.Close()
        oConn.Dispose()
    End Sub

    Protected Sub whatsonGV_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles whatsonGV.RowCommand
        If e.CommandName = "MoveToPos" Then
            Dim oCmd As New Data.SqlClient.SqlCommand
            oCmd.Connection = oConn

            oCmd.CommandText = "proc_CMS_UPD_WhatsOn_Pos"
            oCmd.CommandType = Data.CommandType.StoredProcedure
            oCmd.Parameters.Add("@ID", Data.SqlDbType.Int).Value = e.CommandArgument
            oCmd.Parameters.Add("@NewPos", Data.SqlDbType.Int).Value = HF_NewPos.Value
            oCmd.ExecuteNonQuery()
            oCmd.Dispose()
            whatsonGV.DataBind()
        End If
    End Sub
End Class

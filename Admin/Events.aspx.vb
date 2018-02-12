Imports System.Data.SqlClient
Imports System.Data

Partial Class Admin_Events
    Inherits System.Web.UI.Page

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In eventGV.Rows
            If row.RowType = DataControlRowType.DataRow Then
                row.Attributes("onmouseover") = "this.style.cursor='pointer';this.style.color='#B80C1C';"
                row.Attributes("onmouseout") = "this.style.color='black';"

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(eventGV, "Select$" & row.DataItemIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

    Protected Sub eventGV_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles eventGV.SelectedIndexChanged

        sqlevent.SelectParameters("event_id").DefaultValue = eventGV.SelectedRow.Cells(0).Text

        buttonDiv.Visible = True

    End Sub

    Protected Sub saveButton_Click(sender As Object, e As System.EventArgs) Handles saveButton.Click
        
            Dim oConn As New Data.SqlClient.SqlConnection
            Dim oCmd As New Data.SqlClient.SqlCommand
            oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

            oConn.Open()
            oCmd.Connection = oConn
            oCmd.CommandText = "proc_CMS_Save_Event"
            oCmd.CommandType = Data.CommandType.StoredProcedure
            oCmd.Parameters.Add("@event_id", Data.SqlDbType.Int).Value = eventGV.SelectedRow.Cells(0).Text
            oCmd.Parameters.Add("@event_from", Data.SqlDbType.DateTime).Value = CType(eventFV.FindControl("startTextBox"), TextBox).Text
            oCmd.Parameters.Add("@event_to", Data.SqlDbType.DateTime).Value = CType(eventFV.FindControl("endTextBox"), TextBox).Text
            oCmd.Parameters.Add("@event_Desc", Data.SqlDbType.VarChar, 50000).Value = CType(eventFV.FindControl("descTextBox"), TextBox).Text
            oCmd.Parameters.Add("@showonHome", Data.SqlDbType.Bit).Value = CType(eventFV.FindControl("homeCheckBox"), CheckBox).Checked
            oCmd.Parameters.Add("@login_id", Data.SqlDbType.Int).Value = Session("User_Id")

            oCmd.ExecuteNonQuery()

            oCmd.Dispose()
            oConn.Close()
            oConn.Dispose()
        
        sqleventList.DataBind()
        eventGV.DataBind()

    End Sub

    Protected Sub deleteButton_Click(sender As Object, e As System.EventArgs) Handles deleteButton.Click
        If Remove.Value = "1" Then
            
                Dim oConn As New Data.SqlClient.SqlConnection
                Dim oCmd As New Data.SqlClient.SqlCommand
                oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

                oConn.Open()
                oCmd.Connection = oConn
                oCmd.CommandText = "proc_CMS_Delete_Event"
                oCmd.CommandType = Data.CommandType.StoredProcedure

                oCmd.Parameters.Add("@login_id", Data.SqlDbType.Int).Value = Session("User_Id")

                oCmd.Parameters.Add("@event_id", Data.SqlDbType.Int).Value = eventGV.SelectedRow.Cells(0).Text

                oCmd.ExecuteNonQuery()

                oCmd.Dispose()
                oConn.Close()
                oConn.Dispose()
            End If
            

            Response.Redirect("events.aspx")


    End Sub

    Protected Sub newButton_Click(sender As Object, e As System.EventArgs) Handles saveNewButton.Click

        Dim oConn As New Data.SqlClient.SqlConnection
        Dim oCmd As New Data.SqlClient.SqlCommand
        oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

        oConn.Open()
        oCmd.Connection = oConn
        oCmd.CommandText = "proc_CMS_Add_Event"
        oCmd.CommandType = Data.CommandType.StoredProcedure
        oCmd.Parameters.Add("@event_date", Data.SqlDbType.DateTime).Value = newdateTextBox.Text
        oCmd.Parameters.Add("@event_Desc", Data.SqlDbType.VarChar, 50000).Value = newdescTextBox.Text
        oCmd.Parameters.Add("@login_id", Data.SqlDbType.Int).Value = Session("User_Id")

        Dim event_id As New SqlParameter("@event_id", SqlDbType.Int)
        event_id.Direction = ParameterDirection.Output
        oCmd.Parameters.Add(event_id)

        oCmd.ExecuteNonQuery()

        oCmd.Dispose()
        oConn.Close()
        oConn.Dispose()

        sqleventList.DataBind()

        eventFV.DataBind()
        eventGV.DataBind()

        
    End Sub
End Class

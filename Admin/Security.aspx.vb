Imports System.Data
Imports System.Data.SqlClient

Partial Class Admin_Security
    Inherits System.Web.UI.Page

    Dim oConn As New Data.SqlClient.SqlConnection

    'Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
    '    buildPermissions()
    'End Sub

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In userGV.Rows
            If row.RowType = DataControlRowType.DataRow Then
                row.Attributes("onmouseover") = "this.style.cursor='hand';this.style.color='#B80C1C';"
                row.Attributes("onmouseout") = "this.style.color='black';"

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(userGV, "Select$" & row.DataItemIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

        oConn.Open()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load


    End Sub



    Protected Sub userGV_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles userGV.SelectedIndexChanged

        sqluserdetail.SelectParameters("login_id").DefaultValue = userGV.SelectedRow.Cells(0).Text

        userFV.DataBind()

        buildPermissions()

        saveButton.Visible = True
        permLabel.Visible = True

    End Sub

    Protected Sub saveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveButton.Click



        Dim permtable As Table = permPanel.FindControl("resultstable")

        'Dim a As Integer = permtable.Rows.Count


        Dim oCmd As New Data.SqlClient.SqlCommand
        
        oCmd.Connection = oConn
        oCmd.CommandText = "proc_CMS_Update_User"
        oCmd.CommandType = Data.CommandType.StoredProcedure
        oCmd.Parameters.Add("@login_id", Data.SqlDbType.Int).Value = CType(userFV.FindControl("loginidHF"), HiddenField).Value
        oCmd.Parameters.Add("@login_name", Data.SqlDbType.VarChar, 500).Value = CType(userFV.FindControl("loginnameTextBox"), TextBox).Text
        oCmd.Parameters.Add("@Full_name", Data.SqlDbType.VarChar, 500).Value = CType(userFV.FindControl("nameTextBox"), TextBox).Text
        oCmd.Parameters.Add("@email_address", Data.SqlDbType.VarChar, 500).Value = CType(userFV.FindControl("emailTextBox"), TextBox).Text
        oCmd.Parameters.Add("@Deleted", Data.SqlDbType.Bit).Value = CType(userFV.FindControl("deletedCheckBox"), CheckBox).Checked
        oCmd.Parameters.Add("@password", Data.SqlDbType.VarChar, 500).Value = CType(userFV.FindControl("confirmpasswordTextBox"), TextBox).Text

        oCmd.Parameters.Add("@role_id", Data.SqlDbType.Int).Value = CType(userFV.FindControl("roleDD"), DropDownList).SelectedValue

        oCmd.Parameters.Add("@areaids", Data.SqlDbType.VarChar, 50000).Value = permissionsHF.Value

        Dim IsDeleted As New Data.SqlClient.SqlParameter("@IsDeleted", Data.SqlDbType.Bit)
        IsDeleted.Direction = Data.ParameterDirection.Output
        oCmd.Parameters.Add(IsDeleted)

        oCmd.ExecuteNonQuery()

        oCmd.Dispose()


        'AR 8 Feb 2016 - Shows default login on deletion, change as appropriate
        If IsDeleted.Value = True Then
            Dim loginid As HiddenField = CType(userFV.FindControl("loginidHF"), HiddenField)
            loginid.Value = "6"
            sqluserdetail.SelectParameters("login_id").DefaultValue = 6

            permPanel.Controls.Clear()
            permissionsHF.Value = ""

            userGV.DataBind()

        End If
        buildPermissions()


    End Sub

    Sub buildPermissions()

        Dim tableCount As Integer = 0

        If Not userFV.FindControl("loginidHF") Is Nothing Then

            Dim permissionsString As String = ""

            Dim permissionsTable As New DataTable
            ' Create four typed columns in the DataTable.
            permissionsTable.Columns.Add("page_Id", GetType(Integer))
            permissionsTable.Columns.Add("page_name", GetType(String))
            permissionsTable.Columns.Add("sort_order", GetType(String))
            permissionsTable.Columns.Add("parent_page", GetType(Integer))
            permissionsTable.Columns.Add("user_allowed", GetType(Boolean))

            Dim oCmd As New Data.SqlClient.SqlCommand
            Dim reader As System.Data.SqlClient.SqlDataReader

            oCmd.Connection = oConn
            oCmd.CommandText = "proc_CMS_Get_Page_Permissions"
            oCmd.CommandType = Data.CommandType.StoredProcedure
            oCmd.Parameters.Add("@login_id", Data.SqlDbType.Int).Value = CType(userFV.FindControl("loginidHF"), HiddenField).Value
            reader = oCmd.ExecuteReader




            While reader.Read
                permissionsTable.Rows.Add(reader("page_id"), reader("page_name"), reader("sort_order"), reader("parent_page"), reader("user_allowed"))

                If reader("user_allowed") = True Then
                    permissionsString = permissionsString & "," & reader("page_id")
                End If


            End While

            'And Page.FindControl("SubjectsTable") Is Nothing 

            reader.Close()
            oCmd.Dispose()

            permissionsHF.Value = permissionsString

            permPanel.Controls.Clear()

            Dim resultstable As New Table

            resultstable.CellSpacing = 0
            resultstable.Style("width") = "100%"
            resultstable.ID = "resultstable"

            Dim resultsRow As New TableHeaderRow

            For Each row As DataRow In permissionsTable.Rows

                Dim resultsCell As New TableCell
                resultsCell.VerticalAlign = VerticalAlign.Top

                If row.Item("parent_page") = 0 Then

                    Dim permTable As New Table
                    permTable.ID = row.Item("page_name") & "Table"
                    permTable.ClientIDMode = UI.ClientIDMode.Static
                    permTable.CssClass = "permTable"
                    Dim permRow As New TableRow
                    Dim permCell As New TableCell
                    permCell.CssClass = "permissionsParentCell"

                    Dim cellCheckBox As New CheckBox
                    cellCheckBox.Text = row.Item("page_name")
                    cellCheckBox.Checked = row.Item("User_allowed")
                    cellCheckBox.TextAlign = TextAlign.Right
                    cellCheckBox.Attributes.Add("onclick", "permissionSave(" & row.Item("page_id") & "); ParentClick(this," & permTable.ClientID & ")")
                    cellCheckBox.CssClass = "permissionsParent"

                    permCell.Controls.Add(cellCheckBox)
                    permRow.Controls.Add(permCell)
                    permTable.Controls.Add(permRow)

                    For Each parentrow As DataRow In permissionsTable.Rows

                        If parentrow.Item("parent_page") = row.Item("page_Id") Then

                            Dim parentpermRow As New TableRow
                            Dim parentpermCell As New TableCell
                            parentpermCell.CssClass = "permissionsChildCell"

                            Dim parentcellCheckBox As New CheckBox
                            parentcellCheckBox.Text = parentrow.Item("page_name")
                            parentcellCheckBox.Checked = parentrow.Item("User_allowed")
                            parentcellCheckBox.TextAlign = TextAlign.Right
                            parentcellCheckBox.Attributes.Add("onclick", "permissionSave(" & parentrow.Item("page_id") & ")")
                            parentcellCheckBox.CssClass = "permissionsChild"

                            parentpermCell.Controls.Add(parentcellCheckBox)
                            parentpermRow.Controls.Add(parentpermCell)
                            permTable.Controls.Add(parentpermRow)

                        End If
                    Next

                    resultsCell.Controls.Add(permTable)

                    tableCount = tableCount + 1
                End If

                If resultsCell.Controls.Count > 0 Then
                    resultsRow.Controls.Add(resultsCell)
                End If

                If tableCount = 5 Then
                    tableCount = 0
                    resultstable.Controls.Add(resultsRow)
                    resultsRow = New TableHeaderRow
                End If
            Next

            If tableCount < 5 Then
                resultstable.Controls.Add(resultsRow)
            End If

            permPanel.Controls.Add(resultstable)

        End If

    End Sub

    Protected Sub saveNewButton_Click(sender As Object, e As System.EventArgs) Handles saveNewButton.Click

        If passwordHF.Value = "1" And conpasswordHF.Value = "1" Then

            Dim oCmd As New Data.SqlClient.SqlCommand

            oCmd.Connection = oConn
            oCmd.CommandText = "proc_CMS_Add_User"
            oCmd.CommandType = Data.CommandType.StoredProcedure
            oCmd.Parameters.Add("@login_id", SqlDbType.Int).Value = Session("User_Id")
            oCmd.Parameters.Add("@login_name", Data.SqlDbType.VarChar, 500).Value = newuserTextBox.Text
            oCmd.Parameters.Add("@password", Data.SqlDbType.VarChar, 500).Value = newpassTextBox.Text

            Dim new_login_id As New SqlParameter("@new_login_id", SqlDbType.Int)
            new_login_id.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(new_login_id)

            oCmd.ExecuteNonQuery()

            oCmd.Dispose()
            

            sqluserdetail.SelectParameters("login_id").DefaultValue = new_login_id.Value

            userGV.DataBind()
            userFV.DataBind()

            buildPermissions()

            saveButton.Visible = True
            permLabel.Visible = True
        Else
            Dim message As String = "Please correct any errors for the passwords and make sure they match."
            Dim sb As New System.Text.StringBuilder()
            sb.Append("<script type = 'text/javascript'>")
            sb.Append("window.onload=function(){")
            sb.Append("alert('")
            sb.Append(message)
            sb.Append("')};")
            sb.Append("</script>")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        End If

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oConn.Close()
        oConn.Dispose()
    End Sub
End Class

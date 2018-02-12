
Partial Class Admin_Admin
    Inherits System.Web.UI.MasterPage
    Dim oConn As New Data.SqlClient.SqlConnection

    Protected Sub logoutButton_Click(sender As Object, e As System.EventArgs) Handles logoutButton.Click

        FormsAuthentication.SignOut()

        'Response.Redirect(ConfigurationManager.AppSettings("URL"))
        Response.Redirect("./Login.aspx")

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

        oConn.Open()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        headerLabel.Text = "Website Admin - " & Session("site_name")

        If IsNothing(Session("User_Id")) Then
            Response.Redirect("login.aspx")
        Else
            If Session("User_Id").ToString = "" Then
                Response.Redirect("login.aspx")
            End If
        End If

        loadPages()

        If Session("role") <> "Approver" Then
            NavigationMenu.Items(1).Selectable = False
        Else
            NavigationMenu.Items(1).Selectable = True
        End If

    End Sub

    Sub loadPages()

        'load the list of pages
        treeviewDiv.InnerHtml = ""

        Dim menuhtml As String = ""


        Dim oCmd As New Data.SqlClient.SqlCommand
        Dim reader As System.Data.SqlClient.SqlDataReader

        oCmd.Connection = oConn
        oCmd.CommandText = "proc_CMS_Get_Pages"
        oCmd.CommandType = Data.CommandType.StoredProcedure
        oCmd.Parameters.Add("@login_id", Data.SqlDbType.Int).Value = Session("User_Id")
        reader = oCmd.ExecuteReader

        While reader.Read

            menuhtml = reader("page_name")

            treeIDsHF.Value = reader("treeIDs")

        End While

        reader.Close()
        oCmd.Dispose()

        treeviewDiv.InnerHtml = menuhtml

        otherpagesRepeater.DataBind()

    End Sub

    Protected Sub menuSaveButton_Click(sender As Object, e As System.EventArgs) Handles menuSaveButton.Click

        Dim pageIDs() As String
        Dim SaveIDs() As String

        Dim saveSplit() As String

        Dim page_id As Integer = 0
        Dim sortOrder As Integer = 2
        Dim sortOrderChild As Integer = 1
        Dim parent_page As Integer = 0

        pageIDs = treeIDsHF.Value.Split(",")

        SaveIDs = saveStringHF.Value.Split(",")

        For i = 0 To SaveIDs.Count - 1

            saveSplit = SaveIDs(i).Split("-")

            page_id = pageIDs(saveSplit(0) - 1).Substring(pageIDs(saveSplit(0) - 1).IndexOf("=") + 1)

            If saveSplit(1) = 0 Then
                parent_page = 0
            Else
                parent_page = pageIDs(saveSplit(1) - 1).Substring(pageIDs(saveSplit(1) - 1).IndexOf("=") + 1)
            End If

            Dim oCmd As New Data.SqlClient.SqlCommand
            oCmd.Connection = oConn
            oCmd.CommandText = "proc_CMS_Update_Menu_Order"
            oCmd.CommandType = Data.CommandType.StoredProcedure
            oCmd.Parameters.Add("@page_id", Data.SqlDbType.Int).Value = page_id

            If parent_page = 0 Then
                oCmd.Parameters.Add("@sort_order", Data.SqlDbType.Int).Value = sortOrder
            Else
                oCmd.Parameters.Add("@sort_order", Data.SqlDbType.Int).Value = sortOrderChild
            End If

            oCmd.Parameters.Add("@parent_page", Data.SqlDbType.Int).Value = parent_page
            oCmd.Parameters.Add("@login_id", Data.SqlDbType.Int).Value = Session("User_Id")
            oCmd.ExecuteNonQuery()

            oCmd.Dispose()

            If parent_page = 0 Then
                sortOrder = sortOrder + 1
                sortOrderChild = 1
            Else
                sortOrderChild = sortOrderChild + 1
            End If

        Next

        loadPages()

    End Sub



    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oConn.Close()
        oConn.Dispose()
    End Sub
End Class
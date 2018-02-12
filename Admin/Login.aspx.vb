Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.Web
Imports System.Drawing
Imports System.IO
Imports System.Web.SessionState
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Drawing.Drawing2D

Partial Class Admin_Login
    Inherits System.Web.UI.Page
    Dim oConn As New Data.SqlClient.SqlConnection

    Protected Sub loginLinkButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles loginLinkButton.Click


        If Session("Captcha").ToString = txtCaptcha.Text Then


            Dim oCmd As New Data.SqlClient.SqlCommand
            
            oCmd.Connection = oConn
            oCmd.CommandText = "proc_CMS_Validate_User"
            oCmd.CommandType = Data.CommandType.StoredProcedure

            oCmd.Parameters.Add("@username", Data.SqlDbType.VarChar, 500).Value = txtUserName.Value
            oCmd.Parameters.Add("@password", Data.SqlDbType.VarChar, 500).Value = txtUserPass.Value

            Dim paramUserID As New SqlParameter("@user_id", SqlDbType.Int)
            paramUserID.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(paramUserID)

            Dim user_role As New SqlParameter("@user_role", SqlDbType.VarChar, 500)
            user_role.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(user_role)

            Dim site_name As New SqlParameter("@site_name", SqlDbType.VarChar, 500)
            site_name.Direction = ParameterDirection.Output
            oCmd.Parameters.Add(site_name)

            oCmd.ExecuteNonQuery()

            Session("User_Id") = paramUserID.Value
            Session("User_Name") = txtUserName.Value
            Session("Login_Time") = Date.Now
            Session("Role") = user_role.Value
            Session("site_name") = site_name.Value
            Session.Timeout = 6000

            If (paramUserID.Value > 0) Then
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Value, False)
                Response.Redirect("./Default.aspx")
            Else
                errorlabel.Text = "Invalid details - Please try again or contact your administrator"
            End If

            oCmd.Dispose()

            
        Else
            errorlabel.Text = "Captcha entered incorrectly - Please try again"
            SetCaptchaText()
        End If

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

        oConn.Open()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Page.Form.DefaultButton = loginLinkButton.UniqueID

        txtUserName.Focus()

        If Not (IsPostBack) Then
            SetCaptchaText()
        End If

    End Sub
    Private Sub SetCaptchaText()
        Dim oRandom As Random = New Random
        Dim iNumber As Integer = oRandom.Next(100000, 999999)
        Session("Captcha") = iNumber.ToString

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oConn.Close()
        oConn.Dispose()
    End Sub
End Class

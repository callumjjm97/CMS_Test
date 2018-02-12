Imports System.IO
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms

Partial Class Admin_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Capture()
        If IsNothing(Session("User_Id")) Then
            Response.Redirect("login.aspx")
        Else
            If Session("User_Id").ToString = "" Then
                Response.Redirect("login.aspx")
            End If
        End If

    End Sub
End Class

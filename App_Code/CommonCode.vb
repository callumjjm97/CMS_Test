Imports Microsoft.VisualBasic

Public Class CommonCode
    Inherits System.Web.UI.Page
    Public Sub ASPNET_MsgBox(ByVal Message As String, ByVal type As String)

        Message = Replace(Message, Chr(13), " ")
        Message = Replace(Message, Chr(10), " ")
        Dim cs As ClientScriptManager = Page.ClientScript
        cs.RegisterStartupScript(Me.GetType, "z", "showMsg_Box('" & Message & "', '" & type & "');", True)

        'showMsg_Box('Message here', 'success');
        'showMsg_Box('Message here', 'warning');
        'showMsg_Box('Message here', 'error');
        'showMsg_Box('Message here', 'message');

    End Sub

End Class

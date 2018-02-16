
Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        Dim text = myTextArea.Value

        DisplayTxt.InnerHtml += text

        myTextArea.Value = ""
    End Sub
End Class

Imports System.IO

Partial Class Admin_FileManager
    Inherits System.Web.UI.Page

    Public Function Bodger(ByVal Text As String) As String
        Bodger = "return deleteFile(this, '" & Text & "')"
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GetFilesAndDirs(Server.MapPath("~/Uploads/").ToString)
            deleteBtn.Visible = False
            pasteBtn.Visible = False
            locLabel.Text = "Current Location: Uploads\"
            errorLbl.Text = ""
            copyLabel.Text = ""
            errorLabel.Text = ""

            selectionDiv.Visible = False

        End If
    End Sub

    Protected Sub GetFilesAndDirs(ByVal location As String)
        Dim filePaths() As String = Directory.GetFiles(location)
        Dim dirPaths() As String = Directory.GetDirectories(location)

        Dim files As List(Of ListItem) = New List(Of ListItem)
        For Each filePath As String In filePaths
            'Exclude Uploads web.config file
            If Not Path.GetFileName(filePath).Contains(".config") And Not Path.GetFileName(filePath).Contains(".db") Then
                files.Add(New ListItem(Path.GetFileName(filePath), filePath))
            End If
        Next

        Dim direcs As List(Of ListItem) = New List(Of ListItem)
        For Each direc As String In dirPaths
            direcs.Add(New ListItem(Path.GetFileName(direc), direc))
        Next

        Session("dirLoc") = location

        dirRepeater.DataSource = direcs
        dirRepeater.DataBind()

        filesRepeater.DataSource = files
        filesRepeater.DataBind()

        For Each item As RepeaterItem In filesRepeater.Items
            Dim downloadBtn As ImageButton = CType(item.FindControl("lnkDownload"), ImageButton)
            Dim filePath As String = downloadBtn.CommandArgument
            Dim fileParts As String() = filePath.Split({"\Uploads\"}, 2, StringSplitOptions.RemoveEmptyEntries)
            Dim filename As String = fileParts(1)
            filename = filename.Replace("\", "/")
            filename = "../Uploads/" + filename
            downloadBtn.Attributes("onclick") = "window.open('" & filename & "'); return false;"

            Dim nameParts As String() = fileParts(1).Split(".")
            Dim ext As String = "." + nameParts(1)
            ext = ext.ToLower
            Dim fileBox As HtmlGenericControl = CType(item.FindControl("fileBox"), HtmlGenericControl)

            If ext = ".pdf" Then
                fileBox.Style.Add("background-image", "url('../images/pdf.png')")
            ElseIf ext = ".doc" Or ext = ".docx" Or ext = ".txt" Or ext = ".rtf" Then
                fileBox.Style.Add("background-image", "url('../images/word.png')")
            ElseIf ext = ".jpg" Or ext = ".jpeg" Then
                fileBox.Style.Add("background-image", "url('../images/jpg.png')")
            ElseIf ext = ".png" Then
                fileBox.Style.Add("background-image", "url('../images/png.png')")
            Else
                fileBox.Style.Add("background-image", "url('../images/file.png')")
            End If

        Next

        Dim locParts As String() = location.Split({"\Uploads"}, 2, StringSplitOptions.RemoveEmptyEntries)
        locLabel.Text = "Current Location: Uploads" & locParts(1)

        If location = Server.MapPath("~/Uploads/").ToString Then
            backBtn.Visible = False
        Else
            backBtn.Visible = True
        End If

        If Session("copyFile") IsNot Nothing And Session("copyFile") <> "" Then
            pasteBtn.Visible = True
        End If

        If successHF.Value = 1 Then
            errorLbl.Text = "File successfully uploaded."
            errorLbl.ForeColor = Drawing.Color.Green
            successHF.Value = 0
        End If

    End Sub

    Protected Sub UploadFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
        If fileName.Contains(".sql") Or fileName.Contains(".php") Or fileName.Contains(".asp") Or fileName.Contains(".aspx") Then
            errorLbl.Text = "Invalid file type. Upload failed."
        Else
            If fileName IsNot Nothing And fileName <> "" Then
                Try
                    FileUpload1.PostedFile.SaveAs(Session("dirLoc") + "/" + fileName)
                    successHF.Value = 1
                    GetFilesAndDirs(Session("dirLoc"))
                Catch ex As Exception
                    errorLbl.Text = "Failed to upload file: " & ex.Message & "."
                End Try                
            Else
                errorLbl.Text = "Please choose a file before clicking upload."
            End If
        End If
                
    End Sub

    Protected Sub DeleteFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim filePath As String = CType(sender, ImageButton).CommandArgument
        File.Delete(filePath)
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub ChangeDir(ByVal sender As Object, ByVal e As EventArgs)
        Dim newDir As String = CType(sender, ImageButton).CommandArgument
        GetFilesAndDirs(newDir)
        deleteBtn.Visible = True
    End Sub

    Protected Sub CopyFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim filePath As String = CType(sender, ImageButton).CommandArgument
        Session("copyFile") = Path.GetFileName(filePath)
        Session("copyFilePath") = filePath
        pasteBtn.Visible = True
        copyLabel.Text = "Copying file: " & filePath
    End Sub

    Protected Sub BackToUploads()
        GetFilesAndDirs(Server.MapPath("~/Uploads/"))
        deleteBtn.Visible = False
        errorLabel.Text = ""
        errorLabel.ForeColor = Drawing.Color.Red
    End Sub

    Protected Sub CancelRename(ByVal sender As Object, ByVal E As EventArgs)
        newPageDiv.Style("display") = "none"
        fadedDiv.Style("display") = "none"
        newpageTextBox.Text = ""
    End Sub

    Protected Sub RenameFile(ByVal sender As Object, ByVal e As EventArgs)
        newPageDiv.Style("display") = "block"
        fadedDiv.Style("display") = "block"
        newpageTextBox.Focus()

        Dim filePath As String = CType(sender, ImageButton).CommandArgument
        renameHF.Value = filePath

        Dim pathfil As String = renameHF.Value
        Dim fileStr As String = Path.GetFileName(pathfil)
        Dim fileParts As String() = fileStr.Split(".")
        newpageTextBox.Text = fileParts(0)

    End Sub

    Protected Sub ConfirmRename()
        Dim filePath As String = renameHF.Value
        Dim fileStr As String = Path.GetFileName(filePath)
        Dim separators() As String = {"\Uploads\"}
        Dim fileParts As String() = filePath.Split(separators, 2, StringSplitOptions.RemoveEmptyEntries)
        Dim filename As String = fileParts(1)
        filename = filename.Replace("\", "/")

        Dim nameParts As String() = fileParts(1).Split(".")
        Dim ext As String = "." + nameParts(1)

        If newpageTextBox.Text <> "" And newpageTextBox IsNot Nothing Then
            Dim newfile As String = newpageTextBox.Text + ext
            'newfile = filename.Replace(fileStr, newfile) + ext

            My.Computer.FileSystem.RenameFile(filePath, newfile)

            Dim oConn As New Data.SqlClient.SqlConnection
            Dim oCmd As New Data.SqlClient.SqlCommand
            oConn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnectionString").ConnectionString

            oConn.Open()
            oCmd.Connection = oConn
            oCmd.CommandText = "proc_CMS_Rename_File"
            oCmd.CommandType = Data.CommandType.StoredProcedure
            oCmd.Parameters.Add("@filename", Data.SqlDbType.VarChar, -1).Value = filename
            oCmd.Parameters.Add("@newfile", Data.SqlDbType.VarChar, -1).Value = newfile

            oCmd.ExecuteNonQuery()

            oCmd.Dispose()
            oConn.Close()
            oConn.Dispose()

            newPageDiv.Style("display") = "none"
            fadedDiv.Style("display") = "none"
            newpageTextBox.Text = ""

            renameHF.Value = ""

            GetFilesAndDirs(Server.MapPath("~/Uploads/"))

        Else
            errorLbl.Text = "No file name added."
        End If
    End Sub

    Protected Sub addNewBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addNewBtn.Click
        newDirDiv.Style("display") = "block"
        fadedDiv.Style("display") = "block"
        newdirTextBox.Focus()
    End Sub

    Protected Sub CancelCreate(ByVal sender As Object, ByVal E As EventArgs)
        newDirDiv.Style("display") = "none"
        fadedDiv.Style("display") = "none"
        newdirTextBox.Text = ""
    End Sub

    Protected Sub ConfirmCreate(ByVal sender As Object, ByVal E As EventArgs)
        Dim location As String = Session("dirloc")
        If newdirTextBox.Text <> "" Then
            Dim newdir As String = newdirTextBox.Text
            Dim regexSearch As String = New String(Path.GetInvalidFileNameChars()) & New String(Path.GetInvalidPathChars())
            Dim r As New Regex(String.Format("[{0}]", Regex.Escape(regexSearch)))
            newdir = r.Replace(newdir, "")
            Dim folder As String = location + "/" + newdir
            If Not Directory.Exists(folder) Then
                Directory.CreateDirectory(folder)
                newDirDiv.Style("display") = "none"
                fadedDiv.Style("display") = "none"
                newdirTextBox.Text = ""
                folder.Replace("/", "\")
                GetFilesAndDirs(folder)
            Else
                errorLabel.Text = "Folder already exists."
            End If
        Else
            errorLabel.Text = "Folder name cannot be empty."
        End If
    End Sub

    Protected Sub deleteBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteBtn.Click
        Dim location As String = Session("dirloc")
        If location <> "" Then
            'Specified as true to delete files and directories within path
            Directory.Delete(location, True)
            GetFilesAndDirs(Server.MapPath("~/Uploads/"))
        End If
    End Sub

    Protected Sub pasteBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pasteBtn.Click
        Dim filename As String = Session("dirLoc") & "\" & Session("copyFile")
        filename = filename.Replace("\\", "\")
        If File.Exists(filename) Then
            errorLbl.Text = "File already exists in this folder."
        Else
            File.Copy(Session("copyFilePath"), filename, False)
            errorLbl.Text = "File successfully copied into new folder."
            errorLbl.ForeColor = Drawing.Color.Green
            Session("copyFile") = Nothing
            Session("copyFilePath") = Nothing
            pasteBtn.Visible = False
            GetFilesAndDirs(Session("dirLoc"))
            copyLabel.Text = ""
        End If
    End Sub

    'AR 14 Nov 2016 - 120950: Ability to select multiple files for deleting
    Protected Sub CheckedBox(ByVal sender As Object, ByVal e As EventArgs)
        Dim count As Integer = 0
        checkedHF.Value = ""

        For Each item As RepeaterItem In filesRepeater.Items
            Dim check As CheckBox = CType(item.FindControl("deleteCheck"), CheckBox)
            If check.Checked Then
                checkedHF.Value += CType(item.FindControl("fileHF"), HiddenField).Value + ","
                count += 1
            End If
        Next

        checkedHF.Value = checkedHF.Value.Substring(0, checkedHF.Value.Length - 1)

        If count = 0 Then
            selectionDiv.Visible = False
        Else
            selectionDiv.Visible = True
        End If

        countHF.Value = count

    End Sub

    Protected Sub deleteAllBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteAllBtn.Click
        Dim files As String() = checkedHF.Value.Split(",")
        For Each fileToDelete In files
            File.Delete(fileToDelete)            
        Next
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
End Class

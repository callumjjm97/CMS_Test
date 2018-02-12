<%@ WebHandler Language="VB" Class="Captcha" %>

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

Public Class Captcha : Implements IHttpHandler, IReadOnlySessionState
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim iHeight As Integer = 80
        Dim iWidth As Integer = 190
        Dim oRandom As New Random()

        Dim aBackgroundNoiseColor As Integer() = New Integer() {150, 150, 150}
        Dim aTextColor As Integer() = New Integer() {0, 0, 0}
        Dim aFontEmSizes As Integer() = New Integer() {15, 20, 25, 30, 35}

        Dim aFontNames As String() = New String() {"Comic Sans MS", "Arial", "Times New Roman", "Georgia", "Verdana", "Geneva"}
        Dim aFontStyles As FontStyle() = New FontStyle() {FontStyle.Bold, FontStyle.Italic, FontStyle.Regular, FontStyle.Strikeout, FontStyle.Underline}
        Dim aHatchStyles As HatchStyle() = New HatchStyle() {HatchStyle.BackwardDiagonal, HatchStyle.Cross, HatchStyle.DashedDownwardDiagonal, HatchStyle.DashedHorizontal, HatchStyle.DashedUpwardDiagonal, HatchStyle.DashedVertical, _
         HatchStyle.DiagonalBrick, HatchStyle.DiagonalCross, HatchStyle.Divot, HatchStyle.DottedDiamond, HatchStyle.DottedGrid, HatchStyle.ForwardDiagonal, _
         HatchStyle.Horizontal, HatchStyle.HorizontalBrick, HatchStyle.LargeCheckerBoard, HatchStyle.LargeConfetti, HatchStyle.LargeGrid, HatchStyle.LightDownwardDiagonal, _
         HatchStyle.LightHorizontal, HatchStyle.LightUpwardDiagonal, HatchStyle.LightVertical, HatchStyle.Max, HatchStyle.Min, HatchStyle.NarrowHorizontal, _
         HatchStyle.NarrowVertical, HatchStyle.OutlinedDiamond, HatchStyle.Plaid, HatchStyle.Shingle, HatchStyle.SmallCheckerBoard, HatchStyle.SmallConfetti, _
         HatchStyle.SmallGrid, HatchStyle.SolidDiamond, HatchStyle.Sphere, HatchStyle.Trellis, HatchStyle.Vertical, HatchStyle.Wave, _
         HatchStyle.Weave, HatchStyle.WideDownwardDiagonal, HatchStyle.WideUpwardDiagonal, HatchStyle.ZigZag}

        'Get Captcha in Session
        Dim sCaptchaText As String = context.Session("Captcha").ToString()

        'Creates an output Bitmap
        Dim oOutputBitmap As New Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb)
        Dim oGraphics As Graphics = Graphics.FromImage(oOutputBitmap)
        oGraphics.TextRenderingHint = TextRenderingHint.AntiAlias

        'Create a Drawing area
        Dim oRectangleF As New RectangleF(0, 0, iWidth, iHeight)
        Dim oBrush As Brush = Nothing

        'Draw background (Lighter colors RGB 100 to 255)
        oBrush = New HatchBrush(aHatchStyles(oRandom.[Next](aHatchStyles.Length - 1)), Color.FromArgb((oRandom.[Next](100, 255)), (oRandom.[Next](100, 255)), (oRandom.[Next](100, 255))), Color.White)
        oGraphics.FillRectangle(oBrush, oRectangleF)

        Dim oMatrix As New System.Drawing.Drawing2D.Matrix()
        Dim i As Integer = 0
        For i = 0 To sCaptchaText.Length - 1
            oMatrix.Reset()
            Dim iChars As Integer = sCaptchaText.Length

            Dim x As Integer = iWidth / (iChars + 1) * i
            Dim y As Integer = iHeight / 2

            'Rotate text Random
            oMatrix.RotateAt(oRandom.[Next](-40, 40), New PointF(x, y))
            oGraphics.Transform = oMatrix


            'Draw the letters with Random Font Type, Size and Color
            'Text
            'Random Font Name and Style
            'Random Color (Darker colors RGB 0 to 100)
            oGraphics.DrawString(sCaptchaText.Substring(i, 1), New Font(aFontNames(oRandom.[Next](aFontNames.Length - 1)), aFontEmSizes(oRandom.[Next](aFontEmSizes.Length - 1)), aFontStyles(oRandom.[Next](aFontStyles.Length - 1))), New SolidBrush(Color.FromArgb(oRandom.[Next](0, 100), oRandom.[Next](0, 100), oRandom.[Next](0, 100))), x, oRandom.[Next](10, 40))
            oGraphics.ResetTransform()
        Next

        Dim oMemoryStream As New MemoryStream()
        oOutputBitmap.Save(oMemoryStream, System.Drawing.Imaging.ImageFormat.Png)
        Dim oBytes As Byte() = oMemoryStream.GetBuffer()


        oOutputBitmap.Dispose()
        oMemoryStream.Close()

        context.Response.BinaryWrite(oBytes)
        context.Response.[End]()
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class
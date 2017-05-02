using System;
using System.Drawing;
using System.Configuration;
using System.Web;
using System.Web.UI;

public class JpgHandler:IHttpHandler
{
	public JpgHandler()
	{

	}

    #region IHttpHandler 成员

    public bool IsReusable
    {
        get { return true ; }
    }
    private static Image _originalImage = null;
    private static Image GetOriginalImage(HttpContext context)
    {
        if (_originalImage == null)
        {
            _originalImage = Image.FromFile(
                context.Server.MapPath("~/images/fanwei.jpg")); 
        }
        return _originalImage.Clone() as Image;
    }
    public void ProcessRequest(HttpContext context)
    {
        Image originalImage =   GetOriginalImage(context);
        Graphics graphic = Graphics.FromImage(originalImage);
        Font font = new Font("幼圆", 24.0f, FontStyle.Regular);
        string query = HttpUtility.UrlDecode(context.Request.QueryString["query"]);
        graphic.DrawString(
            query, 
            font, 
            new SolidBrush(Color.White), 
            20.0f, 
            30);

        originalImage.Save(context.Response.OutputStream,
            System.Drawing.Imaging.ImageFormat.Jpeg);

        graphic.Dispose();
        originalImage.Dispose();
    }

    #endregion
}

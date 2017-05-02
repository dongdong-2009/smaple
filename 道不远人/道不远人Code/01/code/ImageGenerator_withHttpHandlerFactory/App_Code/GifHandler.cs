using System;
using System.Drawing;
using System.Configuration;
using System.Web;
using System.Web.UI;
/// <summary>
/// BmpHandler 的摘要说明
/// </summary>
public class GifHandler:IHttpHandler
{
	public GifHandler()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    #region IHttpHandler 成员

    public bool IsReusable
    {
        get { return true; }
    }
    private static Image _originalImage = null;
    private static Image GetOriginalImage(HttpContext context)
    {
        if (_originalImage == null)
        {
            _originalImage = Image.FromFile(
                context.Server.MapPath("~/images/fanwei2.jpg"));
        }
        return _originalImage.Clone() as Image;
    }
    public void ProcessRequest(HttpContext context)
    {
        Image originalImage = GetOriginalImage(context);
        Graphics graphic = Graphics.FromImage(originalImage);
        Font font = new Font("幼圆", 12.0f, FontStyle.Regular);
        string query = HttpUtility.UrlDecode(context.Request.QueryString["query"]);
        graphic.DrawString(
            query,
            font,
            new SolidBrush(Color.Red),
            30.0f,
           　30);

        originalImage.Save(context.Response.OutputStream,
            System.Drawing.Imaging.ImageFormat.Gif);

        graphic.Dispose();
        originalImage.Dispose();
    }

    #endregion
}

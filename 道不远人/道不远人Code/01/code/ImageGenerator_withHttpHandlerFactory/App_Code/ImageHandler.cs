using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class ImageHandler:IHttpHandlerFactory
{
	public ImageHandler()
	{

	}

    #region IHttpHandlerFactory 成员

    public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
    {
        string imgType = context.Request.QueryString["ext"];
        if(string.IsNullOrEmpty(imgType))
            imgType = "jpg";
        imgType = imgType.ToLower();

        if (imgType == "jpg")
            return new JpgHandler();
        else
            return new GifHandler();
    }

    public void ReleaseHandler(IHttpHandler handler)
    {        
    }

    #endregion
}

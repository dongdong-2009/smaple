using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// CorrectCookieDomainModule 的摘要说明
/// </summary>
public class CorrectCookieDomainModule:IHttpModule//继承IHttpModule接口
{
	public CorrectCookieDomainModule()
	{
	}

    #region IHttpModule 成员

    public void Dispose() { }

    public void Init(HttpApplication context)
    {
        //在Init中订阅事件
        context.EndRequest += new EventHandler(context_EndRequest);
    }

    /// <summary>
    /// 在HTTP执行管线的最末端更正Cookie的Domain
    /// </summary>
    void context_EndRequest(object sender, EventArgs e)
    {
        HttpContext context = ((HttpApplication)sender).Context;
        
        string domain = ".cnblogs.com";
        string cookieName = FormsAuthentication.FormsCookieName;
        HttpCookie cookie = context.Response.Cookies[cookieName];
        if (cookie != null)
        {
            //将Cookie的Domain更改为.cnblogs.com
            //这样就使Cookie能共享于所有的二级域名
            cookie.Domain = domain;

        }
    }

    #endregion
}

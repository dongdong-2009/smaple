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
/// ip 的摘要说明
/// </summary>
public class ip
{
	public ip()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 获取IP地址
    /// </summary>
    public static string IPAddress
    {
        get
        {
            string userIP;
            // HttpRequest Request = HttpContext.Current.Request;
            HttpRequest Request = HttpContext.Current.Request; // ForumContext.Current.Context.Request;
            // 如果使用代理，获取真实IP
            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                userIP = Request.ServerVariables["REMOTE_ADDR"];
            else
                userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (userIP == null || userIP == "")
                userIP = Request.UserHostAddress;
            return userIP;
        }
    }

}

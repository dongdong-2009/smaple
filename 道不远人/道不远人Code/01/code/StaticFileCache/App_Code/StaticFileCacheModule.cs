using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// StaticFileCacheModule 的摘要说明
/// </summary>
public class StaticFileCacheModule:IHttpModule
{
    public void Init(HttpApplication context)
    {
        context.BeginRequest += new EventHandler(context_BeginRequest);
    }
    void context_BeginRequest(object sender, EventArgs e)
    {
        HttpContext context = ((HttpApplication)sender).Context;
        //判断是否需要处理
        if (context.Request.AppRelativeCurrentExecutionFilePath.ToLower().EndsWith(".aspx"))
        {
            string fileUrl = "~/CacheFile/";
            string fileName = GetFileName(context);
            string filePath = context.Server.MapPath(fileUrl) + fileName;
            if (File.Exists(filePath))
            {
                //如果静态缓存文件存在，直接返回缓存文件
                context.RewritePath(fileUrl + fileName, false);
            }
        }
    }
    public static string GetFileName(HttpContext context)
    {
        //我们的缓存文件名由页面文件名加上查询字符串组成
        return context.Request.AppRelativeCurrentExecutionFilePath.ToLower()
            .Replace(".aspx", "").Replace("~/","")
            +context.Request.Url.Query.Replace("?","__").Replace("&","_")+".html";
        
    }
    public void Dispose() {}
}

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
/// StaticFileCachePageBase 的摘要说明
/// </summary>
public class StaticFileCachePageBase : System.Web.UI.Page 
{
    protected override void Render(HtmlTextWriter writer)
    {
        StringWriter sw = new StringWriter();
        HtmlTextWriter htmlw = new HtmlTextWriter(sw);
        //调用Render方法，把页面内容输出到StringWriter中
        base.Render(htmlw);
        htmlw.Flush();
        htmlw.Close();
        //获得页面内容
        string pageContent = sw.ToString();
            
        string path = Server.MapPath("~/CacheFile/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string pageUrl = StaticFileCacheModule.GetFileName(HttpContext.Current);
        //把页面内容保存到静态文件中
        using (StreamWriter stringWriter = File.AppendText(path + pageUrl))
        {
            stringWriter.Write(pageContent);
        }

        //将页面内容输出到浏览器
        Response.Write(pageContent);
    }
}

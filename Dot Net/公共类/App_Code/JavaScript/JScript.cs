using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
/// <summary>
/// 提供向页面输出客户端代码实现特殊功能的方法
/// </summary>
/// <remarks>
/// </remarks>

public class JScript
{


    /// <summary>
    /// 弹出JavaScript小窗口
    /// </summary>
    /// <param name="js">窗口信息</param>
    public static void Alert(string message)
    {

        string js = @"<Script language='JavaScript'>
                    alert('" + message + "');</Script>";
        HttpContext.Current.Response.Write(js);
    }
    public static void Alertto(string message, string cometo)
    {
        string js = @"<Script language='JavaScript'>
                    alert('" + message + "');window.parent.location=' " + cometo + " ';</Script>";
        HttpContext.Current.Response.Write(js);

    }
 
 

    public static void AlertClose(string message)
    {
        string js = @"<Script language='JavaScript'>
                    alert('" + message + "');window.close();</Script>";
        HttpContext.Current.Response.Write(js);
    }

    public static void AlertBack(string message)
    {
        string js = @"<Script language='JavaScript'>
                    alert('" + message + "'); history.go({0};</Script>";
        HttpContext.Current.Response.Write(js);

    }
    public static string Confirm(string message)
    {
        string js = @"return confirm('" + message + "')";
        return js;
    }

    public static string Confirm()
    {
        string js = @"return confirm('确定要删除吗?')";
        return js;
    }

    public static string Close()
    {
        string js = @"return window.close()";
        return js;
    }

    public static void NewOpen(string message)
    {
        string js = @"<Script language='JavaScript'>
                    window.open('" + message + "','_blank','width=300,height=300');</Script>";
        HttpContext.Current.Response.Write(js);

    }
}

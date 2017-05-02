using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.SessionState;
using System.Xml;
using System.Security;
using System.Net;
using System.Text.RegularExpressions;
/// <summary>
/// StringUtil 的摘要说明
/// 字符串的处理，字符的转换
/// </summary>
public class StringUtil
{
	public StringUtil()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static string InputText(string text, int maxLength)
    {
        text = text.Trim();
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        if (text.Length > maxLength)
            text = text.Substring(0, maxLength);
        text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
        text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
        text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
        text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
        text = text.Replace("'", "''");
        return text;
    }


    public static string TbEncode(string str)
    {

        str = str.Replace("'", "＇");
        str = str.Replace("\"", "&quot;");
        str = str.Replace("<", "&lt;");
        str = str.Replace(">", "&gt;");
        return str;
    }
    public static string TbDecode(string str)
    {

        str = str.Replace("&gt;", ">");
        str = str.Replace("&lt;", "<");
        str = str.Replace("&nbsp;", " ");
        str = str.Replace("&quot;", "\"");
        return str;
    }
    /// <summary>
    /// 删除不可见字符
    /// </summary>
    /// <param name="sourceString"></param>
    /// <returns></returns>
    public static string DeleteUnVisibleChar(string sourceString)
    {
        System.Text.StringBuilder sBuilder = new System.Text.StringBuilder(131);
        for (int i = 0; i < sourceString.Length; i++)
        {
            int Unicode = sourceString[i];
            if (Unicode >= 16)
            {
                sBuilder.Append(sourceString[i].ToString());
            }
        }
        return sBuilder.ToString();
    }

    //跌去
    public static string length(string strtb, int maxLength)
    {
        strtb = strtb.Trim();
        if (strtb.Length > maxLength)
            strtb = strtb.Substring(0, maxLength);
        return strtb;
    }
    //字符传的转换 用在查询 登陆时 防止恶意的盗取密码
    public static string EnCode2(string strtb, int maxLength)
    {
        strtb = strtb.Trim();
        if (string.IsNullOrEmpty(strtb))
            return string.Empty;
        if (strtb.Length > maxLength)
            strtb = strtb.Substring(0, maxLength);
        strtb = strtb.Replace("'", "＇");
        strtb = strtb.Replace(",", "，");
        strtb = strtb.Replace("`", "");
        strtb = strtb.Replace("--", "－－");
        strtb = strtb.Replace("-", "—");
        strtb = strtb.Replace("_", "__");
        strtb = strtb.Replace("<", "＜");
        strtb = strtb.Replace(">", "＞");
        strtb = Regex.Replace(strtb, "(\\s*[s|S][e|E][l|L][e|E][c|C][t|T]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[i|I][n|N][s|S][e|E][r|R][t|T]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[d|D][e|E][l|L][e|E][t|T][e|E]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[u|U][p|P][d|D][a|A][t|T][a|A]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[d|D][r|R][o|O][p|P]\\s*)+", "");
        return strtb;
    }

    //字符传的转换 用在查询 登陆时 防止恶意的盗取密码
    public static string EnCode(string strtb, int maxLength)
    {

        strtb = strtb.Trim();
        if (string.IsNullOrEmpty(strtb))
            return string.Empty;
        if (strtb.Length > maxLength)
            strtb = strtb.Substring(0, maxLength);
        strtb = strtb.Replace("'", "＇");
        strtb = strtb.Replace("`", "");
        strtb = strtb.Replace("^", "");
        strtb = strtb.Replace("-","—");
        strtb = strtb.Replace("--", "－－");
        strtb = Regex.Replace(strtb, "(\\s*[s|S][e|E][l|L][e|E][c|C][t|T]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[i|I][n|N][s|S][e|E][r|R][t|T]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[d|D][e|E][l|L][e|E][t|T][e|E]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[u|U][p|P][d|D][a|A][t|T][a|A]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[d|D][r|R][o|O][p|P]\\s*)+", "");
        return strtb;
    }
    //简单字符传的转换  
    public static string DeCode(string strtb)
    {
        strtb = strtb.Trim();
        if (string.IsNullOrEmpty(strtb))
            return string.Empty;
        strtb = strtb.Replace("xqj", "-");
        // strtb = strtb.Replace("quot;", "\"");

        return strtb;
    }

    //字符传的转换 用在查询 登陆时 防止恶意的盗取密码
    public static string TBCode(string strtb ,int maxLength)
    {
        strtb = strtb.Trim();
        if (string.IsNullOrEmpty(strtb))
            return string.Empty;
        if (strtb.Length > maxLength)
            strtb = strtb.Substring(0, maxLength);
        strtb = strtb.Replace("!", "");
        strtb = strtb.Replace("@", "");
        strtb = strtb.Replace("#", "");
        strtb = strtb.Replace("$", "");
        strtb = strtb.Replace("%", "");
        strtb = strtb.Replace("^", "");
        strtb = strtb.Replace("&", "");
        strtb = strtb.Replace("*", "");
        strtb = strtb.Replace("(", "");
        strtb = strtb.Replace(")", "");
        strtb = strtb.Replace("_", "");
        strtb = strtb.Replace("+", "");
        strtb = strtb.Replace("|", "");
        strtb = strtb.Replace("?", "");
        strtb = strtb.Replace("/", "");
        strtb = strtb.Replace(".", "");
        strtb = strtb.Replace(">", "");
        strtb = strtb.Replace("<", "");
        strtb = strtb.Replace("{", "");
        strtb = strtb.Replace("}", "");
        strtb = strtb.Replace("[", "");
        strtb = strtb.Replace("]", "");
        strtb = strtb.Replace("-", "");
        strtb = strtb.Replace("=", "");
        strtb = strtb.Replace(",", "");
        strtb = strtb.Replace("`", "");
        strtb = strtb.Replace("~", "");
        strtb = strtb.Replace("'", "");
        strtb = strtb.Replace(":", "");
        strtb = strtb.Replace(";", "");
        strtb = Regex.Replace(strtb, "(\\s*[s|S][e|E][l|L][e|E][c|C][t|T]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[i|I][n|N][s|S][e|E][r|R][t|T]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[d|D][e|E][l|L][e|E][t|T][e|E]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[u|U][p|P][d|D][a|A][t|T][a|A]\\s*)+", "");
        strtb = Regex.Replace(strtb, "(\\s*[d|D][r|R][o|O][p|P]\\s*)+", "");
        return strtb;
    }

    //以javascript的windous.alert()方法输出提示信息
    //strmsg 表示要输出的信息
    //back 表示输出后是否要history.back()
    //end 表示输出后是否要Response.End()
    public static void WriteMessage(string strMsg, bool Back, bool End)
    {
        string js = "";
       // Response = HttpContext.Current.Response;
        //将单引号替换,防止js出错
        strMsg = strMsg.Replace("'", "");
        //将回车符号换掉,防止js出错
        strMsg = strMsg.Replace("\r\n", "");
       js="<script language=javascript>alert('" + strMsg + "')</script>";
        if (Back)
        {
            js="<script language=javascript>history.back();</script)";
        }
        if (End)
        {
            js = "<script language=javascript>End</script)";
        }
        HttpContext.Current.Response.Write(js);   
    }

    /// <summary>
    /// 小函数，将字符串转换成float型，若字符串为空，返回0
    /// </summary>
    /// <param name="str">要转换的字符串</param>
    /// <returns>转后的float值</returns>
    public static float GetFloatValue(string str)
    {
        try
        {
            if (str.Length == 0)
                return 0;
            else
                return float.Parse(str);
        }
        catch
        {
            WriteMessage("数据转换失败，请检查数据是否合理！", true, true);
            return 0;
        }
    }
    /// <summary>
    /// 小函数，将字符串转换成int型，若字符串为空，返回0
    /// </summary>
    /// <param name="str">要转换的字符串</param>
    /// <returns>转后的int值</returns>
    public static int GetIntValue(string str)
    {
        try
        {
            if (str.Length == 0)
                return 0;
            else
            {
                if (Int32.Parse(str) == 0)
                    return 0;
                else
                    return Int32.Parse(str);
            }
        }
        catch
        {
            WriteMessage("数据转换失败，请检查数据是否合理！", true, true);
            return 0;
        }
    }
}

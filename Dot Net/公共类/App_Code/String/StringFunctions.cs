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
/// StringUtil 相关操作
/// 字符串的处理，字符的转换
/// </summary>
public class StringFunctions
{
	public StringFunctions()
	{
		//
		// TODO:
		//
	}
    /// <summary>
    /// 从字符串中的尾部删除指定的字符串
    /// </summary>
    /// <param name="sourceString"></param>
    /// <param name="removedString"></param>
    /// <returns></returns>
    public static string Remove(string sourceString, string removedString)
    {
        try
        {
            if (sourceString.IndexOf(removedString) < 0)
                throw new Exception("原字符串中不包含移除字符串！");
            string result = sourceString;
            int lengthOfSourceString = sourceString.Length;
            int lengthOfRemovedString = removedString.Length;
            int startIndex = lengthOfSourceString - lengthOfRemovedString;
            string tempSubString = sourceString.Substring(startIndex);
            if (tempSubString.ToUpper() == removedString.ToUpper())
            {
                result = sourceString.Remove(startIndex, lengthOfRemovedString);
            }
            return result;
        }
        catch
        {
            return sourceString;
        }
    }

    /// <summary>
    /// 获取拆分符右边的字符串
    /// </summary>
    /// <param name="sourceString"></param>
    /// <param name="splitChar"></param>
    /// <returns></returns>
    public static string RightSplit(string sourceString, char splitChar)
    {
        string result = null;
        string[] tempString = sourceString.Split(splitChar);
        if (tempString.Length > 0)
        {
            result = tempString[tempString.Length - 1].ToString();
        }
        return result;
    }

    /// <summary>
    /// 获取拆分符左边的字符串
    /// </summary>
    /// <param name="sourceString"></param>
    /// <param name="splitChar"></param>
    /// <returns></returns>
    public static string LeftSplit(string sourceString, char splitChar)
    {
        string result = null;
        string[] tempString = sourceString.Split(splitChar);
        if (tempString.Length > 0)
        {
            result = tempString[0].ToString();
        }
        return result;
    }

    /// <summary>
    /// 去掉最后一个逗号
    /// </summary>
    /// <param name="origin"></param>
    /// <returns></returns>
    public static string DelLastComma(string origin)
    {
        if (origin.IndexOf(",") == -1)
        {
            return origin;
        }
        return origin.Substring(0, origin.LastIndexOf(","));
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

    /// <summary>
    /// 获取数组元素的合并字符串
    /// </summary>
    /// <param name="stringArray"></param>
    /// <returns></returns>
    public static string GetArrayString(string[] stringArray)
    {
        string totalString = null;
        for (int i = 0; i < stringArray.Length; i++)
        {
            totalString = totalString + stringArray[i];
        }
        return totalString;
    }

    /// <summary>
    ///		获取某一字符串在字符串数组中出现的次数
    /// </summary>
    /// <param name="stringArray" type="string[]">
    ///     <para>
    ///         
    ///     </para>
    /// </param>
    /// <param name="findString" type="string">
    ///     <para>
    ///         
    ///     </para>
    /// </param>
    /// <returns>
    ///     A int value...
    /// </returns>
    public static int GetStringCount(string[] stringArray, string findString)
    {
        int count = -1;
        string totalString = GetArrayString(stringArray);
        string subString = totalString;

        while (subString.IndexOf(findString) >= 0)
        {
            subString = totalString.Substring(subString.IndexOf(findString));
            count += 1;
        }
        return count;
    }

    /// <summary>
    ///     获取某一字符串在字符串中出现的次数
    /// </summary>
    /// <param name="stringArray" type="string">
    ///     <para>
    ///         原字符串
    ///     </para>
    /// </param>
    /// <param name="findString" type="string">
    ///     <para>
    ///         匹配字符串
    ///     </para>
    /// </param>
    /// <returns>
    ///     匹配字符串数量
    /// </returns>
    public static int GetStringCount(string sourceString, string findString)
    {
        int count = 0;
        int findStringLength = findString.Length;
        string subString = sourceString;

        while (subString.IndexOf(findString) >= 0)
        {
            subString = subString.Substring(subString.IndexOf(findString) + findStringLength);
            count += 1;
        }
        return count;
    }

    /// <summary>
    /// 截取从startString开始到原字符串结尾的所有字符   
    /// </summary>
    /// <param name="sourceString" type="string">
    ///     <para>
    ///         
    ///     </para>
    /// </param>
    /// <param name="startString" type="string">
    ///     <para>
    ///         
    ///     </para>
    /// </param>
    /// <returns>
    ///     A string value...
    /// </returns>
    public static string GetSubString(string sourceString, string startString)
    {
        try
        {
            int index = sourceString.ToUpper().IndexOf(startString);
            if (index > 0)
            {
                return sourceString.Substring(index);
            }
            return sourceString;
        }
        catch
        {
            return "";
        }
    }

    public static string GetSubString(string sourceString, string beginRemovedString, string endRemovedString)
    {
        try
        {
            if (sourceString.IndexOf(beginRemovedString) != 0)
                beginRemovedString = "";

            if (sourceString.LastIndexOf(endRemovedString, sourceString.Length - endRemovedString.Length) < 0)
                endRemovedString = "";

            int startIndex = beginRemovedString.Length;
            int length = sourceString.Length - beginRemovedString.Length - endRemovedString.Length;
            if (length > 0)
            {
                return sourceString.Substring(startIndex, length);
            }
            return sourceString;
        }
        catch
        {
            return sourceString; ;
        }
    }

    /// <summary>
    /// 按字节数取出字符串的长度
    /// </summary>
    /// <param name="strTmp">要计算的字符串</param>
    /// <returns>字符串的字节数</returns>
    public static int GetByteCount(string strTmp)
    {
        int intCharCount = 0;
        for (int i = 0; i < strTmp.Length; i++)
        {
            if (System.Text.UTF8Encoding.UTF8.GetByteCount(strTmp.Substring(i, 1)) == 3)
            {
                intCharCount = intCharCount + 2;
            }
            else
            {
                intCharCount = intCharCount + 1;
            }
        }
        return intCharCount;
    }

    /// <summary>
    /// 按字节数要在字符串的位置
    /// </summary>
    /// <param name="intIns">字符串的位置</param>
    /// <param name="strTmp">要计算的字符串</param>
    /// <returns>字节的位置</returns>
    public static int GetByteIndex(int intIns, string strTmp)
    {
        int intReIns = 0;
        if (strTmp.Trim() == "")
        {
            return intIns;
        }
        for (int i = 0; i < strTmp.Length; i++)
        {
            if (System.Text.UTF8Encoding.UTF8.GetByteCount(strTmp.Substring(i, 1)) == 3)
            {
                intReIns = intReIns + 2;
            }
            else
            {
                intReIns = intReIns + 1;
            }
            if (intReIns >= intIns)
            {
                intReIns = i + 1;
                break;
            }
        }
        return intReIns;
    }

    /// <summary>
    /// Method to make sure that user's inputs are not malicious
    /// 截取输入最大的字符串
    /// </summary>
    /// <param name="text">User's Input</param>
    /// <param name="maxLength">Maximum length of input</param>
    /// <returns>The cleaned up version of the input</returns>
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

    /// <summary>
    /// Method to check whether input has other characters than numbers
    /// 清楚字符
    /// </summary>
    public static string CleanNonWord(string text)
    {
        return Regex.Replace(text, "\\W", "");
    }

    //特殊字符的转换
    public static string Encode(string str)
    {

        str = str.Replace("'", "＇");
        str = str.Replace("\"", "&quot;");
        str = str.Replace("<", "&lt;");
        str = str.Replace(">", "&gt;");
        return str;
    }
    public static string Decode(string str)
    {

        str = str.Replace("&gt;", ">");
        str = str.Replace("&lt;", "<");
        str = str.Replace("&nbsp;", " ");
        str = str.Replace("&quot;", "\"");
        return str;
    }
    //字符传的转换 用在查询 登陆时 防止恶意的盗取密码
    public static string TBCode(string strtb)
    {
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

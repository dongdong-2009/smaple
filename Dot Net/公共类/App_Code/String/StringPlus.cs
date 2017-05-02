using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// StringPlus 的摘要说明
/// </summary>
public class StringPlus
{
    public static string[] GetStrArray(string str)
    {
        return str.Split(new char[',']);
    }

    public static string GetArrayStr(List<string> list, string speater)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < list.Count; i++)
        {
            if (i == list.Count - 1)
            {
                sb.Append(list[i]);
            }
            else
            {
                sb.Append(list[i]);
                sb.Append(speater);
            }
        }
        return sb.ToString();
    }
    #region 删除最后一个字符之后的字符

    /// <summary>
    /// 删除最后结尾的一个逗号
    /// </summary>
    public static string DelLastComma(string str)
    {
        return str.Substring(0, str.LastIndexOf(","));
    }

    /// <summary>
    /// 删除最后结尾的指定字符后的字符
    /// </summary>
    public static string DelLastChar(string str, string strchar)
    {
        return str.Substring(0, str.LastIndexOf(strchar));
    }

    #endregion

    /// <summary>
    /// 单选框得到是否选择的数字 0 或 1
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int boolSelect(bool b)
    {
        if (b)
            return 1;
        else
            return 0;
    }

    /// <summary>
    /// 单选框得到是否选择的数字 0 或 1
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool boolSelect(int i)
    {
        if (i == 1)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 截取字符串
    /// </summary>
    /// <param name="s">文本</param>
    /// <param name="len">最长长度值</param>
    /// <returns></returns>
    public static string Fix(string s, int len)
    {
        s = System.Text.RegularExpressions.Regex.Replace(s, "<[^>]*>", "");
        string result = ""; //最终返回的结果
        int byteLen = System.Text.Encoding.Default.GetByteCount(s);  //单字节字符长度
        int charLen = s.Length; //把字符平等对待时的字符串长度
        int byteCount = 0;  //记录读取进度{中文按两单位计算}
        int pos = 0;    //记录截取位置{中文按两单位计算}
        if (byteLen > len)
        {
            for (int i = 0; i < charLen; i++)
            {
                if (Convert.ToInt32(s.ToCharArray()[i]) > 255)  //遇中文字符计数加2
                    byteCount += 2;
                else         //按英文字符计算加1
                    byteCount += 1;
                if (byteCount >= len)   //到达指定长度时，记录指针位置并停止
                {
                    pos = i;
                    break;
                }
            }
            result = s.Substring(0, pos) + "...";
        }
        else
            result = s;

        return result;
    }
}

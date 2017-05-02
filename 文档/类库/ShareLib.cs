using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Web.Security;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;

namespace YxzjLib
{
    
   public class ShareLib
    {
        /// <summary>
        /// 读取系统config的内容
        /// </summary>
        /// <param name="Nodename">节点名称</param>
        public static string XmlNodeValue(string nodeName)
        {
            XmlDocument node = new XmlDocument();
            node.Load(AppDomain.CurrentDomain.BaseDirectory + "/System.config");
            return node["SystemConfig"][nodeName].InnerText;

        }

        /// <summary>
        /// 编辑系统配置System.config
        /// </summary>
        public static void EditNodeValue(string nodeName, string nodeValue)
        {
            XmlDocument node = new XmlDocument();
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "/System.config";
            node.Load(fileName);
            node["SystemConfig"][nodeName].InnerText = nodeValue;
            node.Save(fileName);
        }
       

        /// <summary>
        /// 对文字进行截断
        /// </summary>
        /// <param name="title">文字</param>
        /// <param name="titleLength">希望获取的长度</param>
        /// <returns></returns>
        public static string ReBuildTitle(string title, int titleLength)
        {

            int templ = 0;
            for (int i = 0; i < title.Length; i++)
            {
                char a = title[i];
                if ((int)a > 255)
                {
                    templ += 2;
                }
                else
                {
                    templ++;
                }
                if (templ == titleLength)
                    return title.Substring(0, i + 1);
                else if (templ > titleLength)
                    return title.Substring(0, i);
            }
            return title;
        }        

       /// <summary>
       /// 检查文件名后缀是否合法
       /// </summary>
       /// <param name="ext">要检测的后缀名</param>
       /// <param name="str">白名单（用逗号隔开，如.gif,.jpg）</param>
       /// <returns>布尔值</returns>
       public static bool CheckImgExt(string ext, string str)
       {
           string[] arr = str.Split(',');
           foreach (string s in arr)
           {
               if (ext.ToLower() == s.ToLower())
               {
                   return true;
               }
           }
           return false;
       }

       /// <summary>
       /// 本方法分离出 网址后面的参数
       /// </summary>
       /// <param name="s">要分析的参数串</param>
       /// <param name="urlencoded">是否编码</param>
       /// <param name="encoding">编码方式</param>
       /// <returns></returns>
       public static System.Collections.Specialized.NameValueCollection FillFromString(string s, bool urlencoded, Encoding encoding)
       {
           System.Collections.Specialized.NameValueCollection nv = new System.Collections.Specialized.NameValueCollection();
           int num1 = (s != null) ? s.Length : 0;
           for (int num2 = 0; num2 < num1; num2++)
           {
               int num3 = num2;
               int num4 = -1;
               while (num2 < num1)
               {
                   char ch1 = s[num2];
                   if (ch1 == '=')
                   {
                       if (num4 < 0)
                       {
                           num4 = num2;
                       }
                   }
                   else if (ch1 == '&')
                   {
                       break;
                   }
                   num2++;
               }
               string text1 = null;
               string text2 = null;
               if (num4 >= 0)
               {
                   text1 = s.Substring(num3, num4 - num3);
                   text2 = s.Substring(num4 + 1, (num2 - num4) - 1);
               }
               else
               {
                   text2 = s.Substring(num3, num2 - num3);
               }
               if (urlencoded)
               {
                   nv.Add(HttpUtility.UrlDecode(text1, encoding), HttpUtility.UrlDecode(text2, encoding));
               }
               else
               {
                   nv.Add(text1, text2);
               }
               if ((num2 == (num1 - 1)) && (s[num2] == '&'))
               {
                   nv.Add(null, "");
               }
           }

           return nv;
       }
       /// <summary>
       /// 分离出网址里的参数串
       /// </summary>
       /// <param name="url">待分离的网址</param>
       /// <returns></returns>
       /// <remarks> asdfasdf.aspx?asdf=1&asdf=dd => asdf=1&asdf=dd</remarks>
       public static string ParseUrlParams(string url)
       { 
       //查找出问号
           if (String.IsNullOrEmpty(url)) return  String.Empty;
           int indexof = url.IndexOf("?");
           if (indexof >= 0)
           {
               return url.Substring(indexof);
           }
           else
           {
               return String.Empty;
           }
       }

       
       /// <summary>
       /// 分离出网址里的绝对路径
       /// </summary>
       /// <param name="url">待分离的网址</param>
       /// <returns>分离后所得参数，字串值</returns>
       /// <remarks> asdfasdf.aspx?asdf=1&asdf=dd => asdf=1&asdf=dd</remarks>
       public static string ParseAbsUrl(string url)
       {
           string urlParas=ParseUrlParams(url);
           if (string.IsNullOrEmpty(urlParas))
           {
               return url;
           }
           else
           {
               return url.Replace(ParseUrlParams(url), "");
           }
       }
       
       /// <summary>
       /// 把网址中分离出的参数放到集合中
       /// </summary>
       /// <param name="url">待分离的网址</param>
       /// <returns>参数集合，NameValueCollection</returns>
       public static System.Collections.Specialized.NameValueCollection FillFromString(string url)
       {
           return FillFromString(ParseUrlParams(url), false, null);
       }

       /// <summary>
       /// 字符串HTML格式化
       /// </summary>
       /// <param name="chr">待格式化的字符串</param>
       /// <returns></returns>
       public static string Boxtohtml(string chr)
       {
           if (chr == null)
           {
               return "";
           }
           else
           {
               System.Web.HttpContext.Current.Server.HtmlEncode(chr);
               //chr=chr.Replace(((char)32).ToString(),"&nbsp;");
               chr = chr.Replace("\n", "<br />");
               chr = chr.Replace("\r", "");
               chr = Regex.Replace(chr,"<img", "<img onload=\"javascript:if(this.width>screen.width-500)this.style.width=screen.width-600;\" ",RegexOptions.IgnoreCase);
               chr = Regex.Replace(chr, "<iframe.*?>.*?</iframe>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
               chr = Regex.Replace(chr, "&lt;br&gt;", "<br />", RegexOptions.IgnoreCase);
               return (chr);
           }
       }      

       /// <summary>
       /// 去除HTML
       /// </summary>
       /// <param name="temp">HTML字符串</param>
       /// <returns></returns>
       public static string FormatTitle(string temp)
       {
           return System.Text.RegularExpressions.Regex.Replace(temp, "<[^>]*>", "");
       }

 
       /// <summary>
       /// 只允许中文字符串
       /// </summary>
       /// <param name="s">要校验的字符串</param>
       /// <returns></returns>
       public static string OnlyChinese(string s)
       {
           return Regex.Replace(s, "[^\u4e00-\uf900]", "");
       }


       /// <summary>
       /// 获取首字母
       /// </summary>
       /// <param name="strText">要获取首字母的字符串</param>
       /// <returns></returns>
       static public char GetFirstLetter(string strText)
       {
           if (string.IsNullOrEmpty(strText))
               return '*';
           return getSpell(strText.Substring(0, 1)).ToUpper().ToCharArray()[0];
       }

       /// <summary>
       /// 获取汉语拼音首字母字符串
       /// </summary>
       /// <param name="strText">要获取的字符串</param>
       /// <returns></returns>
       static public string GetChineseSpell(string strText)
       {
           int len = strText.Length;
           string myStr = "";
           for (int i = 0; i < len; i++)
           {
               myStr += getSpell(strText.Substring(i, 1));
           }
           return myStr;
       }


       /// <summary>
       /// 截断字符串（按全角）
       /// </summary>
       /// <param name="s">源串</param>
       /// <param name="len">需要的长度</param>
       /// <param name="appendDots">末尾是否加省略号</param>
       /// <returns>返回串</returns>
       public static string CutString(string s, int len, bool appendDots)
       {
           string newStr = string.Empty;
           if (!string.IsNullOrEmpty(s))
           {
               if (s.Trim().Length <= len)
                   newStr = s;
               else
               {
                   newStr = s.Substring(0, len);
                   if (appendDots)
                   {
                       newStr = newStr + "…";
                   }
               }
           }         
           return newStr;
       }

       /// <summary>
       /// 检查提交字符是否含有SQL注入风险
       /// </summary>
       /// <param name="fk">提交的字符串</param>
       /// <returns></returns>
       public static bool ReplaceSql(string fk)
       {
           string[] nothis = new string[20];

           nothis[0] = "net user";

           nothis[1] = "xp_cmdshell";

           nothis[2] = "/add";

           nothis[3] = "exec%20master.dbo.xp_cmdshell";

           nothis[4] = "net localgroup administrators";

           nothis[5] = "select";

           nothis[6] = "count";

           nothis[7] = "asc";

           nothis[8] = "char";

           nothis[9] = "mid";

           nothis[10] = "'";

           nothis[11] = ":";

           nothis[12] = "\"\"";

           nothis[13] = "insert";

           nothis[14] = "delete";

           nothis[15] = "drop";

           nothis[16] = "truncate";

           nothis[17] = "from";

           nothis[18] = "%";

           nothis[19] = "@";

           bool errc = false;

           foreach (string fiter in nothis)
           {
               if (fk.IndexOf(fiter) > -1)
               {
                   errc = true;
               }
           }

           return errc;
       }
    }
}

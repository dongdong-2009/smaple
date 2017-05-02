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
        /// ��ȡϵͳconfig������
        /// </summary>
        /// <param name="Nodename">�ڵ�����</param>
        public static string XmlNodeValue(string nodeName)
        {
            XmlDocument node = new XmlDocument();
            node.Load(AppDomain.CurrentDomain.BaseDirectory + "/System.config");
            return node["SystemConfig"][nodeName].InnerText;

        }

        /// <summary>
        /// �༭ϵͳ����System.config
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
        /// �����ֽ��нض�
        /// </summary>
        /// <param name="title">����</param>
        /// <param name="titleLength">ϣ����ȡ�ĳ���</param>
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
       /// ����ļ�����׺�Ƿ�Ϸ�
       /// </summary>
       /// <param name="ext">Ҫ���ĺ�׺��</param>
       /// <param name="str">���������ö��Ÿ�������.gif,.jpg��</param>
       /// <returns>����ֵ</returns>
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
       /// ����������� ��ַ����Ĳ���
       /// </summary>
       /// <param name="s">Ҫ�����Ĳ�����</param>
       /// <param name="urlencoded">�Ƿ����</param>
       /// <param name="encoding">���뷽ʽ</param>
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
       /// �������ַ��Ĳ�����
       /// </summary>
       /// <param name="url">���������ַ</param>
       /// <returns></returns>
       /// <remarks> asdfasdf.aspx?asdf=1&asdf=dd => asdf=1&asdf=dd</remarks>
       public static string ParseUrlParams(string url)
       { 
       //���ҳ��ʺ�
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
       /// �������ַ��ľ���·��
       /// </summary>
       /// <param name="url">���������ַ</param>
       /// <returns>��������ò������ִ�ֵ</returns>
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
       /// ����ַ�з�����Ĳ����ŵ�������
       /// </summary>
       /// <param name="url">���������ַ</param>
       /// <returns>�������ϣ�NameValueCollection</returns>
       public static System.Collections.Specialized.NameValueCollection FillFromString(string url)
       {
           return FillFromString(ParseUrlParams(url), false, null);
       }

       /// <summary>
       /// �ַ���HTML��ʽ��
       /// </summary>
       /// <param name="chr">����ʽ�����ַ���</param>
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
       /// ȥ��HTML
       /// </summary>
       /// <param name="temp">HTML�ַ���</param>
       /// <returns></returns>
       public static string FormatTitle(string temp)
       {
           return System.Text.RegularExpressions.Regex.Replace(temp, "<[^>]*>", "");
       }

 
       /// <summary>
       /// ֻ���������ַ���
       /// </summary>
       /// <param name="s">ҪУ����ַ���</param>
       /// <returns></returns>
       public static string OnlyChinese(string s)
       {
           return Regex.Replace(s, "[^\u4e00-\uf900]", "");
       }


       /// <summary>
       /// ��ȡ����ĸ
       /// </summary>
       /// <param name="strText">Ҫ��ȡ����ĸ���ַ���</param>
       /// <returns></returns>
       static public char GetFirstLetter(string strText)
       {
           if (string.IsNullOrEmpty(strText))
               return '*';
           return getSpell(strText.Substring(0, 1)).ToUpper().ToCharArray()[0];
       }

       /// <summary>
       /// ��ȡ����ƴ������ĸ�ַ���
       /// </summary>
       /// <param name="strText">Ҫ��ȡ���ַ���</param>
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
       /// �ض��ַ�������ȫ�ǣ�
       /// </summary>
       /// <param name="s">Դ��</param>
       /// <param name="len">��Ҫ�ĳ���</param>
       /// <param name="appendDots">ĩβ�Ƿ��ʡ�Ժ�</param>
       /// <returns>���ش�</returns>
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
                       newStr = newStr + "��";
                   }
               }
           }         
           return newStr;
       }

       /// <summary>
       /// ����ύ�ַ��Ƿ���SQLע�����
       /// </summary>
       /// <param name="fk">�ύ���ַ���</param>
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Globalization;

namespace MobileControlLibrary.UI
{
    /// <summary>
    /// WML工具类，主要用于字符编码处理
    /// </summary>
    public class WMLUtility
    {
        const char _char1 = '\x0021';
        const char _char2 = '\x0080';
        const string _prefix = "&#x";
        const string _postfix = ";";
        static readonly Regex _decodeRegex = new Regex(@"&#x([0-9a-zA-Z]{2,4});"
            , RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
        
        /// <summary>
        /// 将字符编码成能被手机正常显示的格式
        /// </summary>
        public static string WMLEncode(string value)
        {
            value = HttpUtility.HtmlEncode(value);
            return _WMLEncode(value);
        }

        /// <summary>
        /// 将字符编码成能被手机正常显示的格式
        /// </summary>
        public static string WMLAttributeEncode(string value)
        {
            value = HttpUtility.HtmlAttributeEncode(value);
            return _WMLEncode(value);
        }

        /// <summary>
        /// 将能被手机正常显示格式的字符解码还原
        /// </summary>
        public static string WMLDecode(string value)
        {
            value = _decodeRegex.Replace(value
                , delegate(Match m)
            {
                return char.ConvertFromUtf32(
                    int.Parse(m.Groups[1].Value
                        , NumberStyles.AllowHexSpecifier));
            });
            return HttpUtility.HtmlDecode(value);
        }

        private static string _WMLEncode(string value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (c > _char1)
                {
                    if (c < _char2)
                    {
                        sb.Append(c);
                    }
                    else
                    {
                        sb.Append(_prefix);
                        sb.Append(((int)c).ToString("X4"));
                        sb.Append(_postfix);
                    }
                }
            }
            return sb.ToString();
        }
    }
}

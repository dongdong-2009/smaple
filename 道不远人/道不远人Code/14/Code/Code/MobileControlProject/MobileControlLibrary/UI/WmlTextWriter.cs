using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Web;

namespace MobileControlLibrary.UI
{
    /// <summary>
    /// 支持WML标签和属性的TextWriter
    /// 用于控件呈现过程
    /// </summary>
    public class WmlTextWriter:HtmlTextWriter
    {

        public WmlTextWriter(TextWriter writer)
            : base(writer)
        {
        }

        /// <summary>
        /// 添加WML属性到输入流
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value">属性值，会自动进行编码</param>
        public void AddMobileAttribute(MobileAttribute attribute, string value)
        {
            string attributeName = null;
            switch (attribute)
            {
                case MobileAttribute.HttpEquiv:
                    attributeName = "http-equiv"; break;
                case MobileAttribute.CacheControl:
                    attributeName = "cache-control"; break;
                case MobileAttribute.AcceptCharset:
                    attributeName = "accept-charset"; break;
                default:
                    attributeName = attribute.ToString().ToLower(); break;
            }
            if (!String.IsNullOrEmpty(value))
            {
                value = WMLUtility.WMLAttributeEncode(value);
            }
            base.AddAttribute(attributeName, value,false);
        }

        /// <summary>
        /// 生成WML标签
        /// </summary>
        /// <param name="tag"></param>
        public void RenderWmlBeginTag(MobileTag tag)
        {
            string tagName = tag.ToString().ToLower();
            base.RenderBeginTag(tagName);
        }
    }
}

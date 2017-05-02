using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Web;

namespace MobileControlLibrary.UI
{
    /// <summary>
    /// ֧��WML��ǩ�����Ե�TextWriter
    /// ���ڿؼ����ֹ���
    /// </summary>
    public class WmlTextWriter:HtmlTextWriter
    {

        public WmlTextWriter(TextWriter writer)
            : base(writer)
        {
        }

        /// <summary>
        /// ���WML���Ե�������
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value">����ֵ�����Զ����б���</param>
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
        /// ����WML��ǩ
        /// </summary>
        /// <param name="tag"></param>
        public void RenderWmlBeginTag(MobileTag tag)
        {
            string tagName = tag.ToString().ToLower();
            base.RenderBeginTag(tagName);
        }
    }
}

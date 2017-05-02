using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace MobileControlLibrary.UI.Controls
{
    /// <summary>
    /// WML����ò�Ҫֱ�ӳ�������
    /// ���ڴ���Ĭ�ϵ�Literal�ؼ������ֱ������ı�
    /// </summary>
    public class MobileLiteral:Literal,IFields
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            string text = Text;
            if (!String.IsNullOrEmpty(text))
            {
                writer.Write(WMLUtility.WMLEncode(text));
            }
        }
    }
}

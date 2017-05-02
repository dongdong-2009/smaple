using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace MobileControlLibrary.UI.Controls
{
    /// <summary>
    /// WML中最好不要直接呈现中文
    /// 用于代替默认的Literal控件，呈现编码后的文本
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace MobileControlLibrary.UI.Controls
{
    /// <summary>
    /// Button生成<anchor><go><postfield/></go></anchor>结构
    /// 模拟ASP.NET的回传按钮
    /// </summary>
    public class Button : System.Web.UI.WebControls.Button, INavElmts
    {
        protected override void Render(HtmlTextWriter writer)
        {
            //设计时使用基类逻辑
            if (DesignMode)
            {
                base.Render(writer);
            }
            else
            {
                WmlTextWriter wmlWriter = writer as WmlTextWriter;
                wmlWriter.RenderWmlBeginTag(MobileTag.Anchor);
                wmlWriter.Write(WMLUtility.WMLEncode(Text));
                wmlWriter.AddMobileAttribute(MobileAttribute.AcceptCharset, "UTF-8");
                string href = Page.Request.Url.PathAndQuery;
                if (!String.IsNullOrEmpty(PostBackUrl))
                {
                    href = PostBackUrl;
                }
                href = Page.Response.ApplyAppPathModifier(href);
                wmlWriter.AddMobileAttribute(MobileAttribute.Href, href);
                wmlWriter.AddMobileAttribute(MobileAttribute.Method, "post");
                wmlWriter.RenderWmlBeginTag(MobileTag.Go);
                AddPostField(wmlWriter);
                wmlWriter.RenderEndTag();//go
                wmlWriter.RenderEndTag();//anchor
            }
        }

        /// <summary>
        /// 将页面中的所有FormField元素呈现为<go>元素的PostField
        /// 包括__EVENTTARGET和__EVENTARGUMENT两个值
        /// </summary>
        /// <param name="writer"></param>
        protected virtual void AddPostField(WmlTextWriter writer)
        {
            FormFieldControlCollection fieldControls = (Page as MobilePage).FormFields;
            foreach (FormFiledControl fieldControl in fieldControls)
            {
                string name = fieldControl.ClientID;
                string value = fieldControl.GetFormFiledValue();
                AddPostField(writer, name, value);
            }
            AddPostField(writer,"__EVENTTARGET",this.ClientID);
            string args = string.Empty;
            if (!String.IsNullOrEmpty(CommandName))
            {
                args = CommandName + "$" + CommandArgument;
            }
            AddPostField(writer, "__EVENTARGUMENT", args);
        }

        private static void AddPostField(WmlTextWriter writer, string name, string value)
        {
            writer.AddMobileAttribute(MobileAttribute.Name, name);
            writer.AddMobileAttribute(MobileAttribute.Value, value);
            writer.RenderWmlBeginTag(MobileTag.PostField);
            writer.RenderEndTag();
        }
    }
}

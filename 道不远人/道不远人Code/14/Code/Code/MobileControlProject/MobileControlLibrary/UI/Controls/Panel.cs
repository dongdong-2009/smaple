using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileControlLibrary.UI.Controls
{
    public enum WmlAlign
    {
        Left,
        Center,
        Right
    }

    public class Panel:System.Web.UI.WebControls.Panel
    {
        public WmlAlign Align
        {
            get
            {
                if (ViewState["Align"] == null)
                    return WmlAlign.Left;
                return (WmlAlign)ViewState["Align"];
            }
            set
            {
                ViewState["Align"] = value;
            }
        }

        /// <summary>
        /// 限制子控件类型
        /// </summary>
        /// <param name="obj"></param>
        protected override void AddParsedSubObject(object obj)
        {
            if (obj is IFields || obj is Button|| obj is MobileLiteral)
            {
                Controls.Add(obj as Control);
            }
            else if (obj is LiteralControl)
            {
                MobileLiteral literal = new MobileLiteral();
                literal.Text = (obj as LiteralControl).Text;
                Controls.Add(literal);
            }
            else if (obj is Literal)
            {
                Literal literal = new MobileLiteral();
                literal.Text = (obj as Literal).Text;
                Controls.Add(literal);
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            //提供简单的设计时效果
            if (DesignMode)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.BorderColor, "blue");
                writer.AddStyleAttribute(HtmlTextWriterStyle.BorderStyle, "solid");
                writer.AddStyleAttribute(HtmlTextWriterStyle.BorderWidth, "1px");
                writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "400px");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "100%");
                writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "20px");
                writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "Navy");
                writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "white");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.Write("Card-" + this.ID);
                writer.RenderEndTag();
                writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "100%");
                writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "white");
                writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "black");
                base.Render(writer);
                writer.RenderEndTag();
            }
            else
            {
                //实现运行时呈现内容
                WmlTextWriter wmlWriter = writer as WmlTextWriter;
                wmlWriter.AddMobileAttribute(MobileAttribute.ID, this.ClientID);
                wmlWriter.AddMobileAttribute(MobileAttribute.Name, this.UniqueID);
                wmlWriter.AddMobileAttribute(MobileAttribute.Align, Align.ToString().ToLower());
                wmlWriter.RenderWmlBeginTag(MobileTag.P);
                RenderChildren(wmlWriter);
                wmlWriter.RenderEndTag();
            }
        }
    }
}

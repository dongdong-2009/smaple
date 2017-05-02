using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RenderHello
{
    public class AlbumnUsingEnum : Control
    {        
        protected override void Render(HtmlTextWriter writer)
        {
            //�����DIV����ʽ����
            writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "194px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "194px");
            writer.AddStyleAttribute("background", "url(Images/background.gif) no-repeat left");

            //������Div��ʼ
            writer.RenderBeginTag(HtmlTextWriterTag.Div);


            //IMG��ǩ�����Ժ���ʽ����
            writer.AddAttribute(HtmlTextWriterAttribute.Src, "images/nature.jpg");
            writer.AddAttribute(HtmlTextWriterAttribute.Width, "160");
            writer.AddAttribute(HtmlTextWriterAttribute.Height, "160");
            writer.AddStyleAttribute(HtmlTextWriterStyle.BorderStyle, "none");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, "0px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.MarginTop, "16px");

            //����Img��ǩ
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();

            //�����DIV����
            writer.RenderEndTag();
        }
    }
}

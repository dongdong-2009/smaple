using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlProperties
{
    public class Albumn:Control
    {
        string _imgUrl = null;
        //定义属性
        public virtual string ImgUrl
        {
            get
            {
                return _imgUrl;
            }
            set
            {
                _imgUrl = value;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            //最外层DIV的样式属性
            writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "194px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "194px");
            writer.AddStyleAttribute("background", "url(Images/background.gif) no-repeat left");

            //最外层的Div开始
            writer.RenderBeginTag(HtmlTextWriterTag.Div);


            //IMG标签的属性和样式属性
            //应用属性
            writer.AddAttribute(HtmlTextWriterAttribute.Src, this.ImgUrl);
            writer.AddAttribute(HtmlTextWriterAttribute.Width, "160");
            writer.AddAttribute(HtmlTextWriterAttribute.Height, "160");
            writer.AddStyleAttribute(HtmlTextWriterStyle.BorderStyle, "none");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Padding, "0px");
            writer.AddStyleAttribute(HtmlTextWriterStyle.MarginTop, "16px");

            //生成Img标签
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();

            //最外层DIV结束
            writer.RenderEndTag();
        }
    }
}

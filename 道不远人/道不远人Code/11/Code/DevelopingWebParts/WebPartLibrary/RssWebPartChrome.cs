using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.HtmlControls;

[assembly: WebResource("WebPartLibrary.Images.flake_header.jpg", "image/jpg")]
[assembly: WebResource("WebPartLibrary.Images.rss.jpg", "image/jpg")]
[assembly: WebResource("WebPartLibrary.Images.refresh.gif", "image/gif")]
[assembly: WebResource("WebPartLibrary.Images.close.gif", "image/gif")]
[assembly: WebResource("WebPartLibrary.CSS.Stylesheet.css", "text/css",PerformSubstitution=true)]

namespace WebPartLibrary
{
    public class RssWebPartChrome:WebPartChrome
    {
        public RssWebPartChrome(WebPartZone zone, WebPartManager manager)
            : base(zone, manager){}

        public override void PerformPreRender()
        {
            base.PerformPreRender();
            AddCssLink();
        }

        private void AddCssLink()
        {

            if (Zone.Page != null && Zone.Page.Header != null)
            {
                string cssHref = Zone.Page.ClientScript.GetWebResourceUrl(this.GetType(), "WebPartLibrary.CSS.Stylesheet.css");
                foreach (Control c in Zone.Page.Header.Controls)
                {
                    if (c is HtmlLink)
                    {
                        HtmlLink link = c as HtmlLink;
                        if (link.Href.Equals(cssHref, StringComparison.OrdinalIgnoreCase))
                        {
                            return;
                        }
                    }
                }
                HtmlLink css = new HtmlLink();
                css.Href = cssHref;
                css.Attributes["type"] = "text/css";
                css.Attributes["rel"] = "stylesheet";
                Zone.Page.Header.Controls.Add(css);
            }
        }

        public override void RenderWebPart(System.Web.UI.HtmlTextWriter writer, WebPart webPart)
        {
            AddStyleAttributeToContainer(writer,webPart);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            AddStyleAttributeToInnerBox(writer);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            AddHeaderStyle(writer, webPart);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            RenderHeaderContent(writer, webPart);
            writer.RenderEndTag();//header div

            writer.AddAttribute(HtmlTextWriterAttribute.Class, "RssWebPartContent");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            RenderPartContents(writer, webPart);
            writer.RenderEndTag();//content

            writer.RenderEndTag();//inner Div
            writer.RenderEndTag();//outer div
        }

        private void RenderHeaderContent(System.Web.UI.HtmlTextWriter writer, WebPart webPart)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "RssWebPartHeaderIcon");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.AddAttribute(HtmlTextWriterAttribute.Src, webPart.Page.ClientScript.GetWebResourceUrl(this.GetType(), "WebPartLibrary.Images.rss.jpg"));
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag();
            writer.RenderEndTag();//icon div

            //title
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "RssWebPartHeaderTitle");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            writer.Write(webPart.Title);
            writer.RenderEndTag();

            //edit
            if (WebPartManager.DisplayMode == System.Web.UI.WebControls.WebParts.WebPartManager.EditDisplayMode)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "RssWebPartEditButton");
                writer.AddAttribute(HtmlTextWriterAttribute.Href, (webPart as RssWebPart).GetEditString());
                writer.AddAttribute("onmousedown", (webPart as RssWebPart).GetEditClick());
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.Write("Edit");
                writer.RenderEndTag();
            }

            //refresh
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "RssWebPartRefreshButton");
            writer.AddAttribute(HtmlTextWriterAttribute.Href,"javascript:"+(webPart as RssWebPart).GetAjaxRefresh());
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write("ajax refresh");
            writer.RenderEndTag();

            //close
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "RssWebPartCloseButton");
            writer.AddAttribute(HtmlTextWriterAttribute.Href,(webPart as RssWebPart).GetCloseString());
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write("close part");
            writer.RenderEndTag();
        }

        private void AddHeaderStyle(System.Web.UI.HtmlTextWriter writer, WebPart webPart)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, GetWebPartTitleClientID(webPart));
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "RssWebPartHeaderContainer");
        }

        private void AddStyleAttributeToInnerBox(System.Web.UI.HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "RssWebPartInnerContainer");
        }

        private void AddStyleAttributeToContainer(System.Web.UI.HtmlTextWriter writer,WebPart webPart)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, GetWebPartChromeClientID(webPart));
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "RssWebPartOutContainer");
        }
    }
}

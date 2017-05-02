using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Net;
using System.Drawing;
using System.Globalization;

namespace WebPartLibrary
{
    public class OPMLWebPartZone:WebPartZoneBase
    {
        #region part1

        public string OPMLUrl
        {
            get
            {
                if (ViewState["OPMLUrl"] == null)
                {
                    return string.Empty;
                }
                return ViewState["OPMLUrl"].ToString();
            }
            set
            {
                ViewState["OPMLUrl"] = value;
            }
        }

        protected override WebPartCollection GetInitialWebParts()
        {
            if (!DesignMode)
            {
                if (!String.IsNullOrEmpty(OPMLUrl))
                {

                    WebRequest request = WebRequest.Create(OPMLUrl);
                    WebResponse response = request.GetResponse();

                    XmlDocument doc = new XmlDocument();
                    doc.Load(response.GetResponseStream());

                    XmlNodeList rssList = doc.SelectNodes(@"//outline[@xmlUrl]");
                    List<WebPart> parts = new List<WebPart>(rssList.Count);
                    int index = 0;
                    foreach (XmlNode rss in rssList)
                    {
                        RssDescriptionWebPart part = new RssDescriptionWebPart();
                        part.RssUrl = rss.Attributes["xmlUrl"].Value;
                        part.Title = rss.Attributes["title"].Value;
                        part.ID = "rssDescription" + index.ToString();
                        parts.Add(part);
                        index++;
                    }
                    return new WebPartCollection(parts);
                }
            }
            return new WebPartCollection();
        }

        #endregion

        #region part2

        private int _repeatColumns = 2;

        public int RepeatColumns
        {
            get { return _repeatColumns; }
            set { _repeatColumns = value; }
        }

        protected override void RenderBody(System.Web.UI.HtmlTextWriter writer)
        {
            if (DesignMode || this.WebPartManager.DisplayMode != WebPartManager.BrowseDisplayMode)
            {
                base.RenderBody(writer);
                return;
            }

            WebPartChrome chrome = this.WebPartChrome;

            writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
            int padding = this.Padding;
            if (padding >= 0)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, padding.ToString(CultureInfo.InvariantCulture));
            }
            writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
            string relativeUrl = this.BackImageUrl;
            if (relativeUrl.Trim().Length > 0)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundImage, "url(" + base.ResolveClientUrl(relativeUrl) + ")");
            }
            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "100%");
            writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "100%");
            writer.RenderBeginTag(HtmlTextWriterTag.Table);


            for (int i = 0; i < WebParts.Count; i++)
            {
                if (i % _repeatColumns == 0)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                    RenderDropCue(writer);
                }

                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                chrome.RenderWebPart(writer,WebParts[i]);
                writer.RenderEndTag();//td

                RenderDropCue(writer);

                if ((i % _repeatColumns) == (_repeatColumns - 1))
                {
                    writer.RenderEndTag();//tr
                }
                else if (i == WebParts.Count - 1)
                {
                    int appendCount = _repeatColumns - 1 - (i % _repeatColumns);
                    for (int i2 = 0; i2 < appendCount; i2++)
                    {
                        writer.RenderBeginTag(HtmlTextWriterTag.Td);//td
                        writer.Write("&nbsp;");
                        writer.RenderEndTag();//td
                    }
                    writer.RenderEndTag();//tr
                }
            }

            writer.RenderEndTag();//table
        }

        bool DrapDropEnable
        {
            get
            {
                if ((!base.DesignMode && base.RenderClientScript) && (this.AllowLayoutChange && (base.WebPartManager != null)))
                {
                    return base.WebPartManager.DisplayMode.AllowPageDesign;

                }
                return false;

            }
        }

        protected override void RenderDropCue(System.Web.UI.HtmlTextWriter writer)
        {
            if (DragDropEnabled)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.PaddingLeft, "1");
                writer.AddStyleAttribute(HtmlTextWriterStyle.PaddingRight, "1");
                writer.RenderBeginTag(HtmlTextWriterTag.Td);

                string backColor = ColorTranslator.ToHtml(this.DragHighlightColor);
                string border = "solid 3px " + backColor;
                writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
                writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
                writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "100%");
                writer.AddStyleAttribute("border-top", border);
                writer.AddStyleAttribute("border-bottom", border);
                writer.AddStyleAttribute(HtmlTextWriterStyle.Visibility, "hidden");
                writer.RenderBeginTag(HtmlTextWriterTag.Table);
                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                writer.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                writer.AddStyleAttribute(HtmlTextWriterStyle.FontSize, "0px");
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.AddStyleAttribute(HtmlTextWriterStyle.Margin, "0px 2px 0px 2px");
                writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "2px");
                writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "100%");
                writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, backColor);
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.RenderEndTag();//div
                writer.RenderEndTag();//td
                writer.RenderEndTag();//tr
                writer.RenderEndTag();//table

                writer.RenderEndTag();//td

            }
         }

        #endregion
    }
}

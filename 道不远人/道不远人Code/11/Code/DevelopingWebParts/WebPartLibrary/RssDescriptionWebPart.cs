using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.ComponentModel;
using System.Web.UI;

namespace WebPartLibrary
{
    public class RssDescriptionWebPart:WebPart,IPostBackEventHandler
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override string Title
        {
            get
            {
                if (ViewState["Title"] == null)
                    return string.Empty;
                return (string)ViewState["Title"];
            }
            set
            {
                ViewState["Title"] = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public string RssUrl    
        {
            get
            {
                if (ViewState["RssUrl"] == null)
                    return string.Empty;
                return (string)ViewState["RssUrl"];
            }
            set
            {
                ViewState["RssUrl"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            string href = Page.ClientScript.GetPostBackClientHyperlink(this,"Add");
            writer.AddAttribute(HtmlTextWriterAttribute.Href, href);
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write("Ìí¼ÓRSS¶©ÔÄ");
            writer.RenderEndTag();
        }

        #region IPostBackEventHandler ³ÉÔ±

        public void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.Equals("Add", StringComparison.OrdinalIgnoreCase))
            {
                RssWebPart part = new RssWebPart();
                part.MaxItems = 5;
                part.RssUrl = this.RssUrl;
                WebPartManager manager = WebPartManager.GetCurrentWebPartManager(Page);
                manager.AddWebPart(part, Zone, ZoneIndex);
                if (manager.Personalization.InitialScope == PersonalizationScope.User)
                {
                    manager.CloseWebPart(this);
                }
            }
        }

        #endregion
    }
}

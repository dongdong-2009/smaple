using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI.Design;
using System.IO;

[assembly:WebResource("WebPartLibrary.Images.refresh_1.gif","image/gif")]

namespace WebPartLibrary
{
    public class RssWebPart:WebPart,ICallbackEventHandler,IPostBackEventHandler
    {
        RssToolkit.GenericRssChannel _channel;

        private string _rssUrl;

        [Personalizable(true)]
        [WebBrowsable(true)]
        public string RssUrl
        {
            get { return _rssUrl; }
            set
            {
                _rssUrl = value; 
                LoadChannel();
            }
        }

        private int _maxItems=int.MaxValue;

        [Personalizable(true)]
        [WebBrowsable(true)]
        public int MaxItems
        {
            get { return _maxItems; }
            set { _maxItems = value; }
        }


        void LoadChannel()
        {
            if (_channel == null)
            {
                if (!string.IsNullOrEmpty(RssUrl))
                {
                    _channel = RssToolkit.GenericRssChannel.LoadChannel(RssUrl);
                }
            }
        }

        protected override void  RenderContents(HtmlTextWriter writer)
        {
            LoadChannel();
            if (_channel != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "RssWebPartList");
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                int itemCount = 0;
                foreach (RssToolkit.GenericRssElement element in _channel.Items)
                {
                    if (itemCount < MaxItems)
                    {
                        writer.RenderBeginTag(HtmlTextWriterTag.Li);
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, element.Attributes["link"]);
                        writer.AddAttribute(HtmlTextWriterAttribute.Target, "_blank");
                        writer.AddAttribute(HtmlTextWriterAttribute.Title, element.Attributes["title"]);
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.Write(HttpUtility.HtmlEncode(element.Attributes["title"]));
                        writer.RenderEndTag();
                        writer.RenderEndTag();//li
                        itemCount++;
                    }
                }
                writer.RenderEndTag();//ul
                writer.RenderBeginTag(HtmlTextWriterTag.Hr);
                writer.RenderEndTag();
                writer.Write("Last update time:" + DateTime.Now.ToLongTimeString());
            }
        }


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override string Title
        {
            get
            {
                LoadChannel();
                if (_channel != null)
                {
                    return _channel.Attributes["title"];
                }
                return string.Empty;
            }
            set
            {
            }
        }

        public override WebPartVerbCollection Verbs
        {
            get
            {
                string imgUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "WebPartLibrary.Images.refresh_1.gif");

                List<WebPartVerb> menu = new List<WebPartVerb>();
                WebPartVerb menuItem = new WebPartVerb("Refresh", RefreshRss, "return confirm('Sure you need renew the rss?');");
                menuItem.Text = "Refresh";
                menuItem.Description = "Refresh the Rss data";
                menuItem.ImageUrl = imgUrl;
                menu.Add(menuItem);

                string ajaxString = GetAjaxRefresh();
                WebPartVerb ajaxItem = new WebPartVerb("AjaxRefresh", ajaxString);
                ajaxItem.Text = "AJAX Refresh";
                ajaxItem.Description = "Refresh data by AJAX approach";
                ajaxItem.ImageUrl = imgUrl;
                menu.Add(ajaxItem);

                return new WebPartVerbCollection(menu);
            }
        }

        public string GetAjaxRefresh()
        {
            return Page.ClientScript.GetCallbackEventReference(this, "'Refresh'", "function(result,controlId){document.getElementById(controlId).innerHTML = result;}", "'" + this.ClientID + "'");          
        }

        public string GetCloseString()
        {
            return Page.ClientScript.GetPostBackClientHyperlink(this, "Close",false);
        }

        public string GetEditString()
        {
            return Page.ClientScript.GetPostBackClientHyperlink(this, "Edit", false);
        }

        public string GetEditClick()
        {
            string format = "{0};window.event.returnValue = false; window.event.cancelBubble = true;";
            return string.Format(format, Page.ClientScript.GetPostBackEventReference(this, "Edit", false));
        }

        void RefreshRss(Object sender, WebPartEventArgs e)
        {
            LoadChannel();
        }

        #region ICallbackEventHandler 成员

        public string GetCallbackResult()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            this.RenderContents(writer);
            return sb.ToString();
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            if (eventArgument.Equals("Refresh",StringComparison.OrdinalIgnoreCase))
            {
                LoadChannel();
            }
        }

        #endregion

        #region IPostBackEventHandler 成员

        public void RaisePostBackEvent(string eventArgument)
        {
            if(eventArgument.Equals("Close",StringComparison.OrdinalIgnoreCase))
            {
                //if(WebPartManager.Personalization.Scope == PersonalizationScope.User)
                {
                    WebPartManager.CloseWebPart(this);
                }
            }
            else if (eventArgument.Equals("Edit", StringComparison.OrdinalIgnoreCase))
            {
                WebPartManager.BeginWebPartEditing(this);
            }
        }

        #endregion

        #region part eidt

        public override EditorPartCollection CreateEditorParts()
        {
            List<EditorPart> editors = new List<EditorPart>();
            RssEditorPart editor = new RssEditorPart();
            editor.ID = "RssEdit1";
            editors.Add(editor);
            return new EditorPartCollection(editors);
        }

        #endregion
    }
}

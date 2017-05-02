using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Net;
using System.Xml;

namespace WebPartLibrary
{
    public class OPMLCatalogPart:CatalogPart
    {
        #region part1

        private string _title = "×ÊÔ´¾ÛºÏ";

        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }


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

        public override WebPartDescriptionCollection GetAvailableWebPartDescriptions()
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

                    List<WebPartDescription> descriptions = new List<WebPartDescription>(rssList.Count);

                    int index=0;
                    foreach (XmlNode rss in rssList)
                    {
                        WebPartDescription description = new WebPartDescription(
                            "rssDescription" + index.ToString(),
                            rss.Attributes["title"].Value,
                            rss.Attributes["xmlUrl"].Value,
                            Page.ClientScript.GetWebResourceUrl(this.GetType(), "WebPartLibrary.Images.rss.jpg"));
                        descriptions.Add(description);
                        index ++;
                    }
                    return new WebPartDescriptionCollection(descriptions);
                }
            }
            return new WebPartDescriptionCollection();
        }

        public override WebPart GetWebPart(WebPartDescription description)
        {
            RssWebPart part = new RssWebPart();
            part.ID = description.ID;
            part.RssUrl = description.Description;
            part.MaxItems = 5;
            return part;
        }

        #endregion
    }
}

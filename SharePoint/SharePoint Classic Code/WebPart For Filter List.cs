using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using Microsoft.SharePoint.WebPartPages;

namespace TestWebpart
{
    [ToolboxItemAttribute(false)]
    public class Part01 : System.Web.UI.WebControls.WebParts.WebPart
    {
        [WebBrowsable]
        [Personalizable(PersonalizationScope.Shared)]
        public string ListName { get; set; }

        [WebBrowsable]
        [Personalizable(PersonalizationScope.Shared)]
        public string ColumnName { get; set; }
        TextBox tb;
        UpdatePanel mainUpdatePanel;
        ListViewWebPart lvwp = new ListViewWebPart();
        SPList list;

        protected override void CreateChildControls()
        {
            mainUpdatePanel = new UpdatePanel();

            mainUpdatePanel.UpdateMode = UpdatePanelUpdateMode.Conditional;

            tb = new TextBox();
            tb.ID = "txtSearch";
            this.Controls.Add(tb);

            Button bt = new Button();
            bt.ID = "bt";
            bt.Text = "Search";
            bt.Click += new EventHandler(bt_Click);

            SPWeb web = SPContext.Current.Web;
            list = web.Lists[ListName];
            lvwp.ListName = list.ID.ToString("B").ToUpper();
            //lvwp.ViewGuid = list.DefaultView.ID.ToString("B").ToUpper();
            lvwp.ViewGuid = list.Views[1].ID.ToString("B").ToUpper(); 
            lvwp.ChromeType = PartChromeType.None;

            mainUpdatePanel.ContentTemplateContainer.Controls.Add(bt);
            mainUpdatePanel.ContentTemplateContainer.Controls.Add(lvwp);
            this.Controls.Add(mainUpdatePanel);
            base.CreateChildControls();
        }

        void bt_Click(object sender, EventArgs e)
        {           
 
            string query = string.Empty;
            string tempAdding = string.Empty;
            if (!string.IsNullOrEmpty(tb.Text))
            {
                query = "<Contains><FieldRef Name='" + ColumnName + "' /><Value Type='Text'>" + tb.Text + "</Value></Contains>";
            }
           

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(lvwp.ListViewXml);
            XmlNode queryNode = doc.SelectSingleNode("//Query");
            XmlNode whereNode = queryNode.SelectSingleNode("Where");

            if (whereNode != null) queryNode.RemoveChild(whereNode);
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "Where", String.Empty);
            newNode.InnerXml = query.ToString();
            queryNode.AppendChild(newNode);
            lvwp.ListViewXml = doc.OuterXml;
        }
    }
}

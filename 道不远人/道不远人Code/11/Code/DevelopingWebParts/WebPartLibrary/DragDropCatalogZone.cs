using System;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;

[assembly: WebResource("WebPartLibrary.DragDropCatalogZone.js", "text/javascript")]

namespace WebPartLibrary
{
    public class DragDropCatalogZone : CatalogZone
    {
        protected override void OnPreRender(EventArgs e)
        {
            EnsureID();
            Page.ClientScript.RegisterClientScriptResource(this.GetType(), "WebPartLibrary.DragDropCatalogZone.js");

            if (!Page.ClientScript.IsStartupScriptRegistered(this.ClientID))
            {
                //��ʼ����������
                Page.ClientScript.RegisterStartupScript(this.GetType(), this.ClientID,
                    "new dragDropCatalogZone('"+this.ClientID+"').initialize();",true);
            }
            base.OnPreRender(e);
        }

        protected override void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.StartsWith("Add:"))
            {
                string[] args = eventArgument.Split(':');
                AddWebPart(args[1], args[2], Int32.Parse(args[3]));
            }
            base.RaisePostBackEvent(eventArgument);
        }

        private void AddWebPart(string webPartId, string zoneId, int zoneIndex)
        {
            //���ѡ�е�WebPart����
            WebPartDescription desc = this.CatalogParts[this.SelectedCatalogPartID]
                    .GetAvailableWebPartDescriptions()[webPartId];
            WebPart webPart = this.CatalogParts[this.SelectedCatalogPartID].GetWebPart(desc);
            //��ý���WebPart��Zone
            WebPartZoneBase zone = this.WebPartManager.Zones[zoneId];
            //ʹ��Manager���WebPart
            this.WebPartManager.AddWebPart(webPart, zone, zoneIndex);
        }

        //ʹ���Զ���Chrome
        protected override CatalogPartChrome CreateCatalogPartChrome()
        {
            return new DragDropCatalogPartChrome(this);
        }
    }
}

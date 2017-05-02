using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI;

namespace WebPartLibrary
{
    public class DragDropCatalogPartChrome : CatalogPartChrome
    {
        public override void RenderCatalogPart(HtmlTextWriter writer, CatalogPart catalogPart)
        {
            //在部件外面添加一个容器
            writer.AddAttribute(HtmlTextWriterAttribute.Id, GetDraggableContainerId());
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            base.RenderCatalogPart(writer, catalogPart);
            writer.RenderEndTag();
        }

        private string GetDraggableContainerId()
        {
            return this.Zone.ID+"_draggable";
        }

        public DragDropCatalogPartChrome(CatalogZoneBase zone)
            : base(zone) { }
    }

}

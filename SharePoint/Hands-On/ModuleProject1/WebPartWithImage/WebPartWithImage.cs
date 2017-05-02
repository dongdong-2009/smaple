using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace ModuleProject1.WebPartWithImage
{
    [ToolboxItemAttribute(false)]
    public class WebPartWithImage : WebPart
    {
        protected override void CreateChildControls()
        {
            this.Controls.Add(
            new Image
            {
                ImageUrl = SPContext.Current.Site.ServerRelativeUrl + "/Resources/Tick.png"
            });
        }
    }
}

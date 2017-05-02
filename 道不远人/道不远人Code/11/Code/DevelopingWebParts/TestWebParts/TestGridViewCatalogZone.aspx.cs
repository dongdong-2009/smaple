using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class TestGridViewCatalogZone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (WebPartDisplayMode mode in WebPartManager1.SupportedDisplayModes)
            {
                Menu1.Items.Add(new MenuItem(mode.Name, mode.Name));
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        WebPartManager1.Personalization.ResetPersonalizationState();
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        WebPartManager1.DisplayMode = WebPartManager1.DisplayModes[e.Item.Value];
    }
    protected void WebPartManager1_DisplayModeChanged(object sender, WebPartDisplayModeEventArgs e)
    {
        if (WebPartManager1.DisplayMode == WebPartManager.CatalogDisplayMode)
        {
            catalogZone1.SelectedCatalogPartID = catalogZone1.CatalogParts[0].ID;
        }
    }
}

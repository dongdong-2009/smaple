using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebPartLibrary
{
    public class GridViewCatalogZone:CatalogZone
    {
        DropDownList _ddlCatalogs;
        DropDownList _ddlZones;
        GridView _gvParts;

        protected override void CreateChildControls()
        {
            //调用base.CreateChildControls()加入Part
            base.CreateChildControls();

            _ddlCatalogs = new DropDownList();
            _ddlCatalogs.ID = "ddlCatalog";
            _ddlCatalogs.DataTextField = "Title";
            _ddlCatalogs.DataValueField = "ID";
            _ddlCatalogs.AutoPostBack = true;
            _ddlCatalogs.SelectedIndexChanged += new EventHandler(_ddlCatalogs_SelectedIndexChanged);
            if (!DesignMode)
            {
                _ddlCatalogs.DataSource = CatalogParts;
                _ddlCatalogs.DataBind();
            }
            Controls.Add(_ddlCatalogs);
            
            _gvParts = new GridView();
            _gvParts.ID = "gvParts";
            _gvParts.AllowPaging = true;
            _gvParts.AllowSorting = true;
            _gvParts.GridLines = GridLines.None;
            _gvParts.DataKeyNames = new string[] { "ID" };
            _gvParts.PageSize = 5;
            _gvParts.EmptyDataText = "目录为空";
            _gvParts.AutoGenerateColumns = false;
            _gvParts.AutoGenerateSelectButton = true;
            BoundField bfTitle =  new BoundField();
            bfTitle.DataField = "Title";
            BoundField bfDescription = new BoundField();
            bfDescription.DataField = "Description";
            _gvParts.Columns.Add(bfTitle);
            _gvParts.Columns.Add(bfDescription);
            _gvParts.PageIndexChanging += new GridViewPageEventHandler(_gvParts_PageIndexChanging);
            _gvParts.SelectedIndexChanged += new EventHandler(_gvParts_SelectedIndexChanged);
            Controls.Add(_gvParts);

            _ddlZones = new DropDownList();
            _ddlZones.ID = "ddlZones";
            _ddlZones.DataTextField = "HeaderText";
            _ddlZones.DataValueField = "ID";
            if (!DesignMode)
            {
                _ddlZones.DataSource = GetZones();
                _ddlZones.DataBind();
            }
            Controls.Add(_ddlZones);
        }

        void _gvParts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _gvParts.PageIndex = e.NewPageIndex;
        }

        void _gvParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string webPartDescriptionId = (string)_gvParts.SelectedValue;
            string zoneId = (string)_ddlZones.SelectedValue;

            AddWebPart(webPartDescriptionId, zoneId);
        }

        void _ddlCatalogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCatalogPartID = _ddlCatalogs.SelectedValue;
        }

        void FillData()
        {
            EnsureChildControls();
            if (!DesignMode)
            {
                _gvParts.DataSource = GetDescriptions();
                _gvParts.DataBind();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            FillData();
        }

        protected override void RenderBody(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.For, _ddlZones.ClientID);
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write("请选择区域：");
            writer.RenderEndTag();
            _ddlZones.RenderControl(writer);
            writer.WriteBreak();
            _gvParts.RenderControl(writer);
        }

        protected override void RenderFooter(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Hr);
            writer.RenderEndTag();            
            writer.AddAttribute(HtmlTextWriterAttribute.For, _ddlCatalogs.ClientID);
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write("请选择目录:");
            writer.RenderEndTag();
            _ddlCatalogs.RenderControl(writer);
        }

        CatalogPart GetSelectedCatalogPart()
        {
            return CatalogParts[SelectedCatalogPartID];
        }

        WebPartDescriptionCollection GetDescriptions()
        {
            return GetSelectedCatalogPart().GetAvailableWebPartDescriptions();
        }

        WebPartZoneCollection GetZones()
        {
            return WebPartManager.Zones;
        }

        void AddWebPart(string descriptionId, string zoneId)
        {
            WebPart part = GetSelectedCatalogPart().GetWebPart(
                GetDescriptions()[descriptionId]);
            WebPartZoneBase zone = GetZones()[zoneId];
            WebPartManager.AddWebPart(part, zone, 0);
        }
    }
}

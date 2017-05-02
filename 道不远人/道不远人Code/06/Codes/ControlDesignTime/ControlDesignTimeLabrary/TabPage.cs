using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.Design;
using System.Drawing;

namespace ControlDesignTimeLabrary
{
    [ParseChildren(false)]
    [ToolboxData("<{0}:TabPage title=\"New Tab\" runat=\"server\"></{0}TabPage>")]
    [Designer(typeof(TabPageDesigner))]
    public class TabPage:WebControl
    {
        public string Title
        {
            get
            {
                if (ViewState["Title"] == null)
                {
                    return string.Empty;
                }
                return (string)ViewState["Title"];
            }
            set
            {
                ViewState["Title"] = value;
            }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }

    }

    public class TabPageDesigner : ContainerControlDesigner
    {
        public override bool AllowResize
        {
            get
            {
                return false;
            }
        }
        public override Style FrameStyle
        {
            get
            {
                Style style = base.FrameStyle;
                style.Width = new Unit(100, UnitType.Percentage);
                style.BackColor = Color.FromArgb(173, 209, 245);
                style.Height = new Unit(2);
                return style;
            }
        }

        public override string FrameCaption
        {
            get
            {
                return "&nbsp;";
            }
        }
    }
}

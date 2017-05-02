using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.ComponentModel;

namespace ControlDesignTimeLabrary
{
    [Designer(typeof(DropShadowDesginer),typeof(ControlDesigner))]
    public class DropShadowPanel:Panel
    {
    }

    public class DropShadowDesginer : ContainerControlDesigner
    {
        protected override void AddDesignTimeCssAttributes(System.Collections.IDictionary styleAttributes)
        {
            styleAttributes.Add("border", "solid 1px blue");
            base.AddDesignTimeCssAttributes(styleAttributes);
        }
    }
}

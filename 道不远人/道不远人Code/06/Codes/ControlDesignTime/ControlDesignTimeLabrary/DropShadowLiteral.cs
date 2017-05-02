using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.ComponentModel;
using System.Web.UI;

[assembly:WebResource("ControlDesignTimeLabrary.alert.gif","image/gif")]

namespace ControlDesignTimeLabrary
{
    [Designer(typeof(DropShadowLitralDesigner))]
    public class DropShadowLiteral:Literal
    {
    }

    public class DropShadowLitralDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            string html =  base.GetDesignTimeHtml();
            html = "<div style='filter:dropShadow(color=#AAAAAA,offX=3,offY=3);padding:1em;width:"+((DropShadowLiteral)Component).Text.Length.ToString()+"em;'>" + html + "</div>";
            return html;
        }
        protected override string GetEmptyDesignTimeHtml()
        {
            string imgSrc = ((DropShadowLiteral)Component).Page.ClientScript.GetWebResourceUrl(typeof(DropShadowLiteral), "ControlDesignTimeLabrary.alert.gif");
            return string.Format("<img src='{0}'/>PleaseInputControlText",imgSrc);
        }
    }
}

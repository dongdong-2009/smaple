using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RenderHello
{
    public class Albumn : Control
    {
        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteLine(@"<div style=""text-align:center;width:194px;height:194px;background:url(Images/background.gif) no-repeat left"">");
            writer.WriteLine(@" <img src=""Images/Nature.jpg"" width=""160"" height=""160"" style=""border:none;padding:0px;margin-top:16px;"">");
            writer.WriteLine(@"</div>");
        }
    }
}

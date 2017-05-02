using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RenderHello
{
    public class RenderHello : Control
    {
        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteLine("Hello World");
        }
    }
}

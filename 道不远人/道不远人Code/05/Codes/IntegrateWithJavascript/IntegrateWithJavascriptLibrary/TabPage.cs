using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace IntegrateWithJavascriptLibrary
{
    [ParseChildren(false)]
    //[ToolboxItem(false)]
    [ToolboxData("<tab title=\"New Tab\"></tab>")]
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
}

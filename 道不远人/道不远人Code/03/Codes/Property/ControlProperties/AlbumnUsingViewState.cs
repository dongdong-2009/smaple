using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlProperties
{
    public class AlbumnUsingViewState:Albumn
    {
        public override string ImgUrl
        {
            get
            {
                object o = ViewState["ImgUrl"];
                if (o != null)
                {
                    return (string)o;
                }

                return string.Empty;
            }
            set
            {
                ViewState["ImgUrl"] = value;
            }
        }
    }
}

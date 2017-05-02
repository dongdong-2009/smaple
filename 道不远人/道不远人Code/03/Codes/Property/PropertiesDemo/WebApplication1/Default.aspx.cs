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

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.lblHappy.Text +=  "again";
            if (this.Albumn1.ImgUrl == "images/nature.jpg")
            {
                this.Albumn1.ImgUrl = "images/nature2.jpg";
            }
            else
            {
                this.Albumn1.ImgUrl = "images/nature.jpg";
            }

            if (this.AlbumnUsingViewState1.ImgUrl == "images/nature.jpg")
            {
                this.AlbumnUsingViewState1.ImgUrl = "images/nature2.jpg";
            }
            else
            {
                this.AlbumnUsingViewState1.ImgUrl = "images/nature.jpg";
            }

        }
    }
}

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
using MobileControlLibrary.UI;

public partial class _Default:MobilePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnHello_Click(object sender, EventArgs e)
    {
        this.lblHello.Text = this.txtName.Text + "欢迎来到WAP的世界";
    }
}

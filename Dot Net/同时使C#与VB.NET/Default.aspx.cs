using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Drawing.Printing;
using Microsoft.VisualBasic;
using System.Text;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        vb v = new vb();
        this.TextBox1.Text = v.Hello();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
                cs v = new cs();
                this.TextBox1.Text = v.csSay();
    }
}

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

public partial class b : System.Web.UI.Page
{
    private int myVar;

    public int MyProperty
    {
        get { return 0; }

        set { myVar = value; }
    }
	
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}

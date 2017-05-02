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

public partial class AjaxCallBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //the script manager
        ScriptManager objScriptManager = ScriptManager.GetCurrent(this.Page);

        //Set up the Reference
        ServiceReference TestWS = new ServiceReference();
        TestWS.Path = "~/WSUsers.asmx";

        //Add the WS reference  to the script manager
        objScriptManager.Services.Add(TestWS);
    }
}

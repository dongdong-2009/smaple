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
using System.Web.SessionState;

public partial class TestValidator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected override void Render(HtmlTextWriter writer)
    {
        ClientScript.RegisterArrayDeclaration("testArray", "1");
        ClientScript.RegisterArrayDeclaration("testArray", "2");
         ClientScript.RegisterExpandoAttribute(this.txtName.ClientID, "Test", "<This is a test>", true);
         base.Render(writer);
    }
}

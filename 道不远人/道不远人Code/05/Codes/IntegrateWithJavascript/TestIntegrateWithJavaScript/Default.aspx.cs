using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.ClientScript.IsClientScriptBlockRegistered("HelloWorldDeclaration"))
        {
            Page.ClientScript.RegisterClientScriptBlock(typeof(string), "HelloWorldDeclaration", "function sayHello(){alert('Hello world!');}", true);
        }

        if (!Page.ClientScript.IsStartupScriptRegistered("HelloWorldExecution"))
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "HelloWorldExecution", "sayHello();", true);
        }

    }
}

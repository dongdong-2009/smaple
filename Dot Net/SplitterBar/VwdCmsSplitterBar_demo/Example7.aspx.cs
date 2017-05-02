using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Example7 : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// need to clear the value in the textarea, it gets
		// set again in javascript after the document has loaded
		// doing this because of a resizing, scrolling, and 
		// text wrapping issue with textarea elements in IE 6 and IE 7.
		this.txtEdit1.Value = string.Empty;


		// set the onload event handler for the page
		ExampleMaster mstr = (ExampleMaster)this.Page.Master;
		HtmlGenericControl body = (HtmlGenericControl)mstr.FindControl("bodyElement");
		body.Attributes.Add("onload", "onPageLoad();");
    }
}

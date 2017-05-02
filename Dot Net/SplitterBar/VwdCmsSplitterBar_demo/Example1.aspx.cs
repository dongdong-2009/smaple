using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Example1 : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// need to clear the value in the textarea, it gets
		// set again in javascript after the document has loaded
		// doing this because of a resizing, scrolling, and 
		// text wrapping issue with textarea elements in IE 6 and IE 7.
		this.txtEdit1.Value = string.Empty;
		this.txtEdit2.Value = string.Empty;
		this.txtEdit4.Value = string.Empty;

		// don't do this for 'txtEdit3' because I want to show how this
		// issue affects the SplitterBar's functionality
		// this.txtEdit3.Value = string.Empty; 


    }
}

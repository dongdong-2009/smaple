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

public partial class Variable_Test : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Hashtable val = new Hashtable();
		val.Add("A", 1);
		val.Add("B", "String");
		val.Add("C", new String[] { "C1", "C2", "C3" });
		val.Add("D", DateTime.Now);
		MyVariable.Value = val;
	}
	protected void Button1_Click(object sender, EventArgs e)
	{

	}
}

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

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
			//读取现存记录
			DataTable dt = new DataTable();
			dt.TableName = "Contact";
			dt.Columns.Add("Name");
			dt.Columns.Add("Tel");
			dt.Columns.Add("Mail");
			dt.ReadXml(Server.MapPath("contact.xml"));
			//将现存记录传送到客户端
			MyTable.Value = dt;
        }
    }
	protected void Button1_Click(object sender, EventArgs e)
	{
		//保存客户端返回的结果
		((DataTable)MyTable.Value).WriteXml(Server.MapPath("contact.xml"));
	}
}

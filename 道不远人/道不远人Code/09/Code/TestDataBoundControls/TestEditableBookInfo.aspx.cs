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

public partial class TestEditableBookInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void EditableBookInfo1_Update(object sender, DataBoundControls.BookInfoUpdateEventArgs e)
    {
        string[] newValues = e.NewValues.AllKeys;
        this.Label1.Text = "更新了："+ String.Join(",", newValues);
    }
}

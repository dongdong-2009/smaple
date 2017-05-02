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

public partial class TestDateChooser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void DateChooser1_SelectedDateChanged(object sender, EventArgs e)
    {
        this.Header.Title = this.DateChooser1.SelectedDate.ToString("d");
    }
}

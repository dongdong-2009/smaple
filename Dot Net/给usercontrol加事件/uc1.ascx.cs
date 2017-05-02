using System.Collections.Generic;
using System;
using System.Web.UI.WebControls;

public partial class uc1 : System.Web.UI.UserControl
{
    public event EventHandler TabClick;

    private int index;

    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> list = new List<string>();
        list.Add("tab1");
        list.Add("tab2");
        list.Add("tab3");
        list.Add("tab4");

        dlshow.DataSource = list;
        dlshow.DataBind();

        dlshow.SelectedIndex = 0;
    }
    protected void dlshow_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label lbl = this.Parent.FindControl("lblshow") as Label;
        lbl.Text = "Access Parent Page Control";

        index = dlshow.SelectedIndex;

        TabClick(this, null);
    }

}
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
    }
    protected void AutoFlexTextArea1_TextChanged(object sender, EventArgs e)
    {
        Page.Header.Title = "Changed...";
    }
    protected void NumericUpDown1_Click(object sender, PostBackControls.NumericArgs e)
    {
        this.Label1.Text = "Contorl's Value is added("+e.AddValue.ToString()+")";
    }
    protected void CompositeNumericUpDown1_Click(object sender, PostBackControls.NumericArgs e)
    {
        this.Label2.Text = CompositeNumericUpDown1.Value.ToString();
    }
    protected void CompositeNumericUpDown1_TextChanged(object sender, EventArgs e)
    {
        this.Label1.Text = "control's value has changed.";
    }
}

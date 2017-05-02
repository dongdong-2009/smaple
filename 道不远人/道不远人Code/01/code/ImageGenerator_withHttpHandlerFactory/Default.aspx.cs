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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink1.NavigateUrl = "img.jpg?query=" + HttpUtility.UrlEncode("天安门前的华表")+"&ext=jpg";
        HyperLink2.NavigateUrl = "img.jpg?query=" + HttpUtility.UrlEncode("天安门前的华表") + "&ext=gif";
    }
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
    }
}

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
using System.Diagnostics;
using System.Threading;

public partial class TestTabControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsCallback)
        {
            Debug.WriteLine("Page_Load");
            Thread.Sleep(1000);
        }
    }
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        Debug.WriteLine("OnPreRender");
    }
    protected override void Render(HtmlTextWriter writer)
    {
        base.Render(writer);
        Debug.WriteLine("Render");
    }
    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
        Debug.WriteLine("LoadViewState");
    }
    protected override void RaisePostBackEvent(IPostBackEventHandler sourceControl, string eventArgument)
    {
        base.RaisePostBackEvent(sourceControl, eventArgument);
        Debug.WriteLine("RaisePostBackEvent");
    }
    protected override void OnInit(EventArgs e)
    {
        Debug.WriteLine("OnInit");
        base.OnInit(e);
    }
}

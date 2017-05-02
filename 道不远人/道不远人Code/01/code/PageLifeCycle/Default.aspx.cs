using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page ,ICallbackEventHandler
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Trace.Warn("Page_Load");
    }


    public override void ApplyStyleSheetSkin(Page page)
    {
        base.ApplyStyleSheetSkin(page);
        Trace.Warn("ApplyStyleSheetSkin");
    }


    protected override HtmlTextWriter CreateHtmlTextWriter(System.IO.TextWriter tw)
    {
        Trace.Warn("CreateHtmlTextWiter");
        return base.CreateHtmlTextWriter(tw);
    }

    protected override ControlCollection CreateControlCollection()
    {
        Trace.Warn("CreateControlCollection");
        return base.CreateControlCollection();
    }

    protected override System.Collections.Specialized.NameValueCollection DeterminePostBackMode()
    {
        Trace.Warn("DeterminePostBackMode");
        return base.DeterminePostBackMode();
    }

    protected override void InitializeCulture()
    {
        Trace.Warn("InitializeCulture");
        base.InitializeCulture();
    }

    protected override void FrameworkInitialize()
    {
        Trace.Warn("FrameworkInitialize");
        base.FrameworkInitialize();
    }

    protected override void InitOutputCache(int duration, string varyByHeader, string varyByCustom, OutputCacheLocation location, string varyByParam)
    {
        Trace.Warn("InitOutputCache");
        base.InitOutputCache(duration, varyByHeader, varyByCustom, location, varyByParam);
    }

    protected override object LoadPageStateFromPersistenceMedium()
    {
        Trace.Warn("LoadPageStateFromPersistenceMedium");
        return base.LoadPageStateFromPersistenceMedium();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Trace.Warn("OnInit");
    }

    protected override void OnInitComplete(EventArgs e)
    {
        Trace.Warn("OnInitComplete");
        base.OnInitComplete(e);
    }

    protected override void OnLoadComplete(EventArgs e)
    {
        Trace.Warn("OnLoadComplete");
        base.OnLoadComplete(e);
    }

    protected override void OnPreInit(EventArgs e)
    {
        Trace.Warn("OnPreInit");
        base.OnPreInit(e);
    }

    protected override void OnPreLoad(EventArgs e)
    {
        Trace.Warn("OnPreLoad");
        base.OnPreLoad(e);
    }

    protected override void OnPreRenderComplete(EventArgs e)
    {
        Trace.Warn("OnPreRenderComplete");
        base.OnPreRenderComplete(e);
    }

    protected override void OnSaveStateComplete(EventArgs e)
    {
        Trace.Warn("OnSaveStateComplete");
        base.OnSaveStateComplete(e);
    }

    public override void ProcessRequest(HttpContext context)
    {
        Trace.Warn("ProcessRequest");
        base.ProcessRequest(context);
    }

    protected override void RaisePostBackEvent(IPostBackEventHandler sourceControl, string eventArgument)
    {
        Trace.Warn("RaisePostBackEvent");
        base.RaisePostBackEvent(sourceControl, eventArgument);
    }

    protected override void Render(HtmlTextWriter writer)
    {
        Trace.Warn("Render");
        base.Render(writer);
    }

    protected override void SavePageStateToPersistenceMedium(object state)
    {
        Trace.Warn("SavePageStateToPersistenceMedium");
        base.SavePageStateToPersistenceMedium(state);
    }


    #region ICallbackEventHandler 成员

    public string GetCallbackResult()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public void RaiseCallbackEvent(string eventArgument)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion
}

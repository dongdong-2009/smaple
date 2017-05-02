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
    //使用自定义的状态持久器页面的视图状态为2164字节
    //注释此段代码，视图状态为4232字节
    #region
    CompressPageStatePersister _pageStatePersister = null;
    protected override PageStatePersister PageStatePersister
    {
        get
        {
            if (_pageStatePersister == null)
            {
                _pageStatePersister = new CompressPageStatePersister(this);
            }
            return _pageStatePersister;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
}

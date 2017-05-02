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
        //DataGrid1.CurrentPageIndex
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        PageDataList(0);
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        PageDataList(EnablePageDataList1.CurrentPageIndex - 1);
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        PageDataList(EnablePageDataList1.CurrentPageIndex + 1);
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        PageDataList( EnablePageDataList1.PageCount -1);
    }

    void PageDataList(int pageIndex)
    {
        EnablePageDataList1.CurrentPageIndex = pageIndex;
        EnablePageDataList1.DataBind();
    }
    protected void EnablePageDataList1_PreRender(object sender, EventArgs e)
    {
        btnFirst.Enabled = btnPrev.Enabled = (EnablePageDataList1.CurrentPageIndex != 0);
        btnLast.Enabled = btnNext.Enabled = (EnablePageDataList1.CurrentPageIndex < EnablePageDataList1.PageCount - 1);
        this.Label3.Text = string.Format("{0}/{1}", EnablePageDataList1.CurrentPageIndex + 1, EnablePageDataList1.PageCount);
    }
}

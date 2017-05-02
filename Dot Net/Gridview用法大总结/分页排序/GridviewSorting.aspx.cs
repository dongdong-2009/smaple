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
/// <summary>
/// Author:匆匆  Blog:http://www.cnblogs.com/huangjianhuakarl/
/// Gridview列正反排序
/// </summary>
public partial class Sorting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["SortOrder"] = "EmpID";
            ViewState["OrderDire"] = "ASC";
            bind();
        }
    }
    /// <summary>
    /// 绑定数据
    /// </summary>
    public void bind()
    {
        string sqlStr = "select * from Employee";
        DataView myView = Common.dataView(sqlStr);
        string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
        myView.Sort = sort;
        GridView1.DataSource = myView;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
    }
    /// <summary>
    /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
    }
    /// <summary>
    /// 在单击某个用于对列进行排序的超链接时发生，但在 GridView 控件执行排序操作之前。此事件通常用于取消排序操作或执行自定义的排序例程。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sPage = e.SortExpression;
        if (ViewState["SortOrder"].ToString() == sPage)
        {
            if (ViewState["OrderDire"].ToString() == "DESC")
                ViewState["OrderDire"] = "ASC";
            else
                ViewState["OrderDire"] = "DESC";
        }
        else
        {
            ViewState["SortOrder"] = e.SortExpression;
        }
        bind();
    }
}

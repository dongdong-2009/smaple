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
/// </summary>
public partial class 多层嵌套_GridviewNested : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindParent();
        }
    }
    /// <summary>
    /// 数据绑定
    /// </summary>
    public void bindParent()
    {
        string sqlStr = "select * from Categories";
        DataSet myds = Common.dataSet(sqlStr);
        ParentGridView.DataSource = myds;
        ParentGridView.DataKeyNames = new string[] { "CategoryID" };
        ParentGridView.DataBind();
    }

    /// <summary>
    /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ParentGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        if (e.Row.RowIndex != -1)
        {
            int id = ParentGridView.PageIndex * ParentGridView.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }
    protected void ParentGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int parent_index = e.NewEditIndex;
        ParentGridView.EditIndex = parent_index;
        bindParent();
        Session["sCategoryID"] =Convert.ToInt32(ParentGridView.DataKeys[parent_index].Value);
        Session["sParentGridViewIndex"] = parent_index;
    }
    protected void ChildGridView_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        int parent_index = (int)Session["sParentGridViewIndex"];
        GridViewRow parent_row = ParentGridView.Rows[parent_index];
        GridView ChildGridView = (GridView)parent_row.FindControl("ChildGridView");
        int child_index = e.NewEditIndex;
        ChildGridView.EditIndex = child_index;
        Session["sProductID"] = Convert.ToInt32(ChildGridView.DataKeys[child_index].Value);
    }
    protected void ChildGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        
    }
    protected void GrandChildGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
    }
    protected void ParentGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        ParentGridView.EditIndex = -1;
        bindParent();
    }
}

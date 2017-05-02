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
public partial class 多层嵌套_GridviewInbuild : System.Web.UI.Page
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
        Session["sCategoryID"] = Convert.ToInt32(ParentGridView.DataKeys[parent_index].Value);
        Session["sParentGridViewIndex"] = parent_index;
        GridView childGridView = (GridView)(ParentGridView.Rows[parent_index].FindControl("ChildGridView"));
        string sqlStr = "select * from Products where CategoryID="+Convert.ToInt32(Session["sCategoryID"].ToString());
        DataSet myds = Common.dataSet(sqlStr);
        childGridView.DataSource = myds;
        childGridView.DataKeyNames = new string[] { "productID" };
        childGridView.DataBind();
    }
    protected void ParentGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        ParentGridView.EditIndex = -1;
        bindParent();
    }
    protected void ChildGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }

    }
    
   
}

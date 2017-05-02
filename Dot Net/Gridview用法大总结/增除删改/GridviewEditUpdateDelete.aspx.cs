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
/// Gridview的增除删改操作
/// </summary>
public partial class EditUpdateDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的 Delete 按钮（其 CommandName 属性设置为"Delete"的按钮）时发生，但在 GridView 控件从数据源删除记录之前。此事件通常用于取消删除操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sqlStr = "delete from Employee where ID=" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value) + "";
        Common.ExecuteSql(sqlStr);
        bind();
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的 Update 按钮（其 CommandName 属性设置为"Update"的按钮）时发生，但在 GridView 控件更新记录之前。此事件通常用于取消更新操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string Emp_ID = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim();
        string Emp_RealName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
        string Emp_Sex = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
        string Emp_Address = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
        string sqlStr = "update Employee set EmpID='" + Emp_ID + "',EmpRealName='" + Emp_RealName + "',EmpSex='" + Emp_Sex + "',EmpAddress='" + Emp_Address + "' where ID=" + ID + "";
        Common.ExecuteSql(sqlStr);
        GridView1.EditIndex = -1;
        bind();
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的 Edit 按钮（其 CommandName 属性设置为“Edit”的按钮）时发生，但在 GridView 控件进入编辑模式之前。此事件通常用于取消编辑操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的 Cancel 按钮（其 CommandName 属性设置为“Cancel”的按钮）时发生，但在 GridView 控件退出编辑模式之前。此事件通常用于停止取消操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }
    /// <summary>
    /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string OrderID = e.Row.Cells[1].Text;
            string _jsEdit = "showModalDialog('GridviewEditUpdateDelete.aspx?id=" + OrderID + "',null,'dialogWidth=650px;dialogHeight=500px;help:no;status:no')";
            e.Row.Cells[7].Attributes.Add("onclick", _jsEdit);
        } 
    }
    /// <summary>
    /// 数据绑定
    /// </summary>
    public void bind()
    {
        string sqlStr = "select * from Employee";
        DataSet myds = Common.dataSet(sqlStr);
        GridView1.DataSource = myds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id =Convert.ToInt32(GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString());
        //Response.Write(id);
        //你的插入数据库新表的代码 
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "EditOrder":
                bind();
                break;
        }
    }
}

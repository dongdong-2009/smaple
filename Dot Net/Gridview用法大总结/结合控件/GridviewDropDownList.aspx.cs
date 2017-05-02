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
/// Gridview中使用DropDownList
/// </summary>
public partial class GridviewHtmlCheckBox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    /// <summary>
    /// 绑定数据
    /// </summary>
    public void bind()
    {
        string sqlStr = "select * from Employee";
        DataSet myds = Common.dataSet(sqlStr);
        GridView1.DataSource = myds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
    }
    /// <summary>
    /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //行绑定DropDownList
        if (((DropDownList)e.Row.FindControl("DDLSex")) != null)
        {
            DropDownList ddlSex = (DropDownList)e.Row.FindControl("DDLSex");
            ddlSex.Items.Clear();
            ddlSex.Items.Add(new ListItem("男", "男"));
            ddlSex.Items.Add(new ListItem("女", "女"));
            //ddlSex.Items.Add(new ListItem("男"));
            //ddlSex.Items.Add(new ListItem("女"));
            //DropDownList初始被选择的项
            ddlSex.SelectedValue = ((HiddenField)e.Row.FindControl("HDFSex")).Value;
        }
        if (((DropDownList)e.Row.FindControl("DDLAddress")) != null)
        {
            DropDownList ddlAddress = (DropDownList)e.Row.FindControl("DDLAddress");
            DataSet ds = Common.dataSet("select Address from Address");
            ddlAddress.DataSource = ds.Tables[0].DefaultView;
            ddlAddress.DataTextField = "Address";
            ddlAddress.DataValueField = "Address";
            ddlAddress.DataBind();
            //当更改时，绑定第一个为它所属的分类
            ddlAddress.SelectedValue = ((HiddenField)e.Row.FindControl("HDFAddress")).Value;
        }
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的 Update 按钮（其 CommandName 属性设置为"Update"的按钮）时发生，但在 GridView 控件更新记录之前。此事件通常用于取消更新操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string Emp_ID = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
        string Emp_RealName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
        string Emp_Sex = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DDLSex")).SelectedValue;
        string Emp_Address = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DDLAddress")).SelectedValue;
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
}

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
/// Gridview插入记录
/// </summary>
public partial class 增除删改_GridviewInsertRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
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
        
    }
    //添加记录
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        TextBox empID = GridView1.FooterRow.FindControl("txtID") as TextBox;
        TextBox empRealName = GridView1.FooterRow.FindControl("txtRealName") as TextBox;
        DropDownList empSex = GridView1.FooterRow.FindControl("ddlSex") as DropDownList;
        TextBox empAddress = GridView1.FooterRow.FindControl("txtAddress") as TextBox;
        string sql = "insert into Employee(EmpID,EmpRealName,EmpSex,EmpAddress) values('" + empID.Text.ToString() + "','" + empRealName.Text.ToString() + "','" + empSex.SelectedValue.ToString() + "','" + empAddress.Text.ToString() + "')";
        Common.ExecuteSql(sql);
        bind();
    }
    //取消
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        GridView1.ShowFooter = false;
        bind();
        Functions.Alert("Cancel");
    }
    //显示Footer
    protected void showAdd_Click(object sender, EventArgs e)
    {
        GridView1.ShowFooter = true;
        bind();
    }
}

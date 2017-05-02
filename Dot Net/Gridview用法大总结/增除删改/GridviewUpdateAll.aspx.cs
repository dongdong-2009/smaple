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
using System.Text;
/// <summary>
/// Author:匆匆  Blog:http://www.cnblogs.com/huangjianhuakarl/
/// </summary>
public partial class 增除删改_GridviewUpdateAll : System.Web.UI.Page
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
        //行绑定DropDownList
        if (((DropDownList)e.Row.FindControl("ddlSex")) != null)
        {
            DropDownList ddlSex = (DropDownList)e.Row.FindControl("ddlSex");
            ddlSex.Items.Clear();
            ddlSex.Items.Add(new ListItem("男", "男"));
            ddlSex.Items.Add(new ListItem("女", "女"));
            //ddlSex.Items.Add(new ListItem("男"));
            //ddlSex.Items.Add(new ListItem("女"));
            //DropDownList初始被选择的项
            ddlSex.SelectedValue = ((HiddenField)e.Row.FindControl("hdfSex")).Value;
        }

    }
    protected void update_Click(object sender, EventArgs e)
    {
        
        //access不支持多语句的;Select * from  Categories;select * from Orders在SqlServer中支持
        /*for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];
            string empID = ((TextBox)row.Cells[0].FindControl("txtID")).Text.Replace("'", "");
            string empRealName = ((TextBox)row.Cells[0].FindControl("txtRealName")).Text.Replace("'", "");
            string empSex = ((DropDownList)row.Cells[0].FindControl("ddlSex")).SelectedValue;
            string empAddress = ((TextBox)row.Cells[0].FindControl("txtAddress")).Text.Replace("'", "");
            query.Append("update Employee set EmpID='" + empID + "',EmpRealName='" + empRealName + "',EmpSex='" + empSex + "',EmpAddress='" + empAddress + "' where ID=" + GridView1.DataKeys[i].Value + "");
            query.Append(";");
        }
        Common.ExecuteSql(query.ToString());
        bind();*/
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            StringBuilder query = new StringBuilder();
            GridViewRow row = GridView1.Rows[i];
            string empID = ((TextBox)row.Cells[0].FindControl("txtID")).Text.Replace("'", "");
            string empRealName = ((TextBox)row.Cells[0].FindControl("txtRealName")).Text.Replace("'", "");
            string empSex = ((DropDownList)row.Cells[0].FindControl("ddlSex")).SelectedValue;
            string empAddress = ((TextBox)row.Cells[0].FindControl("txtAddress")).Text.Replace("'", "");
            query.Append("update Employee set EmpID='" + empID + "',EmpRealName='" + empRealName + "',EmpSex='" + empSex + "',EmpAddress='" + empAddress + "' where ID=" + GridView1.DataKeys[i].Value + "");
            Common.ExecuteSql(query.ToString());
        }
        bind();
    }
}

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
/// Gridview中如何获得主键
/// </summary>
public partial class Keys : System.Web.UI.Page
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
        string sqlStr = "select * from Sms_Send";
        DataSet myds = Common.dataSet(sqlStr);
        GridView1.DataSource = myds;
        GridView1.DataKeyNames = new string[] { "Mobile","SendTime" };
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
    /// <summary>
    /// 在单击 GridView 控件内某一行的 Delete 按钮（其 CommandName 属性设置为"Delete"的按钮）时发生，但在 GridView 控件从数据源删除记录之前。此事件通常用于取消删除操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);//get Row index
        DataKey datakey = GridView1.DataKeys[index];
        string mobile = datakey["Mobile"].ToString();
        string sendTime = datakey["SendTime"].ToString();
        string sqlStr = "delete from Sms_Send where Mobile='" + mobile + "'and SendTime='" + sendTime + "'";
        Common.ExecuteSql(sqlStr);
        bind();
    }
    /// <summary>
    /// 当单击 GridView 控件中的按钮时发生
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //这里是模板列里面的按钮，需要设置CommandArgument ="<%# GridView1.Rows.Count %>"，否则出错
        if (e.CommandName == "DeleteRecord")
        {
            int index = Convert.ToInt32(e.CommandArgument);//get Row index
            DataKey datakey = GridView1.DataKeys[index];
            string mobile = datakey["Mobile"].ToString();
            string sendTime = datakey["SendTime"].ToString();
            string sqlStr = "delete from Sms_Send where Mobile='" + mobile + "'and SendTime='" + sendTime + "'";
            Common.ExecuteSql(sqlStr);
        }
        //这里是ButtonField；CommandArgument的值为被点击的按钮所在行的索引
        if (e.CommandName == "Del")
        {
            int index = Convert.ToInt32(e.CommandArgument);//get Row index
            DataKey datakey = GridView1.DataKeys[index];
            string mobile = datakey["Mobile"].ToString();
            string sendTime = datakey["SendTime"].ToString();
            string sqlStr = "delete from Sms_Send where Mobile='" + mobile + "'and SendTime='" + sendTime + "'";
            Common.ExecuteSql(sqlStr);
        }
        bind();                   
    }
    /// <summary>
    /// 当复选框被点击时发生
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)(GridView1.Rows[i].FindControl("CheckBox1"));
            if (CheckBox2.Checked == true)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
    }
    /// <summary>
    /// 删除所选记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                DataKey datakey = GridView1.DataKeys[i];
                string mobile = datakey["Mobile"].ToString();
                string sendTime = datakey["SendTime"].ToString();
                string sqlStr = "delete from Sms_Send where Mobile='" + mobile + "'and SendTime='" + sendTime + "'";
                Common.ExecuteSql(sqlStr);
            }
        }
        bind();
    }
    /// <summary>
    /// 恢复选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            cbox.Checked = false;
        }
    }
}

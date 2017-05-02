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
/// Gridview自定义分页页码
/// </summary>
public partial class GridviewPage : System.Web.UI.Page
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
        this.ddlCurrentPage.Items.Clear();
        for (int i = 1; i <= this.GridView1.PageCount; i++)
        {
            this.ddlCurrentPage.Items.Add(i.ToString());
        }
        this.ddlCurrentPage.SelectedIndex = this.GridView1.PageIndex;
    }
    /// <summary>
    /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        this.lblCurrentPage.Text = string.Format("当前第{0}页/总共{1}页", this.GridView1.PageIndex + 1, this.GridView1.PageCount); 

        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = GridView1.PageIndex * GridView1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
        
    }
    /// <summary>
    /// 重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = this.ddlCurrentPage.SelectedIndex;
        bind();
    }
    protected void lnkbtnFrist_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = 0;
        bind();
    }
    protected void lnkbtnPre_Click(object sender, EventArgs e)
    {
        if (this.GridView1.PageIndex > 0)
        {
            this.GridView1.PageIndex = this.GridView1.PageIndex - 1;
            bind();
        }
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (this.GridView1.PageIndex < this.GridView1.PageCount)
        {
            this.GridView1.PageIndex = this.GridView1.PageIndex + 1;
            bind();
        }
    }
    protected void lnkbtnLast_Click(object sender, EventArgs e)
    {
        this.GridView1.PageIndex = this.GridView1.PageCount;
        bind();
    } 
}

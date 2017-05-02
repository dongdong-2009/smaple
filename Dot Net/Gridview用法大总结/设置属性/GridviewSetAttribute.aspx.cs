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
using System.Drawing.Imaging;
using System.Drawing;
/// <summary>
/// Author:匆匆  Blog:http://www.cnblogs.com/huangjianhuakarl/
/// 设置Gridview中数据样式
/// </summary>
public partial class Attribute : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //正常换行
        GridView1.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
        //下面这行是自动换行
        GridView1.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
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
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            DataRowView mydrv = myds.Tables[0].DefaultView[i];
            string score = Convert.ToString(mydrv["EmpSalary"]);
            if (Convert.ToDouble(score) > 3000.00)//大家这里根据具体情况设置可能ToInt32等等
            {
                GridView1.Rows[i].Cells[7].BackColor = System.Drawing.Color.Cyan;
            }
        }
    }
    /// <summary>
    /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //每10行记录后增加一个空行
        if (e.Row.RowIndex > 0 && (e.Row.RowIndex + 1) % 5 == 0)
        {
            GridViewRow newRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            newRow.Cells.Add(new TableCell());
            newRow.Cells[0].ColumnSpan = e.Row.Cells.Count;
            newRow.Cells[0].Text = "&nbsp;";
            this.GridView1.Controls[0].Controls.Add(newRow);
        }

        //如果是绑定数据行，添加确认对话框 
        //<asp:Button ID="btnRefuse" runat="server" OnClick="btnRefuse_Click" Text="拒绝" OnClientClick="return confirm(' 你真的要删除?')"/>
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[8].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[1].Text + "\"吗?')");
            }
        }
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
        //设置具备某条件特定行的样式
        for (int i = -1; i < GridView1.Rows.Count; i++)
        {
            string lbl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EmpSex"));
            if (lbl == "女")
            {
                e.Row.Cells[3].ForeColor = Color.Fuchsia;
            }
        }
        //判定当前的行是否属于datarow类型的行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //当鼠标放上去的时候 先保存当前行的背景颜色并给附一颜色
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='Azure',this.style.fontWeight='';");
            //当鼠标离开的时候 将背景颜色还原的以前的颜色
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
        }
        //掩藏字段的处理
        e.Row.Cells[0].Visible = false;

    }
    /// <summary>
    /// 在单击页导航按钮时发生，但在 GridView 控件执行分页操作之前。此事件通常用于取消分页操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind();
    }
    /// <summary>
    /// 在单击 GridView 控件内某一行的 Delete 按钮（其 CommandName 属性设置为“Delete”的按钮）时发生，但在 GridView 控件从数据源删除记录之前。此事件通常用于取消删除操作。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sqlStr = "delete from Employee where ID=" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value) + "";
        Common.ExecuteSql(sqlStr);
        bind();
    }
}

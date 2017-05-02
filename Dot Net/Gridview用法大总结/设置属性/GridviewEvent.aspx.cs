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
public partial class 设置属性_GridviewEvent : System.Web.UI.Page
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
        //如果是绑定数据行，添加确认对话框 
        //<asp:Button ID="btnRefuse" runat="server" OnClick="btnRefuse_Click" Text="拒绝" OnClientClick="return confirm(' 你真的要删除?')"/>
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //鼠标移动到每项时颜色交替效果
            e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor='White';this.style.color='#003399'");
            e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor='#6699FF';this.style.color='#8C4510'");

            //不能同时测试:单击/双击 事件, 要分别测试它们
            //e.Row.Attributes.Add("OnDblClick", "DbClickEvent('" + e.Row.Cells[1].Text + "')");
            e.Row.Attributes.Add("OnClick", "ClickEvent('" + e.Row.Cells[1].Text + "')");

            //e.Row.Attributes.Add("OnKeyDown", "GridViewItemKeyDownEvent('" + e.Row.Cells[1].Text + "')"); 

            e.Row.Attributes["style"] = "Cursor:hand";

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[8].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[1].Text + "\"吗?')");
            }
        }
        //遍历所有行设置边框样式
        foreach (TableCell tc in e.Row.Cells)
        {
            tc.Attributes["style"] = "border-color:Black";
            //单击鼠标可以将单元格中的内容复制到剪切板 
            tc.Attributes.Add("onclick", "window.clipboardData.setData('Text', this.innerText);");
            //鼠标移入可以设置单元格字体颜色 
            tc.Attributes.Add("onmouseover", "this.style.color='red'");
            //鼠标移开,取消单元格字体颜色设置 
            tc.Attributes.Add("onmouseout", "this.style.color=''"); 
        }
        //用索引来取得编号
        if (e.Row.RowIndex != -1)
        {
            int id = GridView1.PageIndex * GridView1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
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

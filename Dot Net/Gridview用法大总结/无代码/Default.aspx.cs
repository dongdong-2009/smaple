using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Drawing.Imaging;
using System.Drawing;
/// <summary>
/// Author:匆匆  Blog:http://www.cnblogs.com/huangjianhuakarl/
/// </summary>
public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
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
}

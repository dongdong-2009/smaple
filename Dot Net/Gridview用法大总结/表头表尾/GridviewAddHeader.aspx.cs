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
/// Gridview中添加表头
/// </summary>
public partial class GridviewAddHeader : System.Web.UI.Page
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
    /// 在 GridView 控件中创建新行时发生，此事件通常用于在创建某个行时修改该行的布局或外观
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
                //判断是否表头
            case DataControlRowType.Header:
                //第一行表头
                TableCellCollection tcHeader = e.Row.Cells;
                tcHeader.Clear();

                tcHeader.Add(new TableHeaderCell());
                tcHeader[0].Attributes.Add("rowspan", "2");
                tcHeader[0].Attributes.Add("bgcolor", "Azure");
                tcHeader[0].Text = "编号";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[1].Attributes.Add("colspan", "6");
                tcHeader[1].Attributes.Add("bgcolor", "Azure");
                tcHeader[1].Text = "基  本  信  息";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[2].Attributes.Add("bgcolor", "Azure");
                tcHeader[2].Text = "福利</th></tr><tr>";

                //第二行表头
                tcHeader.Add(new TableHeaderCell());
                tcHeader[3].Attributes.Add("bgcolor", "Azure");
                tcHeader[3].Text = "账号";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].Attributes.Add("bgcolor", "Azure");
                tcHeader[4].Text = "姓名";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[5].Attributes.Add("bgcolor", "Azure");
                tcHeader[5].Text = "性别";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[6].Attributes.Add("bgcolor", "Azure");
                tcHeader[6].Text = "住址";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[7].Attributes.Add("bgcolor", "Azure");
                tcHeader[7].Text = "邮编";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[8].Attributes.Add("bgcolor", "Azure");
                tcHeader[8].Text = "生日";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[9].Attributes.Add("bgcolor", "Azure");
                tcHeader[9].Text = "月薪";
            break;
        }
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
        if (e.Row.RowIndex != -1)
        {
            int id = GridView1.PageIndex * GridView1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }
}

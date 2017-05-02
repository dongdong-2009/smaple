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
using System.Data.OleDb;
/// <summary>
/// Author:匆匆  Blog:http://www.cnblogs.com/huangjianhuakarl/
/// Gridview从Excel中读取数据
/// </summary>
public partial class GridviewReadExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
    /// <summary>
    /// Inport
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = createDataSource();
        GridView1.DataBind();
    }
    /// <summary>
    /// 以Excel为数据源获取数据集
    /// </summary>
    /// <returns></returns>
    private DataSet createDataSource()
    {
        string strCon;
        strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/Files/Employee.xls") + ";Extended Properties=Excel 8.0;";
        OleDbConnection con = new OleDbConnection(strCon);
        OleDbDataAdapter da = new OleDbDataAdapter("select * from [Employee$]", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
}

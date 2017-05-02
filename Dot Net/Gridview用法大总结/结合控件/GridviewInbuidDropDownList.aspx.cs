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
/// Gridview内嵌DropDownList
/// </summary>
public partial class GridviewInbuidDropDownList : System.Web.UI.Page
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
        string sqlCategory = @"select c.CategoryID,c.CategoryName from Categories c";
        DataSet dsCategory = Common.dataSet(sqlCategory);
        GridView1.DataSource = dsCategory.Tables[0];
        GridView1.DataKeyNames = new string[] { "CategoryID" };
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
        //
        DataTable myTable = new DataTable();
        DataColumn productIDColum = new DataColumn("ProductID");
        DataColumn productNameColumn = new DataColumn("ProductName");
        myTable.Columns.Add(productIDColum);
        myTable.Columns.Add(productNameColumn);
        string sqlProduct=@"select p.CategoryID,p.ProductID,p.ProductName from Products p";
        DataSet ds = Common.dataSet(sqlProduct);
        
        int categoryID=0;
        string express=String.Empty;
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            categoryID=Int32.Parse(e.Row.Cells[0].Text);
            express="CategoryID="+categoryID;
            DropDownList ddl=(DropDownList)e.Row.FindControl("DropDownList1");
            DataRow[] rows=ds.Tables[0].Select(express);

            foreach(DataRow row in rows)
            {
                DataRow newRow=myTable.NewRow();
                newRow["ProductID"]=row["ProductID"];
                newRow["ProductName"]=row["ProductName"];
                myTable.Rows.Add(newRow);
            }
            ddl.DataSource=myTable;
            ddl.DataTextField="ProductName";
            ddl.DataValueField="ProductID";
            ddl.DataBind();
        }
    }
}

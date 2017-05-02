using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
/*
使用这个函数，您可以得到GridView当前页面的数据，当然如果您在GridView中添加了复杂的控件，我们将略过这些内容，我们只从显示文本的列中导出数据到DataTable，如果您想导出GridView的全部数据，请在绑定前设置AllowPaging=false;
当然大家会问这样做有什么用呢？这个函数是我在开发将GridView导出Excel的时候想到的，类似于这种应用情形，我想还有很多。
*/

namespace jzlib.Common
{
    public class GridViewHelper
    {
        public static string GetCellText(TableCell cell)
        {
            string text = cell.Text;
            if (!string.IsNullOrEmpty(text))
            {
                return text;
            }
            foreach (Control control in cell.Controls)
            {
                if (control != null && control is ITextControl)
                {
                    LiteralControl lc = control as LiteralControl;
                    if (lc != null)
                    {
                        continue;
                    }
                    ITextControl l = control as ITextControl;

                    text = l.Text.Replace("\r\n", "").Trim();
                    break;
                }
            }
            return text;
        }
        /**//// <summary>
        /// 从GridView的数据生成DataTable
        /// </summary>
        /// <param name="gv">GridView对象</param>
        public static DataTable GridView2DataTable(GridView gv)
        {
            DataTable table = new DataTable();
            int rowIndex = 0;
            List<string> cols = new List<string>();
            if (!gv.ShowHeader && gv.Columns.Count == 0)
            {
                return table;
            }
            GridViewRow headerRow = gv.HeaderRow;
            int columnCount =headerRow.Cells.Count;
            for (int i = 0; i < columnCount; i++)
            {
                string text = GetCellText(headerRow.Cells[i]);
                cols.Add(text);
            }
            foreach (GridViewRow r in gv.Rows)
            {             
                if (r.RowType == DataControlRowType.DataRow)
                {
                    DataRow row = table.NewRow();                   
                    int j = 0;
                    for (int i = 0; i < columnCount; i++)
                    {                    
                        string text = GetCellText(r.Cells[i]);
                        if (!String.IsNullOrEmpty(text))
                        {
                            if (rowIndex == 0)
                            {
                                DataColumn dc = table.Columns.Add();
                                string columnName = cols[i];
                                if (String.IsNullOrEmpty(columnName))
                                {
                                    columnName = gv.Columns[i].HeaderText;
                                    if (string.IsNullOrEmpty(columnName))
                                    {
                                        continue;
                                    }
                                }
                                dc.ColumnName = columnName;
                                dc.DataType = typeof(string);
                            }
                            row[j] = text;
                              j++; 
                        }
                                               
                    }
                    rowIndex++;
                    table.Rows.Add(row);
                }
            }
            return table;
        }
    }
}

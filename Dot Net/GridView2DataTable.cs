using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
/*
ʹ����������������Եõ�GridView��ǰҳ������ݣ���Ȼ�������GridView������˸��ӵĿؼ������ǽ��Թ���Щ���ݣ�����ֻ����ʾ�ı������е������ݵ�DataTable��������뵼��GridView��ȫ�����ݣ����ڰ�ǰ����AllowPaging=false;
��Ȼ��һ�����������ʲô���أ�������������ڿ�����GridView����Excel��ʱ���뵽�ģ�����������Ӧ�����Σ����뻹�кܶࡣ
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
        /// ��GridView����������DataTable
        /// </summary>
        /// <param name="gv">GridView����</param>
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

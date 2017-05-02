/********************************************************************************************************* 
 Autodata ver 1.0.0.0 >> JSON Class
 ======================================================================
  Created By & Created Date		: Ravi Kant Srivastava & 15th May'06
  Modified By & Date			: Ravi Kant Srivastava & 20th Jul'06
  Name                          : JSON_Class.cs
  
 
**********************************************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;

namespace Ravs.Factory.JSON
{
    public class JSON_Class
    {
        /// <summary>
        /// This Method Will Convert ASP.net DataTable into Json String, and then in javascript
        /// this string will be converted into object. like OBJ.TABLE[0].ROW[0].CELL[0].DATA 

        /// </summary>
        /// <param name="dt"> Requires a Datatable</param>
        /// <returns> return a string contain JSON DataTable </returns>
        public string JSON_DataTable(DataTable dt)
        {
            /****************************************************************************
             * Without goingin to the depth of the functioning of this Method, i will try to give an overview
             * As soon as this method gets a DataTable it starts to convert it into JSON String,
             * it takes each row and ineach row it creates an array of cells and in each cell is having its data
             * on the client side it is very usefull for direct binding of object to  TABLE.
             * Values Can be Access on clien in this way. OBJ.TABLE[0].ROW[0].CELL[0].DATA 
             * NOTE: One negative point. by this method user will not be able to call any cell by its name.
             * *************************************************************************/
            StringBuilder JsonString = new StringBuilder();
            JsonString.Append("{ ");
            JsonString.Append("\"TABLE\":[{ ");
            JsonString.Append("\"ROW\":[ ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                JsonString.Append("{ ");
                JsonString.Append("\"COL\":[ ");
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    if (j < dt.Columns.Count - 1)
                    {
                        JsonString.Append("{" + "\"DATA\":\"" + dt.Rows[i][j].ToString() + "\"},");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        JsonString.Append("{" + "\"DATA\":\"" + dt.Rows[i][j].ToString() + "\"}");
                    }

                }
                /*end Of String*/
                if (i == dt.Rows.Count - 1)
                {
                    JsonString.Append("]} ");
                }
                else
                {
                    JsonString.Append("]}, ");
                }
            }
            JsonString.Append("]}]}");
            return JsonString.ToString();
        }
        public string CreateJsonParameters(DataTable dt)
        {
            /* /****************************************************************************
             * Without goingin to the depth of the functioning of this Method, i will try to give an overview
             * As soon as this method gets a DataTable it starts to convert it into JSON String,
             * it takes each row and in each row it grabs the cell name and its data.
             * This kind of JSON is very usefull when developer have to have Column name of the .
             * Values Can be Access on clien in this way. OBJ.HEAD[0].<ColumnName>
             * NOTE: One negative point. by this method user will not be able to call any cell by its index.
             * *************************************************************************/
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling        
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{ ");
                JsonString.Append("\"Head\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                        }

                    }
                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]}");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

    }
}

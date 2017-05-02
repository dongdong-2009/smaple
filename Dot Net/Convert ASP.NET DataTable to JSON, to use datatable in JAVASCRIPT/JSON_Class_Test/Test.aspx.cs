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
using Ravs.Factory.JSON;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable TempDataTable = new DataTable();
        TempDataTable.Columns.Add("Name");
        TempDataTable.Columns.Add("Age");
        TempDataTable.Columns.Add("Address");
        ////////////////////////Add Few Rows of Data/////////////////////////
            
            //////////////////////////////ROW 1/////////////////////////////////////
            DataRow tempDataRow0 = TempDataTable.NewRow();
            tempDataRow0["Name"] = "Ravi Kant Srivastava";
            tempDataRow0["Age"] = "21";
            tempDataRow0["Address"] = "A 17/7";
            TempDataTable.Rows.Add(tempDataRow0);
            //////////////////////////////ROW 2/////////////////////////////////////
            DataRow tempDataRow1 = TempDataTable.NewRow();
            tempDataRow1["Name"] = "Samarth Abrol";
            tempDataRow1["Age"] = "21";
            tempDataRow1["Address"] = "A 17/7";
            TempDataTable.Rows.Add(tempDataRow1);
            //////////////////////////////ROW 3/////////////////////////////////////
            DataRow tempDataRow2 = TempDataTable.NewRow();
            tempDataRow2["Name"] = "Chetan Tyagi";
            tempDataRow2["Age"] = "21";
            tempDataRow2["Address"] = "A 17/7";
            TempDataTable.Rows.Add(tempDataRow2);
            /////////////////////////////////////////////////////////////////////
            JSON_Class Object_JSON_Class = new JSON_Class();
            ///////// JSON String with Rows And Cols////////////////////////////
            JSON_DataTable_DataHolder.Value= Object_JSON_Class.JSON_DataTable(TempDataTable);
            ///////// JSON String with Rows And ColNames////////////////////////////
            JSON_Parameter_DataHolder.Value= Object_JSON_Class.CreateJsonParameters(TempDataTable);




    }
}

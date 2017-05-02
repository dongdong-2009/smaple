using System;
using System.Data;
using System.IO;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler 
{
    /// <summary>
    /// Holds the result that will be send to the Page
    /// </summary>
    protected string CallBackResult;


    protected void Page_Load(object sender, EventArgs e)
    {
        //Register the CallBack Method
        string ReceiverCallBackMethod;
        ReceiverCallBackMethod = Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveCallBackResult", "context");
        //Register the method that makes the callback
        string CallBackMethod;
        CallBackMethod = "function CallServer(arg, context) { " + ReceiverCallBackMethod + "} ;";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CallServer", CallBackMethod,true );

    }


    /// <summary>
    /// Creates some HTML code
    /// </summary>
    /// <returns>The HTML</returns>
    public string ShowTheData()
    {
        //The datasource
        DataSet DS = new DataSet();
        //Check the file exists
        FileInfo file = new FileInfo(Server.MapPath(Request.ApplicationPath) + "/Data.xml");
        if (!file.Exists)
        {
            DS.Tables.Add("Users");
            DS.Tables["Users"].Columns.Add("User Name", typeof(string));
            DS.Tables["Users"].Columns.Add("Age", typeof (int));
            DS.WriteXml(file.FullName, XmlWriteMode.WriteSchema);
        }
        else
        {
            DS.ReadXml(file.FullName);
        }
        //The HTML
        string HTML = "<Table border=1>";
        //Add some headers
        HTML += "<tr><td>Name</td><td>Age</td></tr>";
        foreach (DataRow Row in DS.Tables["Users"].Rows)
        {
            string TR = "<TR>";
            //show the name and Age
            TR += "<td>" + Row[0].ToString() + "</td>";
            TR += "<td>" + Row[1].ToString() + "</td>";
            TR += "</tr>";
            HTML += TR;
        }
        return HTML + "</TABLE>";
    }



    /// <summary>
    /// The Event that proccess the Call Back
    /// </summary>
    /// <param name="eventArgument">Send values to proccess here</param>
    public void RaiseCallbackEvent(string eventArgument) 
    {
        //In this case we dont need to proccess nothing 
    }


    /// <summary>
    /// This will return some data to the Caller Page
    /// </summary>
    /// <returns>HTML string with all the users</returns>
    public string GetCallbackResult()
    {
        //Return HTML 
        return this.ShowTheData();
    }
}

using System;
using System.Data;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ClientCallBack : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler 
{

    /// <summary>
    /// To hold the CallBack Result
    /// </summary>
    protected string CallBackResult;

    /// <summary>
    /// Manually add the scripts to make the CallBack
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        //Register the CallBack Method
        string ReceiverCallBackMethod;
        ReceiverCallBackMethod = Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveCallBackResult", "context");
        //Register the method that makes the callback
        string CallBackMethod;
        CallBackMethod = "function CallServer(arg, context) { " + ReceiverCallBackMethod + "} ;";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CallServer", CallBackMethod, true);
    }


    /// <summary>
    /// The Event that proccess the Call Back
    /// </summary>
    /// <param name="eventArgument">Send values to proccess here</param>
    public void RaiseCallbackEvent(string eventArgument)
    {
        //Proccess the Argument, because the argument MUST be a string
        //and we receive two values separated with a custome separator (|)
        //Get the name and Age
        string Name = eventArgument.Substring(0, eventArgument.IndexOf("|"));
        int Age = int.Parse (eventArgument.Substring(eventArgument.IndexOf("|") + 1));

        //The datasource
        DataSet DS = new DataSet();
        //Check the file exists
        FileInfo file = new FileInfo(Server.MapPath(Request.ApplicationPath) + "/Data.xml");
        if (!file.Exists)
        {
            DS.Tables.Add("Users");
            DS.Tables["Users"].Columns.Add("User Name", typeof(string));
            DS.Tables["Users"].Columns.Add("Age", typeof(int));
        }
        else
        {
            DS.ReadXml(file.FullName);
        }

        //Add the User
        DataRow User = DS.Tables["Users"].NewRow();
        User[0] = Name;
        User[1] = Age;
        DS.Tables["Users"].Rows.Add(User);
        //Write the DS to the file
        DS.WriteXml(file.FullName, XmlWriteMode.WriteSchema);

        //Set the CallBack result
        this.CallBackResult = "Added User Name:" + Name + " Age:" + Age.ToString() + "    Added At:" + DateTime .Now.ToShortDateString() ;
    }


    /// <summary>
    /// This will return some data to the Caller Page
    /// </summary>
    /// <returns>HTML string with all the users</returns>
    public string GetCallbackResult()
    {
       //Return the call back result
        return this.CallBackResult;
    }
}

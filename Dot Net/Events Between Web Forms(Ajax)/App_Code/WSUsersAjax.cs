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
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.Script.Services;


namespace CallBacks
{
/// <summary>
/// Summary description for WSUsers
/// </summary>
[ScriptService]
public partial class WSUsers : System.Web.Services.WebService
{
    [WebMethod (Description = "Add a New User")]
    [ScriptMethod]
    public string AddUser(string Name, int Age)
    {
        //The datasource
        DataSet DS = new DataSet();
        //Check the file exists
        FileInfo file = new FileInfo(Server.MapPath(System.Web.HttpRuntime .AppDomainAppVirtualPath) + "/Data.xml");
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

        return "Added User Name:" + Name + " Age:" + Age.ToString() + "    Added At:" + DateTime.Now.ToShortDateString();
    }
 }
}



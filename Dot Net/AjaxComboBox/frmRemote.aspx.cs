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
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Data.SqlClient;
public partial class frmRemote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["SearchText"] != null)
        {
            string SearchText = Request["SearchText"].ToString();
            int count = 0;
            string strXmlNames = "";

            if (SearchText != "")
            {
                XPathDocument xDoc = new XPathDocument(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "EmployeeList.xml");
                XPathNavigator xNav = xDoc.CreateNavigator();

                XPathExpression strExpression = xNav.Compile("Employee/EmpName");

                XPathNodeIterator xIterator = xNav.Select(strExpression);

                while (xIterator.MoveNext())
                {
                    XPathNavigator nav = xIterator.Current.Clone();
                    if (nav.Value.Trim().StartsWith(SearchText, true, null))
                    {
                        strXmlNames += "<element><Text>" + nav.Value + "</Text> <Id>" + nav.Value + "</Id></element>";
                        count++;
                    }
                }
                
            }
            if(count>0)
                strXmlNames += "<element><Text>" + "Total search result: " + count + "</Text> <Id>" + count + "</Id></element>";
            strXmlNames = "<?xml version=\"1.0\" ?><Records>" + strXmlNames + "</Records>";

            Response.Clear();
            Response.ContentType = "text/xml";

            Response.Write(strXmlNames);
            Response.End();
        }
    }
}

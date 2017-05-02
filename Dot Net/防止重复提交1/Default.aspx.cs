using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using System.Threading;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assembly aa = Assembly.LoadWithPartialName("TestClassLib");
        //Stream s = aa.GetManifestResourceStream("TestClassLib.js.test.js");
        //byte[] baaa = new byte[s.Length];
        //s.Read(baaa, 0, baaa.Length);
        //this.ClientScript.RegisterClientScriptInclude(this.GetType(), "a", this.ClientScript.GetWebResourceUrl(this.GetType(), "TestClassLib.js.test.js"));
        //string ss =  Encoding.GetEncoding("utf-8").GetString(baaa);

        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.TextBox1.Text += "a";
        Thread.Sleep(3000);
    }
}

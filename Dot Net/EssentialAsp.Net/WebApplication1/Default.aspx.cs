using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EssentialAspNet;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Type hostType = typeof(Intelligencer);
            Intelligencer intelligencer = System.Web.Hosting.ApplicationHost.CreateApplicationHost(hostType, "/", System.Environment.CurrentDirectory) as Intelligencer;

            Console.WriteLine("Current Domain ID: {0}\r\n", AppDomain.CurrentDomain.Id);
            Console.WriteLine(intelligencer.Report());
            Console.ReadLine();
        }
    }
}
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
using System.Web.Caching;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCacheDependencyAdmin.EnableTableForNotifications("server=ZHOUMING-95A064\\SQLEXPRESS;uid = sa; pwd = sa; database= Northwind", "Customers");
        AggregateCacheDependency dependency = new AggregateCacheDependency();
        dependency.Add(new SqlCacheDependency("Northwind", "Customers"));
        dt = (DataTable)HttpRuntime.Cache["my"];
        if (dt == null)
        {
            InitData();
            HttpRuntime.Cache.Add("my", dt, dependency, DateTime.Now.AddHours(12), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }      
    }

    private void InitData()
    {
        dt = new DataTable();
        SqlConnection con = new SqlConnection("server=ZHOUMING-95A064\\SQLEXPRESS;uid = sa; pwd = sa; database= Northwind");
        SqlCommand cmd = new SqlCommand("select top 10 * from Customers", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
    }
}
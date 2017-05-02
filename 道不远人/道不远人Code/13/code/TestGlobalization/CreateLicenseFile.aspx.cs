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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public partial class CreateLicenseFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string licFilePath = Server.MapPath("~/licenses.lic");
        if (!File.Exists(licFilePath))
        {
            //不使用BinaryFormatter直接序列化许可数据
            //LicensedControls.LicenseDataDictionary licenses
            //    = new LicensedControls.LicenseDataDictionary();
            //licenses.Add("LicensedControls.LicensedLable"
            //        , DateTime.Now.AddYears(1).Ticks);
            //BinaryFormatter formatter = new BinaryFormatter();
            using (StreamWriter fs = File.CreateText(licFilePath))
            {
                //formatter.Serialize(fs, licenses);
                fs.WriteLine("{0}:{1}", "LicensedControls.LicensedLable"
                    , DateTime.Now.AddYears(1).Ticks);
            }
        }
    }
}

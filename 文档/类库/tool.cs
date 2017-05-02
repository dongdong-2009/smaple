/****************************************
 * 周铭
 * 最后修改日期:2007-07-18
 * tool.cs* 
 ****************************************/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using System.Configuration;
using System.IO;

namespace WeYyzyq.Comp
{
	/// <summary>
	/// tool 的摘要说明。
	/// </summary>
	public class tool
	{
		public static SPList getList()
		{
			SPSite site = new SPSite(ConfigurationSettings.AppSettings["url"].ToString());
			SPWeb web = site.OpenWeb();
			web.AllowUnsafeUpdates = true;
			SPList list = web.Lists[new Guid(ConfigurationSettings.AppSettings["guid"].ToString())];
			return list;
		}

		public static void Message(Page page,string msg)
		{
			page.Response.Write("<script>alert('" + msg  +"')</script>");
		}

   		public static string getDayOfWeek(DateTime dt)
  		{
   		        return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dt.DayOfWeek);
		}

    public static DateTime getFirstDayOfWeek()//本周第一天(星期一)
    {
        int a = (int)DateTime.Today.DayOfWeek;        
        DateTime dt = DateTime.Today.AddDays(0 - a+1);//默认星期日为第一天
        return dt.Date;
    }

    public static DateTime getLastDayOfWeek()//本周最后一天(星期五)
    {                
        DateTime dt = getFirstDayOfWeek();
        dt= dt.AddDays(4);
        return dt;
    }

    public static string delLastChar(string str,string _char)
    {
        if (str.EndsWith(_char))
        {
            str = str.Substring(0, str.Length - 1);
        }
        return str;
    }

        public static string getFileType(string fileName)
        {
            string type = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
            return type;
        }

        public static string getFileName(string fullName)
        {
            string str_FileName = fullName.ToLower().Trim();
            str_FileName = fullName.Substring(fullName.LastIndexOf("\\") + 1);
            str_FileName = str_FileName.Replace(".exe", "");
            return str_FileName;
        }

public static void closeWindow(Page page)
    {
        StringBuilder s = new StringBuilder();
        s = s.AppendLine("<script>");
        s = s.AppendLine("if(window.opener != null) { ");
        s = s.AppendLine("window.opener.location.href = window.opener.location.href;}");
        s = s.AppendLine("window.opener == null ");
        s = s.AppendLine("window.close();");
        s = s.AppendLine("</script>");
        page.ClientScript.RegisterStartupScript(page.GetType(), "", s.ToString());
    }

public static bool IsNumeric(string str)
    {
        if (str == null || str.Length == 0)
        {
            return false;
        }

        foreach (char c in str)
        {
            if (!Char.IsNumber(c))
            {
                return false;
            }
        }
        return true;
    }


public struct dflMail
{
    public string from;
    public string to;
    public string fromDisplayName;
    public string subject;
    public string body;
}
public static void sendMail(dflMail mail)
        {
            MailAddress fromAddress = new MailAddress(mail.from, mail.fromDisplayName);
            MailMessage msg = new MailMessage();
            msg.From = fromAddress;
            string[] sendTo = mail.to.Split(';');
            foreach (string temp in sendTo)
            {
                if (temp != string.Empty)
                {
                    msg.Bcc.Add(temp);
                }               
            }
            msg.IsBodyHtml = true;
            msg.Subject = mail.subject;
            msg.Body = mail.body;

            SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["mail"]);
            smtpClient.Send(msg);
        }

    /// <summary>
    /// 获得当前登陆名
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public static string getloginName(Page page)
    {
        string loginName = page.User.Identity.Name;
        int j = loginName.LastIndexOf("\\");
        loginName = loginName.Substring(j + 1);
        return loginName;
    }

    public static bool IsAllowedExtension(string path)
    {
        System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
        string fileclass = "";
        byte buffer;
        try
        {
            buffer = r.ReadByte();
            fileclass = buffer.ToString();
            buffer = r.ReadByte();
            fileclass += buffer.ToString();
        }
        catch
        {

        }
        r.Close();
        fs.Close();
        if (fileclass == "255216" || fileclass == "7173")//说明255216是jpg;7173是gif;6677是BMP,13780是PNG;7790是exe,8297是rar
        {
            return true;
        }
        else
        {
            return false;
        }
    }

//本周是本年第几周 
public static int DatePart(System.DateTime dt) 
{ 
int weeknow = Convert.ToInt32(dt.DayOfWeek);//今天星期几 
int daydiff = (-1) * (weeknow+1);//今日与上周末的天数差 
int days = System.DateTime.Now.AddDays(daydiff).DayOfYear;//上周末是本年第几天 
int weeks = days/7; 
if(days%7 != 0) 
{ 
weeks++; 
} 
//此时，weeks为上周是本年的第几周 
return (weeks+1); 
} 


        public static string formatTime(string _time)//去掉秒的部分
        {
            if (_time != string.Empty)
            {
                int i = _time.LastIndexOf(':');
                return _time.Substring(0, i);
            }
            else
            {
                return _time;
            }
        }

public static string CheckCidInfo(string  cid)//验证身份证
    {
        string[]  aCity  =  new  string[]{null,null,null,null,null,null,null,null,null,null,null,"北京","天津","河北","山西","内蒙古",null,null,null,null,null,"辽宁","吉林"
            ,"黑龙江",null,null,null,null,null,null,null,"上海","江苏","浙江","安微","福建","江西"
            ,"山东",null,null,null,"河南","湖北","湖南","广东","广西","海南",null,null,null,"重庆"
            ,"四川","贵州","云南","西藏",null,null,null,null,null,null,"陕西","甘肃","青海","宁夏"
            ,"新疆",null,null,null,null,null,"台湾",null,null,null,null,null,null,null,null,null,"香港"
            ,"澳门",null,null,null,null,null,null,null,null,"国外"};
        double  iSum=0;        
        System.Text.RegularExpressions.Regex  rg  =  new  System.Text.RegularExpressions.Regex(@"^\d{17}(\d|x)$");
        System.Text.RegularExpressions.Match  mc  =  rg.Match(cid);

        if(!mc.Success)
        {
            return  "";
        }

        cid  =  cid.ToLower();
        cid  =  cid.Replace("x","a");

        if(aCity[int.Parse(cid.Substring(0,2))]==null)
        {
            return  "非法地区";
        }

        try
        {
            DateTime.Parse(cid.Substring(6,4)+"-"+cid.Substring(10,2)+"-"+cid.Substring(12,2));
        }
        catch
        {
            return  "非法生日";
        }

        for(int  i=17;i>=0;i--)
        {        
            iSum  +=(System.Math.Pow(2,i)%11)*int.Parse(cid[17-i].ToString(),System.Globalization.NumberStyles.HexNumber);
        }

        if(iSum%11!=1)
        {
            return("非法证号");
        }
        return(aCity[int.Parse(cid.Substring(0,2))]+","+cid.Substring(6,4)+"-"+cid.Substring(10,2)+"-"+cid.Substring(12,2)+","+(int.Parse(cid.Substring(16,1))%2==1?"男":"女"));      
    }

        public static string GetResponsePage(string WebPath)
        {
            HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(WebPath);
            wr.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse htt = (HttpWebResponse)wr.GetResponse();
            byte[] bytes = new byte[htt.ContentLength];
            System.IO.Stream stream = htt.GetResponseStream();
            stream.Read(bytes, 0, Convert.ToInt32(htt.ContentLength));
            string ss = System.Text.Encoding.GetEncoding("GB2312").GetString(bytes, 0, bytes.Length);
            return ss;
        }

        /// <summary>
        /// 最大化窗口
        /// </summary>
        /// <param name="page"></param>
        public static void maxWindow(Page page)
        {
            StringBuilder s = new StringBuilder();
            s = s.AppendLine("<script>");
            s = s.Append("window.resizeTo(window.screen.width,window.screen.height-20);	window.moveTo(0,0);");
            s = s.AppendLine("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "maxWin", s.ToString());
        }

public static string delFirstChar(string str, string _char)
        {
            if (str.StartsWith(_char))
            {
                str = str.Substring(1);
            }
            return str;
        }

#region   取出文本中的图片地址
        ///   <summary>   
        ///   取出文本中的图片   
        ///   </summary>   
        ///   <param   name="HTMLStr">HTMLStr</param>   
        public static List<string> GetImg(string HTMLStr)
        {
            List<string> list = new List<string>();
            Regex re = new Regex(@"<IMG[^>]*?src\s*=\s*(""(?<src>[^""]+?)""|'(?<src>[^']+?)'|(?<src>[^\s>]+))[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match m in re.Matches(HTMLStr))
            {
                list.Add(m.Value);
            }
            return list;
        }
        #endregion

        #region 从<img>标签中找出src的值
        /// <summary>
        /// 从<img>标签中找出src的值
        /// </summary>
        /// <param name="HTMLStr"></param>
        /// <returns></returns>
        public static string GetImgUrl(string HTMLStr)
        {            
            int i = HTMLStr.IndexOf("src=", StringComparison.OrdinalIgnoreCase);
            if (i == 0)
            {
                return "";
            }
            int k = HTMLStr.IndexOf("=", i) + 1;
            string[] arr = new string[] { ".bmp", ".jpg", ".gif", ".jpeg", ".png" };
            int n = 0;
            foreach (string s in arr)
            {
                n = HTMLStr.IndexOf(s, k, StringComparison.OrdinalIgnoreCase);
                if (n != -1)
                {
                    n += s.Length;
                    break;
                }
            }
            if (n == 0)
            {
                return "";
            }
            String aaa = HTMLStr.Substring(k, n - k);
            aaa = aaa.Replace("\'", "").Replace("\"", "").Replace(" ", "").Replace("\\", "");
            return aaa;
        }
        #endregion

string LosSerializeObject(object obj)
    {
        System.Web.UI.LosFormatter los = new LosFormatter();
        System.IO.StringWriter sw = new System.IO.StringWriter();
        los.Serialize(sw, obj);
        return sw.ToString();
    }

    Object RetrieveObjectFormViewState(string SerializedObject)
    {
        System.Web.UI.LosFormatter los = new LosFormatter();
        return los.Deserialize(SerializedObject);
    }

///<summary>
		/// 验证字符传是否符合Ip格式
		///</summary>
		///<param name="StrValue">待验证数据</param>
		///<returns>待验证数据符合Ip格式返回true,否则返回false</returns>
		public static bool IsIpFormat(string strIp)
		{
			try
			{
				string str ="^"+@"(\d\d\d|\d\d|\d)\."+
					@"(\d\d\d|\d\d|\d)\."+
					@"(\d\d\d|\d\d|\d)\."+
					@"(\d\d\d|\d\d|\d)"+ 
					"$";
				Regex obj=new Regex(str);

				if(obj.IsMatch(strIp))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch(System.Exception ex)
			{
				throw ex;
			}
		}
	}
}

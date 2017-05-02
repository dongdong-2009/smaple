/****************************************
 * ����
 * ����޸�����:2007-07-18
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
	/// tool ��ժҪ˵����
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

    public static DateTime getFirstDayOfWeek()//���ܵ�һ��(����һ)
    {
        int a = (int)DateTime.Today.DayOfWeek;        
        DateTime dt = DateTime.Today.AddDays(0 - a+1);//Ĭ��������Ϊ��һ��
        return dt.Date;
    }

    public static DateTime getLastDayOfWeek()//�������һ��(������)
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
    /// ��õ�ǰ��½��
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
        if (fileclass == "255216" || fileclass == "7173")//˵��255216��jpg;7173��gif;6677��BMP,13780��PNG;7790��exe,8297��rar
        {
            return true;
        }
        else
        {
            return false;
        }
    }

//�����Ǳ���ڼ��� 
public static int DatePart(System.DateTime dt) 
{ 
int weeknow = Convert.ToInt32(dt.DayOfWeek);//�������ڼ� 
int daydiff = (-1) * (weeknow+1);//����������ĩ�������� 
int days = System.DateTime.Now.AddDays(daydiff).DayOfYear;//����ĩ�Ǳ���ڼ��� 
int weeks = days/7; 
if(days%7 != 0) 
{ 
weeks++; 
} 
//��ʱ��weeksΪ�����Ǳ���ĵڼ��� 
return (weeks+1); 
} 


        public static string formatTime(string _time)//ȥ����Ĳ���
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

public static string CheckCidInfo(string  cid)//��֤���֤
    {
        string[]  aCity  =  new  string[]{null,null,null,null,null,null,null,null,null,null,null,"����","���","�ӱ�","ɽ��","���ɹ�",null,null,null,null,null,"����","����"
            ,"������",null,null,null,null,null,null,null,"�Ϻ�","����","�㽭","��΢","����","����"
            ,"ɽ��",null,null,null,"����","����","����","�㶫","����","����",null,null,null,"����"
            ,"�Ĵ�","����","����","����",null,null,null,null,null,null,"����","����","�ຣ","����"
            ,"�½�",null,null,null,null,null,"̨��",null,null,null,null,null,null,null,null,null,"���"
            ,"����",null,null,null,null,null,null,null,null,"����"};
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
            return  "�Ƿ�����";
        }

        try
        {
            DateTime.Parse(cid.Substring(6,4)+"-"+cid.Substring(10,2)+"-"+cid.Substring(12,2));
        }
        catch
        {
            return  "�Ƿ�����";
        }

        for(int  i=17;i>=0;i--)
        {        
            iSum  +=(System.Math.Pow(2,i)%11)*int.Parse(cid[17-i].ToString(),System.Globalization.NumberStyles.HexNumber);
        }

        if(iSum%11!=1)
        {
            return("�Ƿ�֤��");
        }
        return(aCity[int.Parse(cid.Substring(0,2))]+","+cid.Substring(6,4)+"-"+cid.Substring(10,2)+"-"+cid.Substring(12,2)+","+(int.Parse(cid.Substring(16,1))%2==1?"��":"Ů"));      
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
        /// ��󻯴���
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

#region   ȡ���ı��е�ͼƬ��ַ
        ///   <summary>   
        ///   ȡ���ı��е�ͼƬ   
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

        #region ��<img>��ǩ���ҳ�src��ֵ
        /// <summary>
        /// ��<img>��ǩ���ҳ�src��ֵ
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
		/// ��֤�ַ����Ƿ����Ip��ʽ
		///</summary>
		///<param name="StrValue">����֤����</param>
		///<returns>����֤���ݷ���Ip��ʽ����true,���򷵻�false</returns>
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

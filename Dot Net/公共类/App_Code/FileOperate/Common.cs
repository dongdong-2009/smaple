using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;

/// <summary>
/// 一些公用的方法
/// </summary>
public class Common
{
  /// <summary>
  /// 获取指定字符串的MD5值
  /// </summary>
  /// <param name="pSeed">要MD5的值</param>
  /// <returns></returns>
  public static string md5(string pSeed)
  {
    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pSeed, "MD5").ToLower();
  }
  /// <summary>
  /// 删除指定路径的文件
  /// </summary>
  /// <param name="Path">路径</param>
  /// <returns>删除是否成功</returns>
  public static bool DeleteFile(string Path)
  {
    if (System.IO.File.Exists(Path))
      try
      {
        System.IO.File.Delete(Path);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    else
      return true;
  }
  /// <summary>
  /// 在指定路径创建目录
  /// </summary>
  /// <param name="Path">路径</param>
  /// <returns>创建是否成功</returns>
  public static bool CreateDirectory(string Path)
  {
    if (System.IO.Directory.Exists(Path))
      return true;
    else
    {
      try
      {
        System.IO.Directory.CreateDirectory(Path);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
  /// <summary>
  /// 以时间为种子生成文件名称
  /// </summary>
  /// <returns></returns>
  public static string GenerateFileName()
  {
    return DateTime.Now.ToString("yyyyMMddhhmmss") + DateTime.Now.Millisecond.ToString();
  }
  /// <summary>
  /// 注册提示客户端脚本
  /// </summary>
  /// <param name="pScript">脚本</param>
  /// <param name="pKey">键值</param>
  public static void RegisterAlertScript(string pMessage, string pNavigateTo, string pKey, Page pPage)
  {
    string Script = @"alert('" + pMessage + @"');window.navigate('" + pNavigateTo + @"');";
    pPage.ClientScript.RegisterClientScriptBlock(pPage.GetType(), pPage.UniqueID + pKey,
    Script, true);
  }

  /// <summary>
  /// 注册提示客户端脚本
  /// </summary>
  /// <param name="pScript">脚本</param>
  /// <param name="pKey">键值</param>
  public static void RegisterConfirmScript(string pMessage, string pYesNavigateTo, string pNoNavigateTo, string pKey, Page pPage)
  {
    string Script = @"if(confirm('" + pMessage + @"'))
                      window.navigate('" + pYesNavigateTo + @"');
                    else
                      window.navigate('" + pNoNavigateTo + @"')";
    pPage.ClientScript.RegisterClientScriptBlock(pPage.GetType(), pPage.UniqueID + pKey,
    Script, true);
  }
  /// <summary>
  /// 注册提示客户端脚本，并返回上一步
  /// </summary>
  /// <param name="pScript">脚本</param>
  /// <param name="pKey">键值</param>
  public static void RegisterAlertAndBackScript(string pMessage, string pKey, Page pPage)
  {
    string Script = @"alert('" + pMessage + @"');history.back();";
    pPage.ClientScript.RegisterClientScriptBlock(pPage.GetType(), pPage.UniqueID + pKey,
    Script, true);
  }
  /// <summary>
  /// 发送邮件
  /// </summary>
  public static string SendEmail(string pTitle, string pBody, string pSendTo, string pSendFrom,
   string pSMTP, string pSMTPUser, string pSMTPPassword)
  {
    SmtpClient smtp = new SmtpClient();
    smtp.Host = pSMTP;
    smtp.Credentials = new NetworkCredential(pSMTPUser, pSMTPPassword);

    try
    {
      smtp.Send(pSendFrom, pSendTo, pTitle, pBody);
    }
    catch (SmtpException e)
    {
      return e.StatusCode.ToString();
    }
    catch (Exception e)
    {
      return e.ToString();
    }
    return "success";
  }
  /// <summary>
  /// 测试指定字符串是否都是整数
  ///  </summary>
  public static bool IsNumber(string pToBeTest)
  {
    Regex reg = new Regex(@"\d+");
    return reg.IsMatch(pToBeTest);
  }
  /// <summary>
  /// 将指定对象序列化，并返回对应的字符串，若序列化失败，返回null
  /// </summary>
  public static string SerializeIt(object ToBeSerialized)
  {
    XmlSerializer serializer = new XmlSerializer(ToBeSerialized.GetType());
    MemoryStream stream = new MemoryStream();

    serializer.Serialize(stream, ToBeSerialized);

    byte[] storeit = stream.ToArray();
    string result = null;

    for (int i = 0; i < storeit.Length; i++)
    {
      result += (char)Convert.ToInt32(storeit[i]);
    }
    stream.Close();
    stream.Dispose();
    return result;
  }
  /// <summary>
  /// 将对方反序列化
  /// </summary>
  public static object DeserializeIt(string ToBeDeserialized, Type t)
  {
    XmlSerializer serializer = new XmlSerializer(t);

    char[] convertit = ToBeDeserialized.ToCharArray();

    byte[] storeit = new byte[convertit.Length];

    for (int i = 0; i < convertit.Length; i++)
      storeit[i] = Convert.ToByte(convertit[i]);

    MemoryStream stream = new MemoryStream(storeit);
    return serializer.Deserialize(stream);
  }
  /// <summary>
  /// 将文件上传到指定路径
  /// </summary>
  /// <param name="fld">文件上传控件</param>
  /// <param name="Path">文件保存的物理路径</param>
  /// <returns>保存的文件名</returns>
  public static string UploadFileToServer(FileUpload fld, string Path)
  {
    string returnName = GenerateFileName() + System.IO.Path.GetExtension(fld.FileName);
    string fileName = Path + @"/" + returnName;
    fld.SaveAs(fileName);
    return returnName;
  }
}

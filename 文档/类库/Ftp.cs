using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Text;


public static class Ftp
{
static string ftpServerIP = ConfigurationManager.AppSettings["FtpServer"];
    static string ftpServerUser = ConfigurationManager.AppSettings["FtpServerUser"];
    static string ftpServerPassword = ConfigurationManager.AppSettings["FtpServerPassword"];
    static string ftpServerIPDomain = ConfigurationManager.AppSettings["FtpServerDomain"];

    /// <summary>
    /// 在FTP服务器上创建目录
    /// </summary>
    /// <param name="FlolderName">目录名</param>
    public static void CreateFloder(string FlolderName)
    {
        string uri = ftpServerIP + FlolderName;
        Uri serverUri = new Uri(uri);
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
        request.Credentials = new NetworkCredential(ftpServerUser, ftpServerPassword, ftpServerIPDomain);
        request.Method = WebRequestMethods.Ftp.MakeDirectory;
        request.GetResponse();
    }

    /// <summary>
    /// 上传文件到FTP服务器
    /// </summary>
    /// <param name="filename"></param>
    public static void UpLoadFile(string FlolderName, string filename, Stream str)
    {
        FileInfo fileInf = new FileInfo(filename);
        string uri = ftpServerIP+FlolderName+"/" + fileInf.Name;
        Uri serverUri = new Uri(uri);

        if (serverUri.Scheme != Uri.UriSchemeFtp)
        {
            return;
        }

        FtpWebRequest reqFTP = (FtpWebRequest)WebRequest.Create(serverUri);
        //StreamReader sourceStream = new StreamReader(filename);
        StreamReader sourceStream = new StreamReader(str);
        byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
        sourceStream.Close();
        reqFTP.ContentLength = fileContents.Length;

        reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
        // ftp用户名和密码 
        reqFTP.Credentials = new NetworkCredential(ftpServerUser, ftpServerPassword, ftpServerIPDomain);

        Stream requestStream = reqFTP.GetRequestStream();
        requestStream.Write(fileContents, 0, fileContents.Length);
        requestStream.Close();
        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
        response.Close();
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    public static void DeleteFile(string filename)
    {

        string uri = ftpServerIP + "//" + filename;
        Uri serverUri = new Uri(uri);
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
        request.Credentials = new NetworkCredential(ftpServerUser, ftpServerPassword, ftpServerIPDomain);
        request.Method = WebRequestMethods.Ftp.DeleteFile;
        request.GetResponse();
    }

}
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

/// <summary>
/// Mail 的摘要说明
/// </summary>
public class Mail
{
    /// <summary>
    /// 注册时发送用户帐号跟密码
    /// </summary>
    /// <param name="receiver">用户注册邮箱</param>
    /// <param name="username">用户名</param>
    /// <param name="password">用户密码明文</param>
    public bool Register(string receiver, string username, string password)
    {
        System.Net.Mail.SmtpClient client;
        client = new System.Net.Mail.SmtpClient("smtp.sina.com");
        client.Timeout = 60000;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("sina@sina.com", "nidemima");
        client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        message.BodyEncoding = System.Text.Encoding.UTF8;
        message.From = new System.Net.Mail.MailAddress("sina@sina.com", "爱促销会员注册中心", System.Text.Encoding.UTF8);
        message.To.Add(new System.Net.Mail.MailAddress(receiver, username, System.Text.Encoding.UTF8));
        message.IsBodyHtml = false;
        message.Subject = "用户注册信息（asp.net）";
        message.Body = "尊敬的"+username + "会员：您好！\r\n    Thanks for you register！用户名是：" + username + "；密码是：" + password + 
            "。\r\n    点此进入asp.net programer：http://www.520aspnet.cn \r\nBest regards！\r\n此邮件为系统自动发送，请勿回复，如有疑问发邮件到 360624682@qq.com";
        try
        {


 

            client.Send(message);
            return true;
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// 用户忘记密码时发送用户密码
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="receiver">用户注册邮箱</param>
    /// <param name="password">用户密码明文</param>
    /// <returns></returns>
    public bool GetPassWord(string username, string receiver, string validate)
    {
        System.Net.Mail.SmtpClient client;
        client = new System.Net.Mail.SmtpClient("mail.dzxsw.com");
        client.Timeout = 60000;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("qiezi@dzxsw.com", "12471944");
        client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        message.BodyEncoding = System.Text.Encoding.Default;
        message.SubjectEncoding = System.Text.Encoding.Default;
        message.IsBodyHtml = true;
        message.From = new System.Net.Mail.MailAddress("qiezi@dzxsw.com", "Qiezi", System.Text.Encoding.Default);
        message.To.Add(new System.Net.Mail.MailAddress(receiver, username, System.Text.Encoding.Default));
        message.IsBodyHtml = false;
        message.Subject = "修改密码链接（大众小说网）";
        message.Body = username + "：您好！\r\n    请通过以下链接修改密码：\r\n    http://www.dzxsw.com/user/modify.aspx?username=" + username + "&validate=" + validate + "\r\n    注：本链接仅第一次使用生效！";
        try
        {
            client.Send(message);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
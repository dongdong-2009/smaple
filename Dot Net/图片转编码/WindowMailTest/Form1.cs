using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowMailTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_encode_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Title = "选择要转换的图片";
            dlg.Filter = "Image files (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.bmp|AllFiles (*.*)|*.*";
            if (DialogResult.OK == dlg.ShowDialog())
            {

                  txt_code.Text=  ImgToBase64String(dlg.FileName);
            }
        }
        /// <summary>
        /// 将图片转为base64编码的字符串
        /// </summary>
        /// <param name="Imagefilename">图片路径</param>
        /// <returns></returns>
        private string ImgToBase64String(string Imagefilename)
        {

            Bitmap bmp = new Bitmap(Imagefilename);

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
            return Convert.ToBase64String(arr);
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string mailBody = "<BODY style=\"MARGIN: 10px\"><DIV><IMG src=\"data:image/png;base64,"+txt_code.Text+"\"> </IMG></DIV></BODY> ";
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.163.com");
            client.UseDefaultCredentials = true;//设置为发送认证消息
            client.Credentials = new System.Net.NetworkCredential("用户名", "密码");//认证消息
            System.Net.Mail.MailMessage mess = new System.Net.Mail.MailMessage();
            mess.From = new System.Net.Mail.MailAddress("shiyeping@163.com", "要显示的发信人的名称");
            mess.To.Add(new System.Net.Mail.MailAddress("shiyeping@163.com", "要显示的收信人的名称"));
            mess.Subject = "主题";
            mess.IsBodyHtml = true;
            mess.Body = mailBody;
            try
            {
                client.Send(mess);
                MessageBox.Show("发送成功完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

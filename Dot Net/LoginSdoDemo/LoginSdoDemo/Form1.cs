using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoginSdoDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string aspcookie = "";
            string html =
                Http.GetHtml("https://cas.sdo.com:80/cas/login?service=http://zh.sdo.com/web1.0/home/index.asp",
                             out aspcookie);
            aspcookie = aspcookie.Split(';')[0];
            richTextBox1.AppendText("获得的Cookie：" + aspcookie+"\r\n");
         
            string lt = Getlt(html);

            string header = "";
            string url1 = "https://cas.sdo.com:80/cas/login?service=http://zh.sdo.com/web1.0/home/select.asp";

            string postData = "warn=false&_eventId=submit&idtype=0&gamearea=0&gametype=0&challenge=5652&lt=" + lt +
                              "&username=" + this.textBox1.Text + "&password=" + this.textBox2.Text +
                              "&ekey=&challenge=5652";
            html = Http.GetHtml(url1, postData, aspcookie, out header); //login
            richTextBox1.AppendText(html);
            if (html.IndexOf("login2.asp") > 0)
            {
                MessageBox.Show("用户名或密码错误");
                return;
            }

            html =Http.GetHtml("https://cas.sdo.com:80/cas/login?service=zh011x01.sdo.com/index.php", aspcookie, out header);
            richTextBox1.AppendText(html);
            if (html.IndexOf("login2.asp") > 0)
            {
                MessageBox.Show("登录失败。请重试");
                return;
            }
        }
        private string Getlt(string html)
        {
            string str = html.Substring(html.IndexOf("?lt"));
            str = str.Substring(4);
            return str.Substring(0, str.IndexOf("&"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
          string  html = Http.GetHtml("https://cas.sdo.com:80/cas/login?service=zh011x01.sdo.com/index.php");
            richTextBox1.AppendText(html);
        }

    }
}
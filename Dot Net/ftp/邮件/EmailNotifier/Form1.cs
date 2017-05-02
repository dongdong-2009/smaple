using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace EmailNotifier
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox ServerAdd;
		private System.Windows.Forms.TextBox ServerPort;
		private System.Windows.Forms.TextBox Username;
		private System.Windows.Forms.TextBox Password;
		private System.Windows.Forms.TextBox TimeSpan;
		private NetworkStream netStream;		

		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			timer1.Interval=Int32.Parse(TimeSpan.Text);//设定时间间隔
			this.Hide();//使窗体不可见
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.ServerAdd = new System.Windows.Forms.TextBox();
			this.TimeSpan = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.Username = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.ServerPort = new System.Windows.Forms.TextBox();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.Password = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ServerAdd
			// 
			this.ServerAdd.Location = new System.Drawing.Point(152, 16);
			this.ServerAdd.Name = "ServerAdd";
			this.ServerAdd.Size = new System.Drawing.Size(136, 21);
			this.ServerAdd.TabIndex = 1;
			this.ServerAdd.Text = "";
			// 
			// TimeSpan
			// 
			this.TimeSpan.Location = new System.Drawing.Point(152, 136);
			this.TimeSpan.Name = "TimeSpan";
			this.TimeSpan.Size = new System.Drawing.Size(136, 21);
			this.TimeSpan.TabIndex = 5;
			this.TimeSpan.Text = "300000";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 106);
			this.label4.Name = "label4";
			this.label4.TabIndex = 0;
			this.label4.Text = "密码：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "时间间隔（毫秒）：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Username
			// 
			this.Username.Location = new System.Drawing.Point(152, 74);
			this.Username.Name = "Username";
			this.Username.Size = new System.Drawing.Size(136, 21);
			this.Username.TabIndex = 3;
			this.Username.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "邮件服务器地址：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 46);
			this.label2.Name = "label2";
			this.label2.TabIndex = 0;
			this.label2.Text = "服务器端口：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 76);
			this.label3.Name = "label3";
			this.label3.TabIndex = 0;
			this.label3.Text = "用户名：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem2,
																						 this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "配置参数";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "检查邮件";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "退出";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(136, 176);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 7;
			this.button1.Text = "隐藏";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(216, 176);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 24);
			this.button2.TabIndex = 6;
			this.button2.Text = "检查邮件";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// ServerPort
			// 
			this.ServerPort.Location = new System.Drawing.Point(152, 45);
			this.ServerPort.Name = "ServerPort";
			this.ServerPort.Size = new System.Drawing.Size(136, 21);
			this.ServerPort.TabIndex = 2;
			this.ServerPort.Text = "";
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenu = this.contextMenu1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "邮件检查程序";
			this.notifyIcon1.Visible = true;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Password
			// 
			this.Password.Location = new System.Drawing.Point(152, 103);
			this.Password.Name = "Password";
			this.Password.PasswordChar = '*';
			this.Password.Size = new System.Drawing.Size(136, 21);
			this.Password.TabIndex = 4;
			this.Password.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(330, 231);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button2,
																		  this.button1,
																		  this.TimeSpan,
																		  this.Password,
																		  this.Username,
																		  this.ServerPort,
																		  this.ServerAdd,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Form1";
			this.ShowInTaskbar = false;
			this.Text = "配置参数";
			this.ResumeLayout(false);

		}
		#endregion

        /// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void EmailCheck()
		{
			//新建一个TcpClient对象来建立连接
			TcpClient tcpClient = new TcpClient();

			try
			{
				tcpClient.Connect(ServerAdd.Text,Int32.Parse(ServerPort.Text));
			}
			catch
			{
				MessageBox.Show("不能连接到主机："+ServerAdd.Text+"和端口："+ServerPort.Text);
			}
			
			//从邮件服务器获得相应
			netStream = tcpClient.GetStream();
			if(netStream == null)
			{
				throw new Exception("获得的网络流为空值。");
			}

			string returnMsg=ReadFromNetStream(ref netStream);
			
			checkForError(returnMsg);

			//发送用户名信息
			WriteToNetStream(ref netStream, "USER " + this.Username.Text);

			returnMsg=ReadFromNetStream(ref netStream);
			checkForError(returnMsg);

			//发送密码信息
			WriteToNetStream(ref netStream, "PASS " + this.Password.Text);

			returnMsg=ReadFromNetStream(ref netStream);
			checkForError(returnMsg);
			
			Stat();

			netStream.Close();
			tcpClient.Close();		
		}

		/// <summary>
		/// 这个函数用来显示新邮件数信息
		/// </summary>
		public void Stat()
		{
			
			WriteToNetStream(ref netStream, "STAT");

			string returnMsg=ReadFromNetStream(ref netStream);
			checkForError(returnMsg);
			
			//将总邮件数和邮件大小分离
			string[] TotalStat= returnMsg.Split(new char[] {' '});
			
			int count =Int32.Parse(TotalStat[1]);
			int totalSize=Int32.Parse(TotalStat[2]);

			//调用精灵，告知用户新邮件数
			Form2 agent= new Form2(count);	
		}

		/// <summary>
		/// 这个函数用来向网络流写入数据
		/// </summary>
		/// <param name="NetStream"></param>
		/// <returns></returns>
		private void WriteToNetStream(ref NetworkStream NetStream, string Command)
		{
			string stringToSend = Command + "\r\n";

			Byte[] arrayToSend = Encoding.ASCII.GetBytes(stringToSend.ToCharArray());
			NetStream.Write(arrayToSend, 0, arrayToSend.Length);
		}

		/// <summary>
		/// 这个函数用来从网络流中读取数据
		/// </summary>
		/// <param name="NetStream"></param>
		/// <returns></returns>
		private String ReadFromNetStream(ref NetworkStream NetStream)
		{
			StringBuilder strReceived= new StringBuilder();
			StreamReader sr= new StreamReader(NetStream);
			String strLine = sr.ReadLine();

			while(strLine==null || strLine.Length==0)
			{
				strLine = sr.ReadLine();
			}
			strReceived.Append(strLine);

			if(sr.Peek()!=-1)
			{
				while ((strLine=sr.ReadLine())!=null) 
				{	
					strReceived.Append(strLine);
				}
			}
			return strReceived.ToString();
		}

		/// <summary>
		/// 这个函数用来检测网络流中的错误
		/// </summary>
		/// <param name="s"></param>
		private void checkForError(String strMessage)
		{
			if (strMessage.IndexOf("+OK") == -1)
				throw new Exception("ERROR - . Recieved: " + strMessage);
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			//this.Opacity=100;//使窗体可见
			this.Show();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.EmailCheck();//检查是否有新邮件
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.Close();//退出程序
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Opacity=0;//使窗体不可见
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.EmailCheck();//检查是否有新邮件
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.EmailCheck();//检查是否有新邮件
		}
	}
}

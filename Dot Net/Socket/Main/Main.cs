using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Main
{
    public partial class Main : Form
    {
        Socket s;
        public bool btnstatu = true;    //开始停止服务按钮状态                 
        public Thread myThread1;             //声明一个线程实例
        public Thread myThread2;             //声明一个线程实例
        bool m_Listening;
        delegate void AppendStringEventHandler(string s);
        private delegate void ProgressHandler(bool b);
        ProgressHandler updateHandler = null;
        string ActiveIP = string.Empty;
        Dictionary<string, Socket> dict = new Dictionary<string, Socket>();

        public Main()
        {
            InitializeComponent();
            updateHandler = new ProgressHandler(UpdateControl);
        }
        
        //监听函数                 
        public void Listen1(object o)                 
        {
            int port = (int)o;
            string host = "127.0.0.1";
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress IP = IPAddress.Parse(host);
            IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(host), port);
            try
            {
                
                //绑定                                
                s.Bind(EndPoint);
                //监听                                 
                s.Listen(100);
                //用于设置按钮状态                                 
                m_Listening = true;
                //开始接受连接，异步。                                 
                s.BeginAccept(new AsyncCallback(OnConnectRequest1), s);               
            }
            catch (Exception ex)
            {
                CloseSocket();
            }
        }


        private void Main_Load(object sender, EventArgs e)
        {
            ParameterizedThreadStart myThreadDelegate = new ParameterizedThreadStart(Listen1);
            myThread1 = new Thread(myThreadDelegate);
            myThread1.Start(8881);

            //myThread2 = new Thread(myThreadDelegate);
            //myThread2.Start(8882);        
        }


        public void OnConnectRequest1(IAsyncResult ar)
        {
            if (!m_Listening) return;

            //初始化一个SOCKET，用于其它客户端的连接
            Socket server1 = (Socket)ar.AsyncState;
            Socket Client = server1.EndAccept(ar);
            
            ActiveIP = Client.RemoteEndPoint.ToString();
            Invoke(updateHandler,true);
            if (!dict.Keys.Contains(ActiveIP))
            {
                dict.Add(ActiveIP, Client);
            }
            

            #region 客户端连接成功，返回成功标识。
            //将要发送给连接上来的客户端的提示字符串
            Byte[] byteDateLine = new byte[2048];
            byteDateLine = System.Text.Encoding.ASCII.GetBytes("@OK@");
            //将提示信息发送给客户端
            
            if (Client.Connected)
            {
                Client.Send(byteDateLine, byteDateLine.Length, 0);
            }
            #endregion          

            //等待新的客户端连接
            server1.BeginAccept(new AsyncCallback(OnConnectRequest1), server1);
            while (m_Listening)
            {       
                byteDateLine = new byte[2048];
                int recv = Client.Receive(byteDateLine);                    
                string stringdata = Encoding.ASCII.GetString(byteDateLine, 0, recv);
                if (stringdata == "XSTOPX")
                {
                    ActiveIP = Client.RemoteEndPoint.ToString();
                    Invoke(updateHandler, false);
                    Client.Disconnect(false);
                    break;                    
                }
                ActiveIP = Client.RemoteEndPoint.ToString();
                DisplayMessage(stringdata);
            }
        }

        void UpdateControl(bool IsAdd)
        {
            if (IsAdd) //添加Client
            {
                bool flag = false;
                foreach (var item in comboBox1.Items)
                {
                    if (item.ToString() == ActiveIP)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    comboBox1.Items.Add(ActiveIP);
                    DisplayMessage("New Client Connected!");
                }
            }
            else
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (comboBox1.Items[i].ToString() == ActiveIP)
                    {
                        comboBox1.Items.RemoveAt(i);
                        if (dict.Keys.Contains(ActiveIP))
                        {
                            dict.Remove(ActiveIP);
                        }
                        DisplayMessage("Client Disconnected!");
                        break;

                    }
                }
            }
            if (comboBox1.Text == string.Empty && comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }


        void DisplayMessage(string message)
        {
            if (message == string.Empty) return;
            try
            {
                //解决"从不是创建控件"xxxx"的线程访问它"的错误。
                if (txtget.InvokeRequired)
                {
                    AppendStringEventHandler AppendString = new AppendStringEventHandler(DisplayMessage);
                    txtget.Invoke(AppendString, message);
                }
                else
                {
                    txtget.AppendText("[" + ActiveIP + "]:" + message + Environment.NewLine);
                    txtget.ScrollToCaret();
                }
            }
            catch { }
        }

        private void CloseSocket()
        {
            m_Listening = false;
            if (myThread1 != null)
            {
                if (myThread1.ThreadState != ThreadState.Aborted && myThread1.ThreadState != ThreadState.Stopped)
                {
                    myThread1.Abort();
                }
            }

            if (s != null)
            {
                s.Close();
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Byte[] byteDateLine = new byte[10];
            byteDateLine = System.Text.Encoding.ASCII.GetBytes("XSTOPX");
            foreach (var c in dict)
            {
                //将提示信息发送给客户端
                c.Value.Send(byteDateLine, byteDateLine.Length, 0);
            }            

            CloseSocket();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == string.Empty) return;
            if (txtsend.Text == string.Empty) return;

            //Socket c = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(comboBox1.Text.Split(':')[0]), int.Parse(comboBox1.Text.Split(':')[1]));
            //c.Bind(EndPoint);
            //c.Connect(EndPoint);
            Socket c = dict[comboBox1.Text];
            Byte[] byteDateLine = new byte[2048];
            byteDateLine = System.Text.Encoding.ASCII.GetBytes(txtsend.Text);
            //将提示信息发送给客户端
            c.Send(byteDateLine, byteDateLine.Length, 0);
            txtsend.Text = string.Empty;
        }
    }
}

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



namespace Server1
{
    public partial class Server1 : Form
    {
        Socket Server;
        Socket local;
        bool m_Listening;
        public Thread myThread1;             //声明一个线程实例
        delegate void AppendStringEventHandler(string s);
        private delegate void ProgressHandler(bool b);
        ProgressHandler updateHandler = null;
        string ActiveIP = string.Empty;

        public Server1()
        {
            InitializeComponent();
        }

        private void Server1_Load(object sender, EventArgs e)
        {
            try
            {
                Socket socket1;
                IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 20000);
                socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket1.Bind(localEP);

                Socket socket2;

                socket2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket2.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                //请注意这一句。ReuseAddress选项设置为True将允许将套接字绑定到已在使用中的地址。 
                socket2.Bind(localEP);
            }
            catch (Exception ex) { }


            string host = "16.187.151.159";
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);            
            IPAddress IP = IPAddress.Parse(host);
            IPEndPoint RemoteEndPoint = new IPEndPoint(IP, 8881);
            //IPEndPoint EndPoint1 = new IPEndPoint(IP, 9991);
            //Server.Bind(EndPoint1);
            Server.Connect(RemoteEndPoint);//连接到服务器
            #region For Vista Connect
            //netsh interface ipv4 set interface "loopback" weakhostreceive=enabled
            //netsh interface ipv4 set interface "loopback" weakhostsend=enabled
	        #endregion

            EndPoint LocalEndPoint = Server.LocalEndPoint;
            if (Server.LocalEndPoint != null)
            {
                this.Text = LocalEndPoint.ToString();
            }
            m_Listening = true;
            ThreadStart myThreadDelegate = new ThreadStart(receive);
            myThread1 = new Thread(myThreadDelegate);
            myThread1.Start();
            
        }

        private void receive()
        {
            //DisplayMessage(m_Listening.ToString());
            if (!m_Listening) return;
            Byte[] byteDateLine;
            while (m_Listening)
            {
                byteDateLine = new byte[2048];

                int recv = Server.Receive(byteDateLine);
                string stringdata = Encoding.ASCII.GetString(byteDateLine, 0, recv);
                
                switch (stringdata)
                {
                    case "@OK@":
                        {
                            ActiveIP = Server.LocalEndPoint.ToString();
                            DisplayMessage("Connect Successful！");
                            break;
                        }
                    case "XSTOPX":
                        {
                            ActiveIP = "Server";
                            m_Listening = false;
                            DisplayMessage("Disconnect！");
                            //Server.Disconnect(false);
                            break;
                        }
                    default:
                        {
                            ActiveIP = "Server";
                            DisplayMessage(stringdata);
                            break;
                        }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtsend.Text == string.Empty) return;
            if (!Server.Connected) return;


            byte[] b = Encoding.ASCII.GetBytes(txtsend.Text);
            Server.Send(b, b.Length, 0);//发送测试信息
            txtsend.Text = string.Empty;
        }

        private void Server1_FormClosed(object sender, FormClosedEventArgs e)
        {
            byte[] b = Encoding.ASCII.GetBytes("XSTOPX");
            try
            {
                if (m_Listening)
                {
                    Server.Send(b, b.Length, 0);//发送测试信息
                }
            }
            finally 
            {
                CloseSocket();
            }
        }

        //监听函数                 
        //public void Listen()
        //{
        //    m_Listening = true;
        //    local = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    EndPoint LocalEndPoint = Server.LocalEndPoint;
        //    try
        //    {
        //        绑定                                
        //        local.Bind(LocalEndPoint);
        //        监听                                 
        //        local.Listen(0);
        //        用于设置按钮状态                                 
        //        m_Listening = true;
        //        开始接受连接，异步。                                 
        //        local.BeginAccept(new AsyncCallback(OnConnectRequest1), local);
        //    }
        //    catch (Exception ex)
        //    {
        //        CloseSocket();
        //    }
        //}

        public void OnConnectRequest1(IAsyncResult ar)
        {
            if (!m_Listening) return;

            //初始化一个SOCKET，用于其它客户端的连接
            Socket server1 = (Socket)ar.AsyncState;
            Socket Client = server1.EndAccept(ar);

            Byte[] byteDateLine = new byte[2048];
      
            //等待新的客户端连接
            server1.BeginAccept(new AsyncCallback(OnConnectRequest1), server1);
            while (m_Listening)
            {
                byteDateLine = new byte[2048];
                int recv = Client.Receive(byteDateLine);
                string stringdata = Encoding.ASCII.GetString(byteDateLine, 0, recv);
                if (stringdata == "XSTOPX")
                {
                    break;
                }
            }
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

            if (local != null)
            {
                local.Close();
            }

            if (Server != null)
            {
                Server.Close();
            }
        }

        void DisplayMessage(string message)
        {
            if (message == string.Empty) return;

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
    }
}

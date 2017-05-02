using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace receive
{
    /// <summary>
    /// 定义委托的方法
    /// </summary>
    public delegate void StartServiceDelegate();


    public class SynService
    {
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        private IPAddress m_ServerIP;

        /// <summary>
        /// 侦听端口号
        /// </summary>
        private int m_ServerPort;

        public int ServerPort
        {
            get { return m_ServerPort; }
            set { m_ServerPort = value; }
        }
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        /// <summary>
        /// 网络侦听器
        /// </summary>
        private TcpListener m_Listener;

        /// <summary>
        /// 文件所在路径
        /// </summary>
      //  private string m_Path = @"D:";
        private string m_Path = "";
        /// <summary>
        /// 服务是否已经停止(默认为停止)
        /// </summary>
        private bool m_bStop = true;


        /// <summary>
        /// 获取或设置服务是否已经停止
        /// </summary>
        public bool IsStop
        {
            set
            {
                lock (this)
                {
                    this.m_bStop = value;
                }
            }
            get
            {
                lock (this)
                {
                    return this.m_bStop;
                }
            }
        }// end bool


        public SynService(int port)
        {

            this.m_ServerIP = Dns.Resolve(Dns.GetHostName()).AddressList[0];
            this.m_ServerPort = port;
        }// end public

        /// <summary>
        /// 启动服务
        /// </summary>
        public void StartService()
        {
            try
            {

                m_Listener = new TcpListener(this.m_ServerIP, this.m_ServerPort);
                Service ser = new Service(this.m_Listener, this.m_Path, this);
                StartServiceDelegate startser = new StartServiceDelegate(ser.DelegateStartServer);
                startser.BeginInvoke(null, null);
            }// try
       
            catch 
            {
       
            }// catch
        }// end void

        /// <summary>
        /// 停止服务
        /// </summary>
        public void StopService()
        {
            try
            {
                if (IsStop == false)
                {
                    this.m_Listener.Stop();
                    IsStop = true;
                }// end if	
            }
            catch
            {
     
            }
        }// end void


    }// end class


    /// <summary>
    /// 服务管理
    /// </summary>
    public class Service
    {
        /// <summary>
        /// 网络侦听器
        /// </summary>
        private TcpListener m_Listener;

        /// <summary>
        /// 文件保存路径
        /// </summary>
        private string m_Path;

        private SynService m_SynService;



        public Service(TcpListener listener, string Patch, SynService synService)
        {
            this.m_Listener = listener;
            this.m_Path = Patch;
            this.m_SynService = synService;
        }// end public

        public void DelegateStartServer()
        {
            try
            {
                //开始侦听客户端连接
                this.m_Listener.Start();
                //服务已经开始
                this.m_SynService.IsStop = false;
                while (!this.m_SynService.IsStop)
                {
                    //接收客户端发送的请求
                    // 一般必须限制最大连接数
                    // Thread[10] 最多允许10个人同时连接,这里不限制最大连接数
                    Socket socket = this.m_Listener.AcceptSocket();
                    SendData receive = new SendData(socket, this.m_Path);
                    Thread thread = new Thread(new ThreadStart(receive.WorkStart));
                    thread.IsBackground = true;
                    thread.Start();
                }// end while              
            }// try
            catch 
            {

            }// end catch
        }// end void


    }// end class

    public class SendData
    {
        private string path = "G:\\teste\\";
        /// <summary>
        /// 客户端连接
        /// </summary>
        private Socket m_socket;

        /// <summary>
        /// 服务器配置文件夹
        /// </summary>
        private string m_Path;


        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="socket"></param>
        public SendData(Socket socket, string path)
        {
            this.m_socket = socket;
            this.m_Path = path;
        }// end void

        /// <summary>
        /// 开始工作
        /// </summary>
        public void WorkStart()
        {
            try
            {
                CreateFielInfo();
            }// end try
            catch { }
            finally
            {
                this.m_socket.Shutdown(SocketShutdown.Both);
                this.m_socket.Close();
                this.m_socket = null;
            }// end finally
        }// end void


        /// <summary>
        /// 准备要发送的文件（准备工作，获取文件名，文件大小 ）
        /// </summary>
        private void CreateFielInfo()
        {
            try
            {
                string filename = null;

                if (this.m_socket.Connected)
                {
                    //设置文件信息缓冲区(格式：|文件名|),编码为UTF8);
                    byte[] byteFile = new byte[1024];
                    //获取客户端请求的文件
                   int lenddd = this.m_socket.Receive(byteFile, 0, byteFile.Length, SocketFlags.None);
                    string file = System.Text.Encoding.UTF8.GetString(byteFile);
                    string[] array = file.Split(new char[] { '|' });
                    //请求的文件名
                    filename = array[1];
                    int size = Int32.Parse(array[2]);
                    long offset = 0;

                    using (FileStream ms = new FileStream(path + filename,FileMode.Create))
                    {
                        while (offset < size)
                        {
                            ///创建文件缓冲区（大小为1KB ）
                            byte[] buf = new byte[1024];
                            int len = this.m_socket.Receive(buf, 0, buf.Length, SocketFlags.None);
                            if (offset + (long)(len) > size)
                            {
                                ms.Write(buf, 0, ((int)(size - offset)));
                                offset = ms.Length;
                            }// end if
                            else
                            {
                                ms.Write(buf, 0, len);
                            }// end if
                            ms.Flush();
                            offset += (long)len;
                            ms.Seek(offset, System.IO.SeekOrigin.Begin);
                        }// end while
                    }




                }// end if
            }// try
            catch { }
        }// end void



    }// end class

}// end namespace

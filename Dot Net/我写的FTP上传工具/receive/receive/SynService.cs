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
    /// ����ί�еķ���
    /// </summary>
    public delegate void StartServiceDelegate();


    public class SynService
    {
        /// <summary>
        /// ������IP��ַ
        /// </summary>
        private IPAddress m_ServerIP;

        /// <summary>
        /// �����˿ں�
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
        /// ����������
        /// </summary>
        private TcpListener m_Listener;

        /// <summary>
        /// �ļ�����·��
        /// </summary>
      //  private string m_Path = @"D:";
        private string m_Path = "";
        /// <summary>
        /// �����Ƿ��Ѿ�ֹͣ(Ĭ��Ϊֹͣ)
        /// </summary>
        private bool m_bStop = true;


        /// <summary>
        /// ��ȡ�����÷����Ƿ��Ѿ�ֹͣ
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
        /// ��������
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
        /// ֹͣ����
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
    /// �������
    /// </summary>
    public class Service
    {
        /// <summary>
        /// ����������
        /// </summary>
        private TcpListener m_Listener;

        /// <summary>
        /// �ļ�����·��
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
                //��ʼ�����ͻ�������
                this.m_Listener.Start();
                //�����Ѿ���ʼ
                this.m_SynService.IsStop = false;
                while (!this.m_SynService.IsStop)
                {
                    //���տͻ��˷��͵�����
                    // һ������������������
                    // Thread[10] �������10����ͬʱ����,���ﲻ�������������
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
        /// �ͻ�������
        /// </summary>
        private Socket m_socket;

        /// <summary>
        /// �����������ļ���
        /// </summary>
        private string m_Path;


        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="socket"></param>
        public SendData(Socket socket, string path)
        {
            this.m_socket = socket;
            this.m_Path = path;
        }// end void

        /// <summary>
        /// ��ʼ����
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
        /// ׼��Ҫ���͵��ļ���׼����������ȡ�ļ������ļ���С ��
        /// </summary>
        private void CreateFielInfo()
        {
            try
            {
                string filename = null;

                if (this.m_socket.Connected)
                {
                    //�����ļ���Ϣ������(��ʽ��|�ļ���|),����ΪUTF8);
                    byte[] byteFile = new byte[1024];
                    //��ȡ�ͻ���������ļ�
                   int lenddd = this.m_socket.Receive(byteFile, 0, byteFile.Length, SocketFlags.None);
                    string file = System.Text.Encoding.UTF8.GetString(byteFile);
                    string[] array = file.Split(new char[] { '|' });
                    //������ļ���
                    filename = array[1];
                    int size = Int32.Parse(array[2]);
                    long offset = 0;

                    using (FileStream ms = new FileStream(path + filename,FileMode.Create))
                    {
                        while (offset < size)
                        {
                            ///�����ļ�����������СΪ1KB ��
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

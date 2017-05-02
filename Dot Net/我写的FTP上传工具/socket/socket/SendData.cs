using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace socket
{
  public  class SendData
    {
        private string filepath;

        public string Filepath
        {
            get { return filepath; }
            set { filepath = value; }
        }
      public void Send()
      {

          SendFile();
      
      }
      private string ip;

      public string Ip
      {
          get { return ip; }
          set { ip = value; }
      }
      private int port;

      public int Port
      {
          get { return port; }
          set { port = value; }
      }
      byte[] msg;
      private void SendFile()
      {
          
              //�Ѿ����͵��ļ���С
              long offset = 0;
              byte[] msg = new byte[1024];
              //����ļ��Ƿ��
              if (System.IO.File.Exists(filepath))
              {
                  IPEndPoint IP = new IPEndPoint(IPAddress.Parse(ip), port);
                  using (Socket socket = new Socket(IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                  {
                      if (!socket.Connected)
                      {
                          socket.Connect(IP);
                      }// end if
                      //��������ļ�

                      using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
                      {
                      
                        byte[]   bytMsg = UTF8Encoding.UTF8.GetBytes("|"+filepath.Substring(filepath.LastIndexOf("\\")+1)+"|" + fs.Length.ToString() + "|");
                        bytMsg.CopyTo(msg, 0);
                          
                          //��ͻ��˷�����Ϣ,֪ͨ�ͻ���׼�������ļ�,�����ļ���С֪ͨ�ͻ���
                           socket.Send(msg, 0, msg.Length, SocketFlags.None);

                          while (offset < fs.Length)
                          {
                              //�����ļ���������С
                              byte[] buf = new byte[1024];
                              fs.Read(buf, 0, buf.Length);
                              int sendlen = socket.Send(buf, 0, buf.Length, SocketFlags.None);
                              offset += sendlen;
                              fs.Seek((long)offset, System.IO.SeekOrigin.Begin);
                          }// end while
                          fs.Close();
                      }// end using 

   
              socket.Shutdown(SocketShutdown.Both);
              socket.Close();
          
        
                  }
                 
              }// end if
          
        
         
        
      }
    }
}

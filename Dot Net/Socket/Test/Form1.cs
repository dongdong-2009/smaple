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

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Socket Listener;
        private void Form1_Load(object sender, EventArgs e)
        {

            Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            IPEndPoint hostEntry = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);

            Listener.Bind(hostEntry);

            Listener.Listen(0);


            SocketAsyncEventArgs socketEventArg = new SocketAsyncEventArgs();

            socketEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(socketEventArg_Completed);

            socketEventArg.RemoteEndPoint = hostEntry;

            socketEventArg.UserToken = Listener;

            Listener.AcceptAsync(socketEventArg);
        }

        void socketEventArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.LastOperation == SocketAsyncOperation.Accept)
            {

                Socket acceptSocket = e.AcceptSocket;



                if (acceptSocket != null)
                {

                    // 处理方法

                }

            }



            e.AcceptSocket = null;

            Listener.AcceptAsync(e);
        }
    }
}

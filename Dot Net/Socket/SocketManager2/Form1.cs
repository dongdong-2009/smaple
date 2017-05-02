using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISocket;
using Simulation1;
using System.Net;
using System.Reflection;

namespace SocketManager2
{
    public partial class Form1 : Form
    {
        IOneWaySocket2 a = new OneWaySocket2();
        IOneWaySocket2 b = new OneWaySocket2();
        IOneWaySocket2 c = new OneWaySocket2();
        public delegate void SetCallBack(string str);
        public delegate void SetCallBack2(string str,Label l);
        public SetCallBack setlistboxcallback;
        public SetCallBack2 setlabcallback;
        public Form1()
        {
            InitializeComponent();
            setlistboxcallback = setLB;
            setlabcallback = setLab;
            a = new OneWaySocket2();
            b = new OneWaySocket2();
            a.OnMessageReceived += new EventHandler(s_OnMessageReceived);
            b.OnMessageReceived += new EventHandler(s_OnMessageReceived);
            c.OnMessageReceived += new EventHandler(s_OnMessageReceived);
            a.OnConnected += new EventHandler(s_OnConnected);
            b.OnConnected += new EventHandler(s_OnConnected);
            c.OnConnected += new EventHandler(s_OnConnected);
            a.OnStopped += new EventHandler(s_OnStopped);
            b.OnStopped += new EventHandler(s_OnStopped);
            c.OnStopped += new EventHandler(s_OnStopped);
            a.Name = "发卡仿真";
            b.Name = "受理仿真";
            c.Name = "清算仿真";
        }

        void s_OnConnected(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init(ref a,button1.Text);
        }

        private void Init(ref IOneWaySocket2 s,string name)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = @"D:\360云盘\Project\smaple\Dot Net\Socket\OneWaySocket\bin\Debug";
            DialogResult dr = fd.ShowDialog();
            if (dr.ToString() == "OK")
            {
                s = (IOneWaySocket2)Assembly.LoadFrom(fd.FileName).CreateInstance("Simulation1.OneWaySocket2", true);
                s.OnMessageReceived += new EventHandler(s_OnMessageReceived);
                s.OnStopped += new EventHandler(s_OnStopped);
                s.OnStopped += new EventHandler(s_OnStopped);
                s.Name = name;
                setLB(name +"加载成功!");
            }            
        }

        void s_OnStopped(object sender, EventArgs e)
        {
            string name = ((IOneWaySocket2)sender).Name;
            switch (name)
            {
                case "发卡仿真":
                    {
                        setlabcallback("停止",msg1);
                        break;
                    }
                case "受理仿真":
                    {
                        setlabcallback("停止", msg2);
                        break;
                    }
                case "清算仿真":
                    {
                        setlabcallback("停止", msg3);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Init(ref b,button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Init(ref c, button3.Text);
        }

        private void btnOn1_Click(object sender, EventArgs e)
        {
            connect(a, txtOut1.Text,txtIn1.Text,msg1);
        }
      
        private void setLB(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;
            if (lbMsg.InvokeRequired)
            {
                lbMsg.Invoke(setlistboxcallback, msg);
            }
            else
            {
                lbMsg.Items.Insert(0, msg); 
            }
        }

        private void setLab(string msg,Label l)
        {
            if (string.IsNullOrEmpty(msg)) return;
            if (l.InvokeRequired)
            {
                l.Invoke(setlabcallback, msg,l);
            }
            else
            {
                l.Text = msg;
            }
        }


        private void btnListen1_Click(object sender, EventArgs e)
        {
            listen(a, txtIn1.Text,msg1);
        }

        private void btnSend1_Click(object sender, EventArgs e)
        {
            send(a,txtSend1.Text);
        }

        private void btnListen2_Click(object sender, EventArgs e)
        {
            listen(b, txtIn2.Text,msg2);
        }

        private void btnOn2_Click(object sender, EventArgs e)
        {
            connect(b, txtOut2.Text,txtIn2.Text,msg2);
        }

        private void btnOff2_Click(object sender, EventArgs e)
        {
            stop(b,msg2);
        }

        private void listen(IOneWaySocket2 s,string t,Label l)
        {
            if (s == null)
            {
                setLB("组件未加载!");
                return;
            }

            if (s.ListenState)
            {
                setLB("Already Listen!"); return;
            }
            if (s.ConnectState)
            {
                setLB("ConnectState Can't Listen!"); return;
            }

            try
            {
                s.InputIP = t.Split(':')[0];
                s.InputPort = t.Split(':')[1];
                s.Listen();
                l.Text = "监听";
                setLB(s.Message);
            }
            catch { setLB(s.Message); }
        }

        void s_OnMessageReceived(object sender, EventArgs e)
        {
            setLB(((IOneWaySocket2)sender).Message);
        }

        private void connect(IOneWaySocket2 s, string sout,string sin,Label l)
        {
            if (s == null)
            {
                setLB("组件未加载!");
                return;
            }


            if (s.ListenState)
            {
                setLB("ListenState Can't Connect!"); return;
            }
            if (s.ConnectState)
            {
                setLB("Already Connected!"); return;
            }
            try
            {
                s.OutIP = sout.Split(':')[0];
                s.OutPort = sout.Split(':')[1];
                s.InputIP = sin.Split(':')[0];
                s.InputPort = sin.Split(':')[1];
                s.Connect();
                l.Text = "连接";
                setLB(s.Message);
            }
            catch { setLB(s.Message); }
        }


        private void send(IOneWaySocket2 s,string msg)
        {
            if (s == null)
            {
                setLB("组件未加载!");
                return;
            }


            if (s.Remote == null && s.pool.Count == 0)
            {
                setLB("Can't Send When Disconnect!");
                return;
            }

            s.Send(msg);
            if (s.Message != "OK")
            {
                setLB(s.Message);
            }
        }

        private void btnSend2_Click(object sender, EventArgs e)
        {
            send(b,txtSend2.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (a != null)
                {
                    a.Stop();
                }
                if (b != null)
                {
                    b.Stop();
                }
            }
            finally
            {
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPAddress[] addressList = Dns.GetHostEntry(Environment.MachineName).AddressList;
            string IP = addressList[addressList.Length - 1].ToString();
            txtIn1.Text = IP + ":8881";
            txtOut1.Text = IP + ":9991";

            txtOut2.Text = IP + ":8881";
            txtIn2.Text = IP + ":9991";
        }

        private void btnOff1_Click(object sender, EventArgs e)
        {
            stop(a,msg1);
        }

        void stop(IOneWaySocket2 s,Label l)
        {
            if (s == null)
            {
                setLB("组件未加载!");
                return;
            }


            if (s == null)
            {
                return;
            }
            if (s.ListenState || s.ConnectState)
            {
                s.Stop();
                l.Text = "停止";
            }
            else
            {
                setLB("Already Stopped!");
            }
        }

        private void btnListen3_Click(object sender, EventArgs e)
        {
            listen(c, txtIn3.Text, msg3);
        }

        private void btnOn3_Click(object sender, EventArgs e)
        {
            connect(c, txtOut3.Text, txtIn3.Text, msg3);
        }

        private void btnOff3_Click(object sender, EventArgs e)
        {
            stop(c, msg3);
        }

        private void btnSend3_Click(object sender, EventArgs e)
        {
            send(c, txtSend3.Text);
        }
    }
}

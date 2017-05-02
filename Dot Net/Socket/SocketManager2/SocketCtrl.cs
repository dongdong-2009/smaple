using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISocket;
using System.Reflection;

namespace SocketManager2
{
    public partial class SocketCtrl : UserControl
    {
        IOneWaySocket2 s;
        public delegate void SetCallBack(string str);
        public SetCallBack setlistboxcallback;
        public SetCallBack setlabcallback;
        public string ButtonName
        {
            get
            {
                return button1.Text;
            }
            set
            {
                button1.Text = value;
            }
        }

        public string listenip 
        {
            get
            {
                return txtIn1.Text;
            }
            set
            {
                txtIn1.Text = value;
            }
        }

        public string connectip
        {
            get
            {
                return txtOut1.Text;
            }
            set
            {
                txtOut1.Text = value;
            }
        }

        public ListBox lbMsg { get; set; }

        public string path { get; set; }

        public SocketCtrl()
        {
            InitializeComponent();
            setlistboxcallback = setLB;
            setlabcallback = setLab;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = @"e:\360云盘\Project\smaple\Dot Net\Socket\OneWaySocket\bin\Debug";
            DialogResult dr = fd.ShowDialog();
            if (dr.ToString() == "OK")
            {
                s = (IOneWaySocket2)Assembly.LoadFrom(fd.FileName).CreateInstance("Simulation1.OneWaySocket2", true);
                s.OnMessageReceived += new EventHandler(s_OnMessageReceived);
                s.OnStopped += new EventHandler(s_OnStopped);
                s.OnStopped += new EventHandler(s_OnStopped);

                setLB(button1.Text + "加载成功!");
            }            
        }

        public void load()
        {
            s = (IOneWaySocket2)Assembly.LoadFrom(path).CreateInstance("Simulation1.OneWaySocket2", true);
            s.OnMessageReceived += new EventHandler(s_OnMessageReceived);
            s.OnStopped += new EventHandler(s_OnStopped);
            s.OnStopped += new EventHandler(s_OnStopped);

            setLB(button1.Text + "加载成功!");
        }

        void s_OnConnected(object sender, EventArgs e)
        {

        }

        void s_OnStopped(object sender, EventArgs e)
        {
            string name = ((IOneWaySocket2)sender).Name;
            setlabcallback("停止");
        }

        private void setLB(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;
            try
            {
                if (lbMsg.InvokeRequired)
                {
                    lbMsg.Invoke(setlistboxcallback, msg);
                }
                else
                {
                    lbMsg.Items.Insert(0, msg);
                }
            }
            catch (Exception ex) { }
        }

        private void setLab(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;
            if (msg1.InvokeRequired)
            {
                msg1.Invoke(setlabcallback, msg, msg1);
            }
            else
            {
                msg1.Text = msg;
            }
        }

        void s_OnMessageReceived(object sender, EventArgs e)
        {
            setLB(((IOneWaySocket2)sender).Message);
        }

        private void btnListen1_Click(object sender, EventArgs e)
        {
            listen(txtIn1.Text);
        }

        private void listen(string t)
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
                msg1.Text = "监听";
                setLB(s.Message);
            }
            catch { setLB(s.Message); }
        }

        private void btnOn1_Click(object sender, EventArgs e)
        {
            connect(txtOut1.Text, txtIn1.Text);
        }

        private void connect(string sout, string sin)
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
                msg1.Text = "连接";
                setLB(s.Message);
            }
            catch { setLB(s.Message); msg1.Text = "停止"; }
        }

        private void btnOff1_Click(object sender, EventArgs e)
        {
            stop();
        }

        void stop()
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
                msg1.Text = "停止";
            }
            else
            {
                setLB("Already Stopped!");
            }
        }

        private void btnSend1_Click(object sender, EventArgs e)
        {
            send(txtSend1.Text);
        }

        private void send(string msg)
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
    }
}

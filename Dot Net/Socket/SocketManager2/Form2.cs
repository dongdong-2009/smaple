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
    public partial class Form2 : Form
    {
        public string ip;
        public int x = 225;

        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {              
            IPAddress[] addressList = Dns.GetHostEntry(Environment.MachineName).AddressList;
            ip = addressList[0].ToString();
            socketCtrl1.listenip = ip+":8881";
            socketCtrl1.connectip = ip + ":9991";
            socketCtrl1.lbMsg = lbMsg;          

            socketCtrl2.listenip = ip + ":9991";
            socketCtrl2.connectip = ip + ":8881";
            socketCtrl2.lbMsg = lbMsg;
            socketCtrl2.ButtonName = "受理仿真";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            modeldialog md = new modeldialog();
            DialogResult dr =   md.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                SocketCtrl sc = new SocketCtrl();
                sc.lbMsg = lbMsg;
                sc.ButtonName = md.modelname;
                sc.listenip = md.listenip;
                sc.connectip = md.connectip;
                sc.path = md.path;
                sc.Location = new Point(x + 213, 31);
                x = x + 213;
                sc.load();
                this.Controls.Add(sc);
                
            }
        }
    }
}

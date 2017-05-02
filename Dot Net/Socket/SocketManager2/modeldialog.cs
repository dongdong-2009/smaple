using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SocketManager2
{
    public partial class modeldialog : Form
    {
        public string modelname
        {
            get
            {
                return textBox1.Text.Trim();
            }
        }

        public string listenip
        {
            get
            {
                return textBox2.Text.Trim();
            }
        }


        public string connectip
        {
            get
            {
                return textBox3.Text.Trim();
            }
        }

        public string path
        {
            get
            {
                return textBox4.Text.Trim();
            }
        }

        public modeldialog()
        {
            InitializeComponent();
        }

        private void modeldialog_Load(object sender, EventArgs e)
        {
            string ip = ((Form2)this.Owner).ip;
            textBox2.Text = ip+":9992";
            textBox3.Text = ip+":8881";

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("模块名不能为空!");
                return;
            }

            if (textBox4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("路径不能为空!");
                return;
            }
            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = @"e:\360云盘\Project\smaple\Dot Net\Socket\OneWaySocket\bin\Debug";
            DialogResult dr = fd.ShowDialog();
            if (dr.ToString() == "OK")
            {
                textBox4.Text = fd.FileName;
            }           
        }
    }
}

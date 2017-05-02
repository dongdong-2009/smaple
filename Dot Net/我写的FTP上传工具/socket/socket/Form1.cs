using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace socket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (ListViewItem item in listView1.Items)
            {
                SendData Send = new SendData();
                Send.Filepath = item.Tag.ToString();
                Send.Ip = textBox1.Text;
                Send.Port = Int32.Parse(textBox2.Text);
                Send.Send();
            }

          
        }

    

     

        private void listView1_DragDrop_1(object sender, DragEventArgs e)
        {
            object obj = e.Data.GetData(DataFormats.FileDrop);
            string strFileName = ((string[])obj)[0].ToString();
            ListViewItem item = new ListViewItem();
            item.Text = strFileName;
            item.Tag = strFileName;
            listView1.Items.Add(item);
        }

        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(e.Item, DragDropEffects.All);
        }

     

     
       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace SerializationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SumOf sObj;
        private void button1_Click(object sender, EventArgs e)
        {
            // create a file stream to write the file
            FileStream fileStream = new FileStream("DoSum.bin", FileMode.Create);
            // use the CLR binary formatter
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            // serialize to disk
            binaryFormatter.Serialize(fileStream, sObj);
            fileStream.Close();

        }
        private SumOf BuildSumObj()
        {
            SumOf sObj = new SumOf();
            for (int i = 0; i < this.numericUpDown1.Value; i++)
            {
                sObj.Members.Add(i);
            }
            sObj.Calculate();
            return sObj;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // create a file stream to write the file
            FileStream fileStream = new FileStream("DoSum_Soap.xml", FileMode.Create);
            // use the CLR binary formatter
            SoapFormatter formatter = new SoapFormatter();
            // serialize to disk
            formatter.Serialize(fileStream, sObj);
            fileStream.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sObj = this.BuildSumObj();
            this.toolStripStatusLabel1.Text =
                string.Format("数量：{0}，合计：{1}，平均值：{2}", sObj.Members.Count, sObj.Sum, sObj.Avg);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // create a file stream to write the file
            FileStream fileStream = new FileStream("DoSum.xml", FileMode.Create);
            // use the CLR binary formatter
            System.Xml.Serialization.XmlSerializer
                formatter = new XmlSerializer(typeof(SumOf));
            // serialize to disk
            formatter.Serialize(fileStream, sObj);
            fileStream.Close();
        }
    }
}
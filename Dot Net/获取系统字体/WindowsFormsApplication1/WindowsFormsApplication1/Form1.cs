using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
//Download by http://www.codefans.net
namespace 获取计算机中已安装的字体
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getfont();
        }

        private void getfont()
        {
            InstalledFontCollection myFonts = new InstalledFontCollection();
            StringBuilder s = new StringBuilder();
            foreach (FontFamily family in myFonts.Families)
            {
                richTextBox1.AppendText(family.Name + System.Environment.NewLine);
                s.Append(family.Name);
                s.Append(System.Environment.NewLine);
            }
            richTextBox1.AppendText(myFonts.Families.Length.ToString());
            s.AppendLine(myFonts.Families.Length.ToString());
            WriteFile("font.txt", s.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getfont();

        }

        public void WriteFile(string file, string fileContent)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }

            FileInfo info = new FileInfo(file);
            if (!Directory.Exists(info.DirectoryName))
            {
                Directory.CreateDirectory(info.DirectoryName);
            }
            FileStream stream = new FileStream(file, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
            try
            {
                writer.WriteLine(fileContent);
            }
            catch (Exception exception)
            {
                throw new FileNotFoundException(exception.ToString());
            }
            finally
            {
                writer.Flush();
                stream.Flush();
                writer.Close();
                stream.Close();
            }
        }
    }
}

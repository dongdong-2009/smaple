using System;
using System.Collections.Generic;
using System.Windows.Forms;
//Download by http://www.codefans.net
namespace 获取计算机中已安装的字体
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

/****************************************
 * 周铭
 * 2007-07-04
 * XmlOperate.cs * 
 * 最后修改时间：2007-07-09
 * **************************************/

using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace ShortCutMenu
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex mutex = new Mutex(false, "ShortCutMenu");
            bool Running = !mutex.WaitOne(0, false);
            if (!Running)
            {                
                Application.EnableVisualStyles();                
                Application.SetCompatibleTextRenderingDefault(false);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(AppThreadException);
                Application.Run(new frm());
            }
        }

        #region 捕获未处理异常
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string errorMsg = string.Format("未处理异常: \n{0}\n",e.ExceptionObject.GetType().ToString());
            errorMsg += Environment.NewLine;

            DialogResult result = MessageBox.Show(errorMsg, "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);

            //如果点击“中止”则退出程序
            if (result == DialogResult.Abort)
            {
                Application.Exit();
            }
        }

        private static void AppThreadException(object source, System.Threading.ThreadExceptionEventArgs e)
        {
            string errorMsg = string.Format("未处理异常: \n{0}\n", e.Exception.Message);
            errorMsg += Environment.NewLine;

            DialogResult result = MessageBox.Show(errorMsg, "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);

            //如果点击“中止”则退出程序
            if (result == DialogResult.Abort)
            {
                Application.Exit();                
            }
        }
        #endregion
    }
}
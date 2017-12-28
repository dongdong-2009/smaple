using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ShortCutMenu
{
    class utility
    {
        private const string STR_Reg = "ZHOUMING";
        public static string getFileName(string fullName)
        {
            string str_FileName = fullName.ToLower().Trim();
            str_FileName = fullName.Substring(fullName.LastIndexOf("\\") + 1);
            str_FileName = str_FileName.Replace(".exe", "");
            return str_FileName;
        }

        public static bool IsApplication(string path)
        {
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
            string fileclass = "";
            byte buffer;
            buffer = r.ReadByte();
            fileclass = buffer.ToString();
            buffer = r.ReadByte();
            fileclass += buffer.ToString();
            r.Close();
            fs.Close();
            if (fileclass == "7790")//说明255216是jpg;7173是gif;6677是BMP,13780是PNG;7790是exe,8297是rar
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 检查注册表项是否存在
        public static bool ifExsistKey()
        {
            Object o = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("Run").GetValue(STR_Reg);
            if (o == null)
            {
                return false;
            }
            else
            {
                string s = o.ToString();
                string appName = "\"" + Application.ExecutablePath + "\"";
                if (s == appName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region 生成注册表项
        private static RegistryKey GenerateRegKey()
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE").CreateSubKey("Microsoft").CreateSubKey("Windows").CreateSubKey("CurrentVersion").CreateSubKey("Run");
            return key;
        }
        #endregion

        #region 设置开机自动运行
        public static void autoRun()
        {
            string appName = "\"" + Application.ExecutablePath + "\"";
            RegistryKey key = utility.GenerateRegKey();
            key.SetValue(STR_Reg, appName);
        }
        #endregion

        #region 取消开机自动运行
        public static void DelAutoRun()
        {
            RegistryKey key = utility.GenerateRegKey();
            key.DeleteValue(STR_Reg, false);
        }
        #endregion
    }
}

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
            if (fileclass == "7790")//˵��255216��jpg;7173��gif;6677��BMP,13780��PNG;7790��exe,8297��rar
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region ���ע������Ƿ����
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

        #region ����ע�����
        private static RegistryKey GenerateRegKey()
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE").CreateSubKey("Microsoft").CreateSubKey("Windows").CreateSubKey("CurrentVersion").CreateSubKey("Run");
            return key;
        }
        #endregion

        #region ���ÿ����Զ�����
        public static void autoRun()
        {
            string appName = "\"" + Application.ExecutablePath + "\"";
            RegistryKey key = utility.GenerateRegKey();
            key.SetValue(STR_Reg, appName);
        }
        #endregion

        #region ȡ�������Զ�����
        public static void DelAutoRun()
        {
            RegistryKey key = utility.GenerateRegKey();
            key.DeleteValue(STR_Reg, false);
        }
        #endregion
    }
}

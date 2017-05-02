using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Hubei.Blackant
{
    /// <summary>
    /// ���õļ���/���ܷ���
    /// </summary>
    public class MySecurity
    {
        private static byte[] DESKey = Encoding.ASCII.GetBytes("blackant");
        private static byte[] DESIV = Encoding.ASCII.GetBytes("DUDUBLOG");

        /// <summary>
        /// DES����
        /// </summary>
        /// <param name="strSource">�������ִ�</param>
        /// <returns>���ܺ���ַ���</returns>
        public string DESEncrypt(string strSource)
        {
            DES mCSP = new DESCryptoServiceProvider();
            ICryptoTransform ct = mCSP.CreateEncryptor(DESKey, DESIV);
            byte[] byt = Encoding.Unicode.GetBytes(strSource);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }
        /// <summary>
        /// DES����
        /// </summary>
        /// <param name="strSource">�����ܵ��ִ�</param>
        /// <returns>���ܺ���ַ���</returns>
        public string DESDecrypt(string strSource)
        {
            DES mCSP = new DESCryptoServiceProvider();
            ICryptoTransform ct = mCSP.CreateDecryptor(DESKey, DESIV);
            byte[] byt = Convert.FromBase64String(strSource);
            MemoryStream ms = new MemoryStream(byt);
            CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs, Encoding.Unicode);
            return sr.ReadToEnd();
        }

       /// <summary>
       /// 16λMD5���ܷ���,��ǰ��DVBBS��ʹ��
       /// </summary>
       /// <param name="strSource">�������ִ�</param>
        /// <returns>���ܺ���ִ�</returns>
        public string MD5Encrypt(string strSource)
        {
            return MD5Encrypt(strSource, 16);
        }
        /// <summary>
        /// MD5����,�Ͷ����ϵ�16/32λMD5���ܽ����ͬ
        /// </summary>
        /// <param name="strSource">�������ִ�</param>
        /// <param name="length">16��32ֵ֮һ,���������.netĬ��MD5�����㷨</param>
        /// <returns>���ܺ���ִ�</returns>
        public string MD5Encrypt(string strSource, int length)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(strSource);
            byte[] hashValue = ((System.Security.Cryptography.HashAlgorithm)System.Security.Cryptography.CryptoConfig.CreateFromName("MD5")).ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            switch (length)
            {
                case 16:
                    for (int i = 4; i < 12; i++)
                        sb.Append(hashValue[i].ToString("x2"));
                    break;
                case 32:
                    for (int i = 0; i < 16; i++)
                    {
                        sb.Append(hashValue[i].ToString("x2"));
                    }
                    break;
                default:
                    for (int i = 0; i < hashValue.Length; i++)
                    {
                        sb.Append(hashValue[i].ToString("x2"));
                    }
                    break;
            }
            return sb.ToString();
        }

    }
}

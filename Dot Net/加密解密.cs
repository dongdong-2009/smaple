using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Hubei.Blackant
{
    /// <summary>
    /// 常用的加密/解密方法
    /// </summary>
    public class MySecurity
    {
        private static byte[] DESKey = Encoding.ASCII.GetBytes("blackant");
        private static byte[] DESIV = Encoding.ASCII.GetBytes("DUDUBLOG");

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="strSource">待加密字串</param>
        /// <returns>加密后的字符串</returns>
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
        /// DES解密
        /// </summary>
        /// <param name="strSource">待解密的字串</param>
        /// <returns>解密后的字符串</returns>
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
       /// 16位MD5加密方法,以前的DVBBS所使用
       /// </summary>
       /// <param name="strSource">待加密字串</param>
        /// <returns>加密后的字串</returns>
        public string MD5Encrypt(string strSource)
        {
            return MD5Encrypt(strSource, 16);
        }
        /// <summary>
        /// MD5加密,和动网上的16/32位MD5加密结果相同
        /// </summary>
        /// <param name="strSource">待加密字串</param>
        /// <param name="length">16或32值之一,其它则采用.net默认MD5加密算法</param>
        /// <returns>加密后的字串</returns>
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

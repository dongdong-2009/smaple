using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;

namespace LicensedControls
{
    //避免用户调试进入许可过程中
    [DebuggerNonUserCode]
    public class ExpirePolicyLicenseProvider:LicenseProvider
    {
        /// <summary>
        /// 将许可信息缓存在静态变量中
        /// </summary>
        static LicenseDataDictionary _licenses;
        static readonly object _lock = new object();

        //提供License，由LicenseManager调用
        public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
        {
            ExpirePolicyLicense license = null;
            string errorMessage = null;
            
            //设计时无需许可
            if (context.UsageMode == LicenseUsageMode.Designtime)
            {
                license = new ExpirePolicyLicense(type, DateTime.MaxValue.Ticks.ToString());
            }
            else
            {
                //尝试读取许可信息
                license = GetLicenseData(type);
                if (license != null)
                {
                    //验证许可信息，由于时间是不断变化的，
                    //所以我们缓存License，但并不缓存验证结果
                    if (!ValidateLicense(license, out errorMessage))
                    {
                        license = null;
                    }
                }
                else
                {
                    errorMessage = "There is no lincense data.";
                }
            }
            //抛出异常
            if ((license == null) && allowExceptions)
            {
                if (errorMessage == null)
                {
                    throw new LicenseException(type);
                }
                else
                {
                    throw new LicenseException(type, instance, errorMessage);
                }
            }
            //返回许可
            return license;
        }

        /// <summary>
        /// 验证许可是否有效
        /// </summary>
        protected virtual bool ValidateLicense(ExpirePolicyLicense license, out string errorMessage)
        {
            errorMessage = null;
            bool validated = true;
            try
            {
                DateTime expiredTime = new DateTime(long.Parse(license.LicenseKey));
                if (expiredTime <= DateTime.Now)
                {
                    errorMessage = "License has expired!";
                    validated = false;
                }
            }
            catch (FormatException)
            {
                errorMessage = "License file is invalid";
                validated = false;
            }
            return validated;
        }

        /// <summary>
        /// 查询类型对应的许可数据
        /// </summary>
        protected virtual ExpirePolicyLicense GetLicenseData(Type type)
        {
            if (_licenses == null)
            {
                lock (_lock)
                {
                    if (_licenses == null)
                    {
                        _licenses = GetLicenseData();
                    }
                }
            }
            if (_licenses.ContainsKey(type.FullName))
            {
                long ticks = _licenses[type.FullName];
                return new ExpirePolicyLicense(type, ticks.ToString());
            }
            return null;
        }

        /// <summary>
        /// 查找licenses.lic文件，并从中读出许可数据
        /// </summary>
        /// <returns>licenses.lic文件中的所有许可数据</returns>
        LicenseDataDictionary GetLicenseData()
        {
            LicenseDataDictionary licenses = new LicenseDataDictionary();
            if (HttpContext.Current != null)
            {
                string licFilePath = HttpContext.Current.Server.MapPath("~/licenses.lic");
                //由于涉及类型信息，所以直接用二进制序列化方式并不合适
                //BinaryFormatter formatter = new BinaryFormatter();
                if (File.Exists(licFilePath))
                {
                    //using (FileStream fs = File.OpenRead(licFilePath))
                    //{
                    //    licenses = formatter.Deserialize(fs) as LicenseDataDictionary;
                    //}
                    using (StreamReader sr = File.OpenText(licFilePath))
                    {
                        string line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line))
                        {
                            string[] data = line.Split(':');
                            licenses.Add(data[0], long.Parse(data[1]));
                            line = sr.ReadLine();
                        }
                    }
                }
            }
            return licenses;
        }
    }

    /// <summary>
    /// 许可数据
    /// </summary>
    [Serializable]
    public class LicenseDataDictionary : Dictionary<string, long>
    {
    }
}

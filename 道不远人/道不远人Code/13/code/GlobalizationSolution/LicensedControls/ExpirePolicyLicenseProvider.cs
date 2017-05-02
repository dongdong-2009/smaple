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
    //�����û����Խ�����ɹ�����
    [DebuggerNonUserCode]
    public class ExpirePolicyLicenseProvider:LicenseProvider
    {
        /// <summary>
        /// �������Ϣ�����ھ�̬������
        /// </summary>
        static LicenseDataDictionary _licenses;
        static readonly object _lock = new object();

        //�ṩLicense����LicenseManager����
        public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
        {
            ExpirePolicyLicense license = null;
            string errorMessage = null;
            
            //���ʱ�������
            if (context.UsageMode == LicenseUsageMode.Designtime)
            {
                license = new ExpirePolicyLicense(type, DateTime.MaxValue.Ticks.ToString());
            }
            else
            {
                //���Զ�ȡ�����Ϣ
                license = GetLicenseData(type);
                if (license != null)
                {
                    //��֤�����Ϣ������ʱ���ǲ��ϱ仯�ģ�
                    //�������ǻ���License��������������֤���
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
            //�׳��쳣
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
            //�������
            return license;
        }

        /// <summary>
        /// ��֤����Ƿ���Ч
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
        /// ��ѯ���Ͷ�Ӧ���������
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
        /// ����licenses.lic�ļ��������ж����������
        /// </summary>
        /// <returns>licenses.lic�ļ��е������������</returns>
        LicenseDataDictionary GetLicenseData()
        {
            LicenseDataDictionary licenses = new LicenseDataDictionary();
            if (HttpContext.Current != null)
            {
                string licFilePath = HttpContext.Current.Server.MapPath("~/licenses.lic");
                //�����漰������Ϣ������ֱ���ö��������л���ʽ��������
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
    /// �������
    /// </summary>
    [Serializable]
    public class LicenseDataDictionary : Dictionary<string, long>
    {
    }
}

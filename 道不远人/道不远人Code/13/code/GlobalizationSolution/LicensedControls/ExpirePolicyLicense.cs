using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace LicensedControls
{
    public class ExpirePolicyLicense:License
    {
        //��ɹ���������
        Type _type;
        string _ticks;

        public ExpirePolicyLicense(Type type, string ticks)
        {
            _type = type;
            _ticks = ticks;
        }
        /// <summary>
        /// ע�⼴ʱ���������ݣ������ؼ�����
        /// </summary>
        public override void Dispose()
        {
            _type = null;
            _ticks = null;
        }

        public override string LicenseKey
        {
            get
            {
                return _ticks;
            }
        }
    }
}

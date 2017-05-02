using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace LicensedControls
{
    public class ExpirePolicyLicense:License
    {
        //许可关联的类型
        Type _type;
        string _ticks;

        public ExpirePolicyLicense(Type type, string ticks)
        {
            _type = type;
            _ticks = ticks;
        }
        /// <summary>
        /// 注意即时清除许可数据，保护关键数据
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

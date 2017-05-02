using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace GlobalizeControl
{
    //将Attribute设为sealed可获得更高效率
    [AttributeUsage(AttributeTargets.All)]
    sealed class GlobalizeDescriptionAttribute : DescriptionAttribute
    {
        bool _localized = false;
        string _key = null;
        public GlobalizeDescriptionAttribute(string resourceKey)
            : base(resourceKey)
        {
            _key = resourceKey;
        }

        public override string Description
        {
            get
            {
                if (!_localized)
                {
                    //将Description更新为本地化内容
                    string localizedDescription 
                        = AssemblyResourceManager.DescriptionResource
                        .GetString(_key,Thread.CurrentThread.CurrentCulture);
                    base.DescriptionValue = localizedDescription;

                    _localized = true;
                }
                return base.Description;
            }
        }

        //将两种Attribute标识为同一类型
        public override object TypeId
        {
            get
            {
                return typeof(DescriptionAttribute);
            }
        }
    }
}

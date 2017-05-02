using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace GlobalizeControl
{
    //��Attribute��Ϊsealed�ɻ�ø���Ч��
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
                    //��Description����Ϊ���ػ�����
                    string localizedDescription 
                        = AssemblyResourceManager.DescriptionResource
                        .GetString(_key,Thread.CurrentThread.CurrentCulture);
                    base.DescriptionValue = localizedDescription;

                    _localized = true;
                }
                return base.Description;
            }
        }

        //������Attribute��ʶΪͬһ����
        public override object TypeId
        {
            get
            {
                return typeof(DescriptionAttribute);
            }
        }
    }
}

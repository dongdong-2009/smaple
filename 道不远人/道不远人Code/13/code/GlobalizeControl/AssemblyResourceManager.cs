using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Resources;
using System.Reflection;

namespace GlobalizeControl
{
    sealed class AssemblyResourceManager
    {
        static object _lockResource = new object();
        //������Դ�ļ���ResourceManagerʵ��
        static Dictionary<string, ResourceManager> _resources = new Dictionary<string, ResourceManager>();
        static ResourceManager GetManagerByResourceName(string resourceName)
        {
            //�����������ʱʹ��lock��˫���ж�
            if (!_resources.ContainsKey(resourceName))
            {
                lock (_lockResource)
                {
                    if (!_resources.ContainsKey(resourceName))
                    {
                        ResourceManager manager = new ResourceManager(resourceName,Assembly.GetAssembly(typeof(AssemblyResourceManager)));
                        _resources[resourceName] = manager;
                    }
                }
            }
            return _resources[resourceName];
        }

        //������Դ�ļ�
        public static ResourceManager DescriptionResource
        {
            get
            {
                return GetManagerByResourceName("GlobalizeControl.DescriptionResource");
            }

        }

        public static ResourceManager PropertyResource
        {
            get
            {
                return GetManagerByResourceName("GlobalizeControl.PropertyResource");
            }
        }
        public static ResourceManager ExceptionResource
        {
            get
            {
                return GetManagerByResourceName("GlobalizeControl.ExceptionResource");
            }
        }
    }
}

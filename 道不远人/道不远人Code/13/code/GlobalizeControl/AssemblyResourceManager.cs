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
        //缓存资源文件的ResourceManager实例
        static Dictionary<string, ResourceManager> _resources = new Dictionary<string, ResourceManager>();
        static ResourceManager GetManagerByResourceName(string resourceName)
        {
            //操作缓存对象时使用lock和双重判断
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

        //三种资源文件
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

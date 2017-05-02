using System;
using System.Collections.Generic;
using System.Text;

namespace one
{
    public sealed class Singleton  //加载即被实例话，饿汉单例类
    {
        private static readonly Singleton instance = new Singleton();

        private Singleton() { }

        public static Singleton GetInstance()
        {
            return instance;
        }
    }
}

namespace two
{
    public class Singleton //第一次引用时才会初始化，懒汉单例类
    {
        private static Singleton instance;

        private static readonly object syncRoot = new object();

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }                
            }
            return instance;
        }
    }
}

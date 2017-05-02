using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using EssentialAspNet;

namespace AppDomainTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建远程对象intelligencer，这种方法需要将intelligencer的程序集添加到GAC中或者复制到BIN下。
            System.Type hostType = typeof(Intelligencer);

            Intelligencer intelligencer = System.Web.Hosting.ApplicationHost.CreateApplicationHost(
                    hostType,
                    "/",
                    System.Environment.CurrentDirectory
                    )
                    as Intelligencer;            


            Console.WriteLine("Current Domain ID: {0}\r\n", AppDomain.CurrentDomain.Id);
            Console.WriteLine(intelligencer.Report());
            Console.ReadLine();
        }
    }
}

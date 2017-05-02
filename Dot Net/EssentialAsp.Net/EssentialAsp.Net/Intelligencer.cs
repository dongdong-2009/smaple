using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Web;

namespace EssentialAspNet
{
        public class Intelligencer : System.MarshalByRefObject
        {
            public string Report()
            {
                System.AppDomain appdomain = System.AppDomain.CurrentDomain;
                StringBuilder builder = new StringBuilder();

                // 应用程序域的信息
                builder.AppendFormat("Domain ID: {0}\r\n", appdomain.Id);

                // 对于每一个 Web 应用程序域，有一个 HostingEnvironment
                builder.AppendFormat("VirtualPath: {0}\r\n",
                    HostingEnvironment.ApplicationVirtualPath);
                builder.AppendFormat("PhysicalPath: {0}\r\n",
                    HostingEnvironment.ApplicationPhysicalPath);

                return builder.ToString();
            }

        }

}

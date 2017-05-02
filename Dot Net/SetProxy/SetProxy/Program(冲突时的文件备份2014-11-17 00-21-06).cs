using PoshHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SetProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            string strHostName = Dns.GetHostName();  //得到本机的主机名
            System.Net.IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;  //取得本机IP
            string strAddr = addressList[0].ToString(); //假设本地主机为单网卡
            string ip = string.Empty;

            for (int i = 0; i < addressList.Length; i++)  
            {  
                ip = addressList[i].ToString();  
            }
            if (ip.IndexOf("16.187.") != -1 || ip.IndexOf("16.165.") != -1)
            {
                Proxies.SetProxy("proxy.houston.hp.com:8080");
            }
            else
            {
                Proxies.UnsetProxy();
            }
           
        }
    }


}

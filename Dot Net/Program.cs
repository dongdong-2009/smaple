using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Net ;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication4
{
    public delegate void ThreadCallback(int ThreadIndex);
    public delegate void WriteCallback(int flashid,string from,string to,string errormessage);
    public  class DownloadThread
    {
        private int ThreadIndex;
        private int FlashId;
        private string From;
        private string To;
        private ThreadCallback CallbackDelegate;
        private WriteCallback WriteError;
        public DownloadThread(int threadindex,int flashid, string from, string to, ThreadCallback callbackDelegate,WriteCallback writecallback)
        {
            ThreadIndex = threadindex;
            FlashId = flashid;
            From = from;
            To = to;
            CallbackDelegate = callbackDelegate;
            WriteError = writecallback;
        }
        public void Start() 
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(From);
            try
            {
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream stream = response.GetResponseStream();
                
                FileStream fs = new FileStream(To, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                byte[] bytes = new byte[1024];
                int length = stream.Read(bytes, 0, bytes.Length);
                while (length > 0)
                {
                    bw.Write(bytes, 0, length);
                    length = stream.Read(bytes, 0, bytes.Length);
                }
                bw.Close();
                fs.Close();
                stream.Close();
                WriteError(FlashId, From, To, "下载完成");
            }
            catch (Exception excep){
                WriteError(FlashId, From, To, excep.Message);
            }

            Thread.Sleep(1000);
            //返回进程可用信息
            CallbackDelegate(ThreadIndex);
        }
    }


    class Program
    {
        private static Thread[] threads;
        private static int intRowIndex;
        private static DataView dv;
        private static FileStream fs;
        private static StreamWriter sw;
        
        static void Main(string[] args)
        {
            string connStr = @"server=SERVER251;uid=sa;pwd=123456;database=yxzj2006";
            SqlConnection conn=new SqlConnection(connStr);
            SqlCommand comm=new SqlCommand("select flashid,0,swfurl from reflash union select flashid,1,flashpic from reflash",conn);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataSet ds=new DataSet();
            conn.Open();
            sda.Fill(ds);
            conn.Close();
            dv = ds.Tables[0].DefaultView;

            fs = new FileStream("e:\\Error.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            threads = new Thread[6];

        
            for(int i=0;i<threads.Length  ;i++)
            {
                StartThread(i,i);  
            }
            
            Console.WriteLine("请等待......");
            Console.Read();
        }
       
        static void WriteError(int flashid, string from, string to, string errormessage)
        {
            String err = String.Format("flashid:{0} from:{1} to:{2} errormessage:{3}",flashid,from,to,errormessage);
            sw.WriteLine(err);
            sw.Flush();
        }
        static void StartThread(int rowindex,int threadindex)
        {
            intRowIndex = rowindex;
            int flashid = Convert.ToInt32(dv[intRowIndex][0]);
            string from=dv[intRowIndex][2].ToString();
            int index=from.LastIndexOf('/');
            if(index+1<from.Length){
                string filename = from.Substring(index + 1, from.Length - index - 1);
                string to;
                if (Convert.ToInt32(dv[intRowIndex][1]) == 1)
                {
                    to = string.Format("e:\\gif\\{0}", filename);
                    from = string.Format("http://img.p4.cn/Flashpic/{0}", filename);
                }
                else {
                    to = string.Format("e:\\swf\\{0}", filename);
                    from = string.Format("http://img.p4.cn/Flash/{0}", filename);
                }
                Console.WriteLine("flashid:{0} from:{1} to:{2}",flashid,from,to);
                DownloadThread dt = new DownloadThread(threadindex, flashid, from, to, new ThreadCallback(Callback), new WriteCallback(WriteError));
                threads[threadindex] = new Thread(new ThreadStart(dt.Start));
                threads[threadindex].Start();
            }
            else
            {
                 WriteError(flashid, dv[intRowIndex][2].ToString(), String.Empty, "格式错误");
            }
            
           
        }
        static void Callback(int ThreadIndex)
        {

            if (intRowIndex <dv.Count)
            {
                intRowIndex++;
                StartThread(intRowIndex, ThreadIndex);
                
            }
            else
            {
                threads[ThreadIndex]=null;
                bool end = true;
                foreach (Thread td in threads) 
                {
                    if (td != null)
                        end = false;
                }
                if (end)
                {
                     sw.Close();
                     fs.Close();
                     Console.WriteLine("下载完成");
                }
            }          
        }
    }
}

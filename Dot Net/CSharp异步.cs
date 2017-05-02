using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    using System;
    using System.Threading;

    public class AsyncDemo
    {
        // The method to be executed asynchronously.
        //
        public string TestMethod(out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(1);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return "MyCallTime was 1";
        }
    }

    public class AsyncMain
    {
        public delegate string AsyncDelegate(out int threadId);
        // Asynchronous method puts the thread id here.
        private static int threadId;

        static void Main1(string[] args)
        {
            AsyncDemo ad = new AsyncDemo();
            AsyncDelegate dlgt = new AsyncDelegate(ad.TestMethod);
            IAsyncResult ar = dlgt.BeginInvoke(
                out threadId,
                new AsyncCallback(CallbackMethod),
                dlgt);

            while (!ar.IsCompleted)
            {
                Console.WriteLine("Running.");
            }
            
            Console.ReadLine();
        }

        static void CallbackMethod(IAsyncResult ar)
        {
            AsyncDelegate dlgt = (AsyncDelegate)ar.AsyncState;
            string ret = dlgt.EndInvoke(out threadId, ar);
            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".", threadId, ret);
        }
    }

}

using System;
using System.Threading;

namespace ThreadPool6
{
	class Class1
	{		
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("ThreadPool Test") ;
			string strSel="3";
			while(strSel.ToUpper()!="E")
			{
                switch (strSel.ToUpper())
                {
                    case "A":
                        {
                            Console.WriteLine(@"本示例将一个由 ThreadProc 方法表示的非常简单的任务排入队列，使用的是 QueueUserWorkItem。");
                            // Queue the task.
                            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));

                            Console.WriteLine("Main thread does some work, then sleeps.");
                            // If you comment out the Sleep, the main thread exits before
                            // the thread pool task runs.  The thread pool uses background
                            // threads, which do not keep the application running.  (This
                            // is a simple example of a race condition.)
                            Thread.Sleep(1000);

                            Console.WriteLine("Main thread exits.");
                            break;
                        }
                    case "B":
                        {
                            Console.WriteLine("开始创建100个线程池对象");
                            C_ThreadPoolTest[] cTpt = new C_ThreadPoolTest[100];
                            for (int i = 0; i < 100; i++)
                            {
                                cTpt[i] = new C_ThreadPoolTest(i.ToString());
                                ThreadPool.QueueUserWorkItem(new WaitCallback(cTpt[i].PrintResult));
                            }
                            Console.WriteLine("100个线程池对象创建完毕，主线程开始休眠 10秒钟");
                            Thread.Sleep(10000); //10秒钟

                            Console.WriteLine("主线程休眠 10秒钟 结束");
                            break;
                        }
                    case "C":
                        {
                            Console.WriteLine("为 QueueUserWorkItem 提供任务数据。即通过线程池可以访问到被执行类中的相关参数");
                            // Create an object containing the information needed
                            // for the task.
                            TaskInfo ti = new TaskInfo("This report displays the number {0}.", 42);

                            // Queue the task and data.
                            if (ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc2), ti))
                            {
                                //WaitCallback : 通过将 WaitCallback 委托传递给 ThreadPool.QueueUserWorkItem 来将任务排入队列以便执行。您的回调方法将在某个线程池线程可用时执行。


                                Console.WriteLine("Main thread does some work, then sleeps.");
                                Thread.Sleep(1000);
                                Console.WriteLine("Main thread exits.");
                            }
                            else
                            {
                                Console.WriteLine("Unable to queue ThreadPool request.");
                            }
                            break;
                        }
                    default:
                        break;
                }                
				
				Console.WriteLine("Please select:  A : [MsdnSample] B: [MyTestSample] C : [为 QueueUserWorkItem 提供任务数据]    E : [Exit] ") ;
				strSel=Console.ReadLine();
			}
		}
		
		static void ThreadProc(Object stateInfo) 
		{
			Console.WriteLine("Hello from the thread pool.");
		}


		static void ThreadProc2(Object stateInfo) 
		{
			TaskInfo ti = (TaskInfo) stateInfo;
			Console.WriteLine(ti.Boilerplate, ti.Value); 
		}

	}

	public class C_ThreadPoolTest
	{
		string ThreadName="";
		double iCount=0;
		public C_ThreadPoolTest(string name)
		{
			ThreadName=name;
		}
		private double Calc( )
		{
			double j=0;
			iCount=0;
			for(double i=0;i<100;i++)
			{
				j+=i;
                if (i % 5 == 0)
                {
                    iCount += 1;
                }
			}
			return j;
		}
		public void PrintResult(object obj1)
		{
			Console.WriteLine( "\nThread "+ThreadName+" 计算完毕.");
			double x1=Calc( );
			Console.WriteLine("\n计算次数: "+ iCount.ToString() ) ;

			Console.WriteLine("\n计算结果: "+  x1.ToString()); 
            
		}
		public void PrintResult(object obj1, bool bl1)
		{
			Console.WriteLine( "\nThread "+ThreadName+" 计算完毕.");
			double x1=Calc( );
			Console.WriteLine("\n计算次数: "+ iCount.ToString() ) ;
			Console.WriteLine("\n计算结果: "+  x1.ToString()); 
            
		}
	}
	public class TaskInfo 
	{
		public string Boilerplate; //样板文件
		public int Value;
		public TaskInfo(string text, int number) 
		{
			Boilerplate = text;
			Value = number;
		}
	}
}

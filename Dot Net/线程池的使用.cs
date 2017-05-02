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
                            Console.WriteLine(@"��ʾ����һ���� ThreadProc ������ʾ�ķǳ��򵥵�����������У�ʹ�õ��� QueueUserWorkItem��");
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
                            Console.WriteLine("��ʼ����100���̳߳ض���");
                            C_ThreadPoolTest[] cTpt = new C_ThreadPoolTest[100];
                            for (int i = 0; i < 100; i++)
                            {
                                cTpt[i] = new C_ThreadPoolTest(i.ToString());
                                ThreadPool.QueueUserWorkItem(new WaitCallback(cTpt[i].PrintResult));
                            }
                            Console.WriteLine("100���̳߳ض��󴴽���ϣ����߳̿�ʼ���� 10����");
                            Thread.Sleep(10000); //10����

                            Console.WriteLine("���߳����� 10���� ����");
                            break;
                        }
                    case "C":
                        {
                            Console.WriteLine("Ϊ QueueUserWorkItem �ṩ�������ݡ���ͨ���̳߳ؿ��Է��ʵ���ִ�����е���ز���");
                            // Create an object containing the information needed
                            // for the task.
                            TaskInfo ti = new TaskInfo("This report displays the number {0}.", 42);

                            // Queue the task and data.
                            if (ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc2), ti))
                            {
                                //WaitCallback : ͨ���� WaitCallback ί�д��ݸ� ThreadPool.QueueUserWorkItem ����������������Ա�ִ�С����Ļص���������ĳ���̳߳��߳̿���ʱִ�С�


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
				
				Console.WriteLine("Please select:  A : [MsdnSample] B: [MyTestSample] C : [Ϊ QueueUserWorkItem �ṩ��������]    E : [Exit] ") ;
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
			Console.WriteLine( "\nThread "+ThreadName+" �������.");
			double x1=Calc( );
			Console.WriteLine("\n�������: "+ iCount.ToString() ) ;

			Console.WriteLine("\n������: "+  x1.ToString()); 
            
		}
		public void PrintResult(object obj1, bool bl1)
		{
			Console.WriteLine( "\nThread "+ThreadName+" �������.");
			double x1=Calc( );
			Console.WriteLine("\n�������: "+ iCount.ToString() ) ;
			Console.WriteLine("\n������: "+  x1.ToString()); 
            
		}
	}
	public class TaskInfo 
	{
		public string Boilerplate; //�����ļ�
		public int Value;
		public TaskInfo(string text, int number) 
		{
			Boilerplate = text;
			Value = number;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleApplication1
{
    public class Account
    {
        int balance;
        Random r = new Random();
        public Account(int balance)
        {
            this.balance = balance;
        }

        int doit(int amount)
        {
            if (this.balance < 0)
            {
                Console.WriteLine("abcde");
            }

            return lockTest(amount);
            return monitorTest(amount);
            return interlockedTest(amount);
        }

        int lockTest(int amount)
        {
            lock(this)
            {
                if (balance >= amount)
                {
                    Thread.Sleep(5);
                    Console.WriteLine("old:"+balance);
                    balance = balance - amount;
                    Console.WriteLine("new:" + balance);
                    return balance;
                }
                else
                {
                    return 0;
                }
            }
        }

        int monitorTest(int amount)
        {
            try
            {
                if (Monitor.TryEnter(this, TimeSpan.FromSeconds(30))) //获得排它锁
                {
                    if (balance >= amount)
                    {
                        Thread.Sleep(5);
                        Console.WriteLine("old:" + balance);
                        balance = balance - amount;
                        Console.WriteLine("new:" + balance);
                        return balance;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch
            {


            }
            finally
            { 
                
            }
            return 0;
        }

        int interlockedTest(int amount)
        {
            int nOld = balance - amount;
            balance = balance - amount;
            Thread.Sleep(6);
            Interlocked.CompareExchange(ref balance, nOld, nOld);
            return amount;
        }

        public void test()
        {
            for (int i = 0; i < 100; i++)
            {
                doit(r.Next(-50,100));
            }
        }
    }

    class Program
    {
        static Thread[] ts = new Thread[10];
        static void Main(string[] args)
        {
            Account aaa = new Account(0);
            for (int i = 0; i < ts.Length; i++)
            {
                ts[i] = new Thread(aaa.test);
            }

            for (int i = 0; i < ts.Length; i++)
            {
                ts[i].Start();
            }

            Console.Read();
        }
    }
}

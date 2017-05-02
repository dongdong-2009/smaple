using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace test
{
    class ThrowSample
    {
        public ThrowSample(){}

        private void ExceptionMethod()
        {
            throw new Exception("123");
        }

        public void ThrowExMethod()
        {
            try 
            {
                this.ExceptionMethod(); 
            }
            catch
            {
                throw;
            }
        }

        public void ThrowExMethod2()
        {

            try 
            {
                this.ExceptionMethod(); 
            }
            catch (Exception ex)
            {
                //throw ex;
                throw new Exception("Uh-oh!", ex);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            ThrowSample ts = new ThrowSample();

            try 
            {
                ts.ThrowExMethod(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught from ThrowExMethod:");
                Console.WriteLine(ex.ToString());
                Console.WriteLine();
            }


            try 
            { 
                ts.ThrowExMethod2(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught from ThrowExMethod2:");
                Console.WriteLine(ex.ToString());                
            }

            Console.Read();
        }
    }
}


//结果我们不难发现，前者比后者多了一条信息，
//而这条信息正是发生异常的根本来源的说明，
//而后者显然漏掉了这一关键信息．如果我们采用后者，
//那么我们势必会很难发现问题的来源，特别是当ThrowExMethod方法非常复杂的时候．
//现在让我们做个假设，如果从ThrowExMethod到ExceptionMethod之间还夹杂了一系列的方法调用，
//每一个方法都往上抛出一个新的异常（throw ex;）
//那我们将更加困难的知道异常真正发生的地方，所以明白它们之间的区别非常重要．

//尽管如此，也不是说throw ex;就是一无是处，
//就是完全不好的，你可以在当你需要向你捕获的异常中添加一些信息的时候，
//可以新建一个异常，然后初始化原始异常为其内部异常.

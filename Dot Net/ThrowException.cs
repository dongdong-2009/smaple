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


//������ǲ��ѷ��֣�ǰ�߱Ⱥ��߶���һ����Ϣ��
//��������Ϣ���Ƿ����쳣�ĸ�����Դ��˵����
//��������Ȼ©������һ�ؼ���Ϣ��������ǲ��ú��ߣ�
//��ô�����Ʊػ���ѷ����������Դ���ر��ǵ�ThrowExMethod�����ǳ����ӵ�ʱ��
//�����������������裬�����ThrowExMethod��ExceptionMethod֮�仹������һϵ�еķ������ã�
//ÿһ�������������׳�һ���µ��쳣��throw ex;��
//�����ǽ��������ѵ�֪���쳣���������ĵط���������������֮�������ǳ���Ҫ��

//������ˣ�Ҳ����˵throw ex;����һ���Ǵ���
//������ȫ���õģ�������ڵ�����Ҫ���㲶����쳣�����һЩ��Ϣ��ʱ��
//�����½�һ���쳣��Ȼ���ʼ��ԭʼ�쳣Ϊ���ڲ��쳣.

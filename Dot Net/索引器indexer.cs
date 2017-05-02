using System;

namespace PropertyIndexerApp
{
    /// <summary>
    /// Class1 的摘要说明。
    /// </summary>
    class Class1
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //
            // TODO: 在此处添加代码以启动应用程序
            //
            //创建一个MyClass实例
            MyClass m = new MyClass();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //写、读第一个索引器
                    m[i * 10, j] = i * 10 + j;
                    Console.Write("No{0}{1}:{2}", i, j, m[i * 10, j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < m.StrCount; i++)
            { //读第二个索引器
                Console.WriteLine(m[i]);
            }

            //Set实例属性
            m.StrCount = 5;
            //Get实例属性
            for (int i = 0; i < m.StrCount; i++)
            { //读第二个索引器
                Console.WriteLine(m[i]);
            }

            //读静态属性
            Console.WriteLine(MyClass.ClassName);
            Console.Write("Press any key to continue");
            Console.ReadLine();
        }
    }

    class MyClass
    {
        private const int c_count = 100;
        private static int[] intArray = new int[c_count];
        //第一个索引器，可读可写，有两个参数
        public int this[int index, int offset]
        {
            get
            {
                if ((index + offset) >= 0 && (index + offset) < c_count)
                {
                    return intArray[index + offset];
                }
                else return 0;
            }
            set
            {
                if ((index + offset) >= 0 && (index + offset) < c_count)
                    intArray[index + offset] = value;
            }
        }


        private int m_strCount = 3;
        private string[] strArray = { "111", "222", "333" };
        //第二个索引器，只读，一个参数
        public string this[int index]
        {
            get
            {
                if ((index >= 0) && (index < m_strCount))
                {
                    return strArray[index];
                }
                else
                {
                    return "NULL";
                }
            }
        }

        //实例属性，可读可写
        public int StrCount
        {
            get
            {
                return m_strCount;
            }
            set
            {
                if (value > m_strCount)
                {
                    strArray = new string[value];
                    for (int i = 0; i < value; i++)
                    {
                        strArray[i] = String.Format("String No.{0}", i);
                    }
                    m_strCount = value;
                }
            }
        }

        private static string m_strName = "MyClass";
        //一个静态属性，只读
        public static string ClassName
        {
            get
            {
                return m_strName;
            }
        }
    }
}
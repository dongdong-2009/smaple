using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Program
    {
        static void Main1(string[] args)
        {
            Product P1 = factory.CreateProduct("A");
            Product P2 = factory.CreateProduct("B");
            Product P3 = factory.CreateProduct("C");
            P1.show();
            P2.show();
            P3.show();
            Console.Read();
        }
    }

    public static class factory
    {
        public static Product CreateProduct(string s)
        {
            switch (s)
            {
                case "A":
                    {
                        return new A();
                    }
                case "B":
                    {
                        return new B();
                    }
                case "C":
                    {
                        return new C();
                    }
            }
            return null;
        }
    }

    public abstract class Product
    {
        public abstract void show();
    }

    public class A : Product
    {
        public override void show()
        {
            Console.WriteLine("A");
        }
    }

    public class B : Product
    {
        public override void show()
        {
            Console.WriteLine("B");
        }
    }

    public class C : Product
    {
        public override void show()
        {
            Console.WriteLine("C");
        }
    }
}

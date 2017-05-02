using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class FactoryMethod
    {
        static void Main2(string[] args)
        {
            IFactory f = new factoryB();
            Product p =  f.CreateProduct();
            p.show();
            Console.Read();
        }
    }

    public  interface IFactory
    {
        Product CreateProduct();
    }

    public class factoryA : IFactory
    {
        public Product CreateProduct()
        {
            return new A();
        }
    }

    public class factoryB : IFactory
    {
        public  Product CreateProduct()
        {
            return new B();
        }
    }


    public class factoryC : IFactory
    {
        public  Product CreateProduct()
        {
            return new C();
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
            Console.WriteLine("A1");
        }
    }

    public class B : Product
    {
        public override void show()
        {
            Console.WriteLine("B1");
        }
    }

    public class C : Product
    {
        public override void show()
        {
            Console.WriteLine("C1");
        }
    }
}

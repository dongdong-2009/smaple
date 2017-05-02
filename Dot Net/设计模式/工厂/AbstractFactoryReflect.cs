using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class FactoryMethod
    {
        static void Main(string[] args)
        {
            //IFactory f = new factory2();
            //Department d = f.CreateDepartment();
            //User s = f.CreateUser();

            User s = Factory.CreateUser();
            Department d = Factory.CreateDepartment();

            
            d.showDepartment();
            s.showUser();
            Console.Read();
        }
    }

    //public  interface IFactory
    //{
    //    User CreateUser();
    //    Department CreateDepartment();
    //}

    //public class factory1 : IFactory
    //{
    //    public User CreateUser()
    //    {
    //        return new User1();
    //    }

    //    public Department CreateDepartment()
    //    {
    //        return new Department1();
    //    }
    //}

    //public class factory2 : IFactory
    //{

    //    public User CreateUser()
    //    {
    //        return new User2();
    //    }

    //    public Department CreateDepartment()
    //    {
    //        return new Department2();
    //    }
    //}

    public static class Factory
    {
        static string s = "2";

        public static User CreateUser()
        {
            switch (s)
            {
                case "1":
                    {
                        return new User1();
                    }
                case "2":
                    {
                        return new User2();
                    }
            }
            return null;
        }

        public static Department CreateDepartment()
        {
            switch (s)
            {
                case "1":
                    {
                        return new Department1();
                    }
                case "2":
                    {
                        return new Department2();
                    }
            }
            return null;
        }
    }


    public abstract class User
    {
        public abstract void showUser();
    }

    public abstract class Department
    {
        public abstract void showDepartment();
    }

    public class User1 : User
    {
        public override void showUser()
        {
            Console.WriteLine("User1");
        }
    }

    public class User2 : User
    {
        public override void showUser()
        {
            Console.WriteLine("User2");
        }
    }

    public class Department1 : Department
    {
        public override void showDepartment()
        {
            Console.WriteLine("Department1");
        }
    }

    public class Department2 : Department
    {
        public override void showDepartment()
        {
            Console.WriteLine("Department2");
        }
    }
}

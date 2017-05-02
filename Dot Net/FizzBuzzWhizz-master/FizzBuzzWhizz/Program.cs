using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzWhizz
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int fizz = 0, buzz = 0, whizz = 0;
            fizz = Int32.Parse(Console.ReadLine());
            buzz = Int32.Parse(Console.ReadLine());
            whizz = Int32.Parse(Console.ReadLine());
            Console.WriteLine("fizz = {0}, buzz = {1}, whizz = {2}", fizz, buzz, whizz);
            Console.ReadKey();
        }
    }
}
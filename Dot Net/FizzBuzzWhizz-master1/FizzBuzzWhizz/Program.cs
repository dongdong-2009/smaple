using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Implement;

namespace FizzBuzzWhizz
{
	class Program
	{
		private static readonly Regex matchNumber = new Regex("^\\d{1}$");

		static void Main(string[] args)
		{
			var specialNumbers = new int[3];
			var gameController = new GameController();
			for (var i = 0; i < specialNumbers.Length; i++)
			{
				Console.WriteLine("请输入第{0}个特殊数字", i + 1);
				specialNumbers[i] = InputNumber();
			}
			Console.WriteLine(gameController.StartGame(100, specialNumbers));
		}

		private static int InputNumber()
		{
			string number;
			while (!matchNumber.IsMatch(number = Console.ReadLine()))
			{
				Console.WriteLine("请输入个位数，重新输入");
			}
			return int.Parse(number);
		}
	}
}

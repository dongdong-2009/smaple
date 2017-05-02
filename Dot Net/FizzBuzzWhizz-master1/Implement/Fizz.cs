using Contract;
using System;
using System.Globalization;

namespace Implement
{
	/// <summary>
	/// 特殊数字第一个类
	/// </summary>
	public class Fizz : IFizzBuzzWhizz
	{
		/// <summary>
		/// 构造一个第一个特殊数字的处理类实例
		/// </summary>
		/// <param name="specialNumber">特殊数字</param>
		/// <param name="nextFlow">下一个流程，这里值第二个特殊数字处理类实例</param>
		/// <param name="containsSpecialNumberAction">当某个数字包含当前的特殊数字时，要执行的事件，这里默认是输出一段字符</param>
		/// <param name="multipleAction">当某个数字是当前特殊数字的倍数时，要执行的事件</param>
		public Fizz(int specialNumber, IFizzBuzzWhizz nextFlow, Action<int> containsSpecialNumberAction, Action<int, bool> multipleAction)
		{
			this.SpecialNumber = specialNumber;
			this.NextFlow = nextFlow;
			this.ContainsSpecialNumberAction = containsSpecialNumberAction;
			this.MultipleAction = multipleAction;
		}

		public Fizz(int specialNumber, Action<int> containsSpecialNumberAction, Action<int, bool> multipleAction)
			: this(specialNumber, new Buzz(5), containsSpecialNumberAction, multipleAction)
		{
		}

		public Fizz(int specialNumber)
			: this(specialNumber, new Buzz(5), delegate { Console.Write("\r\nFizz"); }, (number, isHandle) => Console.Write("\r\nFizz"))
		{
		}

		/// <summary>
		/// 当某个数字包含当前的特殊数字时，要执行的事件
		/// </summary>
		public Action<int> ContainsSpecialNumberAction { get; set; }

		/// <summary>
		/// 当某个数字是当前特殊数字的倍数时，要执行的事件
		/// </summary>
		public Action<int, bool> MultipleAction { get; set; }

		/// <summary>
		/// 特殊数字
		/// </summary>
		public int SpecialNumber { get; set; }

		/// <summary>
		/// 下一个特殊数字处理类，这个默认值第二个特殊数字处理类
		/// </summary>
		public IFizzBuzzWhizz NextFlow { get; set; }

		/// <summary>
		/// 处理特殊数字
		/// </summary>
		/// <param name="number">数字</param>
		/// <param name="isHandle">是否被处理</param>
		public void Process(int number, bool isHandle = false)
		{
			//如果某个数字包含当前的特殊数字，那么就执行当某个数字包含当前特殊数字的事件，并且。终止往后调用。
			if (number.ToString(CultureInfo.InvariantCulture).Contains(this.SpecialNumber.ToString(CultureInfo.InvariantCulture)))
			{
				if (this.ContainsSpecialNumberAction != null)
					this.ContainsSpecialNumberAction(number);
				return;
			}
			//如果某个数字是当前特殊数字的倍数的时候，就执行是倍数时要执行的事件。并且标记ishandle为true。传递到下一个流程
			if (number % this.SpecialNumber == 0)
			{
				if (this.MultipleAction != null)
					this.MultipleAction(number, isHandle);
				isHandle = true;
			}
			//调用下一个流程的方法
			if (this.NextFlow != null)
				this.NextFlow.Process(number, isHandle);
		}
	}
}

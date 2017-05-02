using Contract;
using System;

namespace Implement
{
	/// <summary>
	/// 第二个特殊数字类
	/// </summary>
	public class Buzz : IFizzBuzzWhizz
	{
		/// <summary>
		/// 创建第二个特殊数字处理类实例
		/// </summary>
		/// <param name="specialNumber">特殊数字</param>
		/// <param name="nextFlow">下一个流程，这里指第三个特殊字处理类</param>
		/// <param name="multipleAction">当某个数字被这个类Handle的时候，要执行的事件（这里默认是如果某个数字是这个特殊数字的倍数，就在控制台输出一段字符）</param>
		public Buzz(int specialNumber, IFizzBuzzWhizz nextFlow, Action<int, bool> multipleAction)
		{
			this.SpecialNumber = specialNumber;
			this.NextFlow = nextFlow;
			this.MultipleAction = multipleAction;
		}

		public Buzz(int specialNumber, Action<int, bool> multipleAction)
			: this(specialNumber, new Whizz(7), multipleAction)
		{
		}

		public Buzz(int specialNumber)
			: this(specialNumber, new Whizz(7), (number, isHandle) => Console.Write("{0}Buzz", isHandle ? string.Empty : "\r\n"))
		{
		}

		/// <summary>
		/// 当某个数字是这个特殊数字的倍数的时候，要执行的事件
		/// </summary>
		public Action<int, bool> MultipleAction { get; set; }

		/// <summary>
		/// 特殊数字
		/// </summary>
		public int SpecialNumber { get; set; }

		/// <summary>
		/// 下一个流程，这里指第三个特殊数字处理类
		/// </summary>
		public IFizzBuzzWhizz NextFlow { get; set; }

		/// <summary>
		/// 处理方法
		/// </summary>
		/// <param name="number">数字</param>
		/// <param name="isHandle">是否被处理过</param>
		public void Process(int number, bool isHandle)
		{
			//如果当前的数字是这个特殊数字的倍数，就执行事件。并且标记isHandle为True，传递到下一个流程。
			if (number % this.SpecialNumber == 0)
			{
				if (this.MultipleAction != null)
					this.MultipleAction(number, isHandle);
				isHandle = true;
			}
			if (this.NextFlow != null)
				this.NextFlow.Process(number, isHandle);
		}
	}
}

using Contract;
using System;

namespace Implement
{
	/// <summary>
	/// 第三个特殊数字处理类
	/// </summary>
	public class Whizz : IFizzBuzzWhizz
	{
		/// <summary>
		/// 构造一个第三个特殊数字处理类
		/// </summary>
		/// <param name="specialNumber">特殊数字</param>
		/// <param name="nextFlow">下一个流程，这里默认是null，因为目前就三种情况</param>
		/// <param name="multipleAction">当某个数字是特殊数字的倍数时，所要触发的事件</param>
		/// <param name="neverHandleAction">当从来没用被任何一个特殊数字类处理过的时候要执行事件（这里就是指，这个数字既不是第一个特殊数字的倍数，也不是第二个特殊数字的倍数，更不是第三个特殊数字的倍数）</param>
		public Whizz(int specialNumber, IFizzBuzzWhizz nextFlow, Action<int, bool> multipleAction, Action<int, bool> neverHandleAction)
		{
			this.SpecialNumber = specialNumber;
			this.NextFlow = nextFlow;
			this.MultipleAction = multipleAction;
			this.NeverHandleAction = neverHandleAction;
		}

		public Whizz(int specialNumber, Action<int, bool> multipleAction, Action<int, bool> neverHandleAction)
			: this(specialNumber, default(IFizzBuzzWhizz), multipleAction, neverHandleAction)
		{
		}

		public Whizz(int specialNumber)
			: this(specialNumber, default(IFizzBuzzWhizz), (number, isHandle) => Console.Write("{0}Whizz", isHandle ? string.Empty : "\r\n"), (number, isHandle) => Console.Write("{0}{1}", isHandle ? string.Empty : "\r\n", number))
		{
		}

		public Action<int, bool> MultipleAction { get; set; }

		public Action<int, bool> NeverHandleAction { get; set; }

		public int SpecialNumber { get; set; }

		public IFizzBuzzWhizz NextFlow { get; set; }

		public void Process(int number, bool isHandle)
		{
			if (number % this.SpecialNumber == 0)
			{
				if (this.MultipleAction != null)
					this.MultipleAction(number, isHandle);
				isHandle = true;
			}
			if (!isHandle)
			{
				if (this.NeverHandleAction != default(Action<int, bool>))
					this.NeverHandleAction(number, isHandle);
			}
			if (this.NextFlow != null)
				this.NextFlow.Process(number, isHandle);
		}
	}
}

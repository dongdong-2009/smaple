using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Implement.Tests
{
	[TestClass()]
	public class FizzTests
	{
		[TestMethod()]
		public void FizzProcessTest()
		{
			var fizz = new Fizz(3);
			for (var i = 1; i <= 100; i++)
			{
				fizz.Process(i);
			}
		}
	}
}

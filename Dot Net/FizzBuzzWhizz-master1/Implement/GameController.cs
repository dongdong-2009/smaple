using System.Text;

namespace Implement
{
	/// <summary>
	/// 游戏控制者
	/// </summary>
	public class GameController
	{
		public string StartGame(int players, params int[] numbers)
		{
			var fizz = new Fizz(numbers[0]);
			var buzz = new Buzz(numbers[1]);
			var whizz = new Whizz(numbers[2]);
			fizz.NextFlow = buzz;
			buzz.NextFlow = whizz;
			var result = new StringBuilder();
			for (var i = 1; i <= players; i++)
			{
				fizz.Process(i);
			}
			return result.ToString();
		}
	}
}

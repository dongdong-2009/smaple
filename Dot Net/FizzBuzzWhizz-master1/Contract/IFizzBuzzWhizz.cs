
namespace Contract
{
	/// <summary>
	/// 三个特殊数的约束接口
	/// </summary>
	public interface IFizzBuzzWhizz
	{
		/// <summary>
		/// 特殊数
		/// </summary>
		int SpecialNumber { get; set; }

		/// <summary>
		/// 下一个流程
		/// </summary>
		IFizzBuzzWhizz NextFlow { get; set; }

		/// <summary>
		/// 对特殊数进行处理
		/// </summary>
		/// <returns></returns>
		void Process(int number, bool isHandle);
	}
}

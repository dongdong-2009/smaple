using System;

class Client
{
	public static void Main()
	{
		//重载是指方法名相同，方法的签名不同
		Console.WriteLine(Add(10,5));
		Console.WriteLine(Add("10","5"));	
	}

	public static string Add(string a, string b)
	{
		return a + " add " + b;
	}

	public static int Add(int a, int b)
	{
		return a+b;
	}
}
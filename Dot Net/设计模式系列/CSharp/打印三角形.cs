using System;

public class Hello
{
	public static void Main()
	{
		Console.Write("ÇëÊäÈëĞĞÊı:");
		int lines = int.Parse(Console.ReadLine());
		Console.WriteLine("");

		for(int i=1; i<=lines ; i++)
		{
			for(int k=1; k<= lines-i; k++)
				Console.Write(" ");

			for(int j=1; j<=i*2+1; j++)
				Console.Write("*");
			Console.WriteLine("");
		}
		Console.ReadLine();
	}
}

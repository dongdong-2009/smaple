using System;

public class JiuJiuBiao
{
	public static void Main(string[] args)
	{
		int i,j;
		for(i=1; i<10; i++)
		{
			for(j=1; j<10; j++)
			{
				Console.Write("{0:D1}*{1:D1}={2,2}  ", i, j, i*j);
			}
			Console.WriteLine("");
		}
		Console.ReadLine();
	}
}

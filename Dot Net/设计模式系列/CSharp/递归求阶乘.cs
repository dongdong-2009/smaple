using System;

class Factor
{
	public static void Main()
	{
		for(int i=1; i<=10; i++)
			Console.WriteLine("{0} �Ľ׳��� {1}",i, Factorial(i));
	}
	public static long Factorial(long n)
	{
		if(n == 1)
			return 1;
		else
			return n * Factorial(n-1);
	}
}

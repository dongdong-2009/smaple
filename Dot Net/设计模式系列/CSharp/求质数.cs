using System;

class Factor
{
	public static void Main()
	{
		for(int i=1; i<=100; i++)
			if(IsPrime(i))
                Console.WriteLine(i);
	}

	public static bool IsPrime(int n)
	{
		for(int i=2; i<=Math.Sqrt(n); i++)
			if(n%i == 0)
				return false;

		return true;
	}
}

using System;

class MethodCall
{
	public static void Main() 
	{
		/*
		 * 参数类型分为 in, ref, out 三种，默认为 in。
		 * in 类型在子方法中修改了对应变量后，主方法中的值不会发生改变。
		 * ref 类型在子方法中修改了对应变量后，主方法中的值也会发生改变。
		 * out 主方法中对应的变量不需要初始化。
		 * 
		 */		
		int a = 3, b = 4, c;
		Console.WriteLine("Before Method Call : a = {0}, b = {1}, c 未赋值", a, b);
		AMethod(a, ref b, out c);
		Console.WriteLine("After  Method Call : a = {0}, b = {1}, c = {2}", a, b, c);
	}

	public static void AMethod(int x, ref int y, out int z)
	{
		x = 7;
		y = 8;
		z = 9;
	}
}
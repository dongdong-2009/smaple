using System;

class MethodCall
{
	public static void Main() 
	{
		/*
		 * �������ͷ�Ϊ in, ref, out ���֣�Ĭ��Ϊ in��
		 * in �������ӷ������޸��˶�Ӧ�������������е�ֵ���ᷢ���ı䡣
		 * ref �������ӷ������޸��˶�Ӧ�������������е�ֵҲ�ᷢ���ı䡣
		 * out �������ж�Ӧ�ı�������Ҫ��ʼ����
		 * 
		 */		
		int a = 3, b = 4, c;
		Console.WriteLine("Before Method Call : a = {0}, b = {1}, c δ��ֵ", a, b);
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
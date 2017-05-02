using System;

class Base
{
	/*
	 * public �Ŀɷ��ʷ�Χ��������
	 * private �Ŀɷ��ʷ�Χ�ǵ�ǰ��
	 * protected �Ŀɷ��ʷ�Χ�ǵ�ǰ�༰������
	 */
	public string name = "Tom";
	private double salary = 1500;
	protected int age = 20;

	public virtual void ShowInfo()
	{
		Console.WriteLine(this.name);	//���ԣ���Ϊname�� public �͵�
		Console.WriteLine(this.salary);	//���ԣ�salary��private�ͣ���Base���п��Է���
		Console.WriteLine(this.age);	//���ԣ���Ϊage��protected�ͣ��������п��Է���
	}
}

class Derived : Base
{
	public override void ShowInfo()
	{
		Console.WriteLine(this.name);	//���ԣ���Ϊname�� public �͵�
		//Console.WriteLine(this.salary);	//�����ԣ�salary��private�ͣ�����Base���޷�����
		Console.WriteLine(this.age);	//���ԣ���Ϊage��protected�ͣ��������п��Է���
	}
}

class Client
{
	public static void Main()
	{
		Base b = new Base();
		Console.WriteLine(b.name);	//���ԣ���Ϊname�� public �͵�
		//Console.WriteLine(this.salary);	//�����ԣ�salary��private�ͣ�����Base���޷�����
		//Console.WriteLine(this.age);	//�����ԣ���Ϊage��protected�ͣ�Client����Base������

		Console.WriteLine("==========================");
		b.ShowInfo();
		Console.WriteLine("==========================");
		Derived d = new Derived();
		d.ShowInfo();
	}
}
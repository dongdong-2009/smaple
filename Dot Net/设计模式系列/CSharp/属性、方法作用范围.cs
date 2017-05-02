using System;

class Base
{
	/*
	 * public 的可访问范围是所有类
	 * private 的可访问范围是当前类
	 * protected 的可访问范围是当前类及其子类
	 */
	public string name = "Tom";
	private double salary = 1500;
	protected int age = 20;

	public virtual void ShowInfo()
	{
		Console.WriteLine(this.name);	//可以，因为name是 public 型的
		Console.WriteLine(this.salary);	//可以，salary是private型，在Base类中可以访问
		Console.WriteLine(this.age);	//可以，因为age是protected型，在子类中可以访问
	}
}

class Derived : Base
{
	public override void ShowInfo()
	{
		Console.WriteLine(this.name);	//可以，因为name是 public 型的
		//Console.WriteLine(this.salary);	//不可以，salary是private型，超出Base就无法访问
		Console.WriteLine(this.age);	//可以，因为age是protected型，在子类中可以访问
	}
}

class Client
{
	public static void Main()
	{
		Base b = new Base();
		Console.WriteLine(b.name);	//可以，因为name是 public 型的
		//Console.WriteLine(this.salary);	//不可以，salary是private型，超出Base就无法访问
		//Console.WriteLine(this.age);	//不可以，因为age是protected型，Client不是Base的子类

		Console.WriteLine("==========================");
		b.ShowInfo();
		Console.WriteLine("==========================");
		Derived d = new Derived();
		d.ShowInfo();
	}
}
using System;

public class Person
{
	public string name = "";
	public int age = 0;

	//Ĭ�Ϲ��캯��
	public Person()
	{
	}

	//���캯������(1)
	public Person(int Age)
	{
		this.age = Age;
	}

	//���캯������(2)
	public Person(int Age, string Name)
	{
		this.age = Age;
		this.name = Name;
	}

	public void ShowInfo()
	{
		Console.WriteLine("The name is : " + name);
		Console.WriteLine("The age is:" + age);
	}
}

class Client
{
	public static void Main()
	{
		Person p1 = new Person();
		p1.ShowInfo();

		Console.WriteLine("==========================");

		Person p2 = new Person(30);
		p2.ShowInfo();

		Console.WriteLine("==========================");
		Person p3 = new Person(30, "Tom");
		p3.ShowInfo();
	}
}
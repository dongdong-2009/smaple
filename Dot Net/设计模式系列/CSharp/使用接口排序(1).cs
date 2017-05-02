using System;
using System.Collections; 

public class Person : IComparable
{
	public int ID;
	public string Rank;

	public Person(int id, string rank)
	{ this.ID=id; this.Rank = rank; }

	#region IComparable Members

	/*
	 * IComparable 接口只有一个方法: CompareTo。CompareTo方法 
	 * 只接收一个object类型的参数，这意味着它可以接收任何类
	 * 型的数据（object是所有类的父类），这个方法会返回一
	 * 整型数值，含义如下：
	 * 
	 * 1) 小于零，当前实例（this）小于obj对象 
	 * 2) 等于零，当前实例（this）等于obj对象
	 * 3) 大于零，当前实例（this）大于obj对象 
	 * 
	 * Int32,Int16...,String,Decimal等数据类型都已经实现了IComparable接口
	 */
	public int CompareTo(object obj)
	{
		Person p = (Person)obj;
		return this.ID.CompareTo(p.ID);
	}

	#endregion
}

class SortArrayList 
{
	static void Main(string[] args) 
	{
		ArrayList list = new ArrayList();
		list.Add(new Person(6, "排长"));
		list.Add(new Person(3, "团长"));
		list.Add(new Person(4, "司令"));
		list.Add(new Person(5, "旅长"));
		list.Add(new Person(7, "连长"));
		list.Add(new Person(1, "军长"));
		list.Add(new Person(2, "营长"));
		list.Add(new Person(8, "师长"));

		list.Sort();

		Console.WriteLine("After Sorting");
		foreach (Person person in list) 
		{
			Console.WriteLine("ID: " + person.ID.ToString() + ", Rank: " + person.Rank);
		}
	}
}
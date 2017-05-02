using System;
using System.Collections; 

public enum enuSortOrder
{IDAsc, IDDesc, RankAsc, RankDesc}

public class Person : IComparable
{
	public static enuSortOrder intSortOrder = enuSortOrder.IDAsc;

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
		switch ((int)intSortOrder)
		{
			case (int)enuSortOrder.IDAsc:
				return this.ID.CompareTo(p.ID);
			case (int)enuSortOrder.IDDesc:
				return p.ID.CompareTo(this.ID);
			case (int)enuSortOrder.RankAsc:
				return RankCompare(this.Rank, p.Rank);
			case (int)enuSortOrder.RankDesc:
				return RankCompare(p.Rank, this.Rank);
			default:
				return this.ID.CompareTo(p.ID);
		}
	}

	private int RankCompare(string rank1, string rank2)
	{
		int intRank1 = ConvertRankToInt(rank1);
		int intRank2 = ConvertRankToInt(rank2);
		if(intRank1 < intRank2)
			return -1;
		else if(intRank1 == intRank2)
			return 0;
		else
			return 1;
	}

	private int ConvertRankToInt(string rank)
	{
		if(rank == "司令")
			return 8;
		else if(rank == "军长")
			return 7;
		else if(rank == "师长")
			return 6;
		else if(rank == "旅长")
			return 5;
		else if(rank == "团长")
			return 4;
		else if(rank == "营长")
			return 3;
		else if(rank == "连长")
			return 2;
		else
			return 1;
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
		Console.WriteLine("Sort By ID Asc:");
		foreach (Person person in list) 
		{
			Console.WriteLine("ID: " + person.ID.ToString() + ", Rank: " + person.Rank);
		}

		Console.WriteLine("----------------------------");
		Console.WriteLine("Sort By ID Desc:");

		Person.intSortOrder = enuSortOrder.IDDesc;
		list.Sort();
		foreach (Person person in list) 
		{
			Console.WriteLine("ID: " + person.ID.ToString() + ", Rank: " + person.Rank);
		}

		Console.WriteLine("----------------------------");
		Console.WriteLine("Sort By Rank Asc:");

		Person.intSortOrder = enuSortOrder.RankAsc;
		list.Sort();
		foreach (Person person in list) 
		{
			Console.WriteLine("ID: " + person.ID.ToString() + ", Rank: " + person.Rank);
		}

		Console.WriteLine("----------------------------");
		Console.WriteLine("Sort By Rank Desc:");

		Person.intSortOrder = enuSortOrder.RankDesc;
		list.Sort();
		foreach (Person person in list) 
		{
			Console.WriteLine("ID: " + person.ID.ToString() + ", Rank: " + person.Rank);
		}
	}	
}
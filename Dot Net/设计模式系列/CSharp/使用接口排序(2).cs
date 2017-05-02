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
	 * IComparable �ӿ�ֻ��һ������: CompareTo��CompareTo���� 
	 * ֻ����һ��object���͵Ĳ���������ζ�������Խ����κ���
	 * �͵����ݣ�object��������ĸ��ࣩ����������᷵��һ
	 * ������ֵ���������£�
	 * 
	 * 1) С���㣬��ǰʵ����this��С��obj���� 
	 * 2) �����㣬��ǰʵ����this������obj����
	 * 3) �����㣬��ǰʵ����this������obj���� 
	 * 
	 * Int32,Int16...,String,Decimal���������Ͷ��Ѿ�ʵ����IComparable�ӿ�
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
		if(rank == "˾��")
			return 8;
		else if(rank == "����")
			return 7;
		else if(rank == "ʦ��")
			return 6;
		else if(rank == "�ó�")
			return 5;
		else if(rank == "�ų�")
			return 4;
		else if(rank == "Ӫ��")
			return 3;
		else if(rank == "����")
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
		list.Add(new Person(6, "�ų�"));
		list.Add(new Person(3, "�ų�"));
		list.Add(new Person(4, "˾��"));
		list.Add(new Person(5, "�ó�"));
		list.Add(new Person(7, "����"));
		list.Add(new Person(1, "����"));
		list.Add(new Person(2, "Ӫ��"));
		list.Add(new Person(8, "ʦ��"));

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
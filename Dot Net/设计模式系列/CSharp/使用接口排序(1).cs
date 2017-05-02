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
		return this.ID.CompareTo(p.ID);
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

		Console.WriteLine("After Sorting");
		foreach (Person person in list) 
		{
			Console.WriteLine("ID: " + person.ID.ToString() + ", Rank: " + person.Rank);
		}
	}
}
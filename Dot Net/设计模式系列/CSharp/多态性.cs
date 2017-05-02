using System;

class Car
{
	public virtual void Drive()
	{ Console.WriteLine("Drive Car"); }
}
class Truck : Car
{
	public override void Drive()
	{ Console.WriteLine("Drive Truck");	}

}
class Client
{
	public static void Main()
	{
		Car c = new Truck();
		c.Drive();	//��̬�Ծ����Ž�����Truck��Drive����
	}
}

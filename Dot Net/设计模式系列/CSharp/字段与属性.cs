using System;

class Account
{
	private double balance = 0;		//字段
	public double Balance			//属性
	{
		get { return balance; }
		set { balance = value;}
	}
	/*=============================================================
	 * 我们可以通过修改get、set方法达到控制存取的目的。
	 * 例如：
	 * 
	 * 1)只读属性
	 * public double Balance			//属性
	 * {
	 *    get { return balance; }
	 *    set { }
	 * }
	 * 
	 * 2)读写控制
	 * public double Balance
	 * {
	 *    get 
	 *    {
	 *       if(Console.ReadLine()=="1234")
	 *          return balance;
	 *       else
	 *          return -9999999;
	 *    }
	 *    set { }
	 * }
	 * =============================================================
	 */

	public void Deposit(double n)
	{ this.balance += n; }

	public void WithDraw(double n)
	{ this.balance -= n; }
}

class Client
{
	public static void Main()
	{
		Account a = new Account();
		a.Balance = 1000;	// 可以读写属性，因为属性Balance是public型的
		//a.balance = 1000;	//不可以读写字段，因为字段balance是private型的

		a.WithDraw(500);
		a.Deposit(2000);
		Console.WriteLine(a.Balance);
	}
}
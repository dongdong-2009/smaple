using System;

class Account
{
	private double balance = 0;		//�ֶ�
	public double Balance			//����
	{
		get { return balance; }
		set { balance = value;}
	}
	/*=============================================================
	 * ���ǿ���ͨ���޸�get��set�����ﵽ���ƴ�ȡ��Ŀ�ġ�
	 * ���磺
	 * 
	 * 1)ֻ������
	 * public double Balance			//����
	 * {
	 *    get { return balance; }
	 *    set { }
	 * }
	 * 
	 * 2)��д����
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
		a.Balance = 1000;	// ���Զ�д���ԣ���Ϊ����Balance��public�͵�
		//a.balance = 1000;	//�����Զ�д�ֶΣ���Ϊ�ֶ�balance��private�͵�

		a.WithDraw(500);
		a.Deposit(2000);
		Console.WriteLine(a.Balance);
	}
}
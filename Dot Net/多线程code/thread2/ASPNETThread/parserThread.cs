using System;
using System.Threading;

namespace ASPNETThread
{
	public class parserThread
	{
		public delegate void Start (object obj);
		private class Argument
		{
			public object obj1;
			public Start s1;
			public void parse()
			{ 
				s1(obj1); 
			}
		}
		public static Thread CreateThread (Start s, Object arg1)
		{
			Argument arg = new Argument();
			arg.obj1 = arg1;
			arg.s1 = s;
			Thread t = new Thread (new ThreadStart (arg.parse));
			return t;
		}
	}
}

using System;

namespace ASPNETThread
{
	public interface IEmpDetails
	{
		string empName 
		{
			get;
			set;
		}
		int empId 
		{
			get;
			set;
		}
		string empAddress
		{
			get;
			set;
		}
		string empCity
		{
			get;
			set;
		}
		string empPin 
		{
			get;
			set;
		}
		string empState
		{
			get;
			set;
		}
		string empCountry
		{
			get;
			set;
		}
		string empEmail
		{
			get;
			set;
		}	
	}

	public class EmpDetails : IEmpDetails
	{
		private string empname;
		private int empid;
		private string empaddress;
		private string empcity;
		private string emppin;
		private string empstate;
		private string empemail;
		private string empcountry;
		
		public EmpDetails()
		{
		}
	
		public string empName 
		{
			get 
			{
				return empname;
			}
			set 
			{
				empname = value;
			}
		}
		public int empId 
		{
			get 
			{
				return empid;
			}
			set 
			{
				empid = value;
			}
		}
		public string empAddress
		{
			get 
			{
				return empaddress;
			}
			set 
			{
				empaddress = value;
			}
		}
		public string empCity 
		{
			get 
			{
				return empcity;
			}
			set 
			{
				empcity = value;
			}
		}
		public string empState
		{
			get 
			{
				return empstate;
			}
			set 
			{
				empstate = value;
			}
		}
		public string empPin
		{
			get 
			{
				return emppin;
			}
			set 
			{
				emppin = value;
			}
		}
		public string empCountry
		{
			get 
			{
				return empcountry;
			}
			set 
			{
				empcountry = value;
			}
		}
		public string empEmail
		{
			get 
			{
				return empemail;
			}
			set 
			{
				empemail = value;
			}
		}
	}
}

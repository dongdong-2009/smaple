using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace ASPNETThread 
{
	/// <summary>
	/// Global ��ժҪ˵����
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			CheckOnline online=new CheckOnline();
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			//�õ������û��б�
			User newuser=new User();
			newuser.name=Session.SessionID ;
			newuser.sessionid=Session.SessionID ;
			newuser.lasttime=newuser.curtime=DateTime.Now;
        
			OnLineUser alluser= new OnLineUser();
			if(alluser.AddUserToOnLine(newuser))
			{
				Response.Write ("�û���ӳɹ�<br>");
			}
			else
			{
				Response.Write ("�û����ʧ��<br>");
			}
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}


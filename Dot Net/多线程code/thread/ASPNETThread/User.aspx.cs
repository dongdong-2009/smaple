using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Threading;
namespace ASPNETThread
{
	/// <summary>
	/// User1 ��ժҪ˵����
	/// </summary>
	public class User1 : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			FreshPage();
			Page.RegisterStartupScript("","<script>window.setTimeout('location.href=location.href',10000);</script>");

		}
		private void FreshPage()
		{
			
			OnLineUser temp=new OnLineUser();        //����һ���û�����
			for (int i=0 ;i< temp.alluser.Count;i++)
			{
				User tmpuser=(User)temp.alluser[i];
				temp.CheckUserOnLine(Session.SessionID);
			}
          
		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}

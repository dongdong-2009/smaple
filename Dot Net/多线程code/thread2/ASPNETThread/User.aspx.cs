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
	/// User1 的摘要说明。
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
			
			OnLineUser temp=new OnLineUser();        //定义一个用户对象
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
			// CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}

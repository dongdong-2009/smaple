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

namespace ASPNETThread
{
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			OnLineUser temp= new OnLineUser();
    
			ArrayList alluser =temp.alluser;
			string str="";
			str += "<tr bgcolor=#ffff99>";
			str += "<td width=100 align=center class=coolbar>用户</td>";
			str += "<td align=center width=150 class=coolbar>登陆时间</td>";
			str += "<td align=center width=150 class=coolbar>最近时间</td>";
			str += "<td width=100 height=20 class=coolbar>当前位置</td>";
			str += "</tr>";
    
    
			for ( int i = 0 ; i < alluser.Count ; i++)
			{ 
				User tempuser=(User)alluser[i] ;
				str += "<tr bgcolor=white>";
				str += "<td>" + tempuser.name + "</td>";
				str += "<td>" + tempuser.lasttime + "</td>";
				str += "<td>" + tempuser.curtime + "</td>";
				str += "<Td>" + tempuser.iswhere + "</td>";
				str += "</tr>";
			}
			Label1.Text = str;
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

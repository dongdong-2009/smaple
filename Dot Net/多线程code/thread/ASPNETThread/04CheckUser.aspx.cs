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
			str += "<td width=100 align=center class=coolbar>�û�</td>";
			str += "<td align=center width=150 class=coolbar>��½ʱ��</td>";
			str += "<td align=center width=150 class=coolbar>���ʱ��</td>";
			str += "<td width=100 height=20 class=coolbar>��ǰλ��</td>";
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

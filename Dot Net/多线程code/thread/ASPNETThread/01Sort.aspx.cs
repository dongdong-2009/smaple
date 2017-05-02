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
	/// Sort ��ժҪ˵����
	/// </summary>
	public class SortPage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlNum;
		protected System.Web.UI.WebControls.DropDownList ddlThreadNum;
		protected System.Web.UI.WebControls.TextBox tbOut;
		protected System.Web.UI.WebControls.TextBox tbResult;
		protected System.Web.UI.WebControls.Label lbMsg;
		protected System.Web.UI.WebControls.Button btnSort;
		protected System.Web.UI.WebControls.Button btnClearOut;
		protected System.Web.UI.WebControls.Button btnClearTime;
	
		private int[] valueArray;
		private Random randomNumber = new Random();
		private static volatile bool swaped = true;
		private DateTime startTime;
		private DateTime endTime;
		private static volatile string strng = "";
		private Hashtable threadHolder = new Hashtable();
		private static long threadCounter = 0;


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Application["ThreadAndTime"]!=null)
			{
				tbResult.Text = Application["ThreadAndTime"].ToString();
				tbOut.Text = Application["OutTxt"].ToString();
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
			this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
			this.btnClearOut.Click += new System.EventHandler(this.btnClearOut_Click);
			this.btnClearTime.Click += new System.EventHandler(this.btnClearTime_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnClearOut_Click(object sender, System.EventArgs e)
		{
			Application["OutTxt"] = "";
			tbOut.Text = "";

		}

		private void btnClearTime_Click(object sender, System.EventArgs e)
		{
			Application["ThreadAndTime"] = "";
			tbResult.Text = "";
		}

		private void btnSort_Click(object sender, System.EventArgs e)
		{
			btnSort.Enabled = false;
			valueArray = new int[Convert.ToInt32(ddlNum.SelectedItem.Text.Trim())];
			threadHolder.Clear();
			valueArray.Initialize();
			threadCounter = 0;
			lbMsg.Text = "���������...";
			/* Insert value in to the valueArray */
			for(int i=0; i<valueArray.Length;i++)
			{	
				valueArray[i] = valueArray.Length-i;	
				//valueArray[i] = Convert.ToInt32(randomNumber.Next(1000));
			}
			/*	Start a timer to check the time to sort the array */
			startTime = DateTime.Now;
			/* Start threads to sort the values in the arry */
			for(int t=0; t< Convert.ToInt32(ddlThreadNum.SelectedItem.Text.Trim());t++)
			{
				Thread thread = new Thread(new ThreadStart(Sort));
				thread.Name = Convert.ToString(t);
				thread.Start();
			}
			Page.RegisterStartupScript("","<script>window.setTimeout('location.href=location.href',5000);</script>");

		}
		public void Sort()
		{	
			try
			{	
				while(true)
				{
					swaped = false;
					for (int j = 0; j<valueArray.Length-1; j++)
					{					
						lock(typeof(Thread))
						{	/* If the left-hand side value is greater swap values*/
							if(valueArray[j] > valueArray[j+1]) 
							{
								int T = valueArray[j];
								valueArray[j] = valueArray[j+1];
								valueArray[j+1] = T;
								swaped = true;
							}
						}
					}
					Thread.Sleep(1);
					if(!swaped) { break; }
				}
				Thread.CurrentThread.Abort();
			}		
			catch(Exception ex)
			{
					if( Interlocked.Increment(ref threadCounter) == Convert.ToInt64(ddlThreadNum.SelectedItem.Text.ToString().Trim()))
					Display();
			}
		}
	
		public void Display()
		{
			lbMsg.Text = "�������..";
			strng = "";
			endTime = DateTime.Now;
			for(int i=0; i< valueArray.Length; i++)
			{ strng += valueArray[i].ToString()+" "; }
			btnSort.Enabled = true;
			TimeSpan ts = endTime-startTime;
			Application["ThreadAndTime"]+="Threads: "+ddlThreadNum.SelectedItem.Text.ToString().Trim()+" ���ú�������"+Convert.ToString(ts.TotalMilliseconds)+"\r\n";
			Application["OutTxt"] = strng+"\r\n";
//			tbResult.Text +="Threads: "+ddlThreadNum.SelectedItem.Text.ToString().Trim()+" ���ú�������"+Convert.ToString(ts.TotalMilliseconds)+"\r\n";
//			tbOut.Text = strng+"\r\n";

		}
	}
}

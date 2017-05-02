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
using System.Net.Sockets;
namespace ASPNETThread
{
	/// <summary>
	/// ScanPort ��ժҪ˵����
	/// </summary>
	public class ScanPortPage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox urls;
		protected System.Web.UI.WebControls.Repeater ResultList;
		protected System.Web.UI.WebControls.Label info;
	
		private string _ipPorts;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		private ArrayList _ports;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if ( Scan( urls.Text ) ) 
			{
				info.Text = "Scan result:";
				Form1.Visible = false;
				ResultList.DataSource = ScanResults;
				ResultList.DataBind();
			}
		}
		/// <summary>
		/// The ArrayList of ScanPort objects.
		/// </summary>
		public ArrayList ScanResults 
		{
			get { return _ports; }
		}

		/// <summary>
		/// This method is called to parse the string containing the ip and port information.
		/// and creates An ArrayList of ScanPort objects.
		/// </summary>
		/// <param name="ipPorts">the string containing the ip and port information</param>
		public void parse(string ipPorts) 
		{
			
			string lPort = "";
			string lIP = "";
			int[] lPorts;
			string[] lPortRange;
			string[] lIPs = ipPorts.Split('\n');
			int ipIdx, portRangeIdx, portIdx;
			_ports = new ArrayList();

			// each ip/host, ex: www.microsoft.com:10-20,21,25,80,105-115
			for ( ipIdx = 0; ipIdx < lIPs.Length; ipIdx ++ ) 
			{

				string[] ipInfo = lIPs[ipIdx].Split(':');
				lIP = ipInfo[0];
				lPortRange = ipInfo[1].Split(',');

				// each port range, ex: 10-20,21,25,80,105-115
				for  ( portRangeIdx = 0; portRangeIdx < lPortRange.Length; portRangeIdx ++ ) 
				{

					// ex: 10-20
					if ( lPortRange[portRangeIdx].IndexOf("-") != -1 ) 
					{
						
						string[] lBounds = lPortRange[portRangeIdx].Split('-');
						int lStart = int.Parse( lBounds[0] );
						int lEnd = int.Parse( lBounds[1] );
						lPorts = new int[ lEnd - lStart + 1] ;
						int lIdx = 0;
						for ( portIdx = lStart; portIdx <= lEnd; portIdx ++ )
							lPorts[lIdx++] = portIdx;

					} 
					else 	// ex: 80
						lPorts = new int[] { int.Parse( lPortRange[portRangeIdx] ) };

					// create a ScanPort object for each port,
					// then add the object to the _ports ArrayList
					for ( int lIdx = 0; lIdx < lPorts.Length; lIdx ++ )
						_ports.Add( new ScanPort( lIP, lPorts[lIdx] ) );
				}
			}
		}
		/// <summary>
		/// This method creates, starts and manages the threads
		/// </summary>
		/// <param name="pIPs">The string containing the ip and port information passed from the portscanner.aspx</param>
		/// <returns></returns>
		public bool Scan(string pIPs) 
		{

			try 
			{

				// parse the string to ips and ports
				parse(pIPs);

				// create the threads
				Thread[] lThreads = new Thread[ _ports.Count ];
				int lIdx = 0;

				// add the ScanPort objects' scan method to the threads, then run them.
				for ( lIdx = 0; lIdx < _ports.Count; lIdx ++ ) 
				{
					lThreads[lIdx] = new Thread( new ThreadStart( ((ScanPort)_ports[lIdx]).Scan ) );
					lThreads[lIdx].Start();
				}

				// wait for all of them to finish
				for ( lIdx = 0; lIdx < lThreads.Length; lIdx ++ )
					lThreads[lIdx].Join();

				return true;

			} 
			catch 
			{
				return false;
			}
		}
	}
	/// <summary>
	/// This class does the work of connecting to the port.
	/// </summary>
	public class ScanPort 
	{

		private string _ip = "";
		private int _port = 0;
		private TimeSpan _timeSpent;
		private string _status = "Not scanned";
		
		public string ip 
		{
			get { return _ip; }
		}

		public int port 
		{
			get { return _port; }
		}

		public string status 
		{
			get { return _status; }
		}

		public TimeSpan timeSpent 
		{
			get { return _timeSpent; }
		}

		private ScanPort() {}

		public ScanPort(string ip, int port) 
		{
			_ip = ip;
			_port = port;
		}

		/// <summary>
		/// initiate a connection to the port.
		/// </summary>
		public void Scan() 
		{

			TcpClient scanningIpPort = new TcpClient();
			DateTime lStarted = DateTime.Now;
			try 
			{
				scanningIpPort.Connect( _ip, _port );
				scanningIpPort.Close();
				_status = "Open";
			} 
			catch 
			{
				_status = "Closed";
			}
			_timeSpent = DateTime.Now.Subtract( lStarted );
		}
	}
}

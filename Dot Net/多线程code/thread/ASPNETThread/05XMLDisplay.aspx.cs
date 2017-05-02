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
using System.Xml;
using System.Threading;
using Microsoft.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;
namespace ASPNETThread
{
	public class XMLDisplay : System.Web.UI.Page
	{
		protected Microsoft.Web.UI.WebControls.TreeView TreeView1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnProcess;
	
		private  RequestQueue req_queue;
		private  bool m_bAbort;
		protected System.Web.UI.WebControls.Button btnAddFile;
		protected System.Web.UI.HtmlControls.HtmlInputFile FileXML;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["queue"]==null)
			{
				req_queue = new RequestQueue();
				req_queue.setSize(5);
				m_bAbort = false;
				Session["queue"] = req_queue;
			}
			else
			{
				req_queue = (RequestQueue)Session["queue"];
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
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			
			QueueMonitorfunc();

		}
		public void QueueMonitorfunc()
		{
			
			if(isAbort())
			{
				return;
			}
			for(int i=0;i<req_queue.getSize();i++)
			{
				Object o = req_queue.getFile();
				if( (o  is FileInfo ))
				{
					FileInfo f = (FileInfo)req_queue.getFile();
					string filename = f.fName;
					parse(f);
					req_queue.remove();
				}
			}
		}
		public bool isAbort()
		{
			return m_bAbort;
		}
		private void parse(FileInfo info)
		{
			
			Thread t = parserThread.CreateThread (new parserThread.Start(parserMethod), info);
			t.Start ();
			t.Join (Timeout.Infinite);
		}

		public  void parserMethod(object obj)
		{
			FileInfo fInfo = (FileInfo)obj;
			process_xml((fInfo.fName));
		}

		public  void process_xml(String name)
		{
			try
			{
				XmlDocument doc = new XmlDocument();
				String fname = name;
				doc.Load(fname);
				XmlNodeList nList1;
				XmlNodeList nList2;
				XmlNodeList nList;
				nList=doc.GetElementsByTagName("EmpDataSet");
				for( int m =0;m<nList.Count;m++)
				{
					XmlElement element_main = (XmlElement)nList.Item(m);
					nList1 = element_main.ChildNodes ;
					for( int k =0;k<nList1.Count;k++)
					{
						XmlElement element_fchild = (XmlElement)nList1.Item(k);
						nList2 = element_fchild.ChildNodes ;
						IEmpDetails emp = new EmpDetails();
						if( m_bAbort)
						{
							return;
						}
						for( int j =0;j<nList2.Count;j++)
						{
							XmlElement child_element = (XmlElement)nList2.Item(j);
							if( child_element.Name == "Emp_id" )
							{
								emp.empId = System.Convert.ToInt32(child_element.InnerText);
							}
							if( child_element.Name == "Emp_Name" )
							{
								emp.empName = child_element.InnerText;
							}
							if( child_element.Name == "Emp_Address" )
							{
								emp.empAddress = child_element.InnerText;
							}
							if( child_element.Name == "Emp_City" )
							{
								emp.empCity = child_element.InnerText;
							}
							if( child_element.Name == "Emp_State" )
							{
								emp.empState = child_element.InnerText;
							}
							if( child_element.Name == "Emp_Pin" )
							{
								emp.empPin = child_element.InnerText;
							}
							if( child_element.Name == "Emp_Country" )
							{
								emp.empCountry = child_element.InnerText;
							}
							else 
								if( child_element.Name == "Emp_Email" )
							{
								emp.empEmail = child_element.InnerText;
							} 
						}
						populateTreeView(this,new ThreadEventArgs(emp));
					}
				}
			}
			catch(Exception exp)
			{
				Response.Write("Error...in displaying treeview "+exp.Message);
			}
		}
		private void populateTreeView(object sender, ThreadEventArgs e)
		{
			IEmpDetails ex = e.empDetails;
			TreeNode n = new TreeNode();
			n.ID = "EMP :"+ex.empId.ToString();
			TreeNode nChild = new TreeNode();
			nChild.Text = ex.empName;
			n.Nodes.Add(nChild);
			nChild = new TreeNode();
			nChild.Text = ex.empAddress;
			n.Nodes.Add(nChild);
			nChild = new TreeNode();
			nChild.Text = ex.empCity;
			n.Nodes.Add(nChild);
			nChild = new TreeNode();
			nChild.Text = ex.empState;
			n.Nodes.Add(nChild);
			nChild = new TreeNode();
			nChild.Text = ex.empPin;
			n.Nodes.Add(nChild);
			nChild = new TreeNode();
			nChild.Text = ex.empCountry;
			n.Nodes.Add(nChild);
			nChild = new TreeNode();
			nChild.Text = ex.empEmail;
			n.Nodes.Add(nChild);
			TreeView1.Nodes.Add(n);
		}

		private void btnAddFile_Click(object sender, System.EventArgs e)
		{
			req_queue = (RequestQueue)Session["queue"];
			string fileName = FileXML.PostedFile.FileName;
			FileInfo f = new FileInfo();
			if ( (fileName.Length != 0) && (fileName.EndsWith("xml")))
			{
				f.fName = fileName;
			}
			else
			{
				Response.Write("文件路径错误！");
				return;
			}
			req_queue.add(f);
			Session["queue"] = req_queue;
		}
	}
	public class ThreadEventArgs : EventArgs
	{
		IEmpDetails _empDetails;
		public IEmpDetails empDetails 
		{
			get 
			{
				return _empDetails;
			}
		}
		public ThreadEventArgs(IEmpDetails empDetails)
		{
			this._empDetails = empDetails;
		}
	}
}

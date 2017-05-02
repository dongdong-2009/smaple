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
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading;
using System.IO;



namespace ASPNETThread {

	public class SearchEngine : Page {

		// private member fields.
		private ArrayList _pages;
		protected System.Web.UI.WebControls.Label info;
		protected System.Web.UI.WebControls.Repeater ResultList;
		protected System.Web.UI.WebControls.TextBox keyword;
		protected System.Web.UI.WebControls.TextBox urls;
		protected System.Web.UI.WebControls.Button btnSearch;
		private TimeSpan _timeSpent;

		private void InitializeComponent()
		{
			this.btnSearch.Click += new System.EventHandler(this.Button1_Click);

		}

		/// <summary>
		///		Returns an ArrayList of WebPage objects,
		///		which contains the search results information.
		/// </summary>
		public ArrayList SearchResults {
			get { return _pages; }
		}

		/// <summary>
		///		A TimeSpan object. It lets us know how long was the entire search.
		/// </summary>
		public TimeSpan timeSpent {
			get { return _timeSpent; }
		}

		/// <summary>
		///		Start searching the web sites.
		/// </summary>
		/// <param name="keyword">The keyword to search for.</param>
		/// <param name="pURLs">List of URLs, seperated by the \n character.</param>
		/// <returns></returns>
		public bool SearchWebSites(string keyword, string pURLs) {

			// start the timer
			DateTime lStarted = DateTime.Now;
			_pages = new ArrayList();
			
			// split the urls string to an array
			string[] lURLs = pURLs.Split('\n');
			int lIdx;
			WebPage wp;

			// create the Thread array
			Thread[] t = new Thread[ lURLs.Length ];

			for ( lIdx = 0; lIdx < lURLs.Length; lIdx ++ ) {
				// create a WebPage object for each url
				wp = new WebPage(keyword, lURLs[lIdx]);
				// add it to the _pages ArrayList
				_pages.Add( wp );
				// pass the search() method of the new WebPage object
				//  to the ThreadStart object. Then pass the ThreadStart
				//  object to the Thread object.
				t[lIdx] = new Thread( new ThreadStart( wp.search ) );
				// start the Thread object, which executes the search().
				t[lIdx].Start();
			}

			for ( lIdx = 0; lIdx < _pages.Count; lIdx ++ ) {
				// waiting for all the Threads to finish.
				t[lIdx].Join();
			}

			// stop the timer.
			_timeSpent = DateTime.Now.Subtract( lStarted );
			return true;
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if ( SearchWebSites( keyword.Text, urls.Text ) ) 
			{
			
				info.Text = "Searched <font color=\"red\">" + SearchResults.Count + "</font> web page(s) ";
				info.Text += "on the keyword <font color=\"red\">\"" + keyword.Text + "</font>\". ";
				info.Text += "Total search time was <font color=\"red\">" + timeSpent + "</font>";
				this.Visible = false;
				ResultList.DataSource = SearchResults;
				ResultList.DataBind();
			}
		}

		
	}

	/// <summary>
	///		The class that contains information for each searched web page.
	/// </summary>
	public class WebPage {

		// private member fields.
		private int _instanceCount;
		private string _pageURL;
		private string _pageTitle;
		private string _keyword;
		private TimeSpan _timeSpent;

		/// <summary>
		///		A TimeSpan object. It lets us know how long was the page search.
		/// </summary>
		public TimeSpan timeSpent {
			get { return _timeSpent; }
		}

		/// <summary>
		///		How many times the search keyword appears on the page.
		/// </summary>
		public int instanceCount {
			get { return _instanceCount; }
		}

		/// <summary>
		///		The URL of the search page
		/// </summary>
		public string pageURL {
			get { return _pageURL; }
		}

		/// <summary>
		///		The title of the search page
		/// </summary>
		public string pageTitle {
			get { return _pageTitle; }
		}

		public WebPage() {}

		/// <summary>
		///		A parameterized constructor of the WebPage class.
		/// </summary>
		/// <param name="keyword">The keyword to search for.</param>
		/// <param name="pageURL">The URL to connect to.</param>
		public WebPage(string keyword, string pageURL) {
			_keyword = keyword;
			_pageURL = pageURL;
		}

		/// <summary>
		///		This method connects to the searching page, and retrieve the page content.
		///		It then passes the content to various private methods to perform other operations.
		/// </summary>
		public void search() {

			// start timing it
			DateTime lStarted = DateTime.Now;

			// create the WebRequest
			WebRequest webreq = WebRequest.Create( _pageURL );
			// connect to the page, and get its response
			WebResponse webresp = webreq.GetResponse();
			// wrap the response stream to a stream reader
			StreamReader sr = new StreamReader( webresp.GetResponseStream(), Encoding.ASCII );
			StringBuilder sb = new StringBuilder();
			string line;
			while ( ( line = sr.ReadLine()) != null ) {
				// append each line the server sends, to the string builder
				sb.Append(line);
			}
			sr.Close();
			string pageCode = sb.ToString();

			// get the page title
			_pageTitle = getPageTitle( pageCode );
			// get the amount of time the keyword appeared on the page
			_instanceCount = countInstance( getPureContent( pageCode ) );
			// stop the timer
			_timeSpent = DateTime.Now.Subtract( lStarted );
		}

		// this method uses the regular expression to match the keyword.
		// it then count the matches to find out how many times the keyword appeared on the page.
		private int countInstance(string str) {

			string lPattern = "(" + _keyword + ")";
			int count = 0;
			Regex rx = new Regex(lPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled );
			StringBuilder sb = new StringBuilder();
			Match mt;

			for ( mt = rx.Match(str); mt.Success; mt = mt.NextMatch() )
				count ++ ;

			return count;
		}

		// this method uses the regular expression to match the pattern that represent all
		//  string enclosed between ">" and "<". It removes all the HTML tags,
		//  and only returns the HTML decoded content string.
		private string getPureContent(string str) {
			string lPattern = ">(?:(?<c>[^<]+))";
			Regex rx = new Regex(lPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled );
			StringBuilder sb = new StringBuilder();
			Match mt;

			for ( mt = rx.Match(str); mt.Success; mt = mt.NextMatch() ) {
				sb.Append( HttpUtility.HtmlDecode( mt.Groups["c"].ToString() ) );
				sb.Append( " " );
			}

			return sb.ToString();
		}

		// this method uses the regular expression to match the pattern that represent the
		//  HTML Title tag of the page. It only returns the first match, and ignores the rest.
		private string getPageTitle(string str) {
			string lTitle = "";
			string lPattern = "(?:<\\s*title\\s*>(?<t>[^<]+))";
			Regex rx = new Regex(lPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled );
			Match mt = rx.Match(str);
			if ( mt.Success )
				try{
					lTitle = mt.Groups["t"].Value.ToString();
				} catch {
					lTitle = "";
				}
			else
				lTitle = "";
			return lTitle;
		}
	}
}
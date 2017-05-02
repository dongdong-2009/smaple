//---------------------------------------------------
//     Copyright (c) 2007 Jeffrey Bazinet, VWD-CMS 
//     http://www.vwd-cms.com/  All rights reserved.
//---------------------------------------------------

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Specialized;

namespace VwdCms
{
	// this enum tells ths SplitterBar what technique to 
	// use when hiding IFrames. IFrames capture mouse 
	// events which prevent the SplitterBar from functioning
	// properly
	public enum SplitterBarIFrameHiding
	{
		DoNotHide,     // don't hide IFrames, this is really for testing, debugging
		UseVisibility, // use iframe.style.visibility = "hidden"
		UseDisplay     // use iframe.style.display = "none"
	}

	public class SplitterBar : Panel, INamingContainer, IPostBackDataHandler
	{
		protected HtmlInputHidden hdnWidth;

		private string _leftResizeTargets = string.Empty; // semi-colon delimited
		private string _rightResizeTargets = string.Empty; // semi-colon delimited
		private bool _dynamicResizing = false;
		private string _backgroundColor = null;
		private string _backgroundColorHilite = null;
		private string _backgroundColorResizing = null;
		private string _backgroundColorLimit = null;
		private int _maxWidth = 0; // pixels, max size of LeftResizeTarget
		private int _minWidth = 0; // pixels, min size of LeftResizeTarget
		private int _totalWidth = 0; // pixels, Total size of Left + Right target widths
		private string _saveWidthToElement = null; // element id to save the width to (input text or hidden)
		private string _onResizeStart = null; // onmousedown fires this
		private string _onResize = null; // dynamic resizing and onmouseup fires this
		private string _onResizeComplete = null; // onmouseup fires this
		private string _onDoubleClick = null; 
		private int _splitterWidth = 6;
		private string _debugElement = null;
		private SplitterBarIFrameHiding _iframeHiding = SplitterBarIFrameHiding.UseVisibility;

		protected override void OnLoad(EventArgs e)
		{
			this.Page.RegisterRequiresPostBack(this);
			AddCompositeControls();
			this.RegisterPageStartupScript();
			SetTargetControlWidths();
			base.OnLoad(e);
		}

		private void SetTargetControlWidths()
		{
			if (this.Page.IsPostBack)
			{
				Control[] targets = null;
				string width = null;

				// set the width of the controls in the 
				// LeftResizeTargets
				width = this.LeftColumnWidth;
				if (!string.IsNullOrEmpty(width))
				{
					targets = GetTargetControls(this.LeftResizeTargets);
					if (targets != null && targets.Length > 0)
					{
						foreach (Control c in targets)
						{
							SetControlWidth(c, width);
						}
					}
				}

				// set the width of the controls in the 
				// RightResizeTargets
				width = this.RightColumnWidth;
				if (!string.IsNullOrEmpty(width))
				{
					targets = GetTargetControls(this.RightResizeTargets);
					if (targets != null && targets.Length > 0)
					{
						foreach (Control c in targets)
						{
							SetControlWidth(c, width);
						}
					}
				}
			}
		}

		private void SetControlWidth(Control control, string width)
		{
			if (control != null)
			{
				if (control is WebControl)
				{
					WebControl wc = (WebControl)control;
					wc.Style.Add("width", width);
				}
				else if (control is HtmlControl)
				{
					HtmlControl hc = (HtmlControl)control;
					hc.Style.Add("width", width);
				}
			}
		}

		private Control[] GetTargetControls(string controlIds)
		{
			// warning: the controls array that this method returns
			// may contain null values if a control is not found
			Control[] controls = null;
			string[] ids = GetTargetControlIds(controlIds);

			Control container = this.Page;
			if (this.NamingContainer != null && this.NamingContainer != this.Page)
			{
				container = this.NamingContainer;
			}

			if ( ids != null && ids.Length > 0 )
			{
				int i = 0;
				Control c = null;
				string id = null;
				controls = new Control[ids.Length];
				for ( i = 0; i < ids.Length; i++ )
				{
					id = ids[i];
					if (!string.IsNullOrEmpty(id))
					{
						c = container.FindControl(id);
						if (c != null)
						{
							controls[i] = c;
						}
					}
				}
			}
			return controls;
		}

		private string[] GetTargetControlIds(string controlIds)
		{
			string[] ids = null;
			if (!string.IsNullOrEmpty(controlIds))
			{
				ids = controlIds.Split(';');
			}
			return ids;
		}

		private void AddCompositeControls()
		{
			// save the width to a hidden field so that
			// on PostBacks the width will be available
			if (this.hdnWidth == null)
			{
				this.hdnWidth = new HtmlInputHidden();
				this.hdnWidth.ID = "hdnWidth";
			}
			this.Controls.Add(this.hdnWidth);
		}

		protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
		{
			AddCompositeControls();

			string leftColWidth = postCollection[this.hdnWidth.UniqueID];
			this.hdnWidth.Value = leftColWidth;
			return true;
		}

		public string LeftColumnWidth
		{
			get { return this.hdnWidth.Value; }
		}
		public string RightColumnWidth
		{
			get 
			{ 
				string rcWidth = string.Empty;
				int total = this.TotalWidth;
				if ( total != 0 )
				{
					int width = Convert.ToInt32(this.LeftColumnWidth.Replace("px",string.Empty)); 
					width = total - width;
					width = (width < 1) ? 1 : width;
					rcWidth = width.ToString() + "px";
				}
				return rcWidth;
			}
		}
		public string SaveWidthToElement
		{
			get { return _saveWidthToElement; }
			set { _saveWidthToElement = value; }
		}

		public string LeftResizeTargets
		{
			get { return _leftResizeTargets; }
			set { _leftResizeTargets = value; }
		}

		public string RightResizeTargets
		{
			get { return _rightResizeTargets; }
			set { _rightResizeTargets = value; }
		}

		public bool DynamicResizing
		{
			get { return _dynamicResizing; }
			set { _dynamicResizing = value; }
		}

		public string BackgroundColor
		{
			get { return _backgroundColor; }
			set 
			{ 
				_backgroundColor = value;
				this.Style.Add("background-color", _backgroundColor);
			}
		}

		public string BackgroundColorHilite
		{
			get { return _backgroundColorHilite; }
			set { _backgroundColorHilite = value; }
		}

		public string BackgroundColorResizing
		{
			get { return _backgroundColorResizing; }
			set { _backgroundColorResizing = value; }
		}

		public string BackgroundColorLimit
		{
			get { return _backgroundColorLimit; }
			set { _backgroundColorLimit = value; }
		}

		public string OnResizeStart
		{
			get { return _onResizeStart; }
			set { _onResizeStart = value; }
		}

		public string OnResize
		{
			get { return _onResize; }
			set { _onResize = value; }
		}

		public string OnResizeComplete
		{
			get { return _onResizeComplete; }
			set { _onResizeComplete = value; }
		}

		public string OnDoubleClick
		{
			get { return _onDoubleClick; }
			set { _onDoubleClick = value; }
		}

		public string DebugElement
		{
			get { return _debugElement; }
			set { _debugElement = value; }
		}

		public int MinWidth
		{
			get { return _minWidth; }
			set { _minWidth = value; }
		}

		public int MaxWidth
		{
			get { return _maxWidth; }
			set { _maxWidth = value; }
		}

		public int TotalWidth
		{
			get { return _totalWidth; }
			set { _totalWidth = value; }
		}

		public int SplitterWidth
		{
			get { return _splitterWidth; }
			set { _splitterWidth = value; }
		}

		public SplitterBarIFrameHiding IFrameHiding
		{
			get { return _iframeHiding; }
			set { _iframeHiding = value; }
		}

		private void RegisterPageStartupScript()
		{
			StringBuilder sb = new StringBuilder();
			const string newline = "\r\n";

			sb.Append("<script type=\"text/javascript\"> <!-- ");
			sb.Append(newline);

			string id = "sbar_" + this.ClientID;

			// createNew / constructor
			sb.Append("var ");
			sb.Append(id);
			sb.Append("= VwdCmsSplitterBar.createNew(\"");
			sb.Append(this.ClientID);
			sb.Append("\",");
			if ( this.DebugElement == null )
			{
				sb.Append(" null);");
			}
			else
			{
				sb.Append("\"");
				sb.Append(this.DebugElement);
				sb.Append("\");");
			}
			sb.Append(newline);

			// set the namingContainerId
			if (this.NamingContainer != null && this.NamingContainer != this.Page )
			{
				string prefix = this.NamingContainer.ClientID
					+ this.ClientIDSeparator.ToString();

				sb.Append(id);
				sb.Append(".namingContainerId = \"");
				sb.Append(prefix);
				sb.Append("\";");
				sb.Append(newline);
			}

			// set the debugElementId
			if (!string.IsNullOrEmpty(this.DebugElement))
			{
				sb.Append(id);
				sb.Append(".debugElementId = \"");
				sb.Append(this.DebugElement);
				sb.Append("\";");
				sb.Append(newline);
			}

			// set the left resize target Ids
			sb.Append(id);
			sb.Append(".leftResizeTargetIds = \"");
			sb.Append(this.LeftResizeTargets);
			sb.Append("\";");
			sb.Append(newline);

			// set the right resize target Ids
			sb.Append(id);
			sb.Append(".rightResizeTargetIds = \"");
			sb.Append(this.RightResizeTargets);
			sb.Append("\";");
			sb.Append(newline);

			// IFrameHiding
			sb.Append(id);
			sb.Append(".iframeHiding = \"");
			sb.Append(this.IFrameHiding.ToString());
			sb.Append("\";");
			sb.Append(newline);

			if (this.SplitterWidth != 6)
			{
				sb.Append(id);
				sb.Append(".splitterWidth = new Number(");
				sb.Append(this.SplitterWidth.ToString());
				sb.Append(");");
				sb.Append(newline);
			}

			if (!string.IsNullOrEmpty(this.OnResizeStart))
			{
				sb.Append(id);
				sb.Append(".onResizeStart = ");
				sb.Append(this.OnResizeStart);
				sb.Append(";");
				sb.Append(newline);
			}

			if (!string.IsNullOrEmpty(this.OnResize))
			{
				sb.Append(id);
				sb.Append(".onResize = ");
				sb.Append(this.OnResize);
				sb.Append(";");
				sb.Append(newline);
			}

			if (!string.IsNullOrEmpty(this.OnResizeComplete))
			{
				sb.Append(id);
				sb.Append(".onResizeComplete = ");
				sb.Append(this.OnResizeComplete);
				sb.Append(";");
				sb.Append(newline);
			}

			if (!string.IsNullOrEmpty(this.OnDoubleClick))
			{
				sb.Append(id);
				sb.Append(".OnDoubleClick = ");
				sb.Append(this.OnDoubleClick);
				sb.Append(";");
				sb.Append(newline);
			}

			if (!string.IsNullOrEmpty(this.SaveWidthToElement))
			{
				sb.Append(id);
				sb.Append(".saveWidthToElement = \"");
				sb.Append(this.SaveWidthToElement);
				sb.Append("\";");
				sb.Append(newline);
			}

			if (this.MinWidth > 0)
			{
				sb.Append(id);
				sb.Append(".minWidth = ");
				sb.Append(this.MinWidth.ToString());
				sb.Append(";");
				sb.Append(newline);
			}

			if (this.MaxWidth > 0)
			{
				sb.Append(id);
				sb.Append(".maxWidth = ");
				sb.Append(this.MaxWidth.ToString());
				sb.Append(";");
				sb.Append(newline);
			}

			if (this.TotalWidth > 0)
			{
				sb.Append(id);
				sb.Append(".totalWidth = ");
				sb.Append(this.TotalWidth.ToString());
				sb.Append(";");
				sb.Append(newline);
			}

			if (this.DynamicResizing)
			{
				sb.Append(id);
				sb.Append(".liveResize = true;");
				sb.Append(newline);
			}
			if (!string.IsNullOrEmpty(this.BackgroundColor))
			{
				sb.Append(id);
				sb.Append(".SetBackgroundColor(\"");
				sb.Append(this.BackgroundColor);
				sb.Append("\");");
				sb.Append(newline);
			}

			if (!string.IsNullOrEmpty(this.BackgroundColorHilite))
			{
				sb.Append(id);
				sb.Append(".backgroundColorHilite = \"");
				sb.Append(this.BackgroundColorHilite);
				sb.Append("\";");
				sb.Append(newline);
			}
			if (!string.IsNullOrEmpty(this.BackgroundColorResizing))
			{

				sb.Append(id);
				sb.Append(".backgroundColorResizing = \"");
				sb.Append(this.BackgroundColorResizing);
				sb.Append("\";");
				sb.Append(newline);
			}
			if (!string.IsNullOrEmpty(this.BackgroundColorLimit))
			{

				sb.Append(id);
				sb.Append(".backgroundColorLimit = \"");
				sb.Append(this.BackgroundColorLimit);
				sb.Append("\";");
				sb.Append(newline);
			}


			// do this last...
			// be sure to call configure after all of the 
			// configuration properties have been set
			sb.Append(id);
			sb.Append(".configure();");
			sb.Append(newline);

			sb.Append("// -->");
			sb.Append(newline);
			sb.Append("</script>");
			sb.Append(newline);

			this.Page.ClientScript.RegisterStartupScript(this.GetType(),
				this.ClientID + "_VwdCmsSplitterBarStartupScript", sb.ToString());
		}

		// IPostBackDataHandler Members

		bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
		{
			return this.LoadPostData(postDataKey, postCollection);
		}

		void IPostBackDataHandler.RaisePostDataChangedEvent()
		{
			//not implemented
		}
	}
}
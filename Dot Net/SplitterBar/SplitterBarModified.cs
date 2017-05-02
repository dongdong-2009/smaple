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

            #region added by zhouming  string str_addedByZhouMing
            string str_addedByZhouMing = string.Empty;
            str_addedByZhouMing = @"            
            //------------------------------------------------------------------------------
            // <copyright author='Jeffrey Bazinet' company='VWD-CMS'>
            //	Copyright (c) VWD-CMS (http://www.vwd-cms.com/).
            //  All rights reserved.
            // </copyright>
            //------------------------------------------------------------------------------

            // define the array of VwdCmsSplitterBars on the page
            var _vwdCmsSplitterBars = new Array();
            var _activeSplitterBar = null;
            var _isIE = (document.all) ? true : false;

            // define the VwdCmsSplitterBar 'class'
            function VwdCmsSplitterBar(splitter)
            {
	            this.id = splitter.id; 
	            this.debugElementId = "";
	            this.debug = null;
	            this.primaryResizeTarget = null;
	            this.liveResize = false;
	            this.splitterBar = splitter;
	            this.leftResizeTargetIds = "";  // semi-colon delimited list of ids
	            this.rightResizeTargetIds = ""; // semi-colon delimited list of ids
	            this.leftResizeTargets = null;  // array of target elements
	            this.rightResizeTargets = null; // array of target elements
	            this.offsetLeft = new Number(0);
	            this.isResizing = false;
	            this.backgroundColor = 'lightsteelblue';  
	            this.backgroundColorHilite = 'lightsteelblue'; 
	            this.backgroundColorResizing = 'lightsteelblue'; 
	            this.backgroundColorLimit = 'firebrick';
	            this.maxWidth = new Number(0);
	            this.minWidth = new Number(0);
	            this.totalWidth = new Number(0);
	            this.saveWidthToElement = null;
	            this.splitterWidth = new Number(6);
	            this.onResizeStart = null; // ( onmousedown, resizing starting )
	            this.onResize = null; // ( dynamic resizing, resizing complete)
	            this.onResizeComplete = null; // ( onmouseup, resizing complete)
	            this.onDoubleClick = null;
	            this.hdnWidth = document.getElementById(splitter.id + '_hdnWidth');
	            this.iframeHiding = 'UseVisibility';
	            this.iframes = null;
	            this.iframeStates = null;
	            this.namingContainerId = '';
            }

            // define the 'instance' methods
            VwdCmsSplitterBar.prototype.SetBackgroundColor = VwdCmsSplitterBar_SetBackgroundColor;
            VwdCmsSplitterBar.prototype.configure = VwdCmsSplitterBar_configure;
            VwdCmsSplitterBar.prototype.show = VwdCmsSplitterBar_show;
            VwdCmsSplitterBar.prototype.hide = VwdCmsSplitterBar_hide;
            VwdCmsSplitterBar.prototype.setTargetWidth = VwdCmsSplitterBar_setTargetWidth;
            VwdCmsSplitterBar.prototype.drag = VwdCmsSplitterBar_drag;
            VwdCmsSplitterBar.prototype.onmousedown = VwdCmsSplitterBar_onmousedown;
            VwdCmsSplitterBar.prototype.onmouseup = VwdCmsSplitterBar_onmouseup;
            VwdCmsSplitterBar.prototype.ondblclick = VwdCmsSplitterBar_ondblclick;
            VwdCmsSplitterBar.prototype.showIFrames = VwdCmsSplitterBar_showIFrames;
            VwdCmsSplitterBar.prototype.hideIFrames = VwdCmsSplitterBar_hideIFrames;

            // define the 'static' methods
            VwdCmsSplitterBar.createNew = VwdCmsSplitterBar_createNew;
            VwdCmsSplitterBar.getById = VwdCmsSplitterBar_getById;
            VwdCmsSplitterBar.getCurrent = VwdCmsSplitterBar_getCurrent;
            VwdCmsSplitterBar.reconfigure = VwdCmsSplitterBar_reconfigure;
            VwdCmsSplitterBar.setLiveResize = VwdCmsSplitterBar_setLiveResize;
            VwdCmsSplitterBar.setDebug = VwdCmsSplitterBar_setDebug;

            // create the property set for backgroundColor
            function VwdCmsSplitterBar_SetBackgroundColor(value)
            {
                this.backgroundColor = value;
                this.splitterBar.style.backgroundColor = value;
            }

            // create the createNew static method
            function VwdCmsSplitterBar_createNew(splitterId)
            {
	            var splitter = document.getElementById(splitterId);
	            var sbar = new VwdCmsSplitterBar(splitter);
	            _vwdCmsSplitterBars[_vwdCmsSplitterBars.length] = sbar;
	            return sbar;
            }

            // create the getById static method
            function VwdCmsSplitterBar_getById(id)
            {
	            var sbar = null;
	            var sbarId = id; 
	            for ( var i = 0; i < _vwdCmsSplitterBars.length; i++ )
	            {
		            sbar = _vwdCmsSplitterBars[i];
		            if ( sbar.id == sbarId )
		            {
			            break;
		            }
	            }
	            return sbar;
            }

            // create the getCurrent static method
            function VwdCmsSplitterBar_getCurrent()
            {
	            return _activeSplitterBar;
            }

            // create the reinitialize static method
            function VwdCmsSplitterBar_reconfigure()
            {
	            for ( var i = 0; i < _vwdCmsSplitterBars.length; i++ )
	            {
		            _vwdCmsSplitterBars[i].configure();
	            }	
            }

            // create the setLiveResize static method
            function VwdCmsSplitterBar_setLiveResize(setting)
            {
	            for ( var i = 0; i < _vwdCmsSplitterBars.length; i++ )
	            {
		            _vwdCmsSplitterBars[i].liveResize = setting;
	            }	
            }

            // create the setDebug static method
            function VwdCmsSplitterBar_setDebug(debugId, namingContainerId)
            {
	            var txt = null;
	            if ( debugId ) 
	            {
		            txt = document.getElementById(namingContainerId + debugId);
		            if ( txt == null )
		            {
			            txt = document.getElementById(debugId);
		            }
	            }
	            for ( var i = 0; i < _vwdCmsSplitterBars.length; i++ )
	            {
		            _vwdCmsSplitterBars[i].debug = txt;
	            }	
            }
            	
            // create the initialize method
            function VwdCmsSplitterBar_configure()
            {
	            // the purpose of the configure method is to setup initial 
	            // properties on the splitterbar as well as calculate some
	            // important values rather than calculating them over and 
	            // over again in methods like 'drag', 'onmousedown', 
	            // 'onmouseup', and 'setTargetWidth' -  the less work 
	            // we have to do inside these methods, the better the UI 
	            // performance will be for the user.
	            var sbar = null;
	            if ( this.splitterBar )
	            {
		            sbar = this;
	            }
	            else
	            {
		            sbar = VwdCmsSplitterBar.getById(this.id);
	            }
            	
	            if ( sbar )
	            {
		            // setup the debug element, expecting an ID for a textarea element
		            if ( sbar.debugElementId )
		            {
			            var dbg = document.getElementById(sbar.namingContainerId + sbar.debugElementId);
			            if ( dbg == null )
			            {
				            dbg = document.getElementById(sbar.debugElementId);
			            }
			            sbar.debug = dbg;
		            }
		            if ( sbar.debug ) 
		            { 
			            sbar.debug.value = 'configuring ' + sbar.id + '\r\n' + sbar.debug.value;
		            }
            		
		            // setup the splitterBar control
		            var splitter = sbar.splitterBar;
            		
		            // get the left resize target elements from the Ids
		            sbar.leftResizeTargets = getTargets(sbar.leftResizeTargetIds, sbar.namingContainerId);
            		
		            // get the right resize target elements from the Ids
		            sbar.rightResizeTargets = getTargets(sbar.rightResizeTargetIds, sbar.namingContainerId);

		            // get the primary resize target element (first one in leftResizeTargets)
		            var target = null;
		            if ( sbar.leftResizeTargets && sbar.leftResizeTargets.length > 0 )
		            {
			            target = sbar.leftResizeTargets[0];
			            sbar.primaryResizeTarget = target;
		            }
            		
		            if ( splitter && target )
		            {
			            splitter.style.margin = '0px';
			            splitter.style.padding = '0px';
            			
			            splitter.onmousedown = sbar.onmousedown;
			            splitter.onmouseup = sbar.onmouseup;
			            splitter.onmouseover = sbar.show; 
			            splitter.onmouseout = sbar.hide;
            			
			            if ( sbar.onDoubleClick != null )
			            {
				            splitter.ondblclick = sbar.onDoubleClick; 
			            }
			            else
			            {
				            splitter.ondblclick = sbar.ondblclick; 
			            }
            			
			            splitter.style.backgroundColor = sbar.backgroundColor;
			            splitter.style.cursor = 'e-resize';
			            splitter.style.position = 'absolute';
			            splitter.style.width = sbar.splitterWidth + 'px';
			            splitter.style.zIndex = 0;
            			
			            // determine the min and max widths
			            var op = target.offsetParent;
			            if ( sbar.maxWidth == 0 )
			            {
				            sbar.maxWidth = getInt(op.offsetWidth);
				            sbar.maxWidth -= sbar.splitterWidth;
				            sbar.maxWidth -= getInt(op.style.borderLeftWidth);
				            sbar.maxWidth -= getInt(op.style.borderRightWidth);
				            sbar.maxWidth -= getInt(splitter.style.borderLeftWidth);
				            sbar.maxWidth -= getInt(splitter.style.borderRightWidth);
			            }
            			
			            // set the top location of the SplitterBar
			            var top = getOffsetTop(target);
			            splitter.style.top = top + 'px';
            			
			            // set the left location of the SplitterBar
			            var offsetLeft = getOffsetLeft(target);
			            sbar.offsetLeft = offsetLeft;
            			
			            var left = offsetLeft;
			            left += getInt(target.offsetWidth);
			            splitter.style.left = left + 'px';
            			
			            // set the height of the SplitterBar
			            var height = getInt(target.clientHeight);
			            height += getInt(target.style.borderTopWidth);
			            height += getInt(target.style.borderBottomWidth);
			            splitter.style.height = height + 'px';
            			
			            // output to the debug window
			            if ( sbar.debug ) 
			            { 
				            sbar.debug.value = sbar.id + '.splitterBar.style.top=' 
					            + splitter.style.top + '\r\n' + sbar.debug.value;
				            sbar.debug.value = sbar.id + '.offsetLeft=' 
					            + sbar.offsetLeft + '\r\n' + sbar.debug.value;
				            sbar.debug.value = sbar.id + '.splitterBar.style.left=' 
					            + splitter.style.left + '\r\n' + sbar.debug.value;
				            sbar.debug.value = sbar.id + '.splitterBar.style.height=' 
					            + splitter.style.height + '\r\n' + sbar.debug.value;
			            }
            			
			            // handle window resizing
			            // this is problematic in Firefox because the event
			            // does not fire until the resizing is complete, so 
			            // if the SplitterBar's backcolor is not set to Transparent,
			            // it will display in the wrong location while the resizing
			            // is happening.
			            window.onresize = VwdCmsSplitterBar.reconfigure; 
		            }
	            }	
            }

            // create the show method
            function VwdCmsSplitterBar_show()
            {
	            var sbar = VwdCmsSplitterBar.getById(this.id);
	            if (sbar && !sbar.isResizing)
	            {
		            sbar.splitterBar.style.backgroundColor=sbar.backgroundColorHilite;
	            }
            }

            // create the hide method
            function VwdCmsSplitterBar_hide()
            {
	            var sbar = VwdCmsSplitterBar.getById(this.id);
	            if (sbar && !sbar.isResizing)
	            {
		            sbar.splitterBar.style.backgroundColor=sbar.backgroundColor;
	            }
            }

            // create the setTargetWidth method
            function VwdCmsSplitterBar_setTargetWidth(sbar)
            {
	            if ( sbar == null )
	            {
		            sbar = VwdCmsSplitterBar.getCurrent();
	            }
	            if ( sbar )
	            {
		            var width = 0;
		            // get the primary target ( the first one in LeftResizeTargets)
		            var target = sbar.primaryResizeTarget; // sbar.leftResizeTargets[0];
		            if ( target )
		            {		
			            // calculate the width based on the splitterbar's location
			            width = getInt(sbar.splitterBar.style.left);
			            width -= getInt(sbar.offsetLeft);
			            width -= getInt(target.style.borderLeftWidth);
			            width -= getInt(target.style.borderRightWidth);
			            // do not set the width to 0, 1 is the minimum
			            if ( width < 1 ) { width = 1; }

			            // set the width of the target element
			            target.style.width = width + 'px';
            			
			            // set the width value to the hidden field hdnWidth
			            if ( sbar.hdnWidth )
			            {
				            sbar.hdnWidth.value = width + 'px';
			            }
            			
			            // set the width value to the saveWidthToElement
			            if ( sbar.saveWidthToElement )
			            {
				            var elmWidth = document.getElementById(sbar.namingContainerId + sbar.saveWidthToElement);
				            if ( elmWidth == null )
				            {
					            elmWidth = document.getElementById(sbar.saveWidthToElement);
				            }
				            if ( elmWidth ) 
				            {
					            elmWidth.value = width + 'px';
				            }
			            }
            			
			            // output some debugging info
			            if ( sbar.debug ) 
			            { 
				            sbar.debug.value = sbar.id + '.leftResizeTargets[0].style.width=' 
				            + target.style.width + '\r\n' + sbar.debug.value;
			            }
            			
			            // resize any other LeftResizeTarget elements
			            if ( sbar.leftResizeTargets && sbar.leftResizeTargets.length > 1 )
			            {
				            for (var i = 1; i < sbar.leftResizeTargets.length; i++)
				            {
					            target = sbar.leftResizeTargets[i];
					            target.style.width = width + 'px';
				            }
			            }
            			
			            // resize the RightResizeTarget elements
			            // Note: this calculation requires that the TotalWidth property is 
			            // set so we can determine the width of the RightResizeTarget elements
			            if ( sbar.totalWidth > 0 && sbar.rightResizeTargets 
				            && sbar.rightResizeTargets.length > 0 )
			            {
				            width = sbar.totalWidth - width - sbar.splitterWidth; 
				            for (var i = 0; i < sbar.rightResizeTargets.length; i++)
				            {
					            target = sbar.rightResizeTargets[i];
					            target.style.width = width + 'px';
				            }
			            }
            			
			            // always reconfigure when not in IE because
			            // we don't get enough resize events
			            if ( !_isIE )
			            {
				            VwdCmsSplitterBar.reconfigure();
			            }
            			
			            // fire the onResize event
			            if ( sbar.onResize )
			            {
				            sbar.onResize(sbar, width);
			            }
		            }
	            }
            }		

            // create the drag method
            function VwdCmsSplitterBar_drag(evnt)
            {
	            evnt = evnt ? evnt : event;
	            if ( evnt )
	            {
		            var sbar = VwdCmsSplitterBar.getCurrent();
		            if ( sbar && sbar.isResizing )
		            {
			            evnt.cancelBubble = true;
			            evnt.returnValue = false;
            						
			            // get the new location to move the SplitterBar to 
			            // from the event object
			            var x = getInt(evnt.pageX ? evnt.pageX : evnt.clientX);
            			
			            // adjust for the width of the SplitterBar and
			            // keep the SplitterBar centered on the cursor	
			            pixX = sbar.splitterWidth/2; 
			            x = x - pixX; 
            			
			            // determine the min and max allowable locations
			            var minX = getInt(sbar.offsetLeft);
			            minX += getInt(sbar.minWidth);		
            			
			            var maxX = getInt(sbar.offsetLeft);
			            maxX += getInt(sbar.maxWidth);
            			
			            // output some debug info
			            if ( sbar.debug ) 
			            { 
				            sbar.debug.value = sbar.id + ' resizing: minX=' + minX + '\r\n' + sbar.debug.value;
				            sbar.debug.value = sbar.id + ' resizing: maxX=' + maxX + '\r\n' + sbar.debug.value;
				            sbar.debug.value = sbar.id + ' resizing: x=' + x + '\r\n' + sbar.debug.value;
			            }

			            // check to see if this location is allowed,
			            // otherwise, set the Limit color to indicate that the 
			            // min or max width has been reached
			            if ( ( minX == 0 || x >= minX ) && ( maxX == 0 || x <= maxX) )
			            {
				            sbar.splitterBar.style.backgroundColor = sbar.backgroundColorResizing;
				            sbar.splitterBar.style.left = x + 'px';
            				
				            if ( sbar.liveResize )
				            {
					            sbar.setTargetWidth();
				            }
			            }
			            else
			            {
				            sbar.splitterBar.style.backgroundColor = sbar.backgroundColorLimit;
			            }
		            }
	            }
            }    

            // create the onmousedown method
            function VwdCmsSplitterBar_onmousedown(evnt)
            {
	            var sbar = VwdCmsSplitterBar.getById(this.id);
	            if ( sbar )
	            {
		            // ensure that the splitterbar is at the top of the z-index
		            sbar.splitterBar.style.zIndex = 5000;
            		
		            // start resizing
		            _activeSplitterBar = sbar; // set the current/active splitter bar
		            sbar.isResizing = true;
		            sbar.splitterBar.style.backgroundColor = sbar.backgroundColorResizing;

		            // hookup the mouse events on the document
		            document.onmousemove = sbar.drag;
		            document.onmouseup = sbar.onmouseup;
            				
		            // deal with IFrames
		            sbar.hideIFrames();
            		
		            // fire the onResizeStart event
		            if ( sbar.onResizeStart )
		            {
			            sbar.onResizeStart(sbar);
		            }
            		
	            }	
            }	

            // create the onmouseup method
            function VwdCmsSplitterBar_onmouseup(evnt)
            {
	            var sbar = VwdCmsSplitterBar.getCurrent();

	            if ( sbar )
	            {
		            // stop resizing 
		            // unhook the mouse events on the document
		            document.onmousemove = null;
		            document.onmouseup = null;
            		
		            // set the final width of the target element
		            sbar.setTargetWidth();
            		
		            // return the splitterbar to an inactive state		
		            sbar.isResizing = false;
		            sbar.splitterBar.style.backgroundColor = sbar.backgroundColor;
		            _activeSplitterBar = null; 
            		
		            // deal with IFrames
		            sbar.showIFrames();
            		
		            // fire the onResizeComplete event
		            if ( sbar.onResizeComplete )
		            {
			            sbar.onResizeComplete(sbar, sbar.primaryResizeTarget.style.width);
		            }
            		
	            }	
            }	

            // create the ondblclick method
            function VwdCmsSplitterBar_ondblclick(evnt)
            {
	            var splitter = this; //VwdCmsSplitterBar.getCurrent();
	            var sbar = VwdCmsSplitterBar.getById(splitter.id);

	            if ( sbar )
	            {
		            // fire the onResizeStart event
		            if ( sbar.onResizeStart )
		            {
			            sbar.onResizeStart(sbar);
		            }

		            // if the SplitterBar is at the MinWidth then 
		            // set it to the MaxWidth, otherwise set it 
		            // to the MinWidth
            		
		            // get the min and max allowable locations
		            var minX = getInt(sbar.offsetLeft);
		            if ( getInt(sbar.maxWidth) == 0 )
		            {
			            minX += 1;		
		            }
		            else
		            {
			            minX += getInt(sbar.minWidth);		
		            }
            			
		            var maxX = getInt(sbar.offsetLeft);
		            if ( getInt(sbar.maxWidth) == 0 )
		            {
			            maxX += getInt(sbar.clientWidth);
		            }
		            else
		            {
			            maxX += getInt(sbar.maxWidth);
		            }
            				
		            if (sbar.splitterBar.style.left == minX + 'px')
		            {
			            sbar.splitterBar.style.left = maxX + 'px';
		            }
		            else
		            {
			            sbar.splitterBar.style.left = minX + 'px';
		            }
		            sbar.setTargetWidth(sbar);	
            		
		            // fire the onResizeComplete event
		            if ( sbar.onResizeComplete )
		            {
			            sbar.onResizeComplete(sbar, sbar.primaryResizeTarget.style.width);
		            }
            			
	            }	
            }	
            function VwdCmsSplitterBar_hideIFrames()
            {
	            var sbar = this;
            	
	            if (sbar.iframeHiding != 'DoNotHide')
	            {
		            // make sure we don't get into a weird state
		            // ** if the user rapidly clicks/dbl-clicks on the SplitterBar
		            // or if the onmouseup event does not get fired for some reason 
		            // this method might get called twice before the showIFrames 
		            // method is called - what happens is the IFrame ends up being
		            // permanently hidden. To avoid this problem call showIFrames 
		            // from within this method before doing the hidding.
		            sbar.showIFrames();
            		
		            // IFrames:  hide IFrames so 
		            // that the splitterbar can work properly
		            // because IFrames capture/steal the mouse events
		            var op = sbar.primaryResizeTarget.offsetParent;
		            sbar.iframeStates = new Array();
		            sbar.iframes = op.getElementsByTagName('iframe');
		            if (sbar.iframes && sbar.iframes.length > 0 )
		            {
			            var iframe = null;
			            for (var i=0; i < sbar.iframes.length; i++)
			            {
				            iframe = sbar.iframes[i];
				            if ( iframe )
				            {
					            switch ( sbar.iframeHiding )
					            {
						            case 'UseVisibility':
							            sbar.iframeStates[i] = iframe.style.visibility;
							            //if ( iframe.style.visibility != 'hidden' )
							            //{
								            iframe.style.visibility = 'hidden';
							            //}
							            break;
            							
						            case 'UseDisplay':
							            sbar.iframeStates[i] = iframe.style.display;
							            //if ( iframe.style.display != 'none' )
							            //{
								            iframe.style.display = 'none';
							            //}
							            break;
					            }
				            }
			            }
		            }
	            }
            }
            function VwdCmsSplitterBar_showIFrames()
            {
	            var sbar = this;
	            if (sbar.iframeHiding != 'DoNotHide')
	            {
		            // re-enable/re-display the elements in sbar.elementsToDisable
		            // these elements are known to interfere with the 
		            // splitterBar, but must be returned to their 
		            // normal state before resizing started
		            var iframe = null;
		            if (sbar.iframes && sbar.iframes.length > 0 )
		            {
			            for (var i=0; i < sbar.iframes.length; i++)
			            {
				            iframe = sbar.iframes[i];
				            switch ( sbar.iframeHiding )
				            {
					            case 'UseVisibility':
						            iframe.style.visibility = sbar.iframeStates[i];
						            break;
            						
					            case 'UseDisplay':
						            iframe.style.display = sbar.iframeStates[i];
						            break;
				            }
			            }
		            }
		            sbar.iframes = null;
		            sbar.iframeStates = null;
	            }
            }

            // utility functions
            function getTargets(targetIds, namingContainerId)
            {
	            // parse a string of element id's 
	            // and get a reference to the element 
	            // from the document
	            var target = null;
	            var targetIdArray = targetIds.split(';');
	            var targets = new Array();
	            var t = 0;
	            var id = null;
            	
	            for ( var i = 0; i < targetIdArray.length; i++ )
	            {
		            id = targetIdArray[i];
		            if ( id && id.length > 0 )
		            {
			            target = document.getElementById(namingContainerId + id);
			            if ( target == null )
			            {
				            // elements that don't have runat='server' will not 
				            // have the naming container prefix
				            target = document.getElementById(id);
			            }
            			
			            if ( target )
			            {
				            targets[t] = target;
				            t++;
			            }
		            }
	            }
	            return targets;
            }

            function getOffsetTop(element)
            {
	            // walk up the stack of elements collecting
	            // the offset top values
	            var offsetTop = new Number(0);
	            try
	            {
		            offsetTop = getInt(element.offsetTop);
		            var op = element.offsetParent;
		            while ( op )
		            {
			            offsetTop += getInt(op.offsetTop);
			            op = op.offsetParent;
		            }
	            }
	            catch (ex) {}
	            return offsetTop;
            }

            function getOffsetLeft(element)
            {
	            // walk up the stack of elements collecting
	            // the offset left values
	            var offsetLeft = new Number(0);
	            try
	            {
		            offsetLeft = getInt(element.offsetLeft);
		            var op = element.offsetParent;
		            while ( op )
		            {
			            offsetLeft += getInt(op.offsetLeft);
			            op = op.offsetParent;
		            }
	            }
	            catch (ex) {}
	            return offsetLeft;
            }

            function getInt(value)
            {
	            var num;
	            if ( value )
	            {
		            num = parseInt(value);
		            if (isNaN(num))
		            {
			            num = new Number(0);
		            }
	            }
	            else
	            {
		            num = new Number(0);
	            }
	            return num;
            }";
            #endregion
            if (this.Page.ClientScript.IsStartupScriptRegistered(this.GetType(), "_ZhouMingSplitterBarStartupScript"))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(),
                        this.ClientID + "_ZhouMingSplitterBarStartupScript", str_addedByZhouMing,true);
            }


            if (this.Page.ClientScript.IsStartupScriptRegistered(this.GetType(), "_VwdCmsSplitterBarStartupScript"))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(),
                    this.ClientID + "_VwdCmsSplitterBarStartupScript", sb.ToString());
            }
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
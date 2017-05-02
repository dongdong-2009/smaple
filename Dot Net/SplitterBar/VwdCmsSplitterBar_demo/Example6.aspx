<!--
//---------------------------------------------------
//     Copyright (c) 2007 Jeffrey Bazinet, VWD-CMS 
//     http://www.vwd-cms.com/  All rights reserved.
//---------------------------------------------------
-->
<%@ Page 
Language="C#" 
AutoEventWireup="true"  
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
    "http://www.w3.org/TR/html4/loose.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example 6: VwdCms SplitterBar</title>
	<script type="text/javascript"> 
	<!-- #include virtual="VwdCmsSplitterBar.js" -->
	</script> 
	<!--     <script src="VwdCmsSplitterBar.js" type="text/javascript"></script> -->
</head>

<body style="margin:0px;padding:0px;">

<form id="form1" runat="server">
	<div>
		<center>
		<table border="0" style="width:800px;background-color:gainsboro;border:solid 1px black;">
			<tr>
				<td align="left" valign="middle">
					<h1 style="font-family:Verdana;font-size:13pt;text-align:left;
						padding:5px;color:steelblue;">VwdCms.SplitterBar : Example 6</h1>
				</td>
				<td align="right" valign="middle">
					<a href="http://www.vwd-cms.com/"><img 
					src="vwd-cms-logo.jpg" style="width:150px;height:32px;border:none;"
					alt="The VwdCms.SplitterBar has been provided by VWD-CMS.com." /></a>
				</td>
			</tr>
			<tr>
				<td colspan="2" align="center" valign="middle">
					<a href="Example1.aspx">Example 1</a>
					&nbsp;|&nbsp;
					<a href="Example2.aspx">Example 2</a>
					&nbsp;|&nbsp;
					<a href="Example3.aspx">Example 3</a>
					&nbsp;|&nbsp;
					<a href="Example4.aspx">Example 4</a>
					&nbsp;|&nbsp;
					<a href="Example5.aspx">Example 5</a>
					&nbsp;|&nbsp;
					<a href="Example6.aspx">Example 6</a>
					&nbsp;|&nbsp; 
					<a href="Example7.aspx">Example 7</a>
				</td>
			</tr>
		</table>
		<br />
		<div style="width:800px;font-family:Verdana;font-size:10pt;text-align:left;
			padding:5px;background-color:#efefef;border:solid 1px silver;">
		This example is about <b>IFRAMES</b>.<br />
		<br />
		IFrames are handled by the browser as a completely separate browser window 
		within a browser window. The difficulty that arises from this is that when 
		the mouse is over an IFrame, the IFrame window gets the mouse events, not 
		the outer window. This prevents the SplitterBar from working properly so 
		we need hide the IFrame elements during resizing.
		<br />
		<br />
		There are several different ways to hide elements using DHTML and CSS:<br />
		1. Display: element.style.display = "none";<br />
		2. Visibility: element.style.visibility = "hidden";<br />
		<br />
		There times when you may want to use one approach rather than the other or 
		you may want to tell the SplitterBar not to hide IFrames so that you can 
		write custom JavaScript code to deal with more complex situations.
		<br />
		<br />
		The SplitterBar has a property called "IFrameHiding" which can have one of the following 
		values:<br />
		&nbsp;&nbsp;SplitterBarIFrameHiding.DoNotHide (don't hide IFrames, let your code handle it)<br />
		&nbsp;&nbsp;SplitterBarIFrameHiding.UseVisibility (use iframe.style.visibility = "hidden")<br />
		&nbsp;&nbsp;SplitterBarIFrameHiding.UseDisplay (use iframe.style.display = "none")<br />
		<br />
		Below are examples of each of these approaches:	
		<br />
		<br />	
		This table has a list of items in the left column and an IFrame 
		in the right column. The left column has a minWidth=100 and 
		a maxWidth=600, when these limits are reached the SplitterBar will 
		change color to Red indicating that it cannot go further. 
		<br />
		<br />
		</div>

		<hr />
		<h3 style="color:steelblue;">SplitterBarIFrameHiding.DoNotHide</h3> 
		<div style="width:600px;color:firebrick;text-align:left;">
		The SplitterBar doesn't work well because 
		the IFrame is capturing the mouse events and I have not 
		added any custom code to handle the hiding of the IFrame.
		</div>
		<br />

		<br />
		<table border="0" style="width:700px;height:200px;border:solid 1px black;" 
			cellpadding="0" cellspacing="0">
			<tr style="height:200px;">
				<td id="tdLeft1" style="width:125px;height:200px;
					background-color:gainsboro;border-right:solid 1px black;">
					<div style="width:100%;height:100%;overflow:auto;padding:0px;margin:0px;">
						<ol style="list-style-type:decimal;">
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
						</ol>
					</div>
				</td>
				<td style="width:6px;height:100%;"></td>
				<td id="tdRight1" align="left" valign="top" style="height:100%;"> 
					<iframe id="ifrRight1" runat="server" enableviewstate="false" 
					src="Example1.aspx" scrolling="auto" frameborder="no" 
					style="width:100%;height:100%;"></iframe>
                    
				</td>		
			</tr>
		</table>
		
			<VwdCms:SplitterBar runat="server" 
				ID="vwdSplitter1" 
				LeftResizeTargets="tdLeft1" 
				DynamicResizing="false"
				MinWidth="100" 
				MaxWidth="600"
				IFrameHiding="DoNotHide" />
		
		<br />

		<hr />
		<h3 style="color:steelblue;">SplitterBarIFrameHiding.DoNotHide + DynamicResizing</h3> 
		<div style="width:600px;color:firebrick;text-align:left;">
		I was hoping that turning on DynamicResizing would help with the IFrame issue, but as 
		you can see below, the problems with the mouse events continue to happen.
		</div>
		<br />

		<br />
		<table border="0" style="width:700px;height:200px;border:solid 1px black;" 
			cellpadding="0" cellspacing="0">
			<tr style="height:200px;">
				<td id="tdLeft4" style="width:125px;height:200px;
					background-color:gainsboro;border-right:solid 1px black;">
					<div style="width:100%;height:100%;overflow:auto;padding:0px;margin:0px;">
						<ol style="list-style-type:decimal;">
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
						</ol>
					</div>
				</td>
				<td style="width:6px;height:100%;"></td>
				<td id="tdRight4" align="left" valign="top" style="height:100%;"> 
					<iframe id="ifrRight4" runat="server" enableviewstate="false" 
					src="Example1.aspx" scrolling="auto" frameborder="no" 
					style="width:100%;height:100%;"></iframe>
                    
				</td>		
			</tr>
		</table>
		
			<VwdCms:SplitterBar runat="server" 
				ID="vwdSplitter4" 
				LeftResizeTargets="tdLeft4" 
				DynamicResizing="true"
				MinWidth="100" 
				MaxWidth="600"
				IFrameHiding="DoNotHide" />
		
		<br />
				
		<br />
		<hr />

		<h3 style="color:steelblue;">SplitterBarIFrameHiding.UseVisibility</h3> 
		<div style="width:600px;color:firebrick;text-align:left;">
		During my testing with FireFox I noticed that if I resized the column 
		quickly to the right that sometimes I would see the IFrame jump over to 
		the right for a moment before it is hidden and sometimes there is some 
		residual pixel discoloration left over to the right of the table. For 
		this reason, I would only use the UseVisibility setting if there are other 
		elements in the table cell that you don't want moving around when the 
		column is resized and you don't want to use the solutions provided below for 
		using the UseDisplay setting and you can live with the issues mentioned here.
		</div>
	

		<br />
		<table border="0" style="width:700px;height:200px;border:solid 1px black;" 
			cellpadding="0" cellspacing="0">
			<tr style="height:200px;">
				<td id="tdLeft2" style="width:125px;height:200px;
					background-color:gainsboro;border-right:solid 1px black;">
					<div style="width:100%;height:100%;overflow:auto;padding:0px;margin:0px;">
						<ol style="list-style-type:decimal;">
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
						</ol>
					</div>
				</td>
				<td style="width:6px;height:100%;"></td>
				<td id="tdRight2" align="left" valign="top" style="height:100%;"> 
					<iframe id="ifrRight2" runat="server" enableviewstate="false" 
					src="Example1.aspx" scrolling="auto" frameborder="no" 
					style="width:100%;height:100%;"></iframe>
                    
				</td>		
			</tr>
		</table>
		
			<VwdCms:SplitterBar runat="server" 
				ID="vwdSplitter2" 
				LeftResizeTargets="tdLeft2" 
				DynamicResizing="false"
				MinWidth="100" 
				MaxWidth="600"
				IFrameHiding="UseVisibility" />
		
		<br />


		<br />
		<hr />

		<h3 style="color:steelblue;">SplitterBarIFrameHiding.UseDisplay</h3> 
		<div style="width:600px;color:firebrick;text-align:left;">
		This example is here to show you the problems that come up when setting 
		the iframe.style.display = "none".
		<br />
		<br />
		When the IFrame is hidden, the entire right table cell 
		colapses to zero width immediately because there is no longer any content 
		in the cell that can be rendered. To see this just click on the SplitterBar 
		and hold the mouse button down. You will see that the 
		left column has expanded far to the right. 
		<br />
		<br />
		Once this this has happened in 
		Firefox, the SplitterBar gets into a corrupted state and no longer 
		functions properly.
		
		<br />
		<br />
		The solution to this problem is explained in the the next example.
		</div>
	

		<br />
		<table border="0" style="width:700px;height:200px;border:solid 1px black;" 
			cellpadding="0" cellspacing="0">
			<tr style="height:200px;">
				<td id="tdLeft3" style="width:125px;height:200px;
					background-color:gainsboro;border-right:solid 1px black;">
					<div style="width:100%;height:100%;overflow:auto;padding:0px;margin:0px;">
						<ol style="list-style-type:decimal;">
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
						</ol>
					</div>
				</td>
				<td style="width:6px;height:100%;"></td>
				<td id="tdRight3" align="left" valign="top" style="height:100%;"> 
					<iframe id="ifrRight3" runat="server" enableviewstate="false" 
					src="Example1.aspx" scrolling="auto" frameborder="no" 
					style="width:100%;height:100%;"></iframe>
                    
				</td>		
			</tr>
		</table>
		
			<VwdCms:SplitterBar runat="server" 
				ID="vwdSplitter3" 
				LeftResizeTargets="tdLeft3" 
				DynamicResizing="false"
				MinWidth="100" 
				MaxWidth="600"
				IFrameHiding="UseDisplay" />
		<br />


		<br />
		<hr />

		<h3 style="color:steelblue;">SplitterBarIFrameHiding.UseDisplay + DIV element + Custom JavaScript</h3> 
		<div style="width:600px;color:darkgreen;text-align:left;">
		In my opinion, this is the prefered technique despite the fact that it takes 
		a little bit more work to build the client-side JavaScript functions to handle 
		the OnResizeStart and OnResizeComplete events. The reason I like this approach is 
		that I don't see any of the problems mentioned in the example for UseVisibility so 
		I think it is worth the small amount of extra effort.
		</div>
		<br />
		<div style="width:600px;color:firebrick;text-align:left;">
		The solution to the problem in the previous example is to put a DIV inside 
		the right table cell and set display:none, width:100%, height:100%. 
		<br />
		<br />
		The IFrame is also in the right table cell with the div.
		During normal viewing the IFrame is visible and the div is hidden. During resizing 
		the IFrame is hidden and the div is visible (although there is no content to see).
		The result is that the cell still contains an element to occupy its client 
		area even when the IFrame is hidden.
		<br />
		<br />
		By using the client-side events exposed by the SplitterBar, we can control the 
		hiding and displaying of the DIV element. See the JavaScript in this page to learn 
		how the OnResizeStart and OnResizeComplete event handlers are built. This example 
		uses &quot;vwdSplitter5&quot;.

		<br />
		</div>

		<br />
		<table border="0" style="width:700px;height:200px;border:solid 1px black;" 
			cellpadding="0" cellspacing="0">
			<tr style="height:200px;">
				<td id="tdLeft5" style="width:125px;height:200px;
					background-color:gainsboro;border-right:solid 1px black;">
					<div style="width:100%;height:100%;overflow:auto;padding:0px;margin:0px;">
						<ol style="list-style-type:decimal;">
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
						</ol>
					</div>
				</td>
				<td style="width:6px;height:100%;"></td>
				<td id="tdRight5" align="left" valign="top" style="height:100%;"> 
					<div id="divRight5" style="display:none;width:100%;height:100%;">&nbsp;</div>
					<iframe id="ifrRight5" runat="server" enableviewstate="false" 
					src="Example1.aspx" scrolling="auto" frameborder="no" 
					style="width:100%;height:100%;"></iframe>
                    
				</td>		
			</tr>
		</table>
		
			<VwdCms:SplitterBar runat="server" 
				ID="vwdSplitter5" 
				LeftResizeTargets="tdLeft5" 
				DynamicResizing="false"
				MinWidth="100" 
				MaxWidth="600"
				IFrameHiding="UseDisplay"
				OnResizeStart="splitterOnResizeStart"
				OnResizeComplete="splitterOnResizeComplete" />
		
		<br />

		<br />
		<hr />

		<h3 style="color:steelblue;">SplitterBarIFrameHiding.DoNotHide + DIV element + Custom JavaScript</h3> 
		<div style="width:600px;color:firebrick;text-align:left;">
		This example is doing essentially the same thing as the previous one, except it is 
		your own custom code that controls the hiding and displaying of the IFrame and DIV 
		instead of the automatic functionality built into the SplitterBar.
		<br />
		<br />
		If you have complex resizing needs or if you want to have ultimate control over 
		the hiding and displaying of the IFrames, just turn off the automatic hiding by 
		setting SplitterBar.IFrameHiding = SplitterBarIFrameHiding.DoNotHide.
		<br />
		<br />
		By using the client-side events exposed by the SplitterBar, we can control the 
		hiding and displaying of the IFrame and the DIV element. See the JavaScript in this page to learn 
		how the OnResizeStart and OnResizeComplete event handlers are built. This example 
		uses &quot;vwdSplitter6&quot;.
		</div>
	
		<br />
		<table border="0" style="width:700px;height:200px;border:solid 1px black;" 
			cellpadding="0" cellspacing="0">
			<tr style="height:200px;">
				<td id="tdLeft6" style="width:125px;height:200px;
					background-color:gainsboro;border-right:solid 1px black;">
					<div style="width:100%;height:100%;overflow:auto;padding:0px;margin:0px;">
						<ol style="list-style-type:decimal;">
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
							<li>List Item List Item List Item</li>
						</ol>
					</div>
				</td>
				<td style="width:6px;height:100%;"></td>
				<td id="tdRight6" align="left" valign="top" style="height:100%;"> 
					<div id="divRight6" style="display:none;width:100%;height:100%;">&nbsp;</div>
					<iframe id="ifrRight6" runat="server" enableviewstate="false" 
					src="Example1.aspx" scrolling="auto" frameborder="no" 
					style="width:100%;height:100%;"></iframe>
                    
				</td>		
			</tr>
		</table>
		
			<VwdCms:SplitterBar runat="server" 
				ID="vwdSplitter6" 
				LeftResizeTargets="tdLeft6" 
				DynamicResizing="false"
				MinWidth="100" 
				MaxWidth="600"
				IFrameHiding="DoNotHide"
				OnResizeStart="splitterOnResizeStart"
				OnResizeComplete="splitterOnResizeComplete" />
		
		<br />
												
		</center>

	</div>
	<br />
	<br />
	<br />
	<br />

<script language="javascript" type="text/javascript"><!--

	function splitterOnResizeStart(splitterBar)
	{
		// Arguments:
		// splitterBar is a VwdCmsSplitterBar object

		// ** the actual div element that you see on the 
		// screen can be accessed by using splitterBar.splitterBar
		// or by document.getElementById('splitterBarID')
		// where 'splitterBarID' is the ID of the server control
		// in your ASPX code.
		
		// check to see what splitterBar fired this event
		if ( splitterBar && splitterBar.id == "vwdSplitter5" )
		{
			var div = document.getElementById("divRight5");
			if ( div )
			{
				div.style.display = "block";
			}			
		}
		else if ( splitterBar && splitterBar.id == "vwdSplitter6" )
		{
			// first hide the IFrame, then display the DIV
			var ifrm = document.getElementById("ifrRight6");
			if ( ifrm )
			{
				ifrm.style.display = "none";
			}		
			var div = document.getElementById("divRight6");
			if ( div )
			{
				div.style.display = "block";
			}
		}
	}
	function splitterOnResizeComplete(splitterBar, width)
	{
		// Arguments:
		// splitterBar is a VwdCmsSplitterBar object
		// width is a string like "250px

		// ** the actual div element that you see on the 
		// screen can be accessed by using splitterBar.splitterBar
		// or by document.getElementById('splitterBarID')
		// where 'splitterBarID' is the ID of the server control
		// in your ASPX code.

		// do any other work that needs to happen when the 
		// splitter resizing is complete. this is a good place to handle 
		// any complex resizing rules, etc.

		// make sure the width is in number format
		if (typeof width == "string")
		{
			width = new Number(width.replace("px",""));
		}
		
		// check to see what splitterBar fired this event
		if ( splitterBar && splitterBar.id == "vwdSplitter5" )
		{
			var div = document.getElementById("divRight5");
			if ( div )
			{
				div.style.display = "none";
			}
		}
		else if ( splitterBar && splitterBar.id == "vwdSplitter6" )
		{
			// first hide the DIV, then display the IFrame
			var div = document.getElementById("divRight6");
			if ( div )
			{
				div.style.display = "none";
			}
			var ifrm = document.getElementById("ifrRight6");
			if ( ifrm )
			{
				ifrm.style.display = "block";
			}		
		}
	}		
	function splitterOnResize(splitterBar, width)
	{
		// Arguments:
		// splitterBar is a VwdCmsSplitterBar object
		// width is a string like "250px

		// ** the actual div element that you see on the 
		// screen can be accessed by using splitterBar.splitterBar
		// or by document.getElementById('splitterBarID')
		// where 'splitterBarID' is the ID of the server control
		// in your ASPX code.

		// do any other work that needs to happen when the 
		// splitter resizes. this is a good place to handle 
		// any complex resizing rules, etc.

		// make sure the width is in number format
		if (typeof width == "string")
		{
			width = new Number(width.replace("px",""));
		}
		
		// check to see what splitterBar fired this event
//		if ( splitterBar && splitterBar.id == "???" )
//		{
//			
//		}
	}

// -->
</script>
	 
</form>
    
</body>
</html>

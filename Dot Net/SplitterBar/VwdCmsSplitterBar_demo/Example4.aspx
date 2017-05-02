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
    <title>Example 4: VwdCms SplitterBar</title>
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
						padding:5px;color:steelblue;">VwdCms.SplitterBar : Example 4</h1>
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
		<div style="width:600px;font-family:Verdana;font-size:10pt;text-align:left;
			padding:5px;background-color:#efefef;border:solid 1px silver;">
		<b>SplitterBar Events:</b> This example demonstrates the use of 
		the VwdCms.SplitterBar event handler 
		properties OnResizeStart, OnResize, and OnResizeComplete.
		<br />
		<br />
		See the JavaScipt code in this page 
		for details about custom coding with the OnResizeStart,  
		OnResize, and OnResizeComplete event handlers. 
		<br />
		</div>

		<br />
		<table id="tblExample4" border="0" cellpadding="0" cellspacing="0"
			style="width:500px;border:solid 3px silver;padding:0px;" >
			<tr style="height:150px;">
				<td id="tdLeft1" style="width:300px;background-color:white;
				border-right:solid 2px orange;">&nbsp;</td>
				<td id="tdRight1" style="background-color:lavender;">&nbsp;</td>		
			</tr>
		</table>
		<br />
		<div id="divAlert" style="display:none;border:none;width:500px;height;100px;text-align:center;
		font-family:Verdana;font-weight:bold;color:firebrick;font-size:13pt;">
		!! RESIZING !!
		</div>
		<br />
		<div id="divDirection" style="display:none;border:none;width:500px;height;100px;text-align:center;
		font-family:Verdana;font-weight:bold;color:steelblue;font-size:13pt;">
		
		</div>
		<br />
		<br />
	
		</center>
		
	</div>
	<br />
	<br />
	<br />
	<br />

	<VwdCms:SplitterBar runat="server" ID="vwdSplitter1" 
	 LeftResizeTargets="tdLeft1" 
	 style="background-image:url(vsplitter.gif);
	 background-position:center center;
	 background-repeat:no-repeat;
	 border-left:solid 1px black;
	 border-right:solid 1px black;"
	 DynamicResizing="true"
	 OnResizeStart="splitterOnResizeStart"
	 OnResize="splitterOnResize" 
	 OnResizeComplete="splitterOnResizeComplete"
	  />
	  
<script language="javascript" type="text/javascript"><!--
	var _timerID = 0;
	var _prevWidth = 0;
	
	function splitterOnResizeStart(splitterBar)
	{
		// Arguments:
		// splitterBar is a VwdCmsSplitterBar object

		// ** the actual div element that you see on the 
		// screen can be accessed by using splitterBar.splitterBar
		// or by document.getElementById('splitterBarID')
		// where 'splitterBarID' is the ID of the server control
		// in your ASPX code.
		
		// check to see which splitterBar fired this event
		if ( splitterBar && splitterBar.id == "vwdSplitter1" )
		{
			setupTimer("divAlert");
			
			document.getElementById("divDirection").style.display = "block";
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
		
		// check to see which splitterBar fired this event
		if ( splitterBar && splitterBar.id == "vwdSplitter1" )
		{
			var div = document.getElementById("divDirection");
			
			if ( _prevWidth != 0 )
			{
				if ( width > _prevWidth )
				{
					div.innerHTML = "&gt;&gt; MOVING TO THE RIGHT &gt;&gt;";
				}
				else
				{
					div.innerHTML = "&lt;&lt; MOVING TO THE LEFT &lt;&lt;";
				}
			}
			_prevWidth = width;
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
				
		// check to see which splitterBar fired this event
		if ( splitterBar && splitterBar.id == "vwdSplitter1" )
		{
			cancelTimer("divAlert");

			var div = document.getElementById("divDirection");
			div.style.display = "none";
			div.innerHTML = "";
			_prevWidth = 0;
		}
	}	
	function setupTimer(controlId)
    {
		cancelTimer(controlId);
		_timerID = setInterval("showAlert('" + controlId + "');", 300);
	}
	function cancelTimer(controlId)
	{
		if ( _timerID != 0 )
		{
			hideAlert(controlId);
			clearInterval(_timerID);
			_timerID = 0;
		}
	}
	
	function showAlert(controlId) 
	{
		var element = document.getElementById(controlId);

		if ( element && element.style )
		{
			element.style.display = "block";
			
			if (element.style.fontWeight == "bold")
			{
				element.style.fontWeight = "normal";
			}
			else
			{
				element.style.fontWeight = "bold";
			}
		}
	}	
	function hideAlert(controlId) 
	{
		var element = document.getElementById(controlId);

		if ( element && element.style )
		{
			element.style.display = "none";
			element.style.fontWeight = "normal";
		}
	}		
// -->
</script>
	 
</form>
    
</body>
</html>

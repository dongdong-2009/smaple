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
    <title>Example 2: VwdCms SplitterBar</title>
<!-- NOTE: the following server-side include is used while testing 
		   and debugging because the javascript code gets inserted 
		   into the page source code which makes it easier to find
		   javascript errors when reported with a line number by IE.
		   
		   You will want to remove the server-side include and use 
		   the script tag below it when you deploy your application.
-->		   
<script type="text/javascript"> 
<!-- #include virtual="VwdCmsSplitterBar.js" -->
</script> 
<!--     <script src="VwdCmsSplitterBar.js" type="text/javascript"></script> -->
</head>

<body>
<form id="form1" runat="server">
	<div>
		<center>
		<div style="width:800px;">

		<table border="0" style="width:800px;background-color:gainsboro;border:solid 1px black;">
			<tr>
				<td align="left" valign="middle">
					<h1 style="font-family:Verdana;font-size:13pt;text-align:left;
						padding:5px;color:steelblue;">VwdCms.SplitterBar : Example 2</h1>
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
		<div style="font-family:arial;font-size:10pt;text-align:left;">
		This is a basic usage of the control except that I have added styles 
		to give it a background image, left border, and right border. To show 
		how the debugging features of the VwdCms.SplitterBar can be used, 
		I added a TextArea to the page so we 
		can see what the SplitterBar is doing when we use it.<br /><br />
		The 3 minimum requirements to use the VwdCms.SplitterBar are:<br />
		1. Include a runat=&quot;server&quot; attribute<br />
		2. Give the control an ID<br />
		3. Set the LeftResizeTargets property to a control on the page.<br />
		<br />
		<b>Notes:</b><br />
		1. This example also shows how the SplitterBar takes into account the thickness of the 
		table's borders when determining the resizing range as well as the thickness of the 
		left and right borders of the SplitterBar.<br /> 
		2. Always set the table's CellPadding=&quot;0&quot;.<br />
		3. Always set the table's CellSpacing=&quot;0&quot;.<br />
		4. Do not set a css padding on the table or set it to style=&quot;padding:0px;&quot;.<br />
		</div>
		<br />
		<div style="text-align:left;border:dotted 1px silver;width:500px;background-color:ghostwhite;font-weight:bold;padding:10px;">
&nbsp;&nbsp;&nbsp;&nbsp;&lt;VwdCms:SplitterBar runat=&quot;server&quot; ID=&quot;vwdSplitter1&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp; DebugElement=&quot;txtDebug&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp; LeftResizeTargets=&quot;tdResize1&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp; style=&quot;background-image:url(vsplitter.gif);<br />
&nbsp;&nbsp;&nbsp;&nbsp; background-position:center center;<br />
&nbsp;&nbsp;&nbsp;&nbsp; background-repeat:no-repeat;<br />
&nbsp;&nbsp;&nbsp;&nbsp; border-left:solid 1px black;<br />
&nbsp;&nbsp;&nbsp;&nbsp; border-right:solid 1px black;&quot; /&gt;		</div>
		
		<br />
		
		<table border="0" cellpadding="0" cellspacing="0"
			style="width:500px;border:solid 3px silver;padding:0px;" >
			<tr style="height:150px;">
				<td id="tdResize1" style="width:300px;background-color:white;
				border-right:solid 2px orange;">&nbsp;</td>
				<td style="background-color:lavender;">&nbsp;</td>		
			</tr>
		</table>
		
		<br />
		Check the check box below to enable debugging output.<br />
		<b>Note:</b> Outputting debugging information severely slows down the UI performance of the 
		SplitterBar. <br />
		<input type="checkbox" runat="server" id="chkDebug" checked="checked"
		onclick="var txt=null;if (this.checked){txt='txtDebug';} VwdCmsSplitterBar.setDebug(txt, '');"/>
		Debugging Output: (newest events on the top)
		&nbsp;&nbsp;&nbsp;&nbsp;
		<input type="button" value="Clear" onclick="document.getElementById('txtDebug').value='';"
		style="height:20px;width:45px;font-family:arial;font-size:8pt;" />
		&nbsp;&nbsp;
		<input type="submit" value="Reload" 
		style="height:20px;width:45px;font-family:arial;font-size:8pt;" />
		<br />
		<textarea id="txtDebug" cols="60" rows="8"></textarea>

	</div>

	</center>
	
	</div>
	<VwdCms:SplitterBar runat="server" ID="vwdSplitter1" 
	 DebugElement="txtDebug"
	 LeftResizeTargets="tdResize1" 
	 style="background-image:url(vsplitter.gif);
	 background-position:center center;
	 background-repeat:no-repeat;
	 border-left:solid 1px black;
	 border-right:solid 1px black;" />


</form>
    
</body>
</html>

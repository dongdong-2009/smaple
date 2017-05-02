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
    <title>Example 3: VwdCms SplitterBar</title>
    <script src="VwdCmsSplitterBar.js" type="text/javascript"></script>
</head>

<body style="margin:0px;padding:0px;">
 
<form id="form1" runat="server">
	<div>
		<center>
		<table border="0" style="width:800px;background-color:gainsboro;border:solid 1px black;">
			<tr>
				<td align="left" valign="middle">
					<h1 style="font-family:Verdana;font-size:13pt;text-align:left;
						padding:5px;color:steelblue;">VwdCms.SplitterBar : Example 3</h1>
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
		<div style="width:800px;font-family:Verdana;font-size:8pt;text-align:left;
			padding:5px;background-color:#efefef;border:solid 1px silver;">
		This example sets the following properties of the control:<br />
		1. runat=server attribute<br />
		2. Control ID<br />
		3. LeftResizeTargets property.<br />
		4. BackgroundColor property to "Silver".<br />
		5. BackgroundColorHilite property to "Yellow".<br />
		6. BackgroundColorResizing property to "Purple".<br />
		7. BackgroundColorLimit property to "Orange".<br />
		8. DynamicResizing to "true".<br />
			<br />
		</div>

		<br />
		
		<input type="checkbox" checked="checked"
		 onclick="VwdCmsSplitterBar.setLiveResize(this.checked);" />
		Dynamically Resize the Table Cell as the SplitterBar is moved.
		<br />
		<br />
		<table border="0" style="width:60%;border:solid 1px black;" cellpadding="0" cellspacing="0">
			<tr style="height:150px;">
				<td id="tdResize2" style="width:300px;background-color:gainsboro;
				border-right:solid 1px black;">&nbsp;</td>
				<td style="background-color:lavender;">&nbsp;</td>		
			</tr>
		</table>
		</center>

	</div>

	<!--  customize the colors, turn on Dynamic Resizing -->
	<VwdCms:SplitterBar runat="server" ID="vwdSplitter2" 
	 LeftResizeTargets="tdResize2" 
	 BackgroundColor="silver"
	 BackgroundColorHilite="Yellow"
	 BackgroundColorResizing="Purple"
	 BackgroundColorLimit="Orange"
	 DynamicResizing="true"/>
</form>
    
</body>
</html>

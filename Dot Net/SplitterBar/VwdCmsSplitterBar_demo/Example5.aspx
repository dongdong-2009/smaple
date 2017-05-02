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
    <title>Example 5: VwdCms SplitterBar</title>
	<script type="text/javascript"> 
	<!-- #include virtual="VwdCmsSplitterBar.js" -->
	</script> 
	<!--     <script src="VwdCmsSplitterBar.js" type="text/javascript"></script> -->
</head>

<body>
 
<form id="form1" runat="server">
	<div>
		<center>
		<table border="0" style="width:800px;background-color:gainsboro;border:solid 1px black;">
			<tr>
				<td align="left" valign="middle">
					<h1 style="font-family:Verdana;font-size:13pt;text-align:left;
						padding:5px;color:steelblue;">VwdCms.SplitterBar : Example 5</h1>
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
		<div style="width:600px;font-family:Verdana;font-size:8pt;text-align:left;
			padding:5px;background-color:#efefef;border:solid 1px silver;">
		This example contains other ideas of what is possible...I have not taken 
		the time to try to make them presentable for a real web application.
		<br />
		<br />
		By adjusting the styles of the ResizeTarget controls and the SplitterBar,
		and by making some adjustments to the SplitterBar JavaScript code you 
		can improve the look and feel.		
		<br />
		</div>
		<br />

		<div style="width:600px;text-align:left;border:solid 1px silver;">
			<br />
			<asp:Button runat="server" ID="btnTest1" 
			Text="Test Button 1" style="width:200px;height:25px;"/>
			<VwdCms:SplitterBar runat="server" ID="vwdSplitter1" 
				LeftResizeTargets="btnTest1" 
				RightResizeTargets="btnTest2" 
				TotalWidth="400"
				BackgroundColor="silver"
				DynamicResizing="true"
				/>
			<asp:Button runat="server" ID="btnTest2" 
			Text="Test Button 2" style="width:200px;height:25px;"/>

			<br />
			<br />
			<br />
			
			(the height of the SplitterBar is wrong in Firefox)<br />			
			<asp:DropDownList runat="server" ID="ddlTest" style="height:22px;">
				<asp:ListItem Text="List Item 1" />
				<asp:ListItem Text="List Item 2" />
				<asp:ListItem Text="List Item 3" />
			</asp:DropDownList>
			<VwdCms:SplitterBar runat="server" ID="vwdSplitter2" 
				LeftResizeTargets="ddlTest" 
				BackgroundColor="silver"
				DynamicResizing="true"/>
			
			<br />
			<br />
			<br />
			
			<asp:Panel runat="server" ID="pnlTest" BackColor="Beige" 
			style="width:150px;height:100px;text-align:center">
				<br /><br />Test Panel
			</asp:Panel>
			<VwdCms:SplitterBar runat="server" ID="vwdSplitter3" 
				LeftResizeTargets="pnlTest" 
				BackgroundColor="silver"
				DynamicResizing="true"/>
			
			<br />
			<br />		
			<br />
			<img id="imgVwdCmsLogo" 
			style="width:420px;height:90px;border:none;"
			src="vwd-cms-logo.jpg"/>
			<VwdCms:SplitterBar runat="server" ID="vwdSplitter4" 
				LeftResizeTargets="imgVwdCmsLogo" 
				BackgroundColor="silver"
				DynamicResizing="true" />
			
			<br />
			<br />		

			</div>

		</center>

	</div>

</form>
    
</body>
</html>

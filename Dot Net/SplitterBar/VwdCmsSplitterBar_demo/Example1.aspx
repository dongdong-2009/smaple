<!--
//---------------------------------------------------
//     Copyright (c) 2007 Jeffrey Bazinet, VWD-CMS 
//     http://www.vwd-cms.com/  All rights reserved.
//---------------------------------------------------
-->

<%@ Page 
Language="C#" 
AutoEventWireup="true" 
CodeFile="Example1.aspx.cs" 
Inherits="Example1"
%>

<!-- DOCTYPES -->
<!-- *************  Important Note *************
The DocType (markup format specification) that you choose 
will have a profound impact on how your content is rendered 
by the browser. If you are having trouble getting styles to 
work as you expect, you may want to try using a different 
DocType. If you are getting strange results or it seems like 
the browser is ignoring your style settings it it is interesting
and worth the time to try rendering the page 
with no DocType at all (just commment it out) and see how the 
browser renders your page.

Here is an interesting article on IE 6 and the DOCTYPE implementation:
http://msdn2.microsoft.com/en-us/library/bb250395.aspx

or
http://msdn.microsoft.com/library/default.asp?url=/workshop/author/dhtml/reference/objects/doctype.asp

Element positioning information:
http://msdn.microsoft.com/library/default.asp?url=/workshop/author/position/positioning.asp

http://msdn.microsoft.com/library/default.asp?url=/library/en-us/IETechCol/cols/dnexpie/ie7_css_ZenTek.asp

-->

<!-- HTML 4.01 STRICT  -->
<!-- 
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN"
        "http://www.w3.org/TR/html4/strict.dtd">
-->

<!-- HTML 4.01 TRANSITIONAL  -->
<!-- -->

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
    "http://www.w3.org/TR/html4/loose.dtd">

<!-- HTML 4.01 FRAMES / FRAMESETS  -->
<!--
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN"
        "http://www.w3.org/TR/1999/REC-html401-19991224/frameset.dtd">
-->

<!-- XHTML 1.0 TRANSITIONAL  -->
<!--
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
-->

<!-- XHTML 1.0 STRICT  -->
<!--
<!DOCTYPE html 
     PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
     "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
-->

<!-- HTML 3.2 Final -->
<!--
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2 Final//EN">
-->

<html> <!-- xmlns="http://www.w3.org/1999/xhtml" > -->
<head runat="server">
    <title>Example 1: VwdCms SplitterBar</title>
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

<script language="javascript" type="text/javascript"><!--

	function splitterOnResize(width)
	{
		// do any other work that needs to happen when the 
		// splitter resizes. this is a good place to handle 
		// any complex resizing rules, etc.

		// make sure the width is in number format
		if (typeof width == "string")
		{
			width = new Number(width.replace("px",""));
		}

	}
	
// -->
</script>

</head>
<body style="margin:10px;padding:0px;">
    <form id="form1" runat="server">
    <div>
		<center>
		<table border="0" style="width:800px;background-color:gainsboro;border:solid 1px black;">
			<tr>
				<td align="left" valign="middle" style="width: 480px">
					<h1 style="font-family:Verdana;font-size:13pt;text-align:left;
						padding:5px;color:steelblue;">VwdCms.SplitterBar : Example 1</h1>
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
			This example demonstrates a VwdCms.SplitterBar implemented with 
			a table that contains a TreeView in the left column and a TextArea in 
			the right column. 
			<br />
			<br />
			<b>Note:</b> The term version used in this example refers to the 
			version of the example, not a different version of the SplitterBar. All 
			of the examples here (versions) use the same version of the SplitterBar.
			<br />
			<br />
			<b>Version A</b> works well in Firefox and IE 7. 
			It sets the LeftResizeTargets equal to "tdTree1;divTree1" 
			which tells the SplitterBar to resize both the table cell and the div 
			control that contains the tree view. <b>Note:</b> pay special attention 
			to the styles that have been applied to each element, removing or 
			modifying these settings can cause unpredictable behavior.
			<br />
			<br />
			<b>Version B</b> works in FireFox but does not work in IE 7 
			and I have included it here to show why the SplitterBar has been 
			implemented with the ability to pass in multiple ResizeTargets.
			<br />
			<br />
			<b>Version C</b> is here to demonstrate a very annoying bug in IE (it was 
			there in IE 6 and is still there IE 7) regarding TextArea resizing. 
			If you prefill the content of a TextArea and then later try to resize 
			it, it will not scroll and wrap the text properly, and ends up 
			ignoring the size settings and screws up your layout. The solution 
			that I have used is to set the value of the TextArea once the page 
			has loaded, that way the TextArea has time to render (and figure out 
			its geometry, I guess) before it has any content. Inserting the content 
			after the page is loaded makes it so you can freely resize the TextArea.
			<br />
			<br />
			<b>Version D</b> is the same as version A, but it has DynamicResizing 
			turned on.
			<br />
			<br />
		</div>

		<!-- ********* -->
		<!-- version A -->
		<!-- ********* -->
		<br />
		<br />
		<div style="width:800px;font-family:Verdana;font-size:8pt;text-align:left;
			padding:5px;background-color:#efefef;border:solid 1px silver;">
		<b>Version A:</b> This is the preferred version, works in IE 7 and Firefox. </div>
		<br />
		<div style="text-align:left;border:dotted 1px silver;width:800px;background-color:ghostwhite;font-weight:bold;padding:10px;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;VwdCms:SplitterBar runat=&quot;server&quot; ID=&quot;vsbSplitter1&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeftResizeTargets=&quot;tdTree1;divTree1&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MinWidth=&quot;100&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaxWidth=&quot;700&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColor=&quot;lightsteelblue&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorLimit=&quot;firebrick&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorHilite=&quot;steelblue&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorResizing=&quot;purple&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SaveWidthToElement=&quot;txtWidth1&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnResize=&quot;splitterOnResize&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;style=&quot;background-image:url(vsplitter.gif);<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  background-position:center center;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  background-repeat:no-repeat;&quot;/&gt; 		</div>
		<br />
		<div style="margin:0px;padding:0px;width:800px;overflow:hidden;">
		<table border="0" cellpadding="0" cellspacing="0" 
			style="width:800px;height:200px;border:solid 1px #6699CC;">
			<tr style="height:200px;">
				<td runat="server" id="tdTree1" style="width:250px;height:200px;" align="left" valign="top"> 
					<div runat="server" id="divTree1" style="width:250px;height:100%;overflow:auto;padding:0px;margin:0px;">
					<asp:TreeView ID="tvwFramework1" runat="server" ShowLines="True"
						style="width:100%;height:100%;padding:0px;margin:0px;">
						<Nodes>
							<asp:TreeNode Text=".NET Framework" Value=".NET Framework">
								<asp:TreeNode Text="System.Diagnostics" Value="System.Diagnostics">
									<asp:TreeNode Text="Debug Class" Value="Debug"></asp:TreeNode>
									<asp:TreeNode Text="DebuggableAttribute.DebuggingModes Enumeration" Value="DebuggableAttribute.DebuggingModes Enumeration"></asp:TreeNode>
									<asp:TreeNode Text="EventLogPermissionEntryCollection Class" Value="EventLogPermissionEntryCollection Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.IO" Value="System.IO">
									<asp:TreeNode Text="File Class" Value="File Class"></asp:TreeNode>
									<asp:TreeNode Text="FileInfo Class" Value="FileInfo Class"></asp:TreeNode>
									<asp:TreeNode Text="InternalBufferOverflowException Class" Value="InternalBufferOverflowException Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.WebControls" Value="ASP.NET">
									<asp:TreeNode Text="CheckBoxList Class" Value="CheckBoxList"></asp:TreeNode>
									<asp:TreeNode Text="Content Class" Value="Content"></asp:TreeNode>
									<asp:TreeNode Text="ContentPlaceHolder Class" Value="ContentPlaceHolder"></asp:TreeNode>
									<asp:TreeNode Text="Label Class" Value="Label"></asp:TreeNode>
									<asp:TreeNode Text="TextBox Class" Value="TextBox"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web" Value="System.Web">
									<asp:TreeNode Text="HttpRequest Class" Value="HttpRequest Class"></asp:TreeNode>
									<asp:TreeNode Text="HttpWorkerRequest Class" Value="HttpWorkerRequest Class"></asp:TreeNode>
									<asp:TreeNode Text="HttpWorkerRequest.EndOfSendNotification Delegate" Value="HttpWorkerRequest.EndOfSendNotification Delegate"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.Caching" Value="System.Web.Caching">
									<asp:TreeNode Text="AggregateCacheDependency Class" Value="AggregateCacheDependency Class"></asp:TreeNode>
									<asp:TreeNode Text="DatabaseNotEnabledForNotificationException Class" Value="DatabaseNotEnabledForNotificationException Class"></asp:TreeNode>
									<asp:TreeNode Text="SqlCacheDependency Class" Value="SqlCacheDependency Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls" Value="System.Web.UI.MobileControls">
									<asp:TreeNode Text="DeviceSpecific Class" Value="DeviceSpecific Class"></asp:TreeNode>
									<asp:TreeNode Text="LiteralTextContainerControlBuilder Class" Value="LiteralTextContainerControlBuilder Class"></asp:TreeNode>
									<asp:TreeNode Text="ObjectListShowCommandsEventHandler Delegate" Value="ObjectListShowCommandsEventHandler Delegate"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls.Adapters" Value="System.Web.UI.MobileControls.Adapters">
									<asp:TreeNode Text="HtmlAdapter Class" Value="HtmlAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="HtmlPanelAdapter Class" Value="HtmlPanelAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="WmlControlAdapter Class" Value="WmlControlAdapter Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls.Adapters.XhtmlAdapters" Value="System.Web.UI.MobileControls.Adapters.XhtmlAdapters">
									<asp:TreeNode Text="XhtmlCalendarAdapter Class " Value="XhtmlCalendarAdapter Class "></asp:TreeNode>
									<asp:TreeNode Text="XhtmlCommandAdapter Class" Value="XhtmlCommandAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="XhtmlFormAdapter Class" Value="XhtmlFormAdapter Class"></asp:TreeNode>
								</asp:TreeNode>
							</asp:TreeNode>
						</Nodes>
					</asp:TreeView>	
					</div>			
				</td>
				<td id="tdMid1" style="height:200px;width:6px;background-color:lightsteelblue;"></td>
				<td id="tdEdit1" align="left" valign="top" style="height:200px;"> 
						<textarea runat="server" id="txtEdit1" 
						style="margin:0px;height:100%;width:100%;padding:0px 0px 0px 5px;
						border:none;"></textarea>
				</td>
			
			</tr>
		</table>
		<span style="font-family:Verdana;font-size:10pt;">
		Current Width: 
		</span>
		<asp:textbox runat="server" id="txtWidth1" value="250px" 
		style="width:70px;font-family:Verdana;font-size:10pt;"/>
		<br />
		<asp:Button runat="server" ID="btnPostBack" Text="Test PostBack" />
		<br />
		<div style="width:500px;font-family:Verdana;font-size:8pt;text-align:left;
			padding:5px;background-color:#efefef;border:solid 1px silver;">
			<b>Note:</b> The controls listed in the LeftResizeTargets and 
			RightResizeTargets will be processed during the PostBack only if they have 
			the runat=&quot;server&quot; attribute set.
			<br /> Resize the column, then click the 'Test PostBack' button to 
			verify that the width selection by the user is persisted after 
			the PostBack. 
		</div>
		</div>	
		<VwdCms:SplitterBar runat="server" ID="vsbSplitter1" 
			LeftResizeTargets="tdTree1;divTree1" 
			MinWidth="100" 
			MaxWidth="700"
			BackgroundColor="lightsteelblue" 
			BackgroundColorLimit="firebrick"
			BackgroundColorHilite="steelblue"
			BackgroundColorResizing="purple"
			SaveWidthToElement="txtWidth1"
			OnResize="splitterOnResize"
			style="background-image:url(vsplitter.gif);
				background-position:center center;
				background-repeat:no-repeat;"/> 
				

		<!-- ********* -->
		<!-- version B -->
		<!-- ********* -->
		<br />
		<br />
		<br />
		<div style="width:800px;font-family:Verdana;font-size:8pt;text-align:left;
			padding:5px;background-color:#efefef;border:solid 1px silver;">
		<b>Version B</b>: Works in FireFox, but not in IE 7. To see the problem, drag the 
		SplitterBar all the way to the left. The cell containing the TreeView is resized, 
		but the cell containing the TextArea does not resize. Version A fixes this by 
		adding the div for the TreeView to the LeftResizeTargets property.</div>
		<br />
		<div style="text-align:left;border:dotted 1px silver;width:800px;background-color:ghostwhite;font-weight:bold;padding:10px;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;VwdCms:SplitterBar runat=&quot;server&quot; ID=&quot;vsbSplitter2&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeftResizeTargets=&quot;tdTree2&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MinWidth=&quot;100&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaxWidth=&quot;700&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColor=&quot;lightsteelblue&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorLimit=&quot;firebrick&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorHilite=&quot;steelblue&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorResizing=&quot;purple&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SaveWidthToElement=&quot;txtWidth2&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnResize=&quot;splitterOnResize&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;style=&quot;background-image:url(vsplitter.gif);<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;background-position:center center;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;background-repeat:no-repeat;&quot;/&gt; 		</div>
		<br />
		<div style="margin:0px;padding:0px;width:800px;overflow:hidden;">
		<table border="0" cellpadding="0" cellspacing="0" 
			style="width:800px;height:200px;border:solid 1px #6699CC;">
			<tr style="height:200px;">
				<td id="tdTree2" style="width:250px;height:200px;" align="left" valign="top"> 
					<div id="divTree2" style="width:250px;height:100%;overflow:auto;padding:0px;margin:0px;">
					<asp:TreeView ID="tvwFramework2" runat="server" ShowLines="True"
						style="width:100%;height:100%;padding:0px;margin:0px;">
						<Nodes>
							<asp:TreeNode Text=".NET Framework" Value=".NET Framework">
								<asp:TreeNode Text="System.Diagnostics" Value="System.Diagnostics">
									<asp:TreeNode Text="Debug Class" Value="Debug"></asp:TreeNode>
									<asp:TreeNode Text="DebuggableAttribute.DebuggingModes Enumeration" Value="DebuggableAttribute.DebuggingModes Enumeration"></asp:TreeNode>
									<asp:TreeNode Text="EventLogPermissionEntryCollection Class" Value="EventLogPermissionEntryCollection Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.IO" Value="System.IO">
									<asp:TreeNode Text="File Class" Value="File Class"></asp:TreeNode>
									<asp:TreeNode Text="FileInfo Class" Value="FileInfo Class"></asp:TreeNode>
									<asp:TreeNode Text="InternalBufferOverflowException Class" Value="InternalBufferOverflowException Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.WebControls" Value="ASP.NET">
									<asp:TreeNode Text="CheckBoxList Class" Value="CheckBoxList"></asp:TreeNode>
									<asp:TreeNode Text="Content Class" Value="Content"></asp:TreeNode>
									<asp:TreeNode Text="ContentPlaceHolder Class" Value="ContentPlaceHolder"></asp:TreeNode>
									<asp:TreeNode Text="Label Class" Value="Label"></asp:TreeNode>
									<asp:TreeNode Text="TextBox Class" Value="TextBox"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web" Value="System.Web">
									<asp:TreeNode Text="HttpRequest Class" Value="HttpRequest Class"></asp:TreeNode>
									<asp:TreeNode Text="HttpWorkerRequest Class" Value="HttpWorkerRequest Class"></asp:TreeNode>
									<asp:TreeNode Text="HttpWorkerRequest.EndOfSendNotification Delegate" Value="HttpWorkerRequest.EndOfSendNotification Delegate"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.Caching" Value="System.Web.Caching">
									<asp:TreeNode Text="AggregateCacheDependency Class" Value="AggregateCacheDependency Class"></asp:TreeNode>
									<asp:TreeNode Text="DatabaseNotEnabledForNotificationException Class" Value="DatabaseNotEnabledForNotificationException Class"></asp:TreeNode>
									<asp:TreeNode Text="SqlCacheDependency Class" Value="SqlCacheDependency Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls" Value="System.Web.UI.MobileControls">
									<asp:TreeNode Text="DeviceSpecific Class" Value="DeviceSpecific Class"></asp:TreeNode>
									<asp:TreeNode Text="LiteralTextContainerControlBuilder Class" Value="LiteralTextContainerControlBuilder Class"></asp:TreeNode>
									<asp:TreeNode Text="ObjectListShowCommandsEventHandler Delegate" Value="ObjectListShowCommandsEventHandler Delegate"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls.Adapters" Value="System.Web.UI.MobileControls.Adapters">
									<asp:TreeNode Text="HtmlAdapter Class" Value="HtmlAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="HtmlPanelAdapter Class" Value="HtmlPanelAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="WmlControlAdapter Class" Value="WmlControlAdapter Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls.Adapters.XhtmlAdapters" Value="System.Web.UI.MobileControls.Adapters.XhtmlAdapters">
									<asp:TreeNode Text="XhtmlCalendarAdapter Class " Value="XhtmlCalendarAdapter Class "></asp:TreeNode>
									<asp:TreeNode Text="XhtmlCommandAdapter Class" Value="XhtmlCommandAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="XhtmlFormAdapter Class" Value="XhtmlFormAdapter Class"></asp:TreeNode>
								</asp:TreeNode>
							</asp:TreeNode>
						</Nodes>
					</asp:TreeView>	
					</div>			
				</td>
				<td id="tdMid2" style="height:200px;width:6px;background-color:lightsteelblue;"></td>
				<td id="tdEdit2" align="left" valign="top" style="height:200px;"> 
						<textarea runat="server" id="txtEdit2" 
						style="margin:0px;height:100%;width:100%;padding:0px 0px 0px 6px;
						border:none;"></textarea>
				</td>
			
			</tr>
		</table>
		<span style="font-family:Verdana;font-size:10pt;">
		Current Width: 
		</span>
		<input type="text" id="txtWidth2" value="250px" 
		style="width:70px;font-family:Verdana;font-size:10pt;"/>
		</div>	
		<VwdCms:SplitterBar runat="server" ID="vsbSplitter2" 
			LeftResizeTargets="tdTree2" 
			MinWidth="100" 
			MaxWidth="700"
			BackgroundColor="lightsteelblue" 
			BackgroundColorLimit="firebrick"
			BackgroundColorHilite="steelblue"
			BackgroundColorResizing="purple"
			SaveWidthToElement="txtWidth2"
			OnResize="splitterOnResize"
			style="background-image:url(vsplitter.gif);
				background-position:center center;
				background-repeat:no-repeat;"/> 
				

		<!-- ********* -->
		<!-- version C -->
		<!-- ********* -->
		<br />
		<br />
		<div style="width:800px;font-family:Verdana;font-size:8pt;text-align:left;
			padding:5px;background-color:#efefef;border:solid 1px silver;">
		<b>Version C</b>: Works if FireFox, but not in IE 7. To see the problem 
		 move the SplitterBar all the way to the right. The table expands beyond 
		 the 800px max. This is because the TextArea is refusing to shrink down its width.</div>
		<br />
		<div style="text-align:left;border:dotted 1px silver;width:800px;background-color:ghostwhite;font-weight:bold;padding:10px;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;VwdCms:SplitterBar runat=&quot;server&quot; ID=&quot;vsbSplitter3&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeftResizeTargets=&quot;tdTree3;divTree3&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MinWidth=&quot;100&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaxWidth=&quot;700&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColor=&quot;lightsteelblue&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorLimit=&quot;firebrick&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorHilite=&quot;steelblue&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorResizing=&quot;purple&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SaveWidthToElement=&quot;txtWidth3&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnResize=&quot;splitterOnResize&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;style=&quot;background-image:url(vsplitter.gif);<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;background-position:center center;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;background-repeat:no-repeat;&quot;/&gt; 		</div>
		<br />
		<div style="margin:0px;padding:0px;width:800px;overflow:hidden;">
		<table border="0" cellpadding="0" cellspacing="0" 
			style="width:800px;height:200px;border:solid 1px #6699CC;">
			<tr style="height:200px;">
				<td id="tdTree3" style="width:250px;height:200px;" align="left" valign="top"> 
					<div id="divTree3" style="width:250px;height:100%;overflow:auto;padding:0px;margin:0px;">
					<asp:TreeView ID="tvwFramework3" runat="server" ShowLines="True"
						style="width:100%;height:100%;padding:0px;margin:0px;">
						<Nodes>
							<asp:TreeNode Text=".NET Framework" Value=".NET Framework">
								<asp:TreeNode Text="System.Diagnostics" Value="System.Diagnostics">
									<asp:TreeNode Text="Debug Class" Value="Debug"></asp:TreeNode>
									<asp:TreeNode Text="DebuggableAttribute.DebuggingModes Enumeration" Value="DebuggableAttribute.DebuggingModes Enumeration"></asp:TreeNode>
									<asp:TreeNode Text="EventLogPermissionEntryCollection Class" Value="EventLogPermissionEntryCollection Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.IO" Value="System.IO">
									<asp:TreeNode Text="File Class" Value="File Class"></asp:TreeNode>
									<asp:TreeNode Text="FileInfo Class" Value="FileInfo Class"></asp:TreeNode>
									<asp:TreeNode Text="InternalBufferOverflowException Class" Value="InternalBufferOverflowException Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.WebControls" Value="ASP.NET">
									<asp:TreeNode Text="CheckBoxList Class" Value="CheckBoxList"></asp:TreeNode>
									<asp:TreeNode Text="Content Class" Value="Content"></asp:TreeNode>
									<asp:TreeNode Text="ContentPlaceHolder Class" Value="ContentPlaceHolder"></asp:TreeNode>
									<asp:TreeNode Text="Label Class" Value="Label"></asp:TreeNode>
									<asp:TreeNode Text="TextBox Class" Value="TextBox"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web" Value="System.Web">
									<asp:TreeNode Text="HttpRequest Class" Value="HttpRequest Class"></asp:TreeNode>
									<asp:TreeNode Text="HttpWorkerRequest Class" Value="HttpWorkerRequest Class"></asp:TreeNode>
									<asp:TreeNode Text="HttpWorkerRequest.EndOfSendNotification Delegate" Value="HttpWorkerRequest.EndOfSendNotification Delegate"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.Caching" Value="System.Web.Caching">
									<asp:TreeNode Text="AggregateCacheDependency Class" Value="AggregateCacheDependency Class"></asp:TreeNode>
									<asp:TreeNode Text="DatabaseNotEnabledForNotificationException Class" Value="DatabaseNotEnabledForNotificationException Class"></asp:TreeNode>
									<asp:TreeNode Text="SqlCacheDependency Class" Value="SqlCacheDependency Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls" Value="System.Web.UI.MobileControls">
									<asp:TreeNode Text="DeviceSpecific Class" Value="DeviceSpecific Class"></asp:TreeNode>
									<asp:TreeNode Text="LiteralTextContainerControlBuilder Class" Value="LiteralTextContainerControlBuilder Class"></asp:TreeNode>
									<asp:TreeNode Text="ObjectListShowCommandsEventHandler Delegate" Value="ObjectListShowCommandsEventHandler Delegate"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls.Adapters" Value="System.Web.UI.MobileControls.Adapters">
									<asp:TreeNode Text="HtmlAdapter Class" Value="HtmlAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="HtmlPanelAdapter Class" Value="HtmlPanelAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="WmlControlAdapter Class" Value="WmlControlAdapter Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls.Adapters.XhtmlAdapters" Value="System.Web.UI.MobileControls.Adapters.XhtmlAdapters">
									<asp:TreeNode Text="XhtmlCalendarAdapter Class " Value="XhtmlCalendarAdapter Class "></asp:TreeNode>
									<asp:TreeNode Text="XhtmlCommandAdapter Class" Value="XhtmlCommandAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="XhtmlFormAdapter Class" Value="XhtmlFormAdapter Class"></asp:TreeNode>
								</asp:TreeNode>
							</asp:TreeNode>
						</Nodes>
					</asp:TreeView>	
					</div>			
				</td>
				<td id="tdMid3" style="height:200px;width:6px;background-color:lightsteelblue;"></td>
				<td id="tdEdit3" align="left" valign="top" style="height:200px;"> 
						<textarea runat="server" id="txtEdit3" 
						style="margin:0px;height:100%;width:100%;padding:0px 0px 0px 5px;
						border:none;"
>The TreeView control is used to display hierarchical data, such as a table of contents or file directory, in a tree structure and supports the following features: 
Data binding that allows the nodes of the control to be bound to XML, tabular, or relational data.
Site navigation through integration with the SiteMapDataSource control.
Node text that can be displayed as either plain text or hyperlinks.
Programmatic access to the TreeView object model to create trees, populate nodes, set properties, and so on dynamically.
Client-side node population (on supported browsers).
The ability to display a check box next to each node.
Customizable appearance through themes, user-defined images, and styles. 
Nodes
The TreeView control is made up of nodes. Each entry in the tree is called a node and is represented by a TreeNode object. Node types are defined as follows:
A node that contains other nodes is called a parent node. 
The node that is contained by another node is called a child node. 
A node that has no children is called a leaf node. 
The node that is not contained by any other node but is the ancestor to all the other nodes is the root node. 
</textarea>
				</td>
			
			</tr>
		</table>
		<span style="font-family:Verdana;font-size:10pt;">
		Current Width: 
		</span>
		<input type="text" id="txtWidth3" value="250px" 
		style="width:70px;font-family:Verdana;font-size:10pt;"/>
		</div>	
		<VwdCms:SplitterBar runat="server" ID="vsbSplitter3" 
			LeftResizeTargets="tdTree3;divTree3" 
			MinWidth="100" 
			MaxWidth="700"
			BackgroundColor="lightsteelblue" 
			BackgroundColorLimit="firebrick"
			BackgroundColorHilite="steelblue"
			BackgroundColorResizing="purple"
			SaveWidthToElement="txtWidth3"
			OnResize="splitterOnResize"
			style="background-image:url(vsplitter.gif);
				background-position:center center;
				background-repeat:no-repeat;"/> 
				

		<!-- ********* -->
		<!-- version D -->
		<!-- ********* -->
		<br />
		<br />
		<div style="width:800px;font-family:Verdana;font-size:8pt;text-align:left;
			padding:5px;background-color:#efefef;border:solid 1px silver;">
		<b>Version D</b>: This version is the same as Version A but I have turned on 
		the DynamicResizing so that the table cells will be resized as the 
		SplitterBar is dragged across the screen.  This version works well in Firefox 
		but in IE 7, depending on how quickly I move the cursor, I sometimes see a 
		lot of flashing in the TextArea as I am resizing. <b>Warning:</b> For really 
		simple content in the tables, this feature makes the resizing smooth and 
		cool looking. But for more complex pages, this can really 
		cause problems if there is a lot of content that will need to be re-rendered by 
		the browser every time the width changes. When DynamicResizing is on you may 
		 get slow UI performance and 
		a lot of flashing/flickering. If you see flickering and slowness while resizing,
		turning off DynamicResizing is probably going to give your users a better experience.</div>
		<br />
		<div style="text-align:left;border:dotted 1px silver;width:800px;background-color:ghostwhite;font-weight:bold;padding:10px;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;VwdCms:SplitterBar runat=&quot;server&quot; ID=&quot;vsbSplitter4&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DynamicResizing=&quot;true&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LeftResizeTargets=&quot;tdTree4;divTree4&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MinWidth=&quot;100&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaxWidth=&quot;700&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColor=&quot;lightsteelblue&quot; <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorLimit=&quot;firebrick&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorHilite=&quot;steelblue&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColorResizing=&quot;purple&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SaveWidthToElement=&quot;txtWidth4&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnResize=&quot;splitterOnResize&quot;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;style=&quot;background-image:url(vsplitter.gif);<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;background-position:center center;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;background-repeat:no-repeat;&quot;/&gt; <br />
		</div>
		<br />
		<div style="margin:0px;padding:0px;width:800px;overflow:hidden;">
		<table border="0" cellpadding="0" cellspacing="0" 
			style="width:800px;height:200px;border:solid 1px #6699CC;">
			<tr style="height:200px;">
				<td id="tdTree4" style="width:250px;height:200px;" align="left" valign="top"> 
					<div id="divTree4" style="width:250px;height:100%;overflow:auto;padding:0px;margin:0px;">
					<asp:TreeView ID="tvwFramework4" runat="server" ShowLines="True"
						style="width:100%;height:100%;padding:0px;margin:0px;">
						<Nodes>
							<asp:TreeNode Text=".NET Framework" Value=".NET Framework">
								<asp:TreeNode Text="System.Diagnostics" Value="System.Diagnostics">
									<asp:TreeNode Text="Debug Class" Value="Debug"></asp:TreeNode>
									<asp:TreeNode Text="DebuggableAttribute.DebuggingModes Enumeration" Value="DebuggableAttribute.DebuggingModes Enumeration"></asp:TreeNode>
									<asp:TreeNode Text="EventLogPermissionEntryCollection Class" Value="EventLogPermissionEntryCollection Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.IO" Value="System.IO">
									<asp:TreeNode Text="File Class" Value="File Class"></asp:TreeNode>
									<asp:TreeNode Text="FileInfo Class" Value="FileInfo Class"></asp:TreeNode>
									<asp:TreeNode Text="InternalBufferOverflowException Class" Value="InternalBufferOverflowException Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.WebControls" Value="ASP.NET">
									<asp:TreeNode Text="CheckBoxList Class" Value="CheckBoxList"></asp:TreeNode>
									<asp:TreeNode Text="Content Class" Value="Content"></asp:TreeNode>
									<asp:TreeNode Text="ContentPlaceHolder Class" Value="ContentPlaceHolder"></asp:TreeNode>
									<asp:TreeNode Text="Label Class" Value="Label"></asp:TreeNode>
									<asp:TreeNode Text="TextBox Class" Value="TextBox"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web" Value="System.Web">
									<asp:TreeNode Text="HttpRequest Class" Value="HttpRequest Class"></asp:TreeNode>
									<asp:TreeNode Text="HttpWorkerRequest Class" Value="HttpWorkerRequest Class"></asp:TreeNode>
									<asp:TreeNode Text="HttpWorkerRequest.EndOfSendNotification Delegate" Value="HttpWorkerRequest.EndOfSendNotification Delegate"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.Caching" Value="System.Web.Caching">
									<asp:TreeNode Text="AggregateCacheDependency Class" Value="AggregateCacheDependency Class"></asp:TreeNode>
									<asp:TreeNode Text="DatabaseNotEnabledForNotificationException Class" Value="DatabaseNotEnabledForNotificationException Class"></asp:TreeNode>
									<asp:TreeNode Text="SqlCacheDependency Class" Value="SqlCacheDependency Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls" Value="System.Web.UI.MobileControls">
									<asp:TreeNode Text="DeviceSpecific Class" Value="DeviceSpecific Class"></asp:TreeNode>
									<asp:TreeNode Text="LiteralTextContainerControlBuilder Class" Value="LiteralTextContainerControlBuilder Class"></asp:TreeNode>
									<asp:TreeNode Text="ObjectListShowCommandsEventHandler Delegate" Value="ObjectListShowCommandsEventHandler Delegate"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls.Adapters" Value="System.Web.UI.MobileControls.Adapters">
									<asp:TreeNode Text="HtmlAdapter Class" Value="HtmlAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="HtmlPanelAdapter Class" Value="HtmlPanelAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="WmlControlAdapter Class" Value="WmlControlAdapter Class"></asp:TreeNode>
								</asp:TreeNode>
								<asp:TreeNode Text="System.Web.UI.MobileControls.Adapters.XhtmlAdapters" Value="System.Web.UI.MobileControls.Adapters.XhtmlAdapters">
									<asp:TreeNode Text="XhtmlCalendarAdapter Class " Value="XhtmlCalendarAdapter Class "></asp:TreeNode>
									<asp:TreeNode Text="XhtmlCommandAdapter Class" Value="XhtmlCommandAdapter Class"></asp:TreeNode>
									<asp:TreeNode Text="XhtmlFormAdapter Class" Value="XhtmlFormAdapter Class"></asp:TreeNode>
								</asp:TreeNode>
							</asp:TreeNode>
						</Nodes>
					</asp:TreeView>	
					</div>			
				</td>
				<td id="tdMid4" style="height:200px;width:6px;background-color:lightsteelblue;"></td>
				<td id="tdEdit4" align="left" valign="top" style="height:200px;"> 
						<textarea runat="server" id="txtEdit4" 
						style="margin:0px;height:100%;width:100%;padding:0px 0px 0px 5px;
						border:none;"></textarea>
				</td>
			
			</tr>
		</table>
		<span style="font-family:Verdana;font-size:10pt;">
		Current Width: 
		</span>
		<input type="text" id="txtWidth4" value="250px" 
		style="width:70px;font-family:Verdana;font-size:10pt;"/>
		</div>	
		<VwdCms:SplitterBar runat="server" ID="vsbSplitter4" 
			DynamicResizing="true"
			LeftResizeTargets="tdTree4;divTree4" 
			MinWidth="100" 
			MaxWidth="700"
			BackgroundColor="lightsteelblue" 
			BackgroundColorLimit="firebrick"
			BackgroundColorHilite="steelblue"
			BackgroundColorResizing="purple"
			SaveWidthToElement="txtWidth4"
			OnResize="splitterOnResize"
			style="background-image:url(vsplitter.gif);
				background-position:center center;
				background-repeat:no-repeat;"/> 
				


		<br />
		<br />
		<br />
<script type="text/javascript">
var text = "The TreeView control is used to display hierarchical data, such as a table of contents or file directory, in a tree structure and supports the following features: \r\n"
	+ "Data binding that allows the nodes of the control to be bound to XML, tabular, or relational data.\r\n"
	+ "Site navigation through integration with the SiteMapDataSource control.\r\n"
	+ "Node text that can be displayed as either plain text or hyperlinks.\r\n"
	+ "Programmatic access to the TreeView object model to create trees, populate nodes, set properties, and so on dynamically.\r\n"
	+ "Client-side node population (on supported browsers).\r\n"
	+ "The ability to display a check box next to each node.\r\n"
	+ "Customizable appearance through themes, user-defined images, and styles. \r\n"
	+ "Nodes\r\n"
	+ "The TreeView control is made up of nodes. Each entry in the tree is called a node and is represented by a TreeNode object. Node types are defined as follows:\r\n"
	+ "A node that contains other nodes is called a parent node. \r\n"
	+ "The node that is contained by another node is called a child node. \r\n"
	+ "A node that has no children is called a leaf node. \r\n"
	+ "The node that is not contained by any other node but is the ancestor to all the other nodes is the root node. \r\n";
	
document.getElementById("txtEdit1").value = text;
document.getElementById("txtEdit2").value = text;
document.getElementById("txtEdit4").value = text;

</script>
	</center>
    </div>
    </form>
</body>
</html>

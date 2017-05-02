<%@ Page Language="C#" 
MasterPageFile="ExampleMaster.master" 
AutoEventWireup="true" 
Title="Example 7" 
CodeFile="Example7.aspx.cs" 
Inherits="Example7"
%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
VwdCms.SplitterBar : Example 7
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<!--
//---------------------------------------------------
//     Copyright (c) 2007 Jeffrey Bazinet, VWD-CMS 
//     http://www.vwd-cms.com/  All rights reserved.
//---------------------------------------------------
-->
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
	
	<div style="width:800px;font-family:Verdana;font-size:8pt;text-align:left;
		padding:5px;background-color:#efefef;border:solid 1px silver;font-weight:bold;
		color:firebrick;">
		This example is essentially the same as example 1-A except that the web page is using a 
		Master Page.
	</div>
	<br />

	<!-- ********* -->
	<!-- version A -->
	<!-- ********* -->
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
				<div runat="server" id="divTree1" 
				style="width:250px;height:100%;overflow:auto;padding:0px;margin:0px;">
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
			<td id="tdEdit1" align="left" valign="top" style="height:200px;padding:0px 0px 0px 0px;"> 
					<textarea runat="server" id="txtEdit1" 
					style="margin:0px;width:100%;height:200px;border-width:0px;
					padding:0px;border:none;"></textarea>
			</td>
		
		</tr>
	</table>
	</div>
	
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
			background-repeat:no-repeat;" /> 

			
<script type="text/javascript">
function onPageLoad()
{
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
	
	var id = "<%=this.txtEdit1.ClientID%>";
	document.getElementById(id).value = text;
}

</script>
</asp:Content>


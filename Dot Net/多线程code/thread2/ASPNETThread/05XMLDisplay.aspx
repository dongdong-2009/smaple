<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page language="c#" Codebehind="05XMLDisplay.aspx.cs" AutoEventWireup="false" Inherits="ASPNETThread.XMLDisplay" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>XMLDisplay</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="XMLDisplay" method="post" runat="server" enctype="multipart/form-data">
			<iewc:TreeView id="TreeView1" style="Z-INDEX: 100; LEFT: 71px; POSITION: absolute; TOP: 163px" runat="server" Height="252px" Width="428px" ExpandLevel="1"></iewc:TreeView>
			<asp:Button id="btnAddFile" style="Z-INDEX: 105; LEFT: 306px; POSITION: absolute; TOP: 85px" runat="server" Width="61px" Text="添加文件"></asp:Button>
			<INPUT id="FileXML" style="Z-INDEX: 101; LEFT: 72px; POSITION: absolute; TOP: 86px" type="file" name="File1" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 61px; POSITION: absolute; TOP: 22px" runat="server">请选择XML文件：</asp:Label>
			<asp:Button id="btnProcess" style="Z-INDEX: 104; LEFT: 385px; POSITION: absolute; TOP: 86px" runat="server" Text="填充" Width="61px"></asp:Button>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="03ScanPort.aspx.cs" AutoEventWireup="false" Inherits="ASPNETThread.ScanPortPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ScanPort</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FONT face="宋体">
			<asp:label class="BodyText" id="info" runat="server" text="ip/host to scan, one url per entry."></asp:label><BR>
			<asp:Repeater id="ResultList" runat="server">
				<HeaderTemplate>
					<table class="BodyText" border="0" cellpadding="3" cellspacing="3">
						<tr>
							<td><b>状态</b></td>
							<td><b>IP</b></td>
							<td><b>端口</b></td>
							<td><b>返回 / 超时</b></td>
						</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td><%# DataBinder.Eval(Container.DataItem, "status") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "ip") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "port") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "timeSpent") %></td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</table>
				</FooterTemplate>
			</asp:Repeater>
			<form id="Form1" method="post" runat="server">
				<TABLE class="BodyText" id="Table1">
					<TR>
						<TD vAlign="top">urls:</TD>
						<TD>
							<asp:textbox class="BodyText" id="urls" runat="server" text="" rows="10" columns="50" textmode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="right" colSpan="2">
							<asp:button class="BodyText" id="Button1" runat="server" text="scan!" type="submit"></asp:button></TD>
					</TR>
				</TABLE>
			</form>
		</FONT>
	</body>
</HTML>

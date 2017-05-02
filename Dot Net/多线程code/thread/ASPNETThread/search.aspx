<%@ Page Language="c#" AutoEventWireUp="false" Inherits="ASPNETThread.SearchEngine" Src="search.aspx.cs" CodeBehind="search.aspx.cs" %>
<HTML>
	<HEAD>
		<title>Multi-threaded Search Engine</title>
		<style>.BodyText { FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: verdana }
	</style>
	</HEAD>
	<body>
		<asp:label id="info" class="BodyText" text="URL of the web sites to search, one url per line." runat="server">要查找的Web站点的URL：</asp:label><br>
		<asp:Repeater id="ResultList" runat="server">
			<HeaderTemplate>
				<table class="BodyText" border="0" cellpadding="3" cellspacing="3">
					<tr>
						<td><b>Found</b></td>
						<td><b>Web Page Title</b></td>
						<td><b>Web Page URL</b></td>
						<td><b>Searched Time</b></td>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td><%# DataBinder.Eval(Container.DataItem, "instanceCount") %></td>
					<td><%# DataBinder.Eval(Container.DataItem, "pageTitle") %></td>
					<td><%# DataBinder.Eval(Container.DataItem, "pageURL") %></td>
					<td><%# DataBinder.Eval(Container.DataItem, "timeSpent") %></td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
				</table>
			</FooterTemplate>
		</asp:Repeater>
		<form id="SearchForm" runat="server">
			<table class="BodyText" height="205">
				<tr>
					<td>关键字:</td>
					<td><asp:textbox class="BodyText" text="news" id="keyword" runat="server" /></td>
				</tr>
				<tr>
					<td valign="top">URL:</td>
					<td><asp:textbox class="BodyText" text="" id="urls" rows="10" columns="30" textmode="MultiLine" runat="server" /></td>
				</tr>
				<tr>
					<td align="right" colspan="2">
						<asp:button class="BodyText" text="查找！" type="submit" onclick="search" runat="server" id="btnSearch" />
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

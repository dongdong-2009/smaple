<%@ Page language="c#" Codebehind="02SearchEngine.aspx.cs" AutoEventWireup="false" Inherits="ASPNETThread.SearchEngine1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SearchEngine</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<P><FONT face="����">
				<asp:label class="BodyText" id="info" runat="server" text="URL of the web sites to search, one url per line.">Ҫ���ҵ�Webվ���URL��</asp:label><BR>
				<asp:Repeater id="ResultList" runat="server">
					<HeaderTemplate>
						<table class="BodyText" border="0" cellpadding="3" cellspacing="3">
							<tr>
								<td><b>�ҵ��ؼ��ָ���</b></td>
								<td><b>ҳ�����</b></td>
								<td><b>URL</b></td>
								<td><b>����ʱ��</b></td>
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
				<FORM id="SearchForm" runat="server">
					<TABLE class="BodyText" id="Table1" height="205">
						<TR>
							<TD>�ؼ���:</TD>
							<TD>
								<asp:textbox class="BodyText" id="keyword" runat="server" text="news">news</asp:textbox></TD>
						</TR>
						<TR>
							<TD vAlign="top">URL:</TD>
							<TD>
								<asp:textbox class="BodyText" id="urls" runat="server" text="" rows="10" columns="30" textmode="MultiLine"></asp:textbox></TD>
						</TR>
						<TR>
							<TD align="right" colSpan="2">
								<asp:button class="BodyText" id="btnSearch" runat="server" text="���ң�" type="submit"></asp:button>
								<asp:button class="BodyText" id="btnNothread" text="�����̲߳��ң�" runat="server" type="submit"></asp:button></TD>
						</TR>
					</TABLE>
				</FORM>
			</FONT>
		</P>
	</body>
</HTML>

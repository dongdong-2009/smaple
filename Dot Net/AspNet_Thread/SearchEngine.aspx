<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="SearchEngine.aspx.cs" Inherits="SearchEngine1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ޱ���ҳ</title>
</head>
	
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
								<asp:textbox class="BodyText" id="urls" runat="server" text="http://www.cnn.com
http://www.usatoday.com
http://www.msnbc.com
http://www.wsj.com
http://news.yahoo.com
http://www.nytimes.com
http://www.abcnews.com
http://www.foxnews.com
http://www.nypost.com
http://news.com.com" rows="10" columns="30" textmode="MultiLine"></asp:textbox></TD>
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

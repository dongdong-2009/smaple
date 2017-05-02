<%@Page Language="C#" Inherits="Article.Admin.Main" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text">&nbsp; <%=lang["welcome"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label ID="SysInfo" runat="server" Style="line-height:150%; padding:10px 20px; display:block" />
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>

&nbsp;

<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text">&nbsp; <%=lang["admin_chart"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:DataList id="myDL"
		Width="100%"
		Align="center"
		CellPadding="3"
		CellSpacing="0"
		GridLines="both"
		RepeatColumns="4"
		RepeatDirection="Horizontal"
		RepeatLayout="Table"
		ShowHeader="false"
		ShowFooter="false"
		runat="server" >
		<AlternatingItemStyle CssClass="bg2" />
		<HeaderStyle CssClass="title1" Height="25" HorizontalAlign="center"/>
		<ItemStyle Height="25" Width="25%" CssClass="" />
		<ItemTemplate>
			<%#GetName(DataBinder.Eval(Container.DataItem,"username").ToString())%> (<%#DataBinder.Eval(Container.DataItem,"addnum")%><%#lang["news_unit"]%>)
		</ItemTemplate>
	</asp:DataList>
	
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>

<br>
<center>Powered by <asp:Label ID="CopyRight" runat="server" /></center>
</body>
</html>
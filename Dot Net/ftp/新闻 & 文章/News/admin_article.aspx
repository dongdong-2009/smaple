<%@Page Language="C#" Inherits="Article.Admin.Article" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<asp:Label id=myLabel width=100% Style="text-align:center" runat=server/>
<table align=center height=40 width="90%"><tr>
<form action="" method="get">
<td align=right>
<%=lang["news_search"]%><input type=text size=15 name="keyword">
<select name="where" >
	<option value="title"><%=lang["search_title"]%></option>
	<option value="content"><%=lang["search_content"]%></option>
	<option value="id">ID</option>
</select>
<input type="submit" value="<%=lang["search_submit"]%>"></button>
</td></form>
<td width="30%" align=right>
	<asp:Literal id="dropClass" runat=server/>
</td>
</tr></table>


<form id="myForm" Style="margin:0px" runat=server>

<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text">&nbsp; <%=lang["title_admin_news"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<ASP:DataGrid id="MyDataGrid" runat="server"
			Width="100%"
			Align=center
			ShowHeader="true"
			ShowFooter="false"
			CellPadding="0"
			AutoGenerateColumns="false"
			DataKeyField="articleid"
			OnDeleteCommand="MyDataGrid_Delete"
			OnItemDataBound="MyDataGrid_ItemDataBound"
			HeaderStyle-CssClass="summary-title"
			ItemStyle-CssClass="tdbg"
			CellSpacing="0" >
		<HeaderStyle HorizontalAlign="center" Height="25" />
		<ItemStyle Height="23"/>
		
		<Columns>
			<asp:TemplateColumn
				HeaderText="新闻标题(点击修改)"
			>
				<ItemTemplate>
				<%# TitleUrl((string)DataBinder.Eval(Container.DataItem, "title"),(Int32)DataBinder.Eval(Container.DataItem, "articleid"),(bool)DataBinder.Eval(Container.DataItem, "imgnews"),(bool)DataBinder.Eval(Container.DataItem, "headline"),(int)DataBinder.Eval(Container.DataItem,"classid"),(int)DataBinder.Eval(Container.DataItem,"userid"),DataBinder.Eval(Container.DataItem,"permitGroups").ToString() ) %>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:HyperLinkColumn
				HeaderText="分类"
				DataTextField="class"
				DataNavigateUrlField="classid"
				DataNavigateUrlFormatString="?cid={0}"
				 >
				<ItemStyle Width="80" HorizontalAlign="center" />
			</asp:HyperLinkColumn>
			<asp:ButtonColumn
				ButtonType="LinkButton"
				CommandName="Delete"
				Text="删除" >
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:ButtonColumn>
			<asp:TemplateColumn
				HeaderText=""
				>
				<ItemTemplate>
				<a href="admin_remark.aspx?id=<%#DataBinder.Eval(Container.DataItem,"articleid")%>" title="<%#DataBinder.Eval(Container.DataItem,"remarkNum")%>" target="_self"><%=lang["remark_text"]%></a>
				</ItemTemplate>
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:TemplateColumn>
		</Columns>
	</ASP:DataGrid>
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




<table width=90% align=center><tr><td align=right>
<asp:Label id=PageList runat=server/>
</td></tr>
<tr><td height=30 valign=bottom>
<%=lang["note"]%><img src=pic/canedit.gif align=absmiddle><%=lang["have_right_icon"]%> &nbsp; <img src=pic/cantedit.gif align=absmiddle><%=lang["no_right_icon"]%>
</td></tr></table>

</form>

</body>
</html>
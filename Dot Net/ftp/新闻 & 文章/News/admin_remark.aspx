<%@Page Language="C#" Inherits="Article.Admin.Remark" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>


<asp:Label id=myLabel width=100% style="text-align:center" runat=server/>
<table align=center height=40><tr>
<form action="" method="get">
<td>
<%=lang["remark_search"]%><input type="hidden" name="id" value="<%=articleid%>">
<input type=text size=15 name="keyword">
<select name="where" >
	<option value="body"><%=lang["search_content"]%></option>
	<option value="username"><%=lang["search_author"]%></option>
</select>
<input type="submit" value="<%=lang["search_submit_text"]%>"></button>
</td>
</form></tr></table>

<form id="myForm" Style="margin:0px" runat=server>

<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_manage_remark"]%></span>
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
			DataKeyField="remarkid"
			OnDeleteCommand="MyDataGrid_Delete"
			OnItemDataBound="MyDataGrid_ItemDataBound"
			HeaderStyle-CssClass="summary-title"
			ItemStyle-CssClass="tdbg"
			CellSpacing="0" >
		<HeaderStyle HorizontalAlign="center" Height="25" />
		<ItemStyle Height="23"/>
		
		<Columns>
			<asp:BoundColumn
				HeaderText="评论内容"
				DataField="body"
				/>
			<asp:BoundColumn
				HeaderText="作者"
				DataField="username" >
				<ItemStyle Width="70" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:BoundColumn
				HeaderText="IP"
				DataField="ip" >
				<ItemStyle Width="100" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:TemplateColumn
				HeaderText="新闻">
				<ItemTemplate>
				<a href="show.aspx?id=<%#DataBinder.Eval(Container.DataItem,"articleid")%>" target="_blank" title="<%#((string)DataBinder.Eval(Container.DataItem,"title")).Replace("\"","&quot;")%>"><%#StringLeft((string)DataBinder.Eval(Container.DataItem,"title"),16)%></a>
				</ItemTemplate>
				<ItemStyle Width="100" HorizontalAlign="left" />
			</asp:TemplateColumn>
			<asp:ButtonColumn
				ButtonType="LinkButton"
				CommandName="Delete"
				Text="删除" >
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:ButtonColumn>
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
</td></tr></table>

</form>

</body>
</html>
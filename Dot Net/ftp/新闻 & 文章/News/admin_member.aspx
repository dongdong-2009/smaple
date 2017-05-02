<%@Page Language="C#" Inherits="Article.Admin.Member" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>


<asp:Label id=myLabel width=100% Style="text-align:center" runat=server/>

<table align=center height=40><tr>
<form action="" method="get">
<td>
	<%=lang["member_search"]%><input type=text size=15 name="keyword">
<select name="where" >
	<option value="name"><%=lang["search_name"]%></option>
</select>
<input type="submit" value="<%=lang["search_submit_text"]%>"></button>
</td>
</form></tr></table>

<form id="myForm" Style="margin:0px" runat=server>

<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_manage_member"]%></span>
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
			DataKeyField="id"
			AllowPaging="true"
			OnDeleteCommand="MyDataGrid_Delete"
			OnItemDataBound="MyDataGrid_ItemDataBound"
			OnPageIndexChanged="MyDataGrid_Page"
			HeaderStyle-CssClass="summary-title"
			ItemStyle-CssClass="tdbg"
			CellSpacing="0" >
		<HeaderStyle HorizontalAlign="center" Height="25" />
		<EditItemStyle CssClass="tdbg-dark" />
		<ItemStyle Height="23"/>
		<PagerStyle Mode="NumericPages" PageButtonCount="10" HorizontalAlign="Right" />
		
		<Columns>
			<asp:HyperLinkColumn
				DataNavigateUrlField="id"
				DataNavigateUrlFormatString="admin_memberadd.aspx?id={0}"
				Text="修改"
				>
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:HyperLinkColumn>
			<asp:TemplateColumn
				HeaderText="会员名">
				<ItemTemplate>
					<%#DataBinder.Eval(Container.DataItem,"name")%>
				</ItemTemplate>
				<ItemStyle Width="90" HorizontalAlign="center" />
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="密码">
				<ItemTemplate>
					******
				</ItemTemplate>
				<ItemStyle Width="80" HorizontalAlign="center" />
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="email">
				<ItemTemplate>
					<a href="admin_sendmail.aspx?mailto=<%#DataBinder.Eval(Container.DataItem,"email")%>"><%#DataBinder.Eval(Container.DataItem,"email")%></a>
				</ItemTemplate>
				<ItemStyle Width="80" HorizontalAlign="center" />
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="会员组">
				<ItemTemplate>
					<%#GetGroup(DataBinder.Eval(Container.DataItem,"groupid").ToString())%>
				</ItemTemplate>
				<ItemStyle Width="120" HorizontalAlign="center" />
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="备注">
				<ItemTemplate>
					<%#DataBinder.Eval(Container.DataItem,"remarks")%>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="推荐数">
				<ItemTemplate>
					<%#DataBinder.Eval(Container.DataItem,"addNum")%>
				</ItemTemplate>
				<ItemStyle Width="50" HorizontalAlign="center" />
			</asp:TemplateColumn>
			<asp:BoundColumn
				HeaderText="添加日期"
				DataField="adddate"
				DataFormatString="{0:yyyy-MM-dd}"
				ReadOnly="true">
				<ItemStyle Width="80" HorizontalAlign="center" />
			</asp:BoundColumn>
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


</form>

</body>
</html>
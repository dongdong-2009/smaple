<%@Page Language="C#" Inherits="Article.Admin.Class" SmartNavigation="true" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<asp:Label id=myLabel width=100% style="text-align:center" runat=server/>

<form id="myForm" style="margin:0px" runat=server>

<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_class_manage"]%></span>
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
			DataKeyField="classid"
			OnDeleteCommand="MyDataGrid_Delete"
			OnItemCommand="MyDataGrid_ItemCommand"
			OnItemDataBound="MyDataGrid_ItemBound"
			HeaderStyle-CssClass="summary-title"
			ItemStyle-CssClass="tdbg"
			CellSpacing="0"
			>
		<HeaderStyle HorizontalAlign="center" Height="22" />
		<ItemStyle Height="22" />
		<EditItemStyle CssClass="tdbg-dark" />
		
		<Columns>
			<asp:HyperLinkColumn
				DataNavigateUrlField="classid"
				DataNavigateUrlFormatString="admin_classadd.aspx?id={0}"
				Text="更改" >
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:HyperLinkColumn>
			<asp:TemplateColumn
				HeaderText="分类名"
				>
				<ItemTemplate>
				<%#GetTitle(DataBinder.Eval(Container.DataItem,"class").ToString(), (int)DataBinder.Eval(Container.DataItem,"depth"), (int)DataBinder.Eval(Container.DataItem,"child"), (bool)DataBinder.Eval(Container.DataItem,"lastnode") )%>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:ButtonColumn
				HeaderText="上升"
				ButtonType="LinkButton"
				Text="&uarr;"
				CommandName="up"
				>
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:ButtonColumn>
			<asp:ButtonColumn
				HeaderText="下降"
				ButtonType="LinkButton"
				Text="&darr;"
				CommandName="down"
				>
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:ButtonColumn>
			<asp:BoundColumn
				HeaderText="分类ID"
				DataField="classid"
				ReadOnly="true" >
				<ItemStyle Width="50" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:BoundColumn
				HeaderText="新闻数"
				DataField="articleNum"
				ReadOnly="true" >
				<ItemStyle Width="70" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:BoundColumn
				HeaderText="图片新闻数"
				DataField="imgnewsNum"
				ReadOnly="true" >
				<ItemStyle Width="70" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:ButtonColumn
				ButtonType="LinkButton"
				CommandName="Delete"
				Text="删除" >
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:Buttoncolumn>
				
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
<%@Page Language="C#" Inherits="Article.Admin.Key" %>

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
	<span class="mframe-t-text"><%=lang["title_key_manage"]%></span>
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
			AllowPaging = "True"
			PageSize = "20"
			DataKeyField="id"
			OnDeleteCommand="MyDataGrid_Delete"
			OnItemDataBound="MyDataGrid_ItemBound"
			OnPageIndexChanged = "MyDataGrid_Page"
			HeaderStyle-CssClass="summary-title"
			ItemStyle-CssClass="tdbg"
			CellSpacing="0"
			>
		<HeaderStyle HorizontalAlign="center" Height="22" />
		<ItemStyle Height="22" />
		<EditItemStyle CssClass="tdbg-dark" />
		<PagerStyle Height="20" />
		
		<Columns>
			<asp:HyperLinkColumn
				DataNavigateUrlField="id"
				DataNavigateUrlFormatString="admin_keyadd.aspx?id={0}"
				Text="更改" >
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:HyperLinkColumn>
			<asp:BoundColumn
				HeaderText="关键字"
				DataField = "name"
				>
				<ItemStyle Width="100" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:HyperLinkColumn
				HeaderText="链接"
				DataNavigateUrlField="url"
				DataTextField = "url"
				Target="_blank"
				>
				<ItemStyle Width="250" />
			</asp:HyperLinkColumn>
			<asp:BoundColumn
				HeaderText="说明"
				DataField="alt"
				ReadOnly="true" >
				<ItemStyle />
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
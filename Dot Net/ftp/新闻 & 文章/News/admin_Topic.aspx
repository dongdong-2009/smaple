<%@Page Language="C#" Inherits="Article.Admin.Topic" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>


<asp:Label id=myLabel width=100% Style="text-align:center" runat=server/>

<form id="myForm" runat=server>

<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_manage_topic"]%></span>
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
			AllowPaging="true"
			AutoGenerateColumns="false"
			DataKeyField="Topicid"
			OnEditCommand="MyDataGrid_Edit"
			OnDeleteCommand="MyDataGrid_Delete"
			OnCancelCommand="MyDataGrid_Cancel"
			OnUpdateCommand="MyDataGrid_Update"
			OnPageIndexChanged="MyDataGrid_Page"
			OnItemDataBound="MyDataGrid_ItemBound"
			HeaderStyle-CssClass="summary-title"
			ItemStyle-CssClass="tdbg"
			CellSpacing="0" >
		<HeaderStyle HorizontalAlign="center" Height="25" />
		<EditItemStyle CssClass="tdbg-dark" />
		<ItemStyle Height="25"/>
		<PagerStyle Mode="NumericPages" PageButtonCount="10" HorizontalAlign="Right" />
	
		<Columns>
			<asp:EditCommandColumn
				ButtonType="LinkButton"
				EditText="�޸�"
				UpdateText="����"
				CancelText="ȡ��"
				>
				<ItemStyle Width="70" HorizontalAlign="center" />
			</asp:EditCommandColumn>
			<asp:BoundColumn
				HeaderText="ר����"
				DataField="Topic" />
			<asp:BoundColumn
				HeaderText="ר��ID"
				DataField="Topicid"
				ReadOnly="true" >
				<ItemStyle Width="50" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:BoundColumn
				HeaderText="������"
				DataField="newsNum"
				ReadOnly="true" >
				<ItemStyle Width="50" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:ButtonColumn
				ButtonType="LinkButton"
				CommandName="Delete"
				Text="ɾ��" >
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
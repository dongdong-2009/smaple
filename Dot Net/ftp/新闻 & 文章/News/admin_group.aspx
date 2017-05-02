<%@Page Language="C#" Inherits="Article.Admin.Group" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>


<asp:Label id=myLabel width=100% runat=server/>

<form id="myForm" runat=server>

<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_admin_group"]%></span>
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
			OnEditCommand="MyDataGrid_Edit"
			OnCancelCommand="MyDataGrid_Cancel"
			OnUpdateCommand="MyDataGrid_Update"
			OnDeleteCommand="MyDataGrid_Delete"
			OnItemDataBound="MyDataGrid_ItemDataBound"
			HeaderStyle-CssClass="summary-title"
			ItemStyle-CssClass="tdbg"
			CellSpacing="0" >
		<HeaderStyle HorizontalAlign="center" Height="25" />
		<EditItemStyle CssClass="tdbg-dark" />
		<ItemStyle Height="23"/>
		
		<Columns>
			<asp:EditCommandColumn
				ButtonType="LinkButton"
				CancelText="取消"
				EditText="修改"
				UpdateText="更改" >
				<ItemStyle Width="60" HorizontalAlign="center" />
			</asp:EditCommandColumn>
			<asp:TemplateColumn
				HeaderText="会员组名">
				<ItemTemplate>
					<%#DataBinder.Eval(Container.DataItem,"name")%>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox  runat="server"
						id="Groupname"
						Text=<%#DataBinder.Eval(Container.DataItem,"name")%>
						Columns="20"
						MaxLength="100"
						 />
					<asp:RequiredFieldValidator
						ControlToValidate="Groupname"
						ErrorMessage="*"
						runat="server" >
					</asp:RequiredFieldValidator>
				</EditItemTemplate>
				<ItemStyle Width="200" />
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="备注">
				<ItemTemplate>
					<%#DataBinder.Eval(Container.DataItem,"remarks")%>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox  runat="server"
						id="Remarks"
						Text=<%#DataBinder.Eval(Container.DataItem,"remarks")%>
						Columns="30"
						MaxLength="100"
						 />
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn
				HeaderText="会员数"
				DataField="membernum"
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
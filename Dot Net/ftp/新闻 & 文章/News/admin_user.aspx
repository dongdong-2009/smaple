<%@Page Language="C#" Inherits="Article.Admin.User" %>

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
	<span class="mframe-t-text"><%=lang["title_manage_user"]%></span>
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
				HeaderText="用户名">
				<ItemTemplate>
					<%#DataBinder.Eval(Container.DataItem,"username")%>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox  runat="server"
						id="Username"
						Text=<%#DataBinder.Eval(Container.DataItem,"username")%>
						Columns="10"
						 />
					<asp:RequiredFieldValidator
						ControlToValidate="Username"
						ErrorMessage="*"
						runat="server" >
					</asp:RequiredFieldValidator>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="密码">
				<ItemTemplate>
					<%#StringToStar(DataBinder.Eval(Container.DataItem,"password").ToString())%>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox TextMode="Password" runat="server"
						id="password" 
						Columns="10"
						 />
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="信箱">
				<ItemTemplate>
					<a href="admin_sendmail.aspx?mailto=<%#DataBinder.Eval(Container.DataItem,"email")%>"><%#DataBinder.Eval(Container.DataItem,"email")%></a>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox  runat="server"
						id="Email"
						Text=<%#DataBinder.Eval(Container.DataItem,"email")%>
						Columns="10"
						MaxLength="100"
						 />
				<asp:RegularExpressionValidator
					ControlToValidate="Email"
					ValidationExpression="(\w[0-9a-zA-Z_-]*@(\w[0-9a-zA-Z-]*\.)+\w{2,})"
					ErrorMessage="*"
					Display="Dynamic"
					runat=server
					/>
				</EditItemTemplate>
				<ItemStyle HorizontalAlign="center"/>
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="等级<br>(点击改权限)">
				<ItemTemplate>
					<%#GetPopeLink((int)DataBinder.Eval(Container.DataItem,"id"),(int)DataBinder.Eval(Container.DataItem,"flag"))%>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:DropDownList id="UserClass"
						runat=server>
					</asp:DropDownList>
				</EditItemTemplate>
				<ItemStyle Width="100" HorizontalAlign="center" />
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
						Columns="15"
						 />
				</EditItemTemplate>
				<ItemStyle Width="100" HorizontalAlign="center" />
			</asp:TemplateColumn>
			<asp:BoundColumn
				HeaderText="添加新闻数"
				DataField="addnum"
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
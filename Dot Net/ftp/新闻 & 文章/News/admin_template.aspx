<%@Page Language="C#" Inherits="Article.Admin.Template" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>



<form id="myForm" runat=server>

<asp:Label id=myLabel Style="text-align:center" width=100% runat=server/>
<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_template"]%></span>
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
			DataKeyField="templateid"
			OnDeleteCommand="MyDataGrid_Delete"
			OnItemDataBound="MyDataGrid_ItemDataBound"
			HeaderStyle-CssClass="summary-title"
			ItemStyle-CssClass="tdbg"
			CellSpacing="0" >
		<HeaderStyle HorizontalAlign="center" Height="25" />
		<EditItemStyle CssClass="tdbg-dark" />
		<ItemStyle Height="23"/>
		
		<Columns>
			<asp:HyperLinkColumn
				Text="�޸�"
				DataNavigateUrlField="templateid"
				DataNavigateUrlFormatString="admin_templateadd.aspx?id={0}"
				>
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:HyperLinkColumn>
			<asp:TemplateColumn
				HeaderText="ģ����">
				<ItemTemplate>
					<%#DataBinder.Eval(Container.DataItem,"tname")%>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox  runat="server"
						id="tName"
						Text=<%#DataBinder.Eval(Container.DataItem,"tname")%>
						Columns="10"
						 />
					<asp:RequiredFieldValidator
						ControlToValidate="tName"
						ErrorMessage="*"
						runat="server" >
					</asp:RequiredFieldValidator>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="����">
				<ItemTemplate>
					<%#GetSortName(DataBinder.Eval(Container.DataItem,"tSort").ToString())%>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:DropDownList id="tSort"
						runat=server>
						<asp:ListItem value="index">��ҳ</asp:ListItem>
						<asp:ListItem value="list">����ҳ</asp:ListItem>
						<asp:ListItem value="list">����ҳ</asp:ListItem>
					</asp:DropDownList>
				</EditItemTemplate>
				<ItemStyle Width="100" HorizontalAlign="center" />
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="�ļ���ַ">
				<ItemTemplate>
					<%#DataBinder.Eval(Container.DataItem,"tFile")%>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox  runat="server"
						id="tFile"
						Text=<%#DataBinder.Eval(Container.DataItem,"tfile")%>
						Columns="10"
						 />
					<asp:RequiredFieldValidator
						ControlToValidate="tFile"
						ErrorMessage="*"
						runat="server" >
					</asp:RequiredFieldValidator>
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="��ͼ">
				<ItemTemplate>
					<%#DataBinder.Eval(Container.DataItem,"tpic").ToString()=="" ? "" : "<img src="+DataBinder.Eval(Container.DataItem,"tpic")+">"%>
				</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox  runat="server"
						id="Email"
						Text=<%#DataBinder.Eval(Container.DataItem,"tPic")%>
						Columns="10"
						MaxLength="100"
						 />
				</EditItemTemplate>
				<ItemStyle Width="130" HorizontalAlign="center"/>
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="Ĭ��"
				>
				<ItemTemplate>
					<%# (bool)DataBinder.Eval(Container.DataItem,"tDefault") ? "Yes" : ""%>
				</ItemTemplate>
				<ItemStyle Width="30" HorizontalAlign="center"/>
			</asp:TemplateColumn>
			<asp:HyperLinkColumn
				Text="�༭"
				DataNavigateUrlField="tFile"
				DataNavigateUrlFormatString="admin_fileEdit.aspx?file={0}"
				>
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:HyperLinkColumn>
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
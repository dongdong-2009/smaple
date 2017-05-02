<%@Page Language="C#" Inherits="Article.Admin.MemberCheck" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

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

<table width=750 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_check_member"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=750 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label id=myLabel width=100% style="text-align:center" runat=server/>
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
			OnPageIndexChanged="MyDataGrid_Page"
			OnItemCommand="MyDataGrid_Command"
			OnItemDataBound="MyDataGrid_ItemDataBound"
			HeaderStyle-CssClass="summary-title"
			ItemStyle-CssClass="tdbg"
			CellSpacing="0" >
		<HeaderStyle HorizontalAlign="center" Height="25" />
		<EditItemStyle CssClass="tdbg-dark" />
		<ItemStyle Height="23"/>
		<PagerStyle Mode="NumericPages" PageButtonCount="10" HorizontalAlign="Right" />
		
		<Columns>
			<asp:TemplateColumn
				HeaderText="��Ա��"
				>
				<ItemTemplate>
				<a href="admin_member_ncView.aspx?id=<%#DataBinder.Eval(Container.DataItem,"id")%>"><%#DataBinder.Eval(Container.DataItem,"name")%></a>
				</ItemTemplate>
				<ItemStyle Width="90" HorizontalAlign="center" />
			</asp:TemplateColumn>
			<asp:TemplateColumn
				HeaderText="email"
				>
				<ItemTemplate>
					<a href="admin_sendmail.aspx?mailto=<%#DataBinder.Eval(Container.DataItem,"email")%>"><%#DataBinder.Eval(Container.DataItem,"email")%></a>
				</ItemTemplate>
				<ItemStyle Width="80" HorizontalAlign="center" />
			</asp:TemplateColumn>
			<asp:BoundColumn
				HeaderText="����"
				DataField="realname"
				>
				<ItemStyle Width="80" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:TemplateColumn
				HeaderText="�Ա�">
				<ItemTemplate>
					<%#((bool)DataBinder.Eval(Container.DataItem,"male")? "��" : "Ů")%>
				</ItemTemplate>
				<ItemStyle Width="30" HorizontalAlign="center" />
			</asp:TemplateColumn>
			<asp:BoundColumn
				HeaderText="QQ"
				DataField="qq"
				>
				<ItemStyle Width="80" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:TemplateColumn
				HeaderText="����"
				>
				<ItemTemplate>
					<%#DataBinder.Eval(Container.DataItem,"country")%>
					<%#DataBinder.Eval(Container.DataItem,"province")%>
					<%#DataBinder.Eval(Container.DataItem,"city")%>
				</ItemTemplate>
				<ItemStyle Width="" HorizontalAlign="center" />
			</asp:TemplateColumn>
			<asp:BoundColumn
				HeaderText="��������"
				DataField="adddate"
				DataFormatString="{0:yyyy-MM-dd}"
				ReadOnly="true">
				<ItemStyle Width="80" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:BoundColumn
				HeaderText="������"
				DataField="activecode"
				ReadOnly="true">
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:BoundColumn>

			<asp:ButtonColumn
				HeaderText="���"
				ButtonType="LinkButton"
				CommandName="Pass"
				Text="ͨ��" >
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:ButtonColumn>
			<asp:ButtonColumn
				ButtonType="LinkButton"
				CommandName="Delete"
				Text="ɾ��" >
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:ButtonColumn>
				
		</Columns>
	</ASP:DataGrid>
	
	<asp:PlaceHolder id="phPass" Visible=false runat=server >
		<table width=95% align=center>
		<tr><td width=80>
			<%=lang["member_name"]%>
		</td><td>
			<asp:Literal id="name" runat=server/><input type="hidden" id="ihID" runat=server/>
		</td></tr>
		<tr><td>
			<%=lang["member_remarks"]%>
		</td><td>
			<asp:TextBox id="tbRemarks" Size=40 MaxLength=100 runat=server/>
		</td></tr>
		<tr><td>
			<%=lang["member_group"]%>
		</td><td>
			<asp:CheckBoxList id="cblGroup" RepeatDirection="Horizontal" RepeatColumns=8 runat=server/>
		</td></tr>
		<tr><td align=center>
			<%
			btPass.Text=lang["pass_text"].ToString();
			%>
			<asp:Button id="btPass" Onclick="btPass_Onclick" Text="���ͨ��" runat=server/>
		</td></tr>
		</table>
	</asp:PlaceHolder>
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=750 align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>


</form>

</body>
</html>
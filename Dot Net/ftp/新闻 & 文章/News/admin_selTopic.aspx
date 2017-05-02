<%@Page Language="C#" Inherits="Article.Admin.SelTopic" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
<script>
function selTopic(topic,topicid)
{
	opener.setTopic(topic,topicid);
}
</script>
</head>
<body>

<asp:Label id=myLabel width=100% Style="text-align:center" runat=server/>

<form id="myForm" runat=server>

<table width=400 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_select_topic"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=400 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<ASP:DataGrid id="MyDataGrid" runat="server"
			Width="100%"
			Align=center
			ShowHeader="true"
			ShowFooter="false"
			CellPadding=3
			AllowPaging="true"
			AutoGenerateColumns="false"
			DataKeyField="Topicid"
			OnPageIndexChanged="MyDataGrid_Page"
			HeaderStyle-CssClass="summary-title"
			ItemStyle-CssClass="tdbg"
			CellSpacing="0" >
		<HeaderStyle HorizontalAlign="center" />
		
		<Columns>
			<asp:BoundColumn
				HeaderText="专题名"
				DataField="Topic" />
			<asp:BoundColumn
				HeaderText="文章数"
				DataField="newsNum" >
				<ItemStyle Width="50" HorizontalAlign="center" />
			</asp:BoundColumn>
			<asp:TemplateColumn
				HeaderText="选择">
				<ItemTemplate>
				<input type="radio" name="rtopic" onclick="selTopic('<%# (string)DataBinder.Eval(Container.DataItem,"topic")%>','<%#DataBinder.Eval(Container.DataItem,"topicid")%>')">
				</ItemTemplate>
				<ItemStyle Width="40" HorizontalAlign="center" />
			</asp:TemplateColumn>
		</Columns>
	</ASP:DataGrid>	
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=400 align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>





</form>



</body>
</html>
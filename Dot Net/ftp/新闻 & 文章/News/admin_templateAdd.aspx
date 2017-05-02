<%@ Page Language="C#" Inherits="Article.Admin.TemplateAdd" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>


<form id="myForm" runat=server>

<table width=500 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><asp:Literal id="literalTitle" runat=server/><%=lang["title_manage_template"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=500 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label width=100% style="text-align:center" id=myLabel runat=server/> 
	<table cellpadding=3 cellspacing=0 width="95%" align="center" >
	  <tr> 
	   <td width=50>
		<%=lang["template_name"]%>
	</td><td>
		<asp:TextBox Columns=15 MaxLength=15 id="tName" runat=server/>
		<asp:RequiredFieldValidator
			ControlToValidate="tName"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			runat=server
			ControlToValidate="tName"
			ValidationExpression="[^']+"
			ErrorMessage="*"
			Display="Dynamic" />
	</td></tr>
	<tr><td>
		<%=lang["template_sort"]%>
	</td><td>
		<asp:DropDownList id="tSort" runat=server >
			<asp:ListItem Value="index">首页</asp:ListItem>
			<asp:ListItem Value="list">分类页</asp:ListItem>
			<asp:ListItem Value="show">新闻页</asp:ListItem>
		</asp:DropDownList>
	</td></tr>
	<tr><td>
		<%=lang["template_file"]%>
	</td><td>
		<asp:TextBox id="tFile" Size="40" maxLength="200" runat=server />
		<asp:RequiredFieldValidator
			ControlToValidate="tFile"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
	</td></tr>
	<tr><td>
		<%=lang["template_pic"]%>
	</td><td>
		<asp:TextBox id="tPic" Size="40" maxLength="200" runat=server />
	</td></tr>
	<tr><td colspan=2 align=center>	
	   <asp:Button id="Submit" text="添 加" onclick="Submit_OnClick" runat=server/>
	   </td>
	  </tr>
	 </table>
	
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=500 align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>


</form>

</body>
</html>
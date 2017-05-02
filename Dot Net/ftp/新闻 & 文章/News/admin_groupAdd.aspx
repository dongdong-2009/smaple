<%@Page Language="C#" Inherits="Article.Admin.GroupAdd" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<form id="MyForm" runat=server>

<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_add_group"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label width=100% id=myLabel Visible=false runat=server/> 
	 <table cellpadding=3 width="95%" align="center" >
	  <tr> 
	   <td align="center">
		<%=lang["group_name"]%>
		<asp:TextBox Columns=15 MaxLength=15 id="Groupname" runat=server/>
		<asp:RequiredFieldValidator id="RequiredFieldValidator"
			ControlToValidate="Groupname"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator id="RegularExpressionValidator"
			runat=server
			ControlToValidate="Groupname"
			ValidationExpression="[^' ]+"
			ErrorMessage="*"
			Display="Dynamic" /> 
	</td></tr>
	<tr><td align=center>	
		<%=lang["group_remarks"]%> 
		<asp:TextBox Columns=20
			MaxLength=100
			id="Remarks"
			runat=server/>
		<asp:RegularExpressionValidator id="RegularExpressionValidator1"
			runat=server
			ControlToValidate="Remarks"
			ValidationExpression="[^' ]+"
			ErrorMessage="*"
			Display="Dynamic" />
	</td></tr>
	<tr><td height=30 align=center>
	<%
	Submit.Text=lang["submit_text"].ToString();
	%>
	   <asp:Button id="Submit" text="Ìí ¼Ó" onclick="Submit_OnClick" runat=server/>
	   </td>
	  </tr>
	 </table>
	
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=300 align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>

</form>

</body>
</html>
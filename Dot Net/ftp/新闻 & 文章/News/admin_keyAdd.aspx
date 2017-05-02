<%@ Page Language="C#" Inherits="Article.Admin.KeyAdd" %>

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
	<span class="mframe-t-text">&nbsp; <asp:Literal id="literalTitle" runat=server></asp:Literal><%=lang["title_key"]%></span>
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
	   <td width=60>
		<%=lang["key_name"]%>
	</td><td>
		<asp:TextBox Columns=15 MaxLength=50 id="keyName" runat=server/>
		<asp:RequiredFieldValidator
			ControlToValidate="keyName"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			runat=server
			ControlToValidate="keyName"
			ValidationExpression="[^']+"
			ErrorMessage="*"
			Display="Dynamic" />
	</td></tr>
	<tr><td>
		<%=lang["key_url"]%>
	</td><td>
		<asp:TextBox id="keyUrl" Size="50" maxLength="200" runat=server />
		<asp:RequiredFieldValidator
			ControlToValidate="keyUrl"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			runat=server
			ControlToValidate="keyUrl"
			ValidationExpression="[^']+"
			ErrorMessage="*"
			Display="Dynamic" />
	</td></tr>
	<tr><td>
		<%=lang["key_alt"]%>
	</td><td>
		<asp:TextBox id="keyAlt" Size="50" maxLength="200" runat=server />
		<asp:RegularExpressionValidator
			runat=server
			ControlToValidate="keyAlt"
			ValidationExpression="[^']+"
			ErrorMessage="*"
			Display="Dynamic" />
	</td></tr>
	<tr><td colspan=2 align=center>	
	   <asp:Button id="Submit" text="Ìí ¼Ó" onclick="Submit_OnClick" runat=server/>
	   </td>
	  </tr>
	 <tr><td colspan=2 height=30>
	 	<%=lang["note"]%>
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
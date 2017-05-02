<%@Page Language="C#" Inherits="Article.Admin.Upfiles" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<center>
<form id="myForm" Style="margin:10px" runat=server>
	<asp:Label id="msgLabel" runat=server/>
	<%=lang["delete_useless_1"]%>
	<asp:TextBox id="Days" Size=3 MaxLength=2 CssClass=inputbg runat=server/>
	<asp:RequiredFieldValidator
		ControlToValidate="Days"
		ErrorMessage="*"
		Display="Dynamic"
		runat=server />
	<asp:RegularExpressionValidator
		ControlToValidate="Days"
		ValidationExpression="^\d+$"
		ErrorMessage="*"
		Display="Dynamic"
		runat=server />
	<%=lang["delete_useless_2"]%>
	<%
	Submit.Text=lang["delete_useless_submit"].ToString();
	%>
	<asp:Button id="Submit" onclick="Submit_Onclick" Text="ÇåÀí" runat=server />
</form>
</center>


<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_manage_upload"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label id="myLabel" runat="server" />
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

</body>
</html>
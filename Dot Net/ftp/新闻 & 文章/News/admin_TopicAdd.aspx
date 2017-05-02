<%@Page Language="C#" Inherits="Article.Admin.TopicAdd" %>

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
	<span class="mframe-t-text"><%=lang["title_add_topic"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label width=100% id=myLabel Style="text-align:center" runat=server/> 
	<table cellpadding=3 width="95%" align="center">
	<tr><td align="center">
		<%=lang["topic_name"]%>
		<asp:TextBox Columns=15 MaxLength=15 id="TopicName" runat=server/>
		<asp:RequiredFieldValidator id="RequiredFieldValidator"
			ControlToValidate="TopicName"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator id="RegularExpressionValidator"
			runat=server
			ControlToValidate="TopicName"
			ValidationExpression="[^' ]+"
			ErrorMessage="*"
			Display="Dynamic" />
	</td></tr>
	<tr><td align="center">
	<%
	Submit.Text=lang["submit_text"].ToString();
	%>
	   <asp:Button id="Submit" text="�� ��" onclick="Submit_OnClick" runat=server/>
	</td></tr>
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
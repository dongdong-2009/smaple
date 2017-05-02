<%@Page Language="C#" Inherits="Article.Admin.Change"%>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body >

<form id="form1" runat=server>

<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_modify"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label id="myLabel" width="100%" align="center" style="text-align:center" runat=server/> 
	<table cellpadding=2 align=center width="90%">
	<tr><td width=60>
		<%=lang["username"]%> 
	</td><td>
		<asp:TextBox Columns=15 MaxLength=15 id="Username" runat=server/>
		<asp:RequiredFieldValidator id="RequiredFieldValidator"
			ControlToValidate="Username"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator id="RegularExpressionValidator"
			runat=server
			ControlToValidate="Username"
			ValidationExpression="[^' ]+"
			ErrorMessage="*"
			Display="Dynamic" />
	</td></tr>
	<tr><td>
		<%=lang["email"]%> 
	</td><td>
		<asp:TextBox Columns=15 MaxLength=50 id="Email" runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="Email"
			ValidationExpression="(\w[0-9a-zA-Z_-]*@(\w[0-9a-zA-Z-]*\.)+\w{2,})"
			ErrorMessage=" *"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td >	
		<%=lang["new_password"]%>
	</td><td>
		<asp:TextBox id="Password" Columns=15 textmode=Password MaxLength=15 runat=server/> 
	</td></tr>
	<tr><td>	
		<%=lang["old_password"]%>
	</td><td>
		<asp:TextBox id="oldPassword" Columns=15 textmode=Password MaxLength=15 runat=server/> 
		<asp:RequiredFieldValidator id="RequiredFieldValidator2"
			ControlToValidate="oldPassword"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<input type=hidden id="oldUsername" runat=server>	
	</td></tr>
	<tr><td colspan=2 height=30 align=center>
		<%
		Submit.Text=lang["submit_text"].ToString();
		%>
		<asp:Button id="Submit" text="ÐÞ ¸Ä" onclick="Submit_OnClick" runat=server/>
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
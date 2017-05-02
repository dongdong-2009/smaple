<%@ Page Language="C#" Inherits="Article.Admin.Login"  %>
<%@ Register TagPrefix="WbControls" Namespace="WbControls" Assembly="WbControls" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

&nbsp;
<form id="form1" runat=server>

<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text">&nbsp; <%=lang["title_login"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<table cellpadding=3 width="100%" align="center" >
	<tr><td align="center">
		<asp:Label width=100% id=Label1 runat=server/>
		<%=lang["user_name"]%>
		<asp:TextBox Columns=10 MaxLength=15 id=Username Class="inputbg" runat=server/> 
		   <asp:RequiredFieldValidator id="RequiredFieldValidator"
			ControlToValidate="UserName"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			runat=server
			ControlToValidate="Username"
			ValidationExpression="[^']+"
			ErrorMessage="*"
			Display="Dynamic" />
	</td></tr>
	<tr><td align="center">
		<%=lang["user_password"]%>
		<asp:TextBox id="Password" Columns=10 textmode=Password MaxLength=15 Class="inputbg" runat=server/> 
		<asp:RequiredFieldValidator id="RequiredFieldValidator1"
			ControlToValidate="Password"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			runat=server
			ControlToValidate="Password"
			ValidationExpression="[^' ]+"
			ErrorMessage="*"
			Display="Dynamic" />
	</td></tr>
	<tr><td align="center">
		<%=lang["login_code"]%>
		<asp:TextBox id="VerifyCode" Columns=10 MaxLenth=10 class="inputbg" runat=server/>
		<asp:RequiredFieldValidator
			ControlToValidate="VerifyCode"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
	</td></tr>
	<tr><td align="center">
		<%=lang["code_is"]%><img src="admin_verifyimg.aspx" >
	</td></tr>
	<tr><td align="center">
		<asp:Button id="Submit" text="" onclick="Submit_OnClick" runat=server/>
		<WbControls:ClientDateControl id="clientDate" runat=server/>
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
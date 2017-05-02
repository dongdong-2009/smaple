<%@Page Language="C#" Inherits="Article.Admin.UserAdd" %>

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
	<span class="mframe-t-text"><%=lang["title_add_admin"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label width=100% id=myLabel Visible=false runat=server/> 
	<table cellpadding=3 width="95%" align="center">
	<tr><td align="center">
		<%=lang["user_name"]%>
		<asp:TextBox Columns=15 MaxLength=15 id="Username" runat=server/>
		<asp:RequiredFieldValidator
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
	<tr><td align="center">
		<%=lang["user_email"]%>
		<asp:TextBox Columns=15 MaxLength=100 id="Email" runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="Email"
			ValidationExpression="(\w[0-9a-zA-Z_-]*@(\w[0-9a-zA-Z-]*\.)+\w{2,})"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td align="center">
		<%=lang["user_password"]%>
		<asp:TextBox Columns=15
			MaxLength=15
			id="Password"
			TextMode="Password"
			runat=server/>
		<asp:RequiredFieldValidator
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
		<%=lang["user_password_retype"]%>
		<asp:TextBox Columns=15 MaxLength=15
			id="Password1"
			TextMode="Password"
			runat=server/>
		<asp:RequiredFieldValidator id="RequiredFieldValidator2"
			ControlToValidate="Password1"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator id="RegularExpressionValidator2"
			runat=server
			ControlToValidate="Password1"
			ValidationExpression="[^' ]+"
			ErrorMessage="*"
			Display="Dynamic" /> 
		<asp:CompareValidator
			ControlToValidate="password"
			ControlToCompare="password1"
			Type="String"
			EnableClientScript="false"
			ErrorMessage="Two passwords not match<br>"
			Display="Dynamic"
			runat=server />
	</td></tr>
	<tr><td align="center">
		<%=lang["user_class"]%>
		<asp:DropDownList id="UserClass"
			runat=server >
		</asp:DropDownList>
	</td></tr>
	<tr><td align="center">
		<%=lang["user_remarks"]%>
		<asp:TextBox id="Remarks" Columns="15" MaxLength="100" runat="server"/>
	</td></tr>
	<tr><td align="center">
		<%
		Submit.Text=lang["submit_text"].ToString();
		%>
		<asp:Button id="Submit" text="Ìí ¼Ó" onclick="Submit_OnClick" runat=server/>
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
   &nbsp;&nbsp;<%=lang["note"]%>

</body>
</html>
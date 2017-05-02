<%@ Page Language="C#" Inherits="Article.Mail" EnableSessionState="false" EnableViewState="false" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

	<table width="400" align="center" cellspacing=0 cellpadding=0>
	<tr>
	<td class="mframe-t-left"></td>
	<td class="mframe-t-mid">
		<span class="mframe-t-text"><%=lang["title_recommend"]%></span>
	</td>
	<td class="mframe-t-right"></td>
	</tr>
	</table>
	<table width="400" align="center" cellspacing=0 cellpadding=0>
	<tr>
	<td class="mframe-m-left"></td>
	<td class="mframe-m-mid" align=left style="padding-left:30px">
		<asp:Label width=100% id=myLabel runat=server/>
		<form id="myForm" runat=server>
		<%=lang["sender_name"]%>
		<asp:TextBox Columns=30 MaxLength=30 id="UserName" runat=server/> 
		   <asp:RequiredFieldValidator
			ControlToValidate="UserName"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<br><br>
	
		<%=lang["sender_email"]%>
		<asp:TextBox Columns=30 MaxLength=30 id="MailFrom" runat=server/> 
		   <asp:RequiredFieldValidator id="RequiredFieldValidator"
			ControlToValidate="MailFrom"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="MailFrom"
			ValidationExpression="(\w[0-9a-zA-Z_-]*@(\w[0-9a-zA-Z-]*\.)+\w{2,})"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	
		<br><br>
		<%=lang["mail_receiver"]%>
		<asp:TextBox id="MailTo" MaxLength=30 Columns=30 runat=server/> 
		<asp:RequiredFieldValidator id="RequiredFieldValidator1"
			ControlToValidate="MailTo"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="MailTo"
			ValidationExpression="(\w[0-9a-zA-Z_-]*@(\w[0-9a-zA-Z-]*\.)+\w{2,})"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
		
		
		<br><br>
		<%=lang["mail_cc"]%>
		<asp:TextBox id="MailCc" MaxLength=50 Columns=40 runat=server/> 
		<br><%=lang["mail_cc_note"]%>
		<br><br>
		
		<input type="hidden" id="Url" runat=server />
		
		<asp:Button id="Submit" text="·¢ ÐÅ" onclick="Submit_OnClick" runat=server/>
		</form>		
		
	</td>
	<td class="mframe-m-right"></td>
	</tr>
	</table>
	<table width="400" align="center" cellspacing=0 cellpadding=0 >
	<tr>
	<td class="mframe-b-left"></td>
	<td class="mframe-b-mid">&nbsp;</td>
	<td class="mframe-b-right"></td>
	</tr>
	</table>


</body>
</html>
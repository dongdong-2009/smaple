<%@Page Language="C#" Inherits="Article.Admin.SendMail" %>
<%@Register TagPrefix="WbControls" Namespace="WbControls" Assembly="WbControls" %>
<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>


<form id="myForm" Style="margin:0px" runat=server>

<table width="750" align="center" cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_send_mail"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width="750" align="center" cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid" align=center>
	<asp:Label width=100% id=myLabel style="text-align:center" runat=server/>
	<asp:PlaceHolder id="phForm" runat=server>
	<table width="95%">
	<tr><td width=60>
		<%=lang["mail_sender"]%>
	</td><td>
		<asp:TextBox id="tbMailFrom" MaxLength=30 Columns=20 runat=server/> 
		<asp:RequiredFieldValidator
			ControlToValidate="tbMailFrom"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="tbMailFrom"
			ValidationExpression="(\w[0-9a-zA-Z_-]*@(\w[0-9a-zA-Z-]*\.)+\w{2,})"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td width=60>
		<%=lang["mail_receiver"]%>
	</td><td>
		<asp:TextBox id="tbMailTo" MaxLength=30 Columns=20 runat=server/> 
		<asp:RequiredFieldValidator
			ControlToValidate="tbMailTo"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="tbMailTo"
			ValidationExpression="(\w[0-9a-zA-Z_-]*@(\w[0-9a-zA-Z-]*\.)+\w{2,})"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td>
		<%=lang["mail_cc"]%>
	</td><td>
		<asp:TextBox id="tbMailCc" MaxLength=50 Columns=40 runat=server/> 
	</td></tr>
	<tr><td>
		<%=lang["mail_subject"]%>
	</td><td>
		<asp:TextBox id="tbMailSubject" MaxLength=50 Columns=80 runat=server/> 
		<asp:RequiredFieldValidator
			ControlToValidate="tbMailSubject"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
	</td></tr>
	<tr><td valign=top>
		<%=lang["mail_body"]%>
	</td><td>
		<WbControls:WBTB id="MailBody" NewsButton="false" MediaButton="false" runat=server/>
		<asp:RequiredFieldValidator
			ControlToValidate="MailBody"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
	</td></tr>
	<tr><td colspan=2>
		<%
		Submit.Text=lang["send_text"].ToString();
		%>
		<asp:Button id="Submit" text="·¢ ËÍ" onclick="Submit_OnClick" runat=server/>
	</td></tr>
	</table>
	</asp:PlaceHolder>
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width="750" align="center" cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>

</form>

</body>
</html>
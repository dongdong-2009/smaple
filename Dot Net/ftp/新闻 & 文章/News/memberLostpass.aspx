<%@ Page Language="C#" Inherits="Article.MemberLostPass" EnableSessionState="true"  %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<!--#include file="head.inc" -->

<table class="twidth" align=center cellpadding=0 cellspacing=0 >
<tr>
<td class="navbar-left">
</td>
<td class="navbar">
	<!--#include file="inc/navclass.aspx"-->
</td>
<td class="navbar-right">
</td>
</tr>
</table>

&nbsp;

<form id="myForm" runat="server">
<table align=center width=300 cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_find_password"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table align=center width=300 cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid" style="padding:10px; line-height:130%">
	<asp:Label id="myLabel" Width="100%" style="text-align:center" runat=server/>
	
	<asp:PlaceHolder id="phStep1" runat=server>
	<table width=95% align=center>
	<tr><td width=60>
		<b><%=lang["member_name"]%></b>
	</td><td>
		<asp:TextBox id="tbName" MaxLength=50 Size=15 runat="server"/>
		 <asp:RequiredFieldValidator
			ControlToValidate="tbName"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td colspan=2 height=30 align=center>
		<asp:Button id="btStep1" Text="下一步" Onclick="btStep1_Onclick" runat=server/>
	</td></tr>
	</table>
	</asp:PlaceHolder>

	<asp:PlaceHolder id="phStep2" Visible=false runat=server>
	<table width=95% align=center>
	<tr><td width=60>
		<b><%=lang["question"]%></b>
	</td><td>
		<asp:Literal id="ltQuestion" runat=server/>
	</td></tr>
	<tr><td>
		<b><%=lang["answer"]%></b>
	</td><td>
		<asp:TextBox TextMode="Password" id="tbAnswer" MaxLength=100 Size=15 runat="server"/>
		 <asp:RequiredFieldValidator
			ControlToValidate="tbAnswer"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td colspan=2 height=30 align=center>
		<asp:Button id="btStep2" Text="下一步" Onclick="btStep2_Onclick" runat=server/>
	</td></tr>
	</table>
	</asp:PlaceHolder>
	
	<asp:PlaceHolder id="phStep3" Visible=false runat=server>
	<table width=95% align=center>
	<tr><td width=60>
		<b><%=lang["new_password"]%></b>
	</td><td>
		<asp:TextBox TextMode="Password" id="tbNewPass" Size=15 MaxLength=50 runat=server/>
		 <asp:RequiredFieldValidator
			ControlToValidate="tbNewPass"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td colspan=2 height=30 align=center>
		<asp:Button id="btStep3" Text="确定" Onclick="btStep3_Onclick" runat=server/>
	</td></tr>
	</table>
	</asp:PlaceHolder>
	
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table align=center width=300 cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>
 </form>

<!--#include file="foot.inc"-->
</body>
</html>
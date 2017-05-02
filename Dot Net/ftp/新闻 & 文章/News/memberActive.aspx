<%@ Page Language="C#" Inherits="Article.MemberActive" EnableSessionState="true"  %>

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
	<span class="mframe-t-text"><%=lang["title_member_activate"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table align=center width=300 cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid" style="padding:10px; line-height:130%">
	<asp:Label id="myLabel" Width="100%" style="text-align:center" runat=server/>
	
	<asp:PlaceHolder id="phForm" runat=server>
	<table width=95% align=center>
	<tr><td width=60>
		<b><%=lang["activate_name"]%></b>
	</td><td>
		<asp:TextBox id="tbName" MaxLength=50 Size=15 runat="server"/>
		 <asp:RequiredFieldValidator
			ControlToValidate="tbName"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td>
		<b><%=lang["activate_code"]%></b>
	</td><td>
		<asp:TextBox TextMode="Password" id="tbActiveCode" MaxLength=20 Size=15 runat="server"/>
		 <asp:RequiredFieldValidator
			ControlToValidate="tbActiveCode"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td colspan=2 height=30 align=center>
		<asp:Button id="btPost" Text="¼¤»î" Onclick="btPost_Onclick" runat=server/>
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
<%@ Page Language="C#" Inherits="Article.Login" EnableSessionState="true"  %>

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
 
<asp:PlaceHolder ID="LoginPass" Visible="false" runat="server" >
<table align=center width=300 cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_login_sccess"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table align=center width=300 cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid" style="padding:10px; line-height:130%">
	<li><%=lang["msg_success"]%>
	<li><%=lang["msg_auto_back"]%>
	<li>&lt;&lt; <asp:HyperLink id="Referer" runat=server>·µ»Ø</asp:HyperLink>
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
</asp:PlaceHolder>
 
<asp:PlaceHolder ID="LoginError" Visible="false" runat="server" >
<table align=center width=300 cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_login_fail"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table align=center width=300 cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid" style="padding:10px; line-height:130%">
	<li><%=lang["msg_fail"]%>
	<li><%=lang["msg_auto_back"]%>
	<li><a href="admin_login.aspx"><%=lang["msg_admin_login"]%></a>
	<li>&lt;&lt; <a href="javascript:history.back()"><%=lang["back_text"]%></a>
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
</asp:PlaceHolder>

<!--#include file="foot.inc"-->
</body>
</html>
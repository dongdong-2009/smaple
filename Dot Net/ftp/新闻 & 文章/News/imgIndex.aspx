<%@Page Language="C#" Inherits="Article.ImgIndex" EnableSessionState="false" EnableViewState="false" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<meta name="keywords" content="动网新闻.net,asp.net,新闻系统">
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

<table class="twidth" cellpadding=0 cellspacing=0 align=center>
<tr align="left" valign=top >
<td>
	<% GetList();%>
</td>
</tr>
</table>

<!--#include file="foot.inc" -->

</body>
<html>
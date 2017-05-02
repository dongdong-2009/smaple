<%@Page Language="C#" Inherits="Article.ImgList" EnableSessionState="false" EnableViewState="false" %>

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

&nbsp;

<table class="twidth" cellpadding=0 cellspacing=0 align=center>
<tr align="left" valign=top >
<td width=200>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-t-left"></td>
	<td class="lframe-t-mid">
		<span class="lframe-t-text"><%=lang["title_img_news"]%></span>
	</td>
	<td class="lframe-t-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-m-left"></td>
	<td class="lframe-m-mid">
		<% ImgClassList();%>
	</td>
	<td class="lframe-m-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0 >
	<tr>
	<td class="lframe-b-left"></td>
	<td class="lframe-b-mid">&nbsp;</td>
	<td class="lframe-b-right"></td>
	</tr>
	</table>
	
</td>
<td>

	<table width=100% cellspacing=0 cellpadding=0>
	<tr>
	<td class="mframe-t-left"></td>
	<td class="mframe-t-mid">
		<span class="mframe-t-text">　&gt;&gt; <asp:Label id="NameLabel"  runat=server/></span>
	</td>
	<td class="mframe-t-right"></td>
	</tr>
	</table>
	<table width=100% cellspacing=0 cellpadding=0>
	<tr>
	<td class="mframe-m-left"></td>
	<td class="mframe-m-mid">
		<% GetList();%>
		<% SearchBar();%>
	</td>
	<td class="mframe-m-right"></td>
	</tr>
	</table>
	<table width=100% cellspacing=0 cellpadding=0 >
	<tr>
	<td class="mframe-b-left"></td>
	<td class="mframe-b-mid">&nbsp;</td>
	<td class="mframe-b-right"></td>
	</tr>
	</table>


</td>
</tr>
</table>

<!--#include file="foot.inc" -->

</body>
<html>
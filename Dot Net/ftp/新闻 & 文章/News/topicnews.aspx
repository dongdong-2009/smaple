<%@Page Language="C#" Inherits="Article.List" EnableSessionState="false" EnableViewState="false" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<meta name="keywords" content="��������.net,asp.net,����ϵͳ">
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

<table class="twidth" align=center cellpadding=0 cellspacing=0>
<tr>
<td class="navsub-left"></td>
<td class="navsub">
	&nbsp; <%=StepPath()%>
</td>
<td class="navsub-right"></td>
</tr>
</table>
&nbsp;

<table class="twidth" cellpadding=0 cellspacing=0 border=0 align=center>
<tr align="left" valign=top >
<td width=200>
	
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-t-left"></td>
	<td class="lframe-t-mid">
		<span class="lframe-t-text"><%=lang["title_news_hot_day"]%></span>
	</td>
	<td class="lframe-t-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-m-left"></td>
	<td class="lframe-m-mid">
		<% TopList(classID,0,"dayhot",10,26,false,false,false,false,false);%>
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
		<span class="mframe-t-text">&nbsp; &gt;&gt; <asp:Literal id="nameLiteral"  runat=server/></span>
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
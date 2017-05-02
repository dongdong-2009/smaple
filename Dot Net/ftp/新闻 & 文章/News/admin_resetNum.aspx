<%@ page Language="C#" Inherits="Article.Admin.ResetNum" %>

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
	<span class="mframe-t-text"><%=lang["title_reset_num"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label width="100%" id="myLabel" style="text-align:center" runat=server/> 
	<table cellpadding=3 align="center">
	<tr><td align="center">
		<%=lang["explanation_reset_news_num"]%>
	</td></tr>
	<tr><td align="center">
		<%
		Submit.Text=lang["submit_reset_news"].ToString();
		%>
		<asp:Button id="Submit" text="统计新闻数" onclick="Submit_OnClick" runat=server/>
	</td></tr>
	<tr><td align="center">
		<%=lang["explanation_reset_member_num"]%>
	</td></tr>
	<tr><td align="center">
		<%
		Submit1.Text=lang["submit_reset_member"].ToString();
		%>
		<asp:Button id="Submit1" text="统计会员数" onclick="Submit1_OnClick" runat=server/>
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
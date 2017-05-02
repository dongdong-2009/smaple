<%@Page Language="C#" Inherits="Article.Admin.MemberNcView" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<asp:Label id=myLabel width=100% style="text-align:center" runat=server/>


<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_uncheck_member"]%>&nbsp; <a href="javascript:history.back()">&lt;- Back</a></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<table width=95% cellpadding=3 align=center>
	<tr><td width=250>
		<b><%=lang["member_name"]%></b>
	</td><td>
		<asp:Literal id="name" runat="server"/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_email"]%></b>
	</td><td>
		<asp:Literal id="email" runat="server"/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_qq"]%></b>
	</td><td>
		<asp:Literal id="qq" runat="server"/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_icq"]%></b>
	</td><td>
		<asp:Literal id="icq" runat="server"/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_msn"]%></b>
	</td><td>
		<asp:Literal id="msn" runat="server"/>
	</td></tr>
	<tr><td colspan=2 class="summary-title">
		<%=lang["member_detail"]%>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_sex"]%></b>
	</td><td>
		<asp:Literal id="male" runat="server"/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_birthday"]%></b>
	</td><td>
		<asp:Literal id="birthday" runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_blood_type"]%></b>
	</td><td>
		<asp:Literal id="bloodtype" runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_real_name"]%></b>
	</td><td>
		<asp:Literal id="realname" runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_country"]%></b>
	</td><td>
		<asp:Literal id="country" runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_province"]%></b>
	</td><td>
		<asp:Literal id="province" runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_city"]%></b>
	</td><td>
		<asp:Literal id="city" runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_phone"]%></b>
	</td><td>
		<asp:Literal id="phone" runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_address"]%></b>
	</td><td>
		<asp:Literal id="address" runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_postcode"]%></b>
	</td><td>
		<asp:Literal id="postcode" runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_job"]%></b>
	</td><td>
		<asp:Literal id="job" runat="server"/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_credential"]%></b>
	</td><td>
		<asp:Literal id="edu" runat="server"/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_school"]%></b>
	</td><td>
		<asp:Literal id="school" runat="server"/>
	</td></tr>
	</table>
	
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>



</body>
</html>
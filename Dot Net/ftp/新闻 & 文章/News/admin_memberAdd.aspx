<%@Page Language="C#" Inherits="Article.Admin.MemberAdd" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<form id="myForm" runat=server>

<table width=750 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><asp:Literal id="literalTitle" Text="Ìí¼Ó" runat=server/><%=lang["title_member"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=750 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label width=100% id=myLabel style="text-align:center" runat=server/> 
	<asp:PlaceHolder id="phForm" runat=server>
	<table width=95% align=center>
	<tr><td width=250>
		<b><%=lang["member_name"]%></b>
	</td><td>
		<asp:TextBox id="name" MaxLength=50 Size=20 runat="server"/>
		<asp:RequiredFieldValidator
			ControlToValidate="name"
			ErrorMessage=" *"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_password"]%></b>
	</td><td>
		<asp:TextBox TextMode="Password" id="password" MaxLength=50 Size=20 runat="server"/>
		<asp:RequiredFieldValidator id="rfvPassword"
			ControlToValidate="password"
			ErrorMessage=" *"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_email"]%></b>
	</td><td>
		<asp:TextBox id="email" MaxLength=80 Size=20 runat="server"/>
		<asp:RequiredFieldValidator
			ControlToValidate="email"
			ErrorMessage=" *"
			Display="Dynamic"
			runat=server
			/>
		<asp:RegularExpressionValidator
			ControlToValidate="email"
			ValidationExpression="(\w[0-9a-zA-Z_-]*@(\w[0-9a-zA-Z-]*\.)+\w{2,})"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_question"]%></b>
	</td><td>
		<asp:TextBox id="question" MaxLength=100 Size=50 runat="server"/>
		<asp:RequiredFieldValidator
			ControlToValidate="question"
			ErrorMessage=" *"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_answer"]%></b>
	</td><td>
		<asp:TextBox id="answer" MaxLength=100 Size=50 runat="server"/>
		<asp:RequiredFieldValidator id="rfvAnswer"
			ControlToValidate="answer"
			ErrorMessage=" *"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_qq"]%></b>
	</td><td>
		<asp:TextBox id="qq" MaxLength=20 Size=20 runat="server"/>
		<asp:RegularExpressionValidator
			ControlToValidate="qq"
			ValidationExpression="\d+"
			Display="Dynamic"
			ErrorMessage=" *"
			runat=server
			/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_icq"]%></b>
	</td><td>
		<asp:TextBox id="icq" MaxLength=20 Size=20 runat="server"/>
		<asp:RegularExpressionValidator
			ControlToValidate="icq"
			ValidationExpression="\d+"
			ErrorMessage=" *"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_msn"]%></b>
	</td><td>
		<asp:TextBox id="msn" MaxLength=100 Size=20 runat="server"/>
		<asp:RegularExpressionValidator
			ControlToValidate="msn"
			ValidationExpression="(\w[0-9a-zA-Z_-]*@(\w[0-9a-zA-Z-]*\.)+\w{2,})"
			ErrorMessage=" *"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td colspan=2 class="summary-title">
		<%=lang["member_detail"]%>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_sex"]%></b>
	</td><td>
		<%
		male.Items[0].Text=lang["sex_male"].ToString();
		male.Items[1].Text=lang["sex_female"].ToString();
		%>
		<asp:RadioButtonList id="male"
			RepeatDirection="Horizontal"
			runat="server">
			<asp:ListItem Value=1 Text="ÄÐ" Selected="True"/>
			<asp:ListItem Value=0 Text="Å®"/>
		</asp:RadioButtonList>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_birthday"]%></b>
	</td><td>
		<asp:TextBox id="birthYear" Size=4 MaxLength=4 runat=server/>
		<%=lang["year_text"]%>
		<asp:RegularExpressionValidator
			ControlToValidate="birthYear"
			ValidationExpression="\d+"
			ErrorMessage=" *"
			runat=server
			/>
		<asp:DropDownList id="birthMonth" runat=server>
			<asp:ListItem Value="" Text="" />
			<asp:ListItem Value="1" Text="1" />
			<asp:ListItem Value="2" Text="2" />
			<asp:ListItem Value="3" Text="3" />
			<asp:ListItem Value="4" Text="4" />
			<asp:ListItem Value="5" Text="5" />
			<asp:ListItem Value="6" Text="6" />
			<asp:ListItem Value="7" Text="7" />
			<asp:ListItem Value="8" Text="8" />
			<asp:ListItem Value="9" Text="9" />
			<asp:ListItem Value="10" Text="10" />
			<asp:ListItem Value="11" Text="11" />
			<asp:ListItem Value="12" Text="12" />
		</asp:DropDownList>
		<%=lang["month_text"]%>
		<asp:DropDownList id="birthDay" runat=server>
			<asp:ListItem Value="" Text="" />
			<asp:ListItem Value="1" Text="1" />
			<asp:ListItem Value="2" Text="2" />
			<asp:ListItem Value="3" Text="3" />
			<asp:ListItem Value="4" Text="4" />
			<asp:ListItem Value="5" Text="5" />
			<asp:ListItem Value="6" Text="6" />
			<asp:ListItem Value="7" Text="7" />
			<asp:ListItem Value="8" Text="8" />
			<asp:ListItem Value="9" Text="9" />
			<asp:ListItem Value="10" Text="10" />
			<asp:ListItem Value="11" Text="11" />
			<asp:ListItem Value="12" Text="12" />
			<asp:ListItem Value="13" Text="13" />
			<asp:ListItem Value="14" Text="14" />
			<asp:ListItem Value="15" Text="15" />
			<asp:ListItem Value="16" Text="16" />
			<asp:ListItem Value="17" Text="17" />
			<asp:ListItem Value="18" Text="18" />
			<asp:ListItem Value="19" Text="19" />
			<asp:ListItem Value="20" Text="20" />
			<asp:ListItem Value="21" Text="21" />
			<asp:ListItem Value="22" Text="22" />
			<asp:ListItem Value="23" Text="23" />
			<asp:ListItem Value="24" Text="24" />
			<asp:ListItem Value="25" Text="25" />
			<asp:ListItem Value="26" Text="26" />
			<asp:ListItem Value="27" Text="27" />
			<asp:ListItem Value="28" Text="28" />
			<asp:ListItem Value="29" Text="29" />
			<asp:ListItem Value="30" Text="30" />
			<asp:ListItem Value="31" Text="31" />
		</asp:DropDownList>
		<%=lang["day_text"]%>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_blood_type"]%></b>
	</td><td>
		<asp:DropDownList id="bloodtype" runat=server>
			<asp:ListItem Value="" Text="" />
			<asp:ListItem Value="A" Text="A"/>
			<asp:ListItem Value="B" Text="B"/>
			<asp:ListItem Value="O" Text="O"/>
			<asp:ListItem Value="AB" Text="AB"/>
		</asp:DropDownList>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_real_name"]%></b>
	</td><td>
		<asp:TextBox id="realname" Size=20 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_country"]%></b>
	</td><td>
		<asp:TextBox id="country" Size=20 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_province"]%></b>
	</td><td>
		<asp:TextBox id="province" Size=20 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_province"]%></b>
	</td><td>
		<asp:TextBox id="city" Size=20 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_phone"]%></b>
	</td><td>
		<asp:TextBox id="phone" Size=20 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_address"]%></b>
	</td><td>
		<asp:TextBox id="address" Size=50 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_postcode"]%></b>
	</td><td>
		<asp:TextBox id="postcode" Size=10 MaxLength=10 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_job"]%></b>
	</td><td>
		<asp:DropDownList id="job" runat="server">
		</asp:DropDownList>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_credential"]%></b>
	</td><td>
		<asp:DropDownList id="edu" runat="server">
		</asp:DropDownList>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_school"]%></b>
	</td><td>
		<asp:TextBox id="school" Size=40 MaxLength=100 runat="server"/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_remarks"]%></b>
	</td><td>
		<asp:TextBox id="remarks" Size=40 MaxLength=100 runat="server"/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_group"]%></b>
	</td><td>
		<asp:CheckBoxList id="groupid"
			RepeatDirection="Horizontal"
			RepeatColumns=5
			runat="server"/>
	</td></tr>
	<tr><td colspan=2 height=30 align=center>
		<asp:Button id="btPost" Text="Ìí¼Ó" Onclick="btPost_Onclick" runat=server/>
	</td></tr>
	</table>
	</asp:PlaceHolder>
	
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=750 align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>


</form>

</body>
</html>
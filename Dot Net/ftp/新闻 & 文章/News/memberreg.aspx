<%@ Page Language="C#" Inherits="Article.MemberReg" EnableSessionState="true"  %>

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
<table class="twidth" align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_member_reg"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table class="twidth" align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid" style="padding:10px; line-height:130%">
	<asp:PlaceHolder id="phStatement" runat=server>
	<table width=95% align=center>
	<tr class="summary-title">
		<td align=center><%=lang["statement"]%></td>
	</tr>
	<tr>
	<td >
		<!--#include file="inc/member_reg_statement.inc"-->
	</td>
	</tr>
	<tr>
	<td align=center>
		<asp:Button id="btAgree" Onclick="btAgree_Onclick" runat=server/>
		&nbsp; 
		<asp:Button id="btDisagree" runat=server/>
	</td>
	</tr>
	</table>
	</asp:PlaceHolder>
	
	<asp:Label id="myLabel" Width="100%" style="text-align:center" runat=server/>
	
	<asp:PlaceHolder id="phReg" runat=server>
	<table width=95% align=center>
	<tr><td width=250>
		<b><%=lang["member_name"]%></b>
	</td><td>
		<asp:TextBox id="name" MaxLength=50 Size=20 runat="server"/>
		 <asp:RequiredFieldValidator
			ControlToValidate="name"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_password"]%></b>
	</td><td>
		<asp:TextBox TextMode="Password" id="password" MaxLength=50 Size=20 runat="server"/>
		 <asp:RequiredFieldValidator
			ControlToValidate="password"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_password_retype"]%></b>
	</td><td>
		<asp:TextBox TextMode="Password" id="password2" MaxLength=50 Size=20 runat="server"/>
		 <asp:RequiredFieldValidator
			ControlToValidate="password2"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
		<asp:CompareValidator
			ControlToValidate="password2"
			ControlToCompare="password"
			ErrorMessage="Two passwords not match"
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
			ErrorMessage="*"
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
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["member_answer"]%></b>
	</td><td>
		<asp:TextBox id="answer" MaxLength=100 Size=50 runat="server"/>
		 <asp:RequiredFieldValidator
			ControlToValidate="answer"
			ErrorMessage="*"
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
			ErrorMessage="*"
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
			ErrorMessage="*"
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
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td colspan=2 class="summary-title" style="cursor:hand;" onclick="f_detail();">
		<%=lang["member_detail"]%>
		<script language=javascript>
		function f_detail()
		{
			var obj = document.all.t_detail;
			if (obj.style.display == "")
			{
				obj.style.display = "none";
			}else{
				obj.style.display = "";
			}
		}
		</script>
	</td></tr>
	<tbody id="t_detail" name="t_detail" style="display:none">
	<tr><td width=200>
		<b><%=lang["member_sex"]%></b>
	</td><td>
		<%
		male.Items[0].Text=lang["male"].ToString();
		male.Items[1].Text=lang["female"].ToString();
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
		<%=lang["year"]%><asp:RegularExpressionValidator
			ControlToValidate="birthYear"
			ValidationExpression="\d+"
			ErrorMessage="*"
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
		<%=lang["month"]%>
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
		<%=lang["day"]%>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["blood_type"]%></b>
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
		<b><%=lang["real_name"]%></b>
	</td><td>
		<asp:TextBox id="realname" Size=20 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["country"]%></b>
	</td><td>
		<asp:TextBox id="country" Size=20 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["province"]%></b>
	</td><td>
		<asp:TextBox id="province" Size=20 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["city"]%></b>
	</td><td>
		<asp:TextBox id="city" Size=20 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["phone"]%></b>
	</td><td>
		<asp:TextBox id="phone" Size=20 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["address"]%></b>
	</td><td>
		<asp:TextBox id="address" Size=50 MaxLength=100 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["postcode"]%></b>
	</td><td>
		<asp:TextBox id="postcode" Size=10 MaxLength=10 runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["job"]%></b>
	</td><td>
		<asp:DropDownList id="job" runat="server">
		</asp:DropDownList>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["credential"]%></b>
	</td><td>
		<asp:DropDownList id="edu" runat="server">
		</asp:DropDownList>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["school"]%></b>
	</td><td>
		<asp:TextBox id="school" Size=20 MaxLength=100 runat="server"/>
	</td></tr>
	</tbody>
	<tr><td colspan=2 height=30 align=center>
		<asp:Button id="btReg" Onclick="btReg_Onclick" runat=server/>
	</td></tr>
	</table>
	</asp:PlaceHolder>
	
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table class="twidth" align=center cellspacing=0 cellpadding=0 >
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
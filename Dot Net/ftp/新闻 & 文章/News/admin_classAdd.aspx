<%@ Page Language="C#" Inherits="Article.Admin.ClassAdd" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<form id="myForm" runat=server>

<table width=500 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text">&nbsp; <asp:Literal id="literalTitle" runat=server></asp:Literal><%=lang["title_class"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=500 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label width=100% style="text-align:center" id=myLabel runat=server/> 
	<table cellpadding=3 cellspacing=0 width="95%" align="center" >
	  <tr> 
	   <td width=60>
		<%=lang["class_name"]%>
	</td><td>
		<asp:TextBox Columns=15 MaxLength=15 id="className" runat=server/>
		<asp:RequiredFieldValidator id="RequiredFieldValidator"
			ControlToValidate="className"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator id="RegularExpressionValidator"
			runat=server
			ControlToValidate="ClassName"
			ValidationExpression="[^']+"
			ErrorMessage="*"
			Display="Dynamic" />
	</td></tr>
	<tr><td>
		<%=lang["class_father"]%>
	</td><td>
		<asp:DropDownList id="parentID" runat=server />
	</td></tr>
	<tr><td>
		<%=lang["class_url"]%>
	</td><td>
		<asp:TextBox id="cUrl" Size="30" maxLength="200" runat=server />
	</td></tr>
	<tr><td>
		<%=lang["class_child_bind_num"]%>
	</td><td>
		<asp:TextBox id="cBindNum"
			maxlength=2
			Size=3
			Text="8"
			Style="text-align:right"
			runat=server/>
		<asp:RequiredFieldValidator
			ControlToValidate="cBindNum"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="cBindNum"
			ValidationExpression="\d{1,2}"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
	</td></tr>
	<tr><td>
		<%=lang["class_list_style"]%>
	</td><td>
		<asp:DropDownList id="listStyle" runat=server />
	</td></tr>
	<tr><td>
		<%=lang["class_style"]%>
	</td><td>
		<asp:DropDownList id="styleID" runat=server />
	</td></tr>
	<tr><td>
		<%=lang["class_template"]%>
	</td><td>
		<asp:DropDownList id="cTempID" runat=server />
	</td></tr>
	<tr><td>
		<%=lang["news_template"]%>
	</td><td>
		<asp:DropDownList id="newsTempID" runat=server />
	</td></tr>
	<tr><td>
		
	</td><td>
		<%
		canAdd.Text=lang["allow_add_news"].ToString();
		%>
		<asp:CheckBox id="canAdd" Text="可以添加新闻" Checked="true" runat=server />
	</td></tr>
	<tr><td>
		
	</td><td>
		<%
		cInBar.Text=lang["show_in_bar"].ToString();
		%>
		<asp:CheckBox id="cInBar" Text="显示在分类栏" Checked="true" runat=server />
	</td></tr>
	<tr><td>
		
	</td><td>
		<%
		cInNav.Text=lang["show_in_nav"].ToString();
		%>
		<asp:CheckBox id="cInNav" Text="显示在导航栏" Checked="true" runat=server />
	</td></tr>
	<tr><td>
		
	</td><td>
		<%
		cBind.Text=lang["class_bind"].ToString();
		%>
		<asp:CheckBox id="cBind" Text="分类显示新闻时显示该类新闻" Checked="true" runat=server />
	</td></tr>
	<tr><td valign=top>
		<%=lang["class_logo"]%>
	</td><td>
		<asp:TextBox id="logo"
			TextMode="MultiLine"
			Rows=3
			Columns=50
			runat=server />
	</td></tr>
	<tr><td valign=top>
		<%=lang["news_ad"]%>
	</td><td>
		<asp:TextBox id="newsAd"
			TextMode="MultiLine"
			Rows=3
			Columns=50
			runat=server />
	</td></tr>
	<tr><td valign=top>
		<%=lang["class_ad"]%>
	</td><td>
		<asp:TextBox id="headAd"
			TextMode="MultiLine"
			Rows=3
			Columns=50
			runat=server />
	</td></tr>
	<tr><td colspan=2 align=center>	
	   <asp:Button id="Submit" text="添 加" onclick="Submit_OnClick" runat=server/>
	   </td>
	  </tr>
	 </table>
	
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=500 align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>


</form>

</body>
</html>
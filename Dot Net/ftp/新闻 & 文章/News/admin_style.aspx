<%@Page Language="C#" Inherits="Article.Admin.Style" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body >

<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_manage_style"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label id="myLabel" width="100%" style="text-align:center" runat=server/>
	<table align=center width=95% cellpadding=3 >
	<form runat=server>
	<tr>
	<td colspan=2 class=tdbg-dark>
	<asp:RadioButtonList id="allStyle"
		AutoPostBack=true
		OnSelectedIndexChanged="allStyle_CheckedChanged"
		RepeatDirection="Horizontal"
		RepeatColumns=7
		runat=server/>
		<asp:RequiredFieldValidator
			ControlToValidate="allStyle"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
	</td></tr>
	<tr><td width=200>
		<b><%=lang["style_name"]%></b>
	</td><td>
		<asp:TextBox id="name" 
			Columns=20
			MaxLength=50
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="name"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td valign=top><b><%=lang["css_location"]%></b>
	</td>
	<td>
		<asp:TextBox id="css"
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="css"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td valign=top><b><%=lang["css_file"]%></b><br>
	<iframe src="inc/admin_style.htm?<%=style.Css%>" width="200" height="140" frameborder=0></iframe>
	</td>
	<td>
		<asp:TextBox id="cssBody"
			Rows=10
			TextMode="multiLine"
			Columns=70
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="cssBody"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr>
	<td><b><%=lang["new_icon_1_hour"]%></b></td>
	<td>
		<asp:TextBox id="picNew1" 
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picNew1"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr>
	<td><b><%=lang["new_icon_12_hours"]%></b></td>
	<td>
		<asp:TextBox id="picNew2" 
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picNew2"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr>
	<td><b><%=lang["new_icon_24_hours"]%></b></td>
	<td>
		<asp:TextBox id="picNew3" 
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picNew3"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td><b><%=lang["pic_bullet"]%></b></td>
	<td>
		<asp:TextBox id="picBullet" 
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picBullet"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td><b><%=lang["pic_nav_bullet"]%></b></td>
	<td>
		<asp:TextBox id="picNavBullet" 
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picNavBullet"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td valign=top><b><%=lang["pic_folder_close"]%></b>
	</td>
	<td>
		<asp:TextBox id="picVclassClose"
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picVclassClose"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td valign=top><b><%=lang["pic_folder_open"]%></b>
	</td>
	<td>
		<asp:TextBox id="picVclassOpen"
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picVclassOpen"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td><b><%=lang["pic_lock"]%></b></td>
	<td>
		<asp:TextBox id="picLock"
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picLock"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td><b><%=lang["pic_img_news"]%></b></td>
	<td>
		<asp:TextBox id="picImg"
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picImg"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td><b><%=lang["pic_headline"]%></b></td>
	<td>
		<asp:TextBox id="picHeadline"
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picHeadline"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td><b><%=lang["pic_more"]%></b></td>
	<td>
		<asp:TextBox id="picMore"
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picMore"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td><b><%=lang["pic_class_separator"]%></b></td>
	<td>
		<asp:TextBox id="picNavSeparator"
			Columns=50
			MaxLength=255
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="picNavSeparator"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server
			/>
	</td></tr>
	<tr><td></td>
	<td>
		<%
		addNew.Text=lang["save_new_style"].ToString();
		%>
		<asp:CheckBox id="addNew"
			Text="添加为新风格"
			runat="server"
			/>
	</td></tr>
	<tr><td colspan=2 align=center>
		<%
		Submit.Text=lang["modify_text"].ToString();
		Delete.Text=lang["delete_text"].ToString();
		%>
		<asp:Button id="Submit" Text="修改" onclick="Submit_Onclick" runat="server"/>&nbsp; 
		<asp:Button id="Delete" Text="删除" onclick="Delete_Onclick" runat="server"/>
	</td></tr>
	<tr><td colspan=2 >
		<%=lang["note"]%>
	</td></tr>
	</form>
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
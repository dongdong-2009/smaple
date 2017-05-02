<%@ Page Language="C#" Inherits="Article.Admin.Upload" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>
<form id="form1" enctype="multipart/form-data" method="post" runat=server>

<table width=350 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_file_upload"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=350 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<table cellpadding=3 width="95%" align="center">
	<tr><td align="center">
		<asp:Label width=100% id=myLabel text="" runat=server/><br><br>
		<%=lang["select_upload_file"]%>
		<input type=file  id=myFile size=15 runat=server/> 
	</td></tr>
	<tr><td align="center" valign=top >
		<table align=center>
		<tr><td>
		<asp:CheckBox id="dispImage" runat=server/>
		</td><td>
		<asp:CheckBox id="dispTitle" runat=server/>
		</td></tr>
		<tr><td colspan=2>
		<asp:CheckBox id="getThumbnail" runat=server/>
		<asp:DropDownList id="thumbnailSize"
			runat=server >
			<asp:ListItem value="120">120x90</asp:ListItem>
			<asp:ListItem value="160">160x120</asp:ListItem>
			<asp:ListItem value="200">200x150</asp:ListItem>
		</asp:DropDownList>
		</td></tr>
		<tr><td colspan=2>
		<asp:CheckBox id="getSmall" runat=server/>
		<asp:DropDownList id="smallSize"
			runat=server >
			<asp:ListItem value="800">800x600</asp:ListItem>
			<asp:ListItem value="640">640x480</asp:ListItem>
			<asp:ListItem value="480">480x360</asp:ListItem>
			<asp:ListItem value="360">340x270</asp:ListItem>
			<asp:ListItem value="240">240x180</asp:ListItem>
			<asp:ListItem value="120">120x90</asp:ListItem>
		</asp:DropDownList>
		</td></tr>
		</table>
	</td></tr>
	<tr><td align="center">
	<%
	Submit.Text=lang["submit_text"].ToString();
	%>
	   <asp:Button id="Submit" text="ÉÏ´«" onclick="Submit_OnClick" runat=server/>
	</td> </tr>
	</table>	
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=350 align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>



</form>
</body>
</html>
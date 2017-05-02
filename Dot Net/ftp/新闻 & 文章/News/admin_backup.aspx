<%@Page Language="C#" Inherits="Article.Admin.Backup" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<asp:Label width=100% id=myLabel Visible=false runat=server/> 
<form id="MyForm" runat=server>

<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_backup"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<table cellpadding=0 cellspacing=0 width="100%" border="0" >
	<asp:PlaceHolder id="mdbShow" runat="server">
	  <tr align=center height=25>
	   <td class="tdbg-dark"><b><%=lang["backup_database"]%></b></td>
	  </tr>
	  <tr height=100> 
	   <td align="center" class="tdbg">
		<%=lang["backup_database_name"]%> 
		<asp:TextBox Columns=25 MaxLength=15 id="BackName" Text="db/backup.cs" runat=server/>
		<asp:RequiredFieldValidator id="RequiredFieldValidator"
			ControlToValidate="BackName"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator id="RegularExpressionValidator"
			runat=server
			ControlToValidate="BackName"
			ValidationExpression="\w+\.\w+"
			ErrorMessage="*"
			Display="Dynamic" /> <br><br>
	
		<%
		Submit.Text=lang["submit_text"].ToString();
		%>
	   <asp:Button id="Submit" text="备份" onclick="Submit_OnClick" runat=server/>
	   <br><br>
	   <%=lang["backup_note"]%>
	   </td>
	  </tr>
	</asp:PlaceHolder>
	  <tr align=center height=25>
	   <td class="tdbg-dark"><b><%=lang["backup_upload"]%></b></td>
	  </tr>
	  <tr height=100> 
	   <td align="center" class="tdbg">
		<%=lang["backup_upload_directory"]%>
		<asp:TextBox Columns=25 MaxLength=15 id="BackUploadPath" Text="D:\backup" runat=server/>
		<asp:RequiredFieldValidator
			ControlToValidate="BackUploadPath"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			runat=server
			ControlToValidate="BackUploadPath"
			ValidationExpression="[a-zA-Z0-9\\/.:]+"
			ErrorMessage="*"
			Display="Dynamic" /> <br><br>
		<%
		Submit2.Text=lang["submit_text"].ToString();
		%>
	   <asp:Button id="Submit2" text="备份" onclick="Submit2_OnClick" runat=server/>
	   <br>
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
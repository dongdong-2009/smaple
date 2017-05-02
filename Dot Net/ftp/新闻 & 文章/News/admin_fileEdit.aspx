<%@ Page Language="C#" Inherits="Article.Admin.FileEdit" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>


<form id="myForm" runat=server>

<table width=600 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><asp:Literal id="literalTitle" runat=server></asp:Literal></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=600 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label width=100% style="text-align:center" id=myLabel runat=server/> 
	<table cellpadding=3 cellspacing=0 width="95%" align="center" >
	<tr>
	<td>
		<asp:TextBox id="Body"
			TextMode="MultiLine"
			Rows=20
			Columns=90
			runat=server />
	</td></tr>
	<tr><td colspan=2 align=center>
	<%
	Submit.Text=lang["submit_text"].ToString();
	%>	
	   <asp:Button id="Submit" text="ÐÞ ¸Ä" onclick="Submit_OnClick" runat=server/>
	   </td>
	  </tr>
	 </table>
	
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=600 align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>


</form>

</body>
</html>
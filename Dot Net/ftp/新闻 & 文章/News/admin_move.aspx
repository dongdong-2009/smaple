<%@Page Language="C#" Inherits="Article.Admin.Move" %>

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
	<span class="mframe-t-text"><%=lang["title_news_move"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=300 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label width=100% id=myLabel style="text-align:center" runat=server/> 
	<table cellpadding=3 width="95%" align="center" >
	<tr><td align="center">
		<%=lang["class_from"]%>
		<asp:DropDownList id="ClassID"
			runat=server />
		<asp:RequiredFieldValidator
			ControlToValidate="ClassID"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<script>
		function setOptionColor(obj)
		{
			for (var i=0;i<obj.options.length;i++)
			{
				if (obj.options[i].value=="")
				{
					obj.options[i].style.color="gray";
				}else{
					obj.options[i].style.color="black";
				}
			}
		}
		setOptionColor(document.all.<%=ClassID.ClientID%>);
		</script>
	</td></tr>
	<tr><td align="center">
		<%=lang["class_to"]%>
		<asp:DropDownList id="ToClassID"
			runat=server />
		<asp:RequiredFieldValidator
			ControlToValidate="ToClassID"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<script>
		setOptionColor(document.all.<%=ToClassID.ClientID%>);
		</script>
	</td></tr>
	<tr><td align="center">
		<%
		Submit.Text=lang["submit_text"].ToString();
		%>
		<asp:Button id="Submit" text="×ª ÒÆ" onclick="Submit_OnClick" runat=server/>
	</td></tr>
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
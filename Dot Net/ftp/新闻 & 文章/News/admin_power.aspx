<%@Page Language="C#" Inherits="Article.Admin.Power" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
<script>
function checkAll(layer)
{
	for(var i=0; i<layer.children.length; i++)
	{
		if (layer.children[i].children.length>0)
		{
			checkAll(layer.children[i]);
		}else{
			if (layer.children[i].type=="checkbox")
			{
				layer.children[i].checked = !layer.children[i].checked;
			}
		}
	}
}
</script>
</head>
<body>

<asp:Label width=100% id=myLabel Style="text-align:center" runat=server/> 

<table width=95% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><asp:Literal id="Username" runat=server/></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=95% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Literal id="Content" runat=server/>
</td>
<td class="mframe-m-right"></td>
</tr>
</table>
<table width=95% align=center cellspacing=0 cellpadding=0 >
<tr>
<td class="mframe-b-left"></td>
<td class="mframe-b-mid">&nbsp;</td>
<td class="mframe-b-right"></td>
</tr>
</table>
	

</body>
</html>
<%@Page Language="C#" Inherits="Article.Admin.GetJs" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<script>
function GenerateJs()
{
	var s;
	s=window.location.href;
	s=s.substring(0,s.lastIndexOf("/")+1);
	s+="js.aspx?type=";
	s+=document.all.topType.value;
	s+="&classid=";
	s+=document.all.<%=classID.ClientID%>.value;
	s+="&topicid=";
	s+=document.all.<%=topicID.ClientID%>.value;
	s+="&num=";
	s+=document.all.topNum.value;
	s+="&showclass=";
	s+=document.all.showClass.checked ? "1" : "0";
	s+="&showdate=";
	s+=document.all.showDate.checked ? "1" : "0";
	s+="&showhits=";
	s+=document.all.showHits.checked ? "1" : "0";
	s+="&shownew=";
	s+=document.all.showNew.checked ? "1" : "0";
	s+="&img=";
	s+=document.all.imgNews.checked ? "1" : "0";
	s+="&maxlen=";
	s+=document.all.maxLength.value;
	document.all.jsArea.value="<script src=\""+s+"\"><\/script>";
}

function CopyJs()
{
	document.all.jsArea.focus();
	document.all.jsArea.select();
	document.execCommand("copy");
}
</script>
<body>


<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text"><%=lang["title_getjs"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<table width=95% align=center style="table-layout:fixed">
	<form runat=server>
	<tr>
	<td width=80>
		<%=lang["get_type"]%>
	</td><td>	
		<select id="topType">
			<option value="new"><%=lang["type_new"]%></option>
			<option value="hot"><%=lang["type_hot"]%></option>
			<option value="weekhot"><%=lang["type_week_hot"]%></option>
			<option value="dayhot"><%=lang["type_day_hot"]%></option>
			<option value="adminchart"><%=lang["type_admin_chart"]%></option>
		</select> &nbsp; &nbsp;
		<input type="checkbox" id="imgNews"> <label for="imgNews"><%=lang["img_news"]%></label>
	</td>
	</tr>
	<tr>
	<td>
		<%=lang["get_class"]%>
	</td><td>	
		<asp:DropDownList id="classID"
			runat=server/>
	</td>
	</tr>
	<tr>
	<td>
		<%=lang["get_topic"]%>
	</td><td>	
		<asp:DropDownList id="topicID"
			runat=server/>
	</td>
	</tr>
	<tr>
	<td>
		<%=lang["num"]%>
	</td><td>
		<input type="text" id="topNum" value=10 size=3 maxlength=3>
	</td>
	</tr>
	<tr>
	<td>
		<%=lang["max_title_length"]%>
	</td><td>
		<input type="text" id="maxLength" value=15 size=3 maxlength=3>
	</td>
	</tr>
	<tr>
	<td>
		<%=lang["show_what"]%>
	</td><td>
		<input type="checkbox" id="showClass" > <label for="showClass"><%=lang["show_class"]%></label>&nbsp; &nbsp;
		<input type="checkbox" id="showDate" > <label for="showDate"><%=lang["show_date"]%></label>&nbsp; &nbsp;
		<input type="checkbox" id="showHits" > <label for="showHits"><%=lang["show_hits"]%></label>&nbsp; &nbsp;
		<input type="checkbox" id="showNew" > <label for="showNew"><%=lang["show_new_icon"]%></label>&nbsp; &nbsp;
	</td>
	</tr>
	<tr>
	<td>
		&nbsp;
	</td>
	<td>
		<input type="button" value="<%=lang["generate_text"]%>" onclick="GenerateJs();"> &nbsp; &nbsp; 
		<input type="button" value="<%=lang["copy_text"]%>" onclick="CopyJs();">
	</td>
	</tr>
	<tr>
	<td colspan=2 align=center>
		<textarea id="jsArea" cols=90 rows=6></textarea>
	</td>
	</tr>
	<tr>
	<td colspan=2 height=30>
		<%=lang["note"]%>
	</td>
	</tr>
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
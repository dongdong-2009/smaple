<%@Page Language="C#" Inherits="Article.Show" EnableSessionState="false" EnableViewState="false" %>
<%@Register TagPrefix="WbControls" Namespace="WbControls" Assembly="WbControls" %>

<html>
<head>
<title><%=myConst.SiteName+" --- "+ Title%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<meta name=keywords content="动网新闻.net,asp.net,新闻系统">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
<script language="JavaScript">
var currentpos,timer; 
function initializeScroll() { timer=setInterval("scrollwindow()",80);} 
function scrollclear(){clearInterval(timer);}
function scrollwindow() {currentpos=document.body.scrollTop;window.scroll(0,++currentpos);if (currentpos != document.body.scrollTop) sc();} 
document.onmousedown=scrollclear
document.ondblclick=initializeScroll
</script>
</head>
<body>
<span id="printScript" name="printScript">
<script language=javascript>
function ContentSize(size)
{
	var obj=document.all.<%=BodyLabel.ClientID%>;
	obj.style.fontSize=size+"px";
}
</script>
</span>
<script language=javascript src="inc/print.js"></script>

<!--#include file="../head.inc" -->
<table class="twidth" align=center cellpadding=0 cellspacing=0 >
<tr>
<td class="navbar-left">
</td>
<td class="navbar">
	<!--#include file="../inc/navclass.aspx"-->
</td>
<td class="navbar-right">
</td>
</tr>
</table>

&nbsp;

<table class="twidth" align=center cellspacing=0>
<tr><td>

	<div id="printBody" name="printBody">
	
	<table width="100%" align=center cellspacing=0>
	<tr>
	<td class="summary-title">
		&nbsp; <%=StepPath()%>
	</td>
	</tr>
	<tr ><td valign=top class="tdbg">
		<br><center class="aTitle"><%=Title%></center>
		<table width=97% >
			<td align=right>
			<%=lang["author"]%><asp:Label id="AuthorLabel" runat=server /><br>
			</td></tr>
		</table>
		
		
		<asp:Label id="BodyLabel" class="content" Style="display:block;padding:0px 10px"  runat=server /><br><br>
		
		
		<table width="97%" cellpadding=0 cellspacing=0 style="table-layout:fixed;word-break:break-all">
		<tr><td align=right>
			<table><tr>
			<td>
			<%=lang["source"]%><asp:Label id="SourceLabel" runat=server /><br>
			<%=lang["read_times"]%><asp:Label id="HitsLabel" runat=server /> 次<br>
			<%=lang["date"]%><asp:Label id="TimeLabel" runat=server /><br><br>
			</td></tr>
			</table>
		</td></tr>
		<tr><td align=right>
			【 <a href="remark.aspx?ID=<%=articleID%>" target=_blank><%=lang["remark"]%></a> 】
			【 <a href="mail.aspx?ID=<%=articleID%>" target=_blank><%=lang["recommendation"]%></a> 】
			【 <a href="javascript:doPrint()"><%=lang["print"]%></a> 】
			【 <%=lang["font_size"]%><a href="javascript:ContentSize(16)"><%=lang["font_size_big"]%></a> <a href="javascript:ContentSize(14)"><%=lang["font_size_normal"]%></a> <a href="javascript:ContentSize(12)"><%=lang["font_size_small"]%></a> 】
		</td></tr>
		</table>
		
		<table width=97% align=center>
			<tr><td>
			<%=lang["next_news"]%><asp:Literal id="PreviousLink" runat=server /><br>
			<%=lang["prev_news"]%><asp:Literal id="NextLink" runat=server />
			</td></tr>
		</table>
	</td></tr>
	<tbody id="printHide" name="printHide" >
	<tr>
	<td class="summary-title">&nbsp; &gt;&gt; <%=lang["title_related_news"]%>
		&nbsp; &nbsp; &nbsp; 
		<%
		if (Nkey!="") 
		{
			Response.Write("<a href='search.aspx?Where=Nkey&Keyword=");
			Response.Write(Nkey);
			Response.Write("'>");
			Response.Write(lang["all_related_news"]);
			Response.Write("</a>");
		}
		%>
	</td></tr>
	<tr valign=top class="tdbg">
	<td style="padding:5px 2px">
		<%RelateNews(5,40);%>&nbsp;
	</td></tr>
	
	<script runat=server>/*要显示评论请删本行---------------
	<tr>
	<td class="summary-title">&nbsp; &gt;&gt; <a href="remark.aspx?id=<%=articleID%>" target=_blank><%=lang["title_remark_list"]%></a>
	</td></tr>
	<tr valign=top class="tdbg">
	<td style="padding:5px 2px">
		<%Remarks(5,20);%>&nbsp;
	</td></tr>
	要显示评论请删本行----------------------*/</script>
	
	<tr>
		<td align=center class="summary-title">
		<%=lang["title_post_remark"]%>
		</td>
		<tr>
		<form name="remarkForm" action="remark.aspx?id=<%=articleID%>" method="post" onsubmit="return checkRemark();">
		<td class="tdbg">
			<table width=100% cellpadding=5 cellspacing=0 border=0>
			<tr><td valign=top>
				<script>
				function checkRemark()
				{
				var form=document.all.remarkForm;
				if (form.body.value=="")
				{	alert("<%=lang["remark_write_content"]%>");
					form.body.focus();
					return false;
				}
				if (form.username.value=="")
				{	alert("<%=lang["remark_write_name"]%>");
					form.username.focus();
					return false;
				}
				if (form.body.value.length>200)
				{	alert("<%=lang["remark_max_200_letters"]%>");
					form.body.focus();
					return false;
				}
				if (form.username.value.length>10)
				{	alert("<%=lang["remark_name_max_10_letters"]%>");
					form.username.focus();
					return false;
				}
				form.submit.disabled=true;
				return true;
				}
				function showLen(obj)
				{
					document.all.bodyLen.innerText=obj.value.length;
				}
				</script>
				<input type="radio" name="face" value="1" checked="True"><img src=pic/face1.gif>
				<input type="radio" name="face" value="2"><img src=pic/face2.gif>
				<input type="radio" name="face" value="3"><img src=pic/face3.gif>
				<input type="radio" name="face" value="4"><img src=pic/face4.gif>
				<input type="radio" name="face" value="5"><img src=pic/face5.gif>
				<input type="radio" name="face" value="6"><img src=pic/face6.gif>
				<input type="radio" name="face" value="7"><img src=pic/face7.gif>
				<input type="radio" name="face" value="8"><img src=pic/face8.gif>
				<input type="radio" name="face" value="9"><img src=pic/face9.gif><br>
				<input type="radio" name="face" value="10"><img src=pic/face10.gif>
				<input type="radio" name="face" value="11"><img src=pic/face11.gif>
				<input type="radio" name="face" value="12"><img src=pic/face12.gif>
				<input type="radio" name="face" value="13"><img src=pic/face13.gif>
				<input type="radio" name="face" value="14"><img src=pic/face14.gif>
				<input type="radio" name="face" value="15"><img src=pic/face15.gif>
				<input type="radio" name="face" value="16"><img src=pic/face16.gif>
				<input type="radio" name="face" value="17"><img src=pic/face17.gif>
				<input type="radio" name="face" value="18"><img src=pic/face18.gif><br>
				<%=lang["remark_content"]%>
				<textarea name="body" cols="40" Rows="4" onkeydown="showLen(this)" onkeyup="showLen(this)"></textarea> <%=lang["remark_letters"]%><span id="bodyLen">0</span>
				<br>
				<%=lang["remark_name"]%>
				<input type=text name="username" value="<%=memberName%>" MaxLength=15 size=10 <%if (myConst.RemarkMemberOnly){Response.Write("readonly");}%>>
				<input type=submit name=submit value="<%=lang["remark_submit"]%>" >
				<%
				if (myConst.RemarkMemberOnly)
				{
					Response.Write(lang["remark_member_only"]);
				}
				%>
				<br><br>
				<WbControls:ClientDateControl id="clientDate" runat=server />
			</td>
			<td width=200>
			<ul style="list-style-type:square;margin-left:1em;line-height:150%">
			<%
			foreach(string s in lang["remark_statement"].ToString().Split(new Char[]{'\n'}) )
			{
				Response.Write("<li>");
				Response.Write(s);
			}
			%>
			</ul>
			</td></tr>
			</table>
		</td>
		</form>
	</tr>
	</tbody>
	</table>
	</div>
</td><td width=170 align=right valign=top>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-t-left"></td>
	<td class="lframe-t-mid">
		<span class="lframe-t-text"><%=lang["title_search"]%></span>
	</td>
	<td class="lframe-t-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-m-left"></td>
	<td class="lframe-m-mid" valign=top>
		<form method="get" action="search.aspx" name="frmSearch" style="display:inline;">
			<center><br>
			<input type="text" name="keyword" class=inputbg size="20"><br>
			<select name="where">
				<option value="title"><%=lang["news_search_title"]%></option>
				<option value="content"><%=lang["news_search_content"]%></option>
				<option value="writer"><%=lang["news_search_author"]%></option>
			</select>
			<input type="submit" value="<%=lang["news_search_submit"]%>"><br>
			</center>
		</form>
	</td>
	<td class="lframe-m-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0 >
	<tr>
	<td class="lframe-b-left"></td>
	<td class="lframe-b-mid">&nbsp;</td>
	<td class="lframe-b-right"></td>
	</tr>
	</table>

</td></tr>
</table>



<!--#include file="../foot.inc" -->


</body>
<html>
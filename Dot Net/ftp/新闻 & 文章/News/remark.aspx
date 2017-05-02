<%@Page Language="C#" Inherits="Article.Remark" EnableSessionState="false" EnableViewState="false" %>
<%@Register TagPrefix="WbControls" Namespace="WbControls" Assembly="WbControls" %>
<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<meta name="keywords" content="动网新闻.net,asp.net,新闻系统">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<asp:PlaceHolder id="phMain" runat=server>
<table width=600 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	　<b><asp:Literal id="TitleLiteral" runat=server/> <span class="mframe-t-text" style="width:6em"><%=lang["title_remark"]%></span></b>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=600 align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<table width=100% cellpadding=0 cellspacing=0 >
		<tr>
		<form name="remarkForm" action="" method="post" onsubmit="return checkForm();">
		<td class="tdbg" align=center>
			<table width=100% cellpadding=5 cellspacing=0 border=0>
			<tr><td>
				<script>
				function checkForm()
				{
				var form=document.all.remarkForm;
				if (form.body.value=="")
				{	alert("<%=lang["write_content"]%>");
					form.body.focus();
					return false;
				}
				if (form.username.value=="")
				{	alert("<%=lang["write_name"]%>");
					form.username.focus();
					return false;
				}
				if (form.body.value.length>200)
				{	alert("<%=lang["content_limit_200"]%>");
					form.body.focus();
					return false;
				}
				if (form.username.value.length>10)
				{	alert("<%=lang["name_limit_10"]%>");
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
				<textarea name="body" cols="40" Rows="4" onkeydown="showLen(this)" onkeyup="showLen(this)"></textarea> <%=lang["letter_num"]%><span id="bodyLen">0</span>
				<br>
				<%=lang["remark_name"]%>
				<input type=text name="username" value="<%=memberName%>" MaxLength=15 size=10 <%if (myConst.RemarkMemberOnly){Response.Write("readonly");}%>>
				<input type=submit name=submit value="<%=lang["submit_text"]%>" >
				<%
				if (myConst.RemarkMemberOnly)
				{
					Response.Write(lang["member_only"]);
				}
				%>
				<WbControls:ClientDateControl id="clientDate" runat=server />
			</td>
			<td width=200>
			<ul style="list-style-type:square;margin-left:1em;margin-bottom:0px">
			<%
			foreach(string s in lang["statement"].ToString().Split(new Char[]{'\n'}) )
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
	<tr>
	<td width=50% class="summary-title">&nbsp; &gt;&gt; <%=lang["title_remark_list"]%></td></tr>
	<tr height=30><td class="tdbg" style="padding:5px 2px">
		<table width=100% cellpadding=0 cellspacing=0 border=0 >
			<asp:Repeater id="myRepeater" runat=server >
			<ItemTemplate>
				<tr><td class="tdbg-dark" height=25>		
				&nbsp;<img src="pic/face<%#DataBinder.Eval(Container.DataItem,"face")%>.gif" align=absmiddle>
				<%=lang["writer_1"]%> <b><%# DataBinder.Eval(Container.DataItem,"username")%></b> 
				<%=lang["writer_2"]%>
				<font class=gray><%# DataBinder.Eval(Container.DataItem,"dateAndTime")%></font>
				<%=lang["writer_3"]%>
				</td></tr>
				<tr><td >
				<span style="padding:5px 10px 5px 30px;width=100%; word-break:break-all">
				<%# DataBinder.Eval(Container.DataItem,"body")%>
				</span>
				</td></tr>
				<tr height=1><td class=hr></td></tr>
			</ItemTemplate>
			</asp:Repeater>
		</table>
		<br>
		<center><asp:Literal id="PageLiteral" runat=server /></center>
	</td></tr>
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
</asp:PlaceHolder>

<asp:PlaceHolder id="phMsg" Visible="false" runat=server>
	<table width=300 align=center cellspacing=0 cellpadding=0>
	<tr>
	<td class="mframe-t-left"></td>
	<td class="mframe-t-mid">
		<span class="mframe-t-text" ><%=lang["title_post_result"]%></span>
	</td>
	<td class="mframe-t-right"></td>
	</tr>
	</table>
	<table width=300 height=100 align=center cellspacing=0 cellpadding=0>
	<tr>
	<td class="mframe-m-left"></td>
	<td class="mframe-m-mid" align=center>
			<asp:Literal id="ltMsg" runat=server/>
			<script language=javascript>
			function goBack()
			{
				window.location=window.location;
			}
			window.setTimeout("goBack();",2000);
			</script>
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
</asp:PlaceHolder>

<!--#include file="foot.inc" -->

</body>
<html>
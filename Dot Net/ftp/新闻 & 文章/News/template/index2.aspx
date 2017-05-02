<%@Page Language="C#" Inherits="Article.Default" EnableSessionState="false" EnableViewState="false" %>
<%@Register TagPrefix="WbControls" Namespace="WbControls" Assembly="WbControls" %>
<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<meta name="keywords" content="动网新闻.net,asp.net,新闻系统">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

<!--#include file="../head.inc" -->

<TABLE ID="NotSupport" width="100%" height="80%" style="position:absolute; left:10px; background:white;" runat="server" >	
	<tr>
		<td align="center" class="content">
			<font color=red ><b>注意：您的服务器不支持asp.net</b><br>
			请到 <a href="http://www.aspsky.net/"><u>动网先锋</u></a> 查看.Net相关的文章及如何安装.Net环境</font>
		</td>
	</tr>
</TABLE>



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

<br>

<table class="twidth" cellpadding=0 cellspacing=0 align=center>
<tr align="left" valign=top >
<td width=200>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-t-left"></td>
	<td class="lframe-t-mid">
		<span class="lframe-t-text"><%=lang["title_member_login"]%></span>
	</td>
	<td class="lframe-t-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-m-left"></td>
	<td class="lframe-m-mid">
	<%if (theMember.Loged){%>
		<table width=95% align=center cellpadding=0 cellspacing=0 border=0>
		<tr><td valign=top style="padding:5px 15px;line-height:150%">
			<%=lang["member_hello"]%><%=theMember.Name%><br>
			<a href="membernewsadd.aspx" target="_blank"><%=lang["member_add_news"]%></a><br>
			<%=lang["member_add_news_num"]%><%=theMember.AddNum%><br>
			<a href="memberModify.aspx"><%=lang["member_profile"]%></a>　<a href="logout.aspx"><%=lang["member_logout"]%></a>
		</td></tr>
		</table>
	<%}else{%>
		<table width=95% align=center cellpadding=0 cellspacing=0 border=0>
		<script>
		function checkForm()
		{
		var form=document.all.loginForm;
		if (form.memberName.value=="")
		{	alert("<%=lang["login_need_name"]%>");
			form.memberName.focus();
			return false;
		}
		if (form.memberPass.value=="")
		{	alert("<%=lang["login_need_password"]%>");
			form.memberPass.focus();
			return false;
		}
		return true;
		}
		</script>
		<form id="loginForm" method="post" action="login.aspx">
		<tr><td valign=top align=center >
			<table width=100% cellpadding=3><tr><td align=center>
			<%=lang["login_name"]%><input type=text class=inputbg name="memberName" size=15 maxlength=50>
			</td></tr><tr><td align=center>
			<%=lang["login_password"]%><input type=password class=inputbg name="memberPass" size=15 maxlength=50><br>
			</td></tr><tr><td align=center>
			<%=lang["login_keep"]%><select name="keepLogin">
				<option value=""><%=lang["login_keep_not"]%></option>
				<option value="day"><%=lang["login_keep_day"]%></option>
				<option value="week"><%=lang["login_keep_week"]%></option>
				<option value="month"><%=lang["login_keep_month"]%></option>
				<option value="year"><%=lang["login_keep_year"]%></option>
				</select>
			</td></tr><tr><td align=center>
			<input type=submit value="<%=lang["login_submit"]%>" onclick="return checkForm();">&nbsp; <input type=button onclick="window.location='memberreg.aspx'" value="<%=lang["register_submit"]%>">
			<WbControls:ClientDateControl id="clientDate" runat="server"/>
			</td></tr>
			<tr><td align=center>
			<a href="memberactive.aspx"><%=lang["member_activate"]%></a>&nbsp; <a href="memberLostpass.aspx"><%=lang["member_get_password"]%></a>
			</td></tr>
			</table>
		</td></tr>
		</form>
		</table>
	<%}%>
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


	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-t-left"></td>
	<td class="lframe-t-mid">
		<span class="lframe-t-text"><%=lang["title_site_state"]%></span>
	</td>
	<td class="lframe-t-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-m-left"></td>
	<td class="lframe-m-mid">
		<img src="<%=style.PicBullet%>" align=absmiddle> <%=lang["state_news_num"]%> <%=sState.NewsNum%><br>
		<img src="<%=style.PicBullet%>" align=absmiddle> <%=lang["state_img_news_num"]%> <%=sState.ImgNewsNum%><br>
		<img src="<%=style.PicBullet%>" align=absmiddle> <%=lang["state_uncheck_news_num"]%> <%=sState.UncheckNewsNum%><br>
		<img src="<%=style.PicBullet%>" align=absmiddle> <%=lang["state_member_num"]%> <%=sState.MemberNum%><br>
		<img src="<%=style.PicBullet%>" align=absmiddle> <%=lang["state_uncheck_member_num"]%> <%=sState.UncheckMemberNum%><br>
		<img src="<%=style.PicBullet%>" align=absmiddle> <%=lang["state_topic_num"]%> <%=sState.TopicNum%>
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
	


	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-t-left"></td>
	<td class="lframe-t-mid">
		<span class="lframe-t-text"><%=lang["title_hot_news"]%></span>
	</td>
	<td class="lframe-t-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-m-left"></td>
	<td class="lframe-m-mid">
		<%TopList(0,0,"hot",10,26,false,false,false,false,false);%>
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
	
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-t-left"></td>
	<td class="lframe-t-mid">
		<span class="lframe-t-text"><%=lang["title_hot_news_week"]%></span>
	</td>
	<td class="lframe-t-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-m-left"></td>
	<td class="lframe-m-mid">
		<%TopList(0,0,"weekhot",10,26,false,false,false,false,false);%>
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

	
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-t-left"></td>
	<td class="lframe-t-mid">
		<span class="lframe-t-text"><%=lang["title_hot_news_day"]%></span>
	</td>
	<td class="lframe-t-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-m-left"></td>
	<td class="lframe-m-mid">
		<%TopList(0,0,"dayhot",10,26,false,false,false,false,false);%>
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
	
</td>
<td>

	<table width=100% cellspacing=0 cellpadding=0>
	<tr>
	<td class="mframe-t-left"></td>
	<td class="mframe-t-mid">
		<span class="mframe-t-text"><%=lang["title_headline"]%></span>
	</td>
	<td class="mframe-t-right"></td>
	</tr>
	</table>
	<table width=100% cellspacing=0 cellpadding=0>
	<tr>
	<td class="mframe-m-left"></td>
	<td class="mframe-m-mid">
		<table width=100% cellpadding=0 cellspacing=0 border=0 >
		<tr>
			<td valign=top width=200>
				<%ImgHeadline(2,"verticle",200);%>
			</td>
			<td valign=top width=* >
				<%Headline(12,36);%>
			</td>
		</tr>
		</table>

		<table width=100% >
		<tr>
			<td class=hr>
			</td>
		</tr>
		<tr>
			<td align="center" height=30>
			<!-----------快速搜索栏----------->
			<form method="get" action="search.aspx" name="frmSearch" style="display:inline">
				<%=lang["news_search"]%>
				<input type="text" name="keyword" class=inputbg size="20">
				<input type="radio" name="where" value="title" checked><%=lang["news_search_title"]%>
				<input type="radio" name="where" value="content"><%=lang["news_search_content"]%>
				<input type="radio" name="where" value="writer"><%=lang["news_search_author"]%>
				<input type="submit" value="<%=lang["news_search_submit"]%>">
			</form>
			<!-----------搜索栏结束----------->
			</td>
		</tr>
		</table>
	</td>
	<td class="mframe-m-right"></td>
	</tr>
	</table>
	<table width=100% cellspacing=0 cellpadding=0 >
	<tr>
	<td class="mframe-b-left"></td>
	<td class="mframe-b-mid">&nbsp;</td>
	<td class="mframe-b-right"></td>
	</tr>
	</table>

	
	<table cellspacing=0 cellpadding=0 width=100%>
	<tr><td>
		<%-- 绑定所有分类的最新新闻 --%>
		<%BindAllNew(dlAll);%>
		<asp:DataList id="dlAll"
			RepeatDirection="Horizontal"
			RepeatColumns="1"
			Width="100%"
			DataKeyField="classid"
			OnItemDataBound="dlAll_ItemBound"
			runat=server>
			<ItemStyle VerticalAlign="top" Width="50%" />
			<ItemTemplate>
				<table width=100% cellspacing=0 cellpadding=0>
				<tr>
				<td class="mframe-t-left"></td>
				<td class="mframe-t-mid">
					<table width="100%" height="100%" cellpadding=0 cellspacing=0 border=0>
					<tr><td>
						<span class="mframe-t-text"><%#DataBinder.Eval(Container.DataItem,"class")%></span>
					</td><td align=right>
						<a href="list.aspx?cid=<%#DataBinder.Eval(Container.DataItem,"classid")%>"><img src="<%=style.PicMore%>" border=0></a>
					</td></tr>
					</table>
				</td>
				<td class="mframe-t-right"></td>
				</tr>
				</table>
				<table width=100% cellspacing=0 cellpadding=0>
				<tr>
				<td class="mframe-m-left"></td>
				<td class="mframe-m-mid">
					<table width=100% cellpadding=0 cellspacing=0 border=0>
					<asp:Repeater id="rpClass"
						runat="server" >
						<ItemTemplate>
						<tr><td>
						<%#NewsTitle((int)DataBinder.Eval(Container.DataItem,"articleid"), (int)DataBinder.Eval(Container.DataItem,"classid"), DataBinder.Eval(Container.DataItem,"title").ToString(), (bool)DataBinder.Eval(Container.DataItem,"highlight"), DataBinder.Eval(Container.DataItem,"permitGroups").ToString(), DataBinder.Eval(Container.DataItem,"aUrl").ToString(), (DateTime)DataBinder.Eval(Container.DataItem,"dateandtime"), 45)%>
						</td><td width=35 align=center>
						<span class="<%#(DateTime)DataBinder.Eval(Container.DataItem,"dateandtime")<DateTime.Now.Date ? "gray" : "time"%>"><%#String.Format ("{0:MM-dd}",DataBinder.Eval(Container.DataItem,"dateandtime"))%></span>
						</td></tr>
						</ItemTemplate>
					</asp:Repeater>
					</table>
				</td>
				<td class="mframe-m-right"></td>
				</tr>
				</table>
				<table width=100% cellspacing=0 cellpadding=0 >
				<tr>
				<td class="mframe-b-left"></td>
				<td class="mframe-b-mid">&nbsp;</td>
				<td class="mframe-b-right"></td>
				</tr>
				</table>
			</ItemTemplate>
		</asp:DataList>
	</td><td width=180 valign=top align=right>
		<table width=95% cellspacing=0 cellpadding=0>
		<tr>
		<td class="mframe-t-left"></td>
		<td class="mframe-t-mid">
			<span class="mframe-t-text"><%=lang["title_new_img_news"]%></span>
		</td>
		<td class="mframe-t-right"></td>
		</tr>
		</table>
		<table width=95% cellspacing=0 cellpadding=0>
		<tr>
		<td class="mframe-m-left"></td>
		<td class="mframe-m-mid">
			<%ImgTopList(0,5,1,"right",false,false);%>
		</td>
		<td class="mframe-m-right"></td>
		</tr>
		</table>
		<table width=95% cellspacing=0 cellpadding=0 >
		<tr>
		<td class="mframe-b-left"></td>
		<td class="mframe-b-mid">&nbsp;</td>
		<td class="mframe-b-right"></td>
		</tr>
		</table>
	</td></tr>
	</table>
	
	&nbsp;
	
	<table width=100% cellspacing=0 cellpadding=0>
	<tr>
	<td class="mframe-t-left"></td>
	<td class="mframe-t-mid">
	<span class="mframe-t-text">&nbsp; &gt;&gt;  <%=lang["title_site_map"]%></span>
	</td>
	<td class="mframe-t-right"></td>
	</tr>
	</table>
	<table width=100% cellspacing=0 cellpadding=0>
	<tr>
	<td class="mframe-m-left"></td>
	<td class="mframe-m-mid">
		<%NavList(5);%>
	</td>
	<td class="mframe-m-right"></td>
	</tr>
	</table>
	<table width=100% cellspacing=0 cellpadding=0 >
	<tr>
	<td class="mframe-b-left"></td>
	<td class="mframe-b-mid">&nbsp;</td>
	<td class="mframe-b-right"></td>
	</tr>
	</table>

</td>
</tr>
</table>

<!--#include file="../foot.inc" -->
</body>
<html>

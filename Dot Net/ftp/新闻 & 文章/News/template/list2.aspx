<%@Page Language="C#" Inherits="Article.List" EnableSessionState="false" EnableViewState="false" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<meta name="keywords" content="动网新闻.net,asp.net,新闻系统">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body>

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

<table class="twidth" align=center cellpadding=0 cellspacing=0>
<tr>
<td class="navsub-left"></td>
<td class="navsub">
	&nbsp; <%=StepPath()%>
</td>
<td class="navsub-right"></td>
</tr>
</table>
&nbsp;

<table class="twidth" cellpadding=0 cellspacing=0 border=0 align=center>
<tr align="left" valign=top >
<td width=200>
	
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-t-left"></td>
	<td class="lframe-t-mid">
		<span class="lframe-t-text"><%=lang["title_class"]%></span>
	</td>
	<td class="lframe-t-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-m-left"></td>
	<td class="lframe-m-mid">
		<%=ClassTree()%>
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
		<span class="lframe-t-text"><%=lang["title_news_hot_day"]%></span>
	</td>
	<td class="lframe-t-right"></td>
	</tr>
	</table>
	<table width=95% cellspacing=0 cellpadding=0>
	<tr>
	<td class="lframe-m-left"></td>
	<td class="lframe-m-mid">
		<% TopList(classID,0,"dayhot",10,26,false,false,false,false,false);%>
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
		<span class="mframe-t-text"><asp:Literal id="nameLiteral" runat=server/></span>
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
				<%ImgTopList(2);%>
			</td>
			<td valign=top width=* >
				<%Headline(12,36);%>
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

	<%-- 绑定所有分类的最新新闻 --%>
	<%BindAllNew(dlAll);%>
	<asp:DataList id="dlAll"
		RepeatDirection="Horizontal"
		RepeatColumns="2"
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
					<%#NewsTitle((int)DataBinder.Eval(Container.DataItem,"articleid"), (int)DataBinder.Eval(Container.DataItem,"classid"), DataBinder.Eval(Container.DataItem,"title").ToString(), (bool)DataBinder.Eval(Container.DataItem,"highlight"), DataBinder.Eval(Container.DataItem,"permitGroups").ToString(), DataBinder.Eval(Container.DataItem,"aUrl").ToString(), (DateTime)DataBinder.Eval(Container.DataItem,"dateandtime"), 30)%>
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
	<% SearchBar();%>

</td>
</tr>
</table>

<!--#include file="../foot.inc" -->
</body>
<html>
<%@Page Language="C#" Inherits="Article.Admin.Config" %>

<html>
<head>
<title><%=myConst.SiteName%></title>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<link rel="stylesheet" href="<%=style.Css%>" type="text/css">
</head>
<body >

<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-t-left"></td>
<td class="mframe-t-mid">
	<span class="mframe-t-text">&nbsp; <%=lang["title_config"]%></span>
</td>
<td class="mframe-t-right"></td>
</tr>
</table>
<table width=90% align=center cellspacing=0 cellpadding=0>
<tr>
<td class="mframe-m-left"></td>
<td class="mframe-m-mid">
	<asp:Label id="myLabel" runat=server/>
	<table align=center width=95% cellspacing=0 cellpadding=3>
	<form method="post" runat=server>
	<tr>
	<td colspan=2 class="tdbg-dark">
		&nbsp;
	</td>
	</tr>
	<tr>
	<td><b><%=lang["site_name"]%></b></td>
	<td>
		<asp:TextBox id="siteName" 
			Columns=30
			runat="server"
			/>
	</td></tr>
	<tr>
	<td><b><%=lang["site_url"]%></b></td>
	<td>
		<asp:TextBox id="siteUrl" 
			Columns=30
			runat="server"
			/>
	</td></tr>
	<tr>
	<td><b><%=lang["site_email"]%></b></td>
	<td>
		<asp:TextBox id="siteEmail" 
			Columns=30
			runat="server"
			/>
	</td></tr>
	<tr><td valign=top><b><%=lang["site_logo"]%></b>
	</td>
	<td>
		<asp:TextBox id="logo"
			Columns=70
			runat="server"
			/>
	</td></tr>
	
	<tr>
	<td colspan=2 class="tdbg-dark">
		&nbsp;
	</td>
	</tr>
	<tr><td valign=top><b><%=lang["site_style"]%></b>
	</td>
	<td>
		<asp:DropDownList id="styleID"
			runat="server"
			/>
	</td></tr>
	<tr>
	<td width=170><b><%=lang["page_size"]%></b></td>
	<td>
		<asp:TextBox id="pageSize" 
			Columns=3
			MaxLength=2
			Style="text-align:right"
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="pageSize"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="pageSize"
			ValidationExpression="\d+"
			ErrorMessage="*"
			runat=server/>
	</td></tr>
	<tr><td><b><%=lang["open_news_in"]%></b></td>
	<td>
		<%
		openNews.Items[0].Text=lang["open_news_blank"].ToString();
		openNews.Items[1].Text=lang["open_news_self"].ToString();
		%>
		<asp:DropDownList id="openNews"
			runat="server">
			<asp:ListItem value="true" ></asp:ListItem>
			<asp:ListItem value="false" ></asp:ListItem>
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["pic_align"]%></b></td>
	<td>
		<%
		picAlign.Items[0].Text=lang["pic_align_left"].ToString();
		picAlign.Items[1].Text=lang["pic_align_right"].ToString();
		%>
		<asp:DropDownList id="picAlign"
			runat="server">
			<asp:ListItem value="left" ></asp:ListItem>
			<asp:ListItem value="right" ></asp:ListItem>
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["titleimg_width"]%></b></td>
	<td>
		<asp:TextBox id="titleImgWidth"
			Size=5
			runat="server"/>
		<asp:RequiredFieldValidator
			ControlToValidate="titleImgWidth"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="titleImgWidth"
			ValidationExpression="\d+"
			ErrorMessage="*"
			runat=server/>
		<%=lang["titleimg_width_note"]%>
	</td></tr>
	<tr><td><b><%=lang["show_hits"]%></b></td>
	<td>
		<asp:DropDownList id="showHits"
			runat="server">
			<asp:ListItem value="true" >Yes</asp:ListItem>
			<asp:ListItem value="false" >No</asp:ListItem>
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["list_page_style"]%></b></td>
	<td>
		<asp:DropDownList id="listStyle"
			runat="server"/>
	</td></tr>
	<tr><td><b><%=lang["down_image"]%></b></td>
	<td>
		<asp:DropDownList id="downImage"
			runat="server">
			<asp:ListItem value="true" >Yes</asp:ListItem>
			<asp:ListItem value="false" >No</asp:ListItem>
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["local_domains"]%></b></td>
	<td>
		<asp:TextBox id="localDomains"
			Size=50
			MaxLength=250
			runat="server"/>
	</td></tr>
	<tr><td><b><%=lang["class_bind_news_num"]%></b></td>
	<td>
		<asp:TextBox id="bindNum"
			Size=3
			MaxLength=2
			Style="text-align:right"
			runat="server"/>
		<asp:RequiredFieldValidator
			ControlToValidate="bindNum"
			ErrorMessage="*"
			runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="BindNum"
			ValidationExpression="\d{1,2}"
			ErrorMessage="*"
			runat=server/>
	</td></tr>
	<tr><td><b><%=lang["show_icon_new"]%></b></td>
	<td>
		<asp:DropDownList id="showNew"
			runat="server">
			<asp:ListItem value="true" >Yes</asp:ListItem>
			<asp:ListItem value="false" >No</asp:ListItem>
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["date_format"]%></b></td>
	<td>
		<asp:TextBox id="dateFormat" Size="15" MaxLength="20" runat="server"/><%=lang["date_format_note"]%>
	</td></tr>
	<tr><td><b><%=lang["remark_member_only"]%></b></td>
	<td>
		<asp:DropDownList id="remarkMemberOnly"
			runat="server">
			<asp:ListItem value="true" >Yes</asp:ListItem>
			<asp:ListItem value="false" >No</asp:ListItem>
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["remark_interval"]%></b></td>
	<td>
		<asp:TextBox id="remarkInterval"
			Size=3
			MaxLength=2
			Style="text-align:right"
			runat=server/> <%=lang["remark_interval_minute"]%>
		<asp:RequiredFieldValidator
			ControlToValidate="remarkInterval"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="remarkInterval"
			ValidationExpression="\d{1,2}"
			ErrorMessage="*"
			runat=server/>
	</td></tr>
	<tr><td><b><%=lang["remark_filter"]%></b></td>
	<td>
		<asp:TextBox id="remarkHide" Size=40 runat=server/> <%=lang["remark_filter_note"]%>
	</td></tr>
	
	<tr>
	<td colspan=2 class="tdbg-dark" >
		&nbsp;
	</td>
	</tr>
	<tr><td><b><%=lang["template_index"]%></b></td>
	<td>
		<asp:DropDownList id="templateIndex"
			runat="server">
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["template_class"]%></b></td>
	<td>
		<asp:DropDownList id="templateList"
			runat="server">
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["template_news"]%></b></td>
	<td>
		<asp:DropDownList id="templateShow"
			runat="server">
		</asp:DropDownList>
	</td></tr>
	
	
	<tr>
	<td colspan=2 class="tdbg-dark" >
		&nbsp;
	</td>
	</tr>
	<tr><td><b><%=lang["member_reg_verify_mail"]%></b></td>
	<td>
		<asp:DropDownList id="memberRegVerifyMail"
			runat="server">
			<asp:ListItem value="true" >Yes</asp:ListItem>
			<asp:ListItem value="false" >No</asp:ListItem>
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["member_reg_check"]%></b></td>
	<td>
		<asp:DropDownList id="memberCheck"
			runat="server">
			<asp:ListItem value="true" >Yes</asp:ListItem>
			<asp:ListItem value="false" >No</asp:ListItem>
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["anyone_can_add"]%></b></td>
	<td>
		<asp:DropDownList id="anyoneCanAdd"
			runat="server">
			<asp:ListItem value="true" >Yes</asp:ListItem>
			<asp:ListItem value="false" >No</asp:ListItem>
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["member_reg_stop"]%></b></td>
	<td>
		<asp:DropDownList id="memberRegStop"
			runat="server">
			<asp:ListItem value="true" >Yes</asp:ListItem>
			<asp:ListItem value="false" >No</asp:ListItem>
		</asp:DropDownList>
	</td></tr>
	<tr><td><b><%=lang["member_reg_stop_words"]%></b></td>
	<td>
		<asp:TextBox id="memberRegStopWords" Size=40 runat=server/>
	</td></tr>
	<tr><td valign=top><b><%=lang["member_reg_statement"]%></b>
	</td>
	<td>
		<asp:TextBox id="memberStatement"
			TextMode="MultiLine"
			Columns=70
			Rows=4
			runat="server"
			/>
	</td></tr>
	
	<tr>
	<td colspan=2 class="tdbg-dark" >
		&nbsp;
	</td>
	</tr>
	<tr><td><b><%=lang["upload_directory"]%></b></td>
	<td>
		<asp:TextBox id="uploadPath"
			Size=15
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="uploadPath"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
	</td></tr>
	<tr><td><b><%=lang["upload_file_type"]%></b></td>
	<td>
		<asp:TextBox id="uploadType"
			Size=40
			runat="server"
			/>
		<asp:RequiredFieldValidator
			ControlToValidate="uploadType"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
	</td></tr>
	<tr><td><b><%=lang["upload_file_size"]%></b></td>
	<td>
		<asp:TextBox id="uploadSize"
			Size=6
			Style="text-align:right"
			runat="server"
			/> KBytes
		<asp:RequiredFieldValidator
			ControlToValidate="uploadSize"
			ErrorMessage="*"
			Display="Dynamic"
			runat=server/>
		<asp:RegularExpressionValidator
			ControlToValidate="uploadSize"
			ValidationExpression="\d+"
			ErrorMessage="*"
			runat=server/>
	</td></tr>
	<tr><td><b><%=lang["smtp_server"]%></b></td>
	<td>
		<asp:TextBox id="smtpServer"
			Columns=20
			runat="server"
			/>
			<%=lang["smtp_server_note"]%>
	</td></tr>
	<tr><td><b><%=lang["sql_connection_string"]%></b></td>
	<td>
		<asp:TextBox id="sqlConn"
			Columns=70
			runat="server"
			/>
	</td></tr>
	
	<tr>
	<td colspan=2 class="tdbg-dark" >
		&nbsp;
	</td>
	</tr>
	<tr class=tdbg><td valign=top><b><%=lang["site_ad"]%></b>
	</td>
	<td>
		<asp:TextBox id="headAd"
			TextMode="MultiLine"
			Columns=70
			Rows=4
			runat="server"
			/>
	</td></tr>
	<tr><td valign=top><b><%=lang["news_ad"]%></b>
	</td>
	<td>
		<asp:TextBox id="newsAd"
			Rows=4
			TextMode="multiLine"
			Columns=70
			runat="server"
			/>
	</td></tr>
	<tr><td valign=top><b><%=lang["site_footer"]%></b>
	</td>
	<td>
		<asp:TextBox id="footer"
			TextMode="MultiLine"
			Columns=70
			Rows=4
			runat="server"
			/>
	</td></tr>
	<tr><td colspan=2 align=center>
		<%
		submit.Text=lang["modify_text"].ToString();
		%>
		<asp:Button id="submit"
			Text="ÐÞ¸Ä"
			OnClick="setConst"
			runat="server"
			/>
	</td>
	</tr>
	<tr class=tdbg-dark><td colspan=2 height=40>
	¡¡¡¡<font color=red><%=lang["clear_cache_note"]%></font>
	<%
	ClearCache.Text=lang["clear_cache_text"].ToString();
	%>
	<asp:Button id="ClearCache" Text="Çå³ý»º´æ" OnClick="clearCache" runat="server" />
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
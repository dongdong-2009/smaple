<%@Page Language="C#" Inherits="Article.Admin.Left" %>
<html>
<head>
<meta http-equiv="Content-type" content="text/html;charset=<%=myConst.Charset%>">
<style type=text/css>
body  { background:#799AE1; margin:0px; font:normal 12px ËÎÌו; 
SCROLLBAR-FACE-COLOR: #799AE1; SCROLLBAR-HIGHLIGHT-COLOR: #799AE1; 
SCROLLBAR-SHADOW-COLOR: #799AE1; SCROLLBAR-DARKSHADOW-COLOR: #799AE1; 
SCROLLBAR-3DLIGHT-COLOR: #799AE1; SCROLLBAR-ARROW-COLOR: #FFFFFF;
SCROLLBAR-TRACK-COLOR: #AABFEC;
}
table  { border:0px; }
td  { font:normal 12px ; }
img  { vertical-align:bottom; border:0px; }
a  { font:normal 12px ; color:#215DC6; text-decoration:none; }
a:hover  { color:#428EFF }
.sec_menu  { border-left:1px solid white; border-right:1px solid white; border-bottom:1px solid white; background:#D6DFF7; padding:5px 2px;}
.menu_title  { }
.menu_title span  { position:relative; top:2px; left:8px; color:#215DC6; font-weight:bold; }
.menu_title2  { }
.menu_title2 span  { position:relative; top:2px; left:8px; color:#428EFF; font-weight:bold; }
</style>
<script language=javascript>
function menuChange(obj,menu)
{
	if(menu.style.display=="")
	{
		obj.background="pic/admin_title_bg_hide.gif";
		menu.style.display="none";
	}else{
		obj.background="pic/admin_title_bg_show.gif";
		menu.style.display="";
	}
}

function proLoadimg()
{
	var i=new Image;
	i.src='pic/admin_title_bg_hide.gif';
	i.src='pic/admin_title_bg_show.gif';
}
proLoadimg();
</script>
</head>
<body>
<table cellpadding=0 cellspacing=0 width=158 align=center>
  <tr>
    <td height=42 valign=bottom>
      <a href="admin_main.aspx" target="right"><img src=pic/admin_title.gif width=158 border=0 height=38></a>
    </td>
  </tr>
  <tr height=25><td background="pic/admin_title_bg_quit.gif">
  &nbsp; &nbsp;<a href=admin_login.aspx target=_top><b><%=lang["relogin"]%></b></a>&nbsp; <a href=admin_logout.aspx target=_top><b><%=lang["logout"]%></b></a>
  </td></tr>
</table>

&nbsp;

<table cellpadding=0 cellspacing=0 width=158 align=center>
  <tr style="cursor:hand;">
    <td height=25 class="menu_title" background="pic/admin_title_bg_show.gif" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu1);">
      <span><%=lang["title_admin_news"]%></span>
    </td>
  </tr>
  <tr>
    <td>
      <div class=sec_menu style="width:158px;" id=menu1>
        <table cellpadding=0 cellspacing=0 align=center width=140>
	<tr height=20><td>
	<% if (user.HavePower(user.Power,"addnews")){ %>
		<a href=admin_articleAdd.aspx target=right><%=lang["news_add"]%></a> | <a href=admin_article.aspx target=right><%=lang["news_modify_short"]%></a>
	<%}else{ %>
		<a href=admin_article.aspx target=right><%=lang["news_modify"]%></a>
	<%}%>
		| <a href=admin_check.aspx target=right><%=lang["news_check"]%></a>
	</td></tr>
	<% if (user.HavePower(user.Power,"remarks")) {%>
	<tr height=20><td>
		<a href=admin_remark.aspx target=right><%=lang["manage_remark"]%></a>
	<% if (user.Class==1){ %>
		| <a href=admin_move.aspx target=right><%=lang["news_move"]%></a>
	<%}%>
	</td></tr>
	<%}%>
	
	<% if (user.Class==1){ %>
	<tr height=20><td>
		<a href=admin_keyadd.aspx target=right><%=lang["key_add"]%></a> | <a href=admin_key.aspx target=right><%=lang["key_modify"]%></a>
	</td></tr>
	<%}%>
        </table>
      </div>
    </td>
  </tr>
</table>
&nbsp;

<% if (user.Class==1){ %>
<table cellpadding=0 cellspacing=0 width=158 align=center>
  <tr style="cursor:hand;">
    <td height=25 class="menu_title" background="pic/admin_title_bg_show.gif" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu2);">
      <span><%=lang["title_admin_class"]%></span>
    </td>
  </tr>
  <tr>
    <td>
      <div class=sec_menu style="width:158px;" id=menu2>
        <table cellpadding=0 cellspacing=0 align=center width=140>
	<tr height=20><td><a href=admin_classAdd.aspx target=right><%=lang["class_add"]%></a> | <a href=admin_class.aspx target=right><%=lang["class_modify"]%></a></td></tr>
	<tr height=20><td><a href=admin_TopicAdd.aspx target=right><%=lang["topic_add"]%></a> | <a href=admin_Topic.aspx target=right><%=lang["topic_modify"]%></a></td></tr>
        </table>
      </div>
    </td>
  </tr>
</table>
&nbsp;
<%}%>


<% if (user.Class==1){ %>
<table cellpadding=0 cellspacing=0 width=158 align=center>
  <tr style="cursor:hand;">
    <td height=25 class="menu_title" background="pic/admin_title_bg_show.gif" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu3);">
      <span><%=lang["title_admin_member"]%></span>
    </td>
  </tr>
  <tr>
    <td>
      <div class=sec_menu style="width:158px;" id=menu3>
        <table cellpadding=0 cellspacing=0 align=center width=140>
	<tr height=20><td><a href=admin_memberAdd.aspx target=right><%=lang["member_add"]%></a> | <a href=admin_member.aspx target=right><%=lang["member_modify"]%></a> | <a href=admin_member_check.aspx target=right><%=lang["member_check"]%></a></td></tr>
	<tr height=20><td><a href=admin_groupAdd.aspx target=right><%=lang["member_group_add"]%></a> | <a href=admin_group.aspx target=right><%=lang["member_group_modify"]%></a></td></tr>
        </table>
      </div>
    </td>
  </tr>
</table>
&nbsp;
<%}%>


<% if (user.Class==1){ %>
<table cellpadding=0 cellspacing=0 width=158 align=center>
  <tr style="cursor:hand;">
    <td height=25 class="menu_title" background="pic/admin_title_bg_show.gif" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu4);">
      <span><%=lang["title_admin_user"]%></span>
    </td>
  </tr>
  <tr>
    <td>
      <div class=sec_menu style="width:158px;" id=menu4>
        <table cellpadding=0 cellspacing=0 align=center width=140>
		<tr height=20><td><a href=admin_userAdd.aspx target=right><%=lang["user_add"]%></a> | <a href=admin_user.aspx target=right><%=lang["user_modify"]%></a></td></tr>
        </table>
      </div>
    </td>
  </tr>
</table>
&nbsp;
<%}%>



<% if (user.Class==1){ %>
<table cellpadding=0 cellspacing=0 width=158 align=center>
  <tr style="cursor:hand;">
    <td height=25 class="menu_title" background="pic/admin_title_bg_show.gif" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu5);">
      <span><%=lang["title_admin_system"]%></span>
    </td>
  </tr>
  <tr>
    <td>
      <div class=sec_menu style="width:158px;" id=menu5>
        <table cellpadding=0 cellspacing=0 align=center width=140>
	<tr height=20><td><a href=admin_config.aspx target=right><%=lang["system_modify"]%></a> | <a href=admin_backup.aspx target=right><%=lang["system_backup"]%></a> | <a href=admin_style.aspx target=right><%=lang["style_modify"]%></a></td></tr>
	<tr height=20><td><a href=admin_templateAdd.aspx target=right><%=lang["template_add"]%></a> | <a href=admin_template.aspx target=right><%=lang["template_modify"]%></a></td></tr>
	<tr height=20><td><a href=admin_resetNum.aspx target=right><%=lang["reset_num"]%></a> | <a href=admin_upfiles.aspx target=right><%=lang["manage_upload"]%></a></td></tr>
	<tr height=20><td><a href=admin_getJs.aspx target=right><%=lang["get_js"]%></a></td></tr>
        </table>
      </div>
    </td>
  </tr>
</table>
&nbsp;
<%}%>


<table cellpadding=0 cellspacing=0 width=158 align=center>
  <tr style="cursor:hand;">
    <td height=25 class="menu_title" background="pic/admin_title_bg_show.gif" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu6);">
      <span><%=lang["title_copyright"]%></span>
    </td>
  </tr>
  <tr>
    <td>
      <div class=sec_menu style="width:158px;" id=menu6>
        <table cellpadding=0 cellspacing=0 align=center width=140>
	<tr height=20><td>&nbsp;<%=lang["official_site"]%></td></tr>
	<tr height=20><td>&nbsp;<%=lang["author"]%></td></tr>
        </table>
      </div>
    </td>
  </tr>
</table>
<br><br>

</body>
</html>
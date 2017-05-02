<%@Page Language="C#" Inherits="Article.Admin.Top" %>
<html>
<head>
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=<%=myConst.Charset%>">
<style type="text/css">
a:link { color:#000000;text-decoration:none}
a:hover {color:#666666;}
a:visited {color:#000000;text-decoration:none}

td {FONT-SIZE: 9pt; FILTER: dropshadow(color=#FFFFFF,offx=1,offy=1); COLOR: #000000; }
img {filter:Alpha(opacity:100); chroma(color=#FFFFFF)}
</style>
<base target="right">
<script>
function preloadImg(src)
{
	var img=new Image();
	img.src=src
}
preloadImg("pic/admin_top_open.gif");

var displayBar=true;
function switchBar(obj)
{
	if (displayBar)
	{
		parent.frame.cols="0,*";
		displayBar=false;
		obj.src="pic/admin_top_open.gif";
		obj.title="<%=lang["open_left_menu"]%>";
	}else{
		parent.frame.cols="180,*";
		displayBar=true;
		obj.src="pic/admin_top_close.gif";
		obj.title="<%=lang["close_left_menu"]%>";
	}
}
</script>

<script language=vbscript>
Function URLEncoding(vstrIn)
    strReturn = ""
    For i = 1 To Len(vstrIn)
        ThisChr = Mid(vStrIn,i,1)
        If Abs(Asc(ThisChr)) < &HFF Then
            strReturn = strReturn & ThisChr
        Else
            innerCode = Asc(ThisChr)
            If innerCode < 0 Then
                innerCode = innerCode + &H10000
            End If
            Hight8 = (innerCode  And &HFF00)\ &HFF
            Low8 = innerCode And &HFF
            strReturn = strReturn & "%" & Hex(Hight8) &  "%" & Hex(Low8)
        End If
    Next
    URLEncoding = strReturn
End Function

Function bytes2BSTR(vIn)
    strReturn = ""
    For i = 1 To LenB(vIn)
        ThisCharCode = AscB(MidB(vIn,i,1))
        If ThisCharCode < &H80 Then
            strReturn = strReturn & Chr(ThisCharCode)
        Else
            NextCharCode = AscB(MidB(vIn,i+1,1))
            strReturn = strReturn & Chr(CLng(ThisCharCode) * &H100 + CInt(NextCharCode))
            i = i + 1
        End If
    Next
    bytes2BSTR = strReturn
End Function
</script>

<script language=javascript>
function getHttpPage(url)
{
	var oSend=new ActiveXObject("Microsoft.XMLHTTP");
	oSend.open("Get",url,false);
	oSend.send();
	if (oSend.readystate != 4)
		return "error";
	var body=bytes2BSTR(oSend.responseBody);
	delete(oSend);
	return body;
}
</script>


</head>

<body background="pic/admin_top_bg.gif" leftmargin="0" topmargin="0">
<table height="100%" width="95%" border=0 cellpadding=0 cellspacing=0>
<tr valign=middle>
	<td width=50>
	<img onclick="switchBar(this)" src="pic/admin_top_close.gif" title="<%=lang["close_left_menu"]%>" style="cursor:hand">
	</td>

	<td width=40>
		<img src="pic/admin_top_icon_1.gif">
	</td>
	<td width=100>
		<a href="admin_change.aspx"><%=lang["modify"]%></a>
	</td>
	<td width=40>
		<img src="pic/admin_top_icon_5.gif">
	</td>
	<td width=100>
		<a href="admin_sendmail.aspx"><%=lang["send_mail"]%></a>
	</td>
<!--
	<td width=40>
		<img src="pic/admin_top_icon_2.gif">
	</td>
	<td width=100>
		<a href="#">我的通讯录</a>
	</td>
	<td width=40>
		<img src="pic/admin_top_icon_3.gif">
	</td>
	<td width=100>
		<a href="#">我的备忘录</a>
	</td>
	<td width=40>
		<img src="pic/admin_top_icon_4.gif">
	</td>
	<td width=100>
		<a href="#">我的短信息</a>
	</td>
-->	
	<td align=right>
		&nbsp;
		<script language=javascript>
			var timer;
			var interval = 1200000;
			//interval = 10000;
			function f_get()
			{
				var d = new Date();
				d.setMinutes(d.getMinutes() + 25);
				var url = "admin_keep.aspx?expires=";
				url += d.getYear()+","+(d.getMonth()+1)+","+d.getDate()+","+d.getHours()+","+d.getMinutes();
				getHttpPage(url);
				//alert(url);
			}
			timer = setInterval("f_get();", interval, "JavaScript");
			
		</script>
		
		<script For=window EVENT=onunload>
			if (!isNaN(timer))
			{
				clearInterval(timer);
			}
		</script>
		
		<font face=arial>Version: 2.6</font>
	</td>
</tr>
</table>
</body>

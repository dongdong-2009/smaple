function doPrint()
{
	var adBegin="<!--DVNEWS_AD_BEGIN-->";
	var adEnd="<!--DVNEWS_AD_END-->";
	var body;
	var css;
	var str="<html>";
	str += "<head>";
	str += '<meta http-equiv="content-type" content="text/html; charset=gb2312">';
	str += '<title>'+document.title+'</title>';
	str += '<link rel="stylesheet" href="print.css" type="text/css">';
	str += "<body bgcolor=#ffffff topmargin=30 leftmargin=5 marginheight=50 marginwidth=5 onLoad='window.print();'>";
	str += document.all.printScript.innerHTML;
	str += "\n<script language=javascript>function doPrint(){window.print();}</script>";
	document.all.printHide.style.display='none';
	body= document.all.printBody.innerHTML;
	//去掉广告
	if (body.indexOf(adBegin)>=0)
	{
		str+=body.substr(0,body.indexOf(adBegin));
		str+=body.substr(body.indexOf(adEnd)+adEnd.length,body.length);
	}else{
		str+=body;
	}
	str += "</body></html>";
	document.write(str);
	document.close();
}

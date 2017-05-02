// ******************************默认设置定义******************************
// http://musicbbs.com.cn
var CnvssEr_TipsPop = null;
var CnvssEr_TipsoffsetX = 10; // 提示框位于鼠标左侧或者右侧的距离；3-12 合适
var CnvssEr_TipsoffsetY = 10; // 提示框位于鼠标下方的距离；3-12 合适
var CnvssEr_TipsPopbg = "#FFFFFF"; // 提示框背景色
var CnvssEr_TipsPopfg = "#003366"; // 提示框前景色
var CnvssEr_TipsAlpha = 86; // 提示框透明度，100为不透明
var CnvssEr_Tipsshadowcolor = "threedlightshadow"; // 提示框阴影颜色
var CnvssEr_Tipsshadowdirection = 135; // 提示框阴影方向
var CnvssEr_TipsTitlebg = "#AADFEA"; // 提示框标题文字背景
var CnvssEr_TipsTitlefg = "#FFFFFF"; // 提示框标题文字颜色
var CnvssEr_TipsBorderColor = "#3DC2C2"; // 提示框标题边框颜色
var CnvssEr_TipsBorder	= 1; // 提示框标题边框宽度
var CnvssEr_TipsBaseWidth = 165; // 提示框最小宽度 注意这个值最好不要小于提示框的象素宽度
var CnvssEr_TipsSmallTitle = "☆蓝星潮流娱乐社区☆";	// 提示框副标题文字
var CnvssEr_TipsTitle = "提示您"; 
var CnvssEr_TipsTitleCt = "--->";
var FormObj;
var UsedForm="none";
// ==================================================================================

document.write('<div id=CnvssEr_TipsLayer style="display: none;position: absolute; z-index:10001"></div>');

function CnvssEr_Tips(){
	var o=event.srcElement;
	if(o.alt==null && o.title==null){return false;}
        if(o.id!=null && o.id!=""){return false;}
	if(o.alt!=null && o.alt!=""){o.dypop=o.alt;o.alt=""};
	if(o.title!=null && o.title!=""){o.dypop=o.title;o.title=""};
	CnvssEr_TipsPop=o.dypop;
	if(CnvssEr_TipsPop!=null && CnvssEr_TipsPop!="" && typeof(CnvssEr_TipsPop)!="undefined"){
		CnvssEr_TipsLayer.style.left=-1000;
		CnvssEr_TipsLayer.style.display='';
		var Msg = CnvssEr_TipsPop.replace(/\n/g,"<br>"); // 换行符
		//Msg = Msg.replace(/\r/g,"<br>"); // 回车符
		if(CnvssEr_TipsSmallTitle==""){CnvssEr_TipsTitleCt="";}
		var attr=(document.location.toString().toLowerCase().indexOf("list.asp")>0?"nowrap":"");
		var content = '<table style="FILTER:alpha(opacity='+CnvssEr_TipsAlpha+') shadow(color='+CnvssEr_Tipsshadowcolor+',direction='+CnvssEr_Tipsshadowdirection+');" id=toolTipTalbe border=0><tr><td width="100%"><table border=0 cellspacing="'+CnvssEr_TipsBorder+'" cellpadding="2" style="width:100%;background-color:'+CnvssEr_TipsBorderColor+';">'+
		'<tr id=CnvssEr_TipsPoptop><th style="width:100%; color:'+CnvssEr_TipsTitlefg+'; background-color:'+CnvssEr_TipsTitlebg+';"><b><p id=topleft align=left>↖ '+CnvssEr_TipsSmallTitle+CnvssEr_TipsTitleCt+CnvssEr_TipsTitle+'</p><p id=topright align=right style="display:none">'+CnvssEr_TipsSmallTitle+CnvssEr_TipsTitleCt+CnvssEr_TipsTitle+' ↗</font></b></th></tr>'+
		'<tr><td '+attr+' style="width:100%; background-color:'+CnvssEr_TipsPopbg+'; color:'+CnvssEr_TipsPopfg+'; padding-left:10px; padding-right:10px; padding-top: 4px; padding-bottom:4px; line-height:135%;font-family: Verdana, Arial, Helvetica, sans-serif, "宋体";">'+Msg+'</td></tr>'+
		'<tr id=CnvssEr_TipsPopbot style="display:none"><th style="width:100%;color:'+CnvssEr_TipsTitlefg+';background-color:'+CnvssEr_TipsTitlebg+';"><b><p id=botleft align=left>↙ '+CnvssEr_TipsSmallTitle+CnvssEr_TipsTitleCt+CnvssEr_TipsTitle+'</p><p id=botright align=right style="display:none">'+CnvssEr_TipsSmallTitle+CnvssEr_TipsTitleCt+CnvssEr_TipsTitle+' ↘</font></b></th></tr>'+
		'</table></td></tr></table>';
		CnvssEr_TipsLayer.innerHTML = content;
		var toolTipwidth = Math.min(CnvssEr_TipsLayer.clientWidth, document.body.clientWidth/2.2);
		if(toolTipwidth<CnvssEr_TipsBaseWidth){toolTipwidth=CnvssEr_TipsBaseWidth;}
		toolTipTalbe.style.width=toolTipwidth;
		MoveToMouseLoc();
		return true;
	}else{
		CnvssEr_TipsLayer.innerHTML='';
		CnvssEr_TipsLayer.style.display='none';
		return true;
	}
}

function MoveToMouseLoc(){
	if(CnvssEr_TipsLayer.innerHTML==''){return true;}
	var MouseX=event.x;
	var MouseY=event.y;
	var popTopAdjust=0;
	//window.status="x:"+event.offsetX;
	//window.status+=" y:"+event.offsetY;
	var popHeight=CnvssEr_TipsLayer.clientHeight;
	var popWidth=CnvssEr_TipsLayer.clientWidth;
	if(MouseY+CnvssEr_TipsoffsetY+popHeight>document.body.clientHeight){
		popTopAdjust=-popHeight-CnvssEr_TipsoffsetY*1.5;
		CnvssEr_TipsPoptop.style.display="none";
		CnvssEr_TipsPopbot.style.display="";
	}else{
		popTopAdjust=0;
		CnvssEr_TipsPoptop.style.display="";
		CnvssEr_TipsPopbot.style.display="none";
	}
	if(MouseX+CnvssEr_TipsoffsetX+popWidth>document.body.clientWidth){
		popLeftAdjust=-popWidth-CnvssEr_TipsoffsetX*2;
		topleft.style.display="none";
		botleft.style.display="none";
		topright.style.display="";
		botright.style.display="";
	}else{
		popLeftAdjust=0;
		topleft.style.display="";
		botleft.style.display="";
		topright.style.display="none";
		botright.style.display="none";
	}
	CnvssEr_TipsLayer.style.left=MouseX+CnvssEr_TipsoffsetX+document.body.scrollLeft+popLeftAdjust;
	CnvssEr_TipsLayer.style.top=MouseY+CnvssEr_TipsoffsetY+document.body.scrollTop+popTopAdjust;
	return true;
}

document.onmousemove = CnvssEr_Tips;
var ethanExamTimer=function ()
{
	//图片路径
	this.numPicPath="timeNum/";
	//分隔图
	this.separtorPic="col.jpg";
	//警告图
	this.alertImg="alert.png";
	//警告闪动
	this.alertFlash=false;
	this.numberPic=new Array(10);
	//警告时间,默认5分钟
	this.alertTime=new Date(2008,07,15,00,05,00);
	//结束时间
	this.finishTime="00:00:00";
	this.timeout;
	//开始时间
	this.beginTime=new Date();
	//时钟长度
	this.clockLength=6;
	this.myClock=new Object();
	//输出对象
	this.outPutObject=document.body;
	//计时方向
	this.direction="asc";
	//跳转秒数
	this.vector=1;
	//已初始化
	this.isCreate=false;
}
//显示时钟time:开始时间 alertTime:警告时间 direct:计时方向 objName:目标对象
function showExamClock(time,alertTime,direct,flash,objName)
{
	if(!ethanExamTimer.isCreate)
	{
		/*var script=document.createElement('script');
		script.src="msgbox.js";
		script.type="text/javascript";
		script.language="javascript";
		script.charset="gb2312";
		document.getElementsByTagName('head')[0].appendChild(script);*/
		ethanExamTimer=new ethanExamTimer();
		ethanExamTimer.isCreate=true;
		//系统初始化
		ethanExamTimer.initExamClock(time,alertTime,direct,flash,objName);
	}
	else
	{
		ethanExamTimer.setAlertTime(alertTime);
		ethanExamTimer.setDirection(direct);
		ethanExamTimer.setAlertPicFlash(flash);
		ethanExamTimer.setClockTime(time);
	}
}
//初始化
ethanExamTimer.prototype.initExamClock=function (time,alertTime,direct,flash,objName)
{
	this.setAlertTime(alertTime);
	this.setDirection(direct);
	this.setAlertPicFlash(flash);
	this.setClockTime(time);
	var tmpStr=this.checkExamTime(time);
	if(tmpStr=="continue")//预装载图片
	{
		this.setupImage("");
	}else
	{
		this.separtorPic="n"+this.separtorPic;
		this.setupImage("n");
	}
	if(objName)
	this.outPutObject=document.getElementById(objName);
	var dvMain=document.createElement("div");
	dvMain.className="dvClock";
	this.configMyClock(dvMain);
	this.outPutObject.appendChild(dvMain);
	//附加到目标
	setInterval('ethanExamTimer.showSepartor()',550);
	if(tmpStr!="over")
	{
		this.updateExamClock();
	}
	else
	{
		displayMsgbox("考试结束!".fontcolor("red"));
	}
}
//配置时钟
ethanExamTimer.prototype.configMyClock=function (dvMain)
{
	this.myClock.digit=new Array(this.clockLength);
	//每一位置上的图
	this.myClock.separtor=new Array();
	//分附图
	this.myClock.curTime=new Array(this.clockLength);
	this.myClock.timeStr="";
	//时间戳
	this.myClock.alertPic=null;
	//警告图片对象
	this.myClock.alertFlag=false;
	//是否已警告
	for(i=0;i<this.clockLength;i++)
	{
		this.myClock.digit[i]=this.createNumImg(this.numberPic[0].src,dvMain);
		this.myClock.curTime[i]=0;
		this.myClock.timerStr+='0';
		if(i%2==1&&i!=(this.clockLength-1))
		{
			this.myClock.separtor[this.myClock.separtor.length]=this.createNumImg(this.numPicPath+this.separtorPic,dvMain);
		}
	}
}
//创建警告图片
ethanExamTimer.prototype.createAlertImg=function (dvObj)
{
	var image=dvObj.childNodes[0].appendChild(document.createElement("img"));
	image.className="alertPicture";
	image.alt="到达预警时间!";
	image.src=this.numPicPath+this.alertImg;
	return image;
}
//创建数字图片
ethanExamTimer.prototype.createNumImg=function (img,dvObj)
{
	var image=dvObj.appendChild(document.createElement("img"));
	image.className="numberPic";
	image.src=img;
	return image;
}
//更新时间
ethanExamTimer.prototype.updateClockTime=function ()
{
	var hour=this.beginTime.getHours();
	this.myClock.timeStr=((hour-(-100))+'').substring(1);
	this.myClock.timeStr+=((this.beginTime.getMinutes()-(-100))+'').substring(1);
	this.myClock.timeStr+=((this.beginTime.getSeconds()-(-100))+'').substring(1);
}
//重新绘制
ethanExamTimer.prototype.repaintClockTime=function ()
{
	for(i=0;i<this.clockLength;i++)
	{
		var num=parseInt(this.myClock.timeStr.substring(i,i+1));
		if(num!=this.myClock.curTime[i])
		{
			this.myClock.curTime[i]=num;
			this.myClock.digit[i].src=this.numberPic[num].src;
		}
	}
	var status=this.checkExamTime(this.myClock.timeStr);
	if(status!="continue")
	{
		if(this.myClock.timeStr=="000100")this.showMessage('000100');
		if(!this.myClock.alterFlag)
		{
			//只加载一次获告图片
			this.setupSepartorPic("n",true);
			this.setupImage("n");
			this.changeImage();
			this.myClock.alertPic=this.createAlertImg(this.outPutObject);
			this.showMessage(this.myClock.timeStr);
		}
		if(this.alertFlash)
		{
			if(this.myClock.alertPic.style.visibility=="visible")
			this.myClock.alertPic.style.visibility="hidden";
			else
			this.myClock.alertPic.style.visibility="visible";
		}
		else
		this.myClock.alertPic.style.visibility="visible";
	}
	else
	{
		if(this.myClock.alterFlag)
		{
			//只加载一次正常图片
			this.setupSepartorPic("",false);
			this.setupImage("");
			this.changeImage();
			this.outPutObject.children[0].removeChild(this.myClock.alertPic);
		}
	}
	if(status=="over")
	{
		window.clearTimeout(this.timeout);
		displayMsgbox("考试结束!".fontcolor("red"));
	}
	this.beginTime.setSeconds(this.beginTime.getSeconds()+this.vector);
}
//显示分隔图
ethanExamTimer.prototype.showSepartor=function ()
{
	for(i=0;i<this.myClock.separtor.length;i++)
	{
		if(this.myClock.separtor[i].style.visibility=="hidden")
		this.myClock.separtor[i].style.visibility="visible";
		else
		this.myClock.separtor[i].style.visibility="hidden";
	}
}
//更新时钟
ethanExamTimer.prototype.updateExamClock=function ()
{
	this.timeout=window.setTimeout('ethanExamTimer.updateExamClock()',980);
	this.updateClockTime();
	this.repaintClockTime();
}
//开始时间
ethanExamTimer.prototype.setClockTime=function (time)
{
	if(time)
	{
		var tmpTime=time.split(":");
		if(tmpTime.length>1)this.beginTime=new Date(2008,07,15,tmpTime[0],tmpTime[1],tmpTime[2]);
	}
	else
	{
		this.beginTime.setYear(2008);
		this.beginTime.setMonth(07);
		this.beginTime.setDate(15);
	}
}
//警告时间
ethanExamTimer.prototype.setAlertTime=function (time)
{
	var tmpTime;
	if(time)
	{
		tmpTime=time.split(":");
		this.alertTime=new Date(2008,07,15,tmpTime[0],tmpTime[1],tmpTime[2]);
	}
}
//计时方向
ethanExamTimer.prototype.setDirection=function (dire)
{
	if(dire)
	{
		this.direction=dire.toLowerCase();
		this.direction=="desc"?this.vector=-1:this.vector=1;
	}
}
//警告图标是否闪动
ethanExamTimer.prototype.setAlertPicFlash=function (flag)
{
	if(flag!=null)this.alertFlash=flag;
}
//检测时间
ethanExamTimer.prototype.checkExamTime=function (time)
{
	if(!time)time=this.beginTime.toLocaleTimeString();
	if(time.indexOf(":")<0)time=time.substr(0,2)+":"+time.substr(2,2)+":"+time.substr(4);
	//考试结束
	if(time==this.finishTime)
	{
		return "over";
	}
	var tmpTime=new Date(2008,07,15,time.substr(0,2),time.substr(3,2),time.substr(6));
	//到达警告时间
	if((tmpTime<=this.alertTime&&this.direction=="desc")||(tmpTime>=this.alertTime&&this.direction=="asc"))
	{
		return "alert";
	}
	return "continue";
}
//预加载图片
ethanExamTimer.prototype.setupImage=function (title)
{
	for(i=0;i<10;i++)
	{
		this.numberPic[i]=new Image();
		this.numberPic[i].src=this.numPicPath+title+i+'.jpg';
	}
}
//更改图片
ethanExamTimer.prototype.changeImage=function ()
{
	for(i=0;i<this.clockLength;i++)
	{
		var num=parseInt(this.myClock.timeStr.substring(i,i+1));
		this.myClock.digit[i].src=this.numberPic[num].src;
	}
}
//加载分隔图
ethanExamTimer.prototype.setupSepartorPic=function (title,flag)
{
	this.myClock.alterFlag=flag;
	for(i=0;i<this.myClock.separtor.length;i++)
	{
		this.myClock.separtor[i].src=this.numPicPath+title+'col.jpg';
	}
}
//显示消息
ethanExamTimer.prototype.showMessage=function (time)
{
	var hour,minute,seconds,message;
	hour=time.substr(0,2)*1;
	minute=time.substr(2,2)*1;
	seconds=time.substr(4)*1;
	hour>0?hour='<font class="time">'+hour+'</font>小时':hour='';
	seconds>0?seconds='<font class="time">'+seconds+'</font>秒':seconds='';
	minute>0?(minute='<font class="time">'+minute+'</font>'+(seconds>0?'分':'分钟')):minute='';
	message='距离考试考束还有'+hour+minute+seconds+'!';
	displayMsgbox(message);
}
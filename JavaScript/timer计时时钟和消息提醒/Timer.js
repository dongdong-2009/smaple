var ethanExamTimer=function ()
{
	//ͼƬ·��
	this.numPicPath="timeNum/";
	//�ָ�ͼ
	this.separtorPic="col.jpg";
	//����ͼ
	this.alertImg="alert.png";
	//��������
	this.alertFlash=false;
	this.numberPic=new Array(10);
	//����ʱ��,Ĭ��5����
	this.alertTime=new Date(2008,07,15,00,05,00);
	//����ʱ��
	this.finishTime="00:00:00";
	this.timeout;
	//��ʼʱ��
	this.beginTime=new Date();
	//ʱ�ӳ���
	this.clockLength=6;
	this.myClock=new Object();
	//�������
	this.outPutObject=document.body;
	//��ʱ����
	this.direction="asc";
	//��ת����
	this.vector=1;
	//�ѳ�ʼ��
	this.isCreate=false;
}
//��ʾʱ��time:��ʼʱ�� alertTime:����ʱ�� direct:��ʱ���� objName:Ŀ�����
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
		//ϵͳ��ʼ��
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
//��ʼ��
ethanExamTimer.prototype.initExamClock=function (time,alertTime,direct,flash,objName)
{
	this.setAlertTime(alertTime);
	this.setDirection(direct);
	this.setAlertPicFlash(flash);
	this.setClockTime(time);
	var tmpStr=this.checkExamTime(time);
	if(tmpStr=="continue")//Ԥװ��ͼƬ
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
	//���ӵ�Ŀ��
	setInterval('ethanExamTimer.showSepartor()',550);
	if(tmpStr!="over")
	{
		this.updateExamClock();
	}
	else
	{
		displayMsgbox("���Խ���!".fontcolor("red"));
	}
}
//����ʱ��
ethanExamTimer.prototype.configMyClock=function (dvMain)
{
	this.myClock.digit=new Array(this.clockLength);
	//ÿһλ���ϵ�ͼ
	this.myClock.separtor=new Array();
	//�ָ�ͼ
	this.myClock.curTime=new Array(this.clockLength);
	this.myClock.timeStr="";
	//ʱ���
	this.myClock.alertPic=null;
	//����ͼƬ����
	this.myClock.alertFlag=false;
	//�Ƿ��Ѿ���
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
//��������ͼƬ
ethanExamTimer.prototype.createAlertImg=function (dvObj)
{
	var image=dvObj.childNodes[0].appendChild(document.createElement("img"));
	image.className="alertPicture";
	image.alt="����Ԥ��ʱ��!";
	image.src=this.numPicPath+this.alertImg;
	return image;
}
//��������ͼƬ
ethanExamTimer.prototype.createNumImg=function (img,dvObj)
{
	var image=dvObj.appendChild(document.createElement("img"));
	image.className="numberPic";
	image.src=img;
	return image;
}
//����ʱ��
ethanExamTimer.prototype.updateClockTime=function ()
{
	var hour=this.beginTime.getHours();
	this.myClock.timeStr=((hour-(-100))+'').substring(1);
	this.myClock.timeStr+=((this.beginTime.getMinutes()-(-100))+'').substring(1);
	this.myClock.timeStr+=((this.beginTime.getSeconds()-(-100))+'').substring(1);
}
//���»���
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
			//ֻ����һ�λ��ͼƬ
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
			//ֻ����һ������ͼƬ
			this.setupSepartorPic("",false);
			this.setupImage("");
			this.changeImage();
			this.outPutObject.children[0].removeChild(this.myClock.alertPic);
		}
	}
	if(status=="over")
	{
		window.clearTimeout(this.timeout);
		displayMsgbox("���Խ���!".fontcolor("red"));
	}
	this.beginTime.setSeconds(this.beginTime.getSeconds()+this.vector);
}
//��ʾ�ָ�ͼ
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
//����ʱ��
ethanExamTimer.prototype.updateExamClock=function ()
{
	this.timeout=window.setTimeout('ethanExamTimer.updateExamClock()',980);
	this.updateClockTime();
	this.repaintClockTime();
}
//��ʼʱ��
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
//����ʱ��
ethanExamTimer.prototype.setAlertTime=function (time)
{
	var tmpTime;
	if(time)
	{
		tmpTime=time.split(":");
		this.alertTime=new Date(2008,07,15,tmpTime[0],tmpTime[1],tmpTime[2]);
	}
}
//��ʱ����
ethanExamTimer.prototype.setDirection=function (dire)
{
	if(dire)
	{
		this.direction=dire.toLowerCase();
		this.direction=="desc"?this.vector=-1:this.vector=1;
	}
}
//����ͼ���Ƿ�����
ethanExamTimer.prototype.setAlertPicFlash=function (flag)
{
	if(flag!=null)this.alertFlash=flag;
}
//���ʱ��
ethanExamTimer.prototype.checkExamTime=function (time)
{
	if(!time)time=this.beginTime.toLocaleTimeString();
	if(time.indexOf(":")<0)time=time.substr(0,2)+":"+time.substr(2,2)+":"+time.substr(4);
	//���Խ���
	if(time==this.finishTime)
	{
		return "over";
	}
	var tmpTime=new Date(2008,07,15,time.substr(0,2),time.substr(3,2),time.substr(6));
	//���ﾯ��ʱ��
	if((tmpTime<=this.alertTime&&this.direction=="desc")||(tmpTime>=this.alertTime&&this.direction=="asc"))
	{
		return "alert";
	}
	return "continue";
}
//Ԥ����ͼƬ
ethanExamTimer.prototype.setupImage=function (title)
{
	for(i=0;i<10;i++)
	{
		this.numberPic[i]=new Image();
		this.numberPic[i].src=this.numPicPath+title+i+'.jpg';
	}
}
//����ͼƬ
ethanExamTimer.prototype.changeImage=function ()
{
	for(i=0;i<this.clockLength;i++)
	{
		var num=parseInt(this.myClock.timeStr.substring(i,i+1));
		this.myClock.digit[i].src=this.numberPic[num].src;
	}
}
//���طָ�ͼ
ethanExamTimer.prototype.setupSepartorPic=function (title,flag)
{
	this.myClock.alterFlag=flag;
	for(i=0;i<this.myClock.separtor.length;i++)
	{
		this.myClock.separtor[i].src=this.numPicPath+title+'col.jpg';
	}
}
//��ʾ��Ϣ
ethanExamTimer.prototype.showMessage=function (time)
{
	var hour,minute,seconds,message;
	hour=time.substr(0,2)*1;
	minute=time.substr(2,2)*1;
	seconds=time.substr(4)*1;
	hour>0?hour='<font class="time">'+hour+'</font>Сʱ':hour='';
	seconds>0?seconds='<font class="time">'+seconds+'</font>��':seconds='';
	minute>0?(minute='<font class="time">'+minute+'</font>'+(seconds>0?'��':'����')):minute='';
	message='���뿼�Կ�������'+hour+minute+seconds+'!';
	displayMsgbox(message);
}
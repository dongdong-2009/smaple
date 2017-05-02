/****************************************
 * 周铭
 * 最后修改日期:2007-06-29
 * tool.js * 
 ****************************************/
 
//trim方法
String.prototype.Trim = function()
		{
			return this.replace(/(^\s*)|(\s*$)/g, "");
		}
		
//文本框非空
function nonEmpty(id,msg)
{
    var ctrl = document.getElementById(id);
    if(ctrl.value.Trim() == "")
    {
        alert(msg + '不能为空');
        //ctrl.focus();
        return true;
    }            
}

//是否含有非法字符 '
function invalidateChar(id,msg)
{
    var ctrl = document.getElementById(id);
    var s = ctrl.value;
    if(s.indexOf('\'') != -1)
    {
        alert(msg + '含有非法字符 \'');
        ctrl.focus();
        return true;
    }    
}

function selectDate(id)
{
    window.open("calendarCtrl.aspx?"+id,'','height=250,width=180,top=160,left=300,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no'); 
}

function pressEnter(id)
{
    if(event.keyCode == 13)
    {
        ctrl = document.getElementById(id);
        ctrl.click();
    }
}

//窗口最大化
function openMaxWindow(){
	
		window.moveTo(0,0);
	window.resizeTo(window.screen.availWidth,window.screen.availHeight);
}

//获得当前日期
function CurrentDate()
{
    var year = new Date();
    var _year = year.getFullYear();
    
    var month = new Date();
    var _month = (month.getMonth()+1<10)?("0"+(month.getMonth()+1)):(month.getMonth()+1);
    
    var day = new Date();
    var _day = (day.getDate()<10)?("0"+day.getDate()):day.getDate();
    
    var currenDate = _year+"-"+_month+"-"+_day;
    return currenDate;
} 

//获得当前时间
function CurrentDateTime()
{
    var year = new Date();
    var _year = year.getFullYear();
    
    var month = new Date();
    var _month = (month.getMonth()+1<10)?("0"+(month.getMonth()+1)):(month.getMonth()+1);
    
    var day = new Date();
    var _day = (day.getDate()<10)?("0"+day.getDate()):day.getDate();
    
    var hour = new Date();
    _hour = (hour.getHours() <10)?("0"+hour.getHours()):hour.getHours();
    
    var min = new Date();
    _min = (min.getMinutes() <10)?("0"+min.getMinutes()):min.getMinutes();
    
    var currentDateTime = _year+"-"+_month+"-"+_day+" "+_hour+":"+_min;        
    return currentDateTime;
} 

//findControl
function $f(id)
{
    var ctrl = document.getElementById(id);
    if(ctrl == null)
    {
        alert('控件'+id+'不存在!');
        return 
    }
    return ctrl;
}

//hour_diff 相差多少小时
function hour_diff(date1,date2)
{
    date1 = date1.replace(/-/g,'/');
    date2 = date2.replace(/-/g,'/');
    var startDate= new Date(date1); 
    var endDate= new Date(date2);
    var df=(startDate.getTime()-endDate.getTime())/3600/1000; 
    //return Math.abs(df);
    return df;
}




/*--------没有进行数据有效性校验-------*/
//判断年份是否是闰年
function isLeapYear(year){
    
    if(year%400==0){
        return false;    
    }else if(year%4==0){
        return true;
    }else{
        return false;
    }
}

//计算两个日期的差值
function compareDate(date1,date2)
{
    var regexp=/^(\d{1,4})[-|\.]{1}(\d{1,2})[-|\.]{1}(\d{1,2})$/;
    var monthDays=[0,3,0,1,0,1,0,0,1,0,0,1];
    regexp.test(date1);
    var date1Year=RegExp.$1;
    var date1Month=RegExp.$2;
    var date1Day=RegExp.$3;

    regexp.test(date2);
    var date2Year=RegExp.$1;
    var date2Month=RegExp.$2;
    var date2Day=RegExp.$3;

    firstDate=new Date(date1Year,date1Month,date1Day);
    secondDate=new Date(date2Year,date2Month,date2Day);

    result=Math.floor((secondDate.getTime()-firstDate.getTime())/(1000*3600*24));
    for(j=date1Year;j<=date2Year;j++){
        if(isLeapYear(j)){
            monthDays[1]=2;
        }else{
            monthDays[1]=3;
        }
        for(i=date1Month-1;i<date2Month;i++){
            result=result-monthDays[i];
        }
    }
    return result;
}

//计算日期加上天数后的日期
function addDays(date1,days){
    var monthDays=[0,3,0,1,0,1,0,0,1,0,0,1];
    var regexp=/^(\d{1,4})[-|\.]{1}(\d{1,2})[-|\.]{1}(\d{1,2})$/;
    regexp.test(date1);
    var date1Year=RegExp.$1;
    var date1Month=RegExp.$2;
    var date1Day=RegExp.$3;
    firstDate=new Date(date1Year,date1Month,date1Day);
    firstDate.setTime(firstDate.getTime()+days*1000*3600*24);
    var diff=0;
    for(j=date1Year;j<=firstDate.getYear();j++){
        if(isLeapYear(j)){
            monthDays[1]=2;
        }else{
            monthDays[1]=3;
        }
        for(i=date1Month-1;i<firstDate.getMonth()-1;i++){
            diff=diff+monthDays[i];
        }
    }
    result=firstDate.getYear()+"-"+firstDate.getMonth()+"-"+firstDate.getDate();
    if(diff!=0){
        result=addDays(result,diff);
    }
    return result;    
}

//获取光标在TextBox中的位置
function ShowCursorPos(el)//el TextBox控件
{  
  if (el.createTextRange)
  {
    var v = el.value;  
    var r = el.createTextRange();
	var s=document.selection.createRange();
	s.setEndPoint("StartToStart",el.createTextRange());
	return (s.text.length+1);
  } 
}

function HttpQueryStringBuilder()
{
    //Holds the Url
    this.Url = '';    
    //Holds the Array of Key Value Pairs
    this.Pairs = new Array();    
    //The method for getting the final query string
    HttpQueryStringBuilder.prototype.GetFullString = function()
    {
        var queryString = (this.Url.length > 0) ? this.Url + "?" : '';
        for(var key in this.Pairs)
        {
            queryString += escape(key) + "=" + escape(this.Pairs[key]) + "&";
        }
        return queryString.substring(0, queryString.length - 1);
    }
}

//通过参数名获得当前页面的参数值
function GetArgs(parmName)
{
    var url = window.location.href;
    var argIndex = url.indexOf('?');
    var arg = url.substring(argIndex+1);
    var args = arg.split('&');
    var argValue ='null';
    for(var i = 0; i < args.length; i++)
    {
        var str = args[i];
        var temp = str.split('=');
        if(temp.length <=1)
        {
            continue;
        }
        else
        {
            if(temp[0] == parmName)
            {
                return temp[1];
            }
        }
    }
    return argValue;
}


function Test()
{
    //Define the Object
    var builder = new HttpQueryStringBuilder();
    
    //Supply values
    builder.Url = "http://www.google.com"
    //Pairs[Key] = value (Dont worry about url encoding, it will be handled automatically)
    builder.Pairs["FirstName"] = "aaa";
    builder.Pairs["LastName"] = "ccc";
    
    //Done with insertions! show it! 
    alert(builder.GetFullString());    
    
    //Make some changes
    builder.Pairs["FirstName"] = "bbb";
    builder.Pairs["LastName"] = "ddd";
    
    alert(unescape(builder.Pairs["FirstName"]));
    //Done with modifications! show it again! 
    alert(builder.GetFullString());    
}

//获取调用JS链接所带的参数
//<script id="s" type="text/jscript" src="aa.js?id=1&name=doll.net"></script>
function getJsParam(paramName)   
{   
    var reg = new RegExp("(^|\\?|&)"+ paramName+"=([^&]*)(\\s|&|$)", "i");
  
    if (reg.test(s.src)) //s 为<script>id
    {
        return RegExp.$2; 
    }
    else
    {
        return ""; 
    }
}
//alert(getJsParam('name'));


//给一个事件添加多个方法
function addLoadEvent(func)
{
    var oldOnLoad = window.onload; //此处可改为其他事件
    if(typeof window.onload != 'function')
    {
        window.onload = func;
    }
    else
    {
        window.onload = function()
        {
            oldOnLoad();
            func();
        }
    }
}
//调用：addLoadEvent(firstFunc); addLoadEvent(secondFunc);对事件添加多个方法


function insertAfter(newElement,targetElement)
{
    var parent = targetElement.parentNode;
    if(parent.lastChild == targetElement)
    {
        parent.appendChild(newElement);
    }
    else
    {
        parent.insertBefore(newElement,targetElement.nextSibling);
    }   
}


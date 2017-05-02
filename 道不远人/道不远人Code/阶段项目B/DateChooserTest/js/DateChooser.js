//构造函数，参数列表：日期控件对象(DOM的ID)，对象名，
//日期格式，最小日期，最大日期，显示时效果，隐藏时效果
function DateChooser(elementID,name,dateFormat,minDate,maxDate,fxShow,fxHide){
    this._elementID = elementID;
    if(!dateFormat || dateFormat.trim() == '')
        this._dateFormat = 'd';
    else
        this._dateFormat = dateFormat;          
    this._name = name;
    this._txtrng;
    this._intervalSpeed = 500;
    if(minDate) 
        this._minDate = Date.parseLocale(minDate,this._dateFormat);
    if(maxDate)
        this._maxDate = Date.parseLocale(maxDate,this._dateFormat);
    this._fxShow = fxShow;
    if(!this._fxShow)
        this._fxShow = 'show()';
    this._fxHide = fxHide;
    if(!this._fxHide)
        this._fxHide = 'hide()';
}
//初始化控件
DateChooser.prototype.initiate = function(){
    this._initiateComponents();
    this.hidePanel();
}
//一天在Date变量中的大小
DateChooser.TICKETOFDAY = 86400000;
//初始化本地化信息
DateChooser.cultureInfo = eval("("+__cultureInfo+")");
DateChooser.monthSrc = 'images/month.png';
DateChooser.prevHotSrc = 'images/bPrev-hot.png';
DateChooser.prevSrc = 'images/bPrev.png';
DateChooser.prevDownSrc = 'images/bPrev-down.png';
DateChooser.nextHotSrc = 'images/bNext-hot.png';
DateChooser.nextSrc = 'images/bNext.png';
DateChooser.nextDownSrc = 'images/bNext-down.png';
DateChooser.dropDownSrc = 'images/edit_0.gif';
DateChooser.addSrc = 'images/edit_1.gif';
DateChooser.reduceSrc = 'images/edit_2.gif';
DateChooser._shownChooser;
DateChooser._zIndex = 999;

DateChooser.prototype._initiateComponents = function (){
    this._element = $get(this._elementID);
    this._input = $('.calendarInput',this._element).get(0);
    this._synchronizeFromInput();
    //初始化各按钮
    $('.calendarDropDownButton',this._element).attr('href',
        String.format('javascript:{0}.togglePanel();',this._name));
    $('.calendarDropDownButton > img',this._element).attr('src',DateChooser.dropDownSrc);
    $('.calendarAddButton',this._element).attr('href',
        String.format('javascript:{0}.setPart(1);',this._name));
    $('.calendarAddButton > img',this._element).attr('src',DateChooser.addSrc);
      $('.calendarReduceButton',this._element).attr('href',
        String.format('javascript:{0}.setPart(-1);',this._name));
    $('.calendarReduceButton > img',this._element).attr('src',DateChooser.reduceSrc);
    //初始化各按钮的交互效果
    $(".calendarPrev > img",this._element)
     .mouseover(function(){this.src = DateChooser.prevHotSrc;})
     .mouseout(function(){this.src = DateChooser.prevSrc;})
     .mousedown(function(){this.src = DateChooser.prevDownSrc;})
     .mouseup(function(){this.src = DateChooser.prevHotSrc;});
     $(".calendarNext > img",this._element)
     .mouseover(function(){this.src = DateChooser.nextHotSrc;})
     .mouseout(function(){this.src = DateChooser.nextSrc;})
     .mousedown(function(){this.src = DateChooser.nextDownSrc;})
     .mouseup(function(){this.src = DateChooser.nextHotSrc;});
     $(".calendarMonthHearder th",this._element).each(function(i){
        $(this).html(DateChooser.cultureInfo.dateTimeFormat.ShortestDayNames[i]);
     });   
     //初始化年视图
     var tbody = $(".calendarYearTable > tbody",this._element)[0];
     var fragment = document.createDocumentFragment(); 
     for(var i = 0 ; i < 3; i++){
        var tr = document.createElement("TR");
        $(fragment).append(tr);
        for(var i2 = 0 ; i2 < 4; i2++){
            var td = document.createElement("TD");
            $(tr).append(td);
            var month = i*4 + i2 + 1;
            $(td).append(String.format("<a href='javascript:{0}.set_month({1});'><img src='{2}'/><br />{3}</a>",this._name,month,DateChooser.monthSrc,DateChooser.cultureInfo.dateTimeFormat.MonthNames[month-1].substring(0,2)));
        }
     }
     $(tbody).append(fragment); 
     
    //利用Function.createDelegate()创建委托的好处于，事件触发时，
    //响应函数的执行上下文(this)不会被替换成事件源控件或window对象
    //点击控件之外时，关闭选择面板     
    this._bodyClickHandler = Function.createDelegate(this,this._bodyOnClick);
    $addHandler(document.body,'click',this._bodyClickHandler); 
    this._elementClickHandler = Function.createDelegate(this,this._elementOnClick);
    $addHandler(this._element,'click',this._elementClickHandler);  
    this._inputClickHandler = Function.createDelegate(this,this._inputOnClick);
    $addHandler(this._input,'click',this._inputClickHandler);
    $addHandler(this._input,'focus',this._inputClickHandler); 
    this._inputKeyUpHandler = Function.createDelegate(this,this._inputOnKeyUp);
    $addHandler(this._input,'keyup',this._inputKeyUpHandler);
    
    //如果不支持TextRange，如FireFox，则可以按下按钮后，以加速度递增或递减日期
    if(!document.selection || !document.selection.createRange){
        this._setIntervalAddHandler = Function.createDelegate(this,this.setIntervalAdd); 
        this._setIntervalReduceHandler = Function.createDelegate(this,this.setIntervalReduce); 
        $addHandler($(".calendarAddButton",this._element).get(0),'mousedown',this._setIntervalAddHandler); 
        $addHandler($(".calendarReduceButton",this._element).get(0),'mousedown',this._setIntervalReduceHandler);
        this._clearIntervalHandler = Function.createDelegate(this,this.clearIntervalPart); 
        $addHandler($(".calendarAddButton",this._element).get(0),'mouseup',this._clearIntervalHandler); 
        $addHandler($(".calendarReduceButton",this._element).get(0),'mouseup',this._clearIntervalHandler);
        $addHandler($(".calendarAddButton",this._element).get(0),'mouseout',this._clearIntervalHandler); 
        $addHandler($(".calendarReduceButton",this._element).get(0),'mouseout',this._clearIntervalHandler);
    }
    //初始化月视图
    this._showMonthView();    
}
//接收用户的输入，对于错误的输入显示警示色，并自动恢复
//不管是更正错误的输入，还是分析正确的输入，
//为了不干扰用户的输入，都必须输入完成后过段时间再执行
//注意延时的实现方法
DateChooser.prototype._inputOnKeyUp = function(){
    var date = this._validate(this._input.value);
    if(this._correctError){
        window.clearTimeout(this._correctError);
        this._correctError = null;
    }
    var obj = this;
    if(date){
        $(this._input).removeClass('calendarError');
        this._correctError = window.setTimeout(function(){
            obj._input.value = date.localeFormat(obj._dateFormat);
            obj._synchronizeFromInput();
        },1000);
    }    
    else{
        $(this._input).addClass('calendarError');
        this._correctError = window.setTimeout(function(){
            obj._synchronizeToInput();
            $(obj._input).removeClass('calendarError');
        },1200);
    }
}

DateChooser.prototype._bodyOnClick = function(e){
    if(DateChooser._shownChooser){
        DateChooser._shownChooser.hidePanel();
        DateChooser._shownChooser = null;
    }
}
//控件里的事件不会冒泡到body对象导致_bodyOnClick的执行
DateChooser.prototype._elementOnClick = function(e){
    if(e && e.stopPropagation)
        e.stopPropagation();
}
DateChooser.prototype._inputOnClick = function(e){
    //如果是IE，则支持自动选择日期部分
    if(document.selection && document.selection.createRange){
        this._txtrng = document.selection.createRange();
        if(!this._txtrng.expand('word')){
            this._txtrng.expand('word');
        }
        if(!/\d+/.test(this._txtrng.text)){
            this._txtrng.moveEnd('word',-1);
            this._txtrng.moveStart('word',-1);
        }
        this._txtrng.select();
    }
    if(e && e.stopPropagation)
        e.stopPropagation();
}


DateChooser.prototype.showPanel = function(){
    //关闭其它正在显示的日期面板
    if(DateChooser._shownChooser && DateChooser._shownChooser != this){
        DateChooser._shownChooser.hidePanel();
    }
    DateChooser._shownChooser = this;
    var location = Sys.UI.DomElement.getLocation($('.calendarDropDownButton',this._element).get(0));
    location.y += Sys.UI.DomElement.getBounds(this._input).height;
    Sys.UI.DomElement.setLocation($('.calendarView',this._element).get(0),location.x,location.y);
    //最后弹的日期面板在最上面
    DateChooser._zIndex ++;
    $('.calendarView',this._element).css('zIndex',DateChooser._zIndex);
    eval("$('.calendarView',this._element)."+this._fxShow);
}
DateChooser.prototype.hidePanel = function(){
    eval("$('.calendarView',this._element)."+this._fxHide); 
    DateChooser._shownChooser = null;  
}
DateChooser.prototype.togglePanel = function(){
    if(this != DateChooser._shownChooser)
        this.showPanel();
    else
        this.hidePanel();
}
//返回一个月内的日期数组，包括首尾填补的其它月日期
DateChooser.prototype.MonthCalendar = function (year,month){
    var firstDay = new Date(year,month-1,1);
    var lastDay = new Date(year,month,1);
    var dayOfFirstDay = firstDay.getDay();
    firstDay = new Date(firstDay * 1 - (DateChooser.TICKETOFDAY * dayOfFirstDay)); 
    var dayOfMonth = new Array();
    for(var i = 0 ; firstDay < lastDay || i % 7;i++){
        dayOfMonth.push(firstDay);
        firstDay = new Date(firstDay * 1 + DateChooser.TICKETOFDAY );
    }
    return dayOfMonth;
}
DateChooser.prototype._showMonthView = function (){
    //将导航条放到月视图中
    $(".calendarNavigator",this._element).prependTo($(".calendarMonthView",this._element));
    //允许上一月按钮
    var prevMonth = new Date(new Date(this._showDate.getFullYear(),this._showDate.getMonth(),1) * 1 - DateChooser.TICKETOFDAY);
    if(this._validateRange(prevMonth)){
        $(".calendarPrev > img",this._element).attr("alt",this._showDate.getMonth());
        $(".calendarPrev",this._element).removeAttr("disabled")
            .attr("href",String.format('javascript:{0}.addMonth(-1);',this._name));
    }
    else{
        $(".calendarPrev",this._element).attr("disabled",'disabled')
            .attr("href",'javascript:foo();');
    }
    //允许下一月按钮
    var nextMonth = new Date(this._showDate.getFullYear(),this._showDate.getMonth() + 1,1);
    if(this._validateRange(nextMonth)){
        $(".calendarNext > img",this._element).attr("alt",this._showDate.getMonth()+2);
        $(".calendarNext",this._element).removeAttr("disabled")
            .attr('href',String.format('javascript:{0}.addMonth(1);',this._name));
    }
    else{
        $(".calendarNext",this._element).attr("disabled",'disabled')
            .attr("href",'javascript:foo();');
    }
    $('.calendarMonthView').show();
    $('.calendarYearView').hide();
    $(".calendarTitle",this._element).html(this._showDate.localeFormat('yyyy MM'))
        .attr("href",String.format('javascript:{0}._showYearView();',this._name));
    //填充月视图内容
    this._showMonthDay();
}
DateChooser.prototype._showYearView = function(){
    //将导航条加入年视图
    $(".calendarNavigator",this._element).prependTo($(".calendarYearView",this._element));
    //允许前一年
    var prevYear = new Date(this._showDate.getFullYear()-1,11,31);
    if(this._validateRange(prevYear)){        
        $(".calendarPrev > img",this._element).attr("alt",this._showDate.getFullYear()-1);
        $(".calendarPrev",this._element).removeAttr("disabled")
            .attr("href",String.format('javascript:{0}.addYear(-1);',this._name));
    }
    else{
        $(".calendarPrev",this._element).attr("disabled",'disabled')
            .attr("href",'javascript:foo();');
    }
    //允许后一年
    var nextYear = new Date(this._showDate.getFullYear()+1,0,1);
    if(this._validateRange(nextYear)){
        $(".calendarNext > img",this._element).attr("alt",this._showDate.getFullYear()+1);
        $(".calendarNext",this._element).removeAttr("disabled")
            .attr('href',String.format('javascript:{0}.addYear(1);',this._name));
    }
    else{
        $(".calendarNext",this._element).attr("disabled",'disabled')
            .attr("href",'javascript:foo();');
    }
    $('.calendarMonthView').hide();
    $('.calendarYearView').show();
    $(".calendarTitle",this._element).html(this._showDate.localeFormat('yyyy'))
        .attr("href",'javascript:foo();');
    var obj = this;
    //每个月是不是在可选范围之类
    $('.calendarYearTable a').each(function(i){
        var monthFirstDate = new Date(obj._showDate.getFullYear(),i,1);
        var monthLastDate = new Date(new Date(obj._showDate.getFullYear(),i+1,1)*1 - DateChooser.TICKETOFDAY); 
        var isValid = false;
        if(obj._validateRange(monthFirstDate)){
            isValid = true;
        }
        if(obj._validateRange(monthLastDate)){
            isValid = true;
        }
        if(!isValid){
            $(this).attr('href','javascript:foo();')
                .attr('disabled','disabled').addClass('calendarInvalid');
        }
        else{
            $(this).attr('href',String.format("javascript:{0}.set_month({1});",obj._name,i+1))
                .removeAttr('disabled').removeClass('calendarInvalid');
        }
    });
    
}
//填充月视图内容
DateChooser.prototype._showMonthDay = function (){
    var today = this._showDate;
    var year = today.getFullYear();
    var month = today.getMonth() + 1;
    var daysOfMonth = this.MonthCalendar(year,month);
    var tbody = $(".calendarMonthDay",this._element)[0];
    while(tbody.rows.length > 0){
        tbody.deleteRow(tbody.rows[0]);
    }
    var fragment = document.createDocumentFragment();
    var tr;
    for(var i = 0 ; i < daysOfMonth.length ; i++){
        var day = daysOfMonth[i];
        //是否在可选范围之类
        var isValid = this._validateRange(day) != null;
        var sunday = !(i % 7);
        if(sunday){
            tr = document.createElement("TR");
            $(fragment).append(tr);
        }
        var td = document.createElement("TD");
        td.className = sunday?'calendarSunday':'calendarDay';
        if(i%7==6)td.className = 'calendarSaturday';
        $(tr).append(td);
        if(!isValid){
            $(td).attr('disabled','disabled')
                .html(day.getDate()).addClass('calendarInvalid');
        }
        else{
            var a = document.createElement("A");
            //block便于样式的设置
            a.style.display = 'block';
            a.href = String.format('javascript:{0}.selectDate(new Date({1}));',this._name,day * 1);
            $(a).html(day.getDate());
            $(td).append(a);
            if(this._currentDate.getMonth() == day.getMonth() && this._currentDate.getDate() == day.getDate()){
                $(td).addClass('calendarToday');
            }
            else if(today.getMonth() != day.getMonth()){
                $(td).addClass('calendarOtherMonth');
            }
        }
    }
    $(tbody).append(fragment);
}
DateChooser.prototype._validateRange = function(date){
    if(this._minDate){
        if(date < this._minDate){
            return null;
        }
    }
    if(this._maxDate){
        if(date > this._maxDate){
            return null;
        }
    }
    return date;
}
DateChooser.prototype._validate = function(strDate){
    var date;
    try{
        date = Date.parseLocale(strDate,this._dateFormat);
        if(date == null || date.toString() == 'NaN'){
            return null;
        }
        date = this._validateRange(date);
    }
    catch(e){
    }
    return date;
}
//同步输入框中的日期到选择面板
DateChooser.prototype._synchronizeFromInput = function(){
    var value = this._validate(this._input.value);
    if(!value){
        value = new Date();
        if(this._minDate && value < this._minDate){
            value = this._minDate;
        }
        if(this._maxDate && value > this._maxDate){
            value = this._maxDate;
        }
    }
    this._currentDate = value;  
    this._showDate = value; 
    this._showMonthView();
}
//同步选择的日期到输入框
DateChooser.prototype._synchronizeToInput = function(){
    $(this._input).val(new Date(this._currentDate).localeFormat(this._dateFormat));
}
DateChooser.prototype.setIntervalAdd = function(){
    this.setIntervalPart(1);
}
DateChooser.prototype.setIntervalReduce = function(i){
    this.setIntervalPart(-1);
}
//按住按钮时以加速度变动值，仅非IE使用
DateChooser.prototype.setIntervalPart = function(i){
    var obj = this;
    if(this._interval){
        window.clearInterval(this._interval);
        this._interval = null;
    }
    this._interval = window.setInterval(function(){
        obj.setIntervalPart.call(obj,i);
        obj.setPart(i);
    },this._intervalSpeed);
    if(this._intervalSpeed > 50)
        this._intervalSpeed -= 150;
}
DateChooser.prototype.clearIntervalPart = function(i){
    if(this._interval){
        window.clearInterval(this._interval);
        this._interval = null;
        this._intervalSpeed = 500;
    }
}
//设置日期某部分的值，仅IE使用
DateChooser.prototype.setPart = function(i){
    if(this._txtrng != null && this._txtrng.text.length <5 && this._txtrng.text.length>0){
        if(/(\d+)/.test(this._txtrng.text)){
            var value = parseInt(RegExp.$1);
            value += i;
            this._txtrng.text = value;
        }
        this._txtrng.select();
        this._inputOnKeyUp();
    }
    else{
        this.set_currentDate(new Date(DateChooser.TICKETOFDAY * i + this.get_currentDate() * 1));
    }
}
DateChooser.prototype._correctSetDate = function(i,date){    
    if(!this._validateRange(date)){
        if(i>0){
            date = this._maxDate;
        }
        else{
            date = this._minDate;
        }
    }
    return date;
}
DateChooser.prototype.set_month = function(i){
    var date = new Date(this._showDate.getFullYear(),i-1,this._showDate.getDate());
    date = this._correctSetDate(i,date);
    this._showDate = date;
    this._showMonthView();
}
DateChooser.prototype.addMonth = function(i){
    var date = new Date(this._showDate.getFullYear(),this._showDate.getMonth() + i,this._showDate.getDate());
    date = this._correctSetDate(i,date);
    this._showDate = date;
    this._showMonthView();
}

DateChooser.prototype.addYear = function(i){
    var date = new Date(this._showDate.getFullYear()+ i,this._showDate.getMonth() ,this._showDate.getDate());
    date = this._correctSetDate(i,date);
    this._showDate = date;
    this._showYearView();
}
DateChooser.prototype.selectDate = function(date){
    this.set_currentDate(date);
    this.hidePanel();
}
DateChooser.prototype.get_currentDate = function(){
    return this._currentDate;
}
DateChooser.prototype.set_currentDate = function(date){
    if(this._validateRange(date)){
        this._currentDate = date;
        this._showDate = date;
        this._showMonthView();
        this._synchronizeToInput();
    }
}
//不做任何动作，用于无效按钮
function foo(){
}
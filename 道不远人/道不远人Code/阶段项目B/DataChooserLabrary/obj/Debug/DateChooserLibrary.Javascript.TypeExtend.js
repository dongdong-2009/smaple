String.prototype.formatParse = function(formatString){
    /// <param name="formatString" type="String">解析日期字符时使用的格式字符串</param>
    /// <returns type="Date">分析出的日期</returns>
    formatString = formatString._localeDateFormat();
    var regDate = /\d+/g;
    var regFormat = /[YyMmdHhSs]+/g;
    var dateMatches = this.match(regDate);
    if(dateMatches == null)
        return null;
    var formatmatches = formatString.match(regFormat);
    if(dateMatches.length <3){
        return null;
    }
    var date = new Date();
    for(var i=0;i<dateMatches.length;i++){
        switch(formatmatches[i].substring(0,1)){
            case 'Y':case 'y':date.setFullYear(parseInt(dateMatches[i]));break;
            case 'M':date.setMonth(parseInt(dateMatches[i])-1);break;
            case 'd':date.setDate(parseInt(dateMatches[i]));break;
            case 'H':case 'h':date.setHours(parseInt(dateMatches[i]));break;
            case 'm':date.setMinutes(parseInt(dateMatches[i]));break;
            case 's':date.setSeconds(parseInt(dateMatches[i]));break;
        }
    }
    return date;
}

String.prototype._localeDateFormat = function(){
    var value = this;
    if(value == 'd'){
        value = 'yyyy/MM/dd';
    }
    else if(value == 'D'){
        value = 'yyyy年MM月dd日';
    }
    return value;
}

String.format = function(){
    if(arguments.length > 1){
        var format = arguments[0];
        for(var i = 1 ; i < arguments.length ; i++){
            format = format.replace('{'+(i-1).toString()+'}',arguments[i].toString());
        }
        return format;
    }
    return '';
}

Date.prototype.format = function(formatString){
    formatString = formatString._localeDateFormat();
    var year = this.getFullYear();
    var month = (this.getMonth() + 1);
    var day = this.getDate();
    var regYear = /[Yy]+/;
    var regMonth = /[Mm]+/;
    var regDay = /[Dd]+/;
    function replaceFormat(reg,value){
        var match = formatString.match(reg);
        if(match){
            value = value.toString();
            var formatLength = match.toString().length;
            var temp = new Array();
            for(var i = formatLength ; i > 0; ){
                if( i > value.length){
                    temp.push('0');
                    --i;
                } 
                else{
                    temp.push(value.substring(value.length - i,value.length - (--i) ));
                }
            }
            var val =  temp.join('');
            formatString = formatString.replace(reg,val);
        }
    }
    replaceFormat(regYear,year);
    replaceFormat(regMonth,month);
    replaceFormat(regDay,day);
    return formatString;
}

//不做任何动作，用于无效按钮
function foo(){
}
var EventUtil = {
    CreateEventHandler:function(context,fn){
    /// <param name="context" type="object">委托执行上下文(this指针)</param>
    /// <param name="fn" type="Function">被委托的方法</param>
    /// <returns type="Function"></returns>
        return function (){
            fn.apply(context,arguments);
        }
    }
}

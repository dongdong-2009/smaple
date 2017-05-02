//添加reference，可在Visual studio 2008的智能提示
//中获得MicrsoftAjax.js中的类型与注释信息

/// <reference name="MicrosoftAjax.js"/>

//声明命名空间
Type.registerNamespace("AJAXControls");

//构造函数
AJAXControls.UpdateDisabler = function AJAXControls$UpdateDisabler(element) {
    //调用父类的初始化方法
    AJAXControls.UpdateDisabler.initializeBase(this,[element]);
    this._onlyDisableTrigger = false;
    this._beginRequestHandlerDelegate = null;
    this._endRequestHandlerDelegate = null;
    this._pageRequestManager = null;
}

    //在脚本中使用和C#中格式相同的注释，
    //可作为VS2008智能提示的数据
    //少使用匿名函数有利于调试时准确地设置断点
    function AJAXControls$UpdateDisabler$get_onlyDisableTrigger() {
        /// <summary>
        /// onlyDisableTrigger属性，
        /// 设置是否仅禁用触发页面提交的控件
        /// </summary>
        /// <value type="Boolean"></value>
        if (arguments.length !== 0) throw Error.parameterCount();
        return this._onlyDisableTrigger;
    }
    
    function AJAXControls$UpdateDisabler$set_onlyDisableTrigger(value) {
        var e = Function._validateParams(arguments, [{name: "value", type: Boolean}]);
        if (e) throw e;

        this._onlyDisableTrigger = value;
    }
    
    function AJAXControls$UpdateDisabler$_handleBeginRequest(sender, arg) {
        /// <param name="request" type="Sys.WebForms.PageRequestManager"></param>
        /// <param name="arg" type="Sys.WebForms.BeginRequestEventArgs"></param>
        if(this.get_onlyDisableTrigger()){
            //arg包括两个属性：request和postBackElement
            var trigger = arg.get_postBackElement();
            trigger.disabled = true;
            trigger.disabledFlag = true;
        }
        else{
            $("select,input,a").each(function(){
                if(!this.disabled){
                    this.disabled = true;
                    //在被禁用对象上添加一个标识，
                    //以便于在于在复原控件时区别本来就被禁用的对象
                    this.diabledFlag = true;
                }
            });
        }
    }
    function AJAXControls$UpdateDisabler$_handleEndRequest(sender, arg) {
        /// <param name="request" type="Sys.WebForms.PageRequestManager"></param>
        /// <param name="arg" type="Sys.WebForms.BeginRequestEventArgs"></param> 
        
        //根据开始更新时设置的标识查找需要复原的控件
        $("select[@disabledFlag],input[@disabledFlag],a[@disabledFlag]").each(function(){
            this.disabled = false;
            this.disabledFlag = false;
        });
    }
    
    function AJAXControls$UpdateDisabler$dispose() {
        /// <summary>对象释构函数</summary>
        if (this._pageRequestManager !== null) {
           this._pageRequestManager.remove_beginRequest(this._beginRequestHandlerDelegate);
           this._pageRequestManager.remove_endRequest(this._endRequestHandlerDelegate);
        }
        AJAXControls.UpdateDisabler.callBaseMethod(this,"dispose");
    }
    
    function AJAXControls$UpdateDisabler$initialize() {
        /// <summary>对象初始化函数</summary>
        AJAXControls.UpdateDisabler.callBaseMethod(this, 'initialize');
    	this._beginRequestHandlerDelegate = Function.createDelegate(this, this._handleBeginRequest);
    	this._endRequestHandlerDelegate = Function.createDelegate(this, this._handleEndRequest);
    	if (Sys.WebForms && Sys.WebForms.PageRequestManager) {
           this._pageRequestManager = Sys.WebForms.PageRequestManager.getInstance();
    	}
    	if (this._pageRequestManager !== null ) {
    	    //注册PageRequestManager的beginRequest和endRequest事件
    	    this._pageRequestManager.add_beginRequest(this._beginRequestHandlerDelegate);
    	    this._pageRequestManager.add_endRequest(this._endRequestHandlerDelegate);
    	}
    }
AJAXControls.UpdateDisabler.prototype = {
    get_onlyDisableTrigger:AJAXControls$UpdateDisabler$get_onlyDisableTrigger,
    set_onlyDisableTrigger:AJAXControls$UpdateDisabler$set_onlyDisableTrigger,
    _handleBeginRequest: AJAXControls$UpdateDisabler$_handleBeginRequest,
    _handleEndRequest: AJAXControls$UpdateDisabler$_handleEndRequest,
    dispose: AJAXControls$UpdateDisabler$dispose,
    initialize: AJAXControls$UpdateDisabler$initialize
}

//注册AJAXControls.UpdateDisabler控件，并使它继承自Sys.UI.Control
AJAXControls.UpdateDisabler.registerClass('AJAXControls.UpdateDisabler', Sys.UI.Control);


if (typeof(Sys) !== 'undefined'){
    if(typeof(Sys.Preview) !== 'undefined'){
        //如果要在ASP.NET Futures的XML-Script功能使用本控件，
        //需要将AJAXControls命名空间添加到默认命名空间中
        var defaultNS = Sys.Preview.MarkupParser._getDefaultNamespaces();
        if(!Array.contains(defaultNS,AJAXControls)){
            Array.add(defaultNS,AJAXControls);
        }
    }
    
    //因为Opera在脚本加载完成后不会触发事件
    //通过调用notifyScriptLoaded()通知框架
    Sys.Application.notifyScriptLoaded();
}

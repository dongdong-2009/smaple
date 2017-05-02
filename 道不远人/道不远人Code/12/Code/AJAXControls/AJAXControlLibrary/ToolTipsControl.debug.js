/// <reference name="MicrosoftAjax.debug.js"/>
/// <reference name="MicrosoftAjaxWebForms.debug.js"/>
/// <reference name="PreviewScript.debug.js"/>

//添加<reference>注释能在Orcas中导入对其它脚本文件的智能感知

//在ASP.NET AJAX框架中注册一个命名空间
Type.registerNamespace("AJAXControls");

//构造函数，通过调用基类的构造函数将associatedElement参数传给基类的element属性
AJAXControls.ToolTips = function AJAXControls$ToolTips(associatedElement) {
    /// <param name="associatedElement" domElement="true"></param>
    //添加<param>格式的注释，为Orcas提供JS智能感知所需的数据
    var e = Function._validateParams(arguments, [
        {name: "associatedElement", domElement: true}
    ]);
    if (e) throw e;   
    //利用ASP.NET AJAX框架的参数验证功能让动态的JS函数也能控制参数的数目和类型
    //但如此一来，JS还是JS吗？
    //在大型的脚本框架，如ASP.NET AJAX中，可以牺牲JS的活泼，得到工程可控性是值得的
    //但在小型的JS应用中，这是我不能接受的
    AJAXControls.ToolTips.initializeBase(this, [associatedElement]);
    //ASP.NET AJAX框架中调用父类构造函数的方法
}

//属性、方法和事件在原型中定义
//JS并没有属性的语法，用get_xxx()/set_xxx()函数表达
//JS并没有事件的语法，用add_xxx()/remove_xxx()函数表达
//应该使用以上标准的命名规则
AJAXControls.ToolTips.prototype = {
    initialize: AJAXControls$ToolTips$initialize,
    dispose: AJAXControls$ToolTips$dispose,
    popupElement:null,
    get_popupElement:AJAXControls$ToolTips$get_popupElement,
    set_popupElement:AJAXControls$ToolTips$set_popupElement,
    _onMouseOver:AJAXControls$ToolTips$_onMouseOver,
    _onMouseOut:AJAXControls$ToolTips$_onMouseOut,
    _overHandler:null,
    _outHandler:null,
    add_show:AJAXControls$ToolTips$add_show,
    remove_show:AJAXControls$ToolTips$remove_show,
    add_hide:AJAXControls$ToolTips$add_hide,
    remove_hide:AJAXControls$ToolTips$remove_hide
}

    //初始化函数
    function AJAXControls$ToolTips$initialize(){
        //调用基类的初始化过程
        AJAXControls.ToolTips.callBaseMethod(this, 'initialize'); 
        //initialize popupElement location and hide it
        var pop = this.get_popupElement();
        if(pop){
            var elmt = this.get_element();
            pop.style.position = 'absolute';
            pop.style.zIndex = 1001;
            var location = Sys.UI.DomElement.getLocation(elmt);
            var bounds = Sys.UI.DomElement.getBounds(elmt);
            location.y += bounds.height;
            Sys.UI.DomElement.setLocation(pop,location.x,location.y);
            pop.style.display = 'none';
        }
        //注册MouseOver和MouseOut事件，
        //使用Funciton.createDelegate函数注册事件响应时的正确上下文
        //事件响应上下文的讨述请参考前面章节
        this._overHandler = Function.createDelegate(this,this._onMouseOver);
        this._outHandler = Function.createDelegate(this,this._onMouseOut);
        $addHandler(this.get_element(),'mouseover',this._overHandler);
        $addHandler(this.get_element(),'mouseout',this._outHandler);
    }

    //ASP.NET AJAX会自动注册window的unload事件，
    //并调用所有Sys.IDisposable接口组件的dispose方法
    //合理的析构函数非常重要，有利于防止内存泄露
    //用户注册到this.get_events()上的Handler调用基类的dispose清除
    function AJAXControls$ToolTips$dispose(){
        if(this._overHandler){
            $removeHandler(this.get_element(),'mouseover',this._overHandler);
        }
        if(this._outHandler){
            $removeHandler(this.get_element(),'mouseout',this._outHandler);
        }        
        this.popupElement = null;
        AJAXControls.ToolTips.callBaseMethod(this, 'dispose');
    }
    
    function AJAXControls$ToolTips$get_popupElement() {
        /// <value type="String" mayBeNull="true"></value>
        if (arguments.length !== 0) throw Error.parameterCount();
        return this.popupElement;
    }

    function AJAXControls$ToolTips$set_popupElement(value) {
        if (this.popupElement !== value) {
            this.popupElement = $get(value);
            this.raisePropertyChanged('popupElement');
        }
    }
    function AJAXControls$ToolTips$_onMouseOver(){
        //触发用户注册的show事件处理函数
        var handler = this.get_events().getHandler("show");
        if (handler) {
            handler(this, Sys.EventArgs.Empty);
        }
        
        var pop = this.get_popupElement();
        if(pop){
            pop.style.display = '';
        }
    }
    function AJAXControls$ToolTips$_onMouseOut(){
        //触发用户注册的hide事件处理函数
        var handler = this.get_events().getHandler("hide");
        if (handler) {
            handler(this, Sys.EventArgs.Empty);
        }
        
        var pop = this.get_popupElement();
        if(pop){
            pop.style.display = 'none';
        }        
    }
    
    //注册自定义show事件处理程序
    function AJAXControls$ToolTips$add_show(handler) {
        var e = Function._validateParams(arguments, [{name: "handler", type: Function}]);
        if (e) throw e;
                
        //将事件处理程序添加到events列表中
        this.get_events().addHandler("show", handler);
    }

    //移除自定义show事件处理程序
    function AJAXControls$ToolTips$remove_show(handler) {
        var e = Function._validateParams(arguments, [{name: "handler", type: Function}]);
        if (e) throw e;

        this.get_events().removeHandler("show", handler);
    }
    
    function AJAXControls$ToolTips$add_hide(handler) {
        var e = Function._validateParams(arguments, [{name: "handler", type: Function}]);
        if (e) throw e;

        this.get_events().addHandler("hide", handler);
    }

    function AJAXControls$ToolTips$remove_hide(handler) {
        var e = Function._validateParams(arguments, [{name: "handler", type: Function}]);
        if (e) throw e;

        this.get_events().removeHandler("hide", handler);
    }    
    
//描述ToolTips结构    
AJAXControls.ToolTips.descriptor = {
    properties:[{name:'popupElement',domElement:true}],
    events: [ { name: 'show' },{name:'hide'} ]
}

//将ToolTips注册为ASP.NET AJAX框架中的类
AJAXControls.ToolTips.registerClass('AJAXControls.ToolTips', Sys.UI.Control);

if (typeof(Sys) !== 'undefined') {
    //要使ToolTips在XMLScript中跟Button等内建组件一样，通过<toolTips>标签声明
    //，必须将AJAXControls命名空间注册到默认命名空间数组中
    //如果您觉得这样太麻烦，可以将ToolTips类声明在Sys.UI等namespace
    var defaultNS = Sys.Preview.MarkupParser._getDefaultNamespaces();
    if(!Array.contains(defaultNS,AJAXControls)){
        Array.add(defaultNS,AJAXControls);
    }
    
    //兼容Safari，因为Safari加载脚本文件后不会触发事件通知
    Sys.Application.notifyScriptLoaded();
}

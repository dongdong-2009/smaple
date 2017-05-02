/// <reference name="MicrosoftAjax.debug.js"/>
/// <reference name="MicrosoftAjaxWebForms.debug.js"/>
/// <reference name="PreviewScript.debug.js"/>

Type.registerNamespace("AJAXControls");

AJAXControls.ToolTips = function AJAXControls$ToolTips(associatedElement) {
    /// <param name="associatedElement" domElement="true"></param>
    var e = Function._validateParams(arguments, [
        {name: "associatedElement", domElement: true}
    ]);
    if (e) throw e;   
    AJAXControls.ToolTips.initializeBase(this, [associatedElement]);
}

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

    function AJAXControls$ToolTips$initialize(){
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
        
        this._overHandler = Function.createDelegate(this,this._onMouseOver);
        this._outHandler = Function.createDelegate(this,this._onMouseOut);
        $addHandler(this.get_element(),'mouseover',this._overHandler);
        $addHandler(this.get_element(),'mouseout',this._outHandler);
    }

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
        var handler = this.get_events().getHandler("hide");
        if (handler) {
            handler(this, Sys.EventArgs.Empty);
        }
        
        var pop = this.get_popupElement();
        if(pop){
            pop.style.display = 'none';
        }        
    }
    function AJAXControls$ToolTips$add_show(handler) {
        var e = Function._validateParams(arguments, [{name: "handler", type: Function}]);
        if (e) throw e;

        this.get_events().addHandler("show", handler);
    }

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
    
    
AJAXControls.ToolTips.descriptor = {
    properties:[{name:'popupElement',domElement:true}],
    events: [ { name: 'show' },{name:'hide'} ]
}

AJAXControls.ToolTips.registerClass('AJAXControls.ToolTips', Sys.UI.Control);

if (typeof(Sys) !== 'undefined') {
     var defaultNS = Sys.Preview.MarkupParser._getDefaultNamespaces();
    if(!Array.contains(defaultNS,AJAXControls)){
        Array.add(defaultNS,AJAXControls);
    }
    Sys.Application.notifyScriptLoaded();
}

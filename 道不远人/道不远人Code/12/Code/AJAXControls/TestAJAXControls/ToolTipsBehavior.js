/// <reference name="MicrosoftAjax.debug.js"/>
/// <reference name="MicrosoftAjaxWebForms.debug.js"/>
/// <reference name="PreviewScript.debug.js"/>

Type.registerNamespace("AJAXControls");

AJAXControls.ToolTipsBehavior = function AJAXControls$ToolTipsBehavior(associatedElement) {
    /// <param name="associatedElement" domElement="true"></param>
    var e = Function._validateParams(arguments, [
        {name: "associatedElement", domElement: true}
    ]);
    if (e) throw e;   
    AJAXControls.ToolTipsBehavior.initializeBase(this, [associatedElement]);
}

AJAXControls.ToolTipsBehavior.prototype = {
    initialize: AJAXControls$ToolTipsBehavior$initialize,
    dispose: AJAXControls$ToolTipsBehavior$dispose,
    _toolTipsContent:'',
    get_toolTipsContent:AJAXControls$ToolTipsBehavior$get_toolTipsContent,
    set_toolTipsContent:AJAXControls$ToolTipsBehavior$set_toolTipsContent,
    getPopupElement:AJAXControls$ToolTipsBehavior$getPopupElement,
    _onMouseOver:AJAXControls$ToolTipsBehavior$_onMouseOver,
    _onMouseOut:AJAXControls$ToolTipsBehavior$_onMouseOut,
    _overHandler:null,
    _outHandler:null,
    add_show:AJAXControls$ToolTipsBehavior$add_show,
    remove_show:AJAXControls$ToolTipsBehavior$remove_show,
    add_hide:AJAXControls$ToolTipsBehavior$add_hide,
    remove_hide:AJAXControls$ToolTipsBehavior$remove_hide
}
    
    function AJAXControls$ToolTipsBehavior$getPopupElement(){
        if(!this._popElement){
            //create popupElement
            this._popElement = document.createElement('div');
            this._popElement.style.width = '150px';
            this._popElement.style.border = 'solid 1px navy';
            this._popElement.style.backgroundColor = 'white';
            this._popElement.style.padding = '3px';
            this._popElement.style.display = 'none';
            this._popElement.style.wordBreak = 'break-all';
            if(document.body){
                document.body.appendChild(this._popElement);
            }
            
            //initialize popupElement location and hide it
            var elmt = this.get_element();
            this._popElement.style.position = 'absolute';
            this._popElement.style.zIndex = 1001;
            this._popElement.innerText = this.get_toolTipsContent();;
            var location = Sys.UI.DomElement.getLocation(elmt);
            var bounds = Sys.UI.DomElement.getBounds(elmt);
            location.y += bounds.height;
            Sys.UI.DomElement.setLocation(this._popElement,location.x,location.y);            
        }
        return this._popElement;
    }

    function AJAXControls$ToolTipsBehavior$initialize(){
        AJAXControls.ToolTipsBehavior.callBaseMethod(this, 'initialize');   
        this._overHandler = Function.createDelegate(this,this._onMouseOver);
        this._outHandler = Function.createDelegate(this,this._onMouseOut);
        $addHandler(this.get_element(),'mouseover',this._overHandler);
        $addHandler(this.get_element(),'mouseout',this._outHandler);
    }

    function AJAXControls$ToolTipsBehavior$dispose(){
        if(this._overHandler){
            $removeHandler(this.get_element(),'mouseover',this._overHandler);
        }
        if(this._outHandler){
            $removeHandler(this.get_element(),'mouseout',this._outHandler);
        }        
        this._popElement = null;
        AJAXControls.ToolTipsBehavior.callBaseMethod(this, 'dispose');
    }
    
    function AJAXControls$ToolTipsBehavior$get_toolTipsContent() {
        /// <value type="String" mayBeNull="true"></value>
        if (arguments.length !== 0) throw Error.parameterCount();
        return this._toolTipsContent;
    }

    function AJAXControls$ToolTipsBehavior$set_toolTipsContent(value) {
        if (this._toolTipsContent !== value) {
            this._toolTipsContent = value;
            this.getPopupElement().innerText = value;
            this.raisePropertyChanged('toolTipsContent');
        }
    }
    
    function AJAXControls$ToolTipsBehavior$_onMouseOver(){
        var handler = this.get_events().getHandler("show");
        if (handler) {
            handler(this, Sys.EventArgs.Empty);
        }
        
        var pop = this.getPopupElement();
        pop.style.display = '';
    }
    
    function AJAXControls$ToolTipsBehavior$_onMouseOut(){
        var handler = this.get_events().getHandler("hide");
        if (handler) {
            handler(this, Sys.EventArgs.Empty);
        }
        
        var pop = this.getPopupElement();
        pop.style.display = 'none';
    }
    
    function AJAXControls$ToolTipsBehavior$add_show(handler) {
        var e = Function._validateParams(arguments, [{name: "handler", type: Function}]);
        if (e) throw e;

        this.get_events().addHandler("show", handler);
    }

    function AJAXControls$ToolTipsBehavior$remove_show(handler) {
        var e = Function._validateParams(arguments, [{name: "handler", type: Function}]);
        if (e) throw e;

        this.get_events().removeHandler("show", handler);
    }
    
    function AJAXControls$ToolTipsBehavior$add_hide(handler) {
        var e = Function._validateParams(arguments, [{name: "handler", type: Function}]);
        if (e) throw e;

        this.get_events().addHandler("hide", handler);
    }

    function AJAXControls$ToolTipsBehavior$remove_hide(handler) {
        var e = Function._validateParams(arguments, [{name: "handler", type: Function}]);
        if (e) throw e;

        this.get_events().removeHandler("hide", handler);
    }    
    
    
AJAXControls.ToolTipsBehavior.descriptor = {
    properties:[{name:'toolTipsContent',type:String}],
    events: [ { name: 'show' },{name:'hide'} ]
}

AJAXControls.ToolTipsBehavior.registerClass('AJAXControls.ToolTipsBehavior', Sys.UI.Behavior);

if (typeof(Sys) !== 'undefined') {
     var defaultNS = Sys.Preview.MarkupParser._getDefaultNamespaces();
    if(!Array.contains(defaultNS,AJAXControls)){
        Array.add(defaultNS,AJAXControls);
    }
    Sys.Application.notifyScriptLoaded();
}


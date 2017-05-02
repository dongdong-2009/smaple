/// <reference name="MicrosoftAjax.js"/>

Type.registerNamespace("AJAXControls");

AJAXControls.UpdateDisabler = function AJAXControls$UpdateDisabler(element) {
    AJAXControls.UpdateDisabler.initializeBase(this,[element]);
    this._onlyDisableTrigger = false;
    this._beginRequestHandlerDelegate = null;
    this._endRequestHandlerDelegate = null;
    this._pageRequestManager = null;
}

    function AJAXControls$UpdateDisabler$get_onlyDisableTrigger() {
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
        if(this.get_onlyDisableTrigger()){
            var trigger = arg.get_postBackElement();
            trigger.disabled = true;
            trigger.disabledFlag = true;
        }
        else{
            $("select,input").each(function(){
                if(!this.disabled){
                    this.disabled = true;
                    this.diabledFlag = true;
                }
            });
        }
    }
    function AJAXControls$UpdateDisabler$_handleEndRequest(sender, arg) {
        $("select[@disabledFlag],input[@disabledFlag]").each(function(){
            this.disabled = false;
            this.disabledFlag = false;
        });
    }
    function AJAXControls$UpdateDisabler$dispose() {
       if (this._pageRequestManager !== null) {
           this._pageRequestManager.remove_beginRequest(this._beginRequestHandlerDelegate);
           this._pageRequestManager.remove_endRequest(this._endRequestHandlerDelegate);
       }
       AJAXControls.UpdateDisabler.callBaseMethod(this,"dispose");
    }
    function AJAXControls$UpdateDisabler$initialize() {
        AJAXControls.UpdateDisabler.callBaseMethod(this, 'initialize');
    	this._beginRequestHandlerDelegate = Function.createDelegate(this, this._handleBeginRequest);
    	this._endRequestHandlerDelegate = Function.createDelegate(this, this._handleEndRequest);
    	if (Sys.WebForms && Sys.WebForms.PageRequestManager) {
           this._pageRequestManager = Sys.WebForms.PageRequestManager.getInstance();
    	}
    	if (this._pageRequestManager !== null ) {
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

AJAXControls.UpdateDisabler.registerClass('AJAXControls.UpdateDisabler', Sys.UI.Control);


if (typeof(Sys) !== 'undefined'){
    if(typeof(Sys.Preview) !== 'undefined'){
        var defaultNS = Sys.Preview.MarkupParser._getDefaultNamespaces();
        if(!Array.contains(defaultNS,AJAXControls)){
            Array.add(defaultNS,AJAXControls);
        }
    }
    Sys.Application.notifyScriptLoaded();
}

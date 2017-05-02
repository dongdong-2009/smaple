Type.registerNamespace('AJAXControls');

AJAXControls.ClientSortBehavior = function(element) {
    AJAXControls.ClientSortBehavior.initializeBase(this, [element]);
    this._sortExpressions = [];
    this._ascendingIconUrl = '<%=WebResource("AJAXControls.ascending.gif")%>';
    this._descendingIconUrl = '<%=WebResource("AJAXControls.descending.gif")%>';
    this._sortedIndex = -1;
    this._sortMode = false;
    this._picture = null;    
}
AJAXControls.ClientSortBehavior.prototype = {
    get_sortExpressions : function(){
        return this._sortExpressions;
    },
    set_sortExpressions : function(value){
        this._sortExpressions = eval("("+value+")");
    },    
    get_ascendingIconUrl : function(){
        return this._ascendingIconUrl;
    },
    set_ascendingIconUrl : function(value){
        if(value && value.trim() != ''){
            this._ascendingIconUrl = value;
            this.raisePropertyChanged("AscendingIconUrl");
        }
    },    
    get_descendingIconUrl : function(){
        return this._descendingIconUrl;
    },
    set_descendingIconUrl : function(value){
        if(value && value.trim() != ''){
            this._descendingIconUrl = value;
            this.raisePropertyChanged("DescendingIconUrl");
        }
    },
    initialize : function() {
        AJAXControls.ClientSortBehavior.callBaseMethod(this, 'initialize');        
        var e = this.get_element();
        if(e.tagName.toLowerCase() != 'table'){
            throw Error.argumentType('TargetControlID',Object.getType(e),'table');
        }
        if(e.rows.length < 1){
            return;
        }
        this._addHeaderClickHandler();
        this._picture = document.createElement("IMG");
        this._picture.style.border = 'none';
        this._picture.style.display = 'inline';
        this._picture.src = this._descendingIconUrl;
        this._picture.src = this._ascendingIconUrl;
    },
    _addHeaderClickHandler : function(){
        var e = this.get_element();
        headRow = e.rows[0];
        for(var i = 0 ; i < headRow.cells.length; i ++){
            if(this._sortExpressions[i] != "none"){
                var cell = headRow.cells[i];
                cell.style.cursor = "s-resize";
                var delegate = Function.createDelegate(this,this._generateSortTable(i));
                $addHandler(cell,'click',delegate);
            }
        }
    },    
    _removeHeaderClickHandler : function(){
        var e = this.get_element();
        headRow = e.rows[0];
        for(var i = 0 ; i < headRow.cells.length; i ++){
            if(this._sortExpressions[i] != "none"){
                var cell = headRow.cells[i];
                $clearHandlers(cell);
            }
        }
    },    
    _generateSortTable : function(iCol){
        return function _sortTable(){
            var e = this.get_element();
            var body = e.tBodies[0];
            var source = e.rows[0].cells[iCol];
            var trs = new Array;
            for(var i=1;i<e.rows.length;i++){
                trs[i-1]=e.rows[i];
            }
            if(iCol == this._sortedIndex){
                this._sortMode = !this._sortMode;
                trs.reverse();
            }
            else{
                trs.sort(this._generateCompareTRs.call(this,iCol));
                this._sortMode =false;
            }
            var fragment = document.createDocumentFragment();
            for(var i = 0 ; i < trs.length; i ++){
                fragment.appendChild(trs[i]);
            }
            body.appendChild(fragment);
            var colCount = e.rows[0].cells.length;
            for(var i = 1;i<e.rows.length;i++){
                if(e.rows[i].cells.length != colCount) body.appendChild(e.rows[i]);
            }
            this._sortedIndex = iCol;
            this._picture.src = this._sortMode?this._ascendingIconUrl:this._descendingIconUrl;
            source.appendChild(this._picture);
        }
    },
    _generateCompareTRs : function(iCol) { 
        var dataType = 'string';
        if(this._sortExpressions[iCol]){
            dataType = this._sortExpressions[iCol];
        }      
        return  function compareTRs(oTR1, oTR2) {
                    function getDateFromFormat(dateString,formatString){
	                    var regDate = /\d+/g;
	                    var regFormat = /[YyMmdHhSs]+/g;
	                    var dateMatches = dateString.match(regDate);
	                    if(dateMatches == null)
	                        return Infinity;
	                    var formatmatches = formatString.match(regFormat);
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
                    function parseCurrency(currentString){
	                    var regParser = /[\d\.]+/g;
	                    var matches = currentString.match(regParser);
	                    if(matches == null)
	                        return Infinity;
	                    var result = '';
	                    var dot = false;
	                    for(var i=0;i<matches.length;i++){
		                    var temp = matches[i];
		                    if(temp =='.'){
			                    if(dot) continue;
		                    }
		                    result += temp;
	                    }
	                    return parseFloat(result);
                    }
                    var convert= function(value,type){
                        switch(type) {
                            case 'int': return parseInt(value);
                            case 'float':return parseFloat(value);
                            case 'date':return new Date(Date.parse(value));
                            case 'string':return value.toString();
                            case 'currency':return parseCurrency(value);
                            default:return getDateFromFormat(value,type);                        
                        }                       
                    }
                    var value1=Infinity;
                    var value2=Infinity;
                    if(!dataType)dataType="string";
                    if(typeof(dataType)=='string'){
                        if(oTR1.cells.length > iCol)
                            value1=convert(oTR1.cells[iCol].firstChild.nodeValue, dataType);
                        if(oTR2.cells.length > iCol) 
                            value2=convert(oTR2.cells[iCol].firstChild.nodeValue, dataType);
                    }
                    else if(typeof(dataType)=="function"){
                        if(oTR1.cells.length > iCol)
                            value1 = dataType(oTR1.cells[iCol]);
                        if(oTR2.cells.length > iCol)
                            value2 = dataType(oTR2.cells[iCol]);
                    }
                    if (value1 < value2) {
                        return -1;
                    } 
                    else if (value1 > value2) {
                        return 1;
                    } 
                    else {
                        return 0;
                    }
                };
    },
    dispose : function() {
        this._removeHeaderClickHandler();
        this._sortExpressions = null;
        this._ascendingIconUrl = null;
        this._descendingIconUrl = null;
        this._sortedIndex = null;
        this._sortMode = null;
        this._picture = null; 
        AJAXControls.ClientSortBehavior.callBaseMethod(this, 'dispose');
    }
}
AJAXControls.ClientSortBehavior.registerClass('AJAXControls.ClientSortBehavior', AjaxControlToolkit.BehaviorBase);

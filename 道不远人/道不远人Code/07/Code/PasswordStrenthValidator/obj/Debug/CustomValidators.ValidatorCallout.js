 var ValidatorCallout = function(validator){
    if(typeof(validator) == 'string')
        this._validator = document.getElementById(validator);
    else
        this._validator = validator;
 }
 
 ValidatorCallout.show = function(validator){
    validator.callout._divContainer.style.display = 'block';
 }
 ValidatorCallout.hide = function(validator){
    validator.callout._divContainer.style.display = 'none';
 }
 ValidatorCallout.zIndex = 999;
 
 ValidatorCallout.prototype = {
    smallAlertPic : '<%= WebResource("CustomValidators.alertsmall.gif")%>',
    largeAlertPic : '<%= WebResource("CustomValidators.alertlarge.gif")%>',
    closePic : '<%= WebResource("CustomValidators.close.gif")%>',
    
    initiate:function(){
        var divContainer = document.createElement("DIV");
        this._divContainer = divContainer;
        divContainer.style.position = 'absolute';
        divContainer.style.zIndex = ValidatorCallout.zIndex;
        ValidatorCallout.zIndex++;
        divContainer.onclick = function(){
            this.style.zIndex = ValidatorCallout.zIndex;
            ValidatorCallout.zIndex ++;
        };
        divContainer.style.cursor = 'default';
        
        var divCorner = document.createElement("DIV");
        divContainer.appendChild(divCorner);
        divCorner.style.width = 15;
        divCorner.style.height = 15;
        divCorner.style.position = 'relative';
        divCorner.style.top = 10;
        divCorner.style.left = 1;
        divCorner.style.borderTop = 'solid 1px black';
        divCorner.style.styleFloat = 'left';
        for(var i = 14; i > 0; i--){
            var div = document.createElement("DIV");
            div.style.width = i;
            div.style.height = 1;
            div.style.styleFloat = 'right';
            div.style.clear = 'right';
            div.style.borderLeft = "solid 1px black";
            div.style.backgroundColor = 'lemonchiffon';
            divCorner.appendChild(div);
        }
        
        var divPanel = document.createElement('DIV');
        divContainer.appendChild(divPanel);
        divPanel.style.styleFloat = 'left';
        divPanel.style.border = 'solid 1px black';
        divPanel.style.padding = 12;
        divPanel.style.backgroundColor = 'lemonchiffon';
        
        var img = document.createElement("IMG");
        divPanel.appendChild(img);
        img.src = this.smallAlertPic;
        img.style.styleFloat = 'left';
        img.style.marginRight = 10;
        img.src = this.largeAlertPic;
        
        var h4 = document.createElement("H4");
        divPanel.appendChild(h4);
        h4.style.styleFloat = 'left';
        h4.style.clear = 'right';
        h4.innerText = 'Validation Message!';
        divPanel.appendChild(document.createElement('BR'));
        
        var span = document.createElement('SPAN');
        divPanel.appendChild(span);
        span.style.display = 'block';
        span.style.styleFloat = 'left';
        span.style.clear = 'right';
        span.appendChild(document.createTextNode(this._validator.errormessage));
        
        var close = document.createElement('IMG');
        divPanel.appendChild(close);
        close.src = this.closePic;
        close.style.position = 'absolute';
        close.style.top = 2;
        close.style.right = 2;
        close.onclick = function(){divContainer.style.display = 'none';};
        document.body.insertBefore(divContainer,document.body.children[0]);
        
        var position =  WebForm_GetElementPosition(this._validator);
        position.x += this._validator.offsetWidth;
        WebForm_SetElementX(divContainer,position.x);
        WebForm_SetElementY(divContainer,position.y); 
        
        divContainer.style.display = 'none';
        
        this._validator.callout = this;  
         
        if(typeof(this._validator.evaluationfunction) ==  'String'){
            this._validator.evaluationfunction = eval(this._validator.evaluationfunction);
        }   
        var evaluationfunction = this._validator.evaluationfunction;
        this._validator.evaluationfunction = function(val){
            if(!evaluationfunction(val)){
                ValidatorCallout.show(val);
                return false;
            }
            else{
                ValidatorCallout.hide(val);
                return true;
            }
        };
    }
 };
 

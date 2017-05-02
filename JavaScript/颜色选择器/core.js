/**
 * @projectDescription 颜色选择器.
 * @author ice deng
 */
function ColorPicker(_defaultColor){
	if(!_defaultColor){
		_defaultColor = "#FFFFFF";
	}
	$.init();
	this.id = ColorPicker.lastid++;
	this.defaultColor = _defaultColor;
	ColorPicker.instanceMap["ColorPicker"+this.id] = this;	
};

ColorPicker.lastid = 0;
ColorPicker.instanceMap = new Array;
ColorPicker.restorePool = new Array;

ColorPicker.prototype.getHtml = function(){
	var html = "<span id=\"$pickerId\" style=\"position:relative\" onclick=\"javascript:void(ColorPicker.popupPicker('$pickerId'));\">"+
			"<img src=\"images/transparentpixel.gif\" id=\"$pickerId#color\" style=\"width:40px;height:20px;border:1px inset gray;background-color:\$defaultColor;cursor:pointer;\">"+
			"<a href=\"javascript:void('ColorPicker$pickerId');\"><span id=\"$pickerId#text\">$defaultColor</span></a></span>"+
			
			"<div style=\"display:none;position:absolute;border:solid 1px gray;background-color:white;z-index:2;width:192px;\" id=\"$pickerId#menu\" onmouseout=\"javascript:ColorPicker.restoreColor('$pickerId');\" onclick=\"javascript:$.onPopup();\">"+
			
			"<img src=\"images/colorpicker.jpg\" onMouseMove=\"javascript:ColorPicker.setColor(event,'$pickerId');\" onClick=\"javascript:ColorPicker.selectColor(event,'$pickerId');\" style=\"cursor:crosshair;width:192px;height:136px;\" />"+
			
			"<nobr><input type=\"text\" size=\"8\" id=\"$pickerId#input\" style=\"border:solid 1px gray;font-size:12px;margin:1px;\" onkeyup=\"ColorPicker.keyColor(event,'$pickerId')\" value=\"$defaultColor\"/>"+
			"<a href=\"javascript:ColorPicker.transparent('$pickerId');\">"+
			"<img src=\"images/grid.gif\" style=\"height:20px; width:20px;\" align=\"absmiddle\" border=\"0\">transparent</a></nobr></div>";
	return html.replace(/\$pickerId/g,"ColorPicker"+this.id).replace(/\$defaultColor/g,this.defaultColor);
};

ColorPicker.prototype.render = function(){
	document.write(this.getHtml());
};

ColorPicker.popupPicker= function(id){
	var pop = $(id);
	var p = $.getDivPoint(pop);
	$.setDivPoint($(id+"#menu"), p.x, p.y+ 20);
	
	$(id+"#menu").style.display = "";
	$.onPopup(document.getElementById(id+"#menu"));
};

ColorPicker.setColor = function(event,id){
	if(!ColorPicker.restorePool[id]){
		ColorPicker.restorePool[id] = $(id+"#input").value;
	}
	
	var d = $.getMousePoint(event,$(id+"#menu"));

	var picked = ColorPicker.colorpicker(d.x,d.y).toUpperCase();

	$(id+"#input").value = picked;
	$(id+"#text").innerHTML = picked;
	$(id+"#color").style.background = picked;
	if(ColorPicker.instanceMap[id].onChange){
		ColorPicker.instanceMap[id].onChange(picked);
	}
	return picked;
};

ColorPicker.selectColor = function(event,id){
	var picked = ColorPicker.setColor(event,id);
	
	$(id+"#menu").style.display = "none";
	ColorPicker.restorePool[id] = picked;
	if(ColorPicker.instanceMap[id].onSelect){
		ColorPicker.instanceMap[id].onSelect(picked);
	}
};

ColorPicker.restoreColor = function(id){
	if(ColorPicker.restorePool[id]){
		$(id+"#input").value = ColorPicker.restorePool[id];
		$(id+"#text").innerHTML = ColorPicker.restorePool[id];
		$(id+"#color").style.background = ColorPicker.restorePool[id];
		if(ColorPicker.instanceMap[id].onChange){
			ColorPicker.instanceMap[id].onChange(ColorPicker.restorePool[id]);
		}
		ColorPicker.restorePool[id] = null;
	}
};

ColorPicker.keyColor = function(e,id){
	try{
		e = e?e:window.event;
		if(e.keyCode==$.Enter){
			if($.popupblock == false && $.popup){
				$.popup.style.display = "none";
			}
		}
		$(id+"#color").style.background = $(id+"#input").value;
		ColorPicker.restorePool[id] = $(id+"#input").value;
		$(id+"#text").innerHTML = ColorPicker.restorePool[id];
	}catch(e){}
};

ColorPicker.transparent= function(id){
	ColorPicker.instanceMap[id].set("transparent");
	$(id+"#menu").style.display = "none";
	if(ColorPicker.instanceMap[id].onChange){
		ColorPicker.instanceMap[id].onChange("transparent");
	}
};

ColorPicker.prototype.set = function(color){
	if(ColorPicker.instanceMap["ColorPicker"+this.id].onChange){
		ColorPicker.instanceMap["ColorPicker"+this.id].onChange(color);
	}
	if(color == "") color = "transparent";
	$("ColorPicker"+this.id+"#input").value = color;
	$("ColorPicker"+this.id+"#text").innerHTML = color;
	$("ColorPicker"+this.id+"#color").style.background = color;
};

ColorPicker.prototype.get = function(){
	return $("ColorPicker"+this.id+"#input").value;
};

ColorPicker.colorpicker = function(prtX,prtY){
	var colorR = 0;
	var colorG = 0;
	var colorB = 0;
	
	if(prtX < 32){
		colorR = 256;
		colorG = prtX * 8;
		colorB = 1;
	}
	if(prtX >= 32 && prtX < 64){
		colorR = 256 - (prtX - 32 ) * 8;
		colorG = 256;
		colorB = 1;
	}
	if(prtX >= 64 && prtX < 96){
		colorR = 1;
		colorG = 256;
		colorB = (prtX - 64) * 8;
	}
	if(prtX >= 96 && prtX < 128){
		colorR = 1;
		colorG = 256 - (prtX - 96) * 8;
		colorB = 256;
	}
	if(prtX >= 128 && prtX < 160){
		colorR = (prtX - 128) * 8;
		colorG = 1;
		colorB = 256;
	}
	if(prtX >= 160){
		colorR = 256;
		colorG = 1;
		colorB = 256 - (prtX - 160) * 8;
	}
	
	if(prtY < 64){
		colorR = colorR + (256 - colorR) * (64 - prtY) / 64;
		colorG = colorG + (256 - colorG) * (64 - prtY) / 64;
		colorB = colorB + (256 - colorB) * (64 - prtY) / 64;
	}
	if(prtY > 64 && prtY <= 128){
		colorR = colorR - colorR * (prtY - 64) / 64;
		colorG = colorG - colorG * (prtY - 64) / 64;
		colorB = colorB - colorB * (prtY - 64) / 64;
	}
	if(prtY > 128){
		colorR = 256 - ( prtX / 192 * 256 );
		colorG = 256 - ( prtX / 192 * 256 );
		colorB = 256 - ( prtX / 192 * 256 );
	}
	
	colorR = parseInt(colorR);
	colorG = parseInt(colorG);
	colorB = parseInt(colorB);
	
	if(colorR >= 256){
		colorR = 255;
	}
	if(colorG >= 256){
		colorG = 255;
	}
	if(colorB >= 256){
		colorB = 255;
	}
	
	colorR = colorR.toString(16);
	colorG = colorG.toString(16);
	colorB = colorB.toString(16);
	
	if(colorR.length < 2){
	colorR = 0 + colorR;
	}
	if(colorG.length < 2){
	colorG = 0 + colorG;
	}
	if(colorB.length < 2){
	colorB = 0 + colorB;
	}
	
	return "#" + colorR + colorG + colorB;
};
function Point(_x,_y){
	this.x = _x;
	this.y = _y;
};
function $() {
  var elements = new Array();
  for (var i = 0; i < arguments.length; i++) {
    var element = arguments[i];
    if (typeof element == 'string')
      element = document.getElementById(element);

    if (arguments.length == 1){
      return element;
	}
    elements.push(element);
  }
  return elements;
};
$.Enter		 = 13;
$.LeftArrow	 = 37;
$.UpArrow		 = 38;
$.RightArrow	 = 39;
$.DownArrow	 = 40;
$.init = function(){
	if($.inited) return;
	$.documentBodyOnClickOld = document.body.onclick;
	document.body.onclick = function(event){
		if($.documentBodyOnClickOld) $.documentBodyOnClickOld();
		if($.popupblock == false && $.popup){
			$.popup.style.display = "none";
		}else{
			$.popupblock = false;
		}
	}
	$.inited = true;
};

$.popupblock;
$.onPopup = function(popup){
	if(popup){
		if($.popup && $.popup != popup) $.popup.style.display = "none";
		$.popup = popup;
	}
	$.popupblock = true;
};
$.getDivPoint = function(div){
	if(div.style && (div.style.position == "absolute" || div.style.position == "relative")){
		return new Point(div.offsetLeft+1, div.offsetTop+1);
	}else if(div.offsetParent){
		var d = $.getDivPoint(div.offsetParent);
		return new Point(d.x+div.offsetLeft, d.y+div.offsetTop);
	}else{
		return new Point(0,0);
	}
};
$.setDivPoint = function(div, x, y){
	div.style.top  = y + "px";
	div.style.left = x + "px";
};
$.getMousePoint = function(e,div){
	try{
		if(div){
			var da = $.getMousePoint(e);
			var db = $.getDivPoint(div);
			return new Point(da.x-db.x,da.y-db.y);
		}
		
		if($.Browser.isIE){
			var p = $.getDivPoint(event.srcElement);
			return new Point(p.x+ event.offsetX,p.y + event.offsetY);
		}else{
			return new Point(e.pageX,e.pageY);
		}
	}catch(e){}
};
$.BrowserDetect = function(){
	doc=window.document;
	navVersion=navigator.appVersion.toLowerCase();
	this.ie4=(!doc.getElementById&&doc.all)?true:false;
	this.ie5=(navVersion.indexOf("msie 5.0")!=-1)?true:false;
	this.ie55=(navVersion.indexOf("msie 5.5")!=-1)?true:false;
	this.ie6=(navVersion.indexOf("msie 6.0")!=-1)?true:false;
	this.ie7=(navVersion.indexOf("msie 7.0")!=-1)?true:false;
	this.isIE=(this.ie5||this.ie55||this.ie6||this.ie7)?true:false;
	this.ff5 = navigator.appName == 'Netscape' ? true : false; //mozilla firefox
	this.ns4 = document.layers ? true : false; //Netscape
	this.isGecko=!this.isIE;
};
$.Browser = new $.BrowserDetect();
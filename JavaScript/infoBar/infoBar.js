//Copyright (c) 2008 Lewis Linn White Jr.
//Author: Lewis Linn White Jr.

//Permission is hereby granted, free of charge, to any person
//obtaining a copy of this software and associated documentation
//files (the "Software"), to deal in the Software without
//restriction, including without limitation the rights to use,
//copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the
//Software is furnished to do so, subject to the following
//conditions:

//The above copyright notice and this permission notice shall be
//included in all copies or substantial portions of the Software.
//Except as contained in this notice, the name(s) of the above 
//copyright holders shall not be used in advertising or otherwise 
//to promote the sale, use or other dealings in this Software without 
//prior written authorization.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//OTHER DEALINGS IN THE SOFTWARE.

//Icons used in this project are graciously provided by the Silk icons set:
//http://www.famfamfam.com/lab/icons/silk/

function infoBar(settings)
{
	//test to see if we can support this
	if(!document.createElement)
	{
		alert('I\'m sorry, but your browser doesn\'t support this feature.');
		return;
	}
	//create an empty settings object if one isn't provided
	if(!settings)
	{
		var settings = {};
	}
	
	//ie6 doesn't support the 'fixed' css position, so will will have to hack around it
	var ie6 = (document.all && window.external && (typeof document.documentElement.style.maxHeight == 'undefined')) ? true : false;	
	
	//Create and setup the info bar
	var infoBar = document.createElement('div');
	this.currentOpacity = 10;
	this.infoBar = infoBar;
	infoBar.style.backgroundColor = settings.backColor || '#fff68f';
	infoBar.style.opacity = '1';
	infoBar.style.filter = 'alpha(opacity=100)';
	infoBar.style.fontSize = '8pt';
	infoBar.style.top = '0px';
	infoBar.style.left = '0px';
	infoBar.style.lineHeight = '12px';
	infoBar.style.padding = '0px';
	infoBar.style.width = '100%';
	infoBar.style.fontFamily = 'Verdana';
	infoBar.style.fontColor = settings.fontColor || '#000000';
	//ie6 doesn't support the 'fixed' css position, so will will have to hack around it
	infoBar.style.position = (ie6) ? 'absolute' : 'fixed';
	infoBar.style.display = 'none';
	infoBar.style.border = '1px solid #000000';
	infoBar.style.borderTop = '0px';
	infoBar.style.borderLeft = '0px';
	infoBar.style.borderRight = '0px';
	infoBar.style.zIndex = 1000;
	//ie6 doesn't support the 'fixed' css position, so will will have to hack around it
	if(ie6)
	{
		window.onscroll = function()
		{
			infoBar.style.top = parseInt(window.pageYOffset || (document.documentElement.scrollTop || 0)) + 'px';
			infoBar.style.left = parseInt(window.pageXOffset || (document.documentElement.scrollLeft || 0)) + 'px';
		}
	}
	
	//Create our icon
	var icon = document.createElement('img');
	this.infoBar.icon = icon;
	icon.src = (settings.icon || 'information') + '.png'; 
	icon.style.cssFloat = 'left';
	icon.style.styleFloat = 'left';  //for IE
	icon.style.verticalAlign = 'middle';
	icon.style.paddingTop = '3px';
	icon.style.paddingLeft = '3px';
	icon.style.paddingRight = '3px';
	icon.style.paddingBottom = '3px';
	
	//Create our close button 
	var close = document.createElement('img');
	close.src = 'cross.png';
	close.style.cssFloat = 'right';
	close.style.styleFloat = 'right'; //for IE
	close.style.verticalAlign = 'middle';
	close.style.paddingTop = '3px';
	close.style.paddingBottom = '3px';
	close.style.cursor = 'pointer';
	close.onclick = function()
	{
		infoBar.style.display = 'none';
	};
	
	//Create our text entry
	var text = document.createElement('div');
	this.infoBar.infoText = text;
	text.innerHTML = settings.text || '';
	text.style.paddingTop = '3px';
	text.style.paddingBottom = '3px';
	
	infoBar.appendChild(close);
	infoBar.appendChild(icon);
	infoBar.appendChild(text);
	document.body.insertBefore(infoBar, document.body.firstChild);
}

infoBar.prototype.show = function(fade)
{
	var that = this;
	if(typeof fade == "number")
	{
		this.currentOpacity = 0;
		this.infoBar.style.opacity = '0';
		this.infoBar.style.filter = 'alpha(opacity=0)';
		this.intervalID = window.setInterval(function()
											{
													if(that.currentOpacity < 11)
													{
														that.infoBar.style.opacity = that.currentOpacity / 10;
														that.infoBar.style.filter = 'alpha(opacity=' + that.currentOpacity * 10 + ')';
														that.currentOpacity++;
													}
													else
													{
														window.clearInterval(that.intervalID);
													}
											}, fade);
	}
	else
	{
		this.infoBar.style.opacity = '1';
		this.infoBar.style.filter = 'alpha(opacity=100)';
	}
	this.infoBar.style.display = 'block';
};

infoBar.prototype.setText = function(newText)
{
	this.infoBar.infoText.innerHTML = newText;
};

infoBar.prototype.setIcon = function(newIcon)
{
	this.infoBar.icon.src = newIcon + '.png';
};

infoBar.prototype.setFontColor = function(fontColor)
{
	this.infoBar.text.style.color = fontColor;
};

infoBar.prototype.setBackColor = function(backColor)
{
	this.infoBar.style.backgroundColor = backColor;
};

infoBar.prototype.hide = function()
{
	this.infoBar.style.display = 'none';
};

infoBar.prototype.destroy = function()
{
	document.body.removeChild(this.infoBar);
};
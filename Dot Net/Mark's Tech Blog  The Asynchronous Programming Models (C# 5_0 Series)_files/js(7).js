BlogEngine={$:function(a){return document.getElementById(a)},webRoot:"",i18n:{hasRated:"",savingTheComment:"",comments:"",commentWasSaved:"",commentWaitingModeration:"",cancel:"",filter:"",apmlDescription:"",beTheFirstToRate:"",currentlyRated:"",ratingHasBeenRegistered:"",rateThisXStars:""},setFlag:function(a){if(a.length>0)BlogEngine.comments.flagImage.src=BlogEngine.webRoot+"pics/flags/"+a+".png";else BlogEngine.comments.flagImage.src=BlogEngine.webRoot+"pics/pixel.gif"},showCommentPreview:function(){var b=this.$("preview"),a=this.$("compose");if(b)b.className="selected";if(a)a.className="";this.$("commentCompose").style.display="none";this.$("commentPreview").style.display="block";this.$("commentPreview").innerHTML='<img src="'+BlogEngine.webRoot+'pics/ajax-loader.gif" alt="Loading" />';var c=this.$("commentPreview").innerHTML;this.addComment(true)},composeComment:function(){var b=this.$("preview"),a=this.$("compose");if(b)b.className="";if(a)a.className="selected";this.$("commentPreview").style.display="none";this.$("commentCompose").style.display="block"},endShowPreview:function(a){BlogEngine.$("commentPreview").innerHTML=a},toggleCommentSavingIndicators:function(a){BlogEngine.$("btnSaveAjax").disabled=a;BlogEngine.$("ajaxLoader").style.display=a?"inline":"none";BlogEngine.$("status").className="";BlogEngine.$("status").innerHTML="";if(!a){BlogEngine.$("commentPreview").innerHTML="";BlogEngine.composeComment()}},onCommentError:function(a){BlogEngine.toggleCommentSavingIndicators(false);a=a||"Unknown error occurred.";var b=a.indexOf("|");if(b>0){a=a.substr(0,b);while(a.length>0&&a.substr(a.length-1,1).match(/\d/))a=a.substr(0,a.length-1)}document.getElementById("recaptcha_response_field")&&Recaptcha.reload();if(document.getElementById("spnSimpleCaptchaIncorrect"))document.getElementById("spnSimpleCaptchaIncorrect").style.display="none";alert("Sorry, the following error occurred while processing your comment:\n\n"+a)},addComment:function(r){var a=r==true;if(!a){BlogEngine.toggleCommentSavingIndicators(true);this.$("status").innerHTML=BlogEngine.i18n.savingTheComment}var i=BlogEngine.comments.nameBox.value,j=BlogEngine.comments.emailBox.value,h=BlogEngine.comments.websiteBox.value,g=BlogEngine.comments.countryDropDown?BlogEngine.comments.countryDropDown.value:"",f=BlogEngine.comments.contentBox.value,t=BlogEngine.$("cbNotify").checked,q=BlogEngine.comments.captchaField.value,n=BlogEngine.comments.replyToId?BlogEngine.comments.replyToId.value:"",e=document.getElementById("recaptcha_response_field"),m=e?e.value:"",d=document.getElementById("recaptcha_challenge_field"),l=d?d.value:"",c=document.getElementById("simpleCaptchaValue"),k=c?c.value:"",b=BlogEngine.$("avatarImgSrc"),s=b&&b.value?b.value:"",p=a?BlogEngine.endShowPreview:BlogEngine.appendComment,o=i+"-|-"+j+"-|-"+h+"-|-"+g+"-|-"+f+"-|-"+t+"-|-"+a+"-|-"+q+"-|-"+n+"-|-"+s+"-|-"+m+"-|-"+l+"-|-"+k;WebForm_DoCallback(BlogEngine.comments.controlId,o,p,"comment",BlogEngine.onCommentError,false);!a&&typeof OnComment!="undefined"&&OnComment(i,j,h,g,f)},cancelReply:function(){this.replyToComment("")},replyToComment:function(a){BlogEngine.comments.replyToId.value=a;var c=BlogEngine.$("comment-form");if(!a||a==""||a==null||a=="00000000-0000-0000-0000-000000000000"){var e=BlogEngine.$("commentlist");e.appendChild(c);BlogEngine.$("cancelReply").style.display="none"}else{BlogEngine.$("cancelReply").style.display="";var d=BlogEngine.$("id_"+a),b=BlogEngine.$("replies_"+a);if(b==null){b=document.createElement("div");b.className="comment-replies";b.setAttribute("id")="replies_"+a;d.appendChild(b)}b.style.display="";b.appendChild(c)}BlogEngine.comments.nameBox.focus()},appendComment:function(b,e){if(e=="comment"){document.getElementById("recaptcha_response_field")&&Recaptcha.reload();if(document.getElementById("spnSimpleCaptchaIncorrect"))document.getElementById("spnSimpleCaptchaIncorrect").style.display="none";if(b=="RecaptchaIncorrect"||b=="SimpleCaptchaIncorrect"){if(document.getElementById("spnCaptchaIncorrect"))document.getElementById("spnCaptchaIncorrect").style.display="";if(document.getElementById("spnSimpleCaptchaIncorrect"))document.getElementById("spnSimpleCaptchaIncorrect").style.display="";BlogEngine.toggleCommentSavingIndicators(false)}else{if(document.getElementById("spnCaptchaIncorrect"))document.getElementById("spnCaptchaIncorrect").style.display="none";if(document.getElementById("spnSimpleCaptchaIncorrect"))document.getElementById("spnSimpleCaptchaIncorrect").style.display="none";var a=BlogEngine.$("commentlist");if(a.innerHTML.length<10)a.innerHTML="<h1 id='comment'>"+BlogEngine.i18n.comments+"</h1>";var c=BlogEngine.comments.replyToId?BlogEngine.comments.replyToId.value:"";if(c!=""){var f=BlogEngine.$("replies_"+c);f.innerHTML+=b}else{a.innerHTML+=b;a.style.display="block"}BlogEngine.comments.contentBox.value="";BlogEngine.comments.contentBox=BlogEngine.$(BlogEngine.comments.contentBox.id);BlogEngine.toggleCommentSavingIndicators(false);BlogEngine.$("status").className="success";if(!BlogEngine.comments.moderation)BlogEngine.$("status").innerHTML=BlogEngine.i18n.commentWasSaved;else BlogEngine.$("status").innerHTML=BlogEngine.i18n.commentWaitingModeration;var d=BlogEngine.$("comment-form");a.appendChild(d);if(BlogEngine.comments.replyToId)BlogEngine.comments.replyToId.value="";if(BlogEngine.$("cancelReply"))BlogEngine.$("cancelReply").style.display="none"}}BlogEngine.$("btnSaveAjax").disabled=false},validateAndSubmitCommentForm:function(){var c=Page_ClientValidate("AddComment"),b=BlogEngine.comments.nameBox.value.length>0;document.getElementById("spnNameRequired").style.display=b?"none":"";var a=true;if(BlogEngine.comments.checkName){var e=BlogEngine.comments.postAuthor,d=BlogEngine.comments.nameBox.value;a=!this.equal(e,d)}document.getElementById("spnChooseOtherName").style.display=a?"none":"";if(c&&b&&a){BlogEngine.addComment();return true}return false},addBbCode:function(b){try{var a=BlogEngine.comments.contentBox;if(a.selectionStart){var e=a.value.substring(0,a.selectionStart),d=a.value.substr(a.selectionEnd),c=a.value.substring(a.selectionStart,a.selectionEnd);a.value=e+"["+b+"]"+c+"[/"+b+"]"+d;a.focus()}else if(document.selection&&document.selection.createRange){var f=document.selection.createRange().text;a.focus();var c=document.selection.createRange();c.text="["+b+"]"+f+"[/"+b+"]"}}catch(g){}return},search:function(d){var c=this.$("searchfield"),b=this.$("searchcomments"),a="search.aspx?q="+encodeURIComponent(c.value);if(b!=null&&b.checked)a+="&comment=true";top.location.href=d+a;return false},searchClear:function(b){var a=this.$("searchfield");if(a.value==b)a.value="";else if(a.value=="")a.value=b},rate:function(b,a){this.createCallback("rating.axd?id="+b+"&rating="+a,BlogEngine.ratingCallback)},ratingCallback:function(a){var c=a.substring(0,1),b=a.substring(1);if(b=="OK"){typeof OnRating!="undefined"&&OnRating(c);alert(BlogEngine.i18n.ratingHasBeenRegistered)}else if(b=="HASRATED")alert(BlogEngine.i18n.hasRated);else alert("An error occured while registering your rating. Please try again")},createCallback:function(c,b){var a=BlogEngine.getHttpObject();a.open("GET",c,true);a.onreadystatechange=function(){if(a.readyState==4)a.responseText.length>0&&b!=null&&b(a.responseText)};a.send(null)},getHttpObject:function(){if(typeof XMLHttpRequest!="undefined")return new XMLHttpRequest;try{return new ActiveXObject("Msxml2.XMLHTTP")}catch(a){try{return new ActiveXObject("Microsoft.XMLHTTP")}catch(a){}}return false},updateCalendar:function(a,b){var c=BlogEngine.$("calendarContainer");c.innerHTML=a;BlogEngine.Calendar.months[b]=a},toggleMonth:function(d){var b=BlogEngine.$("monthList"),a=b.getElementsByTagName("ul");for(i=0;i<a.length;i++)if(a[i].id==d){var c=a[i].className=="open"?"":"open";a[i].className=c;break}},equal:function(b,a){var c=b.toLowerCase().replace(new RegExp(" ","gi"),""),d=a.toLowerCase().replace(new RegExp(" ","gi"),"");return c==d},xfnRelationships:["friend","acquaintance","contact","met","co-worker","colleague","co-resident","neighbor","child","parent","sibling","spouse","kin","muse","crush","date","sweetheart","me"],hightLightXfn:function(){var b=BlogEngine.$("content");if(b==null)return;var c=b.getElementsByTagName("a");for(i=0;i<c.length;i++){var d=c[i],a=d.getAttribute("rel");if(a&&a!="nofollow")for(j=0;j<BlogEngine.xfnRelationships.length;j++)if(a.indexOf(BlogEngine.xfnRelationships[j])>-1){d.title="XFN relationship: "+a;break}}},showRating:function(f,k,i,g){var c=document.createElement("div");c.className="rating";var h=document.createElement("p");c.appendChild(h);if(i==0)h.innerHTML=BlogEngine.i18n.beTheFirstToRate;else h.innerHTML=BlogEngine.i18n.currentlyRated.replace("{0}",new Number(g).toFixed(1)).replace("{1}",i);var e=document.createElement("ul");e.className="star-rating small-star";c.appendChild(e);var d=document.createElement("li");d.className="current-rating";d.style.width=Math.round(g*20)+"%";d.innerHTML="Currently "+g+"/5 Stars.";e.appendChild(d);for(var a=1;a<=5;a++){var j=document.createElement("li"),b=document.createElement("a");b.innerHTML=a;b.href="rate/"+a;b.className=this.englishNumber(a);b.title=BlogEngine.i18n.rateThisXStars.replace("{0}",a.toString()).replace("{1}",a==1?"":"s");b.onclick=function(){BlogEngine.rate(k,this.innerHTML);return false};j.appendChild(b);e.appendChild(j)}f.innerHTML="";f.appendChild(c);f.style.visibility="visible"},applyRatings:function(){for(var b=document.getElementsByTagName("div"),a=0;a<b.length;a++)if(b[a].className=="ratingcontainer"){var c=b[a].innerHTML.split("|");BlogEngine.showRating(b[a],c[0],c[1],c[2])}},englishNumber:function(a){return a==1?"one-star":a==2?"two-stars":a==3?"three-stars":a==4?"four-stars":"five-stars"},addLoadEvent:function(a){var b=window.onload;if(typeof window.onload!="function")window.onload=a;else window.onload=function(){b();a()}},filterByAPML:function(){var h=document.documentElement.clientWidth+document.documentElement.scrollLeft,j=document.documentElement.clientHeight+document.documentElement.scrollTop;document.body.style.position="static";var b=document.createElement("div");b.style.zIndex=2;b.id="layer";b.style.position="absolute";b.style.top="0px";b.style.left="0px";b.style.height=document.documentElement.scrollHeight+"px";b.style.width=h+"px";b.style.backgroundColor="black";b.style.opacity=".6";b.style.filter+="progid:DXImageTransform.Microsoft.Alpha(opacity=60)";document.body.appendChild(b);var a=document.createElement("div");a.style.zIndex=3;a.id="apmlfilter";a.style.position=navigator.userAgent.indexOf("MSIE 6")>-1?"absolute":"fixed";a.style.top="200px";a.style.left=h/2-400/2+"px";a.style.height="50px";a.style.width="400px";a.style.backgroundColor="white";a.style.border="2px solid silver";a.style.padding="20px";document.body.appendChild(a);var g=document.createElement("p");g.innerHTML=BlogEngine.i18n.apmlDescription;g.style.margin="0px";a.appendChild(g);var d=document.createElement("form");d.method="get";d.style.display="inline";d.action=BlogEngine.webRoot;a.appendChild(d);var c=document.createElement("input");c.type="text";c.value=BlogEngine.getCookieValue("url")||"http://";c.style.width="320px";c.id="txtapml";c.name="apml";c.style.background="url("+BlogEngine.webRoot+"pics/apml.png) no-repeat 2px center";c.style.paddingLeft="16px";d.appendChild(c);c.focus();var e=document.createElement("input");e.type="submit";e.value=BlogEngine.i18n.filter;e.onclick=function(){location.href=BlogEngine.webRoot+"?apml="+encodeURIComponent(BlogEngine.$("txtapml").value)};d.appendChild(e);var i=document.createElement("br");a.appendChild(i);var f=document.createElement("a");f.innerHTML=BlogEngine.i18n.cancel;f.href="javascript:void(0)";f.onclick=function(){document.body.removeChild(BlogEngine.$("layer"));document.body.removeChild(BlogEngine.$("apmlfilter"));document.body.style.position=""};a.appendChild(f)},getCookieValue:function(c){var a=new String(document.cookie);if(a!=null&&a.indexOf("comment=")>-1){var b=a.indexOf(c+"=")+c.length+1,d=a.indexOf("&",b);if(d>b&&b>-1)return a.substring(b,d)}return null},test:function(){alert("test")},comments:{flagImage:null,contentBox:null,moderation:null,checkName:null,postAuthor:null,nameBox:null,emailBox:null,websiteBox:null,countryDropDown:null,captchaField:null,controlId:null,replyToId:null}};BlogEngine.addLoadEvent(BlogEngine.hightLightXfn);if(typeof $=="undefined")window.$=BlogEngine.$;typeof registerCommentBox!="undefined"&&BlogEngine.addLoadEvent(registerCommentBox);typeof setupBlogEngineCalendar!="undefined"&&BlogEngine.addLoadEvent(setupBlogEngineCalendar);BlogEngine.addLoadEvent(BlogEngine.applyRatings)
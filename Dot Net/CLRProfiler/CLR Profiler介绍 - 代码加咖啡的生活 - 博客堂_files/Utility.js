function doHighlight(bodyText, searchTerm, highlightStartTag, highlightEndTag) 
{
  if ((!highlightStartTag) || (!highlightEndTag)) {
    highlightStartTag = "<font style='color:blue; background-color:yellow;'>";
    highlightEndTag = "</font>";
  }
  
  
  var newText = "";
  var i = -1;
  var lcSearchTerm = searchTerm.toLowerCase();
  var lcBodyText = bodyText.toLowerCase();
    
  while (bodyText.length > 0) {
    i = lcBodyText.indexOf(lcSearchTerm, i+1);
    if (i < 0) {
      newText += bodyText;
      bodyText = "";
    } else {
      // skip anything inside an HTML tag
      if (bodyText.lastIndexOf(">", i) >= bodyText.lastIndexOf("<", i)) {
        // skip anything inside a <script> block
        if (lcBodyText.lastIndexOf("/script>", i) >= lcBodyText.lastIndexOf("<script", i)) {
          newText += bodyText.substring(0, i) + highlightStartTag + bodyText.substr(i, searchTerm.length) + highlightEndTag;
          bodyText = bodyText.substr(i + searchTerm.length);
          lcBodyText = bodyText.toLowerCase();
          i = -1;
        }
      }
    }
  }
  
  return newText;
}

function trim(str)
{  //删除左右两端的空格
    return str.replace(/(^\s*)|(\s*$)/g, "");
}

/*
 * This is sort of a wrapper function to the doHighlight function.
 * It takes the searchText that you pass, optionally splits it into
 * separate words, and transforms the text on the current web page.
 * Only the "searchText" parameter is required; all other parameters
 * are optional and can be omitted.
 */
function highlightSearchTerms(searchText, treatAsPhrase, warnOnFailure,targetObjectID)
{
  // if the treatAsPhrase parameter is true, then we should search for 
  // the entire phrase that was entered; otherwise, we will split the
  // search string so that each word is searched for and highlighted
  // individually
  
  targetObject=document.getElementById(targetObjectID);
  if (!targetObject || typeof(targetObject.innerHTML) == "undefined") {
    if (warnOnFailure) {
      alert("页面尚未加载完成，请稍候再试.");
    }
    return false;
  }
  searchText=trim(searchText);
  
  if (treatAsPhrase) {
    searchArray = [searchText];
  } else {
    searchArray = searchText.split(" ");
  }
  //alert(searchArray.length);
  
  var bodyText = targetObject.innerHTML;
  bodyText=trim(bodyText);
  for (var i = 0; i < searchArray.length; i++) 
  {
    
    if(searchArray[i].length==0) continue;
      text=trim(searchArray[i]);
     bodyText = doHighlight(bodyText, searchArray[i], false, false);
  }
  
  targetObject.innerHTML = bodyText;
  return true;
}
function joycodeHighlight(searchTerm,targetID)
{
    highlightSearchTerms(searchTerm,false,false,targetID);
}
//http://www.cnblogs.com/birdshome/archive/2006/01/03/UrlBuilder.html, from 鸟食轩
//Copyright by 鸟食轩
function joycodeSearchEngine()
{
    var url = new UrlBuilder(document.referrer);
    if ( url.m_Success )
    {
         var host = url.m_Host.toLowerCase();
         if ( host.indexOf('.google.') != -1 )
         {
             var keywords = url.GetValue('q', 'UTF8');
             if ( keywords )
             {
                  joycodeHighlight(keywords,"searchResult");
             }
         }
         else if ( host.indexOf('.baidu.') != -1 )
         {
            var keywords=url.GetValue("wd","GB2312");
            if(keywords)
            {
            }
        
         }    
    }     
}
function UrlBuilder(url)
{
    this.m_Href = null;
    this.m_Host = null;
    this.m_Hostname = null; 
    this.m_Port = null;
    this.m_Protocol = null;
    this.m_Path = null;
    this.m_Search = null;
    this.m_Hash = null;
    this.m_Params = null; 
    this.m_Sucess = false; 
    if ( url ) this.Parse(url);
   
    this.toString = function()
    {
         return '[class UrlBuilder]';
    };     
}

UrlBuilder.prototype.Parse = function(url)
{
    var m = url.match(/(\w{3,5}:)\/\/([^\.]+(?:\.[^\.:/]+)+)(?::(\d{1,5}))?\/?/);
    if ( m )
    {
         this.m_Protocol = m[1];
         this.m_Hostname = m[2]; 
         this.m_Port = m[3]; 
         if ( this.m_Port ) 
         {
             this.m_Host = this.m_Hostname + ':' + this.m_Port;
         }
         else
         {  
             this.m_Host = m[2];
         }
         var indexHash = url.indexOf('#');
         if ( indexHash != -1 )
         {
             this.m_Hash = url.substr(indexHash);
         }
         else
         {
             this.m_Hash = '';
         }        
         var indexParams = url.indexOf('?');
         if ( indexParams != -1 )
         {
             if ( indexHash != -1 )
             {
                  this.m_Search = url.substring(indexParams, indexHash);
             }
             else
             { 
                  this.m_Search = url.substr(indexParams);
             }
             this.m_Path = url.substr(indexParams);
         }
         else
         {
             this.m_Search = '';
         }
         this.m_Success = true; 
         this.m_Params = null; 
         this.m_Href = url;
    }
};

UrlBuilder.prototype.GetValue = function(key, encoding)
{
    if ( !this.m_Params )
    {
         if ( this.m_Search )
         {
             this.m_Params = {}; 
             var search = this.m_Search.substring(1);
             var keyValues = search.split('&');
             for ( var i=0 ; i < keyValues.length ; ++i )
             {
                  var keyValue = keyValues[i];
                  var index = keyValue.indexOf('=');
                  if ( index != -1 )
                  {
                       this.m_Params[keyValue.substring(0, index)] = keyValue.substr(index+1);
                  }
                  else
                  {
                       this.m_Params[keyValue] = '';
                  }
              }  
         }
    }
    encoding = encoding || ''; 
    switch(encoding.toUpperCase())
    {
         case 'UTF8' :
         {
              return decodeURI(this.m_Params[key]);
         }
         case 'UNICODE' :
         {
              return unescape(this.m_Params[key]);
         }
         case 'GB2312' : // need VBScript function Chr()
         default :
         {
              return this.m_Params[key];
         }
    }  
}
    


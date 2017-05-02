<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangeTitleWebPartUserControl.ascx.cs" Inherits="ClientOMProject.ChangeTitleWebPart.ChangeTitleWebPartUserControl" %>
<script language='javascript' type='text/javascript'>
// <![CDATA[    
    var x = ExecuteOrDelayUntilScriptLoaded(GetTitle, 'sp.js');
    function Button1_onclick() {
    //Update the Site’s title property

site.set_title(document.getElementById('Text1').value);
site.update();
//Add the site to query queue
context.load(site);
//Run the query on the server
context. executeQueryAsync(onTitleUpdate, onQueryFailed);

}

function onTitleUpdate(sender, args) {
    SP.UI.ModalDialog.RefreshPage(SP.UI.DialogResult.OK);
}

var site;
var context;
function GetTitle() {
    //Get the current client context
    context = SP.ClientContext.get_current();
    //Add the site to query queue
    site = context.get_web();
    context.load(site);
    //Run the query on the server
    context.executeQueryAsync(onQuerySucceeded, onQueryFailed);
}

function onQueryFailed(sender, args) {
alert('request failed ' + args.get_message() + '\n' + args.get_stackTrace());
}

function onQuerySucceeded(sender, args) {
document.getElementById('Text1').value = site.get_title();
}

// ]]>
</script>

<p>
<input id='Text1' style='width: 229px' type='text' />&nbsp;
<input id='Button1' type='button' value='button' onclick='return Button1_onclick()' /></p>



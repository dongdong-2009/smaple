<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListOperationsVisualWebPartUserControl.ascx.cs" Inherits="ClientOMProject.ListOperationsVisualWebPart.ListOperationsVisualWebPartUserControl" %>

<script src="/SiteAssets/ListOperations.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">
// <![CDATA[
    function CreateButton_onclick() {
        CreateList();
    }
    function AddButton_onclick() {
        AddListItem();
    }
    function ReadButton_onclick() {
        ReadListItem();
    }
    function UpdateButton_onclick() {
        UpdateListItem();
    }
    function DeleteButton_onclick() {
        DeleteListItems();
    }
// ]]>
</script>
<p><input id="CreateButton" type="button" value="Create List"
style="width: 150px" onclick="CreateButton_onclick()" /></p>
<p><input id="AddButton" type="button" value="Add List Item"
style="width: 150px" onclick="AddButton_onclick()" /></p>
<p><input id="ReadButton" type="button" value="Read List Item"
style="width: 150px" onclick="return ReadButton_onclick()" /></p>
<p><input id="UpdateButton" type="button" value="Update List Item"
style="width: 150px" onclick="return UpdateButton_onclick()" /></p>
<p><input id="DeleteButton" type="button" value="Delete List Item"
style="width: 150px" onclick="return DeleteButton_onclick()" /></p>
<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="HOL1_Ex1.VisualWebPart1.VisualWebPart1UserControl" %>
<%@ Import Namespace="Microsoft.SharePoint.WebControls" %>
<SharePoint:SPGridView id="spGridView" runat="server" AutoGenerateColumns="false">
<HeaderStyle HorizontalAlign="Left" ForeColor="Navy" Font-Bold="true" />
 <Columns> 
  <SharePoint:SPBoundField DataField="Title" HeaderText="Title" ></SharePoint:SPBoundField>
 <SharePoint:SPBoundField DataField="ApproverTitle" HeaderText="Approver" ></SharePoint:SPBoundField>
  </Columns> 
</SharePoint:SPGridView>
<br />
<SharePoint:PeopleEditor runat="Server"  ID="peopleEditor" MultiSelect="false" SelectionSet="User" >
</SharePoint:PeopleEditor>
<br />
<asp:Button ID="btn" runat="server" Text="Press me" onclick="btn_Click"></asp:Button>
<br />
<h1><asp:Label runat="server" ID="lbl"></asp:Label></h1>
<br />

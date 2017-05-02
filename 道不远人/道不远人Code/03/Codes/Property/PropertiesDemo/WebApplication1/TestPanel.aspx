<%@ Page Language="C#" AutoEventWireup="true" Trace="true" Codebehind="TestPanel.aspx.cs"
    Inherits="WebApplication1.TestPanel" %>

<%@ Register Assembly="ControlProperties" Namespace="ControlProperties" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server">
            Welcome to
            <asp:HyperLink ID="hplMicrosoft" runat="Server" NavigateUrl="Http://www.microsoft.com">Microsoft</asp:HyperLink>
        </asp:Panel>
<cc1:NoWhiteSpacePanel ID="NoWhiteSpacePanel1" runat="server">
    Welcome to 
    <asp:HyperLink ID="hplMicrosoft2" runat="Server" NavigateUrl="Http://www.microsoft.com">Microsoft</asp:HyperLink>
</cc1:NoWhiteSpacePanel>
<cc1:NotAllowWhiteSpaceLiteralPanel ID="NotAllowWhiteSpaceLiteralPanel1" runat="server">
    Welcome to 
    <asp:HyperLink ID="HyperLink1" runat="Server" NavigateUrl="Http://www.microsoft.com">        Microsoft</asp:HyperLink>
</cc1:NotAllowWhiteSpaceLiteralPanel>
    </form>
</body>
</html>

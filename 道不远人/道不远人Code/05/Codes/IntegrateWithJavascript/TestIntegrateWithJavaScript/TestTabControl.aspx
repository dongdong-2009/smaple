<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestTabControl.aspx.cs" Inherits="TestTabControl" %>

<%@ Import Namespace="System.Web.UI" %>
<%@ Register Assembly="IntegrateWithJavascriptLibrary" Namespace="IntegrateWithJavascriptLibrary"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <cc1:TabControl ID="TabControl1" runat="server" Width="430px" Height="97px">
                <tab title="AutoFlex">
    <asp:HyperLink ID="hlTextArea" runat="server" NavigateUrl="~/TestAutoFlexTextArea.aspx">Test Auto flex Textarea
</asp:HyperLink></tab>
                <tab title="Tabbable">
    <asp:HyperLink ID="hlTextArea2" runat="server" NavigateUrl="~/TestTabbableTextArea.aspx">Test Tabbable TextArea</asp:HyperLink></tab>
                <tab title="New Tab">
    A tabpage in the tabcontrol</tab>
                <cc1:TabPage runat="Server" Title="NewPage2" ID="page2">
                    the second new page
                </cc1:TabPage>
            </cc1:TabControl>&nbsp;
            
            <cc1:TabControl ID="TabControl2" runat="server">
                <tab title="New Tab">A</tab>
                <tab title="New Tab">B</tab>
                <tab title="New Tab">C</tab>
            </cc1:TabControl></div>
    </form>
</body>
</html>

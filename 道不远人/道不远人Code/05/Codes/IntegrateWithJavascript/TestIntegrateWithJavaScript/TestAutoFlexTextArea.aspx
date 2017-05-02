<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestAutoFlexTextArea.aspx.cs"
    Inherits="TestAutoFlexTextArea" %>

<%@ Register Assembly="IntegrateWithJavascriptLibrary" Namespace="IntegrateWithJavascriptLibrary"
    TagPrefix="cc1" %>
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
            <cc1:AutoFlexTextArea ID="AutoFlexTextArea1" runat="server"></cc1:AutoFlexTextArea>
            <cc1:AutoFlexTextArea ID="AutoFlexTextArea2" runat="server" MaxHeight="200"></cc1:AutoFlexTextArea>
        </div>
    </form>
</body>
</html>

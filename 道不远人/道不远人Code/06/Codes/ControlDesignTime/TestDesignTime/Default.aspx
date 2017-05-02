<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="ControlDesignTimeLabrary" Namespace="ControlDesignTimeLabrary"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <cc1:DropShadowLiteral ID="DropShadowLiteral1" runat="server"></cc1:DropShadowLiteral>
        &nbsp;
        <cc1:DropShadowLiteral ID="DropShadowLiteral2" runat="server">Hello World!</cc1:DropShadowLiteral><br />
        
    </form>
</body>
</html>

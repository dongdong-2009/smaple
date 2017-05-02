<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <sc:RenderHello ID="RenderHello1" runat="server"></sc:RenderHello>
    </div>
    <sc:Albumn ID="Albumn1" runat="server">
    </sc:Albumn>
    <sc:AlbumnUsingEnum id="RenderHello2" runat="server" />
    </form>   
</body>
</html>

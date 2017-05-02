<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestDefaultBookInfo.aspx.cs" Inherits="TestDefaultBookInfo" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="CSS/books.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <tc:DefaultBookInfo ID="DefaultBookInfo1" runat="server">
        </tc:DefaultBookInfo>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestHierarchicalHeader.aspx.cs" Inherits="TestHierarchicalHeader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        h1{text-indent:0px;}
        h2{text-indent:50px;}
        h3{text-indent:100px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dc:HierarchicalHeader ID="HierarchicalHeader1" runat="server" DataSourceID="XmlDataSource1" />
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/books.xml">
        </asp:XmlDataSource>
    </div>
    </form>
</body>
</html>

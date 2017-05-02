<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestAutoFormatTextBox.aspx.cs" Inherits="TestAutoFormatTextBox" %>

<%@ Register Assembly="ControlDesignTimeLabrary" Namespace="ControlDesignTimeLabrary"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<cc1:AutoFormatTextBox ID="AutoFormatTextBox1" runat="server" BorderStyle="Solid" BorderWidth="1px" Columns="20" Rows="20"></cc1:AutoFormatTextBox>&nbsp;<br />
        <br />
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" BackColor="Red" /><br />
    </div>
    </form>
</body>
</html>

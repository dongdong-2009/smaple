<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<%@ Register Assembly="MQTools" Namespace="MQTools" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <strong>Caps Lock1<br />
            Standard TextBox Demo<br />
            Please enter your Password<br /></strong>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <cc1:mqtools id="MQTools1" runat="server" textboxcontrolid="TextBox1" warningdisplaytime="2500"
                width="114px"><b>Waring</b>Caps Lock is On</cc1:mqtools>
            <br />
            </div>
            <asp:Button ID="Button1" runat="server" Text="Submit" />
    </form>
</body>
</html>

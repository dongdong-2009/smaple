<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="PostBackControls" Namespace="PostBackControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:AutoFlexTextArea ID="AutoFlexTextArea1" runat="server" OnTextChanged="AutoFlexTextArea1_TextChanged">Hello world/,.&lt;&gt;</cc1:AutoFlexTextArea>
        <asp:Button ID="Button1" runat="server" Text="Button" /></div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp;
        <br />
        <br />
        <cc1:NumericUpDown ID="NumericUpDown1" runat="server" OnClick="NumericUpDown1_Click" Step="10" Value="10" />    <br />
        <br />
<cc1:CompositeNumericUpDown ID="CompositeNumericUpDown1" runat="server" BorderColor="Red" OnClick="CompositeNumericUpDown1_Click" Step="10" Value="1000" OnTextChanged="CompositeNumericUpDown1_TextChanged">
    <UpButtonStyle BorderColor="Peru" BorderStyle="Inset" BorderWidth="1px" Height="0.5em"
        Position="Absolute" />
    <DownButtonStyle BorderColor="Blue" BorderStyle="Outset" BorderWidth="1px" Height="0.5em"
        Position="Absolute" />
    <InputStyle BorderColor="White" BorderWidth="0px" Height="1em" Position="Absolute"
        Width="80px" />
</cc1:CompositeNumericUpDown>
        &nbsp;
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;&nbsp;<br />
        <br />
    </form>
</body>
</html>

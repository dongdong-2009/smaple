<%@ Page Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<%@ Register Assembly="ControlProperties" Namespace="ControlProperties" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:label runat="server" ID="lblHappy">Happy </asp:label>
        <cc1:Albumn ID="Albumn1" runat="server" ImgUrl="images/nature2.jpg">
        </cc1:Albumn>
        <br />
        <cc1:AlbumnUsingViewState ID="AlbumnUsingViewState1" runat="server" ImgUrl="images/nature2.jpg">
        </cc1:AlbumnUsingViewState>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="更换图片" /></div>
    </form>
</body>
</html>

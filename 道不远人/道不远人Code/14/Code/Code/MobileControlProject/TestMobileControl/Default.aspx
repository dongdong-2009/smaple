<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<?xml version="1.0"?><!DOCTYPE wml PUBLIC "-//WAPFORUM//DTD WML 1.3//EN" "http://www.wapforum.org/DTD/wml13.dtd"><wml>
    <head>
        <title>Test Mobile</title>
        <meta content='no-cache' http-equiv='Cache-Control'/>
    </head>
    <mb:Card id="Main" runat="server">
        <mb:Panel runat="server" id="pnlMain">
            请输入姓名：<mb:Input id="txtName" runat="server">中文字</mb:Input>
            <mb:Button id="btnHello" runat="server"  text="Say Hello" OnClick="btnHello_Click"></mb:Button>
            <mb:MobileLiteral id="lblHello" runat="server"></mb:MobileLiteral>
            <mb:Button id="Button1" runat="server" text="Other button"></mb:Button>
        </mb:Panel>
    </mb:Card>
</wml>
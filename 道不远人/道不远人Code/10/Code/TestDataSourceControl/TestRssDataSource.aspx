<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestRssDataSource.aspx.cs"
    Inherits="TestRssDataSource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        h4
        {
            border-bottom:solid 1px silver;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ds:RssDataSource runat="server" ID="rssCnblogs" Url="http://blog.joycode.com/scottgu/Rss.aspx">
        </ds:RssDataSource>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="rssCnblogs">
            <HeaderTemplate>
                <h2>
                    <a href="http://blog.joycode.com/scottgu/">Scott Guthrie 博客中文版</a>
                </h2>
            </HeaderTemplate>
            <ItemTemplate>
                <h4>
                    <asp:HyperLink ID="hlTitle" runat="server" NavigateUrl='<%#Eval("link")%>' Text='<%# Eval("title")%>'></asp:HyperLink></h4>
                <asp:Label ID="lblTime" runat="server" Text='<%# Eval("pubDate","{0:D}")%>'></asp:Label>|
                <asp:Label ID="lblCreator" runat="server" Text='<%# Eval("dc:creator")%>'></asp:Label>
                <p>
                    <asp:Literal runat="server" Mode="PassThrough" ID="ltlDescription" Text='<%# Eval("description")%>'></asp:Literal>
                </p>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>

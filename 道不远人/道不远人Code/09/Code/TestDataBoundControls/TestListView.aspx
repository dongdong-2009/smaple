<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestListView.aspx.cs" Inherits="TestListView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ListView</title>
    <link href="CSS/books.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dc:ListView runat="Server" ID="lvBooks" DataSourceID="SqlDataSource1" CssClass="listView">
                <AlternatingRowStyle CssClass="alternating-item" />
                <RowStyle CssClass="item" />
                <ItemTemplate>
                    <div>
                        ISDN:
                        <asp:Label ID="ISDNLabel" runat="server" Text='<%# Eval("ISDN") %>'></asp:Label><br />
                        Title:
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>'></asp:Label><br />
                        Author:
                        <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>'></asp:Label><br />
                        Publisher:
                        <asp:Label ID="PublisherLabel" runat="server" Text='<%# Eval("Publisher") %>'></asp:Label></div>
                    <asp:Image runat="server" ImageUrl='<%#Eval("ISDN","~/images/{0}.png") %>' />
                </ItemTemplate>
            </dc:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                SelectCommand="SELECT * FROM [Books]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>

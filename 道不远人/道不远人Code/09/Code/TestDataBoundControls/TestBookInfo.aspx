<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestBookInfo.aspx.cs" Inherits="TestBookInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="CSS/books.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dc:BookInfo runat="server" ID="dbi1" Book-Author="Simon Robinson, et al" Book-ISBN="0764557599"
                Book-Publisher="Wrox" Book-Title="Professional C#">
                <ItemTemplate>
                    <div class="bookContainer">
                        <asp:Image runat="server" ID="imgBook" CssClass="bookCover" AlternateText='<%# Eval("Title") %>'
                            ImageUrl='<%# Eval("ISBN","~/images/{0}.png")%>' />
                        <div class="bookContent">
                            <h3>
                                <%# Eval("Title") %>
                            </h3>
                            Written by:<%# Eval("Author") %><br />
                            ISBN: #<%# Eval("ISBN") %>
                            <div class="bookPublisher">
                                <%# Eval("Publisher") %>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </dc:BookInfo>
        </div>
    </form>
</body>
</html>

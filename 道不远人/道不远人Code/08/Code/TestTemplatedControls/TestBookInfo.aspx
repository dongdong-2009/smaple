<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="TestBookInfo.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="CSS/books.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
<tc:BookInfo ID="tc0470109491" runat="Server" DataItem-Author="Nicholas C. Zakas, Jeremy McPeak, Joe Fawcett" DataItem-Description="My favorite book" DataItem-ISBN="0470109491" DataItem-Publisher="Wrox" DataItem-Title="Professional AJAX">
 <ItemTemplate>
    <div class="bookContainer">
        <asp:Image runat="server" ID="imgBook"  CssClass="bookCover" 
            AlternateText='<%# Container.DataItem.Title %>' 
            ImageUrl='<%# "~/images/"+Container.DataItem.ISBN+".png"%>' />
        <div class="bookContent">
            <h3><%# Container.DataItem.Title %></h3>
            Written by:<%# Container.DataItem.Author %><br />
            ISBN: #<%# Container.DataItem.ISBN %>
            <div class="bookPublisher"><%# Container.DataItem.Publisher %></div>
        </div>
    </div>
 </ItemTemplate>
 </tc:BookInfo><br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
    </form>
</body>
</html>

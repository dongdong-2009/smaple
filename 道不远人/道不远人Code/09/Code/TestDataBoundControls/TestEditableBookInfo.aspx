<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestEditableBookInfo.aspx.cs" Inherits="TestEditableBookInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <dc:EditableBookInfo ID="EditableBookInfo1" runat="Server" Book-Author="Simon Robinson, et al" Book-ISBN="0764557599"
                Book-Publisher="Wrox" Book-Title="Professional C#" OnUpdate="EditableBookInfo1_Update">
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
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton></div>
                    </div>
                </ItemTemplate>
                <EditTemplate>
                    <div class="bookContainer">
                        <asp:Image runat="server" ID="imgBook" CssClass="bookCover" AlternateText='<%# Eval("Title") %>'
                            ImageUrl='<%# Eval("ISBN","~/images/{0}.png")%>' />
                        <div class="bookContent">
                            Title:<asp:TextBox ID="txtTitle" runat="server" Text='<%#Bind("Title")%>'></asp:TextBox>
                            <br />
                            Author:<asp:TextBox ID="txtAuthor" runat="server" Text='<%# Bind("Author")%>'></asp:TextBox><br />
                            Publisher:<asp:TextBox ID="txtPublisher" runat="Server" Text='<%# Bind("Publisher")%>'></asp:TextBox><br />          
                            <asp:LinkButton ID="LinkButton2" CommandName="Update" runat="server">Update</asp:LinkButton>                 
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Cancel">Cancel</asp:LinkButton></div>
                    </div>
                </EditTemplate>
        </dc:EditableBookInfo>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        
    </form>
</body>
</html>
